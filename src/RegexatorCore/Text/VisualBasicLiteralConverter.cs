
// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics;

namespace Pihrtsoft.Text.RegularExpressions
{
    internal sealed class VisualBasicLiteralConverter
        : LiteralConverter
    {
        public VisualBasicLiteralConverter()
            : base()
        {
        }

        public VisualBasicLiteralConverter(LiteralSettings settings)
            : base(settings)
        {
        }

        protected override void AppendChar(char value)
        {
            if (value == '"')
            {
                Append('"');
            }

            base.AppendChar(value);
        }

        protected override void EndLine()
        {
            AppendQuoteMark();

            if (Settings.ConcatAtBeginningOfLine)
            {
                Append(" _");
                AppendNewLine();
            }
            else
            {
                Append(' ');
            }

            Append(Settings.ConcatOperator);
            Append(' ');
            AppendNewLineLiteral();
        }

        protected override void BeginLine()
        {
            Append(' ');
            Append(Settings.ConcatOperator);

            if (Settings.ConcatAtBeginningOfLine)
            {
                Append(' ');
            }
            else
            {
                AppendNewLine();
            }

            AppendStartQuoteMark();
        }

        protected override string GetNewLineLiteral()
        {
            switch (Settings.NewLineLiteral)
            {
                case NewLineMode.Linefeed:
                    return "vbLf";
                case NewLineMode.CarriageReturnLinefeed:
                    return "vbCrLf";
                case NewLineMode.Environment:
                    return "Environment.NewLine";
                default:
                    Debug.Assert(false);
                    return string.Empty;
            }
        }
    }
}
