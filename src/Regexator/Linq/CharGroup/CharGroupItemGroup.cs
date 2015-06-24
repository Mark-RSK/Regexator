// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharGroupItemGroup
        : CharGroup
    {
        private readonly CharGroupItem _item;
        private readonly bool _negative;

        public CharGroupItemGroup(CharGroupItem item)
            : this(item, false)
        {
        }

        public CharGroupItemGroup(CharGroupItem item, bool negative)
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
}
