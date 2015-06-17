// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    [Flags]
    public enum PatternOptions
    {
        None = 0,
        ConditionWithAssertion = 1,
        SeparateNumberedGroupReference = 2
    }
}