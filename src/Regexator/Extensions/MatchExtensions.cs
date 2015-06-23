// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Extensions
{
    public static class MatchExtensions
    {
        public static Group Group(this Match match, string groupName)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match");
            }

            return match.Groups[groupName];
        }
    }
}
