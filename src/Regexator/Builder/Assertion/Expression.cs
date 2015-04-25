// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Lookahead(Expression value)
        {
            return Append(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(string value)
        {
            return Append(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(params char[] values)
        {
            return Append(Assertions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params int[] charCodes)
        {
            return Append(Assertions.Lookahead(charCodes));
        }

        public QuantifiableExpression Lookahead(params AsciiChar[] values)
        {
            return Append(Assertions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params CharClass[] values)
        {
            return Append(Assertions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params UnicodeBlock[] blocks)
        {
            return Append(Assertions.Lookahead(blocks));
        }

        public QuantifiableExpression Lookahead(UnicodeCategory[] categories)
        {
            return Append(Assertions.Lookahead(categories));
        }

        public QuantifiableExpression NotLookahead(Expression value)
        {
            return Append(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(string value)
        {
            return Append(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(params char[] values)
        {
            return Append(Assertions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params int[] charCodes)
        {
            return Append(Assertions.NotLookahead(charCodes));
        }

        public QuantifiableExpression NotLookahead(params AsciiChar[] values)
        {
            return Append(Assertions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params CharClass[] values)
        {
            return Append(Assertions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params UnicodeBlock[] blocks)
        {
            return Append(Assertions.NotLookahead(blocks));
        }

        public QuantifiableExpression NotLookahead(UnicodeCategory[] categories)
        {
            return Append(Assertions.NotLookahead(categories));
        }

        public QuantifiableExpression Lookbehind(Expression value)
        {
            return Append(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(string value)
        {
            return Append(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(params char[] values)
        {
            return Append(Assertions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params int[] charCodes)
        {
            return Append(Assertions.Lookbehind(charCodes));
        }

        public QuantifiableExpression Lookbehind(params AsciiChar[] values)
        {
            return Append(Assertions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params CharClass[] values)
        {
            return Append(Assertions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params UnicodeBlock[] blocks)
        {
            return Append(Assertions.Lookbehind(blocks));
        }

        public QuantifiableExpression Lookbehind(UnicodeCategory[] categories)
        {
            return Append(Assertions.Lookbehind(categories));
        }

        public QuantifiableExpression NotLookbehind(Expression value)
        {
            return Append(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(string value)
        {
            return Append(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(params char[] values)
        {
            return Append(Assertions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params int[] charCodes)
        {
            return Append(Assertions.NotLookbehind(charCodes));
        }

        public QuantifiableExpression NotLookbehind(params AsciiChar[] values)
        {
            return Append(Assertions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params CharClass[] values)
        {
            return Append(Assertions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params UnicodeBlock[] blocks)
        {
            return Append(Assertions.NotLookbehind(blocks));
        }

        public QuantifiableExpression NotLookbehind(UnicodeCategory[] categories)
        {
            return Append(Assertions.NotLookbehind(categories));
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
