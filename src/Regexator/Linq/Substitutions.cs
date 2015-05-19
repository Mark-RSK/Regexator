// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
{
    public static class Substitutions
    {
        public static Substitution NamedGroup(string groupName)
        {
            return new NamedGroupSubstitution(groupName);
        }

        public static Substitution LastCapturedGroup()
        {
            return new LastCapturedGroupSubstitution();
        }

        public static Substitution EntireInput()
        {
            return new EntireInputSubstitution();
        }

        public static Substitution EntireMatch()
        {
            return new EntireMatchSubstitution();
        }

        public static Substitution AfterMatch()
        {
            return new AfterMatchSubstitution();
        }

        public static Substitution BeforeMatch()
        {
            return new BeforeMatchSubstitution();
        }

        public static Substitution Text(string value)
        {
            return new TextSubstitution(value);
        }
    }
}
