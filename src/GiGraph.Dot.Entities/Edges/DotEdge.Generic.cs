﻿using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 an edge that joins two nodes, when <typeparamref name="TTail" /> and <typeparamref name="THead" /> are both of
    ///                 <see cref="DotEndpoint" /> type,
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 a group of edges that join one <typeparamref name="TTail" /> <see cref="DotEndpoint" /> node to multiple
    ///                 <typeparamref name="THead" /> <see cref="DotSubgraphEndpoint" /> or <see cref="DotEndpointGroup" /> nodes,
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 a group of edges that join multiple <typeparamref name="TTail" /> <see cref="DotSubgraphEndpoint" /> or
    ///                 <see cref="DotEndpointGroup" /> nodes to one <typeparamref name="THead" /> <see cref="DotEndpoint" /> node,
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 a group of edges that join multiple <typeparamref name="TTail" /> <see cref="DotSubgraphEndpoint" /> or
    ///                 <see cref="DotEndpointGroup" /> nodes to multiple <typeparamref name="THead" />
    ///                 <see cref="DotSubgraphEndpoint" /> or <see cref="DotEndpointGroup" /> nodes.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </summary>
    /// <typeparam name="TTail">
    ///     The type of the tail endpoint.
    /// </typeparam>
    /// <typeparam name="THead">
    ///     The type of the head endpoint.
    /// </typeparam>
    public class DotEdge<TTail, THead> : DotEdgeDefinition
        where TTail : DotEndpointDefinition, IDotOrderable
        where THead : DotEndpointDefinition, IDotOrderable
    {
        /// <summary>
        ///     Creates a new edge instance.
        /// </summary>
        /// <param name="tail">
        ///     The tail endpoint.
        /// </param>
        /// <param name="head">
        ///     The head endpoint.
        /// </param>
        public DotEdge(TTail tail, THead head)
            : this(tail, head, new DotAttributeCollection())
        {
        }

        private DotEdge(TTail tail, THead head, DotAttributeCollection attributes)
            : this(
                new DotEdgeTail<TTail>(tail, new DotEdgeTailRootAttributes(attributes)),
                new DotEdgeHead<THead>(head, new DotEdgeHeadRootAttributes(attributes)),
                new DotEdgeRootAttributes(attributes)
            )
        {
        }

        private DotEdge(DotEdgeTail<TTail> tail, DotEdgeHead<THead> head, DotEdgeRootAttributes attributes)
            : base(new DotEndpointDefinition[] { tail.Endpoint, head.Endpoint }, attributes)
        {
            Tail = tail;
            Head = head;
        }

        /// <summary>
        ///     Gets the tail endpoint.
        /// </summary>
        public virtual DotEdgeTail<TTail> Tail { get; }

        /// <summary>
        ///     Gets the head endpoint.
        /// </summary>
        public virtual DotEdgeHead<THead> Head { get; }

        protected override string GetOrderingKey()
        {
            return $"{Tail.Endpoint.OrderingKey} {Head.Endpoint.OrderingKey}";
        }
    }
}