// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Lookahead(Expression value)
        {
            return AppendInternal(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(string value)
        {
            return AppendInternal(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(params char[] values)
        {
            return AppendInternal(Assertions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params int[] charCodes)
        {
            return AppendInternal(Assertions.Lookahead(charCodes));
        }

        public QuantifiableExpression Lookahead(params AsciiChar[] values)
        {
            return AppendInternal(Assertions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params CharClass[] values)
        {
            return AppendInternal(Assertions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertions.Lookahead(blocks));
        }

        public QuantifiableExpression Lookahead(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertions.Lookahead(categories));
        }

        public QuantifiableExpression NotLookahead(Expression value)
        {
            return AppendInternal(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(string value)
        {
            return AppendInternal(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(params char[] values)
        {
            return AppendInternal(Assertions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params int[] charCodes)
        {
            return AppendInternal(Assertions.NotLookahead(charCodes));
        }

        public QuantifiableExpression NotLookahead(params AsciiChar[] values)
        {
            return AppendInternal(Assertions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params CharClass[] values)
        {
            return AppendInternal(Assertions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertions.NotLookahead(blocks));
        }

        public QuantifiableExpression NotLookahead(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertions.NotLookahead(categories));
        }

        public QuantifiableExpression Lookbehind(Expression value)
        {
            return AppendInternal(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(string value)
        {
            return AppendInternal(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(params char[] values)
        {
            return AppendInternal(Assertions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params int[] charCodes)
        {
            return AppendInternal(Assertions.Lookbehind(charCodes));
        }

        public QuantifiableExpression Lookbehind(params AsciiChar[] values)
        {
            return AppendInternal(Assertions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params CharClass[] values)
        {
            return AppendInternal(Assertions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertions.Lookbehind(blocks));
        }

        public QuantifiableExpression Lookbehind(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertions.Lookbehind(categories));
        }

        public QuantifiableExpression NotLookbehind(Expression value)
        {
            return AppendInternal(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(string value)
        {
            return AppendInternal(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(params char[] values)
        {
            return AppendInternal(Assertions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params int[] charCodes)
        {
            return AppendInternal(Assertions.NotLookbehind(charCodes));
        }

        public QuantifiableExpression NotLookbehind(params AsciiChar[] values)
        {
            return AppendInternal(Assertions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params CharClass[] values)
        {
            return AppendInternal(Assertions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertions.NotLookbehind(blocks));
        }

        public QuantifiableExpression NotLookbehind(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertions.NotLookbehind(categories));
        }

        public QuantifiableExpression AsLookahead()
        {
            return Assertions.Lookahead(this);
        }

        public QuantifiableExpression AsNotLookahead()
        {
            return Assertions.NotLookahead(this);
        }

        public QuantifiableExpression AsLookbehind()
        {
            return Assertions.Lookbehind(this);
        }

        public QuantifiableExpression AsNotLookbehind()
        {
            return Assertions.NotLookbehind(this);
        }
    }
}
