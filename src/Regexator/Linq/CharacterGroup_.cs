// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharacterGroup
    {
        internal sealed class LiteralCharacterGroup
            : CharacterGroup
        {
            private readonly char _value;
            private readonly bool _negative;

            public LiteralCharacterGroup(char value, bool negative)
            {
                _value = value;
                _negative = negative;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_value, true);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_value, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class AsciiCharGroup
            : CharacterGroup
        {
            private readonly AsciiChar _value;
            private readonly bool _negative;

            public AsciiCharGroup(AsciiChar value, bool negative)
            {
                _value = value;
                _negative = negative;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_value, true);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_value, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class CharCodeGroup
            : CharacterGroup
        {
            private readonly int _charCode;
            private readonly bool _negative;

            public CharCodeGroup(int charCode, bool negative)
            {
                if (charCode < 0 || charCode > 0xFFFF)
                {
                    throw new ArgumentOutOfRangeException("charCode");
                }

                _charCode = charCode;
                _negative = negative;
            }

            public override bool Negative
            {
                get { return _negative; }
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteInternal(_charCode, true);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_charCode, Negative);
            }
        }

        internal sealed class LiteralCharactersGroup
            : CharacterGroup
        {
            private readonly string _characters;
            private readonly bool _negative;

            public LiteralCharactersGroup(string characters)
                : this(characters, false)
            {
            }

            public LiteralCharactersGroup(string characters, bool negative)
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
                _negative = negative;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.Write(_characters, true);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_characters, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class CharRangeGroup
            : CharacterGroup
        {
            private readonly char _firstChar;
            private readonly char _lastChar;
            private readonly bool _negative;

            public CharRangeGroup(char firstChar, char lastChar, bool negative)
            {
                if (lastChar < firstChar)
                {
                    throw new ArgumentOutOfRangeException("lastChar");
                }

                _firstChar = firstChar;
                _lastChar = lastChar;
                _negative = negative;
            }

            public override bool Negative
            {
                get { return _negative; }
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteCharRange(_firstChar, _lastChar);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_firstChar, _lastChar, Negative);
            }
        }

        internal sealed class CharCodeRangeGroup
            : CharacterGroup
        {
            private readonly int _first;
            private readonly int _last;
            private readonly bool _negative;

            public CharCodeRangeGroup(int firstCharCode, int lastCharCode, bool negative)
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
                _negative = negative;
            }

            public override bool Negative
            {
                get { return _negative; }
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteCharRange(_first, _last);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_first, _last, Negative);
            }
        }

        internal sealed class GeneralCategoryCharGroup
            : CharacterGroup
        {
            private readonly GeneralCategory _category;
            private readonly bool _negative;

            public GeneralCategoryCharGroup(GeneralCategory category, bool negative)
            {
                _category = category;
                _negative = negative;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                writer.WriteGeneralCategory(_category, Negative);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_category, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class NamedBlockCharGroup
            : CharacterGroup
        {
            private readonly NamedBlock _block;
            private readonly bool _negative;

            public NamedBlockCharGroup(NamedBlock block, bool negative)
            {
                _block = block;
                _negative = negative;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                writer.WriteNamedBlock(_block, Negative);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_block, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class CharClassCharGroup
            : CharacterGroup
        {
            private readonly CharClass _value;

            public CharClassCharGroup(CharClass value)
            {
                _value = value;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                writer.WriteCharClass(_value);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_value);
            }
        }

        internal sealed class CharGroupItemGroup
            : CharacterGroup
        {
            private readonly CharGrouping _item;
            private readonly bool _negative;

            public CharGroupItemGroup(CharGrouping item)
                : this(item, false)
            {
            }

            public CharGroupItemGroup(CharGrouping item, bool negative)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }

                _item = item;
                _negative = negative;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                _item.WriteContentTo(writer);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroup(_item, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class GroupCharGroup
            : CharacterGroup
        {
            private readonly CharacterGroup _group;
            private readonly bool _negative;

            internal GroupCharGroup(CharacterGroup group, bool negative)
            {
                if (group == null)
                {
                    throw new ArgumentNullException("group");
                }

                _group = group;
                _negative = negative;
            }

            internal override void WriteContentTo(PatternWriter writer)
            {
                _group.WriteContentTo(writer);
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteCharGroupStart(Negative);
                _group.WriteContentTo(writer);
                writer.WriteCharGroupEnd();
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }
    }
}
