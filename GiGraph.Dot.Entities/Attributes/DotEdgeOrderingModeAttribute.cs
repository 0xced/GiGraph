﻿using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Specifies the mode used for ordering edges.
    /// </summary>
    public class DotEdgeOrderingModeAttribute : DotAttribute<DotEdgeOrderingMode>
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotEdgeOrderingModeAttribute(string key, DotEdgeOrderingMode value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotEdgeOrderingMode.None:
                    return string.Empty;

                case DotEdgeOrderingMode.Outedge:
                    return "out";

                case DotEdgeOrderingMode.Inedge:
                    return "in";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified edge ordering mode '{Value}' is not supported.");
            }
        }
    }
}