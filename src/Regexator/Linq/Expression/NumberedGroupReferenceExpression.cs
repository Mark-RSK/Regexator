// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NumberedGroupReferenceExpression
        : QuantifiableExpression
    {
        private readonly int _groupNumber;

        internal NumberedGroupReferenceExpression(int groupNumber)
            : base()
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            _groupNumber = groupNumber;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteGroupReferenceInternal(GroupNumber);
        }

        public int GroupNumber
        {
            get { return _groupNumber; }
        }
    }
}
