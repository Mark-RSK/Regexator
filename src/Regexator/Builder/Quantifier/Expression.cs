// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public Quantifier Maybe(string value)
        {
            return AppendInternal(Groups.Maybe(value));
        }

        public Quantifier Maybe(Expression value)
        {
            return AppendInternal(Groups.Maybe(value));
        }

        public Quantifier MaybeMany(string value)
        {
            return AppendInternal(Groups.MaybeMany(value));
        }

        public Quantifier MaybeMany(Expression value)
        {
            return AppendInternal(Groups.MaybeMany(value));
        }

        public Quantifier OneMany(string value)
        {
            return AppendInternal(Groups.OneMany(value));
        }

        public Quantifier OneMany(Expression value)
        {
            return AppendInternal(Groups.OneMany(value));
        }

        public Quantifier Count(string value, int exactCount)
        {
            return AppendInternal(Groups.Count(value, exactCount));
        }

        public Quantifier Count(Expression expression, int exactCount)
        {
            return AppendInternal(Groups.Count(expression, exactCount));
        }

        public Quantifier AtLeast(string value, int minCount)
        {
            return AppendInternal(Groups.AtLeast(value, minCount));
        }

        public Quantifier AtLeast(Expression expression, int minCount)
        {
            return AppendInternal(Groups.AtLeast(expression, minCount));
        }

        public Quantifier Count(string value, int minCount, int maxCount)
        {
            return AppendInternal(Groups.Count(value, minCount, maxCount));
        }

        public Quantifier Count(Expression expression, int minCount, int maxCount)
        {
            return AppendInternal(Groups.Count(expression, minCount, maxCount));
        }
    }
}
