// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharGrouping
    {
        internal sealed class Character
            : CharGrouping
        {
            private readonly char _value;

            public Character(char value)
            {
                _value = value;
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_value, true);
            }
        }

        internal sealed class CharacterCode
            : CharGrouping
        {
            private readonly int _charCode;

            public CharacterCode(int charCode)
            {
                if (charCode < 0 || charCode > 0xFFFF)
                {
                    throw new ArgumentOutOfRangeException("charCode");
                }

                _charCode = charCode;
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteInternal(_charCode, true);
            }
        }

        internal sealed class AsciiCharacter
            : CharGrouping
        {
            private readonly AsciiChar _value;

            public AsciiCharacter(AsciiChar value)
            {
                _value = value;
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_value, true);
            }
        }

        internal sealed class Characters
            : CharGrouping
        {
            private readonly string _characters;

            public Characters(string characters)
            {
                if (characters == null)
                {
                    throw new ArgumentNullException("characters");
                }

                if (characters.Length == 0)
                {
                    throw new ArgumentException("Character group cannot be empty.", "characters");
                }

                _characters = characters;
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_characters, true);
            }
        }

        internal sealed class CharacterRange
            : CharGrouping
        {
            private readonly char _firstChar;
            private readonly char _lastChar;

            public CharacterRange(char firstChar, char lastChar)
            {
                if (lastChar < firstChar)
                {
                    throw new ArgumentOutOfRangeException("lastChar");
                }

                _firstChar = firstChar;
                _lastChar = lastChar;
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteCharRange(_firstChar, _lastChar);
            }
        }

        internal sealed class CharacterCodeRange
            : CharGrouping
        {
            private readonly int _first;
            private readonly int _last;

            public CharacterCodeRange(int firstCharCode, int lastCharCode)
            {
                if (firstCharCode < 0 || firstCharCode > 0xFFFF)
                {
                    throw new ArgumentOutOfRangeException("firstCharCode");
                }

                if (lastCharCode < firstCharCode || lastCharCode > 0xFFFF)
                {
                    throw new ArgumentOutOfRangeException("lastCharCode");
                }

                _first = firstCharCode;
                _last = lastCharCode;
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteCharRange(_first, _last);
            }
        }

        internal sealed class CharacterClass
            : CharGrouping
        {
            private readonly CharClass _value;

            public CharacterClass(CharClass value)
            {
                _value = value;
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteCharClass(_value);
            }
        }

        internal class UnicodeGeneralCategory
            : CharGrouping
        {
            private readonly GeneralCategory _category;
            private readonly bool _negative;

            public UnicodeGeneralCategory(GeneralCategory category, bool negative)
            {
                _category = category;
                _negative = negative;
            }

            public virtual bool Negative
            {
                get { return _negative; }
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteGeneralCategory(_category, Negative);
            }
        }

        internal class UnicodeNamedBlock
            : CharGrouping
        {
            private readonly NamedBlock _block;
            private readonly bool _negative;

            public UnicodeNamedBlock(NamedBlock block, bool negative)
            {
                _block = block;
                _negative = negative;
            }

            public virtual bool Negative
            {
                get { return _negative; }
            }

            protected override void WriteItemContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteNamedBlock(_block, Negative);
            }
        }
    }
}
