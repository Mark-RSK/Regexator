// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal class CharCodeGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<int> _charCodes;
        private readonly int _charCode;

        public CharCodeGroup(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }
            _charCode = charCode;
        }

        public CharCodeGroup(IEnumerable<int> charCodes)
        {
            if (charCodes == null)
            {
                throw new ArgumentNullException("charCodes");
            }
            _charCodes = charCodes;
        }

        public override string Content
        {
            get
            {
                if (_charCodes != null)
                {
                    return Syntax.Char(_charCodes, true);
                }
                else
                {
                    return Syntax.CharInternal(_charCode, true);
                }
            }
        }
    }
}
