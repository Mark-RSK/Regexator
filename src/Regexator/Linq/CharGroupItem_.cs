// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharGroupItem
    {
        internal sealed class CharacterItem
            : CharGroupItem
        {
            private readonly char _value;

            public CharacterItem(char value)
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

        internal sealed class CharCodeCharItem
            : CharGroupItem
        {
            private readonly int _charCode;

            public CharCodeCharItem(int charCode)
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

        internal sealed class AsciiCharItem
            : CharGroupItem
        {
            private readonly AsciiChar _value;

            public AsciiCharItem(AsciiChar value)
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

        internal sealed class CharactersItem
            : CharGroupItem
        {
            private readonly string _characters;

            public CharactersItem(string characters)
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

        internal sealed class RangeCharItem
            : CharGroupItem
        {
            private readonly char _firstChar;
            private readonly char _lastChar;

            public RangeCharItem(char firstChar, char lastChar)
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

        internal sealed class CodeRangeCharItem
            : CharGroupItem
        {
            private readonly int _first;
            private readonly int _last;

            public CodeRangeCharItem(int firstCharCode, int lastCharCode)
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

        internal sealed class CharClassCharItem
            : CharGroupItem
        {
            private readonly CharClass _value;

            public CharClassCharItem(CharClass value)
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

        internal class GeneralCategoryCharItem
            : CharGroupItem
        {
            private readonly GeneralCategory _category;
            private readonly bool _negative;

            public GeneralCategoryCharItem(GeneralCategory category, bool negative)
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

        internal class NamedBlockCharItem
            : CharGroupItem
        {
            private readonly NamedBlock _block;
            private readonly bool _negative;

            public NamedBlockCharItem(NamedBlock block, bool negative)
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
