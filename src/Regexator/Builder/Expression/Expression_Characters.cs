// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Char(char value)
        {
            return AppendInternal(Characters.Char(value));
        }

        public QuantifiableExpression Char(int charCode)
        {
            return AppendInternal(Characters.Char(charCode));
        }

        public QuantifiableExpression Char(AsciiChar value)
        {
            return AppendInternal(Characters.Char(value));
        }

        public QuantifiableExpression Char(CharClass value)
        {
            return AppendInternal(Characters.Char(value));
        }

        public QuantifiableExpression UnicodeBlock(UnicodeBlock block)
        {
            return AppendInternal(Characters.UnicodeBlock(block));
        }

        public QuantifiableExpression UnicodeCategory(UnicodeCategory category)
        {
            return AppendInternal(Characters.UnicodeCategory(category));
        }

        public QuantifiableExpression NotChar(char value)
        {
            return AppendInternal(Characters.NotChar(value));
        }

        public QuantifiableExpression NotChar(int charCode)
        {
            return AppendInternal(Characters.NotChar(charCode));
        }

        public QuantifiableExpression NotChar(AsciiChar value)
        {
            return AppendInternal(Characters.NotChar(value));
        }

        public QuantifiableExpression NotUnicodeBlock(UnicodeBlock block)
        {
            return AppendInternal(Characters.NotUnicodeBlock(block));
        }

        public QuantifiableExpression NotUnicodeCategory(UnicodeCategory category)
        {
            return AppendInternal(Characters.NotUnicodeCategory(category));
        }

        public QuantifiableExpression Tab()
        {
            return AppendInternal(Characters.Tab());
        }

        public Quantifier Tab(int exactCount)
        {
            return AppendInternal(Characters.Tab(exactCount));
        }

        public Quantifier Tab(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return AppendInternal(Characters.NotTab());
        }

        public Quantifier NotTab(int exactCount)
        {
            return AppendInternal(Characters.NotTab(exactCount));
        }

        public Quantifier NotTab(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return AppendInternal(Characters.Linefeed());
        }

        public Quantifier Linefeed(int exactCount)
        {
            return AppendInternal(Characters.Linefeed(exactCount));
        }

        public Quantifier Linefeed(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return AppendInternal(Characters.NotLinefeed());
        }

        public Quantifier NotLinefeed(int exactCount)
        {
            return AppendInternal(Characters.NotLinefeed(exactCount));
        }

        public Quantifier NotLinefeed(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return AppendInternal(Characters.CarriageReturn());
        }

        public Quantifier CarriageReturn(int exactCount)
        {
            return AppendInternal(Characters.CarriageReturn(exactCount));
        }

        public Quantifier CarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Characters.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return AppendInternal(Characters.NotCarriageReturn());
        }

        public Quantifier NotCarriageReturn(int exactCount)
        {
            return AppendInternal(Characters.NotCarriageReturn(exactCount));
        }

        public Quantifier NotCarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return AppendInternal(Characters.Space());
        }

        public Quantifier Space(int exactCount)
        {
            return AppendInternal(Characters.Space(exactCount));
        }

        public Quantifier Space(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return AppendInternal(Characters.NotSpace());
        }

        public Quantifier NotSpace(int exactCount)
        {
            return AppendInternal(Characters.NotSpace(exactCount));
        }

        public Quantifier NotSpace(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return AppendInternal(Characters.ExclamationMark());
        }

        public Quantifier ExclamationMark(int exactCount)
        {
            return AppendInternal(Characters.ExclamationMark(exactCount));
        }

        public Quantifier ExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return AppendInternal(Characters.NotExclamationMark());
        }

        public Quantifier NotExclamationMark(int exactCount)
        {
            return AppendInternal(Characters.NotExclamationMark(exactCount));
        }

        public Quantifier NotExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuotationMark()
        {
            return AppendInternal(Characters.QuotationMark());
        }

        public Quantifier QuotationMark(int exactCount)
        {
            return AppendInternal(Characters.QuotationMark(exactCount));
        }

        public Quantifier QuotationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.QuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuotationMark()
        {
            return AppendInternal(Characters.NotQuotationMark());
        }

        public Quantifier NotQuotationMark(int exactCount)
        {
            return AppendInternal(Characters.NotQuotationMark(exactCount));
        }

        public Quantifier NotQuotationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotQuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return AppendInternal(Characters.NumberSign());
        }

        public Quantifier NumberSign(int exactCount)
        {
            return AppendInternal(Characters.NumberSign(exactCount));
        }

        public Quantifier NumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return AppendInternal(Characters.NotNumberSign());
        }

        public Quantifier NotNumberSign(int exactCount)
        {
            return AppendInternal(Characters.NotNumberSign(exactCount));
        }

        public Quantifier NotNumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return AppendInternal(Characters.Dollar());
        }

        public Quantifier Dollar(int exactCount)
        {
            return AppendInternal(Characters.Dollar(exactCount));
        }

        public Quantifier Dollar(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return AppendInternal(Characters.NotDollar());
        }

        public Quantifier NotDollar(int exactCount)
        {
            return AppendInternal(Characters.NotDollar(exactCount));
        }

        public Quantifier NotDollar(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return AppendInternal(Characters.Percent());
        }

        public Quantifier Percent(int exactCount)
        {
            return AppendInternal(Characters.Percent(exactCount));
        }

        public Quantifier Percent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return AppendInternal(Characters.NotPercent());
        }

        public Quantifier NotPercent(int exactCount)
        {
            return AppendInternal(Characters.NotPercent(exactCount));
        }

        public Quantifier NotPercent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return AppendInternal(Characters.Ampersand());
        }

        public Quantifier Ampersand(int exactCount)
        {
            return AppendInternal(Characters.Ampersand(exactCount));
        }

        public Quantifier Ampersand(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return AppendInternal(Characters.NotAmpersand());
        }

        public Quantifier NotAmpersand(int exactCount)
        {
            return AppendInternal(Characters.NotAmpersand(exactCount));
        }

        public Quantifier NotAmpersand(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return AppendInternal(Characters.Apostrophe());
        }

        public Quantifier Apostrophe(int exactCount)
        {
            return AppendInternal(Characters.Apostrophe(exactCount));
        }

        public Quantifier Apostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return AppendInternal(Characters.NotApostrophe());
        }

        public Quantifier NotApostrophe(int exactCount)
        {
            return AppendInternal(Characters.NotApostrophe(exactCount));
        }

        public Quantifier NotApostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return AppendInternal(Characters.LeftParenthesis());
        }

        public Quantifier LeftParenthesis(int exactCount)
        {
            return AppendInternal(Characters.LeftParenthesis(exactCount));
        }

        public Quantifier LeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return AppendInternal(Characters.NotLeftParenthesis());
        }

        public Quantifier NotLeftParenthesis(int exactCount)
        {
            return AppendInternal(Characters.NotLeftParenthesis(exactCount));
        }

        public Quantifier NotLeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return AppendInternal(Characters.RightParenthesis());
        }

        public Quantifier RightParenthesis(int exactCount)
        {
            return AppendInternal(Characters.RightParenthesis(exactCount));
        }

        public Quantifier RightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return AppendInternal(Characters.NotRightParenthesis());
        }

        public Quantifier NotRightParenthesis(int exactCount)
        {
            return AppendInternal(Characters.NotRightParenthesis(exactCount));
        }

        public Quantifier NotRightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return AppendInternal(Characters.Asterisk());
        }

        public Quantifier Asterisk(int exactCount)
        {
            return AppendInternal(Characters.Asterisk(exactCount));
        }

        public Quantifier Asterisk(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return AppendInternal(Characters.NotAsterisk());
        }

        public Quantifier NotAsterisk(int exactCount)
        {
            return AppendInternal(Characters.NotAsterisk(exactCount));
        }

        public Quantifier NotAsterisk(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return AppendInternal(Characters.Plus());
        }

        public Quantifier Plus(int exactCount)
        {
            return AppendInternal(Characters.Plus(exactCount));
        }

        public Quantifier Plus(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return AppendInternal(Characters.NotPlus());
        }

        public Quantifier NotPlus(int exactCount)
        {
            return AppendInternal(Characters.NotPlus(exactCount));
        }

        public Quantifier NotPlus(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return AppendInternal(Characters.Comma());
        }

        public Quantifier Comma(int exactCount)
        {
            return AppendInternal(Characters.Comma(exactCount));
        }

        public Quantifier Comma(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return AppendInternal(Characters.NotComma());
        }

        public Quantifier NotComma(int exactCount)
        {
            return AppendInternal(Characters.NotComma(exactCount));
        }

        public Quantifier NotComma(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return AppendInternal(Characters.Hyphen());
        }

        public Quantifier Hyphen(int exactCount)
        {
            return AppendInternal(Characters.Hyphen(exactCount));
        }

        public Quantifier Hyphen(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return AppendInternal(Characters.NotHyphen());
        }

        public Quantifier NotHyphen(int exactCount)
        {
            return AppendInternal(Characters.NotHyphen(exactCount));
        }

        public Quantifier NotHyphen(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return AppendInternal(Characters.Period());
        }

        public Quantifier Period(int exactCount)
        {
            return AppendInternal(Characters.Period(exactCount));
        }

        public Quantifier Period(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return AppendInternal(Characters.NotPeriod());
        }

        public Quantifier NotPeriod(int exactCount)
        {
            return AppendInternal(Characters.NotPeriod(exactCount));
        }

        public Quantifier NotPeriod(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return AppendInternal(Characters.Slash());
        }

        public Quantifier Slash(int exactCount)
        {
            return AppendInternal(Characters.Slash(exactCount));
        }

        public Quantifier Slash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return AppendInternal(Characters.NotSlash());
        }

        public Quantifier NotSlash(int exactCount)
        {
            return AppendInternal(Characters.NotSlash(exactCount));
        }

        public Quantifier NotSlash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return AppendInternal(Characters.Colon());
        }

        public Quantifier Colon(int exactCount)
        {
            return AppendInternal(Characters.Colon(exactCount));
        }

        public Quantifier Colon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return AppendInternal(Characters.NotColon());
        }

        public Quantifier NotColon(int exactCount)
        {
            return AppendInternal(Characters.NotColon(exactCount));
        }

        public Quantifier NotColon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return AppendInternal(Characters.Semicolon());
        }

        public Quantifier Semicolon(int exactCount)
        {
            return AppendInternal(Characters.Semicolon(exactCount));
        }

        public Quantifier Semicolon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return AppendInternal(Characters.NotSemicolon());
        }

        public Quantifier NotSemicolon(int exactCount)
        {
            return AppendInternal(Characters.NotSemicolon(exactCount));
        }

        public Quantifier NotSemicolon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return AppendInternal(Characters.LessThan());
        }

        public Quantifier LessThan(int exactCount)
        {
            return AppendInternal(Characters.LessThan(exactCount));
        }

        public Quantifier LessThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return AppendInternal(Characters.NotLessThan());
        }

        public Quantifier NotLessThan(int exactCount)
        {
            return AppendInternal(Characters.NotLessThan(exactCount));
        }

        public Quantifier NotLessThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return AppendInternal(Characters.EqualsSign());
        }

        public Quantifier EqualsSign(int exactCount)
        {
            return AppendInternal(Characters.EqualsSign(exactCount));
        }

        public Quantifier EqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return AppendInternal(Characters.NotEqualsSign());
        }

        public Quantifier NotEqualsSign(int exactCount)
        {
            return AppendInternal(Characters.NotEqualsSign(exactCount));
        }

        public Quantifier NotEqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return AppendInternal(Characters.GreaterThan());
        }

        public Quantifier GreaterThan(int exactCount)
        {
            return AppendInternal(Characters.GreaterThan(exactCount));
        }

        public Quantifier GreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return AppendInternal(Characters.NotGreaterThan());
        }

        public Quantifier NotGreaterThan(int exactCount)
        {
            return AppendInternal(Characters.NotGreaterThan(exactCount));
        }

        public Quantifier NotGreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return AppendInternal(Characters.QuestionMark());
        }

        public Quantifier QuestionMark(int exactCount)
        {
            return AppendInternal(Characters.QuestionMark(exactCount));
        }

        public Quantifier QuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return AppendInternal(Characters.NotQuestionMark());
        }

        public Quantifier NotQuestionMark(int exactCount)
        {
            return AppendInternal(Characters.NotQuestionMark(exactCount));
        }

        public Quantifier NotQuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return AppendInternal(Characters.At());
        }

        public Quantifier At(int exactCount)
        {
            return AppendInternal(Characters.At(exactCount));
        }

        public Quantifier At(int minCount, int maxCount)
        {
            return AppendInternal(Characters.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return AppendInternal(Characters.NotAt());
        }

        public Quantifier NotAt(int exactCount)
        {
            return AppendInternal(Characters.NotAt(exactCount));
        }

        public Quantifier NotAt(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return AppendInternal(Characters.LeftSquareBracket());
        }

        public Quantifier LeftSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.LeftSquareBracket(exactCount));
        }

        public Quantifier LeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return AppendInternal(Characters.NotLeftSquareBracket());
        }

        public Quantifier NotLeftSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.NotLeftSquareBracket(exactCount));
        }

        public Quantifier NotLeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return AppendInternal(Characters.Backslash());
        }

        public Quantifier Backslash(int exactCount)
        {
            return AppendInternal(Characters.Backslash(exactCount));
        }

        public Quantifier Backslash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return AppendInternal(Characters.NotBackslash());
        }

        public Quantifier NotBackslash(int exactCount)
        {
            return AppendInternal(Characters.NotBackslash(exactCount));
        }

        public Quantifier NotBackslash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return AppendInternal(Characters.RightSquareBracket());
        }

        public Quantifier RightSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.RightSquareBracket(exactCount));
        }

        public Quantifier RightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return AppendInternal(Characters.NotRightSquareBracket());
        }

        public Quantifier NotRightSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.NotRightSquareBracket(exactCount));
        }

        public Quantifier NotRightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return AppendInternal(Characters.CircumflexAccent());
        }

        public Quantifier CircumflexAccent(int exactCount)
        {
            return AppendInternal(Characters.CircumflexAccent(exactCount));
        }

        public Quantifier CircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return AppendInternal(Characters.NotCircumflexAccent());
        }

        public Quantifier NotCircumflexAccent(int exactCount)
        {
            return AppendInternal(Characters.NotCircumflexAccent(exactCount));
        }

        public Quantifier NotCircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return AppendInternal(Characters.Underscore());
        }

        public Quantifier Underscore(int exactCount)
        {
            return AppendInternal(Characters.Underscore(exactCount));
        }

        public Quantifier Underscore(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return AppendInternal(Characters.NotUnderscore());
        }

        public Quantifier NotUnderscore(int exactCount)
        {
            return AppendInternal(Characters.NotUnderscore(exactCount));
        }

        public Quantifier NotUnderscore(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return AppendInternal(Characters.GraveAccent());
        }

        public Quantifier GraveAccent(int exactCount)
        {
            return AppendInternal(Characters.GraveAccent(exactCount));
        }

        public Quantifier GraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return AppendInternal(Characters.NotGraveAccent());
        }

        public Quantifier NotGraveAccent(int exactCount)
        {
            return AppendInternal(Characters.NotGraveAccent(exactCount));
        }

        public Quantifier NotGraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return AppendInternal(Characters.LeftCurlyBracket());
        }

        public Quantifier LeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.LeftCurlyBracket(exactCount));
        }

        public Quantifier LeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return AppendInternal(Characters.NotLeftCurlyBracket());
        }

        public Quantifier NotLeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.NotLeftCurlyBracket(exactCount));
        }

        public Quantifier NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return AppendInternal(Characters.VerticalLine());
        }

        public Quantifier VerticalLine(int exactCount)
        {
            return AppendInternal(Characters.VerticalLine(exactCount));
        }

        public Quantifier VerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Characters.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return AppendInternal(Characters.NotVerticalLine());
        }

        public Quantifier NotVerticalLine(int exactCount)
        {
            return AppendInternal(Characters.NotVerticalLine(exactCount));
        }

        public Quantifier NotVerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return AppendInternal(Characters.RightCurlyBracket());
        }

        public Quantifier RightCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.RightCurlyBracket(exactCount));
        }

        public Quantifier RightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return AppendInternal(Characters.NotRightCurlyBracket());
        }

        public Quantifier NotRightCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.NotRightCurlyBracket(exactCount));
        }

        public Quantifier NotRightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return AppendInternal(Characters.Tilde());
        }

        public Quantifier Tilde(int exactCount)
        {
            return AppendInternal(Characters.Tilde(exactCount));
        }

        public Quantifier Tilde(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return AppendInternal(Characters.NotTilde());
        }

        public Quantifier NotTilde(int exactCount)
        {
            return AppendInternal(Characters.NotTilde(exactCount));
        }

        public Quantifier NotTilde(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotTilde(minCount, maxCount));
        }
    }
}
