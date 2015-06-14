// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal abstract class AlternationExpression
        : QuantifiableExpression
    {
        private readonly object _trueContent;
        private readonly object _falseContent;

        protected AlternationExpression(object trueContent, object falseContent)
            : base()
        {
            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            _trueContent = trueContent;
            _falseContent = falseContent;
        }

        protected abstract void BuildCondition(PatternWriter writer);

        internal override void BuildContent(PatternWriter writer)
        {
            BuildCondition(writer);

            writer.WriteContent(_trueContent);

            if (_falseContent != null)
            {
                writer.WriteOr();

                writer.WriteContent(_falseContent);
            }
        }

        internal override void BuildOpening(PatternWriter writer)
        {
            writer.WriteIfStart();
        }

        internal override void BuildClosing(PatternWriter writer)
        {
            writer.WriteGroupEnd();
        }
    }
}
