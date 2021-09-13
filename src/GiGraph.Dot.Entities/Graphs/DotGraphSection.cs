﻿using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Graphs
{
    public partial class DotGraphSection : DotCommonGraphSection
    {
        public DotGraphSection()
            : this(new DotAttributeCollection())
        {
        }

        protected DotGraphSection(DotGraphSection source)
            : base(source)
        {
            Attributes = source.Attributes;
        }

        private DotGraphSection(DotAttributeCollection attributes)
            : this(new DotGraphRootAttributes(attributes), new DotGraphClustersRootAttributes(attributes))
        {
        }

        private DotGraphSection(DotGraphRootAttributes graphAttributes, DotGraphClustersRootAttributes graphClustersAttributes)
            : base(graphAttributes, new DotGraphClusterCollection(graphAttributes, graphClustersAttributes))
        {
            Attributes = new DotEntityRootAttributes<IDotGraphRootAttributes, DotGraphRootAttributes>(graphAttributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the graph.
        /// </summary>
        public virtual DotEntityRootAttributes<IDotGraphRootAttributes, DotGraphRootAttributes> Attributes { get; }

        /// <inheritdoc cref="DotCommonGraphSection.Clusters" />
        public new virtual DotGraphClusterCollection Clusters => (DotGraphClusterCollection) base.Clusters;
    }
}