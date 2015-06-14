// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
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
            if (!string.IsNullOrEmpty(value))
            {
                base.Write(value);
            }
        }

        internal void WriteIf(bool condition, string trueValue, string falseValue)
        {
            if (condition)
            {
                base.Write(trueValue);
            }
            else
            {
                base.Write(falseValue);
            }
        }

        public void WriteEscaped(string value)
        {
            base.Write(RegexUtilities.Escape(value));
        }

        public override void Write(int value)
        {
            base.Write(Syntax.Char(value));
        }

        public void Write(int charCode, bool inCharGroup)
        {
            base.Write(Syntax.Char(charCode, inCharGroup));
        }

        internal void WriteInternal(int charCode)
        {
            base.Write(Syntax.CharInternal(charCode));
        }

        internal void WriteInternal(int charCode, bool inCharGroup)
        {
            base.Write(Syntax.CharInternal(charCode, inCharGroup));
        }

        internal void WriteRange(int firstCharCode, int lastCharCode)
        {
            Write(firstCharCode, true);
            WriteGroupSeparator();
            Write(lastCharCode, true);
        }

        internal void WriteRangeInternal(int firstCharCode, int lastCharCode)
        {
            WriteInternal(firstCharCode, true);
            WriteGroupSeparator();
            WriteInternal(lastCharCode, true);
        }

        public override void Write(char value)
        {
            base.Write(Syntax.Char(value));
        }

        public void Write(char value, bool inCharGroup)
        {
            base.Write(Syntax.Char(value, inCharGroup));
        }

        public void Write(AsciiChar value)
        {
            base.Write(Syntax.Char(value));
        }

        public void Write(AsciiChar value, bool inCharGroup)
        {
            base.Write(Syntax.Char(value, inCharGroup));
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
            if (!Expressions.Add(expression))
            {
                throw new InvalidOperationException("A circular reference was detected while creating a pattern.");
            }
#endif
            expression.BuildOpening(this);

            expression.BuildContent(this);

            expression.BuildClosing(this);
#if DEBUG
            Expressions.Remove(expression);
#endif
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
                WriteEscaped(text);
                return;
            }

            CharGroupItem charGroupItem = value as CharGroupItem;
            if (charGroupItem != null)
            {
                charGroupItem.BuildGroup(this);

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

        public void WriteCapturingGroupStart()
        {
            base.Write(Syntax.CapturingGroupStart);
        }

        public void WriteNoncapturingGroupStart()
        {
            base.Write(Syntax.NoncapturingGroupStart);
        }

        public void WriteGroupSeparator()
        {
            base.Write(Syntax.GroupSeparator);
        }

        public void WriteGroupEnd()
        {
            base.Write(Syntax.GroupEnd);
        }

        internal void WriteNamedGroupStartInternal(string groupName)
        {
            switch (Settings.IdentifierBoundary)
            {
                case IdentifierBoundary.LessThan:
                { 
                    base.Write(@"(?<");
                    base.Write(groupName);
                    base.Write(@">");
                    break;
                }
                case IdentifierBoundary.Apostrophe:
                {
                    base.Write(@"(?'");
                    base.Write(groupName);
                    base.Write(@"'");
                    break;
                }
            }
        }

        internal void WriteBalanceGroupStartInternal(string name1, string name2)
        {
            switch (Settings.IdentifierBoundary)
            {
                case IdentifierBoundary.LessThan:
                {
                    base.Write(@"(?<");
                    base.Write(name1);
                    WriteGroupSeparator();
                    base.Write(name2);
                    base.Write(@">");
                    break;
                }
                case IdentifierBoundary.Apostrophe:
                {
                    base.Write(@"(?'");
                    base.Write(name1);
                    WriteGroupSeparator();
                    base.Write(name2);
                    base.Write(@"'");
                    break;
                }
            }
        }

        public void WriteNonbacktrackingGroupStart()
        {
            base.Write(Syntax.NonbacktrackingGroupStart);
        }

        public void WriteCharGroupStart()
        {
            WriteCharGroupStart(false);
        }

        public void WriteCharGroupStart(bool negative)
        {
            if (negative)
            {
                base.Write(Syntax.NotCharGroupStart);
            }
            else
            {
                base.Write(Syntax.CharGroupStart);
            }
        }

        public void WriteNotCharGroupStart()
        {
            WriteCharGroupStart(true);
        }

        public void WriteCharGroupEnd()
        {
            base.Write(Syntax.CharGroupEnd);
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

        public void WritePreviousMatchEnd()
        {
            base.Write(Syntax.PreviousMatchEnd);
        }

        public void WriteWordBoundary()
        {
            base.Write(Syntax.WordBoundary);
        }

        public void WriteNotWordBoundary()
        {
            base.Write(Syntax.NotWordBoundary);
        }

        public void WriteEndOrBeforeEndingNewLine()
        {
            base.Write(Syntax.EndOrBeforeEndingNewLine);
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
            WriteIf(negative, Syntax.NotUnicodeStart, Syntax.UnicodeStart);
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
            WriteIf(negative, Syntax.NotUnicodeStart, Syntax.UnicodeStart);
            base.Write(Syntax.GetNamedBlockValue(block));
            base.Write(Syntax.UnicodeEnd);
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
                base.Write("(?");
                base.Write(options);
                base.Write(":");
                Write(content);
                WriteGroupEnd();
            }
            else
            {
                Write(content);
            }
        }

        public void WriteGroupOptionsStart(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            string options = Syntax.GetInlineChars(applyOptions, disableOptions);

            if (!string.IsNullOrEmpty(options))
            {
                base.Write("(?");
                base.Write(options);
                base.Write(":");
            }
            else
            {
                WriteNoncapturingGroupStart();
            }
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
                base.Write("(?");
                base.Write(options);
                WriteGroupEnd();
            }
        }

        internal void WriteBackreferenceInternal(int groupNumber)
        {
            base.Write(Syntax.Backreference(groupNumber));

            if (Settings.SeparatorAfterNumberBackreference)
            {
                WriteNoncapturingGroupStart();
                WriteGroupEnd();
            }
        }

        internal void WriteBackreferenceInternal(string groupName)
        {
            switch (Settings.IdentifierBoundary)
            {
                case IdentifierBoundary.LessThan:
                {
                    base.Write(@"\k<");
                    base.Write(groupName);
                    base.Write(">");
                    break;
                }
                case IdentifierBoundary.Apostrophe:
                {
                    base.Write(@"\k'");
                    base.Write(groupName);
                    base.Write("'");
                    break;
                }
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

        public void WriteAnyChar()
        {
            base.Write(Syntax.AnyChar);
        }

        public void WriteOr()
        {
            base.Write(Syntax.Or);
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
            Write(groupName);
            WriteGroupEnd();
        }

        public void WriteAssertStart()
        {
            base.Write(Syntax.AssertStart);
        }

        public void WriteNotAssertStart()
        {
            base.Write(Syntax.NotAssertStart);
        }

        public void WriteAssertBackStart()
        {
            base.Write(Syntax.AssertBackStart);
        }

        public void WriteNotAssertBackStart()
        {
            base.Write(Syntax.NotAssertBackStart);
        }

        public void WriteCharClass(CharClass value)
        {
            base.Write(Syntax.CharClass(value));
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
            base.Write("{");
            base.Write(exactCount);
            base.Write("}");
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
            base.Write("{");
            base.Write(minCount);
            base.Write(",}");
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
            base.Write("{");
            base.Write(minCount);
            base.Write(",");
            base.Write(maxCount);
            base.Write("}");
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