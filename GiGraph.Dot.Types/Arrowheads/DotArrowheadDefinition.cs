using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Arrowheads
{
    /// <summary>
    ///     Represents an arrowhead as either a single shape (<see cref="DotArrowhead" />) or as a composition of multiple shapes (
    ///     <see cref="DotCompositeArrowhead" />).
    /// </summary>
    public abstract class DotArrowheadDefinition : IDotComplexType
    {
        string IDotComplexType.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        protected internal abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotArrowheadDefinition(DotArrowheadShape? shape)
        {
            return (DotArrowhead) shape;
        }

        public static implicit operator DotArrowheadDefinition(DotArrowheadShape[] shapes)
        {
            return shapes is not null ? new DotCompositeArrowhead(shapes) : null;
        }

        public static implicit operator DotArrowheadDefinition(DotArrowhead[] arrows)
        {
            return arrows is not null ? new DotCompositeArrowhead(arrows) : null;
        }
    }
}