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

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.Append(_value);
            }

            protected override void AppendGroupContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_value, true);
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

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendInternal(_charCode);
            }

            protected override void AppendGroupContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendInternal(_charCode, true);
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

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.Append(_value);
            }

            protected override void AppendGroupContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_value, true);
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

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendGeneralCategory(_category, _negative);
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

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendNamedBlock(_block, _negative);
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

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharClass(_value);
            }
        }
    }
}
