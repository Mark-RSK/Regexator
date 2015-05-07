// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Regexator
{
    public class MatchItemEqualityComparer
        : EqualityComparer<MatchItem>
    {
        private static readonly GroupItemEqualityComparer _groupItemEqualityComparer = new GroupItemEqualityComparer();

        public override bool Equals(MatchItem x, MatchItem y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return x.GroupItems.SequenceEqual(y.GroupItems, _groupItemEqualityComparer);
        }

        public override int GetHashCode(MatchItem obj)
        {
            int hashCode = 0;
            if (obj != null)
            {
                foreach (var groupItem in obj.GroupItems)
                {
                    hashCode ^= groupItem.GetHashCode();
                }
            }
            return hashCode;
        }
    }
}
