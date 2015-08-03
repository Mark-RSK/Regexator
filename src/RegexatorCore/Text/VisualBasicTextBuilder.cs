// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    internal sealed class VisualBasicTextBuilder
        : TextBuilder
    {
        public VisualBasicTextBuilder()
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

        protected override void AppendNewLine()
        {
            Append(' ');
            Append(Settings.ConcatOperator);
            Append(' ');

            switch (Settings.NewLineLiteral)
            {
                case NewLineLiteral.Linefeed:
                    Append("vbLf");
                    break;
                case NewLineLiteral.CarriageReturnLinefeed:
                    Append("vbCrLf");
                    break;
                case NewLineLiteral.Environment:
                    Append("Environment.NewLine");
                    break;
            }

            if (Settings.ConcatAtBeginningOfLine)
            {
                Append(" _");
                Append('\n');
                Append(Settings.ConcatOperator);
                Append(' ');
            }
            else
            {
                Append(' ');
                Append(Settings.ConcatOperator);
                Append('\n');
            }
        }
    }
}
