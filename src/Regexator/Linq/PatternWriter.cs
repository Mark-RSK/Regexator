// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
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

        public void WriteEscaped(string value)
        {
            base.Write(RegexUtilities.Escape(value));
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

        public void WriteContent(object content)
        {
            if (content == null)
            {
                return;
            }

            Expression expression = content as Expression;
            if (expression != null)
            {
                Write(expression);
                return;
            }

            string text = content as string;
            if (text != null)
            {
                WriteEscaped(text);
                return;
            }

            CharGroupItem item = content as CharGroupItem;
            if (item != null)
            {
                item.BuildGroup(this);

                return;
            }

            object[] values = content as object[];
            if (values != null)
            {
                foreach (var value in values)
                {
                    WriteContent(value);
                }

                return;
            }

            IEnumerable items = content as IEnumerable;
            if (items != null)
            {
                foreach (var value in items)
                {
                    WriteContent(value);
                }
            }
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

        public void WriteCharGroupStart()
        {
            base.Write(Syntax.CharGroupStart);
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
            base.Write(Syntax.UnicodeStart);
            base.Write(Syntax.GetGeneralCategoryValue(category));
            base.Write(Syntax.UnicodeEnd);
        }

        public void WriteNotGeneralCategory(GeneralCategory category)
        {
            base.Write(Syntax.NotUnicodeStart);
            base.Write(Syntax.GetGeneralCategoryValue(category));
            base.Write(Syntax.UnicodeEnd);
        }

        public void WriteNamedBlock(NamedBlock block)
        {
            base.Write(Syntax.UnicodeStart);
            base.Write(Syntax.GetNamedBlockValue(block));
            base.Write(Syntax.UnicodeEnd);
        }

        public void WriteNotNamedBlock(NamedBlock block)
        {
            base.Write(Syntax.NotUnicodeStart);
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
                WriteContent(content);
                WriteGroupEnd();
            }
            else
            {
                WriteContent(content);
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

        public void WriteAssertStart()
        {
            base.Write(Syntax.AssertStart);
        }

        public void WriteCapturingGroupStart()
        {
            base.Write(Syntax.CapturingGroupStart);
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