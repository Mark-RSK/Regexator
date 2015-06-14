// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using Pihrtsoft.Text.RegularExpressions.Linq.Extensions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public partial class Expression
    {
        private Regex _regex;
        internal static readonly Expression Empty = new Expression();

        protected Expression()
        {
        }

        public static Expression Create(object content)
        {
            return new ContainerExpression(content);
        }

        public Expression ConcatIf(bool condition, object content)
        {
            return condition ? Concat(content) : this;
        }

        public Expression Concat(object content)
        {
            return ConcatInternal(new ContainerExpression(content));
        }

        public static Expression Concat(params object[] content)
        {
            return Create((object)content);
        }

        public static Expression Concat(IEnumerable<object> content)
        {
            return Create((object)content);
        }

        public Expression Concat(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return ConcatInternal(expression.AsContainer());
        }

#if DEBUG
        public Expression Concat(string text)
        {
            return Concat(text, false);
        }

        public Expression Concat(string text, bool ignoreCase)
        {
            return ConcatInternal(new TextExpression(text, ignoreCase));
        }
#else
        public Expression Concat(string text)
        {
            return ConcatInternal(new TextExpression(text));
        }
#endif

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

        public static Expression Join(object separator, params object[] values)
        {
            return new JoinContainerExpression(separator, (object)values);
        }

        public static Expression Join(object separator, IEnumerable<object> values)
        {
            return new JoinContainerExpression(separator, (object)values);
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

            using (var context = new PatternContext(settings))
            {
                Build(context);
                return context.ToString();
            }
        }

        internal void Build(PatternContext context)
        {
            if (Previous != null)
            {
                Expression[] expressions = GetExpressions().ToArray();
                for (int i = (expressions.Length - 1); i >= 0; i--)
                {
                    Build(expressions[i], context);
                }
            }
            else
            {
                Build(this, context);
            }
        }

        private IEnumerable<Expression> GetExpressions()
        {
            Expression exp = this;
            do
            {
                yield return exp;
                exp = exp.Previous;
            } while (exp != null);
        }

        internal static string GetValue(object content)
        {
            return GetValue(content, new PatternSettings());
        }

        internal static string GetValue(object content, PatternSettings settings)
        {
            using (var context = new PatternContext(settings))
            {
                Build(content, context);
                return context.ToString();
            }
        }

        internal static void Build(object content, PatternContext context)
        {
            if (content == null)
            {
                return;
            }

            Expression expression = content as Expression;
            if (expression != null)
            {
                expression.Build(context);
                return;
            }

            string text = content as string;
            if (text != null)
            {
                context.Write(RegexUtilities.Escape(text));
                return;
            }

            CharGroupItem item = content as CharGroupItem;
            if (item != null)
            {
                item.BuildGroup(context);

                return;
            }

            object[] values = content as object[];
            if (values != null)
            {
                foreach (var value in values)
                {
                    Build(value, context);
                }

                return;
            }

            IEnumerable items = content as IEnumerable;
            if (items != null)
            {
                foreach (var value in items)
                {
                    Build(value, context);
                }
            }
        }

        private static void Build(Expression expression, PatternContext context)
        {
#if DEBUG
            if (!context.Expressions.Add(expression))
            {
                throw new InvalidOperationException("A circular reference was detected while creating a pattern.");
            }
#endif
            expression.BuildOpening(context);

            expression.BuildContent(context);

            expression.BuildClosing(context);
#if DEBUG
            context.Expressions.Remove(expression);
#endif
        }

        internal virtual void BuildContent(PatternContext context)
        {
            string s = Value(context);
            if (s != null)
            {
                context.Write(s);
            }
        }

        internal virtual void BuildOpening(PatternContext context)
        {

        }

        internal virtual void BuildClosing(PatternContext context)
        {

        }

        internal virtual string Value(PatternContext context)
        {
            return null;
        }

        internal Expression AsContainer()
        {
            return new ContainerExpression(this);
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

        public IEnumerable<Group> Groups(string groupName,string input)
        {
            return Regex.EnumerateGroups(groupName, input);
        }

        public IEnumerable<Group> Groups(string groupName, string input, int startAt)
        {
            return Regex.EnumerateGroups(groupName, input, startAt);
        }

        public IEnumerable<Group> Groups(string groupName, string input, int beginning, int length)
        {
            return Regex.EnumerateGroups(groupName, input, beginning, length);
        }

        public IEnumerable<Group> Groups(int groupNumber, string input)
        {
            return Regex.EnumerateGroups(groupNumber, input);
        }

        public IEnumerable<Group> Groups(int groupNumber, string input, int startAt)
        {
            return Regex.EnumerateGroups(groupNumber, input, startAt);
        }

        public IEnumerable<Group> Groups(int groupNumber, string input, int beginning, int length)
        {
            return Regex.EnumerateGroups(groupNumber, input, beginning, length);
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

        public IEnumerable<Group> SuccessGroups(string groupName, string input)
        {
            return Regex.EnumerateSuccessGroups(groupName, input);
        }

        public IEnumerable<Group> SuccessGroups(string groupName, string input, int startAt)
        {
            return Regex.EnumerateSuccessGroups(groupName, input, startAt);
        }

        public IEnumerable<Group> SuccessGroups(string groupName, string input, int beginning, int length)
        {
            return Regex.EnumerateSuccessGroups(groupName, input, beginning, length);
        }

        public IEnumerable<Group> SuccessGroups(int groupNumber, string input)
        {
            return Regex.EnumerateSuccessGroups(groupNumber, input);
        }

        public IEnumerable<Group> SuccessGroups(int groupNumber, string input, int startAt)
        {
            return Regex.EnumerateSuccessGroups(groupNumber, input, startAt);
        }

        public IEnumerable<Group> SuccessGroups(int groupNumber, string input, int beginning, int length)
        {
            return Regex.EnumerateSuccessGroups(groupNumber, input, beginning, length);
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

        public IEnumerable<Capture> Captures(string groupName, string input)
        {
            return Regex.EnumerateCaptures(groupName, input);
        }

        public IEnumerable<Capture> Captures(string groupName, string input, int startAt)
        {
            return Regex.EnumerateCaptures(groupName, input, startAt);
        }

        public IEnumerable<Capture> Captures(string groupName, string input, int beginning, int length)
        {
            return Regex.EnumerateCaptures(groupName, input, beginning, length);
        }

        public IEnumerable<Capture> Captures(int groupNumber, string input)
        {
            return Regex.EnumerateCaptures(groupNumber, input);
        }

        public IEnumerable<Capture> Captures(int groupNumber, string input, int startAt)
        {
            return Regex.EnumerateCaptures(groupNumber, input, startAt);
        }

        public IEnumerable<Capture> Captures(int groupNumber, string input, int beginning, int length)
        {
            return Regex.EnumerateCaptures(groupNumber, input, beginning, length);
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

        #region + and | operators

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(Expression left, Expression right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return left.Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(Expression left, string right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return left.Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(string left, Expression right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Expression.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(Expression left, CharGroupItem right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return left.Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(CharGroupItem left, Expression right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Expression.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(Expression left, char right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            return left.Concat(Chars.Char(right));
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(char left, Expression right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Chars.Char(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(Expression left, Expression right)
        {
            return Alternations.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(Expression left, string right)
        {
            return Alternations.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(string left, Expression right)
        {
            return Alternations.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(Expression left, CharGroupItem right)
        {
            return Alternations.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(CharGroupItem left, Expression right)
        {
            return Alternations.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(Expression left, char right)
        {
            return Alternations.Or(left, right.ToString());
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(char left, Expression right)
        {
            return Alternations.Or(left.ToString(), right);
        }

        #endregion

        public static explicit operator Expression(string text)
        {
            return new TextExpression(text);
        }

        public Regex Regex
        {
            get
            {
                if (_regex == null)
                {
                    _regex = ToRegex();
                }

                return _regex;
            }
        }

        internal Expression Previous { get; set; }
    }
}