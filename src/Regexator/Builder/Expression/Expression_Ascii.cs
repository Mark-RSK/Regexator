// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Tab()
        {
            return Append(Expressions.Tab());
        }

        public Quantifier Tab(int exactCount)
        {
            return Append(Expressions.Tab(exactCount));
        }

        public Quantifier Tab(int minCount, int maxCount)
        {
            return Append(Expressions.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return Append(Expressions.NotTab());
        }

        public Quantifier NotTab(int exactCount)
        {
            return Append(Expressions.NotTab(exactCount));
        }

        public Quantifier NotTab(int minCount, int maxCount)
        {
            return Append(Expressions.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return Append(Expressions.Linefeed());
        }

        public Quantifier Linefeed(int exactCount)
        {
            return Append(Expressions.Linefeed(exactCount));
        }

        public Quantifier Linefeed(int minCount, int maxCount)
        {
            return Append(Expressions.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return Append(Expressions.NotLinefeed());
        }

        public Quantifier NotLinefeed(int exactCount)
        {
            return Append(Expressions.NotLinefeed(exactCount));
        }

        public Quantifier NotLinefeed(int minCount, int maxCount)
        {
            return Append(Expressions.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return Append(Expressions.CarriageReturn());
        }

        public Quantifier CarriageReturn(int exactCount)
        {
            return Append(Expressions.CarriageReturn(exactCount));
        }

        public Quantifier CarriageReturn(int minCount, int maxCount)
        {
            return Append(Expressions.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return Append(Expressions.NotCarriageReturn());
        }

        public Quantifier NotCarriageReturn(int exactCount)
        {
            return Append(Expressions.NotCarriageReturn(exactCount));
        }

        public Quantifier NotCarriageReturn(int minCount, int maxCount)
        {
            return Append(Expressions.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return Append(Expressions.Space());
        }

        public Quantifier Space(int exactCount)
        {
            return Append(Expressions.Space(exactCount));
        }

        public Quantifier Space(int minCount, int maxCount)
        {
            return Append(Expressions.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return Append(Expressions.NotSpace());
        }

        public Quantifier NotSpace(int exactCount)
        {
            return Append(Expressions.NotSpace(exactCount));
        }

        public Quantifier NotSpace(int minCount, int maxCount)
        {
            return Append(Expressions.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return Append(Expressions.ExclamationMark());
        }

        public Quantifier ExclamationMark(int exactCount)
        {
            return Append(Expressions.ExclamationMark(exactCount));
        }

        public Quantifier ExclamationMark(int minCount, int maxCount)
        {
            return Append(Expressions.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return Append(Expressions.NotExclamationMark());
        }

        public Quantifier NotExclamationMark(int exactCount)
        {
            return Append(Expressions.NotExclamationMark(exactCount));
        }

        public Quantifier NotExclamationMark(int minCount, int maxCount)
        {
            return Append(Expressions.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuotationMark()
        {
            return Append(Expressions.QuotationMark());
        }

        public Quantifier QuotationMark(int exactCount)
        {
            return Append(Expressions.QuotationMark(exactCount));
        }

        public Quantifier QuotationMark(int minCount, int maxCount)
        {
            return Append(Expressions.QuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuotationMark()
        {
            return Append(Expressions.NotQuotationMark());
        }

        public Quantifier NotQuotationMark(int exactCount)
        {
            return Append(Expressions.NotQuotationMark(exactCount));
        }

        public Quantifier NotQuotationMark(int minCount, int maxCount)
        {
            return Append(Expressions.NotQuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return Append(Expressions.NumberSign());
        }

        public Quantifier NumberSign(int exactCount)
        {
            return Append(Expressions.NumberSign(exactCount));
        }

        public Quantifier NumberSign(int minCount, int maxCount)
        {
            return Append(Expressions.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return Append(Expressions.NotNumberSign());
        }

        public Quantifier NotNumberSign(int exactCount)
        {
            return Append(Expressions.NotNumberSign(exactCount));
        }

        public Quantifier NotNumberSign(int minCount, int maxCount)
        {
            return Append(Expressions.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return Append(Expressions.Dollar());
        }

        public Quantifier Dollar(int exactCount)
        {
            return Append(Expressions.Dollar(exactCount));
        }

        public Quantifier Dollar(int minCount, int maxCount)
        {
            return Append(Expressions.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return Append(Expressions.NotDollar());
        }

        public Quantifier NotDollar(int exactCount)
        {
            return Append(Expressions.NotDollar(exactCount));
        }

        public Quantifier NotDollar(int minCount, int maxCount)
        {
            return Append(Expressions.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return Append(Expressions.Percent());
        }

        public Quantifier Percent(int exactCount)
        {
            return Append(Expressions.Percent(exactCount));
        }

        public Quantifier Percent(int minCount, int maxCount)
        {
            return Append(Expressions.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return Append(Expressions.NotPercent());
        }

        public Quantifier NotPercent(int exactCount)
        {
            return Append(Expressions.NotPercent(exactCount));
        }

        public Quantifier NotPercent(int minCount, int maxCount)
        {
            return Append(Expressions.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return Append(Expressions.Ampersand());
        }

        public Quantifier Ampersand(int exactCount)
        {
            return Append(Expressions.Ampersand(exactCount));
        }

        public Quantifier Ampersand(int minCount, int maxCount)
        {
            return Append(Expressions.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return Append(Expressions.NotAmpersand());
        }

        public Quantifier NotAmpersand(int exactCount)
        {
            return Append(Expressions.NotAmpersand(exactCount));
        }

        public Quantifier NotAmpersand(int minCount, int maxCount)
        {
            return Append(Expressions.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return Append(Expressions.Apostrophe());
        }

        public Quantifier Apostrophe(int exactCount)
        {
            return Append(Expressions.Apostrophe(exactCount));
        }

        public Quantifier Apostrophe(int minCount, int maxCount)
        {
            return Append(Expressions.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return Append(Expressions.NotApostrophe());
        }

        public Quantifier NotApostrophe(int exactCount)
        {
            return Append(Expressions.NotApostrophe(exactCount));
        }

        public Quantifier NotApostrophe(int minCount, int maxCount)
        {
            return Append(Expressions.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return Append(Expressions.LeftParenthesis());
        }

        public Quantifier LeftParenthesis(int exactCount)
        {
            return Append(Expressions.LeftParenthesis(exactCount));
        }

        public Quantifier LeftParenthesis(int minCount, int maxCount)
        {
            return Append(Expressions.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return Append(Expressions.NotLeftParenthesis());
        }

        public Quantifier NotLeftParenthesis(int exactCount)
        {
            return Append(Expressions.NotLeftParenthesis(exactCount));
        }

        public Quantifier NotLeftParenthesis(int minCount, int maxCount)
        {
            return Append(Expressions.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return Append(Expressions.RightParenthesis());
        }

        public Quantifier RightParenthesis(int exactCount)
        {
            return Append(Expressions.RightParenthesis(exactCount));
        }

        public Quantifier RightParenthesis(int minCount, int maxCount)
        {
            return Append(Expressions.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return Append(Expressions.NotRightParenthesis());
        }

        public Quantifier NotRightParenthesis(int exactCount)
        {
            return Append(Expressions.NotRightParenthesis(exactCount));
        }

        public Quantifier NotRightParenthesis(int minCount, int maxCount)
        {
            return Append(Expressions.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return Append(Expressions.Asterisk());
        }

        public Quantifier Asterisk(int exactCount)
        {
            return Append(Expressions.Asterisk(exactCount));
        }

        public Quantifier Asterisk(int minCount, int maxCount)
        {
            return Append(Expressions.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return Append(Expressions.NotAsterisk());
        }

        public Quantifier NotAsterisk(int exactCount)
        {
            return Append(Expressions.NotAsterisk(exactCount));
        }

        public Quantifier NotAsterisk(int minCount, int maxCount)
        {
            return Append(Expressions.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return Append(Expressions.Plus());
        }

        public Quantifier Plus(int exactCount)
        {
            return Append(Expressions.Plus(exactCount));
        }

        public Quantifier Plus(int minCount, int maxCount)
        {
            return Append(Expressions.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return Append(Expressions.NotPlus());
        }

        public Quantifier NotPlus(int exactCount)
        {
            return Append(Expressions.NotPlus(exactCount));
        }

        public Quantifier NotPlus(int minCount, int maxCount)
        {
            return Append(Expressions.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return Append(Expressions.Comma());
        }

        public Quantifier Comma(int exactCount)
        {
            return Append(Expressions.Comma(exactCount));
        }

        public Quantifier Comma(int minCount, int maxCount)
        {
            return Append(Expressions.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return Append(Expressions.NotComma());
        }

        public Quantifier NotComma(int exactCount)
        {
            return Append(Expressions.NotComma(exactCount));
        }

        public Quantifier NotComma(int minCount, int maxCount)
        {
            return Append(Expressions.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return Append(Expressions.Hyphen());
        }

        public Quantifier Hyphen(int exactCount)
        {
            return Append(Expressions.Hyphen(exactCount));
        }

        public Quantifier Hyphen(int minCount, int maxCount)
        {
            return Append(Expressions.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return Append(Expressions.NotHyphen());
        }

        public Quantifier NotHyphen(int exactCount)
        {
            return Append(Expressions.NotHyphen(exactCount));
        }

        public Quantifier NotHyphen(int minCount, int maxCount)
        {
            return Append(Expressions.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return Append(Expressions.Period());
        }

        public Quantifier Period(int exactCount)
        {
            return Append(Expressions.Period(exactCount));
        }

        public Quantifier Period(int minCount, int maxCount)
        {
            return Append(Expressions.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return Append(Expressions.NotPeriod());
        }

        public Quantifier NotPeriod(int exactCount)
        {
            return Append(Expressions.NotPeriod(exactCount));
        }

        public Quantifier NotPeriod(int minCount, int maxCount)
        {
            return Append(Expressions.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return Append(Expressions.Slash());
        }

        public Quantifier Slash(int exactCount)
        {
            return Append(Expressions.Slash(exactCount));
        }

        public Quantifier Slash(int minCount, int maxCount)
        {
            return Append(Expressions.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return Append(Expressions.NotSlash());
        }

        public Quantifier NotSlash(int exactCount)
        {
            return Append(Expressions.NotSlash(exactCount));
        }

        public Quantifier NotSlash(int minCount, int maxCount)
        {
            return Append(Expressions.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return Append(Expressions.Colon());
        }

        public Quantifier Colon(int exactCount)
        {
            return Append(Expressions.Colon(exactCount));
        }

        public Quantifier Colon(int minCount, int maxCount)
        {
            return Append(Expressions.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return Append(Expressions.NotColon());
        }

        public Quantifier NotColon(int exactCount)
        {
            return Append(Expressions.NotColon(exactCount));
        }

        public Quantifier NotColon(int minCount, int maxCount)
        {
            return Append(Expressions.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return Append(Expressions.Semicolon());
        }

        public Quantifier Semicolon(int exactCount)
        {
            return Append(Expressions.Semicolon(exactCount));
        }

        public Quantifier Semicolon(int minCount, int maxCount)
        {
            return Append(Expressions.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return Append(Expressions.NotSemicolon());
        }

        public Quantifier NotSemicolon(int exactCount)
        {
            return Append(Expressions.NotSemicolon(exactCount));
        }

        public Quantifier NotSemicolon(int minCount, int maxCount)
        {
            return Append(Expressions.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return Append(Expressions.LessThan());
        }

        public Quantifier LessThan(int exactCount)
        {
            return Append(Expressions.LessThan(exactCount));
        }

        public Quantifier LessThan(int minCount, int maxCount)
        {
            return Append(Expressions.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return Append(Expressions.NotLessThan());
        }

        public Quantifier NotLessThan(int exactCount)
        {
            return Append(Expressions.NotLessThan(exactCount));
        }

        public Quantifier NotLessThan(int minCount, int maxCount)
        {
            return Append(Expressions.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return Append(Expressions.EqualsSign());
        }

        public Quantifier EqualsSign(int exactCount)
        {
            return Append(Expressions.EqualsSign(exactCount));
        }

        public Quantifier EqualsSign(int minCount, int maxCount)
        {
            return Append(Expressions.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return Append(Expressions.NotEqualsSign());
        }

        public Quantifier NotEqualsSign(int exactCount)
        {
            return Append(Expressions.NotEqualsSign(exactCount));
        }

        public Quantifier NotEqualsSign(int minCount, int maxCount)
        {
            return Append(Expressions.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return Append(Expressions.GreaterThan());
        }

        public Quantifier GreaterThan(int exactCount)
        {
            return Append(Expressions.GreaterThan(exactCount));
        }

        public Quantifier GreaterThan(int minCount, int maxCount)
        {
            return Append(Expressions.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return Append(Expressions.NotGreaterThan());
        }

        public Quantifier NotGreaterThan(int exactCount)
        {
            return Append(Expressions.NotGreaterThan(exactCount));
        }

        public Quantifier NotGreaterThan(int minCount, int maxCount)
        {
            return Append(Expressions.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return Append(Expressions.QuestionMark());
        }

        public Quantifier QuestionMark(int exactCount)
        {
            return Append(Expressions.QuestionMark(exactCount));
        }

        public Quantifier QuestionMark(int minCount, int maxCount)
        {
            return Append(Expressions.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return Append(Expressions.NotQuestionMark());
        }

        public Quantifier NotQuestionMark(int exactCount)
        {
            return Append(Expressions.NotQuestionMark(exactCount));
        }

        public Quantifier NotQuestionMark(int minCount, int maxCount)
        {
            return Append(Expressions.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return Append(Expressions.At());
        }

        public Quantifier At(int exactCount)
        {
            return Append(Expressions.At(exactCount));
        }

        public Quantifier At(int minCount, int maxCount)
        {
            return Append(Expressions.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return Append(Expressions.NotAt());
        }

        public Quantifier NotAt(int exactCount)
        {
            return Append(Expressions.NotAt(exactCount));
        }

        public Quantifier NotAt(int minCount, int maxCount)
        {
            return Append(Expressions.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return Append(Expressions.LeftSquareBracket());
        }

        public Quantifier LeftSquareBracket(int exactCount)
        {
            return Append(Expressions.LeftSquareBracket(exactCount));
        }

        public Quantifier LeftSquareBracket(int minCount, int maxCount)
        {
            return Append(Expressions.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return Append(Expressions.NotLeftSquareBracket());
        }

        public Quantifier NotLeftSquareBracket(int exactCount)
        {
            return Append(Expressions.NotLeftSquareBracket(exactCount));
        }

        public Quantifier NotLeftSquareBracket(int minCount, int maxCount)
        {
            return Append(Expressions.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return Append(Expressions.Backslash());
        }

        public Quantifier Backslash(int exactCount)
        {
            return Append(Expressions.Backslash(exactCount));
        }

        public Quantifier Backslash(int minCount, int maxCount)
        {
            return Append(Expressions.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return Append(Expressions.NotBackslash());
        }

        public Quantifier NotBackslash(int exactCount)
        {
            return Append(Expressions.NotBackslash(exactCount));
        }

        public Quantifier NotBackslash(int minCount, int maxCount)
        {
            return Append(Expressions.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return Append(Expressions.RightSquareBracket());
        }

        public Quantifier RightSquareBracket(int exactCount)
        {
            return Append(Expressions.RightSquareBracket(exactCount));
        }

        public Quantifier RightSquareBracket(int minCount, int maxCount)
        {
            return Append(Expressions.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return Append(Expressions.NotRightSquareBracket());
        }

        public Quantifier NotRightSquareBracket(int exactCount)
        {
            return Append(Expressions.NotRightSquareBracket(exactCount));
        }

        public Quantifier NotRightSquareBracket(int minCount, int maxCount)
        {
            return Append(Expressions.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return Append(Expressions.CircumflexAccent());
        }

        public Quantifier CircumflexAccent(int exactCount)
        {
            return Append(Expressions.CircumflexAccent(exactCount));
        }

        public Quantifier CircumflexAccent(int minCount, int maxCount)
        {
            return Append(Expressions.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return Append(Expressions.NotCircumflexAccent());
        }

        public Quantifier NotCircumflexAccent(int exactCount)
        {
            return Append(Expressions.NotCircumflexAccent(exactCount));
        }

        public Quantifier NotCircumflexAccent(int minCount, int maxCount)
        {
            return Append(Expressions.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return Append(Expressions.Underscore());
        }

        public Quantifier Underscore(int exactCount)
        {
            return Append(Expressions.Underscore(exactCount));
        }

        public Quantifier Underscore(int minCount, int maxCount)
        {
            return Append(Expressions.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return Append(Expressions.NotUnderscore());
        }

        public Quantifier NotUnderscore(int exactCount)
        {
            return Append(Expressions.NotUnderscore(exactCount));
        }

        public Quantifier NotUnderscore(int minCount, int maxCount)
        {
            return Append(Expressions.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return Append(Expressions.GraveAccent());
        }

        public Quantifier GraveAccent(int exactCount)
        {
            return Append(Expressions.GraveAccent(exactCount));
        }

        public Quantifier GraveAccent(int minCount, int maxCount)
        {
            return Append(Expressions.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return Append(Expressions.NotGraveAccent());
        }

        public Quantifier NotGraveAccent(int exactCount)
        {
            return Append(Expressions.NotGraveAccent(exactCount));
        }

        public Quantifier NotGraveAccent(int minCount, int maxCount)
        {
            return Append(Expressions.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return Append(Expressions.LeftCurlyBracket());
        }

        public Quantifier LeftCurlyBracket(int exactCount)
        {
            return Append(Expressions.LeftCurlyBracket(exactCount));
        }

        public Quantifier LeftCurlyBracket(int minCount, int maxCount)
        {
            return Append(Expressions.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return Append(Expressions.NotLeftCurlyBracket());
        }

        public Quantifier NotLeftCurlyBracket(int exactCount)
        {
            return Append(Expressions.NotLeftCurlyBracket(exactCount));
        }

        public Quantifier NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return Append(Expressions.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return Append(Expressions.VerticalLine());
        }

        public Quantifier VerticalLine(int exactCount)
        {
            return Append(Expressions.VerticalLine(exactCount));
        }

        public Quantifier VerticalLine(int minCount, int maxCount)
        {
            return Append(Expressions.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return Append(Expressions.NotVerticalLine());
        }

        public Quantifier NotVerticalLine(int exactCount)
        {
            return Append(Expressions.NotVerticalLine(exactCount));
        }

        public Quantifier NotVerticalLine(int minCount, int maxCount)
        {
            return Append(Expressions.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return Append(Expressions.RightCurlyBracket());
        }

        public Quantifier RightCurlyBracket(int exactCount)
        {
            return Append(Expressions.RightCurlyBracket(exactCount));
        }

        public Quantifier RightCurlyBracket(int minCount, int maxCount)
        {
            return Append(Expressions.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return Append(Expressions.NotRightCurlyBracket());
        }

        public Quantifier NotRightCurlyBracket(int exactCount)
        {
            return Append(Expressions.NotRightCurlyBracket(exactCount));
        }

        public Quantifier NotRightCurlyBracket(int minCount, int maxCount)
        {
            return Append(Expressions.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return Append(Expressions.Tilde());
        }

        public Quantifier Tilde(int exactCount)
        {
            return Append(Expressions.Tilde(exactCount));
        }

        public Quantifier Tilde(int minCount, int maxCount)
        {
            return Append(Expressions.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return Append(Expressions.NotTilde());
        }

        public Quantifier NotTilde(int exactCount)
        {
            return Append(Expressions.NotTilde(exactCount));
        }

        public Quantifier NotTilde(int minCount, int maxCount)
        {
            return Append(Expressions.NotTilde(minCount, maxCount));
        }
    }
}
