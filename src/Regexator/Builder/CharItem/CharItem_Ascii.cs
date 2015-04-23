// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public sealed partial class CharItem
    {
        public CharItem Tab()
        {
            return Append(Create(AsciiChar.Tab));
        }

        public CharItem Linefeed()
        {
            return Append(Create(AsciiChar.Linefeed));
        }

        public CharItem CarriageReturn()
        {
            return Append(Create(AsciiChar.CarriageReturn));
        }

        public CharItem Space()
        {
            return Append(Create(AsciiChar.Space));
        }

        public CharItem ExclamationMark()
        {
            return Append(Create(AsciiChar.ExclamationMark));
        }

        public CharItem QuotationMark()
        {
            return Append(Create(AsciiChar.QuotationMark));
        }

        public CharItem NumberSign()
        {
            return Append(Create(AsciiChar.NumberSign));
        }

        public CharItem Dollar()
        {
            return Append(Create(AsciiChar.Dollar));
        }

        public CharItem Percent()
        {
            return Append(Create(AsciiChar.Percent));
        }

        public CharItem Ampersand()
        {
            return Append(Create(AsciiChar.Ampersand));
        }

        public CharItem Apostrophe()
        {
            return Append(Create(AsciiChar.Apostrophe));
        }

        public CharItem LeftParenthesis()
        {
            return Append(Create(AsciiChar.LeftParenthesis));
        }

        public CharItem RightParenthesis()
        {
            return Append(Create(AsciiChar.RightParenthesis));
        }

        public CharItem Asterisk()
        {
            return Append(Create(AsciiChar.Asterisk));
        }

        public CharItem Plus()
        {
            return Append(Create(AsciiChar.Plus));
        }

        public CharItem Comma()
        {
            return Append(Create(AsciiChar.Comma));
        }

        public CharItem Hyphen()
        {
            return Append(Create(AsciiChar.Hyphen));
        }

        public CharItem Period()
        {
            return Append(Create(AsciiChar.Period));
        }

        public CharItem Slash()
        {
            return Append(Create(AsciiChar.Slash));
        }

        public CharItem Colon()
        {
            return Append(Create(AsciiChar.Colon));
        }

        public CharItem Semicolon()
        {
            return Append(Create(AsciiChar.Semicolon));
        }

        public CharItem LessThan()
        {
            return Append(Create(AsciiChar.LessThan));
        }

        public CharItem EqualsSign()
        {
            return Append(Create(AsciiChar.EqualsSign));
        }

        public CharItem GreaterThan()
        {
            return Append(Create(AsciiChar.GreaterThan));
        }

        public CharItem QuestionMark()
        {
            return Append(Create(AsciiChar.QuestionMark));
        }

        public CharItem At()
        {
            return Append(Create(AsciiChar.At));
        }

        public CharItem LeftSquareBracket()
        {
            return Append(Create(AsciiChar.LeftSquareBracket));
        }

        public CharItem Backslash()
        {
            return Append(Create(AsciiChar.Backslash));
        }

        public CharItem RightSquareBracket()
        {
            return Append(Create(AsciiChar.RightSquareBracket));
        }

        public CharItem CircumflexAccent()
        {
            return Append(Create(AsciiChar.CircumflexAccent));
        }

        public CharItem Underscore()
        {
            return Append(Create(AsciiChar.Underscore));
        }

        public CharItem GraveAccent()
        {
            return Append(Create(AsciiChar.GraveAccent));
        }

        public CharItem LeftCurlyBracket()
        {
            return Append(Create(AsciiChar.LeftCurlyBracket));
        }

        public CharItem VerticalLine()
        {
            return Append(Create(AsciiChar.VerticalLine));
        }

        public CharItem RightCurlyBracket()
        {
            return Append(Create(AsciiChar.RightCurlyBracket));
        }

        public CharItem Tilde()
        {
            return Append(Create(AsciiChar.Tilde));
        }
    }
}
