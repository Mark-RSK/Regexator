// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Chars
    {
        public static CharacterPattern Char(char value)
        {
            return new CharPattern(value);
        }

        public static CharacterPattern Char(int charCode)
        {
            return new CharCodePattern(charCode);
        }

        public static CharacterPattern Char(AsciiChar value)
        {
            return new AsciiCharPattern(value);
        }

        public static CharGroup Char(string characters)
        {
            return new CharactersGroup(characters);
        }

        public static CharGroup Char(CharGroupItem item)
        {
            return new CharGroupItemGroup(item);
        }

        public static CharGroup NotChar(char value)
        {
            return new CharacterGroup(value, true);
        }

        public static CharGroup NotChar(int charCode)
        {
            return new CharCodeGroup(charCode, true);
        }

        public static CharGroup NotChar(AsciiChar value)
        {
            return new AsciiCharGroup(value, true);
        }

        public static CharGroup NotChar(string characters)
        {
            return new CharactersGroup(characters, true);
        }

        public static CharGroup NotChar(CharGroupItem item)
        {
            return new CharGroupItemGroup(item, true);
        }

        public static CharacterPattern Char(NamedBlock block)
        {
            return new NamedBlockPattern(block);
        }

        public static CharacterPattern Char(GeneralCategory category)
        {
            return new GeneralCategoryPattern(category);
        }

        public static CharacterPattern NotChar(NamedBlock block)
        {
            return new NotNamedBlockPattern(block);
        }

        public static CharacterPattern NotChar(GeneralCategory category)
        {
            return new NotGeneralCategoryPattern(category);
        }

        public static CharGroup Range(char first, char last)
        {
            return new CharRangeGroup(first, last);
        }

        public static CharGroup Range(int firstCharCode, int lastCharCode)
        {
            return new CharCodeRangeGroup(firstCharCode, lastCharCode);
        }

        public static CharGroup NotRange(char first, char last)
        {
            return new CharRangeGroup(first, last, true);
        }

        public static CharGroup NotRange(int firstCharCode, int lastCharCode)
        {
            return new CharCodeRangeGroup(firstCharCode, lastCharCode, true);
        }

        public static CharSubtraction Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        public static CharSubtraction NotSubtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new NotCharSubtraction(baseGroup, excludedGroup);
        }

        public static QuantifiablePattern Any()
        {
            return new AnyChar();
        }

        public static QuantifierGroup Any(int count)
        {
            return new Count(count, Any());
        }

        public static QuantifierGroup Any(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Any());
        }

        public static CharGroup AnyInvariant()
        {
            return Char(CharGroupItems.WhiteSpace().NotWhiteSpace());
        }

        public static QuantifierGroup AnyInvariant(int count)
        {
            return new Count(count, AnyInvariant());
        }

        public static QuantifierGroup AnyInvariant(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, AnyInvariant());
        }

        public static CharacterPattern Digit()
        {
            return new Digit();
        }

        public static QuantifierGroup Digit(int count)
        {
            return new Count(count, Digit());
        }

        public static QuantifierGroup Digit(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Digit());
        }

        public static QuantifierGroup Digits()
        {
            return new OneMany(Digit());
        }

        public static CharacterPattern NotDigit()
        {
            return new NotDigit();
        }

        public static QuantifierGroup NotDigit(int count)
        {
            return new Count(count, NotDigit());
        }

        public static QuantifierGroup NotDigit(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotDigit());
        }

        public static QuantifierGroup NotDigits()
        {
            return new OneMany(NotDigit());
        }

        public static CharacterPattern WhiteSpace()
        {
            return new WhiteSpace();
        }

        public static QuantifierGroup WhiteSpace(int count)
        {
            return new Count(count, WhiteSpace());
        }

        public static QuantifierGroup WhiteSpace(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, WhiteSpace());
        }

        public static QuantifierGroup WhiteSpaces()
        {
            return new OneMany(WhiteSpace());
        }

        public static QuantifierGroup WhileWhiteSpace()
        {
            return new MaybeMany(WhiteSpace());
        }

        public static CharacterPattern NotWhiteSpace()
        {
            return new NotWhiteSpace();
        }

        public static QuantifierGroup NotWhiteSpace(int count)
        {
            return new Count(count, NotWhiteSpace());
        }

        public static QuantifierGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotWhiteSpace());
        }

        public static QuantifierGroup NotWhiteSpaces()
        {
            return new OneMany(NotWhiteSpace());
        }

        public static CharacterPattern WordChar()
        {
            return new WordChar();
        }

        public static QuantifierGroup WordChar(int count)
        {
            return new Count(count, WordChar());
        }

        public static QuantifierGroup WordChar(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, WordChar());
        }

        public static QuantifierGroup WordChars()
        {
            return new OneMany(WordChar());
        }

        public static CharacterPattern NotWordChar()
        {
            return new NotWordChar();
        }

        public static QuantifierGroup NotWordChar(int count)
        {
            return new Count(count, NotWordChar());
        }

        public static QuantifierGroup NotWordChar(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotWordChar());
        }

        public static QuantifierGroup NotWordChars()
        {
            return new OneMany(NotWordChar());
        }

        public static CharacterPattern Tab()
        {
            return Char(AsciiChar.Tab);
        }

        public static QuantifierGroup Tab(int exactCount)
        {
            return new Count(exactCount, Tab());
        }

        public static QuantifierGroup Tab(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Tab());
        }

        public static QuantifiablePattern NotTab()
        {
            return NotChar(AsciiChar.Tab);
        }

        public static QuantifierGroup NotTab(int exactCount)
        {
            return new Count(exactCount, NotTab());
        }

        public static QuantifierGroup NotTab(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotTab());
        }

        public static CharacterPattern Linefeed()
        {
            return Char(AsciiChar.Linefeed);
        }

        public static QuantifierGroup Linefeed(int exactCount)
        {
            return new Count(exactCount, Linefeed());
        }

        public static QuantifierGroup Linefeed(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Linefeed());
        }

        public static QuantifiablePattern NotLinefeed()
        {
            return NotChar(AsciiChar.Linefeed);
        }

        public static QuantifierGroup NotLinefeed(int exactCount)
        {
            return new Count(exactCount, NotLinefeed());
        }

        public static QuantifierGroup NotLinefeed(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLinefeed());
        }

        public static CharacterPattern CarriageReturn()
        {
            return Char(AsciiChar.CarriageReturn);
        }

        public static QuantifierGroup CarriageReturn(int exactCount)
        {
            return new Count(exactCount, CarriageReturn());
        }

        public static QuantifierGroup CarriageReturn(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, CarriageReturn());
        }

        public static QuantifiablePattern NotCarriageReturn()
        {
            return NotChar(AsciiChar.CarriageReturn);
        }

        public static QuantifierGroup NotCarriageReturn(int exactCount)
        {
            return new Count(exactCount, NotCarriageReturn());
        }

        public static QuantifierGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotCarriageReturn());
        }

        public static CharacterPattern Space()
        {
            return Char(AsciiChar.Space);
        }

        public static QuantifierGroup Space(int exactCount)
        {
            return new Count(exactCount, Space());
        }

        public static QuantifierGroup Space(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Space());
        }

        public static QuantifiablePattern NotSpace()
        {
            return NotChar(AsciiChar.Space);
        }

        public static QuantifierGroup NotSpace(int exactCount)
        {
            return new Count(exactCount, NotSpace());
        }

        public static QuantifierGroup NotSpace(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotSpace());
        }

        public static CharacterPattern ExclamationMark()
        {
            return Char(AsciiChar.ExclamationMark);
        }

        public static QuantifierGroup ExclamationMark(int exactCount)
        {
            return new Count(exactCount, ExclamationMark());
        }

        public static QuantifierGroup ExclamationMark(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, ExclamationMark());
        }

        public static QuantifiablePattern NotExclamationMark()
        {
            return NotChar(AsciiChar.ExclamationMark);
        }

        public static QuantifierGroup NotExclamationMark(int exactCount)
        {
            return new Count(exactCount, NotExclamationMark());
        }

        public static QuantifierGroup NotExclamationMark(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotExclamationMark());
        }

        public static CharacterPattern QuoteMark()
        {
            return Char(AsciiChar.QuoteMark);
        }

        public static QuantifierGroup QuoteMark(int exactCount)
        {
            return new Count(exactCount, QuoteMark());
        }

        public static QuantifierGroup QuoteMark(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, QuoteMark());
        }

        public static QuantifiablePattern NotQuoteMark()
        {
            return NotChar(AsciiChar.QuoteMark);
        }

        public static QuantifierGroup NotQuoteMark(int exactCount)
        {
            return new Count(exactCount, NotQuoteMark());
        }

        public static QuantifierGroup NotQuoteMark(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotQuoteMark());
        }

        public static CharacterPattern NumberSign()
        {
            return Char(AsciiChar.NumberSign);
        }

        public static QuantifierGroup NumberSign(int exactCount)
        {
            return new Count(exactCount, NumberSign());
        }

        public static QuantifierGroup NumberSign(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NumberSign());
        }

        public static QuantifiablePattern NotNumberSign()
        {
            return NotChar(AsciiChar.NumberSign);
        }

        public static QuantifierGroup NotNumberSign(int exactCount)
        {
            return new Count(exactCount, NotNumberSign());
        }

        public static QuantifierGroup NotNumberSign(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotNumberSign());
        }

        public static CharacterPattern Dollar()
        {
            return Char(AsciiChar.Dollar);
        }

        public static QuantifierGroup Dollar(int exactCount)
        {
            return new Count(exactCount, Dollar());
        }

        public static QuantifierGroup Dollar(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Dollar());
        }

        public static QuantifiablePattern NotDollar()
        {
            return NotChar(AsciiChar.Dollar);
        }

        public static QuantifierGroup NotDollar(int exactCount)
        {
            return new Count(exactCount, NotDollar());
        }

        public static QuantifierGroup NotDollar(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotDollar());
        }

        public static CharacterPattern Percent()
        {
            return Char(AsciiChar.Percent);
        }

        public static QuantifierGroup Percent(int exactCount)
        {
            return new Count(exactCount, Percent());
        }

        public static QuantifierGroup Percent(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Percent());
        }

        public static QuantifiablePattern NotPercent()
        {
            return NotChar(AsciiChar.Percent);
        }

        public static QuantifierGroup NotPercent(int exactCount)
        {
            return new Count(exactCount, NotPercent());
        }

        public static QuantifierGroup NotPercent(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotPercent());
        }

        public static CharacterPattern Ampersand()
        {
            return Char(AsciiChar.Ampersand);
        }

        public static QuantifierGroup Ampersand(int exactCount)
        {
            return new Count(exactCount, Ampersand());
        }

        public static QuantifierGroup Ampersand(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Ampersand());
        }

        public static QuantifiablePattern NotAmpersand()
        {
            return NotChar(AsciiChar.Ampersand);
        }

        public static QuantifierGroup NotAmpersand(int exactCount)
        {
            return new Count(exactCount, NotAmpersand());
        }

        public static QuantifierGroup NotAmpersand(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotAmpersand());
        }

        public static CharacterPattern Apostrophe()
        {
            return Char(AsciiChar.Apostrophe);
        }

        public static QuantifierGroup Apostrophe(int exactCount)
        {
            return new Count(exactCount, Apostrophe());
        }

        public static QuantifierGroup Apostrophe(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Apostrophe());
        }

        public static QuantifiablePattern NotApostrophe()
        {
            return NotChar(AsciiChar.Apostrophe);
        }

        public static QuantifierGroup NotApostrophe(int exactCount)
        {
            return new Count(exactCount, NotApostrophe());
        }

        public static QuantifierGroup NotApostrophe(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotApostrophe());
        }

        public static CharacterPattern LeftParenthesis()
        {
            return Char(AsciiChar.LeftParenthesis);
        }

        public static QuantifierGroup LeftParenthesis(int exactCount)
        {
            return new Count(exactCount, LeftParenthesis());
        }

        public static QuantifierGroup LeftParenthesis(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, LeftParenthesis());
        }

        public static QuantifiablePattern NotLeftParenthesis()
        {
            return NotChar(AsciiChar.LeftParenthesis);
        }

        public static QuantifierGroup NotLeftParenthesis(int exactCount)
        {
            return new Count(exactCount, NotLeftParenthesis());
        }

        public static QuantifierGroup NotLeftParenthesis(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLeftParenthesis());
        }

        public static CharacterPattern RightParenthesis()
        {
            return Char(AsciiChar.RightParenthesis);
        }

        public static QuantifierGroup RightParenthesis(int exactCount)
        {
            return new Count(exactCount, RightParenthesis());
        }

        public static QuantifierGroup RightParenthesis(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, RightParenthesis());
        }

        public static QuantifiablePattern NotRightParenthesis()
        {
            return NotChar(AsciiChar.RightParenthesis);
        }

        public static QuantifierGroup NotRightParenthesis(int exactCount)
        {
            return new Count(exactCount, NotRightParenthesis());
        }

        public static QuantifierGroup NotRightParenthesis(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotRightParenthesis());
        }

        public static CharacterPattern Asterisk()
        {
            return Char(AsciiChar.Asterisk);
        }

        public static QuantifierGroup Asterisk(int exactCount)
        {
            return new Count(exactCount, Asterisk());
        }

        public static QuantifierGroup Asterisk(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Asterisk());
        }

        public static QuantifiablePattern NotAsterisk()
        {
            return NotChar(AsciiChar.Asterisk);
        }

        public static QuantifierGroup NotAsterisk(int exactCount)
        {
            return new Count(exactCount, NotAsterisk());
        }

        public static QuantifierGroup NotAsterisk(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotAsterisk());
        }

        public static CharacterPattern Plus()
        {
            return Char(AsciiChar.Plus);
        }

        public static QuantifierGroup Plus(int exactCount)
        {
            return new Count(exactCount, Plus());
        }

        public static QuantifierGroup Plus(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Plus());
        }

        public static QuantifiablePattern NotPlus()
        {
            return NotChar(AsciiChar.Plus);
        }

        public static QuantifierGroup NotPlus(int exactCount)
        {
            return new Count(exactCount, NotPlus());
        }

        public static QuantifierGroup NotPlus(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotPlus());
        }

        public static CharacterPattern Comma()
        {
            return Char(AsciiChar.Comma);
        }

        public static QuantifierGroup Comma(int exactCount)
        {
            return new Count(exactCount, Comma());
        }

        public static QuantifierGroup Comma(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Comma());
        }

        public static QuantifiablePattern NotComma()
        {
            return NotChar(AsciiChar.Comma);
        }

        public static QuantifierGroup NotComma(int exactCount)
        {
            return new Count(exactCount, NotComma());
        }

        public static QuantifierGroup NotComma(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotComma());
        }

        public static CharacterPattern Hyphen()
        {
            return Char(AsciiChar.Hyphen);
        }

        public static QuantifierGroup Hyphen(int exactCount)
        {
            return new Count(exactCount, Hyphen());
        }

        public static QuantifierGroup Hyphen(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Hyphen());
        }

        public static QuantifiablePattern NotHyphen()
        {
            return NotChar(AsciiChar.Hyphen);
        }

        public static QuantifierGroup NotHyphen(int exactCount)
        {
            return new Count(exactCount, NotHyphen());
        }

        public static QuantifierGroup NotHyphen(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotHyphen());
        }

        public static CharacterPattern Period()
        {
            return Char(AsciiChar.Period);
        }

        public static QuantifierGroup Period(int exactCount)
        {
            return new Count(exactCount, Period());
        }

        public static QuantifierGroup Period(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Period());
        }

        public static QuantifiablePattern NotPeriod()
        {
            return NotChar(AsciiChar.Period);
        }

        public static QuantifierGroup NotPeriod(int exactCount)
        {
            return new Count(exactCount, NotPeriod());
        }

        public static QuantifierGroup NotPeriod(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotPeriod());
        }

        public static CharacterPattern Slash()
        {
            return Char(AsciiChar.Slash);
        }

        public static QuantifierGroup Slash(int exactCount)
        {
            return new Count(exactCount, Slash());
        }

        public static QuantifierGroup Slash(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Slash());
        }

        public static QuantifiablePattern NotSlash()
        {
            return NotChar(AsciiChar.Slash);
        }

        public static QuantifierGroup NotSlash(int exactCount)
        {
            return new Count(exactCount, NotSlash());
        }

        public static QuantifierGroup NotSlash(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotSlash());
        }

        public static CharacterPattern Colon()
        {
            return Char(AsciiChar.Colon);
        }

        public static QuantifierGroup Colon(int exactCount)
        {
            return new Count(exactCount, Colon());
        }

        public static QuantifierGroup Colon(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Colon());
        }

        public static QuantifiablePattern NotColon()
        {
            return NotChar(AsciiChar.Colon);
        }

        public static QuantifierGroup NotColon(int exactCount)
        {
            return new Count(exactCount, NotColon());
        }

        public static QuantifierGroup NotColon(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotColon());
        }

        public static CharacterPattern Semicolon()
        {
            return Char(AsciiChar.Semicolon);
        }

        public static QuantifierGroup Semicolon(int exactCount)
        {
            return new Count(exactCount, Semicolon());
        }

        public static QuantifierGroup Semicolon(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Semicolon());
        }

        public static QuantifiablePattern NotSemicolon()
        {
            return NotChar(AsciiChar.Semicolon);
        }

        public static QuantifierGroup NotSemicolon(int exactCount)
        {
            return new Count(exactCount, NotSemicolon());
        }

        public static QuantifierGroup NotSemicolon(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotSemicolon());
        }

        public static CharacterPattern LessThan()
        {
            return Char(AsciiChar.LessThan);
        }

        public static QuantifierGroup LessThan(int exactCount)
        {
            return new Count(exactCount, LessThan());
        }

        public static QuantifierGroup LessThan(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, LessThan());
        }

        public static QuantifiablePattern NotLessThan()
        {
            return NotChar(AsciiChar.LessThan);
        }

        public static QuantifierGroup NotLessThan(int exactCount)
        {
            return new Count(exactCount, NotLessThan());
        }

        public static QuantifierGroup NotLessThan(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLessThan());
        }

        public static CharacterPattern EqualsSign()
        {
            return Char(AsciiChar.EqualsSign);
        }

        public static QuantifierGroup EqualsSign(int exactCount)
        {
            return new Count(exactCount, EqualsSign());
        }

        public static QuantifierGroup EqualsSign(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, EqualsSign());
        }

        public static QuantifiablePattern NotEqualsSign()
        {
            return NotChar(AsciiChar.EqualsSign);
        }

        public static QuantifierGroup NotEqualsSign(int exactCount)
        {
            return new Count(exactCount, NotEqualsSign());
        }

        public static QuantifierGroup NotEqualsSign(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotEqualsSign());
        }

        public static CharacterPattern GreaterThan()
        {
            return Char(AsciiChar.GreaterThan);
        }

        public static QuantifierGroup GreaterThan(int exactCount)
        {
            return new Count(exactCount, GreaterThan());
        }

        public static QuantifierGroup GreaterThan(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, GreaterThan());
        }

        public static QuantifiablePattern NotGreaterThan()
        {
            return NotChar(AsciiChar.GreaterThan);
        }

        public static QuantifierGroup NotGreaterThan(int exactCount)
        {
            return new Count(exactCount, NotGreaterThan());
        }

        public static QuantifierGroup NotGreaterThan(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotGreaterThan());
        }

        public static CharacterPattern QuestionMark()
        {
            return Char(AsciiChar.QuestionMark);
        }

        public static QuantifierGroup QuestionMark(int exactCount)
        {
            return new Count(exactCount, QuestionMark());
        }

        public static QuantifierGroup QuestionMark(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, QuestionMark());
        }

        public static QuantifiablePattern NotQuestionMark()
        {
            return NotChar(AsciiChar.QuestionMark);
        }

        public static QuantifierGroup NotQuestionMark(int exactCount)
        {
            return new Count(exactCount, NotQuestionMark());
        }

        public static QuantifierGroup NotQuestionMark(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotQuestionMark());
        }

        public static CharacterPattern At()
        {
            return Char(AsciiChar.At);
        }

        public static QuantifierGroup At(int exactCount)
        {
            return new Count(exactCount, At());
        }

        public static QuantifierGroup At(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, At());
        }

        public static QuantifiablePattern NotAt()
        {
            return NotChar(AsciiChar.At);
        }

        public static QuantifierGroup NotAt(int exactCount)
        {
            return new Count(exactCount, NotAt());
        }

        public static QuantifierGroup NotAt(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotAt());
        }

        public static CharacterPattern LeftSquareBracket()
        {
            return Char(AsciiChar.LeftSquareBracket);
        }

        public static QuantifierGroup LeftSquareBracket(int exactCount)
        {
            return new Count(exactCount, LeftSquareBracket());
        }

        public static QuantifierGroup LeftSquareBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, LeftSquareBracket());
        }

        public static QuantifiablePattern NotLeftSquareBracket()
        {
            return NotChar(AsciiChar.LeftSquareBracket);
        }

        public static QuantifierGroup NotLeftSquareBracket(int exactCount)
        {
            return new Count(exactCount, NotLeftSquareBracket());
        }

        public static QuantifierGroup NotLeftSquareBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLeftSquareBracket());
        }

        public static CharacterPattern Backslash()
        {
            return Char(AsciiChar.Backslash);
        }

        public static QuantifierGroup Backslash(int exactCount)
        {
            return new Count(exactCount, Backslash());
        }

        public static QuantifierGroup Backslash(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Backslash());
        }

        public static QuantifiablePattern NotBackslash()
        {
            return NotChar(AsciiChar.Backslash);
        }

        public static QuantifierGroup NotBackslash(int exactCount)
        {
            return new Count(exactCount, NotBackslash());
        }

        public static QuantifierGroup NotBackslash(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotBackslash());
        }

        public static CharacterPattern RightSquareBracket()
        {
            return Char(AsciiChar.RightSquareBracket);
        }

        public static QuantifierGroup RightSquareBracket(int exactCount)
        {
            return new Count(exactCount, RightSquareBracket());
        }

        public static QuantifierGroup RightSquareBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, RightSquareBracket());
        }

        public static QuantifiablePattern NotRightSquareBracket()
        {
            return NotChar(AsciiChar.RightSquareBracket);
        }

        public static QuantifierGroup NotRightSquareBracket(int exactCount)
        {
            return new Count(exactCount, NotRightSquareBracket());
        }

        public static QuantifierGroup NotRightSquareBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotRightSquareBracket());
        }

        public static CharacterPattern CircumflexAccent()
        {
            return Char(AsciiChar.CircumflexAccent);
        }

        public static QuantifierGroup CircumflexAccent(int exactCount)
        {
            return new Count(exactCount, CircumflexAccent());
        }

        public static QuantifierGroup CircumflexAccent(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, CircumflexAccent());
        }

        public static QuantifiablePattern NotCircumflexAccent()
        {
            return NotChar(AsciiChar.CircumflexAccent);
        }

        public static QuantifierGroup NotCircumflexAccent(int exactCount)
        {
            return new Count(exactCount, NotCircumflexAccent());
        }

        public static QuantifierGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotCircumflexAccent());
        }

        public static CharacterPattern Underscore()
        {
            return Char(AsciiChar.Underscore);
        }

        public static QuantifierGroup Underscore(int exactCount)
        {
            return new Count(exactCount, Underscore());
        }

        public static QuantifierGroup Underscore(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Underscore());
        }

        public static QuantifiablePattern NotUnderscore()
        {
            return NotChar(AsciiChar.Underscore);
        }

        public static QuantifierGroup NotUnderscore(int exactCount)
        {
            return new Count(exactCount, NotUnderscore());
        }

        public static QuantifierGroup NotUnderscore(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotUnderscore());
        }

        public static CharacterPattern GraveAccent()
        {
            return Char(AsciiChar.GraveAccent);
        }

        public static QuantifierGroup GraveAccent(int exactCount)
        {
            return new Count(exactCount, GraveAccent());
        }

        public static QuantifierGroup GraveAccent(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, GraveAccent());
        }

        public static QuantifiablePattern NotGraveAccent()
        {
            return NotChar(AsciiChar.GraveAccent);
        }

        public static QuantifierGroup NotGraveAccent(int exactCount)
        {
            return new Count(exactCount, NotGraveAccent());
        }

        public static QuantifierGroup NotGraveAccent(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotGraveAccent());
        }

        public static CharacterPattern LeftCurlyBracket()
        {
            return Char(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifierGroup LeftCurlyBracket(int exactCount)
        {
            return new Count(exactCount, LeftCurlyBracket());
        }

        public static QuantifierGroup LeftCurlyBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, LeftCurlyBracket());
        }

        public static QuantifiablePattern NotLeftCurlyBracket()
        {
            return NotChar(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifierGroup NotLeftCurlyBracket(int exactCount)
        {
            return new Count(exactCount, NotLeftCurlyBracket());
        }

        public static QuantifierGroup NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLeftCurlyBracket());
        }

        public static CharacterPattern VerticalLine()
        {
            return Char(AsciiChar.VerticalLine);
        }

        public static QuantifierGroup VerticalLine(int exactCount)
        {
            return new Count(exactCount, VerticalLine());
        }

        public static QuantifierGroup VerticalLine(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, VerticalLine());
        }

        public static QuantifiablePattern NotVerticalLine()
        {
            return NotChar(AsciiChar.VerticalLine);
        }

        public static QuantifierGroup NotVerticalLine(int exactCount)
        {
            return new Count(exactCount, NotVerticalLine());
        }

        public static QuantifierGroup NotVerticalLine(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotVerticalLine());
        }

        public static CharacterPattern RightCurlyBracket()
        {
            return Char(AsciiChar.RightCurlyBracket);
        }

        public static QuantifierGroup RightCurlyBracket(int exactCount)
        {
            return new Count(exactCount, RightCurlyBracket());
        }

        public static QuantifierGroup RightCurlyBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, RightCurlyBracket());
        }

        public static QuantifiablePattern NotRightCurlyBracket()
        {
            return NotChar(AsciiChar.RightCurlyBracket);
        }

        public static QuantifierGroup NotRightCurlyBracket(int exactCount)
        {
            return new Count(exactCount, NotRightCurlyBracket());
        }

        public static QuantifierGroup NotRightCurlyBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotRightCurlyBracket());
        }

        public static CharacterPattern Tilde()
        {
            return Char(AsciiChar.Tilde);
        }

        public static QuantifierGroup Tilde(int exactCount)
        {
            return new Count(exactCount, Tilde());
        }

        public static QuantifierGroup Tilde(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Tilde());
        }

        public static QuantifiablePattern NotTilde()
        {
            return NotChar(AsciiChar.Tilde);
        }

        public static QuantifierGroup NotTilde(int exactCount)
        {
            return new Count(exactCount, NotTilde());
        }

        public static QuantifierGroup NotTilde(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotTilde());
        }

        public static CharGroup NewLineChar()
        {
            return Char(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifierGroup NewLineChar(int count)
        {
            return new Count(count, NewLineChar());
        }

        public static QuantifierGroup NewLineChar(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NewLineChar());
        }

        public static CharGroup NotNewLineChar()
        {
            return NotChar(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifierGroup NotNewLineChar(int count)
        {
            return new Count(count, NotNewLineChar());
        }

        public static QuantifierGroup NotNewLineChar(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotNewLineChar());
        }

        public static CharGroup Alphanumeric()
        {
            return Char(CharGroupItems.Alphanumeric());
        }

        public static QuantifierGroup Alphanumeric(int count)
        {
            return new Count(count, Alphanumeric());
        }

        public static QuantifierGroup Alphanumeric(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Alphanumeric());
        }

        public static CharGroup NotAlphanumeric()
        {
            return NotChar(CharGroupItems.Alphanumeric());
        }

        public static QuantifierGroup NotAlphanumeric(int count)
        {
            return new Count(count, NotAlphanumeric());
        }

        public static QuantifierGroup NotAlphanumeric(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotAlphanumeric());
        }

        public static CharGroup AlphanumericLower()
        {
            return Char(CharGroupItems.AlphanumericLower());
        }

        public static QuantifierGroup AlphanumericLower(int count)
        {
            return new Count(count, AlphanumericLower());
        }

        public static QuantifierGroup AlphanumericLower(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, AlphanumericLower());
        }

        public static CharGroup NotAlphanumericLower()
        {
            return NotChar(CharGroupItems.AlphanumericLower());
        }

        public static QuantifierGroup NotAlphanumericLower(int count)
        {
            return new Count(count, NotAlphanumericLower());
        }

        public static QuantifierGroup NotAlphanumericLower(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotAlphanumericLower());
        }

        public static CharGroup AlphanumericUpper()
        {
            return Char(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifierGroup AlphanumericUpper(int count)
        {
            return new Count(count, AlphanumericUpper());
        }

        public static QuantifierGroup AlphanumericUpper(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, AlphanumericUpper());
        }

        public static CharGroup NotAlphanumericUpper()
        {
            return NotChar(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifierGroup NotAlphanumericUpper(int count)
        {
            return new Count(count, NotAlphanumericUpper());
        }

        public static QuantifierGroup NotAlphanumericUpper(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotAlphanumericUpper());
        }

        public static CharGroup AlphanumericUnderscore()
        {
            return Char(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifierGroup AlphanumericUnderscore(int count)
        {
            return new Count(count, AlphanumericUnderscore());
        }

        public static QuantifierGroup AlphanumericUnderscore(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, AlphanumericUnderscore());
        }

        public static CharGroup NotAlphanumericUnderscore()
        {
            return NotChar(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifierGroup NotAlphanumericUnderscore(int count)
        {
            return new Count(count, NotAlphanumericUnderscore());
        }

        public static QuantifierGroup NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotAlphanumericUnderscore());
        }

        public static CharGroup LatinLetter()
        {
            return Char(CharGroupItems.LatinLetter());
        }

        public static QuantifierGroup LatinLetter(int count)
        {
            return new Count(count, LatinLetter());
        }

        public static QuantifierGroup LatinLetter(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, LatinLetter());
        }

        public static CharGroup LatinLetterLower()
        {
            return Char(CharGroupItems.LatinLetterLower());
        }

        public static QuantifierGroup LatinLetterLower(int count)
        {
            return new Count(count, LatinLetterLower());
        }

        public static QuantifierGroup LatinLetterLower(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, LatinLetterLower());
        }

        public static CharGroup LatinLetterUpper()
        {
            return Char(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifierGroup LatinLetterUpper(int count)
        {
            return new Count(count, LatinLetterUpper());
        }

        public static QuantifierGroup LatinLetterUpper(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, LatinLetterUpper());
        }

        public static CharGroup NotLatinLetter()
        {
            return NotChar(CharGroupItems.LatinLetter());
        }

        public static QuantifierGroup NotLatinLetter(int count)
        {
            return new Count(count, NotLatinLetter());
        }

        public static QuantifierGroup NotLatinLetter(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLatinLetter());
        }

        public static CharGroup NotLatinLetterLower()
        {
            return NotChar(CharGroupItems.LatinLetterLower());
        }

        public static QuantifierGroup NotLatinLetterLower(int count)
        {
            return new Count(count, NotLatinLetterLower());
        }

        public static QuantifierGroup NotLatinLetterLower(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLatinLetterLower());
        }

        public static CharGroup NotLatinLetterUpper()
        {
            return NotChar(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifierGroup NotLatinLetterUpper(int count)
        {
            return new Count(count, NotLatinLetterUpper());
        }

        public static QuantifierGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotLatinLetterUpper());
        }

        public static CharGroup ArabicDigit()
        {
            return Char(CharGroupItems.ArabicDigit());
        }

        public static QuantifierGroup ArabicDigit(int count)
        {
            return new Count(count, ArabicDigit());
        }

        public static QuantifierGroup ArabicDigit(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, ArabicDigit());
        }

        public static CharGroup NotArabicDigit()
        {
            return NotChar(CharGroupItems.ArabicDigit());
        }

        public static QuantifierGroup NotArabicDigit(int count)
        {
            return new Count(count, NotArabicDigit());
        }

        public static QuantifierGroup NotArabicDigit(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotArabicDigit());
        }

        public static CharGroup HexadecimalDigit()
        {
            return Char(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifierGroup HexadecimalDigit(int count)
        {
            return new Count(count, HexadecimalDigit());
        }

        public static QuantifierGroup HexadecimalDigit(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, HexadecimalDigit());
        }

        public static CharGroup NotHexadecimalDigit()
        {
            return NotChar(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifierGroup NotHexadecimalDigit(int count)
        {
            return new Count(count, NotHexadecimalDigit());
        }

        public static QuantifierGroup NotHexadecimalDigit(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotHexadecimalDigit());
        }

        public static CharGroup Parenthesis()
        {
            return Char(CharGroupItems.Parenthesis());
        }

        public static QuantifierGroup Parenthesis(int count)
        {
            return new Count(count, Parenthesis());
        }

        public static QuantifierGroup Parenthesis(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, Parenthesis());
        }

        public static CharGroup NotParenthesis()
        {
            return NotChar(CharGroupItems.Parenthesis());
        }

        public static QuantifierGroup NotParenthesis(int count)
        {
            return new Count(count, NotParenthesis());
        }

        public static QuantifierGroup NotParenthesis(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotParenthesis());
        }

        public static CharGroup CurlyBracket()
        {
            return Char(CharGroupItems.CurlyBracket());
        }

        public static QuantifierGroup CurlyBracket(int count)
        {
            return new Count(count, CurlyBracket());
        }

        public static QuantifierGroup CurlyBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, CurlyBracket());
        }

        public static CharGroup NotCurlyBracket()
        {
            return NotChar(CharGroupItems.CurlyBracket());
        }

        public static QuantifierGroup NotCurlyBracket(int count)
        {
            return new Count(count, NotCurlyBracket());
        }

        public static QuantifierGroup NotCurlyBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotCurlyBracket());
        }

        public static CharGroup SquareBracket()
        {
            return Char(CharGroupItems.SquareBracket());
        }

        public static QuantifierGroup SquareBracket(int count)
        {
            return new Count(count, SquareBracket());
        }

        public static QuantifierGroup SquareBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, SquareBracket());
        }

        public static CharGroup NotSquareBracket()
        {
            return NotChar(CharGroupItems.SquareBracket());
        }

        public static QuantifierGroup NotSquareBracket(int count)
        {
            return new Count(count, NotSquareBracket());
        }

        public static QuantifierGroup NotSquareBracket(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, NotSquareBracket());
        }

        public static Pattern Apostrophes()
        {
            return Chars.Apostrophe().Apostrophe();
        }

        public static Pattern Apostrophes(object content)
        {
            return Pattern.Surround(AsciiChar.Apostrophe, content);
        }

        public static Pattern QuoteMarks()
        {
            return Chars.QuoteMark().QuoteMark();
        }

        public static Pattern QuoteMarks(object content)
        {
            return Pattern.Surround(AsciiChar.QuoteMark, content);
        }

        public static Pattern Parentheses()
        {
            return Chars.LeftParenthesis().RightParenthesis();
        }

        public static Pattern Parentheses(object content)
        {
            return Pattern.Surround(AsciiChar.LeftParenthesis, content, AsciiChar.RightParenthesis);
        }

        public static Pattern CurlyBrackets()
        {
            return Chars.LeftCurlyBracket().RightCurlyBracket();
        }

        public static Pattern CurlyBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.LeftCurlyBracket, content, AsciiChar.RightCurlyBracket);
        }

        public static Pattern SquareBrackets()
        {
            return Chars.LeftSquareBracket().RightSquareBracket();
        }

        public static Pattern SquareBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.LeftSquareBracket, content, AsciiChar.RightSquareBracket);
        }

        public static Pattern LessThanGreaterThan(object content)
        {
            return Pattern.Surround(AsciiChar.LessThan, content, AsciiChar.GreaterThan);
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return Chars.WhiteSpace().Except(Chars.NewLineChar());
        }

        public static QuantifierGroup WhiteSpaceExceptNewLine(int count)
        {
            return new Count(count, WhiteSpaceExceptNewLine());
        }

        public static QuantifierGroup WhiteSpaceExceptNewLine(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, WhiteSpaceExceptNewLine());
        }

        public static Pattern While(char value)
        {
            return Char(value).MaybeMany();
        }

        public static Pattern While(AsciiChar value)
        {
            return Char(value).MaybeMany();
        }

        public static Pattern While(CharGroupItem item)
        {
            return Char(item).MaybeMany();
        }
        public static Pattern WhileNot(char value)
        {
            return NotChar(value).MaybeMany();
        }

        public static Pattern WhileNot(AsciiChar value)
        {
            return NotChar(value).MaybeMany();
        }

        public static Pattern WhileNot(CharGroupItem item)
        {
            return NotChar(item).MaybeMany();
        }

        public static Pattern WhileNotNewLine()
        {
            return WhileNot(CharGroupItems.NewLineChar());
        }

#if DEBUG
        public static Pattern GoTo(char value)
        {
            return Chars.NotChar(value).MaybeMany().Char(value);
        }

        public static Pattern GoTo(AsciiChar value)
        {
            return Chars.NotChar(value).MaybeMany().Char(value);
        }
#endif

    }
}
