// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharGroup
    {
        internal sealed class CharCharGroup
            : CharGroup
        {
            private readonly char _value;
            private readonly bool _negative;

            public CharCharGroup(char value, bool negative)
            {
                _value = value;
                _negative = negative;
            }

            internal override void AppendContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_value, true);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_value, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class AsciiCharCharGroup
            : CharGroup
        {
            private readonly AsciiChar _value;
            private readonly bool _negative;

            public AsciiCharCharGroup(AsciiChar value, bool negative)
            {
                _value = value;
                _negative = negative;
            }

            internal override void AppendContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_value, true);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_value, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class CharCodeCharGroup
            : CharGroup
        {
            private readonly int _charCode;
            private readonly bool _negative;

            public CharCodeCharGroup(int charCode, bool negative)
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

            internal override void AppendContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendInternal(_charCode, true);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_charCode, Negative);
            }
        }

        internal sealed class CharactersCharGroup
            : CharGroup
        {
            private readonly string _characters;
            private readonly bool _negative;

            public CharactersCharGroup(string characters, bool negative)
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

            internal override void AppendContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.Append(_characters, true);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_characters, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class CharRangeCharGroup
            : CharGroup
        {
            private readonly char _firstChar;
            private readonly char _lastChar;
            private readonly bool _negative;

            public CharRangeCharGroup(char firstChar, char lastChar, bool negative)
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

            internal override void AppendContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendCharRange(_firstChar, _lastChar);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_firstChar, _lastChar, Negative);
            }
        }

        internal sealed class CharCodeRangeCharGroup
            : CharGroup
        {
            private readonly int _first;
            private readonly int _last;
            private readonly bool _negative;

            public CharCodeRangeCharGroup(int firstCharCode, int lastCharCode, bool negative)
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

            internal override void AppendContentTo(PatternBuilder builder)
            {
                if (builder == null)
                {
                    throw new ArgumentNullException("builder");
                }

                builder.AppendCharRange(_first, _last);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_first, _last, Negative);
            }
        }

        internal sealed class GeneralCategoryCharGroup
            : CharGroup
        {
            private readonly GeneralCategory _category;
            private readonly bool _negative;

            public GeneralCategoryCharGroup(GeneralCategory category, bool negative)
            {
                _category = category;
                _negative = negative;
            }

            internal override void AppendContentTo(PatternBuilder builder)
            {
                builder.AppendGeneralCategory(_category, Negative);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_category, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class NamedBlockCharGroup
            : CharGroup
        {
            private readonly NamedBlock _block;
            private readonly bool _negative;

            public NamedBlockCharGroup(NamedBlock block, bool negative)
            {
                _block = block;
                _negative = negative;
            }

            internal override void AppendContentTo(PatternBuilder builder)
            {
                builder.AppendNamedBlock(_block, Negative);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_block, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class CharClassCharGroup
            : CharGroup
        {
            private readonly CharClass _value;

            public CharClassCharGroup(CharClass value)
            {
                _value = value;
            }

            internal override void AppendContentTo(PatternBuilder builder)
            {
                builder.AppendCharClass(_value);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_value);
            }
        }

        internal sealed class CharGroupingCharGroup
            : CharGroup
        {
            private readonly CharGrouping _item;
            private readonly bool _negative;

            public CharGroupingCharGroup(CharGrouping value, bool negative)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                _item = value;
                _negative = negative;
            }

            internal override void AppendContentTo(PatternBuilder builder)
            {
                _item.AppendContentTo(builder);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroup(_item, Negative);
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }

        internal sealed class CharGroupCharGroup
            : CharGroup
        {
            private readonly CharGroup _group;
            private readonly bool _negative;

            internal CharGroupCharGroup(CharGroup group, bool negative)
            {
                if (group == null)
                {
                    throw new ArgumentNullException("group");
                }

                _group = group;
                _negative = negative;
            }

            internal override void AppendContentTo(PatternBuilder builder)
            {
                _group.AppendContentTo(builder);
            }

            internal override void AppendTo(PatternBuilder builder)
            {
                builder.AppendCharGroupStart(Negative);
                _group.AppendContentTo(builder);
                builder.AppendCharGroupEnd();
            }

            public override bool Negative
            {
                get { return _negative; }
            }
        }
    }
}
