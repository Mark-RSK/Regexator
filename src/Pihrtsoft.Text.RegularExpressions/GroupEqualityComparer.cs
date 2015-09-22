// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class GroupEqualityComparer
        : EqualityComparer<Group>
    {
        private static readonly CaptureEqualityComparer _comparer = new CaptureEqualityComparer();

        public override bool Equals(Group x, Group y)
        {
            if (object.ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            IEnumerator e1 = x.Captures.GetEnumerator();
            IEnumerator e2 = y.Captures.GetEnumerator();

            while (e1.MoveNext())
            {
                if (!(e2.MoveNext() && _comparer.Equals((Capture)e1.Current, (Capture)e2.Current)))
                    return false;
            }

            if (e2.MoveNext())
                return false;

            return true;
        }

        public override int GetHashCode(Group obj)
        {
            int hashCode = 0;
            if (obj != null)
            {
                foreach (Capture capture in obj.Captures)
                    hashCode ^= _comparer.GetHashCode(capture);
            }

            return hashCode;
        }
    }
}