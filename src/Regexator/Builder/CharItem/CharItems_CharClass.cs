// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class CharItems
    {
        public static CharItem Digit()
        {
            return CharItem.Create(CharClass.Digit);
        }

        public static CharItem NotDigit()
        {
            return CharItem.Create(CharClass.NotDigit);
        }

        public static CharItem WhiteSpace()
        {
            return CharItem.Create(CharClass.WhiteSpace);
        }

        public static CharItem NotWhiteSpace()
        {
            return CharItem.Create(CharClass.NotWhiteSpace);
        }

        public static CharItem Word()
        {
            return CharItem.Create(CharClass.Word);
        }

        public static CharItem NotWord()
        {
            return CharItem.Create(CharClass.NotWord);
        }
    }
}
