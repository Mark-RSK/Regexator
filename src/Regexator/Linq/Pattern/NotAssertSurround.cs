// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class NotAssertSurround
        : AssertSurround
    {
        public NotAssertSurround(object contentBefore, object content, object contentAfter)
            : base(contentBefore, content, contentAfter)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
