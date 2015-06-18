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
        private string _pattern;
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

        public static Expression Surround(object surroundContent, object content)
        {
            return Surround(surroundContent, content, surroundContent);
        }

        internal static Expression Surround(object contentBefore, object content, object contentAfter)
        {
            return new SurroundExpression(contentBefore, content, contentAfter);
        }

        internal static Expression Surround(AsciiChar surroundChar, object value)
        {
            return Surround(surroundChar, value, surroundChar);
        }

        internal static Expression Surround(AsciiChar charBefore, object value, AsciiChar charAfter)
        {
            return new AsciiCharSurroundExpression(charBefore, value, charAfter);
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

            using (var writer = new PatternWriter(settings))
            {
                writer.Write(this);
                return writer.ToString();
            }
        }

        internal IEnumerable<Expression> GetExpressions()
        {
            Expression exp = this;
            do
            {
                yield return exp;
                exp = exp.Previous;
            } while (exp != null);
        }

        internal static string GetPattern(object content)
        {
            return GetPattern(content, new PatternSettings());
        }

        internal static string GetPattern(object content, PatternSettings settings)
        {
            using (var writer = new PatternWriter(settings))
            {
                writer.Write(content);
                return writer.ToString();
            }
        }

        internal virtual void WriteTo(PatternWriter writer)
        {

        }

        internal Expression AsContainer()
        {
            return new ContainerExpression(this);
        }

        public MatchCollection Matches(string input)
        {
            return Regex.Matches(input, Pattern);
        }

        public MatchCollection Matches(string input, RegexOptions options)
        {
            return Regex.Matches(input, Pattern, options);
        }

        public IEnumerable<Match> EnumerateMatches(string input)
        {
            return EnumerateMatches(input, RegexOptions.None);
        }

        public IEnumerable<Match> EnumerateMatches(string input, RegexOptions options)
        {
            Match match = Regex.Match(input, Pattern, options);
            while (match.Success)
            {
                yield return match;
                match = match.NextMatch();
            }
        }

        public int MatchCount(string input)
        {
            return Matches(input).Count;
        }

        public int MatchCount(string input, RegexOptions options)
        {
            return Matches(input, options).Count;
        }

        public IEnumerable<Group> EnumerateGroups(string input)
        {
            return EnumerateGroups(input, RegexOptions.None);
        }

        public IEnumerable<Group> EnumerateGroups(string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateGroups();
        }

        public IEnumerable<Group> EnumerateGroups(string groupName, string input)
        {
            return EnumerateGroups(groupName, input, RegexOptions.None);
        }

        public IEnumerable<Group> EnumerateGroups(string groupName, string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateGroups(groupName);
        }

        public IEnumerable<Group> EnumerateGroups(int groupNumber, string input)
        {
            return EnumerateGroups(groupNumber, input, RegexOptions.None);
        }

        public IEnumerable<Group> EnumerateGroups(int groupNumber, string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateGroups(groupNumber);
        }

        public IEnumerable<Group> EnumerateSuccessGroups(string input)
        {
            return EnumerateSuccessGroups(input, RegexOptions.None);
        }

        public IEnumerable<Group> EnumerateSuccessGroups(string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateSuccessGroups();
        }

        public IEnumerable<Group> EnumerateSuccessGroups(string groupName, string input)
        {
            return EnumerateSuccessGroups(groupName, input, RegexOptions.None);
        }

        public IEnumerable<Group> EnumerateSuccessGroups(string groupName, string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateSuccessGroups(groupName);
        }

        public IEnumerable<Group> EnumerateSuccessGroups(int groupNumber, string input)
        {
            return EnumerateSuccessGroups(groupNumber, input, RegexOptions.None);
        }

        public IEnumerable<Group> EnumerateSuccessGroups(int groupNumber, string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateSuccessGroups(groupNumber);
        }

        public IEnumerable<Capture> EnumerateCaptures(string input)
        {
            return EnumerateCaptures(input, RegexOptions.None);
        }

        public IEnumerable<Capture> EnumerateCaptures(string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateCaptures();
        }

        public IEnumerable<Capture> EnumerateCaptures(string groupName, string input)
        {
            return EnumerateCaptures(groupName, input, RegexOptions.None);
        }

        public IEnumerable<Capture> EnumerateCaptures(string groupName, string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateCaptures(groupName);
        }

        public IEnumerable<Capture> EnumerateCaptures(int groupNumber, string input)
        {
            return EnumerateCaptures(groupNumber, input, RegexOptions.None);
        }

        public IEnumerable<Capture> EnumerateCaptures(int groupNumber, string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateCaptures(groupNumber);
        }

        public bool IsMatch(string input)
        {
            return Regex.IsMatch(input, Pattern);
        }

        public bool IsMatch(string input, RegexOptions options)
        {
            return Regex.IsMatch(input, Pattern, options);
        }

        public Match Match(string input)
        {
            return Regex.Match(input, Pattern);
        }

        public Match Match(string input, RegexOptions options)
        {
            return Regex.Match(input, Pattern, options);
        }

        public string Replace(string input)
        {
            return Replace(input, string.Empty);
        }

        public string Replace(string input, MatchEvaluator evaluator)
        {
            return Regex.Replace(input, Pattern, evaluator);
        }

        public string Replace(string input, MatchEvaluator evaluator, RegexOptions options)
        {
            return Regex.Replace(input, Pattern, evaluator, options);
        }

        public string Replace(string input, string replacement)
        {
            return Regex.Replace(input, Pattern, replacement);
        }

        public string Replace(string input, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, Pattern, replacement, options);
        }

        public string[] Split(string input)
        {
            return Regex.Split(input, Pattern);
        }

        public string[] Split(string input, RegexOptions options)
        {
            return Regex.Split(input, Pattern, options);
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
            return Expressions.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(Expression left, string right)
        {
            return Expressions.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(string left, Expression right)
        {
            return Expressions.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(Expression left, CharGroupItem right)
        {
            return Expressions.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(CharGroupItem left, Expression right)
        {
            return Expressions.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(Expression left, char right)
        {
            return Expressions.Or(left, right.ToString());
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiableExpression operator |(char left, Expression right)
        {
            return Expressions.Or(left.ToString(), right);
        }

        #endregion

        public static explicit operator Expression(string text)
        {
            return new TextExpression(text);
        }

        public static explicit operator Expression(char value)
        {
            return new CharExpression(value);
        }

        public string Pattern
        {
            get
            {
                if (_pattern == null)
                {
                    _pattern = ToString();
                }

                return _pattern;
            }
        }

        internal Expression Previous { get; set; }
    }
}