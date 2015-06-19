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

        public static Quantifier Any(int count)
        {
            return Any().Count(count);
        }

        public static Quantifier Any(int minCount, int maxCount)
        {
            return Any().CountRange(minCount, maxCount);
        }

        public static CharGroup AnyInvariant()
        {
            return Char(CharGroupItems.WhiteSpace().NotWhiteSpace());
        }

        public static Quantifier AnyInvariant(int count)
        {
            return AnyInvariant().Count(count);
        }

        public static Quantifier AnyInvariant(int minCount, int maxCount)
        {
            return AnyInvariant().CountRange(minCount, maxCount);
        }

        public static Pattern AnyMaybeManyLazy()
        {
            return Any().MaybeMany().Lazy();
        }

        public static Pattern AnyMaybeManyLazyInvariant()
        {
            return AnyInvariant().MaybeMany().Lazy();
        }

        public static CharacterPattern Digit()
        {
            return new CharClassPattern(CharClass.Digit);
        }

        public static Quantifier Digit(int count)
        {
            return new CharClassPattern(CharClass.Digit).Count(count);
        }

        public static Quantifier Digit(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.Digit).CountRange(minCount, maxCount);
        }

        public static Quantifier Digits()
        {
            return Digit().OneMany();
        }

        public static CharacterPattern NotDigit()
        {
            return new CharClassPattern(CharClass.NotDigit);
        }

        public static Quantifier NotDigit(int count)
        {
            return new CharClassPattern(CharClass.NotDigit).Count(count);
        }

        public static Quantifier NotDigit(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.NotDigit).CountRange(minCount, maxCount);
        }

        public static Quantifier NotDigits()
        {
            return NotDigit().OneMany();
        }

        public static CharacterPattern WhiteSpace()
        {
            return new CharClassPattern(CharClass.WhiteSpace);
        }

        public static Quantifier WhiteSpace(int count)
        {
            return new CharClassPattern(CharClass.WhiteSpace).Count(count);
        }

        public static Quantifier WhiteSpace(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.WhiteSpace).CountRange(minCount, maxCount);
        }

        public static Quantifier WhiteSpaces()
        {
            return WhiteSpace().OneMany();
        }

        public static Quantifier WhileWhiteSpace()
        {
            return WhiteSpace().MaybeMany();
        }

        public static CharacterPattern NotWhiteSpace()
        {
            return new CharClassPattern(CharClass.NotWhiteSpace);
        }

        public static Quantifier NotWhiteSpace(int count)
        {
            return new CharClassPattern(CharClass.NotWhiteSpace).Count(count);
        }

        public static Quantifier NotWhiteSpace(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.NotWhiteSpace).CountRange(minCount, maxCount);
        }

        public static Quantifier NotWhiteSpaces()
        {
            return NotWhiteSpace().OneMany();
        }

        public static CharacterPattern WordChar()
        {
            return new CharClassPattern(CharClass.WordChar);
        }

        public static Quantifier WordChar(int count)
        {
            return new CharClassPattern(CharClass.WordChar).Count(count);
        }

        public static Quantifier WordChar(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.WordChar).CountRange(minCount, maxCount);
        }

        public static Quantifier WordChars()
        {
            return WordChar().OneMany();
        }

        public static CharacterPattern NotWordChar()
        {
            return new CharClassPattern(CharClass.NotWordChar);
        }

        public static Quantifier NotWordChar(int count)
        {
            return new CharClassPattern(CharClass.NotWordChar).Count(count);
        }

        public static Quantifier NotWordChar(int minCount, int maxCount)
        {
            return new CharClassPattern(CharClass.NotWordChar).CountRange(minCount, maxCount);
        }

        public static Quantifier NotWordChars()
        {
            return NotWordChar().OneMany();
        }

        public static CharacterPattern Tab()
        {
            return Char(AsciiChar.Tab);
        }

        public static Quantifier Tab(int exactCount)
        {
            return Char(AsciiChar.Tab).Count(exactCount);
        }

        public static Quantifier Tab(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tab).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotTab()
        {
            return NotChar(AsciiChar.Tab);
        }

        public static Quantifier NotTab(int exactCount)
        {
            return NotChar(AsciiChar.Tab).Count(exactCount);
        }

        public static Quantifier NotTab(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tab).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Linefeed()
        {
            return Char(AsciiChar.Linefeed);
        }

        public static Quantifier Linefeed(int exactCount)
        {
            return Char(AsciiChar.Linefeed).Count(exactCount);
        }

        public static Quantifier Linefeed(int minCount, int maxCount)
        {
            return Char(AsciiChar.Linefeed).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLinefeed()
        {
            return NotChar(AsciiChar.Linefeed);
        }

        public static Quantifier NotLinefeed(int exactCount)
        {
            return NotChar(AsciiChar.Linefeed).Count(exactCount);
        }

        public static Quantifier NotLinefeed(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Linefeed).CountRange(minCount, maxCount);
        }

        public static CharacterPattern CarriageReturn()
        {
            return Char(AsciiChar.CarriageReturn);
        }

        public static Quantifier CarriageReturn(int exactCount)
        {
            return Char(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static Quantifier CarriageReturn(int minCount, int maxCount)
        {
            return Char(AsciiChar.CarriageReturn).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotCarriageReturn()
        {
            return NotChar(AsciiChar.CarriageReturn);
        }

        public static Quantifier NotCarriageReturn(int exactCount)
        {
            return NotChar(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static Quantifier NotCarriageReturn(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CarriageReturn).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Space()
        {
            return Char(AsciiChar.Space);
        }

        public static Quantifier Space(int exactCount)
        {
            return Char(AsciiChar.Space).Count(exactCount);
        }

        public static Quantifier Space(int minCount, int maxCount)
        {
            return Char(AsciiChar.Space).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotSpace()
        {
            return NotChar(AsciiChar.Space);
        }

        public static Quantifier NotSpace(int exactCount)
        {
            return NotChar(AsciiChar.Space).Count(exactCount);
        }

        public static Quantifier NotSpace(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Space).CountRange(minCount, maxCount);
        }

        public static CharacterPattern ExclamationMark()
        {
            return Char(AsciiChar.ExclamationMark);
        }

        public static Quantifier ExclamationMark(int exactCount)
        {
            return Char(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static Quantifier ExclamationMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.ExclamationMark).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotExclamationMark()
        {
            return NotChar(AsciiChar.ExclamationMark);
        }

        public static Quantifier NotExclamationMark(int exactCount)
        {
            return NotChar(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static Quantifier NotExclamationMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.ExclamationMark).CountRange(minCount, maxCount);
        }

        public static CharacterPattern QuoteMark()
        {
            return Char(AsciiChar.QuoteMark);
        }

        public static Quantifier QuoteMark(int exactCount)
        {
            return Char(AsciiChar.QuoteMark).Count(exactCount);
        }

        public static Quantifier QuoteMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuoteMark).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotQuoteMark()
        {
            return NotChar(AsciiChar.QuoteMark);
        }

        public static Quantifier NotQuoteMark(int exactCount)
        {
            return NotChar(AsciiChar.QuoteMark).Count(exactCount);
        }

        public static Quantifier NotQuoteMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuoteMark).CountRange(minCount, maxCount);
        }

        public static CharacterPattern NumberSign()
        {
            return Char(AsciiChar.NumberSign);
        }

        public static Quantifier NumberSign(int exactCount)
        {
            return Char(AsciiChar.NumberSign).Count(exactCount);
        }

        public static Quantifier NumberSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.NumberSign).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotNumberSign()
        {
            return NotChar(AsciiChar.NumberSign);
        }

        public static Quantifier NotNumberSign(int exactCount)
        {
            return NotChar(AsciiChar.NumberSign).Count(exactCount);
        }

        public static Quantifier NotNumberSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.NumberSign).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Dollar()
        {
            return Char(AsciiChar.Dollar);
        }

        public static Quantifier Dollar(int exactCount)
        {
            return Char(AsciiChar.Dollar).Count(exactCount);
        }

        public static Quantifier Dollar(int minCount, int maxCount)
        {
            return Char(AsciiChar.Dollar).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotDollar()
        {
            return NotChar(AsciiChar.Dollar);
        }

        public static Quantifier NotDollar(int exactCount)
        {
            return NotChar(AsciiChar.Dollar).Count(exactCount);
        }

        public static Quantifier NotDollar(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Dollar).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Percent()
        {
            return Char(AsciiChar.Percent);
        }

        public static Quantifier Percent(int exactCount)
        {
            return Char(AsciiChar.Percent).Count(exactCount);
        }

        public static Quantifier Percent(int minCount, int maxCount)
        {
            return Char(AsciiChar.Percent).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotPercent()
        {
            return NotChar(AsciiChar.Percent);
        }

        public static Quantifier NotPercent(int exactCount)
        {
            return NotChar(AsciiChar.Percent).Count(exactCount);
        }

        public static Quantifier NotPercent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Percent).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Ampersand()
        {
            return Char(AsciiChar.Ampersand);
        }

        public static Quantifier Ampersand(int exactCount)
        {
            return Char(AsciiChar.Ampersand).Count(exactCount);
        }

        public static Quantifier Ampersand(int minCount, int maxCount)
        {
            return Char(AsciiChar.Ampersand).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotAmpersand()
        {
            return NotChar(AsciiChar.Ampersand);
        }

        public static Quantifier NotAmpersand(int exactCount)
        {
            return NotChar(AsciiChar.Ampersand).Count(exactCount);
        }

        public static Quantifier NotAmpersand(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Ampersand).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Apostrophe()
        {
            return Char(AsciiChar.Apostrophe);
        }

        public static Quantifier Apostrophe(int exactCount)
        {
            return Char(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static Quantifier Apostrophe(int minCount, int maxCount)
        {
            return Char(AsciiChar.Apostrophe).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotApostrophe()
        {
            return NotChar(AsciiChar.Apostrophe);
        }

        public static Quantifier NotApostrophe(int exactCount)
        {
            return NotChar(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static Quantifier NotApostrophe(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Apostrophe).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LeftParenthesis()
        {
            return Char(AsciiChar.LeftParenthesis);
        }

        public static Quantifier LeftParenthesis(int exactCount)
        {
            return Char(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static Quantifier LeftParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLeftParenthesis()
        {
            return NotChar(AsciiChar.LeftParenthesis);
        }

        public static Quantifier NotLeftParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static Quantifier NotLeftParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).CountRange(minCount, maxCount);
        }

        public static CharacterPattern RightParenthesis()
        {
            return Char(AsciiChar.RightParenthesis);
        }

        public static Quantifier RightParenthesis(int exactCount)
        {
            return Char(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static Quantifier RightParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotRightParenthesis()
        {
            return NotChar(AsciiChar.RightParenthesis);
        }

        public static Quantifier NotRightParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static Quantifier NotRightParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightParenthesis).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Asterisk()
        {
            return Char(AsciiChar.Asterisk);
        }

        public static Quantifier Asterisk(int exactCount)
        {
            return Char(AsciiChar.Asterisk).Count(exactCount);
        }

        public static Quantifier Asterisk(int minCount, int maxCount)
        {
            return Char(AsciiChar.Asterisk).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotAsterisk()
        {
            return NotChar(AsciiChar.Asterisk);
        }

        public static Quantifier NotAsterisk(int exactCount)
        {
            return NotChar(AsciiChar.Asterisk).Count(exactCount);
        }

        public static Quantifier NotAsterisk(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Asterisk).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Plus()
        {
            return Char(AsciiChar.Plus);
        }

        public static Quantifier Plus(int exactCount)
        {
            return Char(AsciiChar.Plus).Count(exactCount);
        }

        public static Quantifier Plus(int minCount, int maxCount)
        {
            return Char(AsciiChar.Plus).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotPlus()
        {
            return NotChar(AsciiChar.Plus);
        }

        public static Quantifier NotPlus(int exactCount)
        {
            return NotChar(AsciiChar.Plus).Count(exactCount);
        }

        public static Quantifier NotPlus(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Plus).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Comma()
        {
            return Char(AsciiChar.Comma);
        }

        public static Quantifier Comma(int exactCount)
        {
            return Char(AsciiChar.Comma).Count(exactCount);
        }

        public static Quantifier Comma(int minCount, int maxCount)
        {
            return Char(AsciiChar.Comma).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotComma()
        {
            return NotChar(AsciiChar.Comma);
        }

        public static Quantifier NotComma(int exactCount)
        {
            return NotChar(AsciiChar.Comma).Count(exactCount);
        }

        public static Quantifier NotComma(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Comma).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Hyphen()
        {
            return Char(AsciiChar.Hyphen);
        }

        public static Quantifier Hyphen(int exactCount)
        {
            return Char(AsciiChar.Hyphen).Count(exactCount);
        }

        public static Quantifier Hyphen(int minCount, int maxCount)
        {
            return Char(AsciiChar.Hyphen).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotHyphen()
        {
            return NotChar(AsciiChar.Hyphen);
        }

        public static Quantifier NotHyphen(int exactCount)
        {
            return NotChar(AsciiChar.Hyphen).Count(exactCount);
        }

        public static Quantifier NotHyphen(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Hyphen).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Period()
        {
            return Char(AsciiChar.Period);
        }

        public static Quantifier Period(int exactCount)
        {
            return Char(AsciiChar.Period).Count(exactCount);
        }

        public static Quantifier Period(int minCount, int maxCount)
        {
            return Char(AsciiChar.Period).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotPeriod()
        {
            return NotChar(AsciiChar.Period);
        }

        public static Quantifier NotPeriod(int exactCount)
        {
            return NotChar(AsciiChar.Period).Count(exactCount);
        }

        public static Quantifier NotPeriod(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Period).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Slash()
        {
            return Char(AsciiChar.Slash);
        }

        public static Quantifier Slash(int exactCount)
        {
            return Char(AsciiChar.Slash).Count(exactCount);
        }

        public static Quantifier Slash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Slash).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotSlash()
        {
            return NotChar(AsciiChar.Slash);
        }

        public static Quantifier NotSlash(int exactCount)
        {
            return NotChar(AsciiChar.Slash).Count(exactCount);
        }

        public static Quantifier NotSlash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Slash).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Colon()
        {
            return Char(AsciiChar.Colon);
        }

        public static Quantifier Colon(int exactCount)
        {
            return Char(AsciiChar.Colon).Count(exactCount);
        }

        public static Quantifier Colon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Colon).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotColon()
        {
            return NotChar(AsciiChar.Colon);
        }

        public static Quantifier NotColon(int exactCount)
        {
            return NotChar(AsciiChar.Colon).Count(exactCount);
        }

        public static Quantifier NotColon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Colon).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Semicolon()
        {
            return Char(AsciiChar.Semicolon);
        }

        public static Quantifier Semicolon(int exactCount)
        {
            return Char(AsciiChar.Semicolon).Count(exactCount);
        }

        public static Quantifier Semicolon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Semicolon).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotSemicolon()
        {
            return NotChar(AsciiChar.Semicolon);
        }

        public static Quantifier NotSemicolon(int exactCount)
        {
            return NotChar(AsciiChar.Semicolon).Count(exactCount);
        }

        public static Quantifier NotSemicolon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Semicolon).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LessThan()
        {
            return Char(AsciiChar.LessThan);
        }

        public static Quantifier LessThan(int exactCount)
        {
            return Char(AsciiChar.LessThan).Count(exactCount);
        }

        public static Quantifier LessThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.LessThan).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLessThan()
        {
            return NotChar(AsciiChar.LessThan);
        }

        public static Quantifier NotLessThan(int exactCount)
        {
            return NotChar(AsciiChar.LessThan).Count(exactCount);
        }

        public static Quantifier NotLessThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LessThan).CountRange(minCount, maxCount);
        }

        public static CharacterPattern EqualsSign()
        {
            return Char(AsciiChar.EqualsSign);
        }

        public static Quantifier EqualsSign(int exactCount)
        {
            return Char(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static Quantifier EqualsSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.EqualsSign).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotEqualsSign()
        {
            return NotChar(AsciiChar.EqualsSign);
        }

        public static Quantifier NotEqualsSign(int exactCount)
        {
            return NotChar(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static Quantifier NotEqualsSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.EqualsSign).CountRange(minCount, maxCount);
        }

        public static CharacterPattern GreaterThan()
        {
            return Char(AsciiChar.GreaterThan);
        }

        public static Quantifier GreaterThan(int exactCount)
        {
            return Char(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static Quantifier GreaterThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.GreaterThan).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotGreaterThan()
        {
            return NotChar(AsciiChar.GreaterThan);
        }

        public static Quantifier NotGreaterThan(int exactCount)
        {
            return NotChar(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static Quantifier NotGreaterThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GreaterThan).CountRange(minCount, maxCount);
        }

        public static CharacterPattern QuestionMark()
        {
            return Char(AsciiChar.QuestionMark);
        }

        public static Quantifier QuestionMark(int exactCount)
        {
            return Char(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static Quantifier QuestionMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuestionMark).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotQuestionMark()
        {
            return NotChar(AsciiChar.QuestionMark);
        }

        public static Quantifier NotQuestionMark(int exactCount)
        {
            return NotChar(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static Quantifier NotQuestionMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuestionMark).CountRange(minCount, maxCount);
        }

        public static CharacterPattern At()
        {
            return Char(AsciiChar.At);
        }

        public static Quantifier At(int exactCount)
        {
            return Char(AsciiChar.At).Count(exactCount);
        }

        public static Quantifier At(int minCount, int maxCount)
        {
            return Char(AsciiChar.At).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotAt()
        {
            return NotChar(AsciiChar.At);
        }

        public static Quantifier NotAt(int exactCount)
        {
            return NotChar(AsciiChar.At).Count(exactCount);
        }

        public static Quantifier NotAt(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.At).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LeftSquareBracket()
        {
            return Char(AsciiChar.LeftSquareBracket);
        }

        public static Quantifier LeftSquareBracket(int exactCount)
        {
            return Char(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static Quantifier LeftSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLeftSquareBracket()
        {
            return NotChar(AsciiChar.LeftSquareBracket);
        }

        public static Quantifier NotLeftSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static Quantifier NotLeftSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Backslash()
        {
            return Char(AsciiChar.Backslash);
        }

        public static Quantifier Backslash(int exactCount)
        {
            return Char(AsciiChar.Backslash).Count(exactCount);
        }

        public static Quantifier Backslash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Backslash).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotBackslash()
        {
            return NotChar(AsciiChar.Backslash);
        }

        public static Quantifier NotBackslash(int exactCount)
        {
            return NotChar(AsciiChar.Backslash).Count(exactCount);
        }

        public static Quantifier NotBackslash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Backslash).CountRange(minCount, maxCount);
        }

        public static CharacterPattern RightSquareBracket()
        {
            return Char(AsciiChar.RightSquareBracket);
        }

        public static Quantifier RightSquareBracket(int exactCount)
        {
            return Char(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static Quantifier RightSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotRightSquareBracket()
        {
            return NotChar(AsciiChar.RightSquareBracket);
        }

        public static Quantifier NotRightSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static Quantifier NotRightSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern CircumflexAccent()
        {
            return Char(AsciiChar.CircumflexAccent);
        }

        public static Quantifier CircumflexAccent(int exactCount)
        {
            return Char(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static Quantifier CircumflexAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.CircumflexAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotCircumflexAccent()
        {
            return NotChar(AsciiChar.CircumflexAccent);
        }

        public static Quantifier NotCircumflexAccent(int exactCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static Quantifier NotCircumflexAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Underscore()
        {
            return Char(AsciiChar.Underscore);
        }

        public static Quantifier Underscore(int exactCount)
        {
            return Char(AsciiChar.Underscore).Count(exactCount);
        }

        public static Quantifier Underscore(int minCount, int maxCount)
        {
            return Char(AsciiChar.Underscore).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotUnderscore()
        {
            return NotChar(AsciiChar.Underscore);
        }

        public static Quantifier NotUnderscore(int exactCount)
        {
            return NotChar(AsciiChar.Underscore).Count(exactCount);
        }

        public static Quantifier NotUnderscore(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Underscore).CountRange(minCount, maxCount);
        }

        public static CharacterPattern GraveAccent()
        {
            return Char(AsciiChar.GraveAccent);
        }

        public static Quantifier GraveAccent(int exactCount)
        {
            return Char(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static Quantifier GraveAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.GraveAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotGraveAccent()
        {
            return NotChar(AsciiChar.GraveAccent);
        }

        public static Quantifier NotGraveAccent(int exactCount)
        {
            return NotChar(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static Quantifier NotGraveAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GraveAccent).CountRange(minCount, maxCount);
        }

        public static CharacterPattern LeftCurlyBracket()
        {
            return Char(AsciiChar.LeftCurlyBracket);
        }

        public static Quantifier LeftCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static Quantifier LeftCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotLeftCurlyBracket()
        {
            return NotChar(AsciiChar.LeftCurlyBracket);
        }

        public static Quantifier NotLeftCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static Quantifier NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern VerticalLine()
        {
            return Char(AsciiChar.VerticalLine);
        }

        public static Quantifier VerticalLine(int exactCount)
        {
            return Char(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static Quantifier VerticalLine(int minCount, int maxCount)
        {
            return Char(AsciiChar.VerticalLine).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotVerticalLine()
        {
            return NotChar(AsciiChar.VerticalLine);
        }

        public static Quantifier NotVerticalLine(int exactCount)
        {
            return NotChar(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static Quantifier NotVerticalLine(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.VerticalLine).CountRange(minCount, maxCount);
        }

        public static CharacterPattern RightCurlyBracket()
        {
            return Char(AsciiChar.RightCurlyBracket);
        }

        public static Quantifier RightCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static Quantifier RightCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotRightCurlyBracket()
        {
            return NotChar(AsciiChar.RightCurlyBracket);
        }

        public static Quantifier NotRightCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static Quantifier NotRightCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).CountRange(minCount, maxCount);
        }

        public static CharacterPattern Tilde()
        {
            return Char(AsciiChar.Tilde);
        }

        public static Quantifier Tilde(int exactCount)
        {
            return Char(AsciiChar.Tilde).Count(exactCount);
        }

        public static Quantifier Tilde(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tilde).CountRange(minCount, maxCount);
        }

        public static QuantifiablePattern NotTilde()
        {
            return NotChar(AsciiChar.Tilde);
        }

        public static Quantifier NotTilde(int exactCount)
        {
            return NotChar(AsciiChar.Tilde).Count(exactCount);
        }

        public static Quantifier NotTilde(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tilde).CountRange(minCount, maxCount);
        }

        public static CharGroup NewLineChar()
        {
            return Char(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static Quantifier NewLineChar(int count)
        {
            return NewLineChar().Count(count);
        }

        public static Quantifier NewLineChar(int minCount, int maxCount)
        {
            return NewLineChar().CountRange(minCount, maxCount);
        }

        public static CharGroup NotNewLineChar()
        {
            return NotChar(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static Quantifier NotNewLineChar(int count)
        {
            return NotNewLineChar().Count(count);
        }

        public static Quantifier NotNewLineChar(int minCount, int maxCount)
        {
            return NotNewLineChar().CountRange(minCount, maxCount);
        }

        public static CharGroup Alphanumeric()
        {
            return Char(CharGroupItems.Alphanumeric());
        }

        public static Quantifier Alphanumeric(int count)
        {
            return Alphanumeric().Count(count);
        }

        public static Quantifier Alphanumeric(int minCount, int maxCount)
        {
            return Alphanumeric().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumeric()
        {
            return NotChar(CharGroupItems.Alphanumeric());
        }

        public static Quantifier NotAlphanumeric(int count)
        {
            return NotAlphanumeric().Count(count);
        }

        public static Quantifier NotAlphanumeric(int minCount, int maxCount)
        {
            return NotAlphanumeric().CountRange(minCount, maxCount);
        }

        public static CharGroup AlphanumericLower()
        {
            return Char(CharGroupItems.AlphanumericLower());
        }

        public static Quantifier AlphanumericLower(int count)
        {
            return AlphanumericLower().Count(count);
        }

        public static Quantifier AlphanumericLower(int minCount, int maxCount)
        {
            return AlphanumericLower().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumericLower()
        {
            return NotChar(CharGroupItems.AlphanumericLower());
        }

        public static Quantifier NotAlphanumericLower(int count)
        {
            return NotAlphanumericLower().Count(count);
        }

        public static Quantifier NotAlphanumericLower(int minCount, int maxCount)
        {
            return NotAlphanumericLower().CountRange(minCount, maxCount);
        }

        public static CharGroup AlphanumericUpper()
        {
            return Char(CharGroupItems.AlphanumericUpper());
        }

        public static Quantifier AlphanumericUpper(int count)
        {
            return AlphanumericUpper().Count(count);
        }

        public static Quantifier AlphanumericUpper(int minCount, int maxCount)
        {
            return AlphanumericUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumericUpper()
        {
            return NotChar(CharGroupItems.AlphanumericUpper());
        }

        public static Quantifier NotAlphanumericUpper(int count)
        {
            return NotAlphanumericUpper().Count(count);
        }

        public static Quantifier NotAlphanumericUpper(int minCount, int maxCount)
        {
            return NotAlphanumericUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup AlphanumericUnderscore()
        {
            return Char(CharGroupItems.AlphanumericUnderscore());
        }

        public static Quantifier AlphanumericUnderscore(int count)
        {
            return AlphanumericUnderscore().Count(count);
        }

        public static Quantifier AlphanumericUnderscore(int minCount, int maxCount)
        {
            return AlphanumericUnderscore().CountRange(minCount, maxCount);
        }

        public static CharGroup NotAlphanumericUnderscore()
        {
            return NotChar(CharGroupItems.AlphanumericUnderscore());
        }

        public static Quantifier NotAlphanumericUnderscore(int count)
        {
            return NotAlphanumericUnderscore().Count(count);
        }

        public static Quantifier NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return NotAlphanumericUnderscore().CountRange(minCount, maxCount);
        }

        public static CharGroup LatinLetter()
        {
            return Char(CharGroupItems.LatinLetter());
        }

        public static Quantifier LatinLetter(int count)
        {
            return LatinLetter().Count(count);
        }

        public static Quantifier LatinLetter(int minCount, int maxCount)
        {
            return LatinLetter().CountRange(minCount, maxCount);
        }

        public static CharGroup LatinLetterLower()
        {
            return Char(CharGroupItems.LatinLetterLower());
        }

        public static Quantifier LatinLetterLower(int count)
        {
            return LatinLetterLower().Count(count);
        }

        public static Quantifier LatinLetterLower(int minCount, int maxCount)
        {
            return LatinLetterLower().CountRange(minCount, maxCount);
        }

        public static CharGroup LatinLetterUpper()
        {
            return Char(CharGroupItems.LatinLetterUpper());
        }

        public static Quantifier LatinLetterUpper(int count)
        {
            return LatinLetterUpper().Count(count);
        }

        public static Quantifier LatinLetterUpper(int minCount, int maxCount)
        {
            return LatinLetterUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup NotLatinLetter()
        {
            return NotChar(CharGroupItems.LatinLetter());
        }

        public static Quantifier NotLatinLetter(int count)
        {
            return NotLatinLetter().Count(count);
        }

        public static Quantifier NotLatinLetter(int minCount, int maxCount)
        {
            return NotLatinLetter().CountRange(minCount, maxCount);
        }

        public static CharGroup NotLatinLetterLower()
        {
            return NotChar(CharGroupItems.LatinLetterLower());
        }

        public static Quantifier NotLatinLetterLower(int count)
        {
            return NotLatinLetterLower().Count(count);
        }

        public static Quantifier NotLatinLetterLower(int minCount, int maxCount)
        {
            return NotLatinLetterLower().CountRange(minCount, maxCount);
        }

        public static CharGroup NotLatinLetterUpper()
        {
            return NotChar(CharGroupItems.LatinLetterUpper());
        }

        public static Quantifier NotLatinLetterUpper(int count)
        {
            return NotLatinLetterUpper().Count(count);
        }

        public static Quantifier NotLatinLetterUpper(int minCount, int maxCount)
        {
            return NotLatinLetterUpper().CountRange(minCount, maxCount);
        }

        public static CharGroup ArabicDigit()
        {
            return Char(CharGroupItems.ArabicDigit());
        }

        public static Quantifier ArabicDigit(int count)
        {
            return ArabicDigit().Count(count);
        }

        public static Quantifier ArabicDigit(int minCount, int maxCount)
        {
            return ArabicDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup NotArabicDigit()
        {
            return NotChar(CharGroupItems.ArabicDigit());
        }

        public static Quantifier NotArabicDigit(int count)
        {
            return NotArabicDigit().Count(count);
        }

        public static Quantifier NotArabicDigit(int minCount, int maxCount)
        {
            return NotArabicDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup HexadecimalDigit()
        {
            return Char(CharGroupItems.HexadecimalDigit());
        }

        public static Quantifier HexadecimalDigit(int count)
        {
            return HexadecimalDigit().Count(count);
        }

        public static Quantifier HexadecimalDigit(int minCount, int maxCount)
        {
            return HexadecimalDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup NotHexadecimalDigit()
        {
            return NotChar(CharGroupItems.HexadecimalDigit());
        }

        public static Quantifier NotHexadecimalDigit(int count)
        {
            return NotHexadecimalDigit().Count(count);
        }

        public static Quantifier NotHexadecimalDigit(int minCount, int maxCount)
        {
            return NotHexadecimalDigit().CountRange(minCount, maxCount);
        }

        public static CharGroup Parenthesis()
        {
            return Char(CharGroupItems.Parenthesis());
        }

        public static Quantifier Parenthesis(int count)
        {
            return Parenthesis().Count(count);
        }

        public static Quantifier Parenthesis(int minCount, int maxCount)
        {
            return Parenthesis().CountRange(minCount, maxCount);
        }

        public static CharGroup NotParenthesis()
        {
            return NotChar(CharGroupItems.Parenthesis());
        }

        public static Quantifier NotParenthesis(int count)
        {
            return NotParenthesis().Count(count);
        }

        public static Quantifier NotParenthesis(int minCount, int maxCount)
        {
            return NotParenthesis().CountRange(minCount, maxCount);
        }

        public static CharGroup CurlyBracket()
        {
            return Char(CharGroupItems.CurlyBracket());
        }

        public static Quantifier CurlyBracket(int count)
        {
            return CurlyBracket().Count(count);
        }

        public static Quantifier CurlyBracket(int minCount, int maxCount)
        {
            return CurlyBracket().CountRange(minCount, maxCount);
        }

        public static CharGroup NotCurlyBracket()
        {
            return NotChar(CharGroupItems.CurlyBracket());
        }

        public static Quantifier NotCurlyBracket(int count)
        {
            return NotCurlyBracket().Count(count);
        }

        public static Quantifier NotCurlyBracket(int minCount, int maxCount)
        {
            return NotCurlyBracket().CountRange(minCount, maxCount);
        }

        public static CharGroup SquareBracket()
        {
            return Char(CharGroupItems.SquareBracket());
        }

        public static Quantifier SquareBracket(int count)
        {
            return SquareBracket().Count(count);
        }

        public static Quantifier SquareBracket(int minCount, int maxCount)
        {
            return SquareBracket().CountRange(minCount, maxCount);
        }

        public static CharGroup NotSquareBracket()
        {
            return NotChar(CharGroupItems.SquareBracket());
        }

        public static Quantifier NotSquareBracket(int count)
        {
            return NotSquareBracket().Count(count);
        }

        public static Quantifier NotSquareBracket(int minCount, int maxCount)
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

        public static Quantifier WhiteSpaceExceptNewLine(int count)
        {
            return WhiteSpaceExceptNewLine().Count(count);
        }

        public static Quantifier WhiteSpaceExceptNewLine(int minCount, int maxCount)
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
