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

            var l = left as OrContainerExpression;
            var r = right as OrContainerExpression;

            if (l != null)
            {
                if (r != null)
                {
                    return Combine(l.Content as object[], r.Content as object[]);
                }
                else
                {
                    return Combine(l.Content as object[], right);
                }
            }
            else if (r != null)
            {
                return Combine(left, r.Content as object[]);
            }
            else
            {
                return new object[] { left, right };
            }
        }

        private static object[] Combine(object[] left, object[] right)
        {
            object[] result = new object[left.Length + right.Length];

            Array.Copy(left, result, left.Length);
            Array.Copy(right, 0, result,  left.Length, right.Length);

            return result;
        }

        private static object[] Combine(object[] left, object right)
        {
            object[] result = new object[left.Length + 1];

            Array.Copy(left, result, left.Length);

            result[left.Length] = right;

            return result;
        }

        private static object[] Combine(object left, object[] right)
        {
            object[] result = new object[right.Length + 1];

            result[0] = left;

            Array.Copy(right, 0, result, 1, right.Length);

            return result;
        }

        internal override void BuildOpening(PatternWriter writer)
        {
            writer.Write(Syntax.NoncapturingGroupStart);
        }
    }
}
