// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Lookahead(Expression value)
        {
            return Append(Expressions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(string value)
        {
            return Append(Expressions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(params char[] values)
        {
            return Append(Expressions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params int[] charCodes)
        {
            return Append(Expressions.Lookahead(charCodes));
        }

        public QuantifiableExpression Lookahead(params AsciiChar[] values)
        {
            return Append(Expressions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params CharClass[] values)
        {
            return Append(Expressions.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params UnicodeBlock[] blocks)
        {
            return Append(Expressions.Lookahead(blocks));
        }

        public QuantifiableExpression Lookahead(UnicodeCategory[] categories)
        {
            return Append(Expressions.Lookahead(categories));
        }

        public QuantifiableExpression NotLookahead(Expression value)
        {
            return Append(Expressions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(string value)
        {
            return Append(Expressions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(params char[] values)
        {
            return Append(Expressions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params int[] charCodes)
        {
            return Append(Expressions.NotLookahead(charCodes));
        }

        public QuantifiableExpression NotLookahead(params AsciiChar[] values)
        {
            return Append(Expressions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params CharClass[] values)
        {
            return Append(Expressions.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params UnicodeBlock[] blocks)
        {
            return Append(Expressions.NotLookahead(blocks));
        }

        public QuantifiableExpression NotLookahead(UnicodeCategory[] categories)
        {
            return Append(Expressions.NotLookahead(categories));
        }

        public QuantifiableExpression Lookbehind(Expression value)
        {
            return Append(Expressions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(string value)
        {
            return Append(Expressions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(params char[] values)
        {
            return Append(Expressions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params int[] charCodes)
        {
            return Append(Expressions.Lookbehind(charCodes));
        }

        public QuantifiableExpression Lookbehind(params AsciiChar[] values)
        {
            return Append(Expressions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params CharClass[] values)
        {
            return Append(Expressions.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params UnicodeBlock[] blocks)
        {
            return Append(Expressions.Lookbehind(blocks));
        }

        public QuantifiableExpression Lookbehind(UnicodeCategory[] categories)
        {
            return Append(Expressions.Lookbehind(categories));
        }

        public QuantifiableExpression NotLookbehind(Expression value)
        {
            return Append(Expressions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(string value)
        {
            return Append(Expressions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(params char[] values)
        {
            return Append(Expressions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params int[] charCodes)
        {
            return Append(Expressions.NotLookbehind(charCodes));
        }

        public QuantifiableExpression NotLookbehind(params AsciiChar[] values)
        {
            return Append(Expressions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params CharClass[] values)
        {
            return Append(Expressions.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params UnicodeBlock[] blocks)
        {
            return Append(Expressions.NotLookbehind(blocks));
        }

        public QuantifiableExpression NotLookbehind(UnicodeCategory[] categories)
        {
            return Append(Expressions.NotLookbehind(categories));
        }

        public QuantifiableExpression AsLookahead()
        {
            return Expressions.Lookahead(First);
        }

        public QuantifiableExpression AsNotLookahead()
        {
            return Expressions.NotLookahead(First);
        }

        public QuantifiableExpression AsLookbehind()
        {
            return Expressions.Lookbehind(First);
        }

        public QuantifiableExpression AsNotLookbehind()
        {
            return Expressions.NotLookbehind(First);
        }
    }
}
