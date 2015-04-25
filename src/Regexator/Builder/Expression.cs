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
    public abstract partial class Expression
    {
        private Expression _previous;

        protected Expression()
        {
        }

        public static Expression Create()
        {
            return new TextExpression();
        }

        public static Expression Create(string value)
        {
            return new TextExpression(value);
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
            return AppendIf(condition, new TextExpression(value, escape));
        }

        public Expression AppendIf(bool condition, Expression expression)
        {
            return condition ? Append(expression) : this;
        }

        public T Append<T>(T expression) where T : Expression
        {
            if (expression == null) { throw new ArgumentNullException("expression"); }
            Expression first = expression;
            while (first.Previous != null)
            {
                first = first.Previous;
            }
            first.Previous = this;
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
            return ToString(new PatternSettings());
        }

        public string ToString(PatternSettings settings)
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
            if (Previous != null)
            {
                var items = new Stack<Expression>(EnumerateExpressions());
                while (items.Count > 0)
                {
                    foreach (var value in EnumerateValues(items.Pop(), context))
                    {
                        yield return value;
                    }
                }
            }
            else
            {
                foreach (var value in EnumerateValues(this, context))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<Expression> EnumerateExpressions()
        {
            Expression expression = this;
            do
            {
                yield return expression;
                expression = expression.Previous;
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
            get { return null; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal string Pattern
        {
            get { return string.Concat(EnumerateValues(this, new BuildContext())); }
        }

        internal Expression Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }

        internal virtual ExpressionKind Kind
        {
            get { return ExpressionKind.None; }
        }
    }
}