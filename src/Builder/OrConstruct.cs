// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class OrConstruct
        : QuantifiableExpression
    {
        private readonly Collection<Expression> _expressions;

        internal OrConstruct(params Expression[] expressions)
            : base()
        {
            if (expressions == null) { throw new ArgumentNullException("expressions"); }
            _expressions = new Collection<Expression>(expressions);
        }

        internal OrConstruct(params string[] values)
            : base()
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _expressions = new Collection<Expression>(values.Select(f => Create(f)).ToArray());
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            bool isFirst = true;
            foreach (var expression in OrExpressions)
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
            return context.Settings.NonbacktrackingAny ? Syntax.NoncapturingGroupStart : Syntax.SubexpressionStart;
        }

        internal override string Closing
        {
            get { return Syntax.GroupEnd; }
        }

        public Collection<Expression> OrExpressions
        {
            get { return _expressions; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Or; }
        }
    }
}
