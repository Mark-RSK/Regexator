// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a base class for a substitution in the replacement pattern. This class is abstract.
    /// </summary>
    public abstract partial class Substitution
    {
        private Substitution _previous;

        /// <summary>
        /// Initializes a new instance of the <see cref="Substitution"/> class.
        /// </summary>
        protected Substitution()
        {
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="Substitution"/> class.
        /// </summary>
        /// <param name="text">The literal text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Substitution Create(string text)
        {
            return new LiteralSubstitution(text);
        }

        internal Substitution Concat(Substitution substitution)
        {
            substitution.Previous = this;
            return substitution;
        }

        /// <summary>
        /// Converts the value of this instance to a <see cref="String"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Previous != null)
            {
                var sb = new StringBuilder();
                var stack = new Stack<Substitution>();

                Substitution item = this;
                do
                {
                    stack.Push(item);
                    item = item.Previous;
                } while (item != null);

                while (stack.Count > 0)
                {
                    sb.Append(stack.Pop().Value);
                }

                return sb.ToString();
            }
            else
            {
                return Value;
            }
        }

        /// <summary>
        /// Appends a substitution pattern that substitutes the last substring matched by the named group.
        /// </summary>
        /// <param name="groupName">Valid regex group name.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Substitution NamedGroup(string groupName)
        {
            return Concat(Substitutions.NamedGroup(groupName));
        }

        /// <summary>
        /// Appends a substitution pattern that substitutes the last captured group.
        /// </summary>
        /// <returns></returns>
        public Substitution LastCapturedGroup()
        {
            return Concat(Substitutions.LastCapturedGroup());
        }

        /// <summary>
        /// Appends a substitution pattern that substitutes the entire input string.
        /// </summary>
        /// <returns></returns>
        public Substitution EntireInput()
        {
            return Concat(Substitutions.EntireInput());
        }

        /// <summary>
        /// Appends a substitution pattern that substitutes the entire match.
        /// </summary>
        /// <returns></returns>
        public Substitution EntireMatch()
        {
            return Concat(Substitutions.EntireMatch());
        }

        /// <summary>
        /// Appends a substitution pattern that substitutes all the text of the input string after the match.
        /// </summary>
        /// <returns></returns>
        public Substitution AfterMatch()
        {
            return Concat(Substitutions.AfterMatch());
        }

        /// <summary>
        /// Appends a substitution pattern that substitutes all the text of the input string before the match.
        /// </summary>
        /// <returns></returns>
        public Substitution BeforeMatch()
        {
            return Concat(Substitutions.BeforeMatch());
        }

        /// <summary>
        /// Appends a specified text to the substitution pattern.
        /// </summary>
        /// <param name="value">A text to append.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Substitution Text(string value)
        {
            return Concat(Create(value));
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