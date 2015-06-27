// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
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
