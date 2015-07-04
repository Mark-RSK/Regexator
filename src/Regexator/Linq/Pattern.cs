// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using Pihrtsoft.Text.RegularExpressions.Extensions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents an immutable regular expression pattern. This class is abstract.
    /// </summary>
    public abstract partial class Pattern
    {
        private string _value;
        internal static readonly Pattern Empty = new LiteralPattern();

        protected Pattern()
        {
        }

        internal abstract void AppendTo(PatternBuilder builder);

        /// <summary>
        /// Creates and returns a new instance of the <see cref="Pattern"/> class with the specified content.
        /// </summary>
        /// <param name="content">The pattern content.</param>
        /// <returns></returns>
        public static Pattern Create(object content)
        {
            return new ContentPattern(content);
        }

        /// <summary>
        /// Appends specified pattern to the current instance if a condition is true.
        /// </summary>
        /// <param name="condition">The condition expression to evaluate.</param>
        /// <param name="content">The pattern to append.</param>
        /// <returns></returns>
        public Pattern ConcatIf(bool condition, object content)
        {
            return condition 
                ? Concat(content) 
                : this;
        }

        /// <summary>
        /// Appends specified pattern to the current instance.
        /// </summary>
        /// <param name="content">The pattern to append.</param>
        /// <returns></returns>
        public Pattern Concat(object content)
        {
            return ConcatInternal(new ContentPattern(content));
        }

        /// <summary>
        /// Appends specified pattern to the current instance.
        /// </summary>
        /// <param name="pattern">The pattern to append.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern Concat(Pattern pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            return ConcatInternal(new ContentPattern(pattern));
        }

#if DEBUG
        /// <summary>
        /// Appends specified literal text to the current instance.
        /// </summary>
        /// <param name="text">Literal text to append.</param>
        /// <returns></returns>
        public Pattern Concat(string text)
        {
            return Concat(text, false);
        }

        /// <summary>
        /// Append specified literal text to the current instance, ignoring or honoring its case.
        /// </summary>
        /// <param name="text">Literal text to append.</param>
        /// <param name="ignoreCase">true to ignore case during the matching; otherwise, false.</param>
        /// <returns></returns>
        public Pattern Concat(string text, bool ignoreCase)
        {
            return ConcatInternal(new LiteralPattern(text, ignoreCase));
        }
#else
        /// <summary>
        /// Appends specified literal text to the current instance.
        /// </summary>
        /// <param name="text">Literal text to append.</param>
        /// <returns></returns>
        public Pattern Concat(string text)
        {
            return ConcatInternal(new LiteralPattern(text));
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

        /// <summary>
        /// Concatenates the elements in a specified Object array.
        /// </summary>
        /// <param name="content">An object array that contains the elements to concatenate.</param>
        /// <returns></returns>
        public static Pattern Concat(params object[] content)
        {
            return Create((object)content);
        }

        /// <summary>
        /// Concatenates the elements of a <see cref="System.Collections.Generic.IEnumerable{T}"/> collection of type <see cref="System.Object"/>.
        /// </summary>
        /// <param name="content">A collection object that implements <see cref="System.Collections.Generic.IEnumerable{T}"/> and whose generic type argument is <see cref="System.Object"/>.</param>
        /// <returns></returns>
        public static Pattern Concat(IEnumerable<object> content)
        {
            return Create((object)content);
        }

        /// <summary>
        /// Concatenates the elements of an object array, using the specified separator between each element.
        /// </summary>
        /// <param name="separator">The pattern to use as a separator.</param>
        /// <param name="values">An object array that contains the patterns to concatenate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern Join(object separator, params object[] values)
        {
            return new JoinContainer(separator, (object)values);
        }

        /// <summary>
        /// Concatenates the elements of a <see cref="System.Collections.Generic.IEnumerable{T}"/> collection of type <see cref="System.Object"/>, using the specified separator between each element.
        /// </summary>
        /// <param name="separator">The pattern to use as a separator.</param>
        /// <param name="values">A collection object that implements <see cref="System.Collections.Generic.IEnumerable{T}"/> and whose generic type argument is <see cref="System.Object"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Compiles a new instance of the <see cref="System.Text.RegularExpressions.Regex"/> class for the current instance.
        /// </summary>
        /// <returns></returns>
        public Regex ToRegex()
        {
            return ToRegex(RegexOptions.None);
        }

        /// <summary>
        /// Compiles a new instance of the <see cref="System.Text.RegularExpressions.Regex"/> class for the current instance, with options that modify the pattern.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that modify the regular expression.</param>
        /// <returns></returns>
        public Regex ToRegex(RegexOptions options)
        {
            return new Regex(ToString(), options);
        }

        /// <summary>
        /// Constructs a pattern text that represents the current instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(PatternOptions.None);
        }

        /// <summary>
        /// Constructs a pattern text that represents the current instance. with options that modify the pattern.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that modify the pattern.</param>
        /// <returns></returns>
        public string ToString(PatternOptions options)
        {
            return ToString(new PatternSettings(options));
        }

        /// <summary>
        /// Constructs a pattern text that represents the current instance. with settings that modify the pattern.
        /// </summary>
        /// <param name="settings">A settings that modify the pattern.</param>
        /// <returns></returns>
        public string ToString(PatternSettings settings)
        {
            var builder = new PatternBuilder(settings);
            builder.Append(this);
            return builder.ToString();
        }

        internal static string GetPattern(object content)
        {
            return GetPattern(content, new PatternSettings());
        }

        internal static string GetPattern(object content, PatternSettings settings)
        {
            var builder = new PatternBuilder(settings);
            builder.Append(content);
            return builder.ToString();
        }

        /// <summary>
        /// Searches the specified input string for all matches.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MatchCollection Matches(string input)
        {
            return Regex.Matches(input, Value);
        }

        /// <summary>
        /// Searches the specified input string for all matches, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public MatchCollection Matches(string input, RegexOptions options)
        {
            return Regex.Matches(input, Value, options);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of matches.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Match> EnumerateMatches(string input)
        {
            return EnumerateMatches(input, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of matches, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Match> EnumerateMatches(string input, RegexOptions options)
        {
            Match match = Regex.Match(input, Value, options);
            while (match.Success)
            {
                yield return match;
                match = match.NextMatch();
            }
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateGroups(string input)
        {
            return EnumerateGroups(input, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateGroups(string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateGroups();
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups with a specified name.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateGroups(string input, string groupName)
        {
            return EnumerateGroups(input, groupName, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups with a specified name, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateGroups(string input, string groupName, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateGroups(groupName);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups with a specified number.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A valid number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IEnumerable<Group> EnumerateGroups(string input, int groupNumber)
        {
            return EnumerateGroups(input, groupNumber, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups with a specified number, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A valid number of the group.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IEnumerable<Group> EnumerateGroups(string input, int groupNumber, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateGroups(groupNumber);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups that contain at least one capture.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateSuccessGroups(string input)
        {
            return EnumerateSuccessGroups(input, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups that contain at least one capture, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateSuccessGroups(string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateSuccessGroups();
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups that have a specified name and contain at least one capture.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateSuccessGroups(string input, string groupName)
        {
            return EnumerateSuccessGroups(input, groupName, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups that have a specified name and contain at least one capture, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Group> EnumerateSuccessGroups(string input, string groupName, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateSuccessGroups(groupName);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups that have a specified number and contain at least one capture.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A valid number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IEnumerable<Group> EnumerateSuccessGroups(string input, int groupNumber)
        {
            return EnumerateSuccessGroups(input, groupNumber, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of groups that have a specified number and contain at least one capture, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A valid number of the group.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IEnumerable<Group> EnumerateSuccessGroups(string input, int groupNumber, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateSuccessGroups(groupNumber);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of captures.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Capture> EnumerateCaptures(string input)
        {
            return EnumerateCaptures(input, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of captures, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Capture> EnumerateCaptures(string input, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateCaptures();
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of captures from groups that have a specified name.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Capture> EnumerateCaptures(string input, string groupName)
        {
            return EnumerateCaptures(input, groupName, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of captures from groups that have a specified name, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Capture> EnumerateCaptures(string input, string groupName, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateCaptures(groupName);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of captures from groups that have a specified number.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A valid number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IEnumerable<Capture> EnumerateCaptures(string input, int groupNumber)
        {
            return EnumerateCaptures(input, groupNumber, RegexOptions.None);
        }

        /// <summary>
        /// Searches the specified input string and returns an enumerable collection of captures from groups that have a specified number, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A valid number of the group.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IEnumerable<Capture> EnumerateCaptures(string input, int groupNumber, RegexOptions options)
        {
            return EnumerateMatches(input, options).EnumerateCaptures(groupNumber);
        }

        /// <summary>
        /// Indicates whether the current instance finds a match in the specified input string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool IsMatch(string input)
        {
            return Regex.IsMatch(input, Value);
        }

        /// <summary>
        /// Indicates whether the current instance finds a match in the specified input string, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool IsMatch(string input, RegexOptions options)
        {
            return Regex.IsMatch(input, Value, options);
        }

        /// <summary>
        /// Searches a specified input string for the first occurrence of the current instance.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Match Match(string input)
        {
            return Regex.Match(input, Value);
        }

        /// <summary>
        /// Searches a specified input string for the first occurrence of the current instance, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Match Match(string input, RegexOptions options)
        {
            return Regex.Match(input, Value, options);
        }

        /// <summary>
        /// Within a specified input string, replaces strings that match the current instance with a an empty string. 
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Replace(string input)
        {
            return Replace(input, string.Empty);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match the current instance with a string returned by a <see cref="System.Text.RegularExpressions.MatchEvaluator"/> delegate. 
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="evaluator">A method that examines each match and returns a replacement string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Replace(string input, MatchEvaluator evaluator)
        {
            return Regex.Replace(input, Value, evaluator);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match the current instance with a string returned by a <see cref="System.Text.RegularExpressions.MatchEvaluator"/> delegate. Specified options modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="evaluator">A method that examines each match and returns a replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Replace(string input, MatchEvaluator evaluator, RegexOptions options)
        {
            return Regex.Replace(input, Value, evaluator, options);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match the current instance with a specified replacement string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns></returns>
        public string Replace(string input, string replacement)
        {
            return Regex.Replace(input, Value, replacement);
        }

        /// <summary>
        /// Within a specified input string, replaces all strings that match the current instance with a specified replacement string. Specified options modify the matching operation.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
        public string Replace(string input, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, Value, replacement, options);
        }

        /// <summary>
        /// Splits the specified input string at the positions defined by the current instance.
        /// </summary>
        /// <param name="input">The string to split.</param>
        /// <returns></returns>
        public string[] Split(string input)
        {
            return Regex.Split(input, Value);
        }

        /// <summary>
        /// Splits the specified input string at the positions defined by the current instance, using the specified matching options.
        /// </summary>
        /// <param name="input">The string to split.</param>
        /// <param name="options">A bitwise combination of the enumeration values that specify options for matching.</param>
        /// <returns></returns>
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
        public static Pattern operator +(Pattern left, char right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            return left.Concat(Patterns.Character(right));
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Pattern operator +(char left, Pattern right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Patterns.Character(left).Concat(right);
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
        public static QuantifiablePattern operator |(Pattern left, CharGrouping right)
        {
            return Patterns.Or(left, right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static QuantifiablePattern operator |(CharGrouping left, Pattern right)
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
            return new LiteralPattern(text);
        }

        public static explicit operator Pattern(char value)
        {
            return CharPattern.Create(value);
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