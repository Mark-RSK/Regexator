// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator.Builder
{
    [DebuggerDisplay("{Kind}: {Pattern}")]
    public partial class Expression
    {
        private Expression _first;
        private Expression _previous;
        private Expression _next;
        private readonly string _value;
        private readonly bool _escape;

        protected Expression()
        {
        }

        internal Expression(string value)
            : this(value, false)
        {
        }

        internal Expression(string value, bool escape)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            _value = value;
            _escape = escape;
        }

        public static Expression Create()
        {
            return new Expression();
        }

        public static Expression Create(string value)
        {
            return new Expression(value, true);
        }

        public Expression Append(string value)
        {
            return Append(value, true);
        }

        internal Expression Append(string value, bool escape)
        {
            return AppendIf(true, value, escape);
        }

        public Expression AppendIf(bool condition, string value)
        {
            return AppendIf(condition, value, true);
        }

        internal Expression AppendIf(bool condition, string value, bool escape)
        {
            return AppendIf(condition, new Expression(value, escape));
        }

        public Expression AppendIf(bool condition, Expression expression)
        {
            return condition ? Append(expression) : this;
        }

        public T Append<T>(T expression) where T : Expression
        {
            if (expression == null) { throw new ArgumentNullException("expression"); }
            Next = expression.First;
            expression.First = First;
            expression.Previous = this;
            return expression;
        }

        public Regex ToRegex()
        {
            return ToRegex(RegexOptions.None);
        }

        public Regex ToRegex(RegexOptions options)
        {
            return new Regex(ToString(), options);
        }

        public override string ToString()
        {
            return ToString(new BuildSettings());
        }

        public string ToString(BuildSettings settings)
        {
            if (settings == null) { throw new ArgumentNullException("settings"); }
            using (var context = new BuildContext() { Settings = settings })
            {
                foreach (var value in EnumerateValues(context))
                {
                    context.Write(value);
                }
                return context.ToString();
            }
        }

        internal IEnumerable<string> EnumerateValues(BuildContext context)
        {
            Expression expression = First;
            do
            {
                foreach (var value in EnumerateValues(expression, context))
                {
                    yield return value;
                }
                expression = expression.Next;
            } while (expression != null);
        }

        private static IEnumerable<string> EnumerateValues(Expression expression, BuildContext context)
        {
            if (!context.Expressions.Add(expression))
            {
                throw new InvalidOperationException("A circular reference was detected while creating a pattern.");
            }
            string opening = expression.Opening(context);
            if (opening != null)
            {
                yield return opening;
            }
            foreach (var value in expression.EnumerateContent(context))
            {
                yield return value;
            }
            if (expression.Closing != null)
            {
                yield return expression.Closing;
            }
            context.Expressions.Remove(expression);
        }

        internal virtual IEnumerable<string> EnumerateContent(BuildContext context)
        {
            string value = Value;
            if (value != null)
            {
                yield return value;
            }
        }

        internal virtual string Opening(BuildContext context)
        {
            return null;
        }

        internal virtual string Closing
        {
            get { return null; }
        }

        internal virtual string Value
        {
            get { return _escape ? Utilities.Escape(_value) : _value; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal string Pattern
        {
            get { return string.Concat(EnumerateValues(this, new BuildContext())); }
        }

        internal Expression First
        {
            get { return _first ?? this; }
            set { _first = value; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Expression Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }

        internal Expression Next
        {
            get { return _next; }
            set { _next = value; }
        }

        internal virtual ExpressionKind Kind
        {
            get { return ExpressionKind.None; }
        }
    }
}