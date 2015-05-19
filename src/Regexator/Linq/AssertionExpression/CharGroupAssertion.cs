// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class CharGroupAssertion
        : AssertionExpression
    {
        private readonly CharGroupItem _item;

        internal CharGroupAssertion(AssertionKind kind, CharGroupItem item)
            : base(kind)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _item = item;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.CharGroup(_item.Value);
        }
    }
}