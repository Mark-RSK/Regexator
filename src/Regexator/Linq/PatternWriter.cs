// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public class PatternWriter
        : StringWriter
    {
        private PatternSettings _settings;

        internal PatternWriter()
            : this(new PatternSettings())
        {
        }

        internal PatternWriter(PatternSettings settings)
            : base()
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            _settings = settings;
        }

        public override void Write(string value)
        {
            Write(value, false);
        }

        public void Write(string value, bool inCharGroup)
        {
            if (!string.IsNullOrEmpty(value))
            {
                CharEscapeMode mode;

                for (int i = 0; i < value.Length; i++)
                {
                    mode = RegexUtilities.GetEscapeMode((int)value[i], inCharGroup);
                    if (mode != CharEscapeMode.None)
                    {
                        StringBuilder sb = GetStringBuilder();
                        char ch = value[i];
                        int lastPos;
                        sb.Append(value, 0, i);

                        do
                        {
                            RegexUtilities.AppendEscape(ch, mode, sb);
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

                            sb.Append(value, lastPos, i - lastPos);

                        } while (i < value.Length);

                        return;
                    }
                }

                base.Write(value);
            }
        }

        public void WriteInternal(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                base.Write(value);
            }
        }

        public override void Write(char value)
        {
            Write(value, false);
        }

        public void Write(char value, bool inCharGroup)
        {
            WriteInternal((int)value, inCharGroup);
        }

        public void Write(AsciiChar value)
        {
            Write(value, false);
        }

        public void Write(AsciiChar value, bool inCharGroup)
        {
            WriteInternal((int)value, inCharGroup);
        }

        public override void Write(int value)
        {
            Write(value, false);
        }

        public void Write(int value, bool inCharGroup)
        {
            if (value < 0 || value > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("value");
            }

            WriteInternal(value, inCharGroup);
        }

        internal void WriteInternal(int value)
        {
            WriteInternal(value, false);
        }

        internal void WriteInternal(int value, bool inCharGroup)
        {
            switch (RegexUtilities.GetEscapeMode(value, inCharGroup))
            {
                case CharEscapeMode.None:
                    base.Write((char)value);
                    break;
                case CharEscapeMode.AsciiHexadecimal:
                    WriteAsciiHexadecimal(value);
                    break;
                case CharEscapeMode.Backslash:
                    WriteBackslash();
                    base.Write((char)value);
                    break;
                case CharEscapeMode.Bell:
                    WriteBell();
                    break;
                case CharEscapeMode.CarriageReturn:
                    WriteCarriageReturn();
                    break;
                case CharEscapeMode.Escape:
                    WriteEscape();
                    break;
                case CharEscapeMode.FormFeed:
                    WriteFormFeed();
                    break;
                case CharEscapeMode.Linefeed:
                    WriteLinefeed();
                    break;
                case CharEscapeMode.VerticalTab:
                    WriteVerticalTab();
                    break;
                case CharEscapeMode.Tab:
                    WriteTab();
                    break;
            }
        }

        internal void WriteCharRange(char firstChar, char lastChar)
        {
            Write(firstChar, true);
            WriteHyphen();
            Write(lastChar, true);
        }

        internal void WriteCharRange(int firstCharCode, int lastCharCode)
        {
            Write(firstCharCode, true);
            WriteHyphen();
            Write(lastCharCode, true);
        }

        public void Write(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (expression.Previous != null)
            {
                Expression[] items = expression.GetExpressions().ToArray();
                for (int i = (items.Length - 1); i >= 0; i--)
                {
                    items[i].WriteTo(this);
                }
            }
            else
            {
                expression.WriteTo(this);
            }
        }

        public void Write(CharGroupItem item)
        {
            WriteCharGroup(item);
        }

        public override void Write(object value)
        {
            if (value == null)
            {
                return;
            }

            Expression expression = value as Expression;
            if (expression != null)
            {
                Write(expression);
                return;
            }

            string text = value as string;
            if (text != null)
            {
                Write(text);
                return;
            }

            CharGroupItem charGroupItem = value as CharGroupItem;
            if (charGroupItem != null)
            {
                Write(charGroupItem);
                return;
            }

            object[] values = value as object[];
            if (values != null)
            {
                foreach (var item in values)
                {
                    Write(item);
                }

                return;
            }

            IEnumerable items = value as IEnumerable;
            if (items != null)
            {
                foreach (var item in items)
                {
                    Write(item);
                }
            }
        }

        internal void WriteGroupStart()
        {
            base.Write("(?");
        }

        internal void WriteGroupContent(object content)
        {
            string text = content as string;
            if (text != null)
            {
                Write(text);
            }
            else
            {
                object[] values = content as object[];
                if (values != null)
                {
                    if (values.Length > 0)
                    {
                        Write(values[0]);

                        for (int i = 1; i < values.Length; i++)
                        {
                            WriteOr();
                            Write(values[i]);
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
                            Write(en.Current);

                            while (en.MoveNext())
                            {
                                WriteOr();
                                Write(en.Current);
                            }
                        }
                    }
                    else
                    {
                        Write(content);
                    }
                }
            }
        }

        public void WriteIf(object testContent, object trueContent, object falseContent)
        {
            if (testContent == null)
            {
                throw new ArgumentNullException("testContent");
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            WriteGroupStart();

            if (Settings.HasOptions(PatternOptions.ConditionWithAssertion))
            {
                WriteAssertStart();
            }
            else
            {
                WriteCapturingGroupStart();
            }

            Write(testContent);
            WriteGroupEnd();
            Write(trueContent);

            if (falseContent != null)
            {
                WriteOr();
                Write(falseContent);
            }

            WriteGroupEnd();
        }

        public void WriteIfGroup(string groupName, object trueContent, object falseContent)
        {
            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            RegexUtilities.CheckGroupName(groupName);

            WriteIfGroupInternal(groupName, trueContent, falseContent);
        }

        internal void WriteIfGroupInternal(string groupName, object trueContent, object falseContent)
        {
            WriteGroupStart();
            WriteIfGroupCondition(groupName);
            Write(trueContent);

            if (falseContent != null)
            {
                WriteOr();
                Write(falseContent);
            }

            WriteGroupEnd();
        }

        public void WriteIfGroup(int groupNumber, object trueContent, object falseContent)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            WriteGroupStart();
            WriteIfGroupCondition(groupNumber);
            Write(trueContent);

            if (falseContent != null)
            {
                WriteOr();
                Write(falseContent);
            }

            WriteGroupEnd();
        }

        internal void WriteIfGroupCondition(int groupNumber)
        {
            WriteIfGroupCondition(groupNumber.ToString(CultureInfo.InvariantCulture));
        }

        internal void WriteIfGroupCondition(string groupName)
        {
            WriteCapturingGroupStart();
            base.Write(groupName);
            WriteGroupEnd();
        }

        public void WriteAssert(object content)
        {
            WriteAssertStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteNotAssert(object content)
        {
            WriteNotAssertStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteAssertBack(object content)
        {
            WriteAssertBackStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteNotAssertBack(object content)
        {
            WriteNotAssertBackStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteStart()
        {
            base.Write(Syntax.Start);
        }

        public void WriteStartOfLine()
        {
            base.Write(Syntax.StartOfLine);
        }

        public void WriteEnd()
        {
            base.Write(Syntax.End);
        }

        public void WriteEndOfLine()
        {
            base.Write(Syntax.EndOfLine);
        }

        public void WriteEndOrBeforeEndingNewLine()
        {
            base.Write(Syntax.EndOrBeforeEndingNewLine);
        }

        public void WriteWordBoundary()
        {
            base.Write(Syntax.WordBoundary);
        }

        public void WriteNotWordBoundary()
        {
            base.Write(Syntax.NotWordBoundary);
        }

        public void WritePreviousMatchEnd()
        {
            base.Write(Syntax.PreviousMatchEnd);
        }

        internal void WriteAssertStart()
        {
            base.Write(Syntax.AssertStart);
        }

        internal void WriteNotAssertStart()
        {
            base.Write(Syntax.NotAssertStart);
        }

        internal void WriteAssertBackStart()
        {
            base.Write(Syntax.AssertBackStart);
        }

        internal void WriteNotAssertBackStart()
        {
            base.Write(Syntax.NotAssertBackStart);
        }

        public void WriteOr()
        {
            base.Write(Syntax.Or);
        }

        public void WriteAny(object content)
        {
            WriteAny(content, AnyGroupMode.Noncapturing);
        }

        internal void WriteAny(object content, AnyGroupMode mode)
        {
            if (mode == AnyGroupMode.Capturing)
            {
                WriteCapturingGroupStart();
            }
            else if (mode == AnyGroupMode.Noncapturing)
            {
                WriteNoncapturingGroupStart();
            }

            WriteGroupContent(content);

            if (mode != AnyGroupMode.None)
            {
                WriteGroupEnd();
            }
        }

        public void WriteGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteCapturingGroupStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        internal void WriteCapturingGroupStart()
        {
            base.Write('(');
        }

        public void WriteNoncapturingGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteNoncapturingGroupStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        internal void WriteNoncapturingGroupStart()
        {
            base.Write(Syntax.NoncapturingGroupStart);
        }

        public void WriteNonbacktrackingGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteNonbacktrackingGroupStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        internal void WriteNonbacktrackingGroupStart()
        {
            base.Write(Syntax.NonbacktrackingGroupStart);
        }

        public void WriteNamedGroup(string groupName, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            RegexUtilities.CheckGroupName(groupName);

            WriteNamedGroupInternal(groupName, content);
        }

        public void WriteNamedGroupInternal(string groupName, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteNamedGroupStart(groupName);
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        internal void WriteNamedGroupStart(string groupName)
        {
            WriteGroupStart();
            WriteLeftIdentifierBoundary();
            base.Write(groupName);
            WriteRightIdentifierBoundary();
        }

        public void WriteGroupOptions(InlineOptions applyOptions, object content)
        {
            WriteGroupOptions(applyOptions, InlineOptions.None, content);
        }

        public void WriteGroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            string options = Syntax.GetInlineChars(applyOptions, disableOptions);

            if (!string.IsNullOrEmpty(options))
            {
                WriteGroupStart();
                base.Write(options);
                WriteColon();
            }
            else
            {
                WriteNoncapturingGroupStart();
            }

            Write(content);
            WriteGroupEnd();
        }

        internal void WriteBalanceGroup(string name1, string name2, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteBalanceGroupStartInternal(name1, name2);
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        internal void WriteBalanceGroupStartInternal(string name1, string name2)
        {
            WriteGroupStart();
            WriteLeftIdentifierBoundary();
            base.Write(name1);
            WriteHyphen();
            base.Write(name2);
            WriteRightIdentifierBoundary();
        }

        public void WriteGroupEnd()
        {
            base.Write(Syntax.GroupEnd);
        }

        public void WriteAnyChar()
        {
            base.Write(Syntax.AnyChar);
        }

        public void WriteCharClass(CharClass value)
        {
            base.Write(Syntax.CharClass(value));
        }

        public void WriteCharGroupStart()
        {
            WriteCharGroupStart(false);
        }

        public void WriteCharGroupStart(bool negative)
        {
            base.Write(negative
                ? Syntax.NotCharGroupStart
                : Syntax.CharGroupStart);
        }

        public void WriteNotCharGroupStart()
        {
            WriteCharGroupStart(true);
        }

        public void WriteCharGroupEnd()
        {
            base.Write(Syntax.CharGroupEnd);
        }

        public void WriteCharGroup(NamedBlock block)
        {
            WriteCharGroup(block, false);
        }

        public void WriteCharGroup(NamedBlock block, bool negative)
        {
            WriteCharGroupStart();
            WriteNamedBlock(block, negative);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(GeneralCategory category)
        {
            WriteCharGroup(category, false);
        }

        public void WriteCharGroup(GeneralCategory category, bool negative)
        {
            WriteCharGroupStart();
            WriteGeneralCategory(category, negative);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(CharClass value)
        {
            WriteCharGroupStart();
            WriteCharClass(value);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(AsciiChar value)
        {
            WriteCharGroup(value, false);
        }

        public void WriteCharGroup(AsciiChar value, bool negative)
        {
            WriteCharGroupStart(negative);
            Write(value, true);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(string characters)
        {
            WriteCharGroup(characters, false);
        }

        public void WriteCharGroup(string characters, bool negative)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            if (characters.Length == 0)
            {
                throw new ArgumentException("Character group cannot be empty.", "characters");
            }

            WriteCharGroupStart(negative);
            Write(characters, true);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(char value)
        {
            WriteCharGroup(value, false);
        }

        public void WriteCharGroup(char value, bool negative)
        {
            WriteCharGroupStart(negative);
            Write(value, true);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(char first, char last)
        {
            WriteCharGroup(first, last, false);
        }

        public void WriteCharGroup(char first, char last, bool negative)
        {
            WriteCharGroupStart(negative);
            WriteCharRange(first, last);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(int charCode)
        {
            WriteCharGroup(charCode, false);
        }

        public void WriteCharGroup(int charCode, bool negative)
        {
            WriteCharGroupStart(negative);
            Write(charCode, true);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(int firstCharCode, int lastCharCode)
        {
            WriteCharGroup(firstCharCode, lastCharCode, false);
        }

        public void WriteCharGroup(int firstCharCode, int lastCharCode, bool negative)
        {
            WriteCharGroupStart(negative);
            WriteCharRange(firstCharCode, lastCharCode);
            WriteCharGroupEnd();
        }

        public void WriteCharGroup(CharGroupItem item)
        {
            WriteCharGroup(item, false);
        }

        public void WriteCharGroup(CharGroupItem item, bool negative)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            WriteCharGroupStart(negative);
            item.WriteContentTo(this);
            WriteCharGroupEnd();
        }

        public void WriteNotCharGroup(NamedBlock block)
        {
            WriteCharGroup(block, true);
        }

        public void WriteNotCharGroup(GeneralCategory category)
        {
            WriteCharGroup(category, true);
        }

        public void WriteNotCharGroup(AsciiChar value)
        {
            WriteCharGroup(value, true);
        }

        public void WriteNotCharGroup(string characters)
        {
            WriteCharGroup(characters, true);
        }

        public void WriteNotCharGroup(char value)
        {
            WriteCharGroup(value, true);
        }

        public void WriteNotCharGroup(char first, char last)
        {
            WriteCharGroup(first, last, true);
        }

        public void WriteNotCharGroup(int charCode)
        {
            WriteCharGroup(charCode, true);
        }

        public void WriteNotCharGroup(int firstCharCode, int lastCharCode)
        {
            WriteCharGroup(firstCharCode, lastCharCode, true);
        }

        public void WriteNotCharGroup(CharGroupItem item)
        {
            WriteCharGroup(item, true);
        }

        public void WriteSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            WriteSubtraction(baseGroup, excludedGroup, false);
        }

        public void WriteNotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            WriteSubtraction(baseGroup, excludedGroup, true);
        }

        public void WriteSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup, bool negative)
        {
            if (baseGroup == null)
            {
                throw new ArgumentNullException("baseGroup");
            }

            if (excludedGroup == null)
            {
                throw new ArgumentNullException("excludedGroup");
            }

            WriteCharGroupStart(negative);

            baseGroup.WriteBaseGroupTo(this);

            WriteHyphen();

            excludedGroup.WriteExcludedGroupTo(this);

            WriteCharGroupEnd();
        }

        public void WriteGeneralCategory(GeneralCategory category)
        {
            WriteGeneralCategory(category, false);
        }

        public void WriteNotGeneralCategory(GeneralCategory category)
        {
            WriteGeneralCategory(category, true);
        }

        public void WriteGeneralCategory(GeneralCategory category, bool negative)
        {
            base.Write(negative ? Syntax.NotUnicodeStart : Syntax.UnicodeStart);
            base.Write(Syntax.GetGeneralCategoryValue(category));
            base.Write(Syntax.UnicodeEnd);
        }

        public void WriteNamedBlock(NamedBlock block)
        {
            WriteNamedBlock(block, false);
        }

        public void WriteNotNamedBlock(NamedBlock block)
        {
            WriteNamedBlock(block, true);
        }

        public void WriteNamedBlock(NamedBlock block, bool negative)
        {
            base.Write(negative ? Syntax.NotUnicodeStart : Syntax.UnicodeStart);
            base.Write(Syntax.GetNamedBlockValue(block));
            base.Write(Syntax.UnicodeEnd);
        }

        public void WriteMaybe()
        {
            base.Write(Syntax.Maybe);
        }

        public void WriteMaybeMany()
        {
            base.Write(Syntax.MaybeMany);
        }

        public void WriteOneMany()
        {
            base.Write(Syntax.OneMany);
        }

        public void WriteCount(int exactCount)
        {
            if (exactCount < 0)
            {
                throw new ArgumentOutOfRangeException("exactCount");
            }

            WriteCountInternal(exactCount);
        }

        internal void WriteCountInternal(int exactCount)
        {
            WriteLeftCurlyBracket();
            base.Write(exactCount);
            WriteRightCurlyBracket();
        }

        public void WriteCountFrom(int minCount)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            WriteCountFromInternal(minCount);
        }

        internal void WriteCountFromInternal(int minCount)
        {
            WriteLeftCurlyBracket();
            base.Write(minCount);
            WriteComma();
            WriteRightCurlyBracket();
        }

        public void WriteCountRange(int minCount, int maxCount)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            if (maxCount < minCount)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }

            WriteCountRangeInternal(minCount, maxCount);
        }

        internal void WriteCountRangeInternal(int minCount, int maxCount)
        {
            WriteLeftCurlyBracket();
            base.Write(minCount);
            WriteComma();
            base.Write(maxCount);
            WriteRightCurlyBracket();
        }

        public void WriteLazy()
        {
            base.Write(Syntax.Lazy);
        }

        internal void WriteGroupReferenceInternal(int groupNumber)
        {
            WriteBackslash();
            base.Write(groupNumber);

            if (Settings.HasOptions(PatternOptions.SeparateNumberedGroupReference))
            {
                WriteNoncapturingGroupStart();
                WriteGroupEnd();
            }
        }

        internal void WriteGroupReferenceInternal(string groupName)
        {
            base.Write(@"\k");
            WriteLeftIdentifierBoundary();
            base.Write(groupName);
            WriteRightIdentifierBoundary();
        }

        public void WriteOptions(InlineOptions applyOptions)
        {
            WriteOptions(applyOptions, InlineOptions.None);
        }

        public void WriteOptions(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            string options = Syntax.GetInlineChars(applyOptions, disableOptions);

            if (!string.IsNullOrEmpty(options))
            {
                WriteGroupStart();
                base.Write(options);
                WriteGroupEnd();
            }
        }

        public void WriteInlineComment(string comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }

            base.Write(Syntax.InlineCommentStart);
            base.Write(RegexUtilities.TrimInlineComment.Match(comment).Value);
            WriteGroupEnd();
        }

        public void WriteLeftIdentifierBoundary()
        {
            base.Write(Settings.IdentifierBoundary == IdentifierBoundary.Apostrophe
                ? '\''
                : '<');
        }

        public void WriteRightIdentifierBoundary()
        {
            base.Write(Settings.IdentifierBoundary == IdentifierBoundary.Apostrophe
                ? '\''
                : '>');
        }

        private void WriteLeftCurlyBracket()
        {
            base.Write('{');
        }

        private void WriteRightCurlyBracket()
        {
            base.Write('}');
        }

        private void WriteComma()
        {
            base.Write(',');
        }

        private void WriteColon()
        {
            base.Write(':');
        }

        private void WriteHyphen()
        {
            base.Write('-');
        }

        private void WriteBackslash()
        {
            base.Write('\\');
        }

        public void WriteAsciiHexadecimal(int charCode)
        {
            if (charCode < 0 || charCode > 0xFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            base.Write(Syntax.AsciiStart);
            base.Write(charCode.ToString("X2", CultureInfo.InvariantCulture));
        }

        private void WriteBell()
        {
            base.Write(Syntax.Bell);
        }

        private void WriteCarriageReturn()
        {
            base.Write(Syntax.CarriageReturn);
        }

        private void WriteEscape()
        {
            base.Write(Syntax.Escape);
        }

        private void WriteFormFeed()
        {
            base.Write(Syntax.FormFeed);
        }

        private void WriteLinefeed()
        {
            base.Write(Syntax.Linefeed);
        }

        private void WriteVerticalTab()
        {
            base.Write(Syntax.VerticalTab);
        }

        private void WriteTab()
        {
            base.Write(Syntax.Tab);
        }

        public PatternSettings Settings
        {
            get { return _settings; }
        }
    }
}