﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal enum SyntaxKind
    {
        IfAssert,
        IfGroup,
        Or,
        BeginningOfInput,
        BeginningOfInputOrLine,
        EndOfInput,
        EndOfInputOrLine,
        EndOfInputOrBeforeEndingLinefeed,
        WordBoundary,
        NegativeWordBoundary,
        PreviousMatchEnd,
        Assertion,
        NegativeAssertion,
        BackAssertion,
        NegativeBackAssertion,
        Group,
        NamedGroup,
        NoncapturingGroup,
        NonbacktrackingGroup,
        BalancingGroup,
        GroupOptions,
        GroupEnd,
        Digit,
        NotDigit,
        WhiteSpace,
        NotWhiteSpace,
        WordChar,
        NotWordChar,
        CharGroup,
        NegativeCharGroup,
        GeneralCategory,
        NotGeneralCategory,
        NamedBlock,
        NotNamedBlock,
        Options,
        GroupReference,
        Text,
        Character,
    }
}