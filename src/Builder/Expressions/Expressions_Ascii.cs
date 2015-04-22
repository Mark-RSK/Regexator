// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Tab()
        {
            return Char(AsciiChar.Tab);
        }

        public static Quantifier Tab(int exactCount)
        {
            return Char(AsciiChar.Tab).Count(exactCount);
        }

        public static Quantifier Tab(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tab).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTab()
        {
            return NotChar(AsciiChar.Tab);
        }

        public static Quantifier NotTab(int exactCount)
        {
            return NotChar(AsciiChar.Tab).Count(exactCount);
        }

        public static Quantifier NotTab(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tab).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Linefeed()
        {
            return Char(AsciiChar.Linefeed);
        }

        public static Quantifier Linefeed(int exactCount)
        {
            return Char(AsciiChar.Linefeed).Count(exactCount);
        }

        public static Quantifier Linefeed(int minCount, int maxCount)
        {
            return Char(AsciiChar.Linefeed).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLinefeed()
        {
            return NotChar(AsciiChar.Linefeed);
        }

        public static Quantifier NotLinefeed(int exactCount)
        {
            return NotChar(AsciiChar.Linefeed).Count(exactCount);
        }

        public static Quantifier NotLinefeed(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Linefeed).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CarriageReturn()
        {
            return Char(AsciiChar.CarriageReturn);
        }

        public static Quantifier CarriageReturn(int exactCount)
        {
            return Char(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static Quantifier CarriageReturn(int minCount, int maxCount)
        {
            return Char(AsciiChar.CarriageReturn).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCarriageReturn()
        {
            return NotChar(AsciiChar.CarriageReturn);
        }

        public static Quantifier NotCarriageReturn(int exactCount)
        {
            return NotChar(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static Quantifier NotCarriageReturn(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CarriageReturn).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Space()
        {
            return Char(AsciiChar.Space);
        }

        public static Quantifier Space(int exactCount)
        {
            return Char(AsciiChar.Space).Count(exactCount);
        }

        public static Quantifier Space(int minCount, int maxCount)
        {
            return Char(AsciiChar.Space).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpace()
        {
            return NotChar(AsciiChar.Space);
        }

        public static Quantifier NotSpace(int exactCount)
        {
            return NotChar(AsciiChar.Space).Count(exactCount);
        }

        public static Quantifier NotSpace(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Space).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ExclamationMark()
        {
            return Char(AsciiChar.ExclamationMark);
        }

        public static Quantifier ExclamationMark(int exactCount)
        {
            return Char(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static Quantifier ExclamationMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.ExclamationMark).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotExclamationMark()
        {
            return NotChar(AsciiChar.ExclamationMark);
        }

        public static Quantifier NotExclamationMark(int exactCount)
        {
            return NotChar(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static Quantifier NotExclamationMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.ExclamationMark).Count(minCount, maxCount);
        }

        public static QuantifiableExpression QuotationMark()
        {
            return Char(AsciiChar.QuotationMark);
        }

        public static Quantifier QuotationMark(int exactCount)
        {
            return Char(AsciiChar.QuotationMark).Count(exactCount);
        }

        public static Quantifier QuotationMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuotationMark).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotQuotationMark()
        {
            return NotChar(AsciiChar.QuotationMark);
        }

        public static Quantifier NotQuotationMark(int exactCount)
        {
            return NotChar(AsciiChar.QuotationMark).Count(exactCount);
        }

        public static Quantifier NotQuotationMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuotationMark).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberSign()
        {
            return Char(AsciiChar.NumberSign);
        }

        public static Quantifier NumberSign(int exactCount)
        {
            return Char(AsciiChar.NumberSign).Count(exactCount);
        }

        public static Quantifier NumberSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.NumberSign).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberSign()
        {
            return NotChar(AsciiChar.NumberSign);
        }

        public static Quantifier NotNumberSign(int exactCount)
        {
            return NotChar(AsciiChar.NumberSign).Count(exactCount);
        }

        public static Quantifier NotNumberSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.NumberSign).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Dollar()
        {
            return Char(AsciiChar.Dollar);
        }

        public static Quantifier Dollar(int exactCount)
        {
            return Char(AsciiChar.Dollar).Count(exactCount);
        }

        public static Quantifier Dollar(int minCount, int maxCount)
        {
            return Char(AsciiChar.Dollar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDollar()
        {
            return NotChar(AsciiChar.Dollar);
        }

        public static Quantifier NotDollar(int exactCount)
        {
            return NotChar(AsciiChar.Dollar).Count(exactCount);
        }

        public static Quantifier NotDollar(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Dollar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Percent()
        {
            return Char(AsciiChar.Percent);
        }

        public static Quantifier Percent(int exactCount)
        {
            return Char(AsciiChar.Percent).Count(exactCount);
        }

        public static Quantifier Percent(int minCount, int maxCount)
        {
            return Char(AsciiChar.Percent).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPercent()
        {
            return NotChar(AsciiChar.Percent);
        }

        public static Quantifier NotPercent(int exactCount)
        {
            return NotChar(AsciiChar.Percent).Count(exactCount);
        }

        public static Quantifier NotPercent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Percent).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Ampersand()
        {
            return Char(AsciiChar.Ampersand);
        }

        public static Quantifier Ampersand(int exactCount)
        {
            return Char(AsciiChar.Ampersand).Count(exactCount);
        }

        public static Quantifier Ampersand(int minCount, int maxCount)
        {
            return Char(AsciiChar.Ampersand).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAmpersand()
        {
            return NotChar(AsciiChar.Ampersand);
        }

        public static Quantifier NotAmpersand(int exactCount)
        {
            return NotChar(AsciiChar.Ampersand).Count(exactCount);
        }

        public static Quantifier NotAmpersand(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Ampersand).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Apostrophe()
        {
            return Char(AsciiChar.Apostrophe);
        }

        public static Quantifier Apostrophe(int exactCount)
        {
            return Char(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static Quantifier Apostrophe(int minCount, int maxCount)
        {
            return Char(AsciiChar.Apostrophe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotApostrophe()
        {
            return NotChar(AsciiChar.Apostrophe);
        }

        public static Quantifier NotApostrophe(int exactCount)
        {
            return NotChar(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static Quantifier NotApostrophe(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Apostrophe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LeftParenthesis()
        {
            return Char(AsciiChar.LeftParenthesis);
        }

        public static Quantifier LeftParenthesis(int exactCount)
        {
            return Char(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static Quantifier LeftParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftParenthesis).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLeftParenthesis()
        {
            return NotChar(AsciiChar.LeftParenthesis);
        }

        public static Quantifier NotLeftParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static Quantifier NotLeftParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).Count(minCount, maxCount);
        }

        public static QuantifiableExpression RightParenthesis()
        {
            return Char(AsciiChar.RightParenthesis);
        }

        public static Quantifier RightParenthesis(int exactCount)
        {
            return Char(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static Quantifier RightParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightParenthesis).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotRightParenthesis()
        {
            return NotChar(AsciiChar.RightParenthesis);
        }

        public static Quantifier NotRightParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static Quantifier NotRightParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightParenthesis).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Asterisk()
        {
            return Char(AsciiChar.Asterisk);
        }

        public static Quantifier Asterisk(int exactCount)
        {
            return Char(AsciiChar.Asterisk).Count(exactCount);
        }

        public static Quantifier Asterisk(int minCount, int maxCount)
        {
            return Char(AsciiChar.Asterisk).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAsterisk()
        {
            return NotChar(AsciiChar.Asterisk);
        }

        public static Quantifier NotAsterisk(int exactCount)
        {
            return NotChar(AsciiChar.Asterisk).Count(exactCount);
        }

        public static Quantifier NotAsterisk(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Asterisk).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Plus()
        {
            return Char(AsciiChar.Plus);
        }

        public static Quantifier Plus(int exactCount)
        {
            return Char(AsciiChar.Plus).Count(exactCount);
        }

        public static Quantifier Plus(int minCount, int maxCount)
        {
            return Char(AsciiChar.Plus).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPlus()
        {
            return NotChar(AsciiChar.Plus);
        }

        public static Quantifier NotPlus(int exactCount)
        {
            return NotChar(AsciiChar.Plus).Count(exactCount);
        }

        public static Quantifier NotPlus(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Plus).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Comma()
        {
            return Char(AsciiChar.Comma);
        }

        public static Quantifier Comma(int exactCount)
        {
            return Char(AsciiChar.Comma).Count(exactCount);
        }

        public static Quantifier Comma(int minCount, int maxCount)
        {
            return Char(AsciiChar.Comma).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotComma()
        {
            return NotChar(AsciiChar.Comma);
        }

        public static Quantifier NotComma(int exactCount)
        {
            return NotChar(AsciiChar.Comma).Count(exactCount);
        }

        public static Quantifier NotComma(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Comma).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hyphen()
        {
            return Char(AsciiChar.Hyphen);
        }

        public static Quantifier Hyphen(int exactCount)
        {
            return Char(AsciiChar.Hyphen).Count(exactCount);
        }

        public static Quantifier Hyphen(int minCount, int maxCount)
        {
            return Char(AsciiChar.Hyphen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHyphen()
        {
            return NotChar(AsciiChar.Hyphen);
        }

        public static Quantifier NotHyphen(int exactCount)
        {
            return NotChar(AsciiChar.Hyphen).Count(exactCount);
        }

        public static Quantifier NotHyphen(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Hyphen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Period()
        {
            return Char(AsciiChar.Period);
        }

        public static Quantifier Period(int exactCount)
        {
            return Char(AsciiChar.Period).Count(exactCount);
        }

        public static Quantifier Period(int minCount, int maxCount)
        {
            return Char(AsciiChar.Period).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPeriod()
        {
            return NotChar(AsciiChar.Period);
        }

        public static Quantifier NotPeriod(int exactCount)
        {
            return NotChar(AsciiChar.Period).Count(exactCount);
        }

        public static Quantifier NotPeriod(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Period).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Slash()
        {
            return Char(AsciiChar.Slash);
        }

        public static Quantifier Slash(int exactCount)
        {
            return Char(AsciiChar.Slash).Count(exactCount);
        }

        public static Quantifier Slash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Slash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSlash()
        {
            return NotChar(AsciiChar.Slash);
        }

        public static Quantifier NotSlash(int exactCount)
        {
            return NotChar(AsciiChar.Slash).Count(exactCount);
        }

        public static Quantifier NotSlash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Slash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Colon()
        {
            return Char(AsciiChar.Colon);
        }

        public static Quantifier Colon(int exactCount)
        {
            return Char(AsciiChar.Colon).Count(exactCount);
        }

        public static Quantifier Colon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Colon).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotColon()
        {
            return NotChar(AsciiChar.Colon);
        }

        public static Quantifier NotColon(int exactCount)
        {
            return NotChar(AsciiChar.Colon).Count(exactCount);
        }

        public static Quantifier NotColon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Colon).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Semicolon()
        {
            return Char(AsciiChar.Semicolon);
        }

        public static Quantifier Semicolon(int exactCount)
        {
            return Char(AsciiChar.Semicolon).Count(exactCount);
        }

        public static Quantifier Semicolon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Semicolon).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSemicolon()
        {
            return NotChar(AsciiChar.Semicolon);
        }

        public static Quantifier NotSemicolon(int exactCount)
        {
            return NotChar(AsciiChar.Semicolon).Count(exactCount);
        }

        public static Quantifier NotSemicolon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Semicolon).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LessThan()
        {
            return Char(AsciiChar.LessThan);
        }

        public static Quantifier LessThan(int exactCount)
        {
            return Char(AsciiChar.LessThan).Count(exactCount);
        }

        public static Quantifier LessThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.LessThan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLessThan()
        {
            return NotChar(AsciiChar.LessThan);
        }

        public static Quantifier NotLessThan(int exactCount)
        {
            return NotChar(AsciiChar.LessThan).Count(exactCount);
        }

        public static Quantifier NotLessThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LessThan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression EqualsSign()
        {
            return Char(AsciiChar.EqualsSign);
        }

        public static Quantifier EqualsSign(int exactCount)
        {
            return Char(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static Quantifier EqualsSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.EqualsSign).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEqualsSign()
        {
            return NotChar(AsciiChar.EqualsSign);
        }

        public static Quantifier NotEqualsSign(int exactCount)
        {
            return NotChar(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static Quantifier NotEqualsSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.EqualsSign).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GreaterThan()
        {
            return Char(AsciiChar.GreaterThan);
        }

        public static Quantifier GreaterThan(int exactCount)
        {
            return Char(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static Quantifier GreaterThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.GreaterThan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreaterThan()
        {
            return NotChar(AsciiChar.GreaterThan);
        }

        public static Quantifier NotGreaterThan(int exactCount)
        {
            return NotChar(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static Quantifier NotGreaterThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GreaterThan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression QuestionMark()
        {
            return Char(AsciiChar.QuestionMark);
        }

        public static Quantifier QuestionMark(int exactCount)
        {
            return Char(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static Quantifier QuestionMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuestionMark).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotQuestionMark()
        {
            return NotChar(AsciiChar.QuestionMark);
        }

        public static Quantifier NotQuestionMark(int exactCount)
        {
            return NotChar(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static Quantifier NotQuestionMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuestionMark).Count(minCount, maxCount);
        }

        public static QuantifiableExpression At()
        {
            return Char(AsciiChar.At);
        }

        public static Quantifier At(int exactCount)
        {
            return Char(AsciiChar.At).Count(exactCount);
        }

        public static Quantifier At(int minCount, int maxCount)
        {
            return Char(AsciiChar.At).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAt()
        {
            return NotChar(AsciiChar.At);
        }

        public static Quantifier NotAt(int exactCount)
        {
            return NotChar(AsciiChar.At).Count(exactCount);
        }

        public static Quantifier NotAt(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.At).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LeftSquareBracket()
        {
            return Char(AsciiChar.LeftSquareBracket);
        }

        public static Quantifier LeftSquareBracket(int exactCount)
        {
            return Char(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static Quantifier LeftSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftSquareBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLeftSquareBracket()
        {
            return NotChar(AsciiChar.LeftSquareBracket);
        }

        public static Quantifier NotLeftSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static Quantifier NotLeftSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Backslash()
        {
            return Char(AsciiChar.Backslash);
        }

        public static Quantifier Backslash(int exactCount)
        {
            return Char(AsciiChar.Backslash).Count(exactCount);
        }

        public static Quantifier Backslash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Backslash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBackslash()
        {
            return NotChar(AsciiChar.Backslash);
        }

        public static Quantifier NotBackslash(int exactCount)
        {
            return NotChar(AsciiChar.Backslash).Count(exactCount);
        }

        public static Quantifier NotBackslash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Backslash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression RightSquareBracket()
        {
            return Char(AsciiChar.RightSquareBracket);
        }

        public static Quantifier RightSquareBracket(int exactCount)
        {
            return Char(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static Quantifier RightSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightSquareBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotRightSquareBracket()
        {
            return NotChar(AsciiChar.RightSquareBracket);
        }

        public static Quantifier NotRightSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static Quantifier NotRightSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CircumflexAccent()
        {
            return Char(AsciiChar.CircumflexAccent);
        }

        public static Quantifier CircumflexAccent(int exactCount)
        {
            return Char(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static Quantifier CircumflexAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.CircumflexAccent).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCircumflexAccent()
        {
            return NotChar(AsciiChar.CircumflexAccent);
        }

        public static Quantifier NotCircumflexAccent(int exactCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static Quantifier NotCircumflexAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Underscore()
        {
            return Char(AsciiChar.Underscore);
        }

        public static Quantifier Underscore(int exactCount)
        {
            return Char(AsciiChar.Underscore).Count(exactCount);
        }

        public static Quantifier Underscore(int minCount, int maxCount)
        {
            return Char(AsciiChar.Underscore).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotUnderscore()
        {
            return NotChar(AsciiChar.Underscore);
        }

        public static Quantifier NotUnderscore(int exactCount)
        {
            return NotChar(AsciiChar.Underscore).Count(exactCount);
        }

        public static Quantifier NotUnderscore(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Underscore).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GraveAccent()
        {
            return Char(AsciiChar.GraveAccent);
        }

        public static Quantifier GraveAccent(int exactCount)
        {
            return Char(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static Quantifier GraveAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.GraveAccent).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGraveAccent()
        {
            return NotChar(AsciiChar.GraveAccent);
        }

        public static Quantifier NotGraveAccent(int exactCount)
        {
            return NotChar(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static Quantifier NotGraveAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GraveAccent).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LeftCurlyBracket()
        {
            return Char(AsciiChar.LeftCurlyBracket);
        }

        public static Quantifier LeftCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static Quantifier LeftCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLeftCurlyBracket()
        {
            return NotChar(AsciiChar.LeftCurlyBracket);
        }

        public static Quantifier NotLeftCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static Quantifier NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression VerticalLine()
        {
            return Char(AsciiChar.VerticalLine);
        }

        public static Quantifier VerticalLine(int exactCount)
        {
            return Char(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static Quantifier VerticalLine(int minCount, int maxCount)
        {
            return Char(AsciiChar.VerticalLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotVerticalLine()
        {
            return NotChar(AsciiChar.VerticalLine);
        }

        public static Quantifier NotVerticalLine(int exactCount)
        {
            return NotChar(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static Quantifier NotVerticalLine(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.VerticalLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression RightCurlyBracket()
        {
            return Char(AsciiChar.RightCurlyBracket);
        }

        public static Quantifier RightCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static Quantifier RightCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightCurlyBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotRightCurlyBracket()
        {
            return NotChar(AsciiChar.RightCurlyBracket);
        }

        public static Quantifier NotRightCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static Quantifier NotRightCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tilde()
        {
            return Char(AsciiChar.Tilde);
        }

        public static Quantifier Tilde(int exactCount)
        {
            return Char(AsciiChar.Tilde).Count(exactCount);
        }

        public static Quantifier Tilde(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tilde).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTilde()
        {
            return NotChar(AsciiChar.Tilde);
        }

        public static Quantifier NotTilde(int exactCount)
        {
            return NotChar(AsciiChar.Tilde).Count(exactCount);
        }

        public static Quantifier NotTilde(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tilde).Count(minCount, maxCount);
        }
    }
}
