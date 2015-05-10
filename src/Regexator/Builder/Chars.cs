// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    public static class Chars
    {
        public static CharGroupExpression Char(string chars)
        {
            return new CharsCharGroup(chars);
        }

        public static CharGroupExpression Char(CharGroupItem item)
        {
            return new CharItemGroup(item);
        }

        public static CharGroupExpression Char(IEnumerable<char> values)
        {
            return new CharGroup(values);
        }

        public static CharGroupExpression Char(IEnumerable<int> charCodes)
        {
            return new CharCodeGroup(charCodes);
        }

        public static CharGroupExpression Char(IEnumerable<AsciiChar> values)
        {
            return new AsciiCharGroup(values);
        }

        public static CharGroupExpression Char(IEnumerable<CharClass> values)
        {
            return new CharClassGroup(values);
        }

        public static CharGroupExpression Char(IEnumerable<NamedBlock> blocks)
        {
            return new NamedBlockGroup(blocks);
        }

        public static CharGroupExpression Char(IEnumerable<GeneralCategory> categories)
        {
            return new GeneralCategoryGroup(categories);
        }

        public static CharGroupExpression NotChar(string chars)
        {
            return new NotCharsCharGroup(chars);
        }

        public static CharGroupExpression NotChar(CharGroupItem item)
        {
            return new NotCharItemGroup(item);
        }

        public static CharGroupExpression NotChar(IEnumerable<char> values)
        {
            return new NotCharGroup(values);
        }

        public static CharGroupExpression NotChar(IEnumerable<int> charCodes)
        {
            return new NotCharCodeGroup(charCodes);
        }

        public static CharGroupExpression NotChar(IEnumerable<AsciiChar> values)
        {
            return new NotAsciiCharGroup(values);
        }

        public static CharGroupExpression NotChar(IEnumerable<NamedBlock> blocks)
        {
            return new NotNamedBlockGroup(blocks);
        }

        public static CharGroupExpression NotChar(IEnumerable<GeneralCategory> categories)
        {
            return new NotGeneralCategoryGroup(categories);
        }

        public static CharGroupExpression Range(char first, char last)
        {
            return new CharRangeGroup(first, last);
        }

        public static CharGroupExpression Range(int firstCharCode, int lastCharCode)
        {
            return new CharCodeRangeGroup(firstCharCode, lastCharCode);
        }

        public static CharGroupExpression ArabicDigitRange(int first, int last)
        {
            return new ArabicDigitRangeGroup(first, last);
        }

        public static CharGroupExpression NotRange(char first, char last)
        {
            return new NotCharRangeGroup(first, last);
        }

        public static CharGroupExpression NotRange(int firstCharCode, int lastCharCode)
        {
            return new NotCharCodeRangeGroup(firstCharCode, lastCharCode);
        }

        public static CharGroupExpression NotArabicDigitRange(int first, int last)
        {
            return new NotArabicDigitRangeGroup(first, last);
        }

        public static CharSubtraction Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        public static CharSubtraction NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new NotCharSubtraction(baseGroup, excludedGroup);
        }

        public static CharGroupExpression Alphanumeric()
        {
            return Char(CharGroupItems.Alphanumeric());
        }

        public static CharGroupExpression LatinAlphabet()
        {
            return Char(CharGroupItems.LatinAlphabet());
        }

        public static CharGroupExpression ArabicDigit()
        {
            return Char(CharGroupItems.ArabicDigit());
        }

        public static QuantifiableExpression Any()
        {
            return new AnyCharExpression();
        }

        public static CharGroupExpression AnyInvariant()
        {
            return Char(CharGroupItems.WhiteSpace().NotWhiteSpace());
        }

        public static Expression AnyMaybeManyLazy()
        {
            return Any().MaybeMany().Lazy();
        }

        public static QuantifiableExpression Digit()
        {
            return new CharClassExpression(CharClass.Digit);
        }

        public static QuantifierExpression Digit(int count)
        {
            return new CharClassExpression(CharClass.Digit).Count(count);
        }

        public static QuantifierExpression Digit(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.Digit).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotDigit()
        {
            return new CharClassExpression(CharClass.NotDigit);
        }

        public static QuantifierExpression NotDigit(int count)
        {
            return new CharClassExpression(CharClass.NotDigit).Count(count);
        }

        public static QuantifierExpression NotDigit(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.NotDigit).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression WhiteSpace()
        {
            return new CharClassExpression(CharClass.WhiteSpace);
        }

        public static QuantifierExpression WhiteSpace(int count)
        {
            return new CharClassExpression(CharClass.WhiteSpace).Count(count);
        }

        public static QuantifierExpression WhiteSpace(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.WhiteSpace).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotWhiteSpace()
        {
            return new CharClassExpression(CharClass.NotWhiteSpace);
        }

        public static QuantifierExpression NotWhiteSpace(int count)
        {
            return new CharClassExpression(CharClass.NotWhiteSpace).Count(count);
        }

        public static QuantifierExpression NotWhiteSpace(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.NotWhiteSpace).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression WordChar()
        {
            return new CharClassExpression(CharClass.WordChar);
        }

        public static QuantifierExpression WordChar(int count)
        {
            return new CharClassExpression(CharClass.WordChar).Count(count);
        }

        public static QuantifierExpression WordChar(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.WordChar).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotWordChar()
        {
            return new CharClassExpression(CharClass.NotWordChar);
        }

        public static QuantifierExpression NotWordChar(int count)
        {
            return new CharClassExpression(CharClass.NotWordChar).Count(count);
        }

        public static QuantifierExpression NotWordChar(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.NotWordChar).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Char(char value)
        {
            return new CharExpression(value);
        }

        public static QuantifiableExpression Char(int charCode)
        {
            return new CharCodeExpression(charCode);
        }

        public static QuantifiableExpression Char(AsciiChar value)
        {
            return new AsciiCharExpression(value);
        }

        public static QuantifiableExpression Char(CharClass value)
        {
            return new CharClassExpression(value);
        }

        public static QuantifiableExpression NamedBlock(NamedBlock block)
        {
            return new NamedBlockExpression(block);
        }

        public static QuantifiableExpression GeneralCategory(GeneralCategory category)
        {
            return new GeneralCategoryExpression(category);
        }

        public static CharGroupExpression NotChar(char value)
        {
            return new NotCharGroup(value);
        }

        public static CharGroupExpression NotChar(int charCode)
        {
            return new NotCharCodeGroup(charCode);
        }

        public static CharGroupExpression NotChar(AsciiChar value)
        {
            return new NotAsciiCharGroup(value);
        }

        public static QuantifiableExpression NotNamedBlock(NamedBlock block)
        {
            return new NotNamedBlockExpression(block);
        }

        public static QuantifiableExpression NotGeneralCategory(GeneralCategory category)
        {
            return new NotGeneralCategoryExpression(category);
        }

        public static QuantifiableExpression Tab()
        {
            return Char(AsciiChar.Tab);
        }

        public static QuantifierExpression Tab(int exactCount)
        {
            return Char(AsciiChar.Tab).Count(exactCount);
        }

        public static QuantifierExpression Tab(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tab).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotTab()
        {
            return NotChar(AsciiChar.Tab);
        }

        public static QuantifierExpression NotTab(int exactCount)
        {
            return NotChar(AsciiChar.Tab).Count(exactCount);
        }

        public static QuantifierExpression NotTab(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tab).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Linefeed()
        {
            return Char(AsciiChar.Linefeed);
        }

        public static QuantifierExpression Linefeed(int exactCount)
        {
            return Char(AsciiChar.Linefeed).Count(exactCount);
        }

        public static QuantifierExpression Linefeed(int minCount, int maxCount)
        {
            return Char(AsciiChar.Linefeed).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotLinefeed()
        {
            return NotChar(AsciiChar.Linefeed);
        }

        public static QuantifierExpression NotLinefeed(int exactCount)
        {
            return NotChar(AsciiChar.Linefeed).Count(exactCount);
        }

        public static QuantifierExpression NotLinefeed(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Linefeed).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression CarriageReturn()
        {
            return Char(AsciiChar.CarriageReturn);
        }

        public static QuantifierExpression CarriageReturn(int exactCount)
        {
            return Char(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static QuantifierExpression CarriageReturn(int minCount, int maxCount)
        {
            return Char(AsciiChar.CarriageReturn).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotCarriageReturn()
        {
            return NotChar(AsciiChar.CarriageReturn);
        }

        public static QuantifierExpression NotCarriageReturn(int exactCount)
        {
            return NotChar(AsciiChar.CarriageReturn).Count(exactCount);
        }

        public static QuantifierExpression NotCarriageReturn(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CarriageReturn).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Space()
        {
            return Char(AsciiChar.Space);
        }

        public static QuantifierExpression Space(int exactCount)
        {
            return Char(AsciiChar.Space).Count(exactCount);
        }

        public static QuantifierExpression Space(int minCount, int maxCount)
        {
            return Char(AsciiChar.Space).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpace()
        {
            return NotChar(AsciiChar.Space);
        }

        public static QuantifierExpression NotSpace(int exactCount)
        {
            return NotChar(AsciiChar.Space).Count(exactCount);
        }

        public static QuantifierExpression NotSpace(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Space).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression ExclamationMark()
        {
            return Char(AsciiChar.ExclamationMark);
        }

        public static QuantifierExpression ExclamationMark(int exactCount)
        {
            return Char(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static QuantifierExpression ExclamationMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.ExclamationMark).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotExclamationMark()
        {
            return NotChar(AsciiChar.ExclamationMark);
        }

        public static QuantifierExpression NotExclamationMark(int exactCount)
        {
            return NotChar(AsciiChar.ExclamationMark).Count(exactCount);
        }

        public static QuantifierExpression NotExclamationMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.ExclamationMark).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression QuotationMark()
        {
            return Char(AsciiChar.QuotationMark);
        }

        public static QuantifierExpression QuotationMark(int exactCount)
        {
            return Char(AsciiChar.QuotationMark).Count(exactCount);
        }

        public static QuantifierExpression QuotationMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuotationMark).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotQuotationMark()
        {
            return NotChar(AsciiChar.QuotationMark);
        }

        public static QuantifierExpression NotQuotationMark(int exactCount)
        {
            return NotChar(AsciiChar.QuotationMark).Count(exactCount);
        }

        public static QuantifierExpression NotQuotationMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuotationMark).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NumberSign()
        {
            return Char(AsciiChar.NumberSign);
        }

        public static QuantifierExpression NumberSign(int exactCount)
        {
            return Char(AsciiChar.NumberSign).Count(exactCount);
        }

        public static QuantifierExpression NumberSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.NumberSign).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberSign()
        {
            return NotChar(AsciiChar.NumberSign);
        }

        public static QuantifierExpression NotNumberSign(int exactCount)
        {
            return NotChar(AsciiChar.NumberSign).Count(exactCount);
        }

        public static QuantifierExpression NotNumberSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.NumberSign).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Dollar()
        {
            return Char(AsciiChar.Dollar);
        }

        public static QuantifierExpression Dollar(int exactCount)
        {
            return Char(AsciiChar.Dollar).Count(exactCount);
        }

        public static QuantifierExpression Dollar(int minCount, int maxCount)
        {
            return Char(AsciiChar.Dollar).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotDollar()
        {
            return NotChar(AsciiChar.Dollar);
        }

        public static QuantifierExpression NotDollar(int exactCount)
        {
            return NotChar(AsciiChar.Dollar).Count(exactCount);
        }

        public static QuantifierExpression NotDollar(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Dollar).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Percent()
        {
            return Char(AsciiChar.Percent);
        }

        public static QuantifierExpression Percent(int exactCount)
        {
            return Char(AsciiChar.Percent).Count(exactCount);
        }

        public static QuantifierExpression Percent(int minCount, int maxCount)
        {
            return Char(AsciiChar.Percent).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotPercent()
        {
            return NotChar(AsciiChar.Percent);
        }

        public static QuantifierExpression NotPercent(int exactCount)
        {
            return NotChar(AsciiChar.Percent).Count(exactCount);
        }

        public static QuantifierExpression NotPercent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Percent).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Ampersand()
        {
            return Char(AsciiChar.Ampersand);
        }

        public static QuantifierExpression Ampersand(int exactCount)
        {
            return Char(AsciiChar.Ampersand).Count(exactCount);
        }

        public static QuantifierExpression Ampersand(int minCount, int maxCount)
        {
            return Char(AsciiChar.Ampersand).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotAmpersand()
        {
            return NotChar(AsciiChar.Ampersand);
        }

        public static QuantifierExpression NotAmpersand(int exactCount)
        {
            return NotChar(AsciiChar.Ampersand).Count(exactCount);
        }

        public static QuantifierExpression NotAmpersand(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Ampersand).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Apostrophe()
        {
            return Char(AsciiChar.Apostrophe);
        }

        public static QuantifierExpression Apostrophe(int exactCount)
        {
            return Char(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static QuantifierExpression Apostrophe(int minCount, int maxCount)
        {
            return Char(AsciiChar.Apostrophe).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotApostrophe()
        {
            return NotChar(AsciiChar.Apostrophe);
        }

        public static QuantifierExpression NotApostrophe(int exactCount)
        {
            return NotChar(AsciiChar.Apostrophe).Count(exactCount);
        }

        public static QuantifierExpression NotApostrophe(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Apostrophe).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression LeftParenthesis()
        {
            return Char(AsciiChar.LeftParenthesis);
        }

        public static QuantifierExpression LeftParenthesis(int exactCount)
        {
            return Char(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static QuantifierExpression LeftParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotLeftParenthesis()
        {
            return NotChar(AsciiChar.LeftParenthesis);
        }

        public static QuantifierExpression NotLeftParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).Count(exactCount);
        }

        public static QuantifierExpression NotLeftParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression RightParenthesis()
        {
            return Char(AsciiChar.RightParenthesis);
        }

        public static QuantifierExpression RightParenthesis(int exactCount)
        {
            return Char(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static QuantifierExpression RightParenthesis(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotRightParenthesis()
        {
            return NotChar(AsciiChar.RightParenthesis);
        }

        public static QuantifierExpression NotRightParenthesis(int exactCount)
        {
            return NotChar(AsciiChar.RightParenthesis).Count(exactCount);
        }

        public static QuantifierExpression NotRightParenthesis(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightParenthesis).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Asterisk()
        {
            return Char(AsciiChar.Asterisk);
        }

        public static QuantifierExpression Asterisk(int exactCount)
        {
            return Char(AsciiChar.Asterisk).Count(exactCount);
        }

        public static QuantifierExpression Asterisk(int minCount, int maxCount)
        {
            return Char(AsciiChar.Asterisk).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotAsterisk()
        {
            return NotChar(AsciiChar.Asterisk);
        }

        public static QuantifierExpression NotAsterisk(int exactCount)
        {
            return NotChar(AsciiChar.Asterisk).Count(exactCount);
        }

        public static QuantifierExpression NotAsterisk(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Asterisk).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Plus()
        {
            return Char(AsciiChar.Plus);
        }

        public static QuantifierExpression Plus(int exactCount)
        {
            return Char(AsciiChar.Plus).Count(exactCount);
        }

        public static QuantifierExpression Plus(int minCount, int maxCount)
        {
            return Char(AsciiChar.Plus).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotPlus()
        {
            return NotChar(AsciiChar.Plus);
        }

        public static QuantifierExpression NotPlus(int exactCount)
        {
            return NotChar(AsciiChar.Plus).Count(exactCount);
        }

        public static QuantifierExpression NotPlus(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Plus).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Comma()
        {
            return Char(AsciiChar.Comma);
        }

        public static QuantifierExpression Comma(int exactCount)
        {
            return Char(AsciiChar.Comma).Count(exactCount);
        }

        public static QuantifierExpression Comma(int minCount, int maxCount)
        {
            return Char(AsciiChar.Comma).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotComma()
        {
            return NotChar(AsciiChar.Comma);
        }

        public static QuantifierExpression NotComma(int exactCount)
        {
            return NotChar(AsciiChar.Comma).Count(exactCount);
        }

        public static QuantifierExpression NotComma(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Comma).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Hyphen()
        {
            return Char(AsciiChar.Hyphen);
        }

        public static QuantifierExpression Hyphen(int exactCount)
        {
            return Char(AsciiChar.Hyphen).Count(exactCount);
        }

        public static QuantifierExpression Hyphen(int minCount, int maxCount)
        {
            return Char(AsciiChar.Hyphen).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotHyphen()
        {
            return NotChar(AsciiChar.Hyphen);
        }

        public static QuantifierExpression NotHyphen(int exactCount)
        {
            return NotChar(AsciiChar.Hyphen).Count(exactCount);
        }

        public static QuantifierExpression NotHyphen(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Hyphen).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Period()
        {
            return Char(AsciiChar.Period);
        }

        public static QuantifierExpression Period(int exactCount)
        {
            return Char(AsciiChar.Period).Count(exactCount);
        }

        public static QuantifierExpression Period(int minCount, int maxCount)
        {
            return Char(AsciiChar.Period).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotPeriod()
        {
            return NotChar(AsciiChar.Period);
        }

        public static QuantifierExpression NotPeriod(int exactCount)
        {
            return NotChar(AsciiChar.Period).Count(exactCount);
        }

        public static QuantifierExpression NotPeriod(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Period).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Slash()
        {
            return Char(AsciiChar.Slash);
        }

        public static QuantifierExpression Slash(int exactCount)
        {
            return Char(AsciiChar.Slash).Count(exactCount);
        }

        public static QuantifierExpression Slash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Slash).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotSlash()
        {
            return NotChar(AsciiChar.Slash);
        }

        public static QuantifierExpression NotSlash(int exactCount)
        {
            return NotChar(AsciiChar.Slash).Count(exactCount);
        }

        public static QuantifierExpression NotSlash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Slash).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Colon()
        {
            return Char(AsciiChar.Colon);
        }

        public static QuantifierExpression Colon(int exactCount)
        {
            return Char(AsciiChar.Colon).Count(exactCount);
        }

        public static QuantifierExpression Colon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Colon).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotColon()
        {
            return NotChar(AsciiChar.Colon);
        }

        public static QuantifierExpression NotColon(int exactCount)
        {
            return NotChar(AsciiChar.Colon).Count(exactCount);
        }

        public static QuantifierExpression NotColon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Colon).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Semicolon()
        {
            return Char(AsciiChar.Semicolon);
        }

        public static QuantifierExpression Semicolon(int exactCount)
        {
            return Char(AsciiChar.Semicolon).Count(exactCount);
        }

        public static QuantifierExpression Semicolon(int minCount, int maxCount)
        {
            return Char(AsciiChar.Semicolon).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotSemicolon()
        {
            return NotChar(AsciiChar.Semicolon);
        }

        public static QuantifierExpression NotSemicolon(int exactCount)
        {
            return NotChar(AsciiChar.Semicolon).Count(exactCount);
        }

        public static QuantifierExpression NotSemicolon(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Semicolon).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression LessThan()
        {
            return Char(AsciiChar.LessThan);
        }

        public static QuantifierExpression LessThan(int exactCount)
        {
            return Char(AsciiChar.LessThan).Count(exactCount);
        }

        public static QuantifierExpression LessThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.LessThan).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotLessThan()
        {
            return NotChar(AsciiChar.LessThan);
        }

        public static QuantifierExpression NotLessThan(int exactCount)
        {
            return NotChar(AsciiChar.LessThan).Count(exactCount);
        }

        public static QuantifierExpression NotLessThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LessThan).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression EqualsSign()
        {
            return Char(AsciiChar.EqualsSign);
        }

        public static QuantifierExpression EqualsSign(int exactCount)
        {
            return Char(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static QuantifierExpression EqualsSign(int minCount, int maxCount)
        {
            return Char(AsciiChar.EqualsSign).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotEqualsSign()
        {
            return NotChar(AsciiChar.EqualsSign);
        }

        public static QuantifierExpression NotEqualsSign(int exactCount)
        {
            return NotChar(AsciiChar.EqualsSign).Count(exactCount);
        }

        public static QuantifierExpression NotEqualsSign(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.EqualsSign).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression GreaterThan()
        {
            return Char(AsciiChar.GreaterThan);
        }

        public static QuantifierExpression GreaterThan(int exactCount)
        {
            return Char(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static QuantifierExpression GreaterThan(int minCount, int maxCount)
        {
            return Char(AsciiChar.GreaterThan).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreaterThan()
        {
            return NotChar(AsciiChar.GreaterThan);
        }

        public static QuantifierExpression NotGreaterThan(int exactCount)
        {
            return NotChar(AsciiChar.GreaterThan).Count(exactCount);
        }

        public static QuantifierExpression NotGreaterThan(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GreaterThan).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression QuestionMark()
        {
            return Char(AsciiChar.QuestionMark);
        }

        public static QuantifierExpression QuestionMark(int exactCount)
        {
            return Char(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static QuantifierExpression QuestionMark(int minCount, int maxCount)
        {
            return Char(AsciiChar.QuestionMark).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotQuestionMark()
        {
            return NotChar(AsciiChar.QuestionMark);
        }

        public static QuantifierExpression NotQuestionMark(int exactCount)
        {
            return NotChar(AsciiChar.QuestionMark).Count(exactCount);
        }

        public static QuantifierExpression NotQuestionMark(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.QuestionMark).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression At()
        {
            return Char(AsciiChar.At);
        }

        public static QuantifierExpression At(int exactCount)
        {
            return Char(AsciiChar.At).Count(exactCount);
        }

        public static QuantifierExpression At(int minCount, int maxCount)
        {
            return Char(AsciiChar.At).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotAt()
        {
            return NotChar(AsciiChar.At);
        }

        public static QuantifierExpression NotAt(int exactCount)
        {
            return NotChar(AsciiChar.At).Count(exactCount);
        }

        public static QuantifierExpression NotAt(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.At).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression LeftSquareBracket()
        {
            return Char(AsciiChar.LeftSquareBracket);
        }

        public static QuantifierExpression LeftSquareBracket(int exactCount)
        {
            return Char(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static QuantifierExpression LeftSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotLeftSquareBracket()
        {
            return NotChar(AsciiChar.LeftSquareBracket);
        }

        public static QuantifierExpression NotLeftSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).Count(exactCount);
        }

        public static QuantifierExpression NotLeftSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Backslash()
        {
            return Char(AsciiChar.Backslash);
        }

        public static QuantifierExpression Backslash(int exactCount)
        {
            return Char(AsciiChar.Backslash).Count(exactCount);
        }

        public static QuantifierExpression Backslash(int minCount, int maxCount)
        {
            return Char(AsciiChar.Backslash).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotBackslash()
        {
            return NotChar(AsciiChar.Backslash);
        }

        public static QuantifierExpression NotBackslash(int exactCount)
        {
            return NotChar(AsciiChar.Backslash).Count(exactCount);
        }

        public static QuantifierExpression NotBackslash(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Backslash).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression RightSquareBracket()
        {
            return Char(AsciiChar.RightSquareBracket);
        }

        public static QuantifierExpression RightSquareBracket(int exactCount)
        {
            return Char(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static QuantifierExpression RightSquareBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotRightSquareBracket()
        {
            return NotChar(AsciiChar.RightSquareBracket);
        }

        public static QuantifierExpression NotRightSquareBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).Count(exactCount);
        }

        public static QuantifierExpression NotRightSquareBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightSquareBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression CircumflexAccent()
        {
            return Char(AsciiChar.CircumflexAccent);
        }

        public static QuantifierExpression CircumflexAccent(int exactCount)
        {
            return Char(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static QuantifierExpression CircumflexAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.CircumflexAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotCircumflexAccent()
        {
            return NotChar(AsciiChar.CircumflexAccent);
        }

        public static QuantifierExpression NotCircumflexAccent(int exactCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).Count(exactCount);
        }

        public static QuantifierExpression NotCircumflexAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.CircumflexAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Underscore()
        {
            return Char(AsciiChar.Underscore);
        }

        public static QuantifierExpression Underscore(int exactCount)
        {
            return Char(AsciiChar.Underscore).Count(exactCount);
        }

        public static QuantifierExpression Underscore(int minCount, int maxCount)
        {
            return Char(AsciiChar.Underscore).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotUnderscore()
        {
            return NotChar(AsciiChar.Underscore);
        }

        public static QuantifierExpression NotUnderscore(int exactCount)
        {
            return NotChar(AsciiChar.Underscore).Count(exactCount);
        }

        public static QuantifierExpression NotUnderscore(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Underscore).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression GraveAccent()
        {
            return Char(AsciiChar.GraveAccent);
        }

        public static QuantifierExpression GraveAccent(int exactCount)
        {
            return Char(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static QuantifierExpression GraveAccent(int minCount, int maxCount)
        {
            return Char(AsciiChar.GraveAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotGraveAccent()
        {
            return NotChar(AsciiChar.GraveAccent);
        }

        public static QuantifierExpression NotGraveAccent(int exactCount)
        {
            return NotChar(AsciiChar.GraveAccent).Count(exactCount);
        }

        public static QuantifierExpression NotGraveAccent(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.GraveAccent).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression LeftCurlyBracket()
        {
            return Char(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifierExpression LeftCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static QuantifierExpression LeftCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.LeftCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotLeftCurlyBracket()
        {
            return NotChar(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifierExpression NotLeftCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).Count(exactCount);
        }

        public static QuantifierExpression NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.LeftCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression VerticalLine()
        {
            return Char(AsciiChar.VerticalLine);
        }

        public static QuantifierExpression VerticalLine(int exactCount)
        {
            return Char(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static QuantifierExpression VerticalLine(int minCount, int maxCount)
        {
            return Char(AsciiChar.VerticalLine).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotVerticalLine()
        {
            return NotChar(AsciiChar.VerticalLine);
        }

        public static QuantifierExpression NotVerticalLine(int exactCount)
        {
            return NotChar(AsciiChar.VerticalLine).Count(exactCount);
        }

        public static QuantifierExpression NotVerticalLine(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.VerticalLine).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression RightCurlyBracket()
        {
            return Char(AsciiChar.RightCurlyBracket);
        }

        public static QuantifierExpression RightCurlyBracket(int exactCount)
        {
            return Char(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static QuantifierExpression RightCurlyBracket(int minCount, int maxCount)
        {
            return Char(AsciiChar.RightCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotRightCurlyBracket()
        {
            return NotChar(AsciiChar.RightCurlyBracket);
        }

        public static QuantifierExpression NotRightCurlyBracket(int exactCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).Count(exactCount);
        }

        public static QuantifierExpression NotRightCurlyBracket(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.RightCurlyBracket).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression Tilde()
        {
            return Char(AsciiChar.Tilde);
        }

        public static QuantifierExpression Tilde(int exactCount)
        {
            return Char(AsciiChar.Tilde).Count(exactCount);
        }

        public static QuantifierExpression Tilde(int minCount, int maxCount)
        {
            return Char(AsciiChar.Tilde).CountRange(minCount, maxCount);
        }

        public static QuantifiableExpression NotTilde()
        {
            return NotChar(AsciiChar.Tilde);
        }

        public static QuantifierExpression NotTilde(int exactCount)
        {
            return NotChar(AsciiChar.Tilde).Count(exactCount);
        }

        public static QuantifierExpression NotTilde(int minCount, int maxCount)
        {
            return NotChar(AsciiChar.Tilde).CountRange(minCount, maxCount);
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return new CharSubtraction(CharGroupItems.WhiteSpace(), CharGroupItems.CarriageReturn().Linefeed());
        }

        public static CharSubtraction WordExceptArabicDigit()
        {
            return new CharSubtraction(CharGroupItems.WordChar(), CharGroupItems.ArabicDigit());
        }
    }
}