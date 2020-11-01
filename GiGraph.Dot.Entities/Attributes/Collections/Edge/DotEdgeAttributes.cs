using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeAttributes : DotEntityCommonAttributes<IDotEdgeAttributes>, IDotEdgeAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeAttributes, IDotEdgeAttributes>().Build();

        protected DotEdgeAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeHeadAttributes headAttributes,
            DotEdgeTailAttributes tailAttributes,
            DotEntityFontAttributes fontAttributes,
            DotEntityHyperlinkAttributes hyperlinkAttributes,
            DotEdgeEndpointLabelAttributes endpointLabelAttributes,
            DotEdgeLabelHyperlinkAttributes labelHyperlinkAttributes,
            DotEdgeHyperlinkAttributes edgeHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Head = headAttributes;
            Tail = tailAttributes;
            Font = fontAttributes;
            EndpointLabels = endpointLabelAttributes;
            EdgeHyperlink = edgeHyperlinkAttributes;
            LabelHyperlink = labelHyperlinkAttributes;
        }

        public DotEdgeAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                EdgeAttributesKeyLookup,
                new DotEdgeHeadAttributes(attributes),
                new DotEdgeTailAttributes(attributes),
                new DotEntityFontAttributes(attributes),
                new DotEntityHyperlinkAttributes(attributes),
                new DotEdgeEndpointLabelAttributes(attributes),
                new DotEdgeLabelHyperlinkAttributes(attributes),
                new DotEdgeHyperlinkAttributes(attributes)
            )
        {
        }

        public DotEdgeAttributes()
            : this(new DotAttributeCollection())
        {
        }

        /// <summary>
        ///     Attributes applied to the head of the edge.
        /// </summary>
        public virtual DotEdgeHeadAttributes Head { get; }

        /// <summary>
        ///     Attributes applied to the tail of the edge.
        /// </summary>
        public virtual DotEdgeTailAttributes Tail { get; }

        /// <summary>
        ///     Font attributes.
        /// </summary>
        public virtual DotEntityFontAttributes Font { get; }

        /// <summary>
        ///     Attributes applied to labels specified for the <see cref="Head" /> and the <see cref="Tail" /> of the edge.
        /// </summary>
        public virtual DotEdgeEndpointLabelAttributes EndpointLabels { get; }

        /// <summary>
        ///     Hyperlink attributes applied to the non-label parts of the edge.
        /// </summary>
        public virtual DotEdgeHyperlinkAttributes EdgeHyperlink { get; }

        /// <summary>
        ///     Hyperlink attributes applied to the label of the edge.
        /// </summary>
        public virtual DotEdgeLabelHyperlinkAttributes LabelHyperlink { get; }

        // overridden to inherit comment from interface
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        // overridden to inherit comment from interface
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        // overridden to inherit comment from interface
        public override DotStyles? Style
        {
            get => base.Style;
            set => base.Style = value;
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.XLabel)]
        public virtual DotLabel ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? Width
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Width), v.Value, "Width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Weight)]
        public virtual double? Weight
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Weight), v.Value, "Weight must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Len)]
        public virtual double? Length
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.MinLen)]
        public virtual int? MinLength
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(MinLength), v.Value, "Minimum length must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.ArrowSize)]
        public virtual double? ArrowheadScale
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(ArrowheadScale), v.Value, "Arrowhead scale must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Dir)]
        public virtual DotEdgeDirections? Directions
        {
            get => GetValueAs<DotEdgeDirections>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeDirections?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeDirectionsAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Decorate)]
        public virtual bool? AttachLabel
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.LabelFloat)]
        public virtual bool? AllowLabelFloat
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Constraint)]
        public virtual bool? Constrain
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <summary>
        ///     Applies the specified style options to the <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" />
        ///     attribute.
        /// </summary>
        public virtual void SetStyle(DotEdgeStyleOptions options)
        {
            base.SetStyle(options);
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Invisible" /> style option to the
        ///     <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" /> attribute, making the edge invisible.
        /// </summary>
        public virtual void SetInvisible()
        {
            ApplyStyleOption(DotStyles.Invisible);
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Tapered" /> style to the edge. The edge starts with the specified width, and tapers to width
        ///     1, in points.
        /// </summary>
        /// <param name="startWidth">
        ///     The width to start with (applied to the <see cref="Width" /> attribute).
        /// </param>
        public virtual void Taper(double startWidth)
        {
            Width = startWidth;
            ApplyStyleOption(DotStyles.Tapered);
        }

        // TODO: taper też przenieść do extensions
    }
}