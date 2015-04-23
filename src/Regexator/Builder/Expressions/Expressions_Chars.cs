// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Char(char value)
        {
            return new QuantifiableExpression(Syntax.Char(value));
        }

        public static QuantifiableExpression Char(int charCode)
        {
            return new QuantifiableExpression(Syntax.Char(charCode));
        }

        public static QuantifiableExpression Char(AsciiChar value)
        {
            return new QuantifiableExpression(Syntax.Char(value));
        }

        public static QuantifiableExpression Char(CharClass value)
        {
            return new QuantifiableExpression(Syntax.CharClass(value));
        }

        public static QuantifiableExpression UnicodeBlock(UnicodeBlock block)
        {
            return new QuantifiableExpression(Syntax.UnicodeBlock(block));
        }

        public static QuantifiableExpression UnicodeCategory(UnicodeCategory category)
        {
            return new QuantifiableExpression(Syntax.UnicodeCategory(category));
        }

        public static CharGroup NotChar(char value)
        {
            return new NotCharGroup(value);
        }

        public static CharGroup NotChar(int charCode)
        {
            return new NotCharGroup(charCode);
        }

        public static CharGroup NotChar(AsciiChar value)
        {
            return new NotCharGroup(value);
        }

        public static QuantifiableExpression NotUnicodeBlock(UnicodeBlock block)
        {
            return new QuantifiableExpression(Syntax.NotUnicodeBlock(block));
        }

        public static QuantifiableExpression NotUnicodeCategory(UnicodeCategory category)
        {
            return new QuantifiableExpression(Syntax.NotUnicodeCategory(category));
        }

        public static CharGroup Chars(string value)
        {
            return new CharGroup(Utilities.Escape(value, true));
        }

        public static CharGroup Chars(CharItem item)
        {
            return new CharGroup(item);
        }

        public static CharGroup Chars(params char[] values)
        {
            return new CharGroup(values);
        }

        public static CharGroup Chars(params int[] charCodes)
        {
            return new CharGroup(charCodes);
        }

        public static CharGroup Chars(params AsciiChar[] values)
        {
            return new CharGroup(values);
        }

        public static CharGroup Chars(params CharClass[] values)
        {
            return new CharGroup(values);
        }

        public static CharGroup UnicodeBlock(params UnicodeBlock[] blocks)
        {
            return new CharGroup(blocks);
        }

        public static CharGroup UnicodeCategory(params UnicodeCategory[] categories)
        {
            return new CharGroup(categories);
        }

        public static CharGroup NotChars(string value)
        {
            return new NotCharGroup(Utilities.Escape(value, true));
        }

        public static CharGroup NotChars(CharItem item)
        {
            return new NotCharGroup(item);
        }

        public static CharGroup NotChars(params char[] values)
        {
            return new NotCharGroup(values);
        }

        public static CharGroup NotChars(params int[] charCodes)
        {
            return new NotCharGroup(charCodes);
        }

        public static CharGroup NotChars(params AsciiChar[] values)
        {
            return new NotCharGroup(values);
        }

        public static CharGroup NotUnicodeBlock(params UnicodeBlock[] blocks)
        {
            return new NotCharGroup(blocks);
        }

        public static CharGroup NotUnicodeCategory(params UnicodeCategory[] categories)
        {
            return new NotCharGroup(categories);
        }

        public static CharGroup Range(char first, char last)
        {
            return new CharGroup(Syntax.Char(first, true) + "-" + Syntax.Char(last, true));
        }

        public static CharGroup Range(int first, int last)
        {
            return new CharGroup(Syntax.Char(first, true) + "-" + Syntax.Char(last, true));
        }

        public static CharGroup NotRange(char first, char last)
        {
            return new NotCharGroup(Syntax.Char(first, true) + "-" + Syntax.Char(last, true));
        }

        public static CharGroup NotRange(int first, int last)
        {
            return new NotCharGroup(Syntax.Char(first, true) + "-" + Syntax.Char(last, true));
        }

        public static CharSubtraction Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        public static CharSubtraction NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup, true);
        }

        public static QuantifiableExpression Any()
        {
            return new QuantifiableExpression(Syntax.Any);
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return new CharSubtraction(CharItems.WhiteSpace(), new CharGroup(CharItems.CarriageReturn().Linefeed()));
        }
    }
}
