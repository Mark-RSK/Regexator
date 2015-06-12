// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class IfExpression
        : AlternationExpression
    {
        private readonly object _condition;

        internal IfExpression(object testContent, object trueContent)
            : this(testContent, trueContent, null)
        {
        }

        internal IfExpression(object testContent, object trueContent, object falseContent)
            : base(trueContent, falseContent)
        {
            if (testContent == null)
            {
                throw new ArgumentNullException("testContent");
            }

            _condition = testContent;
        }

        protected override void BuildCondition(PatternContext context)
        {
            if (_condition != null)
            {
                context.Write(context.Settings.ConditionWithAssertion 
                    ? Syntax.AssertStart 
                    : Syntax.CapturingGroupStart);

                Expression.BuildContent(_condition, context);

                context.Write(Syntax.GroupEnd);
            }
        }
    }
}
