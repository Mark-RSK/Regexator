// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharacterPattern
    {
        internal sealed class CharCharacterPattern
            : CharacterPattern
        {
            private readonly char _value;

            internal CharCharacterPattern(char value)
            {
                _value = value;
            }

            public override CharacterGroup Invert()
            {
                return CharacterGroup.Create(_value, true);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.Write(_value);
            }

            protected override void WriteGroupContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_value, true);
            }
        }

        internal sealed class CharCodeCharacterPattern
            : CharacterPattern
        {
            private readonly int _charCode;

            internal CharCodeCharacterPattern(int charCode)
            {
                if (charCode < 0 || charCode > 0xFFFF)
                {
                    throw new ArgumentOutOfRangeException("charCode");
                }

                _charCode = charCode;
            }

            public override CharacterGroup Invert()
            {
                return CharacterGroup.Create(_charCode, true);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteInternal(_charCode);
            }

            protected override void WriteGroupContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteInternal(_charCode, true);
            }
        }

        internal sealed class AsciiCharCharacterPattern
            : CharacterPattern
        {
            private readonly AsciiChar _value;

            internal AsciiCharCharacterPattern(AsciiChar value)
            {
                _value = value;
            }

            public override CharacterGroup Invert()
            {
                return CharacterGroup.Create(_value, true);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.Write(_value);
            }

            protected override void WriteGroupContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_value, true);
            }
        }

        internal class GeneralCategoryCharacterPattern
            : CharacterPattern
        {
            private readonly GeneralCategory _category;
            private readonly bool _negative;

            internal GeneralCategoryCharacterPattern(GeneralCategory category, bool negative)
            {
                _category = category;
                _negative = negative;
            }

            public override CharacterGroup Invert()
            {
                return CharacterGroup.Create(_category, !_negative);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteGeneralCategory(_category, _negative);
            }

            public GeneralCategory Category
            {
                get { return _category; }
            }
        }

        internal class NamedBlockCharacterPattern
            : CharacterPattern
        {
            private readonly NamedBlock _block;
            private readonly bool _negative;

            internal NamedBlockCharacterPattern(NamedBlock block, bool negative)
            {
                _block = block;
                _negative = negative;
            }

            public override CharacterGroup Invert()
            {
                return CharacterGroup.Create(_block, !_negative);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteNamedBlock(_block, _negative);
            }

            public NamedBlock Block
            {
                get { return _block; }
            }
        }

        internal sealed class CharClassCharacterPattern
            : CharacterPattern
        {
            private readonly CharClass _value;

            public CharClassCharacterPattern(CharClass value)
            {
                _value = value;
            }

            public override CharacterGroup Invert()
            {
                switch (_value)
                {
                    case CharClass.Digit:
                        return CharacterGroup.Create(CharClass.NotDigit);
                    case CharClass.WordChar:
                        return CharacterGroup.Create(CharClass.NotWordChar);
                    case CharClass.WhiteSpace:
                        return CharacterGroup.Create(CharClass.NotWhiteSpace);
                    case CharClass.NotDigit:
                        return CharacterGroup.Create(CharClass.Digit);
                    case CharClass.NotWordChar:
                        return CharacterGroup.Create(CharClass.WordChar);
                    case CharClass.NotWhiteSpace:
                        return CharacterGroup.Create(CharClass.WhiteSpace);
                }

                return null;
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharClass(_value);
            }
        }
    }
}
