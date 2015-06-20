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
            return Any().Count(count);
        }

        public static QuantifierGroup Any(int minCount, int maxCount)
        {
            return Any().CountRange(minCount, maxCount);
        }

        public static CharGroup AnyInvariant()
        {
            return Char(CharGroupItems.WhiteSpace().NotWhiteSpace());
        }

        public static QuantifierGroup AnyInvariant(int count)
        {
            return AnyInvariant().Count(count);
        }

        public static QuantifierGroup AnyInvariant(int minCount, int maxCount)
        {
            return AnyInvariant().CountRange(minCount, maxCount);
        }

        public static CharacterPattern Digit()
        {
            return new CharClassPattern(CharClass.Digit);
        }

        public static QuantifierGroup Digit(int count)
        {
            return new CharClassPattern(CharClass.Digit).Count(count);
        }

        public static QuantifierGroup Digit(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.Digit).CountRange(minCount, maxCount);
        }

        public static QuantifierGroup Digits()
        {
            return Digit().OneMany();
        }

        public static CharacterPattern NotDigit()
        {
            return new CharClassPattern(CharClass.NotDigit);
        }

        public static QuantifierGroup NotDigit(int count)
        {
            return new CharClassPattern(CharClass.NotDigit).Count(count);
        }

        public static QuantifierGroup NotDigit(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.NotDigit).CountRange(minCount, maxCount);
        }

        public static QuantifierGroup NotDigits()
        {
            return NotDigit().OneMany();
        }

        public static CharacterPattern WhiteSpace()
        {
            return new CharClassPattern(CharClass.WhiteSpace);
        }

        public static QuantifierGroup WhiteSpace(int count)
        {
            return new CharClassPattern(CharClass.WhiteSpace).Count(count);
        }

        public static QuantifierGroup WhiteSpace(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.WhiteSpace).CountRange(minCount, maxCount);
        }

        public static QuantifierGroup WhiteSpaces()
        {
            return WhiteSpace().OneMany();
        }

        public static QuantifierGroup WhileWhiteSpace()
        {
            return WhiteSpace().MaybeMany();
        }

        public static CharacterPattern NotWhiteSpace()
        {
            return new CharClassPattern(CharClass.NotWhiteSpace);
        }

        public static QuantifierGroup NotWhiteSpace(int count)
        {
            return new CharClassPattern(CharClass.NotWhiteSpace).Count(count);
        }

        public static QuantifierGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.NotWhiteSpace).CountRange(minCount, maxCount);
        }

        public static QuantifierGroup NotWhiteSpaces()
        {
            return NotWhiteSpace().OneMany();
        }

        public static CharacterPattern WordChar()
        {
            return new CharClassPattern(CharClass.WordChar);
        }

        public static QuantifierGroup WordChar(int count)
        {
            return new CharClassPattern(CharClass.WordChar).Count(count);
        }

        public static QuantifierGroup WordChar(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.WordChar).CountRange(minCount, maxCount);
        }

        public static QuantifierGroup WordChars()
        {
            return WordChar().OneMany();
        }

        public static CharacterPattern NotWordChar()
        {
            return new CharClassPattern(CharClass.NotWordChar);
        }

        public static QuantifierGroup NotWordChar(int count)
        {
            return new CharClassPattern(CharClass.NotWordChar).Count(count);
        }

        public static QuantifierGroup NotWordChar(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.NotWordChar).CountRange(minCount, maxCount);
        }

        public static QuantifierGroup NotWordChars()
        {
            return NotWordChar().OneMany();
        }

        public static CharacterPattern Tab()
        {
            return Char(AsciiChar.Tab);
        }

        public static QuantifierGroup Tab(int exactCount)
        {
            return Char(AsciiChar.Tab).Count(exactCount);
        }

        public static QuantifierGroup Tab(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tab).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotTab()
        {
            return NotChar(AsciiChar.Tab);
        }

        public static QuantifierGroup NotTab(int exactCount)
        {
            return NotChar(AsciiChar.Tab).Count(exactCount);
        }

        public static QuantifierGroup NotTab(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tab).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Linefeed()
        {
            return Char(AsciiChar.Linefeed);
        }

        public static QuantifierGroup Linefeed(int exactCount)
        {
            return Char(AsciiChar.Linefeed).Count(exactCount);
        }

        public static QuantifierGroup Linefeed(int minCount, int maxCount)
        {
            return Char(AsciiChar.Linefeed).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLinefeed()
        {
            return NotChar(AsciiChar.Linefeed);
        }

        public static QuantifierGroup NotLinefeed(int exactCount)
        {
            return NotChar(AsciiChar.Linefeed).Count(exactCount);
        }

        public static QuantifierGroup NotLinefeed(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Linefeed).CountRange(minCount, maxCount);
        }

        public static CharacterPattern CarriageReturn()
        {
            return Char(AsciiChar.CarriageReturn);
        }

        public static QuantifierGroup CarriageReturn(int exactCount)
        {
            return Char(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static QuantifierGroup CarriageReturn(int minCount, int maxCount)
        {
            return Char(AsciiChar.CarriageReturn).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotCarriageReturn()
        {
            return NotChar(AsciiChar.CarriageReturn);
        }

        public static QuantifierGroup NotCarriageReturn(int exactCount)
        {
            return NotChar(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static QuantifierGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CarriageReturn).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Space()
        {
            return Char(AsciiChar.Space);
        }

        public static QuantifierGroup Space(int exactCount)
        {
            return Char(AsciiChar.Space).Count(exactCount);
        }

        public static QuantifierGroup Space(int minCount, int maxCount)
        {
            return Char(AsciiChar.Space).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotSpace()
        {
            return NotChar(AsciiChar.Space);
        }

        public static QuantifierGroup NotSpace(int exactCount)
        {
            return NotChar(AsciiChar.Space).Count(exactCount);
        }

        public static QuantifierGroup NotSpace(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Space).CountRange(minCount, maxCount);
        }

        public static CharacterPattern ExclamationMark()
        {
            return Char(AsciiChar.ExclamationMark);
        }

        public static QuantifierGroup ExclamationMark(int exactCount)
        {
            return Char(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static QuantifierGroup ExclamationMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.ExclamationMark).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotExclamationMark()
        {
            return NotChar(AsciiChar.ExclamationMark);
        }

        public static QuantifierGroup NotExclamationMark(int exactCount)
        {
            return NotChar(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static QuantifierGroup NotExclamationMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.ExclamationMark).CountRange(minCount, maxCount);
        }

        public static CharacterPattern QuoteMark()
        {
            return Char(AsciiChar.QuoteMark);
        }

        public static QuantifierGroup QuoteMark(int exactCount)
        {
            return Char(AsciiChar.QuoteMark).Count(exactCount);
        }

        public static QuantifierGroup QuoteMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuoteMark).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotQuoteMark()
        {
            return NotChar(AsciiChar.QuoteMark);
        }

        public static QuantifierGroup NotQuoteMark(int exactCount)
        {
            return NotChar(AsciiChar.QuoteMark).Count(exactCount);
        }

        public static QuantifierGroup NotQuoteMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuoteMark).CountRange(minCount, maxCount);
        }

        public static CharacterPattern NumberSign()
        {
            return Char(AsciiChar.NumberSign);
        }

        public static QuantifierGroup NumberSign(int exactCount)
        {
            return Char(AsciiChar.NumberSign).Count(exactCount);
        }

        public static QuantifierGroup NumberSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.NumberSign).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotNumberSign()
        {
            return NotChar(AsciiChar.NumberSign);
        }

        public static QuantifierGroup NotNumberSign(int exactCount)
        {
            return NotChar(AsciiChar.NumberSign).Count(exactCount);
        }

        public static QuantifierGroup NotNumberSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.NumberSign).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Dollar()
        {
            return Char(AsciiChar.Dollar);
        }

        public static QuantifierGroup Dollar(int exactCount)
        {
            return Char(AsciiChar.Dollar).Count(exactCount);
        }

        public static QuantifierGroup Dollar(int minCount, int maxCount)
        {
            return Char(AsciiChar.Dollar).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotDollar()
        {
            return NotChar(AsciiChar.Dollar);
        }

        public static QuantifierGroup NotDollar(int exactCount)
        {
            return NotChar(AsciiChar.Dollar).Count(exactCount);
        }

        public static QuantifierGroup NotDollar(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Dollar).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Percent()
        {
            return Char(AsciiChar.Percent);
        }

        public static QuantifierGroup Percent(int exactCount)
        {
            return Char(AsciiChar.Percent).Count(exactCount);
        }

        public static QuantifierGroup Percent(int minCount, int maxCount)
        {
            return Char(AsciiChar.Percent).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotPercent()
        {
            return NotChar(AsciiChar.Percent);
        }

        public static QuantifierGroup NotPercent(int exactCount)
        {
            return NotChar(AsciiChar.Percent).Count(exactCount);
        }

        public static QuantifierGroup NotPercent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Percent).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Ampersand()
        {
            return Char(AsciiChar.Ampersand);
        }

        public static QuantifierGroup Ampersand(int exactCount)
        {
            return Char(AsciiChar.Ampersand).Count(exactCount);
        }

        public static QuantifierGroup Ampersand(int minCount, int maxCount)
        {
            return Char(AsciiChar.Ampersand).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotAmpersand()
        {
            return NotChar(AsciiChar.Ampersand);
        }

        public static QuantifierGroup NotAmpersand(int exactCount)
        {
            return NotChar(AsciiChar.Ampersand).Count(exactCount);
        }

        public static QuantifierGroup NotAmpersand(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Ampersand).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Apostrophe()
        {
            return Char(AsciiChar.Apostrophe);
        }

        public static QuantifierGroup Apostrophe(int exactCount)
        {
            return Char(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static QuantifierGroup Apostrophe(int minCount, int maxCount)
        {
            return Char(AsciiChar.Apostrophe).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotApostrophe()
        {
            return NotChar(AsciiChar.Apostrophe);
        }

        public static QuantifierGroup NotApostrophe(int exactCount)
        {
            return NotChar(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static QuantifierGroup NotApostrophe(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Apostrophe).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LeftParenthesis()
        {
            return Char(AsciiChar.LeftParenthesis);
        }

        public static QuantifierGroup LeftParenthesis(int exactCount)
        {
            return Char(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static QuantifierGroup LeftParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLeftParenthesis()
        {
            return NotChar(AsciiChar.LeftParenthesis);
        }

        public static QuantifierGroup NotLeftParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static QuantifierGroup NotLeftParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).CountRange(minCount, maxCount);
        }

        public static CharacterPattern RightParenthesis()
        {
            return Char(AsciiChar.RightParenthesis);
        }

        public static QuantifierGroup RightParenthesis(int exactCount)
        {
            return Char(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static QuantifierGroup RightParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotRightParenthesis()
        {
            return NotChar(AsciiChar.RightParenthesis);
        }

        public static QuantifierGroup NotRightParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static QuantifierGroup NotRightParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightParenthesis).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Asterisk()
        {
            return Char(AsciiChar.Asterisk);
        }

        public static QuantifierGroup Asterisk(int exactCount)
        {
            return Char(AsciiChar.Asterisk).Count(exactCount);
        }

        public static QuantifierGroup Asterisk(int minCount, int maxCount)
        {
            return Char(AsciiChar.Asterisk).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotAsterisk()
        {
            return NotChar(AsciiChar.Asterisk);
        }

        public static QuantifierGroup NotAsterisk(int exactCount)
        {
            return NotChar(AsciiChar.Asterisk).Count(exactCount);
        }

        public static QuantifierGroup NotAsterisk(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Asterisk).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Plus()
        {
            return Char(AsciiChar.Plus);
        }

        public static QuantifierGroup Plus(int exactCount)
        {
            return Char(AsciiChar.Plus).Count(exactCount);
        }

        public static QuantifierGroup Plus(int minCount, int maxCount)
        {
            return Char(AsciiChar.Plus).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotPlus()
        {
            return NotChar(AsciiChar.Plus);
        }

        public static QuantifierGroup NotPlus(int exactCount)
        {
            return NotChar(AsciiChar.Plus).Count(exactCount);
        }

        public static QuantifierGroup NotPlus(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Plus).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Comma()
        {
            return Char(AsciiChar.Comma);
        }

        public static QuantifierGroup Comma(int exactCount)
        {
            return Char(AsciiChar.Comma).Count(exactCount);
        }

        public static QuantifierGroup Comma(int minCount, int maxCount)
        {
            return Char(AsciiChar.Comma).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotComma()
        {
            return NotChar(AsciiChar.Comma);
        }

        public static QuantifierGroup NotComma(int exactCount)
        {
            return NotChar(AsciiChar.Comma).Count(exactCount);
        }

        public static QuantifierGroup NotComma(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Comma).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Hyphen()
        {
            return Char(AsciiChar.Hyphen);
        }

        public static QuantifierGroup Hyphen(int exactCount)
        {
            return Char(AsciiChar.Hyphen).Count(exactCount);
        }

        public static QuantifierGroup Hyphen(int minCount, int maxCount)
        {
            return Char(AsciiChar.Hyphen).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotHyphen()
        {
            return NotChar(AsciiChar.Hyphen);
        }

        public static QuantifierGroup NotHyphen(int exactCount)
        {
            return NotChar(AsciiChar.Hyphen).Count(exactCount);
        }

        public static QuantifierGroup NotHyphen(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Hyphen).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Period()
        {
            return Char(AsciiChar.Period);
        }

        public static QuantifierGroup Period(int exactCount)
        {
            return Char(AsciiChar.Period).Count(exactCount);
        }

        public static QuantifierGroup Period(int minCount, int maxCount)
        {
            return Char(AsciiChar.Period).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotPeriod()
        {
            return NotChar(AsciiChar.Period);
        }

        public static QuantifierGroup NotPeriod(int exactCount)
        {
            return NotChar(AsciiChar.Period).Count(exactCount);
        }

        public static QuantifierGroup NotPeriod(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Period).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Slash()
        {
            return Char(AsciiChar.Slash);
        }

        public static QuantifierGroup Slash(int exactCount)
        {
            return Char(AsciiChar.Slash).Count(exactCount);
        }

        public static QuantifierGroup Slash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Slash).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotSlash()
        {
            return NotChar(AsciiChar.Slash);
        }

        public static QuantifierGroup NotSlash(int exactCount)
        {
            return NotChar(AsciiChar.Slash).Count(exactCount);
        }

        public static QuantifierGroup NotSlash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Slash).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Colon()
        {
            return Char(AsciiChar.Colon);
        }

        public static QuantifierGroup Colon(int exactCount)
        {
            return Char(AsciiChar.Colon).Count(exactCount);
        }

        public static QuantifierGroup Colon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Colon).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotColon()
        {
            return NotChar(AsciiChar.Colon);
        }

        public static QuantifierGroup NotColon(int exactCount)
        {
            return NotChar(AsciiChar.Colon).Count(exactCount);
        }

        public static QuantifierGroup NotColon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Colon).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Semicolon()
        {
            return Char(AsciiChar.Semicolon);
        }

        public static QuantifierGroup Semicolon(int exactCount)
        {
            return Char(AsciiChar.Semicolon).Count(exactCount);
        }

        public static QuantifierGroup Semicolon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Semicolon).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotSemicolon()
        {
            return NotChar(AsciiChar.Semicolon);
        }

        public static QuantifierGroup NotSemicolon(int exactCount)
        {
            return NotChar(AsciiChar.Semicolon).Count(exactCount);
        }

        public static QuantifierGroup NotSemicolon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Semicolon).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LessThan()
        {
            return Char(AsciiChar.LessThan);
        }

        public static QuantifierGroup LessThan(int exactCount)
        {
            return Char(AsciiChar.LessThan).Count(exactCount);
        }

        public static QuantifierGroup LessThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.LessThan).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLessThan()
        {
            return NotChar(AsciiChar.LessThan);
        }

        public static QuantifierGroup NotLessThan(int exactCount)
        {
            return NotChar(AsciiChar.LessThan).Count(exactCount);
        }

        public static QuantifierGroup NotLessThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LessThan).CountRange(minCount, maxCount);
        }

        public static CharacterPattern EqualsSign()
        {
            return Char(AsciiChar.EqualsSign);
        }

        public static QuantifierGroup EqualsSign(int exactCount)
        {
            return Char(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static QuantifierGroup EqualsSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.EqualsSign).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotEqualsSign()
        {
            return NotChar(AsciiChar.EqualsSign);
        }

        public static QuantifierGroup NotEqualsSign(int exactCount)
        {
            return NotChar(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static QuantifierGroup NotEqualsSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.EqualsSign).CountRange(minCount, maxCount);
        }

        public static CharacterPattern GreaterThan()
        {
            return Char(AsciiChar.GreaterThan);
        }

        public static QuantifierGroup GreaterThan(int exactCount)
        {
            return Char(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static QuantifierGroup GreaterThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.GreaterThan).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotGreaterThan()
        {
            return NotChar(AsciiChar.GreaterThan);
        }

        public static QuantifierGroup NotGreaterThan(int exactCount)
        {
            return NotChar(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static QuantifierGroup NotGreaterThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GreaterThan).CountRange(minCount, maxCount);
        }

        public static CharacterPattern QuestionMark()
        {
            return Char(AsciiChar.QuestionMark);
        }

        public static QuantifierGroup QuestionMark(int exactCount)
        {
            return Char(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static QuantifierGroup QuestionMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuestionMark).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotQuestionMark()
        {
            return NotChar(AsciiChar.QuestionMark);
        }

        public static QuantifierGroup NotQuestionMark(int exactCount)
        {
            return NotChar(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static QuantifierGroup NotQuestionMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuestionMark).CountRange(minCount, maxCount);
        }

        public static CharacterPattern At()
        {
            return Char(AsciiChar.At);
        }

        public static QuantifierGroup At(int exactCount)
        {
            return Char(AsciiChar.At).Count(exactCount);
        }

        public static QuantifierGroup At(int minCount, int maxCount)
        {
            return Char(AsciiChar.At).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotAt()
        {
            return NotChar(AsciiChar.At);
        }

        public static QuantifierGroup NotAt(int exactCount)
        {
            return NotChar(AsciiChar.At).Count(exactCount);
        }

        public static QuantifierGroup NotAt(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.At).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LeftSquareBracket()
        {
            return Char(AsciiChar.LeftSquareBracket);
        }

        public static QuantifierGroup LeftSquareBracket(int exactCount)
        {
            return Char(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static QuantifierGroup LeftSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLeftSquareBracket()
        {
            return NotChar(AsciiChar.LeftSquareBracket);
        }

        public static QuantifierGroup NotLeftSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static QuantifierGroup NotLeftSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Backslash()
        {
            return Char(AsciiChar.Backslash);
        }

        public static QuantifierGroup Backslash(int exactCount)
        {
            return Char(AsciiChar.Backslash).Count(exactCount);
        }

        public static QuantifierGroup Backslash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Backslash).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotBackslash()
        {
            return NotChar(AsciiChar.Backslash);
        }

        public static QuantifierGroup NotBackslash(int exactCount)
        {
            return NotChar(AsciiChar.Backslash).Count(exactCount);
        }

        public static QuantifierGroup NotBackslash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Backslash).CountRange(minCount, maxCount);
        }

        public static CharacterPattern RightSquareBracket()
        {
            return Char(AsciiChar.RightSquareBracket);
        }

        public static QuantifierGroup RightSquareBracket(int exactCount)
        {
            return Char(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static QuantifierGroup RightSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotRightSquareBracket()
        {
            return NotChar(AsciiChar.RightSquareBracket);
        }

        public static QuantifierGroup NotRightSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static QuantifierGroup NotRightSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern CircumflexAccent()
        {
            return Char(AsciiChar.CircumflexAccent);
        }

        public static QuantifierGroup CircumflexAccent(int exactCount)
        {
            return Char(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static QuantifierGroup CircumflexAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.CircumflexAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotCircumflexAccent()
        {
            return NotChar(AsciiChar.CircumflexAccent);
        }

        public static QuantifierGroup NotCircumflexAccent(int exactCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static QuantifierGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Underscore()
        {
            return Char(AsciiChar.Underscore);
        }

        public static QuantifierGroup Underscore(int exactCount)
        {
            return Char(AsciiChar.Underscore).Count(exactCount);
        }

        public static QuantifierGroup Underscore(int minCount, int maxCount)
        {
            return Char(AsciiChar.Underscore).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotUnderscore()
        {
            return NotChar(AsciiChar.Underscore);
        }

        public static QuantifierGroup NotUnderscore(int exactCount)
        {
            return NotChar(AsciiChar.Underscore).Count(exactCount);
        }

        public static QuantifierGroup NotUnderscore(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Underscore).CountRange(minCount, maxCount);
        }

        public static CharacterPattern GraveAccent()
        {
            return Char(AsciiChar.GraveAccent);
        }

        public static QuantifierGroup GraveAccent(int exactCount)
        {
            return Char(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static QuantifierGroup GraveAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.GraveAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotGraveAccent()
        {
            return NotChar(AsciiChar.GraveAccent);
        }

        public static QuantifierGroup NotGraveAccent(int exactCount)
        {
            return NotChar(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static QuantifierGroup NotGraveAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GraveAccent).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LeftCurlyBracket()
        {
            return Char(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifierGroup LeftCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static QuantifierGroup LeftCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLeftCurlyBracket()
        {
            return NotChar(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifierGroup NotLeftCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static QuantifierGroup NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern VerticalLine()
        {
            return Char(AsciiChar.VerticalLine);
        }

        public static QuantifierGroup VerticalLine(int exactCount)
        {
            return Char(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static QuantifierGroup VerticalLine(int minCount, int maxCount)
        {
            return Char(AsciiChar.VerticalLine).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotVerticalLine()
        {
            return NotChar(AsciiChar.VerticalLine);
        }

        public static QuantifierGroup NotVerticalLine(int exactCount)
        {
            return NotChar(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static QuantifierGroup NotVerticalLine(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.VerticalLine).CountRange(minCount, maxCount);
        }

        public static CharacterPattern RightCurlyBracket()
        {
            return Char(AsciiChar.RightCurlyBracket);
        }

        public static QuantifierGroup RightCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static QuantifierGroup RightCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotRightCurlyBracket()
        {
            return NotChar(AsciiChar.RightCurlyBracket);
        }

        public static QuantifierGroup NotRightCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static QuantifierGroup NotRightCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Tilde()
        {
            return Char(AsciiChar.Tilde);
        }

        public static QuantifierGroup Tilde(int exactCount)
        {
            return Char(AsciiChar.Tilde).Count(exactCount);
        }

        public static QuantifierGroup Tilde(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tilde).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotTilde()
        {
            return NotChar(AsciiChar.Tilde);
        }

        public static QuantifierGroup NotTilde(int exactCount)
        {
            return NotChar(AsciiChar.Tilde).Count(exactCount);
        }

        public static QuantifierGroup NotTilde(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tilde).CountRange(minCount, maxCount);
        }

        public static CharGroup NewLineChar()
        {
            return Char(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifierGroup NewLineChar(int count)
        {
            return NewLineChar().Count(count);
        }

        public static QuantifierGroup NewLineChar(int minCount, int maxCount)
        {
            return NewLineChar().CountRange(minCount, maxCount);
        }

        public static CharGroup NotNewLineChar()
        {
            return NotChar(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifierGroup NotNewLineChar(int count)
        {
            return NotNewLineChar().Count(count);
        }

        public static QuantifierGroup NotNewLineChar(int minCount, int maxCount)
        {
            return NotNewLineChar().CountRange(minCount, maxCount);
        }

        public static CharGroup Alphanumeric()
        {
            return Char(CharGroupItems.Alphanumeric());
        }

        public static QuantifierGroup Alphanumeric(int count)
        {
            return Alphanumeric().Count(count);
        }

        public static QuantifierGroup Alphanumeric(int minCount, int maxCount)
        {
            return Alphanumeric().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumeric()
        {
            return NotChar(CharGroupItems.Alphanumeric());
        }

        public static QuantifierGroup NotAlphanumeric(int count)
        {
            return NotAlphanumeric().Count(count);
        }

        public static QuantifierGroup NotAlphanumeric(int minCount, int maxCount)
        {
            return NotAlphanumeric().CountRange(minCount, maxCount);
        }

        public static CharGroup AlphanumericLower()
        {
            return Char(CharGroupItems.AlphanumericLower());
        }

        public static QuantifierGroup AlphanumericLower(int count)
        {
            return AlphanumericLower().Count(count);
        }

        public static QuantifierGroup AlphanumericLower(int minCount, int maxCount)
        {
            return AlphanumericLower().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumericLower()
        {
            return NotChar(CharGroupItems.AlphanumericLower());
        }

        public static QuantifierGroup NotAlphanumericLower(int count)
        {
            return NotAlphanumericLower().Count(count);
        }

        public static QuantifierGroup NotAlphanumericLower(int minCount, int maxCount)
        {
            return NotAlphanumericLower().CountRange(minCount, maxCount);
        }

        public static CharGroup AlphanumericUpper()
        {
            return Char(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifierGroup AlphanumericUpper(int count)
        {
            return AlphanumericUpper().Count(count);
        }

        public static QuantifierGroup AlphanumericUpper(int minCount, int maxCount)
        {
            return AlphanumericUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumericUpper()
        {
            return NotChar(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifierGroup NotAlphanumericUpper(int count)
        {
            return NotAlphanumericUpper().Count(count);
        }

        public static QuantifierGroup NotAlphanumericUpper(int minCount, int maxCount)
        {
            return NotAlphanumericUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup AlphanumericUnderscore()
        {
            return Char(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifierGroup AlphanumericUnderscore(int count)
        {
            return AlphanumericUnderscore().Count(count);
        }

        public static QuantifierGroup AlphanumericUnderscore(int minCount, int maxCount)
        {
            return AlphanumericUnderscore().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumericUnderscore()
        {
            return NotChar(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifierGroup NotAlphanumericUnderscore(int count)
        {
            return NotAlphanumericUnderscore().Count(count);
        }

        public static QuantifierGroup NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return NotAlphanumericUnderscore().CountRange(minCount, maxCount);
        }

        public static CharGroup LatinLetter()
        {
            return Char(CharGroupItems.LatinLetter());
        }

        public static QuantifierGroup LatinLetter(int count)
        {
            return LatinLetter().Count(count);
        }

        public static QuantifierGroup LatinLetter(int minCount, int maxCount)
        {
            return LatinLetter().CountRange(minCount, maxCount);
        }

        public static CharGroup LatinLetterLower()
        {
            return Char(CharGroupItems.LatinLetterLower());
        }

        public static QuantifierGroup LatinLetterLower(int count)
        {
            return LatinLetterLower().Count(count);
        }

        public static QuantifierGroup LatinLetterLower(int minCount, int maxCount)
        {
            return LatinLetterLower().CountRange(minCount, maxCount);
        }

        public static CharGroup LatinLetterUpper()
        {
            return Char(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifierGroup LatinLetterUpper(int count)
        {
            return LatinLetterUpper().Count(count);
        }

        public static QuantifierGroup LatinLetterUpper(int minCount, int maxCount)
        {
            return LatinLetterUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup NotLatinLetter()
        {
            return NotChar(CharGroupItems.LatinLetter());
        }

        public static QuantifierGroup NotLatinLetter(int count)
        {
            return NotLatinLetter().Count(count);
        }

        public static QuantifierGroup NotLatinLetter(int minCount, int maxCount)
        {
            return NotLatinLetter().CountRange(minCount, maxCount);
        }

        public static CharGroup NotLatinLetterLower()
        {
            return NotChar(CharGroupItems.LatinLetterLower());
        }

        public static QuantifierGroup NotLatinLetterLower(int count)
        {
            return NotLatinLetterLower().Count(count);
        }

        public static QuantifierGroup NotLatinLetterLower(int minCount, int maxCount)
        {
            return NotLatinLetterLower().CountRange(minCount, maxCount);
        }

        public static CharGroup NotLatinLetterUpper()
        {
            return NotChar(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifierGroup NotLatinLetterUpper(int count)
        {
            return NotLatinLetterUpper().Count(count);
        }

        public static QuantifierGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return NotLatinLetterUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup ArabicDigit()
        {
            return Char(CharGroupItems.ArabicDigit());
        }

        public static QuantifierGroup ArabicDigit(int count)
        {
            return ArabicDigit().Count(count);
        }

        public static QuantifierGroup ArabicDigit(int minCount, int maxCount)
        {
            return ArabicDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup NotArabicDigit()
        {
            return NotChar(CharGroupItems.ArabicDigit());
        }

        public static QuantifierGroup NotArabicDigit(int count)
        {
            return NotArabicDigit().Count(count);
        }

        public static QuantifierGroup NotArabicDigit(int minCount, int maxCount)
        {
            return NotArabicDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup HexadecimalDigit()
        {
            return Char(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifierGroup HexadecimalDigit(int count)
        {
            return HexadecimalDigit().Count(count);
        }

        public static QuantifierGroup HexadecimalDigit(int minCount, int maxCount)
        {
            return HexadecimalDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup NotHexadecimalDigit()
        {
            return NotChar(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifierGroup NotHexadecimalDigit(int count)
        {
            return NotHexadecimalDigit().Count(count);
        }

        public static QuantifierGroup NotHexadecimalDigit(int minCount, int maxCount)
        {
            return NotHexadecimalDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup Parenthesis()
        {
            return Char(CharGroupItems.Parenthesis());
        }

        public static QuantifierGroup Parenthesis(int count)
        {
            return Parenthesis().Count(count);
        }

        public static QuantifierGroup Parenthesis(int minCount, int maxCount)
        {
            return Parenthesis().CountRange(minCount, maxCount);
        }

        public static CharGroup NotParenthesis()
        {
            return NotChar(CharGroupItems.Parenthesis());
        }

        public static QuantifierGroup NotParenthesis(int count)
        {
            return NotParenthesis().Count(count);
        }

        public static QuantifierGroup NotParenthesis(int minCount, int maxCount)
        {
            return NotParenthesis().CountRange(minCount, maxCount);
        }

        public static CharGroup CurlyBracket()
        {
            return Char(CharGroupItems.CurlyBracket());
        }

        public static QuantifierGroup CurlyBracket(int count)
        {
            return CurlyBracket().Count(count);
        }

        public static QuantifierGroup CurlyBracket(int minCount, int maxCount)
        {
            return CurlyBracket().CountRange(minCount, maxCount);
        }

        public static CharGroup NotCurlyBracket()
        {
            return NotChar(CharGroupItems.CurlyBracket());
        }

        public static QuantifierGroup NotCurlyBracket(int count)
        {
            return NotCurlyBracket().Count(count);
        }

        public static QuantifierGroup NotCurlyBracket(int minCount, int maxCount)
        {
            return NotCurlyBracket().CountRange(minCount, maxCount);
        }

        public static CharGroup SquareBracket()
        {
            return Char(CharGroupItems.SquareBracket());
        }

        public static QuantifierGroup SquareBracket(int count)
        {
            return SquareBracket().Count(count);
        }

        public static QuantifierGroup SquareBracket(int minCount, int maxCount)
        {
            return SquareBracket().CountRange(minCount, maxCount);
        }

        public static CharGroup NotSquareBracket()
        {
            return NotChar(CharGroupItems.SquareBracket());
        }

        public static QuantifierGroup NotSquareBracket(int count)
        {
            return NotSquareBracket().Count(count);
        }

        public static QuantifierGroup NotSquareBracket(int minCount, int maxCount)
        {
            return NotSquareBracket().CountRange(minCount, maxCount);
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
            return WhiteSpaceExceptNewLine().Count(count);
        }

        public static QuantifierGroup WhiteSpaceExceptNewLine(int minCount, int maxCount)
        {
            return WhiteSpaceExceptNewLine().CountRange(minCount, maxCount);
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
