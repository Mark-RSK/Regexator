﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public enum AsciiChar
    {
        Null = 0,
        StartOfHeading = 1,
        StartOfText = 2,
        EndOfText = 3,
        EndOfTransmission = 4,
        Enquiry = 5,
        Acknowledge = 6,
        Bell = 7,
        Backspace = 8,
        Tab = 9,
        Linefeed = 10,
        VerticalTab = 11,
        FormFeed = 12,
        CarriageReturn = 13,
        ShiftOut = 14,
        ShiftIn = 15,
        DataLinkEscape = 16,
        DeviceControlOne = 17,
        DeviceControlTwo = 18,
        DeviceControlThree = 19,
        DeviceControlFour = 20,
        NegativeAcknowledge = 21,
        SynchronousIdle = 22,
        EndOfTransmissionBlock = 23,
        Cancel = 24,
        EndOfMedium = 25,
        Substitute = 26,
        Escape = 27,
        InformationSeparatorFour = 28,
        InformationSeparatorThree = 29,
        InformationSeparatorTwo = 30,
        InformationSeparatorOne = 31,
        Space = 32,
        ExclamationMark = 33,
        QuoteMark = 34,
        NumberSign = 35,
        Dollar = 36,
        Percent = 37,
        Ampersand = 38,
        Apostrophe = 39,
        LeftParenthesis = 40,
        RightParenthesis = 41,
        Asterisk = 42,
        Plus = 43,
        Comma = 44,
        Hyphen = 45,
        Period = 46,
        Slash = 47,
        DigitZero = 48,
        DigitOne = 49,
        DigitTwo = 50,
        DigitThree = 51,
        DigitFour = 52,
        DigitFive = 53,
        DigitSix = 54,
        DigitSeven = 55,
        DigitEight = 56,
        DigitNine = 57,
        Colon = 58,
        Semicolon = 59,
        LessThan = 60,
        EqualsSign = 61,
        GreaterThan = 62,
        QuestionMark = 63,
        At = 64,
        CapitalLetterA = 65,
        CapitalLetterB = 66,
        CapitalLetterC = 67,
        CapitalLetterD = 68,
        CapitalLetterE = 69,
        CapitalLetterF = 70,
        CapitalLetterG = 71,
        CapitalLetterH = 72,
        CapitalLetterI = 73,
        CapitalLetterJ = 74,
        CapitalLetterK = 75,
        CapitalLetterL = 76,
        CapitalLetterM = 77,
        CapitalLetterN = 78,
        CapitalLetterO = 79,
        CapitalLetterP = 80,
        CapitalLetterQ = 81,
        CapitalLetterR = 82,
        CapitalLetterS = 83,
        CapitalLetterT = 84,
        CapitalLetterU = 85,
        CapitalLetterV = 86,
        CapitalLetterW = 87,
        CapitalLetterX = 88,
        CapitalLetterY = 89,
        CapitalLetterZ = 90,
        LeftSquareBracket = 91,
        Backslash = 92,
        RightSquareBracket = 93,
        CircumflexAccent = 94,
        Underscore = 95,
        GraveAccent = 96,
        SmallLetterA = 97,
        SmallLetterB = 98,
        SmallLetterC = 99,
        SmallLetterD = 100,
        SmallLetterE = 101,
        SmallLetterF = 102,
        SmallLetterG = 103,
        SmallLetterH = 104,
        SmallLetterI = 105,
        SmallLetterJ = 106,
        SmallLetterK = 107,
        SmallLetterL = 108,
        SmallLetterM = 109,
        SmallLetterN = 110,
        SmallLetterO = 111,
        SmallLetterP = 112,
        SmallLetterQ = 113,
        SmallLetterR = 114,
        SmallLetterS = 115,
        SmallLetterT = 116,
        SmallLetterU = 117,
        SmallLetterV = 118,
        SmallLetterW = 119,
        SmallLetterX = 120,
        SmallLetterY = 121,
        SmallLetterZ = 122,
        LeftCurlyBracket = 123,
        VerticalLine = 124,
        RightCurlyBracket = 125,
        Tilde = 126,
        Delete = 127,
        Control128 = 128,
        Control129 = 129,
        BreakPermittedHere = 130,
        NoBreakHere = 131,
        Control132 = 132,
        NextLine = 133,
        StartOfSelectedArea = 134,
        EndOfSelectedArea = 135,
        CharacterTabulationSet = 136,
        CharacterTabulationWithJustification = 137,
        LineTabulationSet = 138,
        PartialLineForward = 139,
        PartialLineBackward = 140,
        ReverseLinefeed = 141,
        SingleShiftTwo = 142,
        SingleShiftThree = 143,
        DeviceControlString = 144,
        PrivateUseOne = 145,
        PrivateUseTwo = 146,
        SetTransmitState = 147,
        CancelCharacter = 148,
        MessageWaiting = 149,
        StartOfGuardedArea = 150,
        EndOfGuardedArea = 151,
        StartOfString = 152,
        Control153 = 153,
        SingleCharacterIntroducer = 154,
        ControlSequenceIntroducer = 155,
        StringTerminator = 156,
        OperatingSystemCommand = 157,
        PrivacyMessage = 158,
        ApplicationProgramCommand = 159,
        NoBreakSpace = 160,
        InvertedExclamationMark = 161,
        CentSign = 162,
        PoundSign = 163,
        CurrencySign = 164,
        YenSign = 165,
        BrokenBar = 166,
        SectionSign = 167,
        Diaeresis = 168,
        CopyrightSign = 169,
        FeminineOrdinalIndicator = 170,
        LeftPointingDoubleAngleQuotationMark = 171,
        NotSign = 172,
        SoftHyphen = 173,
        RegisteredSign = 174,
        Macron = 175,
        DegreeSign = 176,
        PlusMinus = 177,
        SuperscriptTwo = 178,
        SuperscriptThree = 179,
        AcuteAccent = 180,
        MicroSign = 181,
        PilcrowSign = 182,
        MiddleDot = 183,
        Cedilla = 184,
        SuperscriptOne = 185,
        MasculineOrdinalIndicator = 186,
        RightPointingDoubleAngleQuotationMark = 187,
        VulgarFractionOneQuarter = 188,
        VulgarFractionOneHalf = 189,
        VulgarFractionThreeQuarters = 190,
        InvertedQuestionMark = 191,
        CapitalLetterAWithGrave = 192,
        CapitalLetterAWithAcute = 193,
        CapitalLetterAWithCircumflex = 194,
        CapitalLetterAWithTilde = 195,
        CapitalLetterAWithDiaeresis = 196,
        CapitalLetterAWithRingAbove = 197,
        CapitalLetterAE = 198,
        CapitalLetterCWithCedilla = 199,
        CapitalLetterEWithGrave = 200,
        CapitalLetterEWithAcute = 201,
        CapitalLetterEWithCircumflex = 202,
        CapitalLetterEWithDiaeresis = 203,
        CapitalLetterIWithGrave = 204,
        CapitalLetterIWithAcute = 205,
        CapitalLetterIWithCircumflex = 206,
        CapitalLetterIWithDiaeresis = 207,
        CapitalLetterEth = 208,
        CapitalLetterNWithTilde = 209,
        CapitalLetterOWithGrave = 210,
        CapitalLetterOWithAcute = 211,
        CapitalLetterOWithCircumflex = 212,
        CapitalLetterOWithTilde = 213,
        CapitalLetterOWithDiaeresis = 214,
        MultiplicationSign = 215,
        CapitalLetterOWithStroke = 216,
        CapitalLetterUWithGrave = 217,
        CapitalLetterUWithAcute = 218,
        CapitalLetterUWithCircumflex = 219,
        CapitalLetterUWithDiaeresis = 220,
        CapitalLetterYWithAcute = 221,
        CapitalLetterThorn = 222,
        SmallLetterSharpS = 223,
        SmallLetterAWithGrave = 224,
        SmallLetterAWithAcute = 225,
        SmallLetterAWithCircumflex = 226,
        SmallLetterAWithTilde = 227,
        SmallLetterAWithDiaeresis = 228,
        SmallLetterAWithRingAbove = 229,
        SmallLetterAE = 230,
        SmallLetterCWithCedilla = 231,
        SmallLetterEWithGrave = 232,
        SmallLetterEWithAcute = 233,
        SmallLetterEWithCircumflex = 234,
        SmallLetterEWithDiaeresis = 235,
        SmallLetterIWithGrave = 236,
        SmallLetterIWithAcute = 237,
        SmallLetterIWithCircumflex = 238,
        SmallLetterIWithDiaeresis = 239,
        SmallLetterEth = 240,
        SmallLetterNWithTilde = 241,
        SmallLetterOWithGrave = 242,
        SmallLetterOWithAcute = 243,
        SmallLetterOWithCircumflex = 244,
        SmallLetterOWithTilde = 245,
        SmallLetterOWithDiaeresis = 246,
        DivisionSign = 247,
        SmallLetterOWithStroke = 248,
        SmallLetterUWithGrave = 249,
        SmallLetterUWithAcute = 250,
        SmallLetterUWithCircumflex = 251,
        SmallLetterUWithDiaeresis = 252,
        SmallLetterYWithAcute = 253,
        SmallLetterThorn = 254,
        SmallLetterYWithDiaeresis = 255
    }
}
