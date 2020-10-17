using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeImageAttributes : DotEntityAttributes<IDotNodeImageAttributes>, IDotNodeImageAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup NodeImageAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotNodeImageAttributes));

        protected DotNodeImageAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotNodeImageAttributes(DotAttributeCollection attributes)
            : base(attributes, NodeImageAttributesKeyLookup)
        {
        }

        [DotAttributeKey("image")]
        public virtual string Path
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("imagepos")]
        public virtual DotAlignment? Alignment
        {
            get => GetValueAs<DotAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey("imagescale")]
        public virtual DotImageScaling? Scaling
        {
            get => GetValueAs<DotImageScaling>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotImageScaling?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotImageScalingAttribute(k, v.Value));
        }
    }
}