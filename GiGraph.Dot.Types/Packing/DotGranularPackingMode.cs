using System;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing
{
    /// <summary>
    ///     A graph packing mode based on a granularity option.
    /// </summary>
    public class DotGranularPackingMode : DotPackingModeDefinition
    {
        /// <summary>
        ///     Creates a new packing granularity instance.
        /// </summary>
        /// <param name="granularity">
        ///     The option to initialize the instance with.
        /// </param>
        public DotGranularPackingMode(DotPackingGranularity granularity)
        {
            Granularity = granularity;
        }

        /// <summary>
        ///     Gets or sets the granularity option.
        /// </summary>
        public virtual DotPackingGranularity Granularity { get; set; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValue.Get(Granularity);
        }
    }
}