// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public Quantifier Maybe(string value)
        {
            return Append(Expressions.Maybe(value));
        }

        public Quantifier Maybe(Expression value)
        {
            return Append(Expressions.Maybe(value));
        }

        public Quantifier MaybeMany(string value)
        {
            return Append(Expressions.MaybeMany(value));
        }

        public Quantifier MaybeMany(Expression value)
        {
            return Append(Expressions.MaybeMany(value));
        }

        public Quantifier OneMany(string value)
        {
            return Append(Expressions.OneMany(value));
        }

        public Quantifier OneMany(Expression value)
        {
            return Append(Expressions.OneMany(value));
        }
    }
}
