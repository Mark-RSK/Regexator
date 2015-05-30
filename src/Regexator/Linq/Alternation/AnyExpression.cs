// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AnyExpression
        : QuantifiableExpression
    {
        private readonly AnyGroupMode _groupMode;
        private readonly IEnumerable<object> _values;

        internal AnyExpression(IEnumerable<object> values)
            : this(AnyGroupMode.Noncapturing, values)
        {
        }

        internal AnyExpression(AnyGroupMode groupMode, IEnumerable<object> values)
            : base()
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            _groupMode = groupMode;
            _values = values;
        }

        internal AnyExpression(params object[] expressions)
            : this(AnyGroupMode.Noncapturing, expressions)
        {
        }

        internal AnyExpression(AnyGroupMode groupMode, params object[] values)
            : base()
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            _groupMode = groupMode;
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

                foreach (var value2 in Expression.EnumerateValues(value, context))
                {
                    yield return value2;
                }
            }
        }

        internal override string Opening(BuildContext context)
        {
            switch (GroupMode)
            {
                case AnyGroupMode.None:
                    return string.Empty;
                case AnyGroupMode.Capturing:
                    return Syntax.CapturingGroupStart;
                case AnyGroupMode.Noncapturing:
                    return Syntax.NoncapturingGroupStart;
            }

            return string.Empty;
        }

        internal override string Closing(BuildContext context)
        {
            return (GroupMode == AnyGroupMode.None)
                ? string.Empty
                : Syntax.GroupEnd;
        }

        internal AnyGroupMode GroupMode
        {
            get { return _groupMode; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Any; }
        }
    }
}
