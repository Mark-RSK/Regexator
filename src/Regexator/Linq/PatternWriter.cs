// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public class PatternWriter
        : StringWriter
    {
#if DEBUG
        private readonly HashSet<Expression> _expressions;
#endif
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
#if DEBUG
            _expressions = new HashSet<Expression>();
#endif
        }

        public override void Write(string value)
        {
            Write(value, false);
        }

        public void Write(string value, bool inCharGroup)
        {
            if (!string.IsNullOrEmpty(value))
            {
                base.Write(RegexUtilities.Escape(value, inCharGroup));
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
                case CharEscapeMode.AsciiEscape:
                    WriteAsciiHexadecimal(value);
                    break;
                case CharEscapeMode.BackslashEscape:
                    base.Write(@"\");
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
            WriteGroupSeparator();
            Write(lastChar, true);
        }

        public void WriteCharRange(int firstCharCode, int lastCharCode)
        {
            Write(firstCharCode, true);
            WriteGroupSeparator();
            Write(lastCharCode, true);
        }

        internal void WriteCharRangeInternal(int firstCharCode, int lastCharCode)
        {
            WriteInternal(firstCharCode, true);
            WriteGroupSeparator();
            WriteInternal(lastCharCode, true);
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
                    WriteInternal(items[i]);
                }
            }
            else
            {
                WriteInternal(expression);
            }
        }

        private void WriteInternal(Expression expression)
        {
#if DEBUG
            Debug.Assert(Expressions.Add(expression));
#endif
            expression.WriteStartTo(this);

            expression.WriteContentTo(this);

            expression.WriteEndTo(this);
#if DEBUG
            Expressions.Remove(expression);
#endif
        }

        public void Write(CharGroupItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            WriteCharGroupStart();

            //todo check empty
            item.WriteContentTo(this);

            WriteCharGroupEnd();
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

        public void WriteIfStart()
        {
            base.Write(Syntax.IfStart);
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

        public void WriteOr()
        {
            base.Write(Syntax.Or);
        }

        public void WriteAssert(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteAssertStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteAssertBack(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteAssertBackStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteNotAssert(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteNotAssertStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteNotAssertBack(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            WriteNotAssertBackStart();
            WriteGroupContent(content);
            WriteGroupEnd();
        }

        public void WriteStartOfInput()
        {
            base.Write(Syntax.StartOfInput);
        }

        public void WriteStartOfLine()
        {
            base.Write(Syntax.StartOfLine);
        }

        public void WriteEndOfInput()
        {
            base.Write(Syntax.EndOfInput);
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

        public void WriteCapturingGroup(object content)
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
            base.Write(Syntax.CapturingGroupStart);
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
            WriteGroupSeparator();
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

        internal void WriteBackreferenceInternal(int groupNumber)
        {
            base.Write(Syntax.Backreference(groupNumber));

            if (Settings.HasOptions(PatternOptions.SeparatorAfterNumberBackreference))
            {
                WriteNoncapturingGroupStart();
                WriteGroupEnd();
            }
        }

        internal void WriteBackreferenceInternal(string groupName)
        {
            WriteBackreferenceStart();
            WriteLeftIdentifierBoundary();
            base.Write(groupName);
            WriteRightIdentifierBoundary();
        }

        private void WriteBackreferenceStart()
        {
            base.Write(@"\k");
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

        public void WriteGroupSeparator()
        {
            base.Write(Syntax.GroupSeparator);
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

#if DEBUG
        public HashSet<Expression> Expressions
        {
            get { return _expressions; }
        }
#endif

        public PatternSettings Settings
        {
            get { return _settings; }
        }
    }
}