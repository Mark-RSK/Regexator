// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class AnyTextExpression
        : AnyExpression
    {
        private readonly IEnumerable<string> _values;

        internal AnyTextExpression(IEnumerable<string> values)
            : base()
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            _values = values;
        }

        internal AnyTextExpression(params string[] values)
            : base()
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
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
                yield return RegexUtilities.Escape(value);
            }
        }
    }
}
