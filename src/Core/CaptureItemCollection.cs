// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator
{
    public class CaptureItemCollection
        : ReadOnlyCollection<CaptureItem>
    {
        internal CaptureItemCollection(IList<CaptureItem> list)
            : base(list)
        {
        }
    }
}
