// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class OrContainerExpression
        : GroupExpression
    {
        internal OrContainerExpression(object left, object right)
            : base(Combine(left, right))
        {
        }

        private static object Combine(object left, object right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            OrContainerExpression l = left as OrContainerExpression;
            OrContainerExpression r = right as OrContainerExpression;

            if (l != null)
            {
                if (r != null)
                {
                    var la = l.Content as object[];
                    var ra = r.Content as object[];

                    object[] arr = new object[la.Length + ra.Length];

                    Array.Copy(la, arr, la.Length);
                    Array.Copy(ra, 0, arr,  la.Length, ra.Length);

                    return arr;
                }
                else
                {
                    var la = l.Content as object[];

                    object[] arr = new object[la.Length + 1];

                    Array.Copy(la, arr, la.Length);
                    arr[la.Length] = right;

                    return arr;
                }
         
            }
            else if (r != null)
            {
                var ra = l.Content as object[];

                object[] arr = new object[ra.Length + 1];

                arr[0] = right;
                Array.Copy(ra, 0, arr, 1, ra.Length);

                return arr;
            }

            return new object[] { left, right };
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.NoncapturingGroupStart;
        }
    }
}
