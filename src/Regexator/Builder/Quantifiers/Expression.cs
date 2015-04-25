// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public Quantifier Maybe(string value)
        {
            return Append(Groups.Maybe(value));
        }

        public Quantifier Maybe(Expression value)
        {
            return Append(Groups.Maybe(value));
        }

        public Quantifier MaybeMany(string value)
        {
            return Append(Groups.MaybeMany(value));
        }

        public Quantifier MaybeMany(Expression value)
        {
            return Append(Groups.MaybeMany(value));
        }

        public Quantifier OneMany(string value)
        {
            return Append(Groups.OneMany(value));
        }

        public Quantifier OneMany(Expression value)
        {
            return Append(Groups.OneMany(value));
        }

        public Quantifier Count(int exactCount, Expression expression)
        {
            return Append(Groups.Count(exactCount, expression));
        }

        public Quantifier AtLeast(int minCount, Expression expression)
        {
            return Append(Groups.AtLeast(minCount, expression));
        }

        public Quantifier Count(int minCount, int maxCount, Expression expression)
        {
            return Append(Groups.Count(minCount, maxCount, expression));
        }
    }
}
