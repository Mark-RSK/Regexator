// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Text;

//TODO add xml comments

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a base class for a regex substitution.
    /// </summary>
    public abstract partial class Substitution
    {
        private Substitution _previous;

        protected Substitution()
        {
        }

        public static Substitution Create(string text)
        {
            return new LiteralSubstitution(text);
        }

        internal Substitution Concat(Substitution substitution)
        {
            substitution.Previous = this;
            return substitution;
        }

        public override string ToString()
        {
            if (Previous != null)
            {
                var sb = new StringBuilder();
                var items = new Stack<Substitution>(EnumerateSubstitutions());
                while (items.Count > 0)
                {
                    sb.Append(items.Pop().Value);
                }
                return sb.ToString();
            }
            else
            {
                return Value;
            }
        }

        private IEnumerable<Substitution> EnumerateSubstitutions()
        {
            Substitution s = this;
            do
            {
                yield return s;
                s = s.Previous;
            } while (s != null);
        }

        public Substitution NamedGroup(string groupName)
        {
            return Concat(Substitutions.NamedGroup(groupName));
        }

        public Substitution LastCapturedGroup()
        {
            return Concat(Substitutions.LastCapturedGroup());
        }

        public Substitution EntireInput()
        {
            return Concat(Substitutions.EntireInput());
        }

        public Substitution EntireMatch()
        {
            return Concat(Substitutions.EntireMatch());
        }

        public Substitution AfterMatch()
        {
            return Concat(Substitutions.AfterMatch());
        }

        public Substitution BeforeMatch()
        {
            return Concat(Substitutions.BeforeMatch());
        }

        public Substitution Text(string value)
        {
            return Concat(Substitution.Create(value));
        }

        internal virtual string Value
        {
            get { return null; }
        }

        internal Substitution Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }
    }
}