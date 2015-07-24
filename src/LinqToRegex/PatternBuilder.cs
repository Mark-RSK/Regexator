// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a class that converts an instance of the <see cref="Pattern"/> class to its text representation.
    /// </summary>
    public sealed class PatternBuilder
    {
        private StringBuilder _sb;
        private PatternSettings _settings;
        private Stack<Pattern> _patterns;
        private Stack<CharGrouping> _charGroupings;
        private RegexOptions _currentOptions;

        internal PatternBuilder()
            : this(new PatternSettings())
        {
        }

        internal PatternBuilder(PatternSettings settings)
            : this(settings, RegexOptions.None)
        {
        }

        internal PatternBuilder(PatternSettings settings, RegexOptions options)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            _settings = settings;
            _currentOptions = options;
            _sb = new StringBuilder();
        }

        /// <summary>
        /// Converts the value of this instance to a <see cref="String"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _sb.ToString();
        }

        /// <summary>
        /// Appends specified text to this instance.
        /// </summary>
        /// <param name="value">The text to append.</param>
        public void Append(string value)
        {
            Append(value, false);
        }

        /// <summary>
        /// Appends specified characters to this instance.
        /// </summary>
        /// <param name="characters">Unicode characters.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Append(char[] characters)
        {
            Append(characters, false);
        }

        internal void Append(char[] characters, bool inCharGroup)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            foreach (var value in characters)
            {
                Append(value, inCharGroup);
            }
        }

        internal void Append(string value, bool inCharGroup)
        {
            if (!string.IsNullOrEmpty(value))
            {
                CharEscapeMode mode = CharEscapeMode.None;

                for (int i = 0; i < value.Length; i++)
                {
                    mode = RegexUtility.GetEscapeModeInternal((int)value[i], inCharGroup);
                    if (mode != CharEscapeMode.None)
                    {
                        char ch = value[i];
                        int lastPos;
                        _sb.Append(value, 0, i);

                        do
                        {
                            Append(ch, mode);
                            i++;
                            lastPos = i;

                            while (i < value.Length)
                            {
                                ch = value[i];
                                mode = RegexUtility.GetEscapeModeInternal((int)ch, inCharGroup);

                                if (mode != CharEscapeMode.None)
                                {
                                    break;
                                }

                                i++;
                            }

                            _sb.Append(value, lastPos, i - lastPos);

                        } while (i < value.Length);

                        return;
                    }
                }

                _sb.Append(value);
            }
        }

        private void Append(char ch, CharEscapeMode mode)
        {
            switch (mode)
            {
                case CharEscapeMode.AsciiHexadecimal:
                    _sb.Append(Syntax.AsciiHexadecimalStart);
                    _sb.Append(((int)ch).ToString("X2", CultureInfo.InvariantCulture));
                    break;
                case CharEscapeMode.Backslash:
                    _sb.Append('\\');
                    _sb.Append(ch);
                    break;
                case CharEscapeMode.Bell:
                    _sb.Append(Syntax.Bell);
                    break;
                case CharEscapeMode.CarriageReturn:
                    _sb.Append(Syntax.CarriageReturn);
                    break;
                case CharEscapeMode.Escape:
                    _sb.Append(Syntax.Escape);
                    break;
                case CharEscapeMode.FormFeed:
                    _sb.Append(Syntax.FormFeed);
                    break;
                case CharEscapeMode.Linefeed:
                    _sb.Append(Syntax.Linefeed);
                    break;
                case CharEscapeMode.VerticalTab:
                    _sb.Append(Syntax.VerticalTab);
                    break;
                case CharEscapeMode.Tab:
                    _sb.Append(Syntax.Tab);
                    break;
            }
        }

        /// <summary>
        /// Appends specified character to this instance.
        /// </summary>
        /// <param name="value">The character to append.</param>
        public void Append(char value)
        {
            Append(value, false);
        }

        internal void Append(char value, bool inCharGroup)
        {
            AppendInternal((int)value, inCharGroup);
        }

        /// <summary>
        /// Appends specified character to this instance.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies an ASCII character to append.</param>
        public void Append(AsciiChar value)
        {
            Append(value, false);
        }

        internal void Append(AsciiChar value, bool inCharGroup)
        {
            AppendInternal((int)value, inCharGroup);
        }

        /// <summary>
        /// Appends specified character to this instance.
        /// </summary>
        /// <param name="value">A code of the character to append.</param>
        public void Append(int value)
        {
            Append(value, false);
        }

        internal void Append(int value, bool inCharGroup)
        {
            if (value < 0 || value > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("value");
            }

            AppendInternal(value, inCharGroup);
        }

        internal void AppendInternal(int value, bool inCharGroup)
        {
            switch (RegexUtility.GetEscapeModeInternal(value, inCharGroup))
            {
                case CharEscapeMode.None:
                    _sb.Append((char)value);
                    break;
                case CharEscapeMode.AsciiHexadecimal:
                    AppendAsciiHexadecimal(value);
                    break;
                case CharEscapeMode.Backslash:
                    AppendBackslash();
                    _sb.Append((char)value);
                    break;
                case CharEscapeMode.Bell:
                    AppendBell();
                    break;
                case CharEscapeMode.CarriageReturn:
                    AppendCarriageReturn();
                    break;
                case CharEscapeMode.Escape:
                    AppendEscape();
                    break;
                case CharEscapeMode.FormFeed:
                    AppendFormFeed();
                    break;
                case CharEscapeMode.Linefeed:
                    AppendLinefeed();
                    break;
                case CharEscapeMode.VerticalTab:
                    AppendVerticalTab();
                    break;
                case CharEscapeMode.Tab:
                    AppendTab();
                    break;
            }
        }

        internal void AppendCharRange(char firstChar, char lastChar)
        {
            Append(firstChar, true);
            AppendHyphen();
            Append(lastChar, true);
        }

        /// <summary>
        /// Appends the text representation of the pattern to this instance.
        /// </summary>
        /// <param name="pattern">The pattern to append.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Append(Pattern pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            if (pattern.Previous != null)
            {
                if (_patterns == null)
                {
                    _patterns = new Stack<Pattern>();
                }

                int cnt = _patterns.Count;
                Pattern item = pattern;

                do
                {
                    _patterns.Push(item);
                    item = item.Previous;
                } while (item != null);

                while (_patterns.Count > cnt)
                {
                    _patterns.Pop().AppendTo(this);
                }
            }
            else
            {
                pattern.AppendTo(this);
            }
        }

        /// <summary>
        /// Appends the text representation of the pattern to this instance.
        /// </summary>
        /// <param name="value">The pattern to append.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Append(CharGrouping value)
        {
            AppendCharGroup(value);
        }

        /// <summary>
        /// Appends the pattern representation of an object. The object must be convertible to <see cref="Pattern"/>, <see cref="CharGrouping"/>, <see cref="String"/>, <see cref="Char"/>, object array or <see cref="System.Collections.IEnumerable"/>.
        /// </summary>
        /// <param name="value">The object to append.</param>
        public void Append(object value)
        {
            Append(value, GroupMode.NoncapturingGroup);
        }

        internal void Append(object value, GroupMode mode)
        {
            if (value == null)
            {
                return;
            }

            Pattern pattern = value as Pattern;
            if (pattern != null)
            {
                Append(pattern);
                return;
            }

            string text = value as string;
            if (text != null)
            {
                Append(text);
                return;
            }

            if (value is char)
            {
                Append((char)value);
                return;
            }

            CharGrouping charGrouping = value as CharGrouping;
            if (charGrouping != null)
            {
                Append(charGrouping);
                return;
            }

            object[] values = value as object[];
            if (values != null)
            {
                if (values.Length > 0)
                {
                    if (mode == GroupMode.Group)
                    {
                        AppendGroupStart();
                    }
                    else if (mode == GroupMode.NoncapturingGroup)
                    {
                        AppendNoncapturingGroupStart();
                    }

                    Append(values[0]);

                    for (int i = 1; i < values.Length; i++)
                    {
                        AppendOr();
                        Append(values[i]);
                    }

                    if (mode != GroupMode.None)
                    {
                        AppendGroupEnd();
                    }
                }

                return;
            }

            IEnumerable items = value as IEnumerable;
            if (items != null)
            {
                IEnumerator en = items.GetEnumerator();

                if (en.MoveNext())
                {
                    if (mode == GroupMode.Group)
                    {
                        AppendGroupStart();
                    }
                    else if (mode == GroupMode.NoncapturingGroup)
                    {
                        AppendNoncapturingGroupStart();
                    }

                    Append(en.Current);

                    while (en.MoveNext())
                    {
                        AppendOr();
                        Append(en.Current);
                    }

                    if (mode != GroupMode.None)
                    {
                        AppendGroupEnd();
                    }
                }
            }
        }

        internal void AppendGroupStart()
        {
            _sb.Append("(?");
        }

        internal void AppendGroupContent(object content)
        {
            AppendGroupContent(content, RegexOptions.None, RegexOptions.None);
        }

        internal void AppendGroupContent(object content, RegexOptions applyOptions, RegexOptions disableOptions)
        {
            RegexOptions currentOptions = _currentOptions;

            _currentOptions &= applyOptions;
            _currentOptions &= ~disableOptions;

            Append(content, GroupMode.None);

            _currentOptions = currentOptions;
        }

        /// <summary>
        /// Appends an if construct.
        /// </summary>
        /// <param name="testContent">The pattern to assert.</param>
        /// <param name="trueContent">The pattern to match if the assertion succeeds.</param>
        /// <param name="falseContent">The pattern to match if the assertion fails.</param>
        public void AppendIfAssert(object testContent, object trueContent, object falseContent)
        {
            if (testContent == null)
            {
                throw new ArgumentNullException("testContent");
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            AppendGroupStart();

            if (Settings.HasOptions(PatternOptions.ConditionWithAssertion))
            {
                AppendAssertionStart();
            }
            else
            {
                AppendLeftParenthesis();
            }

            Append(testContent, GroupMode.None);
            AppendGroupEnd();

            RegexOptions currentOptions = _currentOptions;

            if (falseContent == null)
            {
                Append(trueContent, GroupMode.None);
            }
            else
            {
                Append(trueContent);
                AppendOr();
                Append(falseContent);
            }

            AppendGroupEnd();

            _currentOptions = currentOptions;
        }

        /// <summary>
        /// Appends an if construct.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="trueContent">The pattern to match if the named group is matched.</param>
        /// <param name="falseContent">The pattern to match if the named group is not matched.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AppendIfGroup(string groupName, object trueContent, object falseContent)
        {
            AppendIfGroupInternal(groupName, trueContent, falseContent, true);
        }

        internal void AppendIfGroupInternal(string groupName, object trueContent, object falseContent, bool checkGroupName)
        {
            if (checkGroupName)
            {
                RegexUtility.CheckGroupName(groupName);
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            AppendGroupStart();
            AppendIfGroupCondition(groupName);

            RegexOptions currentOptions = _currentOptions;

            if (falseContent == null)
            {
                Append(trueContent, GroupMode.None);
            }
            else
            {
                Append(trueContent);
                AppendOr();
                Append(falseContent);
            }

            AppendGroupEnd();

            _currentOptions = currentOptions;
        }

        /// <summary>
        /// Appends an if construct.
        /// </summary>
        /// <param name="groupNumber">A number of the group.</param>
        /// <param name="trueContent">The pattern to match if the named group is matched.</param>
        /// <param name="falseContent">The pattern to match if the named group is not matched.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendIfGroup(int groupNumber, object trueContent, object falseContent)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            AppendGroupStart();
            AppendIfGroupCondition(groupNumber);

            RegexOptions currentOptions = _currentOptions;

            if (falseContent == null)
            {
                Append(trueContent, GroupMode.None);
            }
            else
            {
                Append(trueContent);
                AppendOr();
                Append(falseContent);
            }

            AppendGroupEnd();

            _currentOptions = currentOptions;
        }

        internal void AppendIfGroupCondition(int groupNumber)
        {
            AppendIfGroupCondition(groupNumber.ToString(CultureInfo.InvariantCulture));
        }

        internal void AppendIfGroupCondition(string groupName)
        {
            AppendLeftParenthesis();
            _sb.Append(groupName);
            AppendGroupEnd();
        }

        /// <summary>
        /// Appends a positive lookahead assertion with a specified content.
        /// </summary>
        /// <param name="content">An assertion content.</param>
        public void AppendAssertion(object content)
        {
            AppendAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        /// <summary>
        /// Appends a negative lookahead assertion with a specified content.
        /// </summary>
        /// <param name="content">An assertion content.</param>
        public void AppendNegativeAssertion(object content)
        {
            AppendNegativeAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        /// <summary>
        /// Appends a positive lookbehind assertion with a specified content.
        /// </summary>
        /// <param name="content">An assertion content.</param>
        public void AppendBackAssertion(object content)
        {
            AppendBackAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        /// <summary>
        /// Appends a negative lookbehind assertion with a specified content.
        /// </summary>
        /// <param name="content">An assertion content.</param>
        public void AppendNegativeBackAssertion(object content)
        {
            AppendNegativeBackAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        /// <summary>
        /// Appends a pattern that matches the beginning of the string.
        /// </summary>
        public void AppendBeginningOfInput()
        {
            _sb.Append(Syntax.BeginningOfInput);
        }

        /// <summary>
        /// Appends a pattern that matches the beginning of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied).
        /// </summary>
        public void AppendBeginningOfInputOrLine()
        {
            _sb.Append(Syntax.BeginningOfInputOrLine);
        }

        /// <summary>
        /// Appends a pattern that matches the end of the string.
        /// </summary>
        public void AppendEndOfInput()
        {
            _sb.Append(Syntax.EndOfInput);
        }

        /// <summary>
        /// Appends a pattern that is matched at the end of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        public void AppendEndOfInputOrLine()
        {
            _sb.Append(Syntax.EndOfInputOrLine);
        }

        /// <summary>
        /// Appends a pattern that is matched at the end of the string or before linefeed at the end of the string.
        /// </summary>
        public void AppendEndOfInputOrBeforeEndingLinefeed()
        {
            _sb.Append(Syntax.EndOfInputOrBeforeEndingLinefeed);
        }

        /// <summary>
        /// Appends a pattern that is matched on a boundary between a word character (\w) and a non-word character (\W). The pattern may be also matched on a word boundary at the beginning or end of the string.
        /// </summary>
        public void AppendWordBoundary()
        {
            _sb.Append(Syntax.WordBoundary);
        }

        /// <summary>
        /// Appends a pattern that is not matched on a boundary between a word character (\w) and a non-word character (\W).
        /// </summary>
        public void AppendNegativeWordBoundary()
        {
            _sb.Append(Syntax.NegativeWordBoundary);
        }

        /// <summary>
        /// Appends a pattern that is matched at the position where the previous match ended.
        /// </summary>
        public void AppendPreviousMatchEnd()
        {
            _sb.Append(Syntax.PreviousMatchEnd);
        }

        internal void AppendAssertionStart()
        {
            _sb.Append(Syntax.AssertionStart);
        }

        internal void AppendNegativeAssertionStart()
        {
            _sb.Append(Syntax.NegativeAssertionStart);
        }

        internal void AppendBackAssertionStart()
        {
            _sb.Append(Syntax.BackAssertionStart);
        }

        internal void AppendNegativeBackAssertionStart()
        {
            _sb.Append(Syntax.NegativeBackAssertionStart);
        }

        internal void AppendOr()
        {
            _sb.Append(Syntax.Or);
        }

        internal void AppendAny(object content, GroupMode mode)
        {
            if (mode == GroupMode.Group)
            {
                AppendLeftParenthesis();
            }
            else if (mode == GroupMode.NoncapturingGroup)
            {
                AppendNoncapturingGroupStart();
            }

            AppendGroupContent(content);

            if (mode != GroupMode.None)
            {
                AppendGroupEnd();
            }
        }

        /// <summary>
        /// Appends a numbered group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendNumberedGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            AppendLeftParenthesis();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        /// <summary>
        /// Appends a named group with a specified name and content.
        /// </summary>
        /// <param name="name">A name of the group.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AppendNamedGroup(string name, object content)
        {
            RegexUtility.CheckGroupName(name, "name");

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            AppendNamedGroupInternal(name, content);
        }

        internal void AppendNamedGroupInternal(string groupName, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            AppendNamedGroupStart(groupName);
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        internal void AppendNamedGroupStart(string groupName)
        {
            AppendGroupStart();
            AppendStartIdentifierBoundary();
            _sb.Append(groupName);
            AppendEndIdentifierBoundary();
        }

        /// <summary>
        /// Appends a noncapturing group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendNoncapturingGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            AppendNoncapturingGroupStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        internal void AppendNoncapturingGroupStart()
        {
            _sb.Append(Syntax.NoncapturingGroupStart);
        }

        /// <summary>
        /// Appends a nonbacktracking group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendNonbacktrackingGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            AppendNonbacktrackingGroupStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        internal void AppendNonbacktrackingGroupStart()
        {
            _sb.Append(Syntax.NonbacktrackingGroupStart);
        }

        internal void AppendBalancingGroup(string name1, string name2, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            AppendBalancingGroupStart(name1, name2);
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        internal void AppendBalancingGroupStart(string name1, string name2)
        {
            AppendGroupStart();
            AppendStartIdentifierBoundary();
            _sb.Append(name1);
            AppendHyphen();
            _sb.Append(name2);
            AppendEndIdentifierBoundary();
        }

        internal void AppendGroupEnd()
        {
            _sb.Append(Syntax.GroupEnd);
        }

        /// <summary>
        /// Appends a pattern that matches any character except linefeed (or any character if the <see cref="RegexOptions.Singleline"/> option is applied).
        /// </summary>
        public void AppendAnyChar()
        {
            _sb.Append(Syntax.AnyChar);
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified character class.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies character class.</param>
        internal void AppendCharClass(CharClass value)
        {
            switch (value)
            {
                case CharClass.Digit:
                    AppendDigit();
                    break;
                case CharClass.WordChar:
                    AppendWordChar();
                    break;
                case CharClass.WhiteSpace:
                    AppendWhiteSpace();
                    break;
                case CharClass.NotDigit:
                    AppendNotDigit();
                    break;
                case CharClass.NotWordChar:
                    AppendNotWordChar();
                    break;
                case CharClass.NotWhiteSpace:
                    AppendNotWhiteSpace();
                    break;
            }
        }

        /// <summary>
        /// Appends a pattern that matches a digit character.
        /// </summary>
        public void AppendDigit()
        {
            _sb.Append(Syntax.Digit);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character.
        /// </summary>
        public void AppendNotDigit()
        {
            _sb.Append(Syntax.NotDigit);
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character.
        /// </summary>
        public void AppendWhiteSpace()
        {
            _sb.Append(Syntax.WhiteSpace);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character.
        /// </summary>
        public void AppendNotWhiteSpace()
        {
            _sb.Append(Syntax.NotWhiteSpace);
        }

        /// <summary>
        /// Appends a pattern that matches a word character.
        /// </summary>
        public void AppendWordChar()
        {
            _sb.Append(Syntax.WordChar);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character.
        /// </summary>
        public void AppendNotWordChar()
        {
            _sb.Append(Syntax.NotWordChar);
        }

        internal void AppendCharGroupStart()
        {
            AppendCharGroupStart(false);
        }

        internal void AppendCharGroupStart(bool negative)
        {
            _sb.Append(Syntax.CharGroupStart);

            if (negative)
            {
                _sb.Append(Syntax.CharGroupNegation);
            }
        }

        internal void AppendCharGroupEnd()
        {
            _sb.Append(Syntax.CharGroupEnd);
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        public void AppendCharGroup(NamedBlock block)
        {
            AppendCharGroup(block, false);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        public void AppendNegativeCharGroup(NamedBlock block)
        {
            AppendCharGroup(block, true);
        }

        internal void AppendCharGroup(NamedBlock block, bool negative)
        {
            AppendCharGroupStart();
            AppendNamedBlock(block, negative);
            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        public void AppendCharGroup(GeneralCategory category)
        {
            AppendCharGroup(category, false);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        public void AppendNegativeCharGroup(GeneralCategory category)
        {
            AppendCharGroup(category, true);
        }

        internal void AppendCharGroup(GeneralCategory category, bool negative)
        {
            AppendCharGroupStart();
            AppendGeneralCategory(category, negative);
            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified character class.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies character class.</param>
        internal void AppendCharGroup(CharClass value)
        {
            AppendCharGroupStart();
            AppendCharClass(value);
            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a pattern that matches a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        public void AppendCharGroup(AsciiChar value)
        {
            AppendCharGroup(value, false);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a specified character..
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        public void AppendNegativeCharGroup(AsciiChar value)
        {
            AppendCharGroup(value, true);
        }

        internal void AppendCharGroup(AsciiChar value, bool negative)
        {
            AppendCharGroupStart(negative);
            Append(value, true);
            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a character group containing specified characters.
        /// </summary>
        /// <param name="characters">A set of characters any one of which has to be matched.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AppendCharGroup(string characters)
        {
            AppendCharGroup(characters, false);
        }

        /// <summary>
        /// Appends a negative character group containing specified characters.
        /// </summary>
        /// <param name="characters">Unicode characters.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AppendNegativeCharGroup(string characters)
        {
            AppendCharGroup(characters, true);
        }

        internal void AppendCharGroup(string characters, bool negative)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            if (characters.Length == 0)
            {
                throw new ArgumentException(ExceptionHelper.CharGroupCannotBeEmpty, "characters");
            }

            AppendCharGroupStart(negative);
            Append(characters, true);
            AppendCharGroupEnd();
        }

        internal void AppendCharGroup(char[] characters, bool negative)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            if (characters.Length == 0)
            {
                throw new ArgumentException(ExceptionHelper.CharGroupCannotBeEmpty, "characters");
            }

            AppendCharGroupStart(negative);
            Append(characters, true);
            AppendCharGroupEnd();
        }

        internal void AppendCharGroup(char value, bool negative)
        {
            AppendCharGroupStart(negative);
            Append(value, true);
            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a pattern that matches a character in the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendCharGroup(char first, char last)
        {
            AppendCharGroup(first, last, false);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not in the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendNegativeCharGroup(char first, char last)
        {
            AppendCharGroup(first, last, true);
        }

        internal void AppendCharGroup(char first, char last, bool negative)
        {
            AppendCharGroupStart(negative);
            AppendCharRange(first, last);
            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a character group containing specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendCharGroup(CharGrouping value)
        {
            AppendCharGroup(value, false);
        }

        /// <summary>
        /// Appends a negative character group containing specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendNegativeCharGroup(CharGrouping value)
        {
            AppendCharGroup(value, true);
        }

        internal void AppendCharGroup(CharGrouping value, bool negative)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            AppendCharGroupStart(negative);
            value.AppendContentTo(this);
            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified base group except characters from a specified excluded group.
        /// </summary>
        /// <param name="baseGroup">A base group.</param>
        /// <param name="excludedGroup">An excluded group.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            if (baseGroup == null)
            {
                throw new ArgumentNullException("baseGroup");
            }

            if (excludedGroup == null)
            {
                throw new ArgumentNullException("excludedGroup");
            }

            AppendCharGroupStart();

            baseGroup.AppendBaseGroupTo(this);

            AppendHyphen();

            excludedGroup.AppendExcludedGroupTo(this);

            AppendCharGroupEnd();
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        public void AppendGeneralCategory(GeneralCategory category)
        {
            AppendGeneralCategory(category, false);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        public void AppendNotGeneralCategory(GeneralCategory category)
        {
            AppendGeneralCategory(category, true);
        }

        internal void AppendGeneralCategory(GeneralCategory category, bool negative)
        {
            AppendUnicodeStart(negative);
            _sb.Append(Syntax.GetCategoryDesignation(category));
            _sb.Append(Syntax.UnicodeEnd);
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public void AppendNamedBlock(NamedBlock block)
        {
            AppendNamedBlock(block, false);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public void AppendNotNamedBlock(NamedBlock block)
        {
            AppendNamedBlock(block, true);
        }

        internal void AppendNamedBlock(NamedBlock block, bool negative)
        {
            AppendUnicodeStart(negative);
            _sb.Append(Syntax.GetBlockDesignation(block));
            _sb.Append(Syntax.UnicodeEnd);
        }

        private void AppendUnicodeStart(bool negative)
        {
            if (negative)
            {
                _sb.Append(Syntax.NotUnicodeStart);
            }
            else
            {
                _sb.Append(Syntax.UnicodeStart);
            }
        }

        /// <summary>
        /// Appends a quantifier that matches previous element zero or one time.
        /// </summary>
        public void AppendMaybe()
        {
            AppendMaybe(false);
        }

        /// <summary>
        /// Appends a quantifier that matches previous element zero or one time.
        /// </summary>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        public void AppendMaybe(bool lazy)
        {
            _sb.Append(Syntax.Maybe);

            if (lazy)
            {
                AppendLazy();
            }
        }

        /// <summary>
        /// Appends a quantifier that matches previous element zero or more times.
        /// </summary>
        public void AppendMaybeMany()
        {
            AppendMaybeMany(false);
        }

        /// <summary>
        /// Appends a quantifier that matches previous element zero or more times.
        /// </summary>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        public void AppendMaybeMany(bool lazy)
        {
            _sb.Append(Syntax.MaybeMany);

            if (lazy)
            {
                AppendLazy();
            }
        }

        /// <summary>
        /// Appends a quantifier that matches previous element one or more times.
        /// </summary>
        public void AppendOneMany()
        {
            AppendOneMany(false);
        }

        /// <summary>
        /// Appends a quantifier that matches previous element one or more times.
        /// </summary>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        public void AppendOneMany(bool lazy)
        {
            _sb.Append(Syntax.OneMany);

            if (lazy)
            {
                AppendLazy();
            }
        }

        /// <summary>
        /// Appends a quantifier that matches previous element specific number of times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern must be matched.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendCount(int exactCount)
        {
            AppendCount(exactCount, false);
        }

        /// <summary>
        /// Appends a quantifier that matches previous element specific number of times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern must be matched.</param>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendCount(int exactCount, bool lazy)
        {
            if (exactCount < 0)
            {
                throw new ArgumentOutOfRangeException("exactCount");
            }

            AppendCountInternal(exactCount);

            if (lazy)
            {
                AppendLazy();
            }
        }

        internal void AppendCountInternal(int exactCount)
        {
            AppendLeftCurlyBracket();
            _sb.Append(exactCount);
            AppendRightCurlyBracket();
        }

        /// <summary>
        /// Appends a quantifier that matches previous element from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendCount(int minCount, int maxCount)
        {
            AppendCount(minCount, maxCount, false);
        }

        /// <summary>
        /// Appends a quantifier that matches previous element from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendCount(int minCount, int maxCount, bool lazy)
        {
            if (minCount < 0 || maxCount < minCount)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            AppendCountInternal(minCount, maxCount);

            if (lazy)
            {
                AppendLazy();
            }
        }

        internal void AppendCountInternal(int minCount, int maxCount)
        {
            AppendLeftCurlyBracket();
            _sb.Append(minCount);
            AppendComma();
            _sb.Append(maxCount);
            AppendRightCurlyBracket();
        }

        /// <summary>
        /// Appends a quantifier that matches previous element at least specified number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendCountFrom(int minCount)
        {
            AppendCountFrom(minCount, false);
        }

        /// <summary>
        /// Appends a quantifier that matches previous element at least specified number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendCountFrom(int minCount, bool lazy)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            AppendCountFromInternal(minCount);

            if (lazy)
            {
                AppendLazy();
            }
        }

        internal void AppendCountFromInternal(int minCount)
        {
            AppendLeftCurlyBracket();
            _sb.Append(minCount);
            AppendComma();
            AppendRightCurlyBracket();
        }

        /// <summary>
        /// Appends a quantifier that matches previous element at most specified number of times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendMaybeCount(int maxCount)
        {
            AppendMaybeCount(maxCount, false);
        }

        /// <summary>
        /// Appends a quantifier that matches previous element at most specified number of times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AppendMaybeCount(int maxCount, bool lazy)
        {
            if (maxCount < 0)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }

            AppendMaybeCountInternal(maxCount);

            if (lazy)
            {
                AppendLazy();
            }
        }

        internal void AppendMaybeCountInternal(int maxCount)
        {
            AppendLeftCurlyBracket();
            _sb.Append(0);
            AppendComma();
            _sb.Append(maxCount);
            AppendRightCurlyBracket();
        }

        internal void AppendLazy()
        {
            _sb.Append(Syntax.Lazy);
        }

        internal void AppendGroupReferenceInternal(int groupNumber)
        {
            AppendBackslash();
            _sb.Append(groupNumber);

            if (Settings.HasOptions(PatternOptions.SeparateGroupNumberReference))
            {
                AppendNoncapturingGroupStart();
                AppendGroupEnd();
            }
        }

        internal void AppendGroupReferenceInternal(string groupName)
        {
            _sb.Append(@"\k");
            AppendStartIdentifierBoundary();
            _sb.Append(groupName);
            AppendEndIdentifierBoundary();
        }

        /// <summary>
        /// Appends a pattern that applies specified options.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AppendOptions(RegexOptions applyOptions)
        {
            AppendOptions(applyOptions, RegexOptions.None);
        }

        /// <summary>
        /// Appends a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AppendOptions(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            if (applyOptions != RegexOptions.None || disableOptions != RegexOptions.None)
            {
                if (!RegexUtility.IsValidInlineOptions(applyOptions))
                {
                    throw new ArgumentException(ExceptionHelper.RegexOptionsNotConvertibleToInlineChars, "applyOptions");
                }

                if (!RegexUtility.IsValidInlineOptions(disableOptions))
                {
                    throw new ArgumentException(ExceptionHelper.RegexOptionsNotConvertibleToInlineChars, "disableOptions");
                }

                AppendGroupStart();
                AppendOptionsChars(applyOptions, disableOptions);
                AppendGroupEnd();

                _currentOptions &= applyOptions;
                _currentOptions &= ~disableOptions;
            }
        }

        /// <summary>
        /// Appends a pattern that applies specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="content">The pattern to match.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AppendOptions(RegexOptions applyOptions, object content)
        {
            AppendOptions(applyOptions, RegexOptions.None, content);
        }

        /// <summary>
        /// Appends a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">The pattern to match.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal void AppendOptions(RegexOptions applyOptions, RegexOptions disableOptions, object content)
        {
            if (!RegexUtility.IsValidInlineOptions(applyOptions))
            {
                throw new ArgumentException(ExceptionHelper.RegexOptionsNotConvertibleToInlineChars, "applyOptions");
            }

            if (!RegexUtility.IsValidInlineOptions(disableOptions))
            {
                throw new ArgumentException(ExceptionHelper.RegexOptionsNotConvertibleToInlineChars, "disableOptions");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (applyOptions != RegexOptions.None || disableOptions != RegexOptions.None)
            {
                AppendGroupStart();
                AppendOptionsChars(applyOptions, disableOptions);
                AppendColon();
            }
            else
            {
                AppendNoncapturingGroupStart();
            }

            AppendGroupContent(content, applyOptions, disableOptions);
            AppendGroupEnd();
        }

        private void AppendOptionsChars(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            if (applyOptions != RegexOptions.None)
            {
                if (disableOptions != RegexOptions.None)
                {
                    AppendOptionsChars(applyOptions);
                    AppendHyphen();
                    AppendOptionsChars(disableOptions);
                }
                else
                {
                    AppendOptionsChars(applyOptions);
                }
            }
            else if (disableOptions != RegexOptions.None)
            {
                AppendHyphen();
                AppendOptionsChars(disableOptions);
            }
        }

        private void AppendOptionsChars(RegexOptions options)
        {
            if ((options & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase)
            {
                _sb.Append(Syntax.IgnoreCaseChar);
            }

            if ((options & RegexOptions.Multiline) == RegexOptions.Multiline)
            {
                _sb.Append(Syntax.MultilineChar);
            }

            if ((options & RegexOptions.ExplicitCapture) == RegexOptions.ExplicitCapture)
            {
                _sb.Append(Syntax.ExplicitCaptureChar);
            }

            if ((options & RegexOptions.Singleline) == RegexOptions.Singleline)
            {
                _sb.Append(Syntax.SinglelineChar);
            }

            if ((options & RegexOptions.IgnorePatternWhitespace) == RegexOptions.IgnorePatternWhitespace)
            {
                _sb.Append(Syntax.IgnorePatternWhiteSpaceChar);
            }
        }

        /// <summary>
        /// Appends an inline comment.
        /// </summary>
        /// <param name="value">A comment text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AppendInlineComment(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.IndexOf(')') != -1)
            {
                throw new ArgumentException(ExceptionHelper.CommentCannotContainsRightParenthesis, "value");
            }

            AppendInlineCommentInternal(value);
        }

        internal void AppendInlineCommentInternal(string comment)
        {
            _sb.Append(Syntax.InlineCommentStart);
            _sb.Append(comment);
            AppendGroupEnd();
        }

        internal void AppendStartIdentifierBoundary()
        {
            _sb.Append(Settings.IdentifierBoundary == IdentifierBoundary.Apostrophe
                ? '\''
                : '<');
        }

        internal void AppendEndIdentifierBoundary()
        {
            _sb.Append(Settings.IdentifierBoundary == IdentifierBoundary.Apostrophe
                ? '\''
                : '>');
        }

        internal void AppendLeftParenthesis()
        {
            _sb.Append('(');
        }

        internal void AppendLeftCurlyBracket()
        {
            _sb.Append('{');
        }

        internal void AppendRightCurlyBracket()
        {
            _sb.Append('}');
        }

        internal void AppendComma()
        {
            _sb.Append(',');
        }

        internal void AppendColon()
        {
            _sb.Append(':');
        }

        internal void AppendHyphen()
        {
            _sb.Append('-');
        }

        internal void AppendBackslash()
        {
            _sb.Append('\\');
        }

        internal void AppendCharGroupNegation()
        {
            _sb.Append('^');
        }

        internal void AppendAsciiHexadecimal(int charCode)
        {
            if (charCode < 0 || charCode > 0xFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            _sb.Append(Syntax.AsciiHexadecimalStart);
            _sb.Append(charCode.ToString("X2", CultureInfo.InvariantCulture));
        }

        private void AppendBell()
        {
            _sb.Append(Syntax.Bell);
        }

        private void AppendCarriageReturn()
        {
            _sb.Append(Syntax.CarriageReturn);
        }

        private void AppendEscape()
        {
            _sb.Append(Syntax.Escape);
        }

        private void AppendFormFeed()
        {
            _sb.Append(Syntax.FormFeed);
        }

        private void AppendLinefeed()
        {
            _sb.Append(Syntax.Linefeed);
        }

        private void AppendVerticalTab()
        {
            _sb.Append(Syntax.VerticalTab);
        }

        private void AppendTab()
        {
            _sb.Append(Syntax.Tab);
        }

        /// <summary>
        /// Gets the <see cref="PatternSettings"/> object that modifies the pattern.
        /// </summary>
        public PatternSettings Settings
        {
            get { return _settings; }
        }

        internal Stack<CharGrouping> CharGroupings
        {
            get
            {
                if (_charGroupings == null)
                {
                    _charGroupings = new Stack<CharGrouping>();
                }

                return _charGroupings;
            }
        }
    }
}