// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public sealed partial class CharItem
    {
        public CharItem Digit()
        {
            return Append(Create(CharClass.Digit));
        }

        public CharItem NotDigit()
        {
            return Append(Create(CharClass.NotDigit));
        }

        public CharItem WhiteSpace()
        {
            return Append(Create(CharClass.WhiteSpace));
        }

        public CharItem NotWhiteSpace()
        {
            return Append(Create(CharClass.NotWhiteSpace));
        }

        public CharItem Word()
        {
            return Append(Create(CharClass.Word));
        }

        public CharItem NotWord()
        {
            return Append(Create(CharClass.NotWord));
        }
    }
}
