// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public abstract class CharGroupExpression
        : QuantifiableExpression, IBaseGroup, IExcludedGroup
    {
        protected CharGroupExpression()
        {
        }

        public abstract string Content { get; }

        public string BaseGroupValue
        {
            get { return Content; }
        }

        public string ExcludedGroupValue
        {
            get { return ValueInternal; }
        }

        internal sealed override string Value(BuildContext context)
        {
            return ValueInternal;
        }

        public string ValueInternal
        {
            get { return Syntax.CharGroup(Content, Negative); }
        }

        public virtual bool Negative
        {
            get { return false; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.CharGroup; }
        }
    }
}
