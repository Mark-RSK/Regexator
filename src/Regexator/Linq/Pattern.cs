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
    public partial class Pattern
    {
        private string _value;
        internal static readonly Pattern Empty = new Pattern();

        protected Pattern()
        {
        }

        public static Pattern Create(object content)
        {
            return new ContainerPattern(content);
        }

        public Pattern ConcatIf(bool condition, object content)
        {
            return condition ? Concat(content) : this;
        }

        public Pattern Concat(object content)
        {
            return ConcatInternal(new ContainerPattern(content));
        }

        public Pattern Concat(Pattern pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            return ConcatInternal(pattern.AsContainer());
        }

#if DEBUG
        public Pattern Concat(string text)
        {
            return Concat(text, false);
        }

        public Pattern Concat(string text, bool ignoreCase)
        {
            return ConcatInternal(new TextPattern(text, ignoreCase));
        }
#else
        public Pattern Concat(string text)
        {
            return ConcatInternal(new TextPattern(text));
        }
#endif

        internal TPattern ConcatInternal<TPattern>(TPattern pattern) where TPattern : Pattern
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            Pattern first = pattern;
            while (first.Previous != null)
            {
                first = first.Previous;
            }
            first.Previous = this;

            return pattern;
        }

        public static Pattern Concat(params object[] content)
        {
            return Create((object)content);
        }

        public static Pattern Concat(IEnumerable<object> content)
        {
            return Create((object)content);
        }

        public static Pattern Join(object separator, params object[] values)
        {
            return new JoinContainer(separator, (object)values);
        }

        public static Pattern Join(object separator, IEnumerable<object> values)
        {
            return new JoinContainer(separator, (object)values);
        }

        public static Pattern Surround(object surroundContent, object content)
        {
            return Surround(surroundContent, content, surroundContent);
        }

        internal static Pattern Surround(object contentBefore, object content, object contentAfter)
        {
            return new SurroundPattern(contentBefore, content, contentAfter);
        }

        internal static Pattern Surround(AsciiChar surroundChar, object value)
        {
            return Surround(surroundChar, value, surroundChar);
        }

        internal static Pattern Surround(AsciiChar charBefore, object value, AsciiChar charAfter)
        {
            return new AsciiCharSurroundPattern(charBefore, value, charAfter);
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

        internal Pattern AsContainer()
        {
            return new ContainerPattern(this);
        }

        public MatchCollection Matches(string input)
        {
            return Regex.Matches(input, Value);
        }

        public MatchCollection Matches(string input, RegexOptions options)
        {
            return Regex.Matches(input, Value, options);
        }

        public IEnumerable<Match> EnumerateMatches(string input)
        {
            return EnumerateMatches(input, RegexOptions.None);
        }

        public IEnumerable<Match> EnumerateMatches(string input, RegexOptions options)
        {
            Match match = Regex.Match(input, Value, options);
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
            return Regex.IsMatch(input, Value);
        }

        public bool IsMatch(string input, RegexOptions options)
        {
            return Regex.IsMatch(input, Value, options);
        }

        public Match Match(string input)
        {
            return Regex.Match(input, Value);
        }

        public Match Match(string input, RegexOptions options)
        {
            return Regex.Match(input, Value, options);
        }

        public string Replace(string input)
        {
            return Replace(input, string.Empty);
        }

        public string Replace(string input, MatchEvaluator evaluator)
        {
            return Regex.Replace(input, Value, evaluator);
        }

        public string Replace(string input, MatchEvaluator evaluator, RegexOptions options)
        {
            return Regex.Replace(input, Value, evaluator, options);
        }

        public string Replace(string input, string replacement)
        {
            return Regex.Replace(input, Value, replacement);
        }

        public string Replace(string input, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, Value, replacement, options);
        }

        public string[] Split(string input)
        {
            return Regex.Split(input, Value);
        }

        public string[] Split(string input, RegexOptions options)
        {
            return Regex.Split(input, Value, options);
        }

        #region + and | operators

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Pattern operator +(Pattern left, Pattern right)
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
        public static Pattern operator +(Pattern left, string right)
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
        public static Pattern operator +(string left, Pattern right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Pattern.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Pattern operator +(Pattern left, CharGroupItem right)
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
        public static Pattern operator +(CharGroupItem left, Pattern right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Pattern.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Pattern operator +(Pattern left, char right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            return left.Concat(Chars.Char(right));
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Pattern operator +(char left, Pattern right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Chars.Char(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(Pattern left, Pattern right)
        {
            return Patterns.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(Pattern left, string right)
        {
            return Patterns.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(string left, Pattern right)
        {
            return Patterns.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(Pattern left, CharGroupItem right)
        {
            return Patterns.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(CharGroupItem left, Pattern right)
        {
            return Patterns.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(Pattern left, char right)
        {
            return Patterns.Or(left, right.ToString());
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(char left, Pattern right)
        {
            return Patterns.Or(left.ToString(), right);
        }

        #endregion

        public static explicit operator Pattern(string text)
        {
            return new TextPattern(text);
        }

        public static explicit operator Pattern(char value)
        {
            return new CharPattern(value);
        }

        internal string Value
        {
            get
            {
                if (_value == null)
                {
                    _value = ToString();
                }

                return _value;
            }
        }

        internal Pattern Previous { get; set; }
    }
}