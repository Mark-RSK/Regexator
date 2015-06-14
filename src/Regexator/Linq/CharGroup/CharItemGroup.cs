// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharItemGroup
        : CharGroupExpression
    {
        private readonly CharGroupItem _item;
        private readonly bool _negative;

        public CharItemGroup(CharGroupItem item)
            : this(item, false)
        {
        }

        public CharItemGroup(CharGroupItem item, bool negative)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _item = item;
            _negative = negative;
        }

        internal override void BuildContent(PatternWriter writer)
        {
            _item.BuildContent(writer);
        }

        public override bool Negative
        {
            get { return _negative; }
        }
    }
}
