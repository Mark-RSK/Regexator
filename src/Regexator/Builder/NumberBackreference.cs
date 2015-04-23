// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NumberBackreference
        : QuantifiableExpression
    {
        private readonly int _groupNumber;

        internal NumberBackreference(int groupNumber)
            : base()
        {
            if (groupNumber < 0) { throw new ArgumentOutOfRangeException("groupNumber"); }
            _groupNumber = groupNumber;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            if (context.Settings.SeparatorAfterNumberBackreference)
            {
                yield return Syntax.Backreference(GroupNumber) + Expressions.InsignificantSeparator();		        
            }
            {
                yield return Syntax.Backreference(GroupNumber);
            }
        }

        public int GroupNumber
        {
            get { return _groupNumber; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Backreference; }
        }
    }
}
