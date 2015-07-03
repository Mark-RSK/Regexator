// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharGrouping
    {
        internal sealed class CharacterCharGrouping
            : CharGrouping
        {
            private readonly char _value;

            public CharacterCharGrouping(char value)
            {
                _value = value;
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_value, true);
            }
        }

        internal sealed class CharacterCodeCharGrouping
            : CharGrouping
        {
            private readonly int _charCode;

            public CharacterCodeCharGrouping(int charCode)
            {
                if (charCode < 0 || charCode > 0xFFFF)
                {
                    throw new ArgumentOutOfRangeException("charCode");
                }

                _charCode = charCode;
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendInternal(_charCode, true);
            }
        }

        internal sealed class AsciiCharacterCharGrouping
            : CharGrouping
        {
            private readonly AsciiChar _value;

            public AsciiCharacterCharGrouping(AsciiChar value)
            {
                _value = value;
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_value, true);
            }
        }

        internal sealed class CharactersCharGrouping
            : CharGrouping
        {
            private readonly string _characters;

            public CharactersCharGrouping(string characters)
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

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_characters, true);
            }
        }

        internal sealed class CharacterRangeCharGrouping
            : CharGrouping
        {
            private readonly char _firstChar;
            private readonly char _lastChar;

            public CharacterRangeCharGrouping(char firstChar, char lastChar)
            {
                if (lastChar < firstChar)
                {
                    throw new ArgumentOutOfRangeException("lastChar");
                }

                _firstChar = firstChar;
                _lastChar = lastChar;
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendCharRange(_firstChar, _lastChar);
            }
        }

        internal sealed class CharacterCodeRangeCharGrouping
            : CharGrouping
        {
            private readonly int _first;
            private readonly int _last;

            public CharacterCodeRangeCharGrouping(int firstCharCode, int lastCharCode)
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

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendCharRange(_first, _last);
            }
        }

        internal sealed class CharacterClassCharGrouping
            : CharGrouping
        {
            private readonly CharClass _value;

            public CharacterClassCharGrouping(CharClass value)
            {
                _value = value;
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendCharClass(_value);
            }
        }

        internal class GeneralCategoryCharGrouping
            : CharGrouping
        {
            private readonly GeneralCategory _category;
            private readonly bool _negative;

            public GeneralCategoryCharGrouping(GeneralCategory category, bool negative)
            {
                _category = category;
                _negative = negative;
            }

            public virtual bool Negative
            {
                get { return _negative; }
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendGeneralCategory(_category, Negative);
            }
        }

        internal class NamedBlockCharGrouping
            : CharGrouping
        {
            private readonly NamedBlock _block;
            private readonly bool _negative;

            public NamedBlockCharGrouping(NamedBlock block, bool negative)
            {
                _block = block;
                _negative = negative;
            }

            public virtual bool Negative
            {
                get { return _negative; }
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendNamedBlock(_block, Negative);
            }
        }

        internal class CharGroupingCharGrouping
            : CharGrouping
        {
            private readonly CharGrouping _value;

            public CharGroupingCharGrouping(CharGrouping value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                _value = value;
            }

            protected override void AppendItemContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                _value.AppendItemContentTo(builder);
            }
        }
    }
}
