// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Substitutions
    {
        public static Substitution NamedGroup(string groupName)
        {
            return new Substitution.NamedGroupSubstitution(groupName);
        }

        public static Substitution LastCapturedGroup()
        {
            return new Substitution.LastCapturedGroupSubstitution();
        }

        public static Substitution EntireInput()
        {
            return new Substitution.EntireInputSubstitution();
        }

        public static Substitution EntireMatch()
        {
            return new Substitution.EntireMatchSubstitution();
        }

        public static Substitution AfterMatch()
        {
            return new Substitution.AfterMatchSubstitution();
        }

        public static Substitution BeforeMatch()
        {
            return new Substitution.BeforeMatchSubstitution();
        }

    }
}
