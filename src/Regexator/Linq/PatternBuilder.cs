// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

//TODO add xml comments

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class PatternBuilder
    {
        private StringBuilder _sb;
        private PatternSettings _settings;
        private Stack<Pattern> _patterns;
        private Stack<CharGrouping> _charGroupings;
        private RegexOptions _currentOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternBuilder"/> class.
        /// </summary>
        internal PatternBuilder()
            : this(new PatternSettings())
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PatternBuilder"/> class with the specified settings.
        /// </summary>
        /// <param name="settings">A settings that controls pattern formatting.</param>
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
            _sb = new StringBuilder();

            if (options != RegexOptions.None)
            {
                _currentOptions = options;
            }
        }

        public override string ToString()
        {
            return _sb.ToString();
        }

        /// <summary>
        /// Appends a string literal to this instance.
        /// </summary>
        /// <param name="value">The string literal to append.</param>
        public void Append(string value)
        {
            Append(value, false);
        }

        internal void Append(string value, bool inCharGroup)
        {
            if (!string.IsNullOrEmpty(value))
            {
                CharEscapeMode mode;

                for (int i = 0; i < value.Length; i++)
                {
                    mode = RegexUtilities.GetEscapeMode((int)value[i], inCharGroup);
                    if (mode != CharEscapeMode.None)
                    {
                        char ch = value[i];
                        int lastPos;
                        _sb.Append(value, 0, i);

                        do
                        {
                            RegexUtilities.AppendEscape(ch, mode, _sb);
                            i++;
                            lastPos = i;

                            while (i < value.Length)
                            {
                                ch = value[i];
                                mode = RegexUtilities.GetEscapeMode((int)ch, inCharGroup);

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

        internal void AppendInternal(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _sb.Append(value);
            }
        }

        /// <summary>
        /// Appends a character literal to this instance.
        /// </summary>
        /// <param name="value">The character literal to append.</param>
        public void Append(char value)
        {
            Append(value, false);
        }

        internal void Append(char value, bool inCharGroup)
        {
            AppendInternal((int)value, inCharGroup);
        }

        /// <summary>
        /// Appends a character literal to this instance.
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
        /// Appends a character literal to this instance.
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

        internal void AppendInternal(int value)
        {
            AppendInternal(value, false);
        }

        internal void AppendInternal(int value, bool inCharGroup)
        {
            switch (RegexUtilities.GetEscapeMode(value, inCharGroup))
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

        internal void AppendCharRange(int firstCharCode, int lastCharCode)
        {
            Append(firstCharCode, true);
            AppendHyphen();
            Append(lastCharCode, true);
        }

        /// <summary>
        /// Appends the text representation of the pattern to this instance.
        /// </summary>
        /// <param name="pattern">The pattern to append.</param>
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
        /// <param name="pattern">The pattern to append.</param>
        public void Append(CharGrouping value)
        {
            AppendCharGroup(value);
        }

        /// <summary>
        /// Tries to append the text representation of an object this instance.
        /// The object must be convertible to <see cref="Pattern"/>, <see cref="CharGrouping"/> or a <see cref="System.String"/>.
        /// For a recursive call, the object must be convertible to an array of object or <see cref="System.Collections.IEnumerable"/>.
        /// </summary>
        /// <param name="value">The object to append.</param>
        public void Append(object value)
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

            CharGrouping charGrouping = value as CharGrouping;
            if (charGrouping != null)
            {
                Append(charGrouping);
                return;
            }

            object[] values = value as object[];
            if (values != null)
            {
                foreach (var item in values)
                {
                    Append(item);
                }

                return;
            }

            IEnumerable items = value as IEnumerable;
            if (items != null)
            {
                foreach (var item in items)
                {
                    Append(item);
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

            Pattern pattern = content as Pattern;
            if (pattern != null)
            {
                Append(pattern);
            }
            else
            {
                string text = content as string;
                if (text != null)
                {
                    Append(text);
                }
                else
                {
                    CharGrouping charGrouping = content as CharGrouping;
                    if (charGrouping != null)
                    {
                        Append(charGrouping);
                    }
                    else
                    {
                        object[] values = content as object[];
                        if (values != null)
                        {
                            if (values.Length > 0)
                            {
                                Append(values[0]);

                                for (int i = 1; i < values.Length; i++)
                                {
                                    AppendOr();
                                    Append(values[i]);
                                }
                            }
                        }
                        else
                        {
                            IEnumerable items = content as IEnumerable;
                            if (items != null)
                            {
                                IEnumerator en = items.GetEnumerator();

                                if (en.MoveNext())
                                {
                                    Append(en.Current);

                                    while (en.MoveNext())
                                    {
                                        AppendOr();
                                        Append(en.Current);
                                    }
                                }
                            }
                            else
                            {
                                Append(content);
                            }
                        }
                    }
                }
            }

            _currentOptions = currentOptions;
        }

        /// <summary>
        /// Appends an if construct to this instance.
        /// </summary>
        /// <param name="testContent"></param>
        /// <param name="trueContent"></param>
        /// <param name="falseContent"></param>
        public void AppendIf(object testContent, object trueContent, object falseContent)
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
                AppendStartParenthesis();
            }

            Append(testContent);
            AppendGroupEnd();

            RegexOptions currentOptions = _currentOptions;

            Append(trueContent);

            if (falseContent != null)
            {
                AppendOr();
                Append(falseContent);
            }

            AppendGroupEnd();

            _currentOptions = currentOptions;
        }

        public void AppendIfGroup(string groupName, object trueContent, object falseContent)
        {
            AppendIfGroupInternal(groupName, trueContent, falseContent, true);
        }

        internal void AppendIfGroupInternal(string groupName, object trueContent, object falseContent, bool checkGroupName)
        {
            if (checkGroupName)
            {
                RegexUtilities.CheckGroupName(groupName);
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            AppendGroupStart();
            AppendIfGroupCondition(groupName);

            RegexOptions currentOptions = _currentOptions;

            Append(trueContent);

            if (falseContent != null)
            {
                AppendOr();
                Append(falseContent);
            }

            AppendGroupEnd();

            _currentOptions = currentOptions;
        }

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

            Append(trueContent);

            if (falseContent != null)
            {
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
            AppendStartParenthesis();
            _sb.Append(groupName);
            AppendGroupEnd();
        }

        public void AppendAssertion(object content)
        {
            AppendAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        public void AppendNegativeAssertion(object content)
        {
            AppendNegativeAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        public void AppendBackAssertion(object content)
        {
            AppendBackAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        public void AppendNegativeBackAssertion(object content)
        {
            AppendNegativeBackAssertionStart();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

        public void AppendStartOfInput()
        {
            _sb.Append(Syntax.StartOfInput);
        }

        public void AppendStartOfLine()
        {
            _sb.Append(Syntax.StartOfLine);
        }

        public void AppendEndOfInput()
        {
            _sb.Append(Syntax.EndOfInput);
        }

        public void AppendEndOfLine()
        {
            _sb.Append(Syntax.EndOfLine);
        }

        public void AppendEndOrBeforeEndingNewLine()
        {
            _sb.Append(Syntax.EndOrBeforeEndingNewLine);
        }

        public void AppendWordBoundary()
        {
            _sb.Append(Syntax.WordBoundary);
        }

        public void AppendNotWordBoundary()
        {
            _sb.Append(Syntax.NotWordBoundary);
        }

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

        public void AppendOr()
        {
            _sb.Append(Syntax.Or);
        }

        public void AppendAny(object content)
        {
            AppendAny(content, GroupMode.NoncapturingGroup);
        }

        internal void AppendAny(object content, GroupMode mode)
        {
            if (mode == GroupMode.Group)
            {
                AppendStartParenthesis();
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

        public void AppendNumberedGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            AppendStartParenthesis();
            AppendGroupContent(content);
            AppendGroupEnd();
        }

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

        public void AppendNamedGroup(string groupName, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            RegexUtilities.CheckGroupName(groupName);

            AppendNamedGroupInternal(groupName, content);
        }

        public void AppendNamedGroupInternal(string groupName, object content)
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

        public void AppendGroupEnd()
        {
            _sb.Append(Syntax.GroupEnd);
        }

        public void AppendAnyChar()
        {
            _sb.Append(Syntax.AnyChar);
        }

        public void AppendCharClass(CharClass value)
        {
            _sb.Append(Syntax.CharClass(value));
        }

        public void AppendDigit()
        {
            _sb.Append(Syntax.Digit);
        }

        public void AppendWhiteSpace()
        {
            _sb.Append(Syntax.WhiteSpace);
        }

        public void AppendWordChar()
        {
            _sb.Append(Syntax.WordChar);
        }

        public void AppendNotDigit()
        {
            _sb.Append(Syntax.NotDigit);
        }

        public void AppendNotWhiteSpace()
        {
            _sb.Append(Syntax.NotWhiteSpace);
        }

        public void AppendNotWordChar()
        {
            _sb.Append(Syntax.NotWordChar);
        }

        public void AppendCharGroupStart()
        {
            AppendCharGroupStart(false);
        }

        public void AppendCharGroupStart(bool negative)
        {
            _sb.Append(negative
                ? Syntax.NegativeCharGroupStart
                : Syntax.CharGroupStart);
        }

        public void AppendNegativeCharGroupStart()
        {
            AppendCharGroupStart(true);
        }

        public void AppendCharGroupEnd()
        {
            _sb.Append(Syntax.CharGroupEnd);
        }

        public void AppendCharGroup(NamedBlock block)
        {
            AppendCharGroup(block, false);
        }

        public void AppendNegativeCharGroup(NamedBlock block)
        {
            AppendCharGroup(block, true);
        }

        public void AppendCharGroup(NamedBlock block, bool negative)
        {
            AppendCharGroupStart();
            AppendNamedBlock(block, negative);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(GeneralCategory category)
        {
            AppendCharGroup(category, false);
        }

        public void AppendNegativeCharGroup(GeneralCategory category)
        {
            AppendCharGroup(category, true);
        }

        public void AppendCharGroup(GeneralCategory category, bool negative)
        {
            AppendCharGroupStart();
            AppendGeneralCategory(category, negative);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(CharClass value)
        {
            AppendCharGroupStart();
            AppendCharClass(value);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(AsciiChar value)
        {
            AppendCharGroup(value, false);
        }

        public void AppendNegativeCharGroup(AsciiChar value)
        {
            AppendCharGroup(value, true);
        }

        public void AppendCharGroup(AsciiChar value, bool negative)
        {
            AppendCharGroupStart(negative);
            Append(value, true);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(string characters)
        {
            AppendCharGroup(characters, false);
        }

        public void AppendNegativeCharGroup(string characters)
        {
            AppendCharGroup(characters, true);
        }

        public void AppendCharGroup(string characters, bool negative)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            if (characters.Length == 0)
            {
                throw new ArgumentException("Character group cannot be empty.", "characters");
            }

            AppendCharGroupStart(negative);
            Append(characters, true);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(char value)
        {
            AppendCharGroup(value, false);
        }

        public void AppendNegativeCharGroup(char value)
        {
            AppendCharGroup(value, true);
        }

        public void AppendCharGroup(char value, bool negative)
        {
            AppendCharGroupStart(negative);
            Append(value, true);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(char first, char last)
        {
            AppendCharGroup(first, last, false);
        }

        public void AppendNegativeCharGroup(char first, char last)
        {
            AppendCharGroup(first, last, true);
        }

        public void AppendCharGroup(char first, char last, bool negative)
        {
            AppendCharGroupStart(negative);
            AppendCharRange(first, last);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(int charCode)
        {
            AppendCharGroup(charCode, false);
        }

        public void AppendNegativeCharGroup(int charCode)
        {
            AppendCharGroup(charCode, true);
        }

        public void AppendCharGroup(int charCode, bool negative)
        {
            AppendCharGroupStart(negative);
            Append(charCode, true);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(int firstCharCode, int lastCharCode)
        {
            AppendCharGroup(firstCharCode, lastCharCode, false);
        }

        public void AppendNegativeCharGroup(int firstCharCode, int lastCharCode)
        {
            AppendCharGroup(firstCharCode, lastCharCode, true);
        }

        public void AppendCharGroup(int firstCharCode, int lastCharCode, bool negative)
        {
            AppendCharGroupStart(negative);
            AppendCharRange(firstCharCode, lastCharCode);
            AppendCharGroupEnd();
        }

        public void AppendCharGroup(CharGrouping value)
        {
            AppendCharGroup(value, false);
        }

        public void AppendNegativeCharGroup(CharGrouping value)
        {
            AppendCharGroup(value, true);
        }

        public void AppendCharGroup(CharGrouping value, bool negative)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            AppendCharGroupStart(negative);
            value.AppendContentTo(this);
            AppendCharGroupEnd();
        }

        public void AppendSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            AppendSubtraction(baseGroup, excludedGroup, false);
        }

        public void AppendNegativeSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            AppendSubtraction(baseGroup, excludedGroup, true);
        }

        public void AppendSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup, bool negative)
        {
            if (baseGroup == null)
            {
                throw new ArgumentNullException("baseGroup");
            }

            if (excludedGroup == null)
            {
                throw new ArgumentNullException("excludedGroup");
            }

            AppendCharGroupStart(negative);

            baseGroup.AppendBaseGroupTo(this);

            AppendHyphen();

            excludedGroup.AppendExcludedGroupTo(this);

            AppendCharGroupEnd();
        }

        public void AppendGeneralCategory(GeneralCategory category)
        {
            AppendGeneralCategory(category, false);
        }

        public void AppendNotGeneralCategory(GeneralCategory category)
        {
            AppendGeneralCategory(category, true);
        }

        public void AppendGeneralCategory(GeneralCategory category, bool negative)
        {
            _sb.Append(negative ? Syntax.NotUnicodeStart : Syntax.UnicodeStart);
            _sb.Append(Syntax.GetGeneralCategoryValue(category));
            _sb.Append(Syntax.UnicodeEnd);
        }

        public void AppendNamedBlock(NamedBlock block)
        {
            AppendNamedBlock(block, false);
        }

        public void AppendNotNamedBlock(NamedBlock block)
        {
            AppendNamedBlock(block, true);
        }

        public void AppendNamedBlock(NamedBlock block, bool negative)
        {
            _sb.Append(negative ? Syntax.NotUnicodeStart : Syntax.UnicodeStart);
            _sb.Append(Syntax.GetNamedBlockValue(block));
            _sb.Append(Syntax.UnicodeEnd);
        }

        public void AppendMaybe()
        {
            _sb.Append(Syntax.Maybe);
        }

        public void AppendMaybeMany()
        {
            _sb.Append(Syntax.MaybeMany);
        }

        public void AppendOneMany()
        {
            _sb.Append(Syntax.OneMany);
        }

        public void AppendCount(int exactCount)
        {
            if (exactCount < 0)
            {
                throw new ArgumentOutOfRangeException("exactCount");
            }

            AppendCountInternal(exactCount);
        }

        public void AppendCount(int minCount, int maxCount)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            if (maxCount < minCount)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }

            AppendCountInternal(minCount, maxCount);
        }

        internal void AppendCountInternal(int exactCount)
        {
            AppendStartCurlyBracket();
            _sb.Append(exactCount);
            AppendEndCurlyBracket();
        }

        internal void AppendCountInternal(int minCount, int maxCount)
        {
            AppendStartCurlyBracket();
            _sb.Append(minCount);
            AppendComma();
            _sb.Append(maxCount);
            AppendEndCurlyBracket();
        }

        public void AppendCountFrom(int minCount)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            AppendCountFromInternal(minCount);
        }

        internal void AppendCountFromInternal(int minCount)
        {
            AppendStartCurlyBracket();
            _sb.Append(minCount);
            AppendComma();
            AppendEndCurlyBracket();
        }

        public void AppendCountTo(int maxCount)
        {
            if (maxCount < 0)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }

            AppendCountToInternal(maxCount);
        }

        internal void AppendCountToInternal(int maxCount)
        {
            AppendStartCurlyBracket();
            _sb.Append(0);
            AppendComma();
            _sb.Append(maxCount);
            AppendEndCurlyBracket();
        }

        public void AppendLazy()
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

        public void AppendOptions(RegexOptions applyOptions)
        {
            AppendOptions(applyOptions, RegexOptions.None);
        }

        public void AppendOptions(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            if (applyOptions != RegexOptions.None || disableOptions != RegexOptions.None)
            {
                if (!RegexUtilities.IsValidInlineOptions(applyOptions))
                {
                    throw new ArgumentNullException("applyOptions");
                }

                if (!RegexUtilities.IsValidInlineOptions(disableOptions))
                {
                    throw new ArgumentNullException("disableOptions");
                }

                AppendGroupStart();
                AppendOptionsChars(applyOptions, disableOptions);
                AppendGroupEnd();

                _currentOptions &= applyOptions;
                _currentOptions &= ~disableOptions;
            }
        }

        public void AppendOptions(RegexOptions applyOptions, object content)
        {
            AppendOptions(applyOptions, RegexOptions.None, content);
        }

        internal void AppendOptions(RegexOptions applyOptions, RegexOptions disableOptions, object content)
        {
            if (!RegexUtilities.IsValidInlineOptions(applyOptions))
            {
                throw new ArgumentNullException("applyOptions");
            }

            if (!RegexUtilities.IsValidInlineOptions(disableOptions))
            {
                throw new ArgumentNullException("disableOptions");
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

        public void AppendInlineComment(string comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }

            if (comment.IndexOf(')') != -1)
            {
                throw new ArgumentException("Comment cannot contain right parenthesis.", "comment");
            }

            AppendInlineCommentInternal(comment);
        }

        internal void AppendInlineCommentInternal(string comment)
        {
            _sb.Append(Syntax.InlineCommentStart);
            _sb.Append(comment);
            AppendGroupEnd();
        }

        public void AppendStartIdentifierBoundary()
        {
            _sb.Append(Settings.IdentifierBoundary == IdentifierBoundary.Apostrophe
                ? '\''
                : '<');
        }

        public void AppendEndIdentifierBoundary()
        {
            _sb.Append(Settings.IdentifierBoundary == IdentifierBoundary.Apostrophe
                ? '\''
                : '>');
        }

        internal void AppendStartParenthesis()
        {
            _sb.Append('(');
        }

        private void AppendStartCurlyBracket()
        {
            _sb.Append('{');
        }

        private void AppendEndCurlyBracket()
        {
            _sb.Append('}');
        }

        private void AppendComma()
        {
            _sb.Append(',');
        }

        private void AppendColon()
        {
            _sb.Append(':');
        }

        private void AppendHyphen()
        {
            _sb.Append('-');
        }

        private void AppendBackslash()
        {
            _sb.Append('\\');
        }

        public void AppendAsciiHexadecimal(int charCode)
        {
            if (charCode < 0 || charCode > 0xFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            _sb.Append(Syntax.AsciiStart);
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

        public PatternSettings Settings
        {
            get { return _settings; }
        }

        public RegexOptions CurrentOptions
        {
            get { return _currentOptions; }
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