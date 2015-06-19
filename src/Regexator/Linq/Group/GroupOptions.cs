// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class GroupOptions
        : GroupingPattern
    {
        private readonly InlineOptions _applyOptions;
        private readonly InlineOptions _disableOptions;

        public GroupOptions(InlineOptions applyOptions, object content)
            : this(applyOptions, InlineOptions.None, content)
        {
        }

        public GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, object content)
            : base(content)
        {
            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        public static QuantifiablePattern Apply(InlineOptions options, object content)
        {
            return new GroupOptions(options, InlineOptions.None, content);
        }

        public static QuantifiablePattern Apply(InlineOptions options, params object[] content)
        {
            return new GroupOptions(options, InlineOptions.None, content);
        }

        public static QuantifiablePattern Disable(InlineOptions options, object content)
        {
            return new GroupOptions(InlineOptions.None, options, content);
        }

        public static QuantifiablePattern Disable(InlineOptions options, params object[] content)
        {
            return new GroupOptions(InlineOptions.None, options, (object)content);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteGroupOptions(_applyOptions, _disableOptions, Content);
        }
    }
}
