// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal class AnyExpression
        : QuantifiableExpression
    {
        private readonly bool _noncapturing;
        private readonly IEnumerable<Expression> _expressions;

        protected AnyExpression()
            : this(true)
        {
        }

        protected AnyExpression(bool noncapturing)
        {
            _noncapturing = noncapturing;
        }

        internal AnyExpression(IEnumerable<Expression> expressions)
            : this(true, expressions)
        {
        }

        internal AnyExpression(bool noncapturing, IEnumerable<Expression> expressions)
            : base()
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }
            _noncapturing = noncapturing;
            _expressions = expressions;
        }

        internal AnyExpression(params Expression[] expressions)
            : this(true, expressions)
        {
        }

        internal AnyExpression(bool noncapturing, params Expression[] expressions)
            : base()
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }
            _noncapturing = noncapturing;
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
            return IsNoncapturing ? Syntax.NoncapturingGroupStart : Syntax.SubexpressionStart;
        }

        internal override string Closing(BuildContext context)
        {
            return Syntax.GroupEnd;
        }

        internal bool IsNoncapturing
        {
            get { return _noncapturing; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Any; }
        }
    }
}
