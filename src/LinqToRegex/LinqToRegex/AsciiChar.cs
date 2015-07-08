// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies the Unicode character from first two blocks, i.e. from first 256 Unicode characters.
    /// </summary>
    public enum AsciiChar
    {
        /// <summary>
        /// Null, decimal value: 0, hexadecimal value: 0x00
        /// </summary>
        Null,

        /// <summary>
        /// Start of Heading, decimal value: 1, hexadecimal value: 0x01
        /// </summary>
        StartOfHeading,

        /// <summary>
        /// Start of Text, decimal value: 2, hexadecimal value: 0x02
        /// </summary>
        StartOfText,

        /// <summary>
        /// End of Text, decimal value: 3, hexadecimal value: 0x03
        /// </summary>
        EndOfText,

        /// <summary>
        /// End of Transmission, decimal value: 4, hexadecimal value: 0x04
        /// </summary>
        EndOfTransmission,

        /// <summary>
        /// Enquiry, decimal value: 5, hexadecimal value: 0x05
        /// </summary>
        Enquiry,

        /// <summary>
        /// Acknowledge, decimal value: 6, hexadecimal value: 0x06
        /// </summary>
        Acknowledge,

        /// <summary>
        /// Bell, decimal value: 7, hexadecimal value: 0x07
        /// </summary>
        Bell,

        /// <summary>
        /// Backspace, decimal value: 8, hexadecimal value: 0x08
        /// </summary>
        Backspace,

        /// <summary>
        /// Tab, decimal value: 9, hexadecimal value: 0x09
        /// </summary>
        Tab,

        /// <summary>
        /// Linefeed, decimal value: 10, hexadecimal value: 0x0A
        /// </summary>
        Linefeed,

        /// <summary>
        /// Vertical Tab, decimal value: 11, hexadecimal value: 0x0B
        /// </summary>
        VerticalTab,

        /// <summary>
        /// Form Feed, decimal value: 12, hexadecimal value: 0x0C
        /// </summary>
        FormFeed,

        /// <summary>
        /// Carriage Return, decimal value: 13, hexadecimal value: 0x0D
        /// </summary>
        CarriageReturn,

        /// <summary>
        /// Shift Out, decimal value: 14, hexadecimal value: 0x0E
        /// </summary>
        ShiftOut,

        /// <summary>
        /// Shift In, decimal value: 15, hexadecimal value: 0x0F
        /// </summary>
        ShiftIn,

        /// <summary>
        /// Data Link Escape, decimal value: 16, hexadecimal value: 0x10
        /// </summary>
        DataLinkEscape,

        /// <summary>
        /// Device Control One, decimal value: 17, hexadecimal value: 0x11
        /// </summary>
        DeviceControlOne,

        /// <summary>
        /// Device Control Two, decimal value: 18, hexadecimal value: 0x12
        /// </summary>
        DeviceControlTwo,

        /// <summary>
        /// Device Control Three, decimal value: 19, hexadecimal value: 0x13
        /// </summary>
        DeviceControlThree,

        /// <summary>
        /// Device Control Four, decimal value: 20, hexadecimal value: 0x14
        /// </summary>
        DeviceControlFour,

        /// <summary>
        /// Negative Acknowledge, decimal value: 21, hexadecimal value: 0x15
        /// </summary>
        NegativeAcknowledge,

        /// <summary>
        /// Synchronous Idle, decimal value: 22, hexadecimal value: 0x16
        /// </summary>
        SynchronousIdle,

        /// <summary>
        /// End of Transmission Block, decimal value: 23, hexadecimal value: 0x17
        /// </summary>
        EndOfTransmissionBlock,

        /// <summary>
        /// Cancel, decimal value: 24, hexadecimal value: 0x18
        /// </summary>
        Cancel,

        /// <summary>
        /// End of Medium, decimal value: 25, hexadecimal value: 0x19
        /// </summary>
        EndOfMedium,

        /// <summary>
        /// Substitute, decimal value: 26, hexadecimal value: 0x1A
        /// </summary>
        Substitute,

        /// <summary>
        /// Escape, decimal value: 27, hexadecimal value: 0x1B
        /// </summary>
        Escape,

        /// <summary>
        /// Information Separator Four, decimal value: 28, hexadecimal value: 0x1C
        /// </summary>
        InformationSeparatorFour,

        /// <summary>
        /// Information Separator Three, decimal value: 29, hexadecimal value: 0x1D
        /// </summary>
        InformationSeparatorThree,

        /// <summary>
        /// Information Separator Two, decimal value: 30, hexadecimal value: 0x1E
        /// </summary>
        InformationSeparatorTwo,

        /// <summary>
        /// Information Separator One, decimal value: 31, hexadecimal value: 0x1F
        /// </summary>
        InformationSeparatorOne,

        /// <summary>
        /// Space, decimal value: 32, hexadecimal value: 0x20
        /// </summary>
        Space,

        /// <summary>
        /// Exclamation Mark, decimal value: 33, hexadecimal value: 0x21
        /// </summary>
        ExclamationMark,

        /// <summary>
        /// Quote Mark, decimal value: 34, hexadecimal value: 0x22
        /// </summary>
        QuoteMark,

        /// <summary>
        /// Number Sign, decimal value: 35, hexadecimal value: 0x23
        /// </summary>
        NumberSign,

        /// <summary>
        /// Dollar, decimal value: 36, hexadecimal value: 0x24
        /// </summary>
        Dollar,

        /// <summary>
        /// Percent, decimal value: 37, hexadecimal value: 0x25
        /// </summary>
        Percent,

        /// <summary>
        /// Ampersand, decimal value: 38, hexadecimal value: 0x26
        /// </summary>
        Ampersand,

        /// <summary>
        /// Apostrophe, decimal value: 39, hexadecimal value: 0x27
        /// </summary>
        Apostrophe,

        /// <summary>
        /// Start (Left) Parenthesis, decimal value: 40, hexadecimal value: 0x28
        /// </summary>
        StartParenthesis,

        /// <summary>
        /// End (Right) Parenthesis, decimal value: 41, hexadecimal value: 0x29
        /// </summary>
        EndParenthesis,

        /// <summary>
        /// Asterisk, decimal value: 42, hexadecimal value: 0x2A
        /// </summary>
        Asterisk,

        /// <summary>
        /// Plus, decimal value: 43, hexadecimal value: 0x2B
        /// </summary>
        Plus,

        /// <summary>
        /// Comma, decimal value: 44, hexadecimal value: 0x2C
        /// </summary>
        Comma,

        /// <summary>
        /// Hyphen, decimal value: 45, hexadecimal value: 0x2D
        /// </summary>
        Hyphen,

        /// <summary>
        /// Dot (Period), decimal value: 46, hexadecimal value: 0x2E
        /// </summary>
        Dot,

        /// <summary>
        /// Slash, decimal value: 47, hexadecimal value: 0x2F
        /// </summary>
        Slash,

        /// <summary>
        /// Digit Zero, decimal value: 48, hexadecimal value: 0x30
        /// </summary>
        DigitZero,

        /// <summary>
        /// Digit One, decimal value: 49, hexadecimal value: 0x31
        /// </summary>
        DigitOne,

        /// <summary>
        /// Digit Two, decimal value: 50, hexadecimal value: 0x32
        /// </summary>
        DigitTwo,

        /// <summary>
        /// Digit Three, decimal value: 51, hexadecimal value: 0x33
        /// </summary>
        DigitThree,

        /// <summary>
        /// Digit Four, decimal value: 52, hexadecimal value: 0x34
        /// </summary>
        DigitFour,

        /// <summary>
        /// Digit Five, decimal value: 53, hexadecimal value: 0x35
        /// </summary>
        DigitFive,

        /// <summary>
        /// Digit Six, decimal value: 54, hexadecimal value: 0x36
        /// </summary>
        DigitSix,

        /// <summary>
        /// Digit Seven, decimal value: 55, hexadecimal value: 0x37
        /// </summary>
        DigitSeven,

        /// <summary>
        /// Digit Eight, decimal value: 56, hexadecimal value: 0x38
        /// </summary>
        DigitEight,

        /// <summary>
        /// Digit Nine, decimal value: 57, hexadecimal value: 0x39
        /// </summary>
        DigitNine,

        /// <summary>
        /// Colon, decimal value: 58, hexadecimal value: 0x3A
        /// </summary>
        Colon,

        /// <summary>
        /// Semicolon, decimal value: 59, hexadecimal value: 0x3B
        /// </summary>
        Semicolon,

        /// <summary>
        /// Start Angle Bracket (Less-Than Sign), decimal value: 60, hexadecimal value: 0x3C
        /// </summary>
        StartAngleBracket,

        /// <summary>
        /// Equals Sign, decimal value: 61, hexadecimal value: 0x3D
        /// </summary>
        EqualsSign,

        /// <summary>
        /// End Angle Bracket (Greater-Than Sign), decimal value: 62, hexadecimal value: 0x3E
        /// </summary>
        EndAngleBracket,

        /// <summary>
        /// Question Mark, decimal value: 63, hexadecimal value: 0x3F
        /// </summary>
        QuestionMark,

        /// <summary>
        /// At Sign, decimal value: 64, hexadecimal value: 0x40
        /// </summary>
        AtSign,

        /// <summary>
        /// Capital Letter A, decimal value: 65, hexadecimal value: 0x41
        /// </summary>
        CapitalLetterA,

        /// <summary>
        /// Capital Letter B, decimal value: 66, hexadecimal value: 0x42
        /// </summary>
        CapitalLetterB,

        /// <summary>
        /// Capital Letter C, decimal value: 67, hexadecimal value: 0x43
        /// </summary>
        CapitalLetterC,

        /// <summary>
        /// Capital Letter D, decimal value: 68, hexadecimal value: 0x44
        /// </summary>
        CapitalLetterD,

        /// <summary>
        /// Capital Letter E, decimal value: 69, hexadecimal value: 0x45
        /// </summary>
        CapitalLetterE,

        /// <summary>
        /// Capital Letter F, decimal value: 70, hexadecimal value: 0x46
        /// </summary>
        CapitalLetterF,

        /// <summary>
        /// Capital Letter G, decimal value: 71, hexadecimal value: 0x47
        /// </summary>
        CapitalLetterG,

        /// <summary>
        /// Capital Letter H, decimal value: 72, hexadecimal value: 0x48
        /// </summary>
        CapitalLetterH,

        /// <summary>
        /// Capital Letter I, decimal value: 73, hexadecimal value: 0x49
        /// </summary>
        CapitalLetterI,

        /// <summary>
        /// Capital Letter J, decimal value: 74, hexadecimal value: 0x4A
        /// </summary>
        CapitalLetterJ,

        /// <summary>
        /// Capital Letter K, decimal value: 75, hexadecimal value: 0x4B
        /// </summary>
        CapitalLetterK,

        /// <summary>
        /// Capital Letter L, decimal value: 76, hexadecimal value: 0x4C
        /// </summary>
        CapitalLetterL,

        /// <summary>
        /// Capital Letter M, decimal value: 77, hexadecimal value: 0x4D
        /// </summary>
        CapitalLetterM,

        /// <summary>
        /// Capital Letter N, decimal value: 78, hexadecimal value: 0x4E
        /// </summary>
        CapitalLetterN,

        /// <summary>
        /// Capital Letter O, decimal value: 79, hexadecimal value: 0x4F
        /// </summary>
        CapitalLetterO,

        /// <summary>
        /// Capital Letter P, decimal value: 80, hexadecimal value: 0x50
        /// </summary>
        CapitalLetterP,

        /// <summary>
        /// Capital Letter Q, decimal value: 81, hexadecimal value: 0x51
        /// </summary>
        CapitalLetterQ,

        /// <summary>
        /// Capital Letter R, decimal value: 82, hexadecimal value: 0x52
        /// </summary>
        CapitalLetterR,

        /// <summary>
        /// Capital Letter S, decimal value: 83, hexadecimal value: 0x53
        /// </summary>
        CapitalLetterS,

        /// <summary>
        /// Capital Letter T, decimal value: 84, hexadecimal value: 0x54
        /// </summary>
        CapitalLetterT,

        /// <summary>
        /// Capital Letter U, decimal value: 85, hexadecimal value: 0x55
        /// </summary>
        CapitalLetterU,

        /// <summary>
        /// Capital Letter V, decimal value: 86, hexadecimal value: 0x56
        /// </summary>
        CapitalLetterV,

        /// <summary>
        /// Capital Letter W, decimal value: 87, hexadecimal value: 0x57
        /// </summary>
        CapitalLetterW,

        /// <summary>
        /// Capital Letter X, decimal value: 88, hexadecimal value: 0x58
        /// </summary>
        CapitalLetterX,

        /// <summary>
        /// Capital Letter Y, decimal value: 89, hexadecimal value: 0x59
        /// </summary>
        CapitalLetterY,

        /// <summary>
        /// Capital Letter Z, decimal value: 90, hexadecimal value: 0x5A
        /// </summary>
        CapitalLetterZ,

        /// <summary>
        /// Start (Left) Square Bracket, decimal value: 91, hexadecimal value: 0x5B
        /// </summary>
        StartSquareBracket,

        /// <summary>
        /// Backslash, decimal value: 92, hexadecimal value: 0x5C
        /// </summary>
        Backslash,

        /// <summary>
        /// End (Right) Square Bracket, decimal value: 93, hexadecimal value: 0x5D
        /// </summary>
        EndSquareBracket,

        /// <summary>
        /// Circumflex Accent, decimal value: 94, hexadecimal value: 0x5E
        /// </summary>
        CircumflexAccent,

        /// <summary>
        /// Underscore, decimal value: 95, hexadecimal value: 0x5F
        /// </summary>
        Underscore,

        /// <summary>
        /// Grave Accent, decimal value: 96, hexadecimal value: 0x60
        /// </summary>
        GraveAccent,

        /// <summary>
        /// Small Letter A, decimal value: 97, hexadecimal value: 0x61
        /// </summary>
        SmallLetterA,

        /// <summary>
        /// Small Letter B, decimal value: 98, hexadecimal value: 0x62
        /// </summary>
        SmallLetterB,

        /// <summary>
        /// Small Letter C, decimal value: 99, hexadecimal value: 0x63
        /// </summary>
        SmallLetterC,

        /// <summary>
        /// Small Letter D, decimal value: 100, hexadecimal value: 0x64
        /// </summary>
        SmallLetterD,

        /// <summary>
        /// Small Letter E, decimal value: 101, hexadecimal value: 0x65
        /// </summary>
        SmallLetterE,

        /// <summary>
        /// Small Letter F, decimal value: 102, hexadecimal value: 0x66
        /// </summary>
        SmallLetterF,

        /// <summary>
        /// Small Letter G, decimal value: 103, hexadecimal value: 0x67
        /// </summary>
        SmallLetterG,

        /// <summary>
        /// Small Letter H, decimal value: 104, hexadecimal value: 0x68
        /// </summary>
        SmallLetterH,

        /// <summary>
        /// Small Letter I, decimal value: 105, hexadecimal value: 0x69
        /// </summary>
        SmallLetterI,

        /// <summary>
        /// Small Letter J, decimal value: 106, hexadecimal value: 0x6A
        /// </summary>
        SmallLetterJ,

        /// <summary>
        /// Small Letter K, decimal value: 107, hexadecimal value: 0x6B
        /// </summary>
        SmallLetterK,

        /// <summary>
        /// Small Letter L, decimal value: 108, hexadecimal value: 0x6C
        /// </summary>
        SmallLetterL,

        /// <summary>
        /// Small Letter M, decimal value: 109, hexadecimal value: 0x6D
        /// </summary>
        SmallLetterM,

        /// <summary>
        /// Small Letter N, decimal value: 110, hexadecimal value: 0x6E
        /// </summary>
        SmallLetterN,

        /// <summary>
        /// Small Letter O, decimal value: 111, hexadecimal value: 0x6F
        /// </summary>
        SmallLetterO,

        /// <summary>
        /// Small Letter P, decimal value: 112, hexadecimal value: 0x70
        /// </summary>
        SmallLetterP,

        /// <summary>
        /// Small Letter Q, decimal value: 113, hexadecimal value: 0x71
        /// </summary>
        SmallLetterQ,

        /// <summary>
        /// Small Letter R, decimal value: 114, hexadecimal value: 0x72
        /// </summary>
        SmallLetterR,

        /// <summary>
        /// Small Letter S, decimal value: 115, hexadecimal value: 0x73
        /// </summary>
        SmallLetterS,

        /// <summary>
        /// Small Letter T, decimal value: 116, hexadecimal value: 0x74
        /// </summary>
        SmallLetterT,

        /// <summary>
        /// Small Letter U, decimal value: 117, hexadecimal value: 0x75
        /// </summary>
        SmallLetterU,

        /// <summary>
        /// Small Letter V, decimal value: 118, hexadecimal value: 0x76
        /// </summary>
        SmallLetterV,

        /// <summary>
        /// Small Letter W, decimal value: 119, hexadecimal value: 0x77
        /// </summary>
        SmallLetterW,

        /// <summary>
        /// Small Letter X, decimal value: 120, hexadecimal value: 0x78
        /// </summary>
        SmallLetterX,

        /// <summary>
        /// Small Letter Y, decimal value: 121, hexadecimal value: 0x79
        /// </summary>
        SmallLetterY,

        /// <summary>
        /// Small Letter Z, decimal value: 122, hexadecimal value: 0x7A
        /// </summary>
        SmallLetterZ,

        /// <summary>
        /// Start (Left) Curly Bracket, decimal value: 123, hexadecimal value: 0x7B
        /// </summary>
        StartCurlyBracket,

        /// <summary>
        /// Vertical Line, decimal value: 124, hexadecimal value: 0x7C
        /// </summary>
        VerticalLine,

        /// <summary>
        /// End (Right) Curly Bracket, decimal value: 125, hexadecimal value: 0x7D
        /// </summary>
        EndCurlyBracket,

        /// <summary>
        /// Tilde, decimal value: 126, hexadecimal value: 0x7E
        /// </summary>
        Tilde,

        /// <summary>
        /// Delete, decimal value: 127, hexadecimal value: 0x7F
        /// </summary>
        Delete,
    }
}
