using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEdgeAttributes : DotEntityAttributes, IDotEdgeAttributes
    {
        public virtual double? ArrowSize
        {
            get => TryGetValueAs<double>("arrowsize", out var result) ? result : (double?) null;
            set => AddOrRemove("arrowsize", value, v => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(ArrowSize), v.Value, "Arrow size must be greater than or equal to 0.")
                : new DotDoubleAttribute("arrowsize", v.Value));
        }

        public virtual DotArrowType? ArrowHead
        {
            get => TryGetValueAs<DotArrowType>("arrowhead", out var result) ? result : (DotArrowType?) null;
            set => AddOrRemove("arrowhead", value, v => new DotArrowTypeAttribute("arrowhead", v.Value));
        }

        public virtual DotArrowType? ArrowTail
        {
            get => TryGetValueAs<DotArrowType>("arrowtail", out var result) ? result : (DotArrowType?) null;
            set => AddOrRemove("arrowtail", value, v => new DotArrowTypeAttribute("arrowtail", v.Value));
        }

        public virtual DotArrowDirection? ArrowDirection
        {
            get => TryGetValueAs<DotArrowDirection>("dir", out var result) ? result : (DotArrowDirection?) null;
            set => AddOrRemove("dir", value, v => new DotArrowDirectionAttribute("dir", v.Value));
        }

        public virtual DotEndpointPort HeadPort
        {
            get => TryGetValueAs<DotEndpointPort>("headport", out var result) ? result : null;
            set => AddOrRemove("headport", value, v => new DotEndpointPortAttribute("headport", v));
        }

        public virtual DotEndpointPort TailPort
        {
            get => TryGetValueAs<DotEndpointPort>("tailport", out var result) ? result : null;
            set => AddOrRemove("tailport", value, v => new DotEndpointPortAttribute("tailport", v));
        }

        public virtual string LogicalHeadId
        {
            get => TryGetValueAs<string>("lhead", out var result) ? result : null;
            set => AddOrRemove("lhead", value, v => new DotLogicalEndpointAttribute("lhead", v));
        }

        public virtual string LogicalTailId
        {
            get => TryGetValueAs<string>("ltail", out var result) ? result : null;
            set => AddOrRemove("ltail", value, v => new DotLogicalEndpointAttribute("ltail", v));
        }

        public virtual bool? Decorate
        {
            get => TryGetValueAs<bool>("decorate", out var result) ? result : (bool?) null;
            set => AddOrRemove("decorate", value, v => new DotBoolAttribute("decorate", v.Value));
        }

        public virtual bool? Constraint
        {
            get => TryGetValueAs<bool>("constraint", out var result) ? result : (bool?) null;
            set => AddOrRemove("constraint", value, v => new DotBoolAttribute("constraint", v.Value));
        }

        public virtual string HeadUrl
        {
            get => TryGetValueAsEscapableString("headURL");
            set => AddOrRemove("headURL", value, v => new DotEscapeStringAttribute("headURL", v));
        }

        public virtual string HeadHref
        {
            get => TryGetValueAsEscapableString("headhref");
            set => AddOrRemove("headhref", value, v => new DotEscapeStringAttribute("headhref", v));
        }

        public virtual string TailUrl
        {
            get => TryGetValueAsEscapableString("tailURL");
            set => AddOrRemove("tailURL", value, v => new DotEscapeStringAttribute("tailURL", v));
        }

        public virtual string TailHref
        {
            get => TryGetValueAsEscapableString("tailhref");
            set => AddOrRemove("tailhref", value, v => new DotEscapeStringAttribute("tailhref", v));
        }

        public virtual string LabelUrl
        {
            get => TryGetValueAsEscapableString("labelURL");
            set => AddOrRemove("labelURL", value, v => new DotEscapeStringAttribute("labelURL", v));
        }

        public virtual string LabelHref
        {
            get => TryGetValueAsEscapableString("labelhref");
            set => AddOrRemove("labelhref", value, v => new DotEscapeStringAttribute("labelhref", v));
        }

        public virtual string EdgeUrl
        {
            get => TryGetValueAsEscapableString("edgeURL");
            set => AddOrRemove("edgeURL", value, v => new DotEscapeStringAttribute("edgeURL", v));
        }

        public virtual string EdgeHref
        {
            get => TryGetValueAsEscapableString("edgehref");
            set => AddOrRemove("edgehref", value, v => new DotEscapeStringAttribute("edgehref", v));
        }

        public override void SetFilled(DotColorDefinition value) => FillColor = value;
    }
}