// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Syntax
    {
        public const string Maybe = "?";
        public const string MaybeLazy = "??";
        public const string MaybeMany = "*";
        public const string MaybeManyLazy = "*?";
        public const string OneMany = "+";
        public const string OneManyLazy = "+?";
        public const string Lazy = "?";

        public static string Count(int exactCount)
        {
            return "{" + exactCount + "}";
        }

        public static string AtLeast(int minCount)
        {
            return "{" + minCount + ",}";
        }

        public static string Count(int minCount, int maxCount)
        {
            return "{" + minCount + "," + maxCount + "}";
        }
    }
}
