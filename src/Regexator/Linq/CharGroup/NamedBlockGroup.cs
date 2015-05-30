﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class NamedBlockGroup
        : CharGroupExpression
    {
        private readonly NamedBlock _value;

        public NamedBlockGroup(NamedBlock value)
        {
            _value = value;
        }

        public override string Content
        {
            get { return Syntax.NamedBlock(_value); }
        }
    }
}