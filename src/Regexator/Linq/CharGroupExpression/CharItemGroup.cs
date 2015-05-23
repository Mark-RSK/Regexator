// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class CharItemGroup
        : CharGroupExpression
    {
        private readonly CharGroupItem _item;

        public CharItemGroup(CharGroupItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _item = item;
        }

        public override string Content
        {
            get { return _item.Value; }
        }
    }
}
