using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeStyleAttributes : DotEntityStyleAttributes
    {
        public DotEdgeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a line style for the edge (default: <see cref="DotLineStyle.Normal" />).
        /// </summary>
        public virtual DotLineStyle LineStyle
        {
            get => GetPart<DotLineStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a line weight for the edge (default: <see cref="DotLineWeight.Normal" />).
        /// </summary>
        public virtual DotLineWeight LineWeight
        {
            get => GetPart<DotLineWeight>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a value indicating if the edge is invisible.
        /// </summary>
        public virtual bool Invisible
        {
            get => HasOptions(DotStyles.Invisible);
            set => ApplyOption(DotStyles.Invisible, value);
        }

        /// <summary>
        ///     Applies the specified style options to the edge.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Set(DotEdgeStyleOptions options)
        {
            Set(options.LineStyle, options.LineWeight, options.Invisible);
        }

        /// <summary>
        ///     Applies the specified style options to the edge.
        /// </summary>
        /// <param name="lineStyle">
        ///     The line style to set.
        /// </param>
        /// <param name="lineWeight">
        ///     The line weight to set.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the edge should be invisible.
        /// </param>
        public virtual void Set(DotLineStyle lineStyle = default, DotLineWeight lineWeight = default, bool invisible = false)
        {
            LineStyle = lineStyle;
            LineWeight = lineWeight;
            Invisible = invisible;
        }
    }
}