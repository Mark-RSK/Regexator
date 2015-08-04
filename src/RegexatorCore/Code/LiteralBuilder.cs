// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text;

namespace Pihrtsoft.Text.RegularExpressions
{
    internal abstract class LiteralBuilder
    {
        private StringBuilder _sb;
        private readonly LiteralBuilderSettings _settings;

        protected abstract void AppendNewLine();

        protected LiteralBuilder()
        {
        }

        public string GetText(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException("code");
            }

            _sb = new StringBuilder(code.Length);
            AppendLineStart();

            bool isNewLine = false;

            for (int i = 0; i < code.Length; i++)
            {
                char ch = code[i];

                if (ch == '\n')
                {
                    isNewLine = true;
                }
                else
                {
                    if (isNewLine)
                    {
                        if (MultilineEnabled && Settings.Multiline)
                        {
                            _sb.Append('\n');
                        }
                        else
                        {
                            AppendLineEnd();
                            AppendNewLine();
                            AppendLineStart();
                        }

                        isNewLine = false;
                    }

                    AppendChar(ch);
                }
            }

            AppendLineEnd();
            return _sb.ToString();
        }

        protected virtual void AppendChar(char value)
        {
            _sb.Append(value);
        }

        protected void Append(char value)
        {
            _sb.Append(value);
        }

        protected void Append(string value)
        {
            _sb.Append(value);
        }

        protected virtual void AppendLineStart()
        {
            _sb.Append('"');
        }

        protected virtual void AppendLineEnd()
        {
            _sb.Append('"');
        }

        protected virtual bool MultilineEnabled
        {
            get { return false; }
        }

        public LiteralBuilderSettings Settings
        {
            get { return _settings; }
        }
    }
}
