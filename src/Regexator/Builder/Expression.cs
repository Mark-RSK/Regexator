// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            return condition ? AppendInternal(expression) : this;
        }

        internal TExpression AppendInternal<TExpression>(TExpression expression) where TExpression : Expression
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            Expression first = expression;
            while (first.Previous != null)
            {
                first = first.Previous;
            }
            first.Previous = this;
            return expression;
        }

        public Expression Append(Expression expression)
        {
            return AppendInternal(new ContainerExpression(expression));
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
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
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
            string closing = expression.Closing(context);
            if (closing != null)
            {
                yield return closing;
            }
            context.Expressions.Remove(expression);
        }

        internal virtual IEnumerable<string> EnumerateContent(BuildContext context)
        {
            string value = Value(context);
            if (value != null)
            {
                yield return value;
            }
        }

        internal virtual string Opening(BuildContext context)
        {
            return null;
        }

        internal virtual string Closing(BuildContext context)
        {
            return null;
        }

        internal virtual string Value(BuildContext context)
        {
            return null;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal string Pattern
        {
            get
            {
                using (var context = new BuildContext())
                {
                    return string.Concat(EnumerateValues(this, context));
                }
            }
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