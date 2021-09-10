using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead : DotEdgeEndpoint, IDotEdgeHeadRootAttributes
    {
        public DotEdgeHead(DotEdgeHeadRootAttributes attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets the head attributes of the edge.
        /// </summary>
        public virtual DotEdgeHeadRootAttributes Attributes => (DotEdgeHeadRootAttributes) _attributes;

        /// <inheritdoc cref="IDotEdgeHeadRootAttributes.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((IDotEdgeHeadRootAttributes) Attributes).Hyperlink;
    }
}