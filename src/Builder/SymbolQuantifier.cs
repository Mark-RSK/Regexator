// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class SymbolQuantifier
        : Quantifier
    {
        private readonly QuantifierKind _kind;

        internal SymbolQuantifier(QuantifierKind kind)
            : base()
        {
            _kind = kind;
        }

        protected override string QuantifierValue
        {
            get
            {
                switch (QuantifierKind)
                {
                    case QuantifierKind.Maybe:
                        return Syntax.Maybe;
                    case QuantifierKind.MaybeMany:
                        return Syntax.MaybeMany;
                    case QuantifierKind.OneMany:
                        return Syntax.OneMany;
                    default:
                        return string.Empty;
                }
            }
        }

        public override QuantifierKind QuantifierKind
        {
            get { return _kind; }
        }
    }
}
