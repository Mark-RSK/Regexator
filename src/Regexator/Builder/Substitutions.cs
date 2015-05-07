// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static class Substitutions
    {
        /// <summary>
        /// Substitutes the last substring matched by the named group.
        /// </summary>
        /// <param name="name">Group name</param>
        /// <returns>Substitution expression</returns>
        public static string NamedGroup(string name)
        {
            if (name == null) { throw new ArgumentNullException("name"); }
            return "${" + name + "}";
        }

        /// <summary>
        /// Substitutes the last substring matched by the numbered group
        /// </summary>
        /// <returns></returns>
        public static string LastCapturedGroup
        {
            get { return "$+"; }
        }

        /// <summary>
        /// Substitutes the entire input string.
        /// </summary>
        public static string EntireInput
        {
            get { return "$_"; }
        }

        /// <summary>
        /// Substitutes the entire match.
        /// </summary>
        public static string EntireMatch
        {
            get { return "$&"; }
        }

        /// <summary>
        /// Substitutes a literal "$".
        /// </summary>
        public static string Dollar
        {
            get { return "$$"; }
        }

        /// <summary>
        /// Substitutes all the text of the input string after the match.
        /// </summary>
        public static string AfterMatch
        {
            get { return "$'"; }
        }

        /// <summary>
        /// Substitutes all the text of the input string before the match.
        /// </summary>
        public static string BeforeMatch
        {
            get { return "$`"; }
        }
    }
}
