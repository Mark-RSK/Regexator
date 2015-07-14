﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharSurroundPattern
        : Pattern
    {
        private readonly object _content;
        private readonly AsciiChar _charBefore;
        private readonly AsciiChar _charAfter;

        public AsciiCharSurroundPattern(AsciiChar charBefore, object content, AsciiChar charAfter)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _charBefore = charBefore;
            _content = content;
            _charAfter = charAfter;
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.Append(_charBefore);

            if (_content is IEnumerable)
            {
                builder.AppendAny(_content, GroupMode.NoncapturingGroup);
            }
            else
            {
                builder.Append(_content);
            }

            builder.Append(_charAfter);
        }
    }
}
