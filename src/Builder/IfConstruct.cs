// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class IfConstruct
        : QuantifiableExpression
    {
        private readonly string _opening;
        private readonly Expression _condition;
        private readonly Expression _yes;
        private readonly Expression _no;

        internal IfConstruct(string opening, string yes)
            : this(opening, Create(yes))
        {
        }

        internal IfConstruct(string opening, string yes, string no)
            : this(opening, Create(yes), Create(no))
        {
        }

        internal IfConstruct(string opening, Expression yes)
            : this(opening, yes, null)
        {
        }

        internal IfConstruct(string opening, Expression yes, Expression no)
            : base()
        {
            if (yes == null) { throw new ArgumentNullException("yes"); }
            _opening = opening;
            _yes = yes;
            _no = no;
        }

        internal IfConstruct(Expression condition, string yes)
            : this(condition, Create(yes))
        {
        }

        internal IfConstruct(Expression condition, string yes, string no)
            : this(condition, Create(yes), Create(no))
        {
        }

        internal IfConstruct(Expression condition, Expression yes)
            : this(condition, yes, null)
        {
        }

        internal IfConstruct(Expression condition, Expression yes, Expression no)
            : base()
        {
            if (condition == null) { throw new ArgumentNullException("condition"); }
            if (yes == null) { throw new ArgumentNullException("yes"); }
            _opening = Syntax.IfStart;
            _condition = condition;
            _yes = yes;
            _no = no;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            if (_condition != null)
            {
                yield return context.Settings.ConditionWithAssertion ? Syntax.LookaheadStart : Syntax.SubexpressionStart;
                foreach (var value in _condition.EnumerateValues(context))
                {
                    yield return value;
                }
                yield return Syntax.GroupEnd;
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
            return _opening;
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
