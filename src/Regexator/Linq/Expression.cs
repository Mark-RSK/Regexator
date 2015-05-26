// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public partial class Expression
    {
        private Expression _previous;
        private Regex _regex;
        private static readonly object _syncRoot = new object();
        internal static readonly Expression Empty = new Expression();

        public Expression()
        {
        }

        public Expression Append(string value)
        {
            return Append(value, true);
        }

        public Expression Append(IEnumerable<string> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            Expression exp = this;
            foreach (var item in values)
            {
                exp = exp.Append(item);
            }
            return exp;
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
            return condition ? AppendInternal(new TextExpression(value, escape)) : this;
        }

        public Expression AppendIf(bool condition, Expression expression)
        {
            return condition ? Append(expression) : this;
        }

        public Expression AppendIf(bool condition, Expression yesExpression, Expression noExpression)
        {
            return condition ? Append(yesExpression) : Append(noExpression);
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

        public Expression Append(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Expression expression = value as Expression;
            return (expression != null)
                ? Append(expression)
                : Append(value.ToString());
        }

        public Expression Append(Expression expression)
        {
            return AppendInternal(new ContainerExpression(expression));
        }

        public Expression Append(IEnumerable<Expression> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }
            Expression exp = this;
            foreach (var item in expressions)
            {
                exp = exp.Append(item);
            }
            return exp;
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
            string s = Value(context);
            if (s != null)
            {
                yield return s;
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

        public static Expression Join(Expression joinExpression, params string[] values)
        {
            return Join(joinExpression, values.AsEnumerable());
        }

        public static Expression Join(Expression joinExpression, IEnumerable<string> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return Join(joinExpression, values.Select(value => Expressions.Text(value)));
        }

        public static Expression Join(Expression joinExpression, params Expression[] expressions)
        {
            return Join(joinExpression, expressions.AsEnumerable());
        }

        public static Expression Join(Expression joinExpression, IEnumerable<Expression> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }

            if (joinExpression == null)
            {
                joinExpression = Empty;
            }

            using (IEnumerator<Expression> en = expressions.GetEnumerator())
            {
                if (!en.MoveNext())
                {
                    return Empty;
                }

                Expression exp = Empty;

                if (en.Current != null)
                {
                    exp = exp.Append(en.Current);
                }

                while (en.MoveNext())
                {
                    exp = exp.Append(joinExpression);

                    if (en.Current != null)
                    {
                        exp = exp.Append(en.Current);
                    }
                }

                return exp;
            }
        }

        public static Expression Concat(IEnumerable<Expression> expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }

            return Empty.Append(expressions);
        }

        public IEnumerable<Match> EnumerateMatches(string input)
        {
            return Regex.EnumerateMatches(input);
        }

        public IEnumerable<Match> EnumerateMatches(string input, int startAt)
        {
            return Regex.EnumerateMatches(input, startAt);
        }

        public IEnumerable<Match> EnumerateMatches(string input, int beginning, int length)
        {
            return Regex.EnumerateMatches(input, beginning, length);
        }

        public bool IsMatch(string input)
        {
            return this.Regex.IsMatch(input);
        }

        public bool IsMatch(string input, int startAt)
        {
            return this.Regex.IsMatch(input, startAt);
        }

        public Match Match(string input)
        {
            return this.Regex.Match(input);
        }

        public Match Match(string input, int startAt)
        {
            return this.Regex.Match(input, startAt);
        }

        public Match Match(string input, int beginning, int length)
        {
            return this.Regex.Match(input, beginning, length);
        }

        public string Replace(string input)
        {
            return this.Regex.Replace(input, string.Empty);
        }

        public string Replace(string input, MatchEvaluator evaluator)
        {
            return this.Regex.Replace(input, evaluator);
        }

        public string Replace(string input, string replacement)
        {
            return this.Regex.Replace(input, replacement);
        }

        public string Replace(string input, string replacement, int count)
        {
            return this.Regex.Replace(input, replacement, count);
        }

        public string Replace(string input, string replacement, int count, int startAt)
        {
            return this.Regex.Replace(input, replacement, count, startAt);
        }

        public string Replace(string input, MatchEvaluator evaluator, int count)
        {
            return this.Regex.Replace(input, evaluator, count);
        }

        public string Replace(string input, MatchEvaluator evaluator, int count, int startAt)
        {
            return this.Regex.Replace(input, evaluator, count, startAt);
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

        public Regex Regex
        {
            get
            {
                if (_regex == null)
                {
                    lock (_syncRoot)
                    {
                        if (_regex == null)
                        {
                            _regex = ToRegex();
                        }
                    }
                }

                return _regex;
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