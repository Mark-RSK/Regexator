// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class AnyTextExpression
        : AnyExpression
    {
        private readonly string[] _values;

        internal AnyTextExpression(params string[] values)
            : base()
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            if (values.Length == 0) { throw new ArgumentException(); }
            _values = values;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            bool isFirst = true;
            foreach (var value in _values)
            {
                if (!isFirst)
                {
                    yield return Syntax.Or;
                }
                else
                {
                    isFirst = false;
                }
                yield return Utilities.Escape(value);
            }
        }
    }
}
