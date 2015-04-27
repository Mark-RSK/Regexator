// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal abstract class AlternationExpression
        : QuantifiableExpression
    {
        private readonly Expression _yes;
        private readonly Expression _no;

        protected AlternationExpression(string yes, string no)
            : this(Create(yes), Create(no))
        {
        }

        protected AlternationExpression(Expression yes, Expression no)
            : base()
        {
            if (yes == null) { throw new ArgumentNullException("yes"); }
            _yes = yes;
            _no = no;
        }

        protected abstract IEnumerable<string> EnumerateCondition(BuildContext context);

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            foreach (var value in EnumerateCondition(context))
            {
                yield return Value;
            }
            foreach (var value in YesExpression.EnumerateValues(context))
            {
                yield return value;
            }
            if (NoExpression != null)
            {
                yield return Syntax.Or;
                foreach (var value in NoExpression.EnumerateValues(context))
                {
                    yield return value;
                }
            }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.IfStart;
        }

        internal override string Closing
        {
            get { return Syntax.GroupEnd; }
        }

        public Expression YesExpression
        {
            get { return _yes; }
        }

        public Expression NoExpression
        {
            get { return _no; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.If; }
        }
    }
}
