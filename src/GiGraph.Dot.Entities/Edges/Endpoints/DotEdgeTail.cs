using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail : DotEdgeEndpoint, IDotEdgeTailRootAttributes
    {
        public DotEdgeTail(DotEdgeTailRootAttributes attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets the tail attributes of the edge.
        /// </summary>
        public virtual DotEdgeTailRootAttributes Attributes => (DotEdgeTailRootAttributes) _attributes;

        /// <inheritdoc cref="IDotEdgeTailRootAttributes.Hyperlink" />
        public virtual DotEdgeTailHyperlinkAttributes Hyperlink => ((IDotEdgeTailRootAttributes) Attributes).Hyperlink;
    }
}