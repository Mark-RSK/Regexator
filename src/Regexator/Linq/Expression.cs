// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
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

        public static Expression Create(params object[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return Create(values.AsEnumerable());
        }

        public static Expression Create(IEnumerable<object> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return Expression.Empty.Concat(values);
        }

        public Expression ConcatIf(bool condition, object content)
        {
            return condition ? Concat(content) : this;
        }

        public Expression Concat(object content)
        {
            if (content == null)
            {
                return this;
            }

            Expression expression = content as Expression;
            if (expression != null)
            {
                return Concat(expression);
            }

            string text = content as string;
            if (text != null)
            {
                return Concat(text);
            }

            CharGroupItem item = content as CharGroupItem;
            if (item != null)
            {
                return Concat(item.ToGroup());
            }

            object[] values = content as object[];
            if (values != null)
            {
                Expression exp = this;
                foreach (var value in values)
                {
                    exp = exp.Concat(value);
                }
                return exp;
            }

            IEnumerable items = content as IEnumerable;
            if (items != null)
            {
                Expression exp = this;
                foreach (var value in items)
                {
                    exp = exp.Concat(value);
                }
                return exp;
            }

            return Concat(content.ToString());
        }

        public Expression Concat(params object[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return Concat(values.AsEnumerable());
        }

        public Expression Concat(IEnumerable<object> values)
        {
            return Concat((object)values);
        }

        public Expression Concat(Expression expression)
        {
            return ConcatInternal(new ContainerExpression(expression));
        }

        public Expression Concat(string value)
        {
            return ConcatInternal(new TextExpression(value));
        }

        internal TExpression ConcatInternal<TExpression>(TExpression expression) where TExpression : Expression
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

        public static Expression Join(object joinValue, params object[] values)
        {
            return Join(joinValue, values.AsEnumerable());
        }

        public static Expression Join(object joinValue, IEnumerable<object> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (joinValue == null)
            {
                joinValue = Expression.Empty;
            }

            using (IEnumerator<object> en = values.GetEnumerator())
            {
                if (!en.MoveNext())
                {
                    return Expression.Empty;
                }

                Expression exp = Expression.Empty;

                if (en.Current != null)
                {
                    exp = exp.Concat(en.Current);
                }

                while (en.MoveNext())
                {
                    exp = exp.Concat(joinValue);

                    if (en.Current != null)
                    {
                        exp = exp.Concat(en.Current);
                    }
                }

                return exp;
            }
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

        internal static IEnumerable<string> EnumerateValues(object content, BuildContext context)
        {
            if (content == null)
            {
                yield break;
            }

            Expression expression = content as Expression;
            if (expression != null)
            {
                foreach (var value in expression.EnumerateValues(context))
                {
                    yield return value;
                }
            }
            else
            {
                string text = content as string;
                if (text != null)
                {
                    yield return text;
                }
                else
                {
                    CharGroupItem item = content as CharGroupItem;
                    if (item != null)
                    {
                        yield return Syntax.CharGroup(item.Value);
                    }
                    else
                    {
                        IEnumerable items = content as IEnumerable;
                        if (items != null)
                        {
                            foreach (var item2 in items)
                            {
                                foreach (var value in EnumerateValues(item2, context))
                                {
                                    yield return value;
                                }
                            }
                        }
                        else
                        {
                            yield return content.ToString();
                        }
                    }
                }
            }
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

        public IEnumerable<Match> Matches(string input)
        {
            return Regex.EnumerateMatches(input);
        }

        public IEnumerable<Match> Matches(string input, int startAt)
        {
            return Regex.EnumerateMatches(input, startAt);
        }

        public IEnumerable<Match> Matches(string input, int beginning, int length)
        {
            return Regex.EnumerateMatches(input, beginning, length);
        }

        public int MatchCount(string input)
        {
            return Matches(input).Count();
        }

        public int MatchCount(string input, int startAt)
        {
            return Matches(input, startAt).Count();
        }

        public int MatchCount(string input, int beginning, int length)
        {
            return Matches(input, beginning, length).Count();
        }

        public IEnumerable<Group> Groups(string input)
        {
            return Regex.EnumerateGroups(input);
        }

        public IEnumerable<Group> Groups(string input, int startAt)
        {
            return Regex.EnumerateGroups(input, startAt);
        }

        public IEnumerable<Group> Groups(string input, int beginning, int length)
        {
            return Regex.EnumerateGroups(input, beginning, length);
        }

        public IEnumerable<Group> SuccessGroups(string input)
        {
            return Regex.EnumerateSuccessGroups(input);
        }

        public IEnumerable<Group> SuccessGroups(string input, int startAt)
        {
            return Regex.EnumerateSuccessGroups(input, startAt);
        }

        public IEnumerable<Group> SuccessGroups(string input, int beginning, int length)
        {
            return Regex.EnumerateSuccessGroups(input, beginning, length);
        }

        public IEnumerable<Capture> Captures(string input)
        {
            return Regex.EnumerateCaptures(input);
        }

        public IEnumerable<Capture> Captures(string input, int startAt)
        {
            return Regex.EnumerateCaptures(input, startAt);
        }

        public IEnumerable<Capture> Captures(string input, int beginning, int length)
        {
            return Regex.EnumerateCaptures(input, beginning, length);
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

        public static explicit operator string(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return expression.ToString();
        }

        public static explicit operator Expression(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return new TextExpression(text);
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