// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Chars
    {
        public static CharacterPattern Tab()
        {
            return Patterns.Char(AsciiChar.Tab);
        }

        public static QuantifiedGroup Tab(int exactCount)
        {
            return new Count(exactCount, Tab());
        }

        public static QuantifiedGroup Tab(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Tab());
        }

        public static QuantifiablePattern NotTab()
        {
            return Patterns.NotChar(AsciiChar.Tab);
        }

        public static QuantifiedGroup NotTab(int exactCount)
        {
            return new Count(exactCount, NotTab());
        }

        public static QuantifiedGroup NotTab(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotTab());
        }

        public static CharacterPattern Linefeed()
        {
            return Patterns.Char(AsciiChar.Linefeed);
        }

        public static QuantifiedGroup Linefeed(int exactCount)
        {
            return new Count(exactCount, Linefeed());
        }

        public static QuantifiedGroup Linefeed(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Linefeed());
        }

        public static QuantifiablePattern NotLinefeed()
        {
            return Patterns.NotChar(AsciiChar.Linefeed);
        }

        public static QuantifiedGroup NotLinefeed(int exactCount)
        {
            return new Count(exactCount, NotLinefeed());
        }

        public static QuantifiedGroup NotLinefeed(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLinefeed());
        }

        public static CharacterPattern CarriageReturn()
        {
            return Patterns.Char(AsciiChar.CarriageReturn);
        }

        public static QuantifiedGroup CarriageReturn(int exactCount)
        {
            return new Count(exactCount, CarriageReturn());
        }

        public static QuantifiedGroup CarriageReturn(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, CarriageReturn());
        }

        public static QuantifiablePattern NotCarriageReturn()
        {
            return Patterns.NotChar(AsciiChar.CarriageReturn);
        }

        public static QuantifiedGroup NotCarriageReturn(int exactCount)
        {
            return new Count(exactCount, NotCarriageReturn());
        }

        public static QuantifiedGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotCarriageReturn());
        }

        public static CharacterPattern Space()
        {
            return Patterns.Char(AsciiChar.Space);
        }

        public static QuantifiedGroup Space(int exactCount)
        {
            return new Count(exactCount, Space());
        }

        public static QuantifiedGroup Space(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Space());
        }

        public static QuantifiablePattern NotSpace()
        {
            return Patterns.NotChar(AsciiChar.Space);
        }

        public static QuantifiedGroup NotSpace(int exactCount)
        {
            return new Count(exactCount, NotSpace());
        }

        public static QuantifiedGroup NotSpace(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotSpace());
        }

        public static CharacterPattern ExclamationMark()
        {
            return Patterns.Char(AsciiChar.ExclamationMark);
        }

        public static QuantifiedGroup ExclamationMark(int exactCount)
        {
            return new Count(exactCount, ExclamationMark());
        }

        public static QuantifiedGroup ExclamationMark(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, ExclamationMark());
        }

        public static QuantifiablePattern NotExclamationMark()
        {
            return Patterns.NotChar(AsciiChar.ExclamationMark);
        }

        public static QuantifiedGroup NotExclamationMark(int exactCount)
        {
            return new Count(exactCount, NotExclamationMark());
        }

        public static QuantifiedGroup NotExclamationMark(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotExclamationMark());
        }

        public static CharacterPattern QuoteMark()
        {
            return Patterns.Char(AsciiChar.QuoteMark);
        }

        public static QuantifiedGroup QuoteMark(int exactCount)
        {
            return new Count(exactCount, QuoteMark());
        }

        public static QuantifiedGroup QuoteMark(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, QuoteMark());
        }

        public static QuantifiablePattern NotQuoteMark()
        {
            return Patterns.NotChar(AsciiChar.QuoteMark);
        }

        public static QuantifiedGroup NotQuoteMark(int exactCount)
        {
            return new Count(exactCount, NotQuoteMark());
        }

        public static QuantifiedGroup NotQuoteMark(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotQuoteMark());
        }

        public static CharacterPattern NumberSign()
        {
            return Patterns.Char(AsciiChar.NumberSign);
        }

        public static QuantifiedGroup NumberSign(int exactCount)
        {
            return new Count(exactCount, NumberSign());
        }

        public static QuantifiedGroup NumberSign(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NumberSign());
        }

        public static QuantifiablePattern NotNumberSign()
        {
            return Patterns.NotChar(AsciiChar.NumberSign);
        }

        public static QuantifiedGroup NotNumberSign(int exactCount)
        {
            return new Count(exactCount, NotNumberSign());
        }

        public static QuantifiedGroup NotNumberSign(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotNumberSign());
        }

        public static CharacterPattern Dollar()
        {
            return Patterns.Char(AsciiChar.Dollar);
        }

        public static QuantifiedGroup Dollar(int exactCount)
        {
            return new Count(exactCount, Dollar());
        }

        public static QuantifiedGroup Dollar(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Dollar());
        }

        public static QuantifiablePattern NotDollar()
        {
            return Patterns.NotChar(AsciiChar.Dollar);
        }

        public static QuantifiedGroup NotDollar(int exactCount)
        {
            return new Count(exactCount, NotDollar());
        }

        public static QuantifiedGroup NotDollar(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotDollar());
        }

        public static CharacterPattern Percent()
        {
            return Patterns.Char(AsciiChar.Percent);
        }

        public static QuantifiedGroup Percent(int exactCount)
        {
            return new Count(exactCount, Percent());
        }

        public static QuantifiedGroup Percent(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Percent());
        }

        public static QuantifiablePattern NotPercent()
        {
            return Patterns.NotChar(AsciiChar.Percent);
        }

        public static QuantifiedGroup NotPercent(int exactCount)
        {
            return new Count(exactCount, NotPercent());
        }

        public static QuantifiedGroup NotPercent(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotPercent());
        }

        public static CharacterPattern Ampersand()
        {
            return Patterns.Char(AsciiChar.Ampersand);
        }

        public static QuantifiedGroup Ampersand(int exactCount)
        {
            return new Count(exactCount, Ampersand());
        }

        public static QuantifiedGroup Ampersand(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Ampersand());
        }

        public static QuantifiablePattern NotAmpersand()
        {
            return Patterns.NotChar(AsciiChar.Ampersand);
        }

        public static QuantifiedGroup NotAmpersand(int exactCount)
        {
            return new Count(exactCount, NotAmpersand());
        }

        public static QuantifiedGroup NotAmpersand(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotAmpersand());
        }

        public static CharacterPattern Apostrophe()
        {
            return Patterns.Char(AsciiChar.Apostrophe);
        }

        public static QuantifiedGroup Apostrophe(int exactCount)
        {
            return new Count(exactCount, Apostrophe());
        }

        public static QuantifiedGroup Apostrophe(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Apostrophe());
        }

        public static QuantifiablePattern NotApostrophe()
        {
            return Patterns.NotChar(AsciiChar.Apostrophe);
        }

        public static QuantifiedGroup NotApostrophe(int exactCount)
        {
            return new Count(exactCount, NotApostrophe());
        }

        public static QuantifiedGroup NotApostrophe(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotApostrophe());
        }

        public static CharacterPattern LeftParenthesis()
        {
            return Patterns.Char(AsciiChar.LeftParenthesis);
        }

        public static QuantifiedGroup LeftParenthesis(int exactCount)
        {
            return new Count(exactCount, LeftParenthesis());
        }

        public static QuantifiedGroup LeftParenthesis(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, LeftParenthesis());
        }

        public static QuantifiablePattern NotLeftParenthesis()
        {
            return Patterns.NotChar(AsciiChar.LeftParenthesis);
        }

        public static QuantifiedGroup NotLeftParenthesis(int exactCount)
        {
            return new Count(exactCount, NotLeftParenthesis());
        }

        public static QuantifiedGroup NotLeftParenthesis(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLeftParenthesis());
        }

        public static CharacterPattern RightParenthesis()
        {
            return Patterns.Char(AsciiChar.RightParenthesis);
        }

        public static QuantifiedGroup RightParenthesis(int exactCount)
        {
            return new Count(exactCount, RightParenthesis());
        }

        public static QuantifiedGroup RightParenthesis(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, RightParenthesis());
        }

        public static QuantifiablePattern NotRightParenthesis()
        {
            return Patterns.NotChar(AsciiChar.RightParenthesis);
        }

        public static QuantifiedGroup NotRightParenthesis(int exactCount)
        {
            return new Count(exactCount, NotRightParenthesis());
        }

        public static QuantifiedGroup NotRightParenthesis(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotRightParenthesis());
        }

        public static CharacterPattern Asterisk()
        {
            return Patterns.Char(AsciiChar.Asterisk);
        }

        public static QuantifiedGroup Asterisk(int exactCount)
        {
            return new Count(exactCount, Asterisk());
        }

        public static QuantifiedGroup Asterisk(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Asterisk());
        }

        public static QuantifiablePattern NotAsterisk()
        {
            return Patterns.NotChar(AsciiChar.Asterisk);
        }

        public static QuantifiedGroup NotAsterisk(int exactCount)
        {
            return new Count(exactCount, NotAsterisk());
        }

        public static QuantifiedGroup NotAsterisk(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotAsterisk());
        }

        public static CharacterPattern Plus()
        {
            return Patterns.Char(AsciiChar.Plus);
        }

        public static QuantifiedGroup Plus(int exactCount)
        {
            return new Count(exactCount, Plus());
        }

        public static QuantifiedGroup Plus(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Plus());
        }

        public static QuantifiablePattern NotPlus()
        {
            return Patterns.NotChar(AsciiChar.Plus);
        }

        public static QuantifiedGroup NotPlus(int exactCount)
        {
            return new Count(exactCount, NotPlus());
        }

        public static QuantifiedGroup NotPlus(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotPlus());
        }

        public static CharacterPattern Comma()
        {
            return Patterns.Char(AsciiChar.Comma);
        }

        public static QuantifiedGroup Comma(int exactCount)
        {
            return new Count(exactCount, Comma());
        }

        public static QuantifiedGroup Comma(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Comma());
        }

        public static QuantifiablePattern NotComma()
        {
            return Patterns.NotChar(AsciiChar.Comma);
        }

        public static QuantifiedGroup NotComma(int exactCount)
        {
            return new Count(exactCount, NotComma());
        }

        public static QuantifiedGroup NotComma(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotComma());
        }

        public static CharacterPattern Hyphen()
        {
            return Patterns.Char(AsciiChar.Hyphen);
        }

        public static QuantifiedGroup Hyphen(int exactCount)
        {
            return new Count(exactCount, Hyphen());
        }

        public static QuantifiedGroup Hyphen(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Hyphen());
        }

        public static QuantifiablePattern NotHyphen()
        {
            return Patterns.NotChar(AsciiChar.Hyphen);
        }

        public static QuantifiedGroup NotHyphen(int exactCount)
        {
            return new Count(exactCount, NotHyphen());
        }

        public static QuantifiedGroup NotHyphen(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotHyphen());
        }

        public static CharacterPattern Period()
        {
            return Patterns.Char(AsciiChar.Period);
        }

        public static QuantifiedGroup Period(int exactCount)
        {
            return new Count(exactCount, Period());
        }

        public static QuantifiedGroup Period(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Period());
        }

        public static QuantifiablePattern NotPeriod()
        {
            return Patterns.NotChar(AsciiChar.Period);
        }

        public static QuantifiedGroup NotPeriod(int exactCount)
        {
            return new Count(exactCount, NotPeriod());
        }

        public static QuantifiedGroup NotPeriod(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotPeriod());
        }

        public static CharacterPattern Slash()
        {
            return Patterns.Char(AsciiChar.Slash);
        }

        public static QuantifiedGroup Slash(int exactCount)
        {
            return new Count(exactCount, Slash());
        }

        public static QuantifiedGroup Slash(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Slash());
        }

        public static QuantifiablePattern NotSlash()
        {
            return Patterns.NotChar(AsciiChar.Slash);
        }

        public static QuantifiedGroup NotSlash(int exactCount)
        {
            return new Count(exactCount, NotSlash());
        }

        public static QuantifiedGroup NotSlash(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotSlash());
        }

        public static CharacterPattern Colon()
        {
            return Patterns.Char(AsciiChar.Colon);
        }

        public static QuantifiedGroup Colon(int exactCount)
        {
            return new Count(exactCount, Colon());
        }

        public static QuantifiedGroup Colon(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Colon());
        }

        public static QuantifiablePattern NotColon()
        {
            return Patterns.NotChar(AsciiChar.Colon);
        }

        public static QuantifiedGroup NotColon(int exactCount)
        {
            return new Count(exactCount, NotColon());
        }

        public static QuantifiedGroup NotColon(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotColon());
        }

        public static CharacterPattern Semicolon()
        {
            return Patterns.Char(AsciiChar.Semicolon);
        }

        public static QuantifiedGroup Semicolon(int exactCount)
        {
            return new Count(exactCount, Semicolon());
        }

        public static QuantifiedGroup Semicolon(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Semicolon());
        }

        public static QuantifiablePattern NotSemicolon()
        {
            return Patterns.NotChar(AsciiChar.Semicolon);
        }

        public static QuantifiedGroup NotSemicolon(int exactCount)
        {
            return new Count(exactCount, NotSemicolon());
        }

        public static QuantifiedGroup NotSemicolon(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotSemicolon());
        }

        public static CharacterPattern LessThan()
        {
            return Patterns.Char(AsciiChar.LessThan);
        }

        public static QuantifiedGroup LessThan(int exactCount)
        {
            return new Count(exactCount, LessThan());
        }

        public static QuantifiedGroup LessThan(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, LessThan());
        }

        public static QuantifiablePattern NotLessThan()
        {
            return Patterns.NotChar(AsciiChar.LessThan);
        }

        public static QuantifiedGroup NotLessThan(int exactCount)
        {
            return new Count(exactCount, NotLessThan());
        }

        public static QuantifiedGroup NotLessThan(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLessThan());
        }

        public static CharacterPattern EqualsSign()
        {
            return Patterns.Char(AsciiChar.EqualsSign);
        }

        public static QuantifiedGroup EqualsSign(int exactCount)
        {
            return new Count(exactCount, EqualsSign());
        }

        public static QuantifiedGroup EqualsSign(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, EqualsSign());
        }

        public static QuantifiablePattern NotEqualsSign()
        {
            return Patterns.NotChar(AsciiChar.EqualsSign);
        }

        public static QuantifiedGroup NotEqualsSign(int exactCount)
        {
            return new Count(exactCount, NotEqualsSign());
        }

        public static QuantifiedGroup NotEqualsSign(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotEqualsSign());
        }

        public static CharacterPattern GreaterThan()
        {
            return Patterns.Char(AsciiChar.GreaterThan);
        }

        public static QuantifiedGroup GreaterThan(int exactCount)
        {
            return new Count(exactCount, GreaterThan());
        }

        public static QuantifiedGroup GreaterThan(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, GreaterThan());
        }

        public static QuantifiablePattern NotGreaterThan()
        {
            return Patterns.NotChar(AsciiChar.GreaterThan);
        }

        public static QuantifiedGroup NotGreaterThan(int exactCount)
        {
            return new Count(exactCount, NotGreaterThan());
        }

        public static QuantifiedGroup NotGreaterThan(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotGreaterThan());
        }

        public static CharacterPattern QuestionMark()
        {
            return Patterns.Char(AsciiChar.QuestionMark);
        }

        public static QuantifiedGroup QuestionMark(int exactCount)
        {
            return new Count(exactCount, QuestionMark());
        }

        public static QuantifiedGroup QuestionMark(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, QuestionMark());
        }

        public static QuantifiablePattern NotQuestionMark()
        {
            return Patterns.NotChar(AsciiChar.QuestionMark);
        }

        public static QuantifiedGroup NotQuestionMark(int exactCount)
        {
            return new Count(exactCount, NotQuestionMark());
        }

        public static QuantifiedGroup NotQuestionMark(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotQuestionMark());
        }

        public static CharacterPattern At()
        {
            return Patterns.Char(AsciiChar.At);
        }

        public static QuantifiedGroup At(int exactCount)
        {
            return new Count(exactCount, At());
        }

        public static QuantifiedGroup At(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, At());
        }

        public static QuantifiablePattern NotAt()
        {
            return Patterns.NotChar(AsciiChar.At);
        }

        public static QuantifiedGroup NotAt(int exactCount)
        {
            return new Count(exactCount, NotAt());
        }

        public static QuantifiedGroup NotAt(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotAt());
        }

        public static CharacterPattern LeftSquareBracket()
        {
            return Patterns.Char(AsciiChar.LeftSquareBracket);
        }

        public static QuantifiedGroup LeftSquareBracket(int exactCount)
        {
            return new Count(exactCount, LeftSquareBracket());
        }

        public static QuantifiedGroup LeftSquareBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, LeftSquareBracket());
        }

        public static QuantifiablePattern NotLeftSquareBracket()
        {
            return Patterns.NotChar(AsciiChar.LeftSquareBracket);
        }

        public static QuantifiedGroup NotLeftSquareBracket(int exactCount)
        {
            return new Count(exactCount, NotLeftSquareBracket());
        }

        public static QuantifiedGroup NotLeftSquareBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLeftSquareBracket());
        }

        public static CharacterPattern Backslash()
        {
            return Patterns.Char(AsciiChar.Backslash);
        }

        public static QuantifiedGroup Backslash(int exactCount)
        {
            return new Count(exactCount, Backslash());
        }

        public static QuantifiedGroup Backslash(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Backslash());
        }

        public static QuantifiablePattern NotBackslash()
        {
            return Patterns.NotChar(AsciiChar.Backslash);
        }

        public static QuantifiedGroup NotBackslash(int exactCount)
        {
            return new Count(exactCount, NotBackslash());
        }

        public static QuantifiedGroup NotBackslash(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotBackslash());
        }

        public static CharacterPattern RightSquareBracket()
        {
            return Patterns.Char(AsciiChar.RightSquareBracket);
        }

        public static QuantifiedGroup RightSquareBracket(int exactCount)
        {
            return new Count(exactCount, RightSquareBracket());
        }

        public static QuantifiedGroup RightSquareBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, RightSquareBracket());
        }

        public static QuantifiablePattern NotRightSquareBracket()
        {
            return Patterns.NotChar(AsciiChar.RightSquareBracket);
        }

        public static QuantifiedGroup NotRightSquareBracket(int exactCount)
        {
            return new Count(exactCount, NotRightSquareBracket());
        }

        public static QuantifiedGroup NotRightSquareBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotRightSquareBracket());
        }

        public static CharacterPattern CircumflexAccent()
        {
            return Patterns.Char(AsciiChar.CircumflexAccent);
        }

        public static QuantifiedGroup CircumflexAccent(int exactCount)
        {
            return new Count(exactCount, CircumflexAccent());
        }

        public static QuantifiedGroup CircumflexAccent(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, CircumflexAccent());
        }

        public static QuantifiablePattern NotCircumflexAccent()
        {
            return Patterns.NotChar(AsciiChar.CircumflexAccent);
        }

        public static QuantifiedGroup NotCircumflexAccent(int exactCount)
        {
            return new Count(exactCount, NotCircumflexAccent());
        }

        public static QuantifiedGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotCircumflexAccent());
        }

        public static CharacterPattern Underscore()
        {
            return Patterns.Char(AsciiChar.Underscore);
        }

        public static QuantifiedGroup Underscore(int exactCount)
        {
            return new Count(exactCount, Underscore());
        }

        public static QuantifiedGroup Underscore(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Underscore());
        }

        public static QuantifiablePattern NotUnderscore()
        {
            return Patterns.NotChar(AsciiChar.Underscore);
        }

        public static QuantifiedGroup NotUnderscore(int exactCount)
        {
            return new Count(exactCount, NotUnderscore());
        }

        public static QuantifiedGroup NotUnderscore(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotUnderscore());
        }

        public static CharacterPattern GraveAccent()
        {
            return Patterns.Char(AsciiChar.GraveAccent);
        }

        public static QuantifiedGroup GraveAccent(int exactCount)
        {
            return new Count(exactCount, GraveAccent());
        }

        public static QuantifiedGroup GraveAccent(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, GraveAccent());
        }

        public static QuantifiablePattern NotGraveAccent()
        {
            return Patterns.NotChar(AsciiChar.GraveAccent);
        }

        public static QuantifiedGroup NotGraveAccent(int exactCount)
        {
            return new Count(exactCount, NotGraveAccent());
        }

        public static QuantifiedGroup NotGraveAccent(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotGraveAccent());
        }

        public static CharacterPattern LeftCurlyBracket()
        {
            return Patterns.Char(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifiedGroup LeftCurlyBracket(int exactCount)
        {
            return new Count(exactCount, LeftCurlyBracket());
        }

        public static QuantifiedGroup LeftCurlyBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, LeftCurlyBracket());
        }

        public static QuantifiablePattern NotLeftCurlyBracket()
        {
            return Patterns.NotChar(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifiedGroup NotLeftCurlyBracket(int exactCount)
        {
            return new Count(exactCount, NotLeftCurlyBracket());
        }

        public static QuantifiedGroup NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLeftCurlyBracket());
        }

        public static CharacterPattern VerticalLine()
        {
            return Patterns.Char(AsciiChar.VerticalLine);
        }

        public static QuantifiedGroup VerticalLine(int exactCount)
        {
            return new Count(exactCount, VerticalLine());
        }

        public static QuantifiedGroup VerticalLine(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, VerticalLine());
        }

        public static QuantifiablePattern NotVerticalLine()
        {
            return Patterns.NotChar(AsciiChar.VerticalLine);
        }

        public static QuantifiedGroup NotVerticalLine(int exactCount)
        {
            return new Count(exactCount, NotVerticalLine());
        }

        public static QuantifiedGroup NotVerticalLine(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotVerticalLine());
        }

        public static CharacterPattern RightCurlyBracket()
        {
            return Patterns.Char(AsciiChar.RightCurlyBracket);
        }

        public static QuantifiedGroup RightCurlyBracket(int exactCount)
        {
            return new Count(exactCount, RightCurlyBracket());
        }

        public static QuantifiedGroup RightCurlyBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, RightCurlyBracket());
        }

        public static QuantifiablePattern NotRightCurlyBracket()
        {
            return Patterns.NotChar(AsciiChar.RightCurlyBracket);
        }

        public static QuantifiedGroup NotRightCurlyBracket(int exactCount)
        {
            return new Count(exactCount, NotRightCurlyBracket());
        }

        public static QuantifiedGroup NotRightCurlyBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotRightCurlyBracket());
        }

        public static CharacterPattern Tilde()
        {
            return Patterns.Char(AsciiChar.Tilde);
        }

        public static QuantifiedGroup Tilde(int exactCount)
        {
            return new Count(exactCount, Tilde());
        }

        public static QuantifiedGroup Tilde(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Tilde());
        }

        public static QuantifiablePattern NotTilde()
        {
            return Patterns.NotChar(AsciiChar.Tilde);
        }

        public static QuantifiedGroup NotTilde(int exactCount)
        {
            return new Count(exactCount, NotTilde());
        }

        public static QuantifiedGroup NotTilde(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotTilde());
        }
    }
}
