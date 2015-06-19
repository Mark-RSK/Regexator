// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Groups
    {
        public static QuantifiablePattern NamedGroup(string name, object content)
        {
            return new NamedGroup(name, content);
        }

        public static QuantifiablePattern NamedGroup(string name, params object[] content)
        {
            return NamedGroup(name, (object)content);
        }

        public static QuantifiablePattern Group()
        {
            return new CapturingGroup(string.Empty);
        }

        public static QuantifiablePattern Group(object content)
        {
            return new CapturingGroup(content);
        }

        public static QuantifiablePattern Group(params object[] content)
        {
            return Group((object)content);
        }

        public static QuantifiablePattern Noncapturing(object content)
        {
            return new NoncapturingGroup(content);
        }

        public static QuantifiablePattern Noncapturing(params object[] content)
        {
            return Noncapturing((object)content);
        }

        public static QuantifiablePattern BalanceGroup(string name1, string name2, object content)
        {
            return new BalanceGroup(name1, name2, content);
        }

        public static QuantifiablePattern BalanceGroup(string name1, string name2, params object[] content)
        {
            return BalanceGroup(name1, name2, (object)content);
        }

        public static QuantifiablePattern Nonbacktracking(object content)
        {
            return new NonbacktrackingGroup(content);
        }

        public static QuantifiablePattern Nonbacktracking(params object[] content)
        {
            return Nonbacktracking((object)content);
        }

        public static Quantifier Maybe(object content)
        {
            return new Maybe(content);
        }

        public static Quantifier Maybe(params object[] content)
        {
            return new Maybe((object)content);
        }

        public static Quantifier MaybeMany(object content)
        {
            return new MaybeMany(content);
        }

        public static Quantifier MaybeMany(params object[] content)
        {
            return new MaybeMany((object)content);
        }

        public static Quantifier OneMany(object content)
        {
            return new OneMany(content);
        }

        public static Quantifier OneMany(params object[] content)
        {
            return new OneMany((object)content);
        }

        public static Quantifier Count(int exactCount, object content)
        {
            return new Count(exactCount, content);
        }

        public static Quantifier Count(int exactCount, params object[] content)
        {
            return new Count(exactCount, (object)content);
        }

        public static Quantifier CountFrom(int minCount, object content)
        {
            return new CountFrom(minCount, content);
        }

        public static Quantifier CountFrom(int minCount, params object[] content)
        {
            return new CountFrom(minCount, (object)content);
        }

        public static Quantifier CountRange(int minCount, int maxCount, object content)
        {
            return new CountRange(minCount, maxCount, content);
        }

        public static Quantifier CountRange(int minCount, int maxCount, params object[] content)
        {
            return new CountRange(minCount, maxCount, (object)content);
        }

        public static Quantifier CountTo(int maxCount, object content)
        {
            return new CountTo(maxCount, content);
        }

        public static Quantifier CountTo(int maxCount, params object[] content)
        {
            return new CountTo(maxCount, (object)content);
        }

        public static QuantifiablePattern GroupReference(int groupNumber)
        {
            return new NumberedGroupReference(groupNumber);
        }

        public static QuantifiablePattern GroupReference(string groupName)
        {
            return new NamedGroupReference(groupName);
        }
    }
}
