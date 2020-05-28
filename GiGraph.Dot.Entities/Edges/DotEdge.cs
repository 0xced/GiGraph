﻿using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents an edge that joins:
    /// <list type="bullet">
    ///     <item>
    ///         two nodes, when <typeparamref name="TTail"/> and <typeparamref name="THead"/> are both
    ///         <see cref="DotEndpoint"/>,
    ///     </item>
    ///     <item>
    ///         a set of edges that join one <typeparamref name="TTail"/> <see cref="DotEndpoint"/> node
    ///         to multiple <typeparamref name="THead"/> <see cref="DotEndpointGroup"/> nodes,
    ///     </item>
    ///     <item>
    ///         or a set of edges that join multiple <typeparamref name="TTail"/> <see cref="DotEndpointGroup"/> nodes
    ///         to one <typeparamref name="THead"/> <see cref="DotEndpoint"/> node,
    ///     </item>
    ///     <item>
    ///         or a set of edges that join multiple <typeparamref name="TTail"/> <see cref="DotEndpointGroup"/> nodes
    ///         to multiple <typeparamref name="THead"/> <see cref="DotEndpointGroup"/> nodes.
    ///     </item>
    /// </list>
    /// </summary>
    /// <typeparam name="TTail">The type of the tail endpoint.</typeparam>
    /// <typeparam name="THead">The type of the head endpoint.</typeparam>
    public class DotEdge<TTail, THead> : DotCommonEdge
        where TTail : DotCommonEndpoint
        where THead : DotCommonEndpoint
    {
        /// <summary>
        /// The tail (source, left) endpoint.
        /// </summary>
        public virtual TTail Tail { get; set; }

        /// <summary>
        /// The head (destination, right) endpoint.
        /// </summary>
        public virtual THead Head { get; set; }

        /// <summary>
        /// Gets the endpoints of this edge.
        /// </summary>
        public override IEnumerable<DotCommonEndpoint> Endpoints => new DotCommonEndpoint[] { Tail, Head };

        protected DotEdge(TTail tail, THead head, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Tail = tail;
            Head = head;
        }

        /// <summary>
        /// Creates a new edge instance.
        /// </summary>
        /// <param name="tail">The tail (source, left) endpoint.</param>
        /// <param name="head">The head (destination, right) endpoint.</param>
        public DotEdge(TTail tail, THead head)
            : this(tail, head, new DotEntityAttributes())
        {
        }
    }

    /// <summary>
    /// Represents an edge (joins two nodes).
    /// </summary>
    public class DotEdge : DotEdge<DotEndpoint, DotEndpoint>
    {
        /// <summary>
        /// Indicates if the current instance is a loop edge.
        /// </summary>
        public bool IsLoop => Tail.NodeId == Head.NodeId;

        protected DotEdge(DotEndpoint tail, DotEndpoint head, IDotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        /// Creates a new edge instance.
        /// </summary>
        /// <param name="tail">The tail (source, left) node.</param>
        /// <param name="head">The head (destination, right) node.</param>
        public DotEdge(DotEndpoint tail, DotEndpoint head)
            : base(tail, head)
        {
        }

        /// <summary>
        /// Creates a new edge instance.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        public DotEdge(string tailNodeId, string headNodeId)
            : this(new DotEndpoint(tailNodeId), new DotEndpoint(headNodeId))
        {
        }

        /// <summary>
        /// Determines whether the edge joins the specified nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node to check.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node to check.</param>
        public bool Equals(string tailNodeId, string headNodeId)
        {
            return Tail.NodeId == tailNodeId &&
                   Head.NodeId == headNodeId;
        }

        /// <summary>
        /// Determines whether the current edge connects the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The identifier of the node to check.</param>
        public bool Loops(string nodeId)
        {
            return Equals(nodeId, nodeId);
        }

        /// <summary>
        /// Creates a new loop edge instance.
        /// </summary>
        /// <param name="nodeId">The identifier of the node the edge should connect to itself.</param>
        public static DotEdge Loop(string nodeId)
        {
            return new DotEdge(nodeId, nodeId);
        }
    }
}
