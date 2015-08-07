// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics;

namespace Pihrtsoft.Text.RegularExpressions
{
    internal sealed class CSharpLiteralConverter
        : LiteralConverter
    {
        public CSharpLiteralConverter()
            : base()
        {
        }

        public CSharpLiteralConverter(LiteralSettings settings)
            : base(settings)
        {
        }

        protected override void AppendChar(char value)
        {
            switch (value)
            {
                case '"':
                    {
                        Append(Settings.Verbatim ? '"' : '\\');
                        break;
                    }
                case '\\':
                    {
                        if (!Settings.Verbatim)
                        {
                            Append("\\");
                        }

                        break;
                    }
            }

            base.AppendChar(value);
        }

        protected override void EndLine()
        {
            AppendQuoteMark();

            if (Settings.ConcatAtBeginningOfLine)
            {
                AppendNewLine();
            }
            else
            {
                Append(" ");
            }

            Append("+ ");
            AppendNewLineLiteral();
        }

        protected override void BeginLine()
        {
            Append(" + ");

            if (!Settings.ConcatAtBeginningOfLine)
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
                    return @"'\n'";
                case NewLineMode.CarriageReturnLinefeed:
                    return @"""\r\n\""";
                case NewLineMode.Environment:
                    return "Environment.NewLine";
                default:
                    Debug.Assert(false);
                    return string.Empty;
            }
        }

        protected override void AppendStartQuoteMark()
        {
            if (Settings.Verbatim)
            {
                Append('@');
            }

            base.AppendStartQuoteMark();
        }
    }
}
