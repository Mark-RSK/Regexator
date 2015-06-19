// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class AlternationPattern
        : QuantifiablePattern
    {
        private readonly object _trueContent;
        private readonly object _falseContent;

        protected AlternationPattern(object trueContent, object falseContent)
            : base()
        {
            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            _trueContent = trueContent;
            _falseContent = falseContent;
        }

        internal object TrueContent
        {
            get { return _trueContent; }
        }

        internal object FalseContent
        {
            get { return _falseContent; }
        }
    }
}
