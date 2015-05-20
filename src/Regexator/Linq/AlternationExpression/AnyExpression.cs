// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal class AnyExpression
        : QuantifiableExpression
    {
        private readonly AnyGroupMode _groupMode;
        private readonly IEnumerable<Expression> _expressions;

        protected AnyExpression()
            : this(AnyGroupMode.Noncapturing)
        {
        }

        protected AnyExpression(AnyGroupMode groupMode)
        {
            _groupMode = groupMode;
        }

        internal AnyExpression(IEnumerable<Expression> expressions)
            : this(AnyGroupMode.Noncapturing, expressions)
        {
        }

        internal AnyExpression(AnyGroupMode groupMode, IEnumerable<Expression> expressions)
            : base()
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }
            _groupMode = groupMode;
            _expressions = expressions;
        }

        internal AnyExpression(params Expression[] expressions)
            : this(AnyGroupMode.Noncapturing, expressions)
        {
        }

        internal AnyExpression(AnyGroupMode groupMode, params Expression[] expressions)
            : base()
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }
            _groupMode = groupMode;
            _expressions = expressions;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            bool isFirst = true;
            foreach (var expression in _expressions)
            {
                if (!isFirst)
                {
                    yield return Syntax.Or;
                }
                else
                {
                    isFirst = false;
                }
                foreach (var value in expression.EnumerateValues(context))
                {
                    yield return value;
                }
            }
        }

        internal override string Opening(BuildContext context)
        {
            switch (GroupMode)
            {
                case AnyGroupMode.None:
                    return string.Empty;
                case AnyGroupMode.Subexpression:
                    return Syntax.SubexpressionStart;
                case AnyGroupMode.Noncapturing:
                    return Syntax.NoncapturingGroupStart;
            }
            return string.Empty;
        }

        internal override string Closing(BuildContext context)
        {
            return (GroupMode == AnyGroupMode.None) ? string.Empty : Syntax.GroupEnd;
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
