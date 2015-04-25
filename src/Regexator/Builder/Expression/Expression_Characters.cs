// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Char(char value)
        {
            return Append(Characters.Char(value));
        }

        public QuantifiableExpression Char(int charCode)
        {
            return Append(Characters.Char(charCode));
        }

        public QuantifiableExpression Char(AsciiChar value)
        {
            return Append(Characters.Char(value));
        }

        public QuantifiableExpression Char(CharClass value)
        {
            return Append(Characters.Char(value));
        }

        public QuantifiableExpression UnicodeBlock(UnicodeBlock block)
        {
            return Append(Characters.UnicodeBlock(block));
        }

        public QuantifiableExpression UnicodeCategory(UnicodeCategory category)
        {
            return Append(Characters.UnicodeCategory(category));
        }

        public QuantifiableExpression NotChar(char value)
        {
            return Append(Characters.NotChar(value));
        }

        public QuantifiableExpression NotChar(int charCode)
        {
            return Append(Characters.NotChar(charCode));
        }

        public QuantifiableExpression NotChar(AsciiChar value)
        {
            return Append(Characters.NotChar(value));
        }

        public QuantifiableExpression NotUnicodeBlock(UnicodeBlock block)
        {
            return Append(Characters.NotUnicodeBlock(block));
        }

        public QuantifiableExpression NotUnicodeCategory(UnicodeCategory category)
        {
            return Append(Characters.NotUnicodeCategory(category));
        }

        public QuantifiableExpression Tab()
        {
            return Append(Characters.Tab());
        }

        public Quantifier Tab(int exactCount)
        {
            return Append(Characters.Tab(exactCount));
        }

        public Quantifier Tab(int minCount, int maxCount)
        {
            return Append(Characters.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return Append(Characters.NotTab());
        }

        public Quantifier NotTab(int exactCount)
        {
            return Append(Characters.NotTab(exactCount));
        }

        public Quantifier NotTab(int minCount, int maxCount)
        {
            return Append(Characters.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return Append(Characters.Linefeed());
        }

        public Quantifier Linefeed(int exactCount)
        {
            return Append(Characters.Linefeed(exactCount));
        }

        public Quantifier Linefeed(int minCount, int maxCount)
        {
            return Append(Characters.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return Append(Characters.NotLinefeed());
        }

        public Quantifier NotLinefeed(int exactCount)
        {
            return Append(Characters.NotLinefeed(exactCount));
        }

        public Quantifier NotLinefeed(int minCount, int maxCount)
        {
            return Append(Characters.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return Append(Characters.CarriageReturn());
        }

        public Quantifier CarriageReturn(int exactCount)
        {
            return Append(Characters.CarriageReturn(exactCount));
        }

        public Quantifier CarriageReturn(int minCount, int maxCount)
        {
            return Append(Characters.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return Append(Characters.NotCarriageReturn());
        }

        public Quantifier NotCarriageReturn(int exactCount)
        {
            return Append(Characters.NotCarriageReturn(exactCount));
        }

        public Quantifier NotCarriageReturn(int minCount, int maxCount)
        {
            return Append(Characters.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return Append(Characters.Space());
        }

        public Quantifier Space(int exactCount)
        {
            return Append(Characters.Space(exactCount));
        }

        public Quantifier Space(int minCount, int maxCount)
        {
            return Append(Characters.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return Append(Characters.NotSpace());
        }

        public Quantifier NotSpace(int exactCount)
        {
            return Append(Characters.NotSpace(exactCount));
        }

        public Quantifier NotSpace(int minCount, int maxCount)
        {
            return Append(Characters.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return Append(Characters.ExclamationMark());
        }

        public Quantifier ExclamationMark(int exactCount)
        {
            return Append(Characters.ExclamationMark(exactCount));
        }

        public Quantifier ExclamationMark(int minCount, int maxCount)
        {
            return Append(Characters.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return Append(Characters.NotExclamationMark());
        }

        public Quantifier NotExclamationMark(int exactCount)
        {
            return Append(Characters.NotExclamationMark(exactCount));
        }

        public Quantifier NotExclamationMark(int minCount, int maxCount)
        {
            return Append(Characters.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuotationMark()
        {
            return Append(Characters.QuotationMark());
        }

        public Quantifier QuotationMark(int exactCount)
        {
            return Append(Characters.QuotationMark(exactCount));
        }

        public Quantifier QuotationMark(int minCount, int maxCount)
        {
            return Append(Characters.QuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuotationMark()
        {
            return Append(Characters.NotQuotationMark());
        }

        public Quantifier NotQuotationMark(int exactCount)
        {
            return Append(Characters.NotQuotationMark(exactCount));
        }

        public Quantifier NotQuotationMark(int minCount, int maxCount)
        {
            return Append(Characters.NotQuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return Append(Characters.NumberSign());
        }

        public Quantifier NumberSign(int exactCount)
        {
            return Append(Characters.NumberSign(exactCount));
        }

        public Quantifier NumberSign(int minCount, int maxCount)
        {
            return Append(Characters.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return Append(Characters.NotNumberSign());
        }

        public Quantifier NotNumberSign(int exactCount)
        {
            return Append(Characters.NotNumberSign(exactCount));
        }

        public Quantifier NotNumberSign(int minCount, int maxCount)
        {
            return Append(Characters.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return Append(Characters.Dollar());
        }

        public Quantifier Dollar(int exactCount)
        {
            return Append(Characters.Dollar(exactCount));
        }

        public Quantifier Dollar(int minCount, int maxCount)
        {
            return Append(Characters.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return Append(Characters.NotDollar());
        }

        public Quantifier NotDollar(int exactCount)
        {
            return Append(Characters.NotDollar(exactCount));
        }

        public Quantifier NotDollar(int minCount, int maxCount)
        {
            return Append(Characters.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return Append(Characters.Percent());
        }

        public Quantifier Percent(int exactCount)
        {
            return Append(Characters.Percent(exactCount));
        }

        public Quantifier Percent(int minCount, int maxCount)
        {
            return Append(Characters.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return Append(Characters.NotPercent());
        }

        public Quantifier NotPercent(int exactCount)
        {
            return Append(Characters.NotPercent(exactCount));
        }

        public Quantifier NotPercent(int minCount, int maxCount)
        {
            return Append(Characters.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return Append(Characters.Ampersand());
        }

        public Quantifier Ampersand(int exactCount)
        {
            return Append(Characters.Ampersand(exactCount));
        }

        public Quantifier Ampersand(int minCount, int maxCount)
        {
            return Append(Characters.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return Append(Characters.NotAmpersand());
        }

        public Quantifier NotAmpersand(int exactCount)
        {
            return Append(Characters.NotAmpersand(exactCount));
        }

        public Quantifier NotAmpersand(int minCount, int maxCount)
        {
            return Append(Characters.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return Append(Characters.Apostrophe());
        }

        public Quantifier Apostrophe(int exactCount)
        {
            return Append(Characters.Apostrophe(exactCount));
        }

        public Quantifier Apostrophe(int minCount, int maxCount)
        {
            return Append(Characters.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return Append(Characters.NotApostrophe());
        }

        public Quantifier NotApostrophe(int exactCount)
        {
            return Append(Characters.NotApostrophe(exactCount));
        }

        public Quantifier NotApostrophe(int minCount, int maxCount)
        {
            return Append(Characters.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return Append(Characters.LeftParenthesis());
        }

        public Quantifier LeftParenthesis(int exactCount)
        {
            return Append(Characters.LeftParenthesis(exactCount));
        }

        public Quantifier LeftParenthesis(int minCount, int maxCount)
        {
            return Append(Characters.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return Append(Characters.NotLeftParenthesis());
        }

        public Quantifier NotLeftParenthesis(int exactCount)
        {
            return Append(Characters.NotLeftParenthesis(exactCount));
        }

        public Quantifier NotLeftParenthesis(int minCount, int maxCount)
        {
            return Append(Characters.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return Append(Characters.RightParenthesis());
        }

        public Quantifier RightParenthesis(int exactCount)
        {
            return Append(Characters.RightParenthesis(exactCount));
        }

        public Quantifier RightParenthesis(int minCount, int maxCount)
        {
            return Append(Characters.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return Append(Characters.NotRightParenthesis());
        }

        public Quantifier NotRightParenthesis(int exactCount)
        {
            return Append(Characters.NotRightParenthesis(exactCount));
        }

        public Quantifier NotRightParenthesis(int minCount, int maxCount)
        {
            return Append(Characters.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return Append(Characters.Asterisk());
        }

        public Quantifier Asterisk(int exactCount)
        {
            return Append(Characters.Asterisk(exactCount));
        }

        public Quantifier Asterisk(int minCount, int maxCount)
        {
            return Append(Characters.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return Append(Characters.NotAsterisk());
        }

        public Quantifier NotAsterisk(int exactCount)
        {
            return Append(Characters.NotAsterisk(exactCount));
        }

        public Quantifier NotAsterisk(int minCount, int maxCount)
        {
            return Append(Characters.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return Append(Characters.Plus());
        }

        public Quantifier Plus(int exactCount)
        {
            return Append(Characters.Plus(exactCount));
        }

        public Quantifier Plus(int minCount, int maxCount)
        {
            return Append(Characters.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return Append(Characters.NotPlus());
        }

        public Quantifier NotPlus(int exactCount)
        {
            return Append(Characters.NotPlus(exactCount));
        }

        public Quantifier NotPlus(int minCount, int maxCount)
        {
            return Append(Characters.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return Append(Characters.Comma());
        }

        public Quantifier Comma(int exactCount)
        {
            return Append(Characters.Comma(exactCount));
        }

        public Quantifier Comma(int minCount, int maxCount)
        {
            return Append(Characters.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return Append(Characters.NotComma());
        }

        public Quantifier NotComma(int exactCount)
        {
            return Append(Characters.NotComma(exactCount));
        }

        public Quantifier NotComma(int minCount, int maxCount)
        {
            return Append(Characters.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return Append(Characters.Hyphen());
        }

        public Quantifier Hyphen(int exactCount)
        {
            return Append(Characters.Hyphen(exactCount));
        }

        public Quantifier Hyphen(int minCount, int maxCount)
        {
            return Append(Characters.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return Append(Characters.NotHyphen());
        }

        public Quantifier NotHyphen(int exactCount)
        {
            return Append(Characters.NotHyphen(exactCount));
        }

        public Quantifier NotHyphen(int minCount, int maxCount)
        {
            return Append(Characters.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return Append(Characters.Period());
        }

        public Quantifier Period(int exactCount)
        {
            return Append(Characters.Period(exactCount));
        }

        public Quantifier Period(int minCount, int maxCount)
        {
            return Append(Characters.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return Append(Characters.NotPeriod());
        }

        public Quantifier NotPeriod(int exactCount)
        {
            return Append(Characters.NotPeriod(exactCount));
        }

        public Quantifier NotPeriod(int minCount, int maxCount)
        {
            return Append(Characters.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return Append(Characters.Slash());
        }

        public Quantifier Slash(int exactCount)
        {
            return Append(Characters.Slash(exactCount));
        }

        public Quantifier Slash(int minCount, int maxCount)
        {
            return Append(Characters.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return Append(Characters.NotSlash());
        }

        public Quantifier NotSlash(int exactCount)
        {
            return Append(Characters.NotSlash(exactCount));
        }

        public Quantifier NotSlash(int minCount, int maxCount)
        {
            return Append(Characters.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return Append(Characters.Colon());
        }

        public Quantifier Colon(int exactCount)
        {
            return Append(Characters.Colon(exactCount));
        }

        public Quantifier Colon(int minCount, int maxCount)
        {
            return Append(Characters.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return Append(Characters.NotColon());
        }

        public Quantifier NotColon(int exactCount)
        {
            return Append(Characters.NotColon(exactCount));
        }

        public Quantifier NotColon(int minCount, int maxCount)
        {
            return Append(Characters.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return Append(Characters.Semicolon());
        }

        public Quantifier Semicolon(int exactCount)
        {
            return Append(Characters.Semicolon(exactCount));
        }

        public Quantifier Semicolon(int minCount, int maxCount)
        {
            return Append(Characters.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return Append(Characters.NotSemicolon());
        }

        public Quantifier NotSemicolon(int exactCount)
        {
            return Append(Characters.NotSemicolon(exactCount));
        }

        public Quantifier NotSemicolon(int minCount, int maxCount)
        {
            return Append(Characters.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return Append(Characters.LessThan());
        }

        public Quantifier LessThan(int exactCount)
        {
            return Append(Characters.LessThan(exactCount));
        }

        public Quantifier LessThan(int minCount, int maxCount)
        {
            return Append(Characters.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return Append(Characters.NotLessThan());
        }

        public Quantifier NotLessThan(int exactCount)
        {
            return Append(Characters.NotLessThan(exactCount));
        }

        public Quantifier NotLessThan(int minCount, int maxCount)
        {
            return Append(Characters.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return Append(Characters.EqualsSign());
        }

        public Quantifier EqualsSign(int exactCount)
        {
            return Append(Characters.EqualsSign(exactCount));
        }

        public Quantifier EqualsSign(int minCount, int maxCount)
        {
            return Append(Characters.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return Append(Characters.NotEqualsSign());
        }

        public Quantifier NotEqualsSign(int exactCount)
        {
            return Append(Characters.NotEqualsSign(exactCount));
        }

        public Quantifier NotEqualsSign(int minCount, int maxCount)
        {
            return Append(Characters.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return Append(Characters.GreaterThan());
        }

        public Quantifier GreaterThan(int exactCount)
        {
            return Append(Characters.GreaterThan(exactCount));
        }

        public Quantifier GreaterThan(int minCount, int maxCount)
        {
            return Append(Characters.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return Append(Characters.NotGreaterThan());
        }

        public Quantifier NotGreaterThan(int exactCount)
        {
            return Append(Characters.NotGreaterThan(exactCount));
        }

        public Quantifier NotGreaterThan(int minCount, int maxCount)
        {
            return Append(Characters.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return Append(Characters.QuestionMark());
        }

        public Quantifier QuestionMark(int exactCount)
        {
            return Append(Characters.QuestionMark(exactCount));
        }

        public Quantifier QuestionMark(int minCount, int maxCount)
        {
            return Append(Characters.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return Append(Characters.NotQuestionMark());
        }

        public Quantifier NotQuestionMark(int exactCount)
        {
            return Append(Characters.NotQuestionMark(exactCount));
        }

        public Quantifier NotQuestionMark(int minCount, int maxCount)
        {
            return Append(Characters.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return Append(Characters.At());
        }

        public Quantifier At(int exactCount)
        {
            return Append(Characters.At(exactCount));
        }

        public Quantifier At(int minCount, int maxCount)
        {
            return Append(Characters.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return Append(Characters.NotAt());
        }

        public Quantifier NotAt(int exactCount)
        {
            return Append(Characters.NotAt(exactCount));
        }

        public Quantifier NotAt(int minCount, int maxCount)
        {
            return Append(Characters.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return Append(Characters.LeftSquareBracket());
        }

        public Quantifier LeftSquareBracket(int exactCount)
        {
            return Append(Characters.LeftSquareBracket(exactCount));
        }

        public Quantifier LeftSquareBracket(int minCount, int maxCount)
        {
            return Append(Characters.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return Append(Characters.NotLeftSquareBracket());
        }

        public Quantifier NotLeftSquareBracket(int exactCount)
        {
            return Append(Characters.NotLeftSquareBracket(exactCount));
        }

        public Quantifier NotLeftSquareBracket(int minCount, int maxCount)
        {
            return Append(Characters.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return Append(Characters.Backslash());
        }

        public Quantifier Backslash(int exactCount)
        {
            return Append(Characters.Backslash(exactCount));
        }

        public Quantifier Backslash(int minCount, int maxCount)
        {
            return Append(Characters.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return Append(Characters.NotBackslash());
        }

        public Quantifier NotBackslash(int exactCount)
        {
            return Append(Characters.NotBackslash(exactCount));
        }

        public Quantifier NotBackslash(int minCount, int maxCount)
        {
            return Append(Characters.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return Append(Characters.RightSquareBracket());
        }

        public Quantifier RightSquareBracket(int exactCount)
        {
            return Append(Characters.RightSquareBracket(exactCount));
        }

        public Quantifier RightSquareBracket(int minCount, int maxCount)
        {
            return Append(Characters.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return Append(Characters.NotRightSquareBracket());
        }

        public Quantifier NotRightSquareBracket(int exactCount)
        {
            return Append(Characters.NotRightSquareBracket(exactCount));
        }

        public Quantifier NotRightSquareBracket(int minCount, int maxCount)
        {
            return Append(Characters.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return Append(Characters.CircumflexAccent());
        }

        public Quantifier CircumflexAccent(int exactCount)
        {
            return Append(Characters.CircumflexAccent(exactCount));
        }

        public Quantifier CircumflexAccent(int minCount, int maxCount)
        {
            return Append(Characters.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return Append(Characters.NotCircumflexAccent());
        }

        public Quantifier NotCircumflexAccent(int exactCount)
        {
            return Append(Characters.NotCircumflexAccent(exactCount));
        }

        public Quantifier NotCircumflexAccent(int minCount, int maxCount)
        {
            return Append(Characters.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return Append(Characters.Underscore());
        }

        public Quantifier Underscore(int exactCount)
        {
            return Append(Characters.Underscore(exactCount));
        }

        public Quantifier Underscore(int minCount, int maxCount)
        {
            return Append(Characters.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return Append(Characters.NotUnderscore());
        }

        public Quantifier NotUnderscore(int exactCount)
        {
            return Append(Characters.NotUnderscore(exactCount));
        }

        public Quantifier NotUnderscore(int minCount, int maxCount)
        {
            return Append(Characters.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return Append(Characters.GraveAccent());
        }

        public Quantifier GraveAccent(int exactCount)
        {
            return Append(Characters.GraveAccent(exactCount));
        }

        public Quantifier GraveAccent(int minCount, int maxCount)
        {
            return Append(Characters.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return Append(Characters.NotGraveAccent());
        }

        public Quantifier NotGraveAccent(int exactCount)
        {
            return Append(Characters.NotGraveAccent(exactCount));
        }

        public Quantifier NotGraveAccent(int minCount, int maxCount)
        {
            return Append(Characters.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return Append(Characters.LeftCurlyBracket());
        }

        public Quantifier LeftCurlyBracket(int exactCount)
        {
            return Append(Characters.LeftCurlyBracket(exactCount));
        }

        public Quantifier LeftCurlyBracket(int minCount, int maxCount)
        {
            return Append(Characters.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return Append(Characters.NotLeftCurlyBracket());
        }

        public Quantifier NotLeftCurlyBracket(int exactCount)
        {
            return Append(Characters.NotLeftCurlyBracket(exactCount));
        }

        public Quantifier NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return Append(Characters.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return Append(Characters.VerticalLine());
        }

        public Quantifier VerticalLine(int exactCount)
        {
            return Append(Characters.VerticalLine(exactCount));
        }

        public Quantifier VerticalLine(int minCount, int maxCount)
        {
            return Append(Characters.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return Append(Characters.NotVerticalLine());
        }

        public Quantifier NotVerticalLine(int exactCount)
        {
            return Append(Characters.NotVerticalLine(exactCount));
        }

        public Quantifier NotVerticalLine(int minCount, int maxCount)
        {
            return Append(Characters.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return Append(Characters.RightCurlyBracket());
        }

        public Quantifier RightCurlyBracket(int exactCount)
        {
            return Append(Characters.RightCurlyBracket(exactCount));
        }

        public Quantifier RightCurlyBracket(int minCount, int maxCount)
        {
            return Append(Characters.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return Append(Characters.NotRightCurlyBracket());
        }

        public Quantifier NotRightCurlyBracket(int exactCount)
        {
            return Append(Characters.NotRightCurlyBracket(exactCount));
        }

        public Quantifier NotRightCurlyBracket(int minCount, int maxCount)
        {
            return Append(Characters.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return Append(Characters.Tilde());
        }

        public Quantifier Tilde(int exactCount)
        {
            return Append(Characters.Tilde(exactCount));
        }

        public Quantifier Tilde(int minCount, int maxCount)
        {
            return Append(Characters.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return Append(Characters.NotTilde());
        }

        public Quantifier NotTilde(int exactCount)
        {
            return Append(Characters.NotTilde(exactCount));
        }

        public Quantifier NotTilde(int minCount, int maxCount)
        {
            return Append(Characters.NotTilde(minCount, maxCount));
        }
    }
}
