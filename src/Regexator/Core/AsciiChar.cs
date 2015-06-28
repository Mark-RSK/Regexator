// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    /// <summary>
    /// Specifies a character from first two Unicode blocks, i.e. from first 256 Unicode characters.
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
        /// Left Parenthesis, decimal value: 40, hexadecimal value: 0x28
        /// </summary>
        LeftParenthesis,

        /// <summary>
        /// Right Parenthesis, decimal value: 41, hexadecimal value: 0x29
        /// </summary>
        RightParenthesis,

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
        /// Period, decimal value: 46, hexadecimal value: 0x2E
        /// </summary>
        Period,

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
        /// Less Than, decimal value: 60, hexadecimal value: 0x3C
        /// </summary>
        LessThan,

        /// <summary>
        /// Equals Sign, decimal value: 61, hexadecimal value: 0x3D
        /// </summary>
        EqualsSign,

        /// <summary>
        /// Greater Than, decimal value: 62, hexadecimal value: 0x3E
        /// </summary>
        GreaterThan,

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
        /// Left Square Bracket, decimal value: 91, hexadecimal value: 0x5B
        /// </summary>
        LeftSquareBracket,

        /// <summary>
        /// Backslash, decimal value: 92, hexadecimal value: 0x5C
        /// </summary>
        Backslash,

        /// <summary>
        /// Right Square Bracket, decimal value: 93, hexadecimal value: 0x5D
        /// </summary>
        RightSquareBracket,

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
        /// Left Curly Bracket, decimal value: 123, hexadecimal value: 0x7B
        /// </summary>
        LeftCurlyBracket,

        /// <summary>
        /// Vertical Line, decimal value: 124, hexadecimal value: 0x7C
        /// </summary>
        VerticalLine,

        /// <summary>
        /// Right Curly Bracket, decimal value: 125, hexadecimal value: 0x7D
        /// </summary>
        RightCurlyBracket,

        /// <summary>
        /// Tilde, decimal value: 126, hexadecimal value: 0x7E
        /// </summary>
        Tilde,

        /// <summary>
        /// Delete, decimal value: 127, hexadecimal value: 0x7F
        /// </summary>
        Delete,

        /// <summary>
        /// Control128, decimal value: 128, hexadecimal value: 0x80
        /// </summary>
        Control128,

        /// <summary>
        /// Control129, decimal value: 129, hexadecimal value: 0x81
        /// </summary>
        Control129,

        /// <summary>
        /// Break Permitted Here, decimal value: 130, hexadecimal value: 0x82
        /// </summary>
        BreakPermittedHere,

        /// <summary>
        /// No Break Here, decimal value: 131, hexadecimal value: 0x83
        /// </summary>
        NoBreakHere,

        /// <summary>
        /// Control132, decimal value: 132, hexadecimal value: 0x84
        /// </summary>
        Control132,

        /// <summary>
        /// Next Line, decimal value: 133, hexadecimal value: 0x85
        /// </summary>
        NextLine,

        /// <summary>
        /// Start of Selected Area, decimal value: 134, hexadecimal value: 0x86
        /// </summary>
        StartOfSelectedArea,

        /// <summary>
        /// End of Selected Area, decimal value: 135, hexadecimal value: 0x87
        /// </summary>
        EndOfSelectedArea,

        /// <summary>
        /// Character Tabulation Set, decimal value: 136, hexadecimal value: 0x88
        /// </summary>
        CharacterTabulationSet,

        /// <summary>
        /// Character Tabulation with Justification, decimal value: 137, hexadecimal value: 0x89
        /// </summary>
        CharacterTabulationWithJustification,

        /// <summary>
        /// Line Tabulation Set, decimal value: 138, hexadecimal value: 0x8A
        /// </summary>
        LineTabulationSet,

        /// <summary>
        /// Partial Line Forward, decimal value: 139, hexadecimal value: 0x8B
        /// </summary>
        PartialLineForward,

        /// <summary>
        /// Partial Line Backward, decimal value: 140, hexadecimal value: 0x8C
        /// </summary>
        PartialLineBackward,

        /// <summary>
        /// Reverse Linefeed, decimal value: 141, hexadecimal value: 0x8D
        /// </summary>
        ReverseLinefeed,

        /// <summary>
        /// Single Shift Two, decimal value: 142, hexadecimal value: 0x8E
        /// </summary>
        SingleShiftTwo,

        /// <summary>
        /// Single Shift Three, decimal value: 143, hexadecimal value: 0x8F
        /// </summary>
        SingleShiftThree,

        /// <summary>
        /// Device Control String, decimal value: 144, hexadecimal value: 0x90
        /// </summary>
        DeviceControlString,

        /// <summary>
        /// Private Use One, decimal value: 145, hexadecimal value: 0x91
        /// </summary>
        PrivateUseOne,

        /// <summary>
        /// Private Use Two, decimal value: 146, hexadecimal value: 0x92
        /// </summary>
        PrivateUseTwo,

        /// <summary>
        /// Set Transmit State, decimal value: 147, hexadecimal value: 0x93
        /// </summary>
        SetTransmitState,

        /// <summary>
        /// Cancel Character, decimal value: 148, hexadecimal value: 0x94
        /// </summary>
        CancelCharacter,

        /// <summary>
        /// Message Waiting, decimal value: 149, hexadecimal value: 0x95
        /// </summary>
        MessageWaiting,

        /// <summary>
        /// Start of Guarded Area, decimal value: 150, hexadecimal value: 0x96
        /// </summary>
        StartOfGuardedArea,

        /// <summary>
        /// End of Guarded Area, decimal value: 151, hexadecimal value: 0x97
        /// </summary>
        EndOfGuardedArea,

        /// <summary>
        /// Start of String, decimal value: 152, hexadecimal value: 0x98
        /// </summary>
        StartOfString,

        /// <summary>
        /// Control153, decimal value: 153, hexadecimal value: 0x99
        /// </summary>
        Control153,

        /// <summary>
        /// Single Character Introducer, decimal value: 154, hexadecimal value: 0x9A
        /// </summary>
        SingleCharacterIntroducer,

        /// <summary>
        /// Control Sequence Introducer, decimal value: 155, hexadecimal value: 0x9B
        /// </summary>
        ControlSequenceIntroducer,

        /// <summary>
        /// String Terminator, decimal value: 156, hexadecimal value: 0x9C
        /// </summary>
        StringTerminator,

        /// <summary>
        /// Operating System Command, decimal value: 157, hexadecimal value: 0x9D
        /// </summary>
        OperatingSystemCommand,

        /// <summary>
        /// Privacy Message, decimal value: 158, hexadecimal value: 0x9E
        /// </summary>
        PrivacyMessage,

        /// <summary>
        /// Application Program Command, decimal value: 159, hexadecimal value: 0x9F
        /// </summary>
        ApplicationProgramCommand,

        /// <summary>
        /// No Break Space, decimal value: 160, hexadecimal value: 0xA0
        /// </summary>
        NoBreakSpace,

        /// <summary>
        /// Inverted Exclamation Mark, decimal value: 161, hexadecimal value: 0xA1
        /// </summary>
        InvertedExclamationMark,

        /// <summary>
        /// Cent Sign, decimal value: 162, hexadecimal value: 0xA2
        /// </summary>
        CentSign,

        /// <summary>
        /// Pound Sign, decimal value: 163, hexadecimal value: 0xA3
        /// </summary>
        PoundSign,

        /// <summary>
        /// Currency Sign, decimal value: 164, hexadecimal value: 0xA4
        /// </summary>
        CurrencySign,

        /// <summary>
        /// Yen Sign, decimal value: 165, hexadecimal value: 0xA5
        /// </summary>
        YenSign,

        /// <summary>
        /// Broken Bar, decimal value: 166, hexadecimal value: 0xA6
        /// </summary>
        BrokenBar,

        /// <summary>
        /// Section Sign, decimal value: 167, hexadecimal value: 0xA7
        /// </summary>
        SectionSign,

        /// <summary>
        /// Diaeresis, decimal value: 168, hexadecimal value: 0xA8
        /// </summary>
        Diaeresis,

        /// <summary>
        /// Copyright Sign, decimal value: 169, hexadecimal value: 0xA9
        /// </summary>
        CopyrightSign,

        /// <summary>
        /// Feminine Ordinal Indicator, decimal value: 170, hexadecimal value: 0xAA
        /// </summary>
        FeminineOrdinalIndicator,

        /// <summary>
        /// Left Pointing Double Angle Quotation Mark, decimal value: 171, hexadecimal value: 0xAB
        /// </summary>
        LeftPointingDoubleAngleQuotationMark,

        /// <summary>
        /// Not Sign, decimal value: 172, hexadecimal value: 0xAC
        /// </summary>
        NotSign,

        /// <summary>
        /// Soft Hyphen, decimal value: 173, hexadecimal value: 0xAD
        /// </summary>
        SoftHyphen,

        /// <summary>
        /// Registered Sign, decimal value: 174, hexadecimal value: 0xAE
        /// </summary>
        RegisteredSign,

        /// <summary>
        /// Macron, decimal value: 175, hexadecimal value: 0xAF
        /// </summary>
        Macron,

        /// <summary>
        /// Degree Sign, decimal value: 176, hexadecimal value: 0xB0
        /// </summary>
        DegreeSign,

        /// <summary>
        /// Plus Minus, decimal value: 177, hexadecimal value: 0xB1
        /// </summary>
        PlusMinus,

        /// <summary>
        /// Superscript Two, decimal value: 178, hexadecimal value: 0xB2
        /// </summary>
        SuperscriptTwo,

        /// <summary>
        /// Superscript Three, decimal value: 179, hexadecimal value: 0xB3
        /// </summary>
        SuperscriptThree,

        /// <summary>
        /// Acute Accent, decimal value: 180, hexadecimal value: 0xB4
        /// </summary>
        AcuteAccent,

        /// <summary>
        /// Micro Sign, decimal value: 181, hexadecimal value: 0xB5
        /// </summary>
        MicroSign,

        /// <summary>
        /// Pilcrow Sign, decimal value: 182, hexadecimal value: 0xB6
        /// </summary>
        PilcrowSign,

        /// <summary>
        /// Middle Dot, decimal value: 183, hexadecimal value: 0xB7
        /// </summary>
        MiddleDot,

        /// <summary>
        /// Cedilla, decimal value: 184, hexadecimal value: 0xB8
        /// </summary>
        Cedilla,

        /// <summary>
        /// Superscript One, decimal value: 185, hexadecimal value: 0xB9
        /// </summary>
        SuperscriptOne,

        /// <summary>
        /// Masculine Ordinal Indicator, decimal value: 186, hexadecimal value: 0xBA
        /// </summary>
        MasculineOrdinalIndicator,

        /// <summary>
        /// Right Pointing Double Angle Quotation Mark, decimal value: 187, hexadecimal value: 0xBB
        /// </summary>
        RightPointingDoubleAngleQuotationMark,

        /// <summary>
        /// Vulgar Fraction One Quarter, decimal value: 188, hexadecimal value: 0xBC
        /// </summary>
        VulgarFractionOneQuarter,

        /// <summary>
        /// Vulgar Fraction One Half, decimal value: 189, hexadecimal value: 0xBD
        /// </summary>
        VulgarFractionOneHalf,

        /// <summary>
        /// Vulgar Fraction Three Quarters, decimal value: 190, hexadecimal value: 0xBE
        /// </summary>
        VulgarFractionThreeQuarters,

        /// <summary>
        /// Inverted Question Mark, decimal value: 191, hexadecimal value: 0xBF
        /// </summary>
        InvertedQuestionMark,

        /// <summary>
        /// Capital Letter A with Grave, decimal value: 192, hexadecimal value: 0xC0
        /// </summary>
        CapitalLetterAWithGrave,

        /// <summary>
        /// Capital Letter A with Acute, decimal value: 193, hexadecimal value: 0xC1
        /// </summary>
        CapitalLetterAWithAcute,

        /// <summary>
        /// Capital Letter A with Circumflex, decimal value: 194, hexadecimal value: 0xC2
        /// </summary>
        CapitalLetterAWithCircumflex,

        /// <summary>
        /// Capital Letter A with Tilde, decimal value: 195, hexadecimal value: 0xC3
        /// </summary>
        CapitalLetterAWithTilde,

        /// <summary>
        /// Capital Letter A with Diaeresis, decimal value: 196, hexadecimal value: 0xC4
        /// </summary>
        CapitalLetterAWithDiaeresis,

        /// <summary>
        /// Capital Letter A with Ring Above, decimal value: 197, hexadecimal value: 0xC5
        /// </summary>
        CapitalLetterAWithRingAbove,

        /// <summary>
        /// Capital Letter AE, decimal value: 198, hexadecimal value: 0xC6
        /// </summary>
        CapitalLetterAE,

        /// <summary>
        /// Capital Letter C with Cedilla, decimal value: 199, hexadecimal value: 0xC7
        /// </summary>
        CapitalLetterCWithCedilla,

        /// <summary>
        /// Capital Letter E with Grave, decimal value: 200, hexadecimal value: 0xC8
        /// </summary>
        CapitalLetterEWithGrave,

        /// <summary>
        /// Capital Letter E with Acute, decimal value: 201, hexadecimal value: 0xC9
        /// </summary>
        CapitalLetterEWithAcute,

        /// <summary>
        /// Capital Letter E with Circumflex, decimal value: 202, hexadecimal value: 0xCA
        /// </summary>
        CapitalLetterEWithCircumflex,

        /// <summary>
        /// Capital Letter E with Diaeresis, decimal value: 203, hexadecimal value: 0xCB
        /// </summary>
        CapitalLetterEWithDiaeresis,

        /// <summary>
        /// Capital Letter I with Grave, decimal value: 204, hexadecimal value: 0xCC
        /// </summary>
        CapitalLetterIWithGrave,

        /// <summary>
        /// Capital Letter I with Acute, decimal value: 205, hexadecimal value: 0xCD
        /// </summary>
        CapitalLetterIWithAcute,

        /// <summary>
        /// Capital Letter I with Circumflex, decimal value: 206, hexadecimal value: 0xCE
        /// </summary>
        CapitalLetterIWithCircumflex,

        /// <summary>
        /// Capital Letter I with Diaeresis, decimal value: 207, hexadecimal value: 0xCF
        /// </summary>
        CapitalLetterIWithDiaeresis,

        /// <summary>
        /// Capital Letter Eth, decimal value: 208, hexadecimal value: 0xD0
        /// </summary>
        CapitalLetterEth,

        /// <summary>
        /// Capital Letter N with Tilde, decimal value: 209, hexadecimal value: 0xD1
        /// </summary>
        CapitalLetterNWithTilde,

        /// <summary>
        /// Capital Letter O with Grave, decimal value: 210, hexadecimal value: 0xD2
        /// </summary>
        CapitalLetterOWithGrave,

        /// <summary>
        /// Capital Letter O with Acute, decimal value: 211, hexadecimal value: 0xD3
        /// </summary>
        CapitalLetterOWithAcute,

        /// <summary>
        /// Capital Letter O with Circumflex, decimal value: 212, hexadecimal value: 0xD4
        /// </summary>
        CapitalLetterOWithCircumflex,

        /// <summary>
        /// Capital Letter O with Tilde, decimal value: 213, hexadecimal value: 0xD5
        /// </summary>
        CapitalLetterOWithTilde,

        /// <summary>
        /// Capital Letter O with Diaeresis, decimal value: 214, hexadecimal value: 0xD6
        /// </summary>
        CapitalLetterOWithDiaeresis,

        /// <summary>
        /// Multiplication Sign, decimal value: 215, hexadecimal value: 0xD7
        /// </summary>
        MultiplicationSign,

        /// <summary>
        /// Capital Letter O with Stroke, decimal value: 216, hexadecimal value: 0xD8
        /// </summary>
        CapitalLetterOWithStroke,

        /// <summary>
        /// Capital Letter U with Grave, decimal value: 217, hexadecimal value: 0xD9
        /// </summary>
        CapitalLetterUWithGrave,

        /// <summary>
        /// Capital Letter U with Acute, decimal value: 218, hexadecimal value: 0xDA
        /// </summary>
        CapitalLetterUWithAcute,

        /// <summary>
        /// Capital Letter U with Circumflex, decimal value: 219, hexadecimal value: 0xDB
        /// </summary>
        CapitalLetterUWithCircumflex,

        /// <summary>
        /// Capital Letter U with Diaeresis, decimal value: 220, hexadecimal value: 0xDC
        /// </summary>
        CapitalLetterUWithDiaeresis,

        /// <summary>
        /// Capital Letter Y with Acute, decimal value: 221, hexadecimal value: 0xDD
        /// </summary>
        CapitalLetterYWithAcute,

        /// <summary>
        /// Capital Letter Thorn, decimal value: 222, hexadecimal value: 0xDE
        /// </summary>
        CapitalLetterThorn,

        /// <summary>
        /// Small Letter Sharp S, decimal value: 223, hexadecimal value: 0xDF
        /// </summary>
        SmallLetterSharpS,

        /// <summary>
        /// Small Letter A with Grave, decimal value: 224, hexadecimal value: 0xE0
        /// </summary>
        SmallLetterAWithGrave,

        /// <summary>
        /// Small Letter A with Acute, decimal value: 225, hexadecimal value: 0xE1
        /// </summary>
        SmallLetterAWithAcute,

        /// <summary>
        /// Small Letter A with Circumflex, decimal value: 226, hexadecimal value: 0xE2
        /// </summary>
        SmallLetterAWithCircumflex,

        /// <summary>
        /// Small Letter A with Tilde, decimal value: 227, hexadecimal value: 0xE3
        /// </summary>
        SmallLetterAWithTilde,

        /// <summary>
        /// Small Letter A with Diaeresis, decimal value: 228, hexadecimal value: 0xE4
        /// </summary>
        SmallLetterAWithDiaeresis,

        /// <summary>
        /// Small Letter A with Ring Above, decimal value: 229, hexadecimal value: 0xE5
        /// </summary>
        SmallLetterAWithRingAbove,

        /// <summary>
        /// Small Letter AE, decimal value: 230, hexadecimal value: 0xE6
        /// </summary>
        SmallLetterAE,

        /// <summary>
        /// Small Letter C with Cedilla, decimal value: 231, hexadecimal value: 0xE7
        /// </summary>
        SmallLetterCWithCedilla,

        /// <summary>
        /// Small Letter E with Grave, decimal value: 232, hexadecimal value: 0xE8
        /// </summary>
        SmallLetterEWithGrave,

        /// <summary>
        /// Small Letter E with Acute, decimal value: 233, hexadecimal value: 0xE9
        /// </summary>
        SmallLetterEWithAcute,

        /// <summary>
        /// Small Letter E with Circumflex, decimal value: 234, hexadecimal value: 0xEA
        /// </summary>
        SmallLetterEWithCircumflex,

        /// <summary>
        /// Small Letter E with Diaeresis, decimal value: 235, hexadecimal value: 0xEB
        /// </summary>
        SmallLetterEWithDiaeresis,

        /// <summary>
        /// Small Letter I with Grave, decimal value: 236, hexadecimal value: 0xEC
        /// </summary>
        SmallLetterIWithGrave,

        /// <summary>
        /// Small Letter I with Acute, decimal value: 237, hexadecimal value: 0xED
        /// </summary>
        SmallLetterIWithAcute,

        /// <summary>
        /// Small Letter I with Circumflex, decimal value: 238, hexadecimal value: 0xEE
        /// </summary>
        SmallLetterIWithCircumflex,

        /// <summary>
        /// Small Letter I with Diaeresis, decimal value: 239, hexadecimal value: 0xEF
        /// </summary>
        SmallLetterIWithDiaeresis,

        /// <summary>
        /// Small Letter Eth, decimal value: 240, hexadecimal value: 0xF0
        /// </summary>
        SmallLetterEth,

        /// <summary>
        /// Small Letter N with Tilde, decimal value: 241, hexadecimal value: 0xF1
        /// </summary>
        SmallLetterNWithTilde,

        /// <summary>
        /// Small Letter O with Grave, decimal value: 242, hexadecimal value: 0xF2
        /// </summary>
        SmallLetterOWithGrave,

        /// <summary>
        /// Small Letter O with Acute, decimal value: 243, hexadecimal value: 0xF3
        /// </summary>
        SmallLetterOWithAcute,

        /// <summary>
        /// Small Letter O with Circumflex, decimal value: 244, hexadecimal value: 0xF4
        /// </summary>
        SmallLetterOWithCircumflex,

        /// <summary>
        /// Small Letter O with Tilde, decimal value: 245, hexadecimal value: 0xF5
        /// </summary>
        SmallLetterOWithTilde,

        /// <summary>
        /// Small Letter O with Diaeresis, decimal value: 246, hexadecimal value: 0xF6
        /// </summary>
        SmallLetterOWithDiaeresis,

        /// <summary>
        /// Division Sign, decimal value: 247, hexadecimal value: 0xF7
        /// </summary>
        DivisionSign,

        /// <summary>
        /// Small Letter O with Stroke, decimal value: 248, hexadecimal value: 0xF8
        /// </summary>
        SmallLetterOWithStroke,

        /// <summary>
        /// Small Letter U with Grave, decimal value: 249, hexadecimal value: 0xF9
        /// </summary>
        SmallLetterUWithGrave,

        /// <summary>
        /// Small Letter U with Acute, decimal value: 250, hexadecimal value: 0xFA
        /// </summary>
        SmallLetterUWithAcute,

        /// <summary>
        /// Small Letter U with Circumflex, decimal value: 251, hexadecimal value: 0xFB
        /// </summary>
        SmallLetterUWithCircumflex,

        /// <summary>
        /// Small Letter U with Diaeresis, decimal value: 252, hexadecimal value: 0xFC
        /// </summary>
        SmallLetterUWithDiaeresis,

        /// <summary>
        /// Small Letter Y with Acute, decimal value: 253, hexadecimal value: 0xFD
        /// </summary>
        SmallLetterYWithAcute,

        /// <summary>
        /// Small Letter Thorn, decimal value: 254, hexadecimal value: 0xFE
        /// </summary>
        SmallLetterThorn,

        /// <summary>
        /// Small Letter Y with Diaeresis, , decimal value: 255, hexadecimal value: 0xFF
        /// </summary>
        SmallLetterYWithDiaeresis,
    }
}
