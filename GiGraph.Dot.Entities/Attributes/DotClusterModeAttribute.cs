﻿using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Specifies the mode used for handling clusters.
    /// </summary>
    public class DotClusterModeAttribute : DotAttribute<DotClusterMode>
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
        public DotClusterModeAttribute(string key, DotClusterMode value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value switch
            {
                DotClusterMode.None => "none",
                DotClusterMode.Global => "global",
                DotClusterMode.Local => "local",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"The specified cluster mode '{Value}' is invalid.")
            };
        }
    }
}