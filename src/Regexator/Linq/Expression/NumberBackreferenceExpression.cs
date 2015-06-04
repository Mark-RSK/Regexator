// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NumberBackreferenceExpression
        : QuantifiableExpression
    {
        private readonly int _groupNumber;

        internal NumberBackreferenceExpression(int groupNumber)
            : base()
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            _groupNumber = groupNumber;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            yield return Syntax.Backreference(GroupNumber);

            if (context.Settings.SeparatorAfterNumberBackreference)
            {
                yield return Syntax.NoncapturingGroup(string.Empty);
            }
        }

        public int GroupNumber
        {
            get { return _groupNumber; }
        }
    }
}
