// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    internal sealed class CSharpLiteralBuilder
        : LiteralBuilder
    {
        public CSharpLiteralBuilder()
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

        protected override void AppendNewLine()
        {
            Append(' ');
            Append('+');
            Append(' ');

            switch (Settings.NewLineLiteral)
            {
                case NewLineMode.Linefeed:
                    Append("'\\n'");
                    break;
                case NewLineMode.CarriageReturnLinefeed:
                    Append("\"\\r\\n\"");
                    break;
                case NewLineMode.Environment:
                    Append("Environment.NewLine");
                    break;
            }

            if (Settings.ConcatAtBeginningOfLine)
            {
                Append('\n');
                Append('+');
                Append(' ');
            }
            else
            {
                Append(' ');
                Append('+');
                Append('\n');
            }
        }

        protected override void AppendLineStart()
        {
            if (Settings.Verbatim)
            {
                Append('@');
            }

            base.AppendLineStart();
        }

        protected override bool MultilineEnabled
        {
            get { return true; }
        }
    }
}
