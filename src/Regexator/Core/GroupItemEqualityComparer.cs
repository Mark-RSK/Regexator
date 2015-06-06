// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class GroupItemEqualityComparer
        : EqualityComparer<GroupItem>
    {
        private static readonly CaptureItemEqualityComparer _captureItemEqualityComparer = new CaptureItemEqualityComparer();

        public override bool Equals(GroupItem x, GroupItem y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.CaptureItems.SequenceEqual(y.CaptureItems, _captureItemEqualityComparer);
        }

        public override int GetHashCode(GroupItem obj)
        {
            int hashCode = 0;
            if (obj != null)
            {
                foreach (var captureItem in obj.CaptureItems)
                {
                    hashCode ^= captureItem.GetHashCode();
                }
            }

            return hashCode;
        }
    }
}
