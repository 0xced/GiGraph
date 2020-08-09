﻿using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Attributes.Edge;
using GiGraph.Dot.Output.Writers.Attributes.Graph;
using GiGraph.Dot.Output.Writers.Attributes.Node;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Graphs;
using GiGraph.Dot.Output.Writers.Nodes;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Graphs
{
    public class DotGraphSectionGenerator<TGraphAttributes> : DotEntityGenerator<DotGraphSection<TGraphAttributes>, IDotGraphBodyWriter>
        where TGraphAttributes : IDotAttributeCollection
    {
        public DotGraphSectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotGraphSection<TGraphAttributes> graphSection, IDotGraphBodyWriter writer)
        {
            // node and edge defaults have to appear first, so that they are applied to all elements that come later in the output script
            WriteGlobalAttributes(graphSection.Attributes, graphSection.NodeDefaults, graphSection.EdgeDefaults, writer);

            // subgraphs and clusters may also specify node defaults, and these are applied only
            // if the nodes they contain do not appear earlier in the parent graph or subgraph
            WriteSubgraphs(graphSection.Subgraphs, writer);
            WriteClusters(graphSection.Clusters, writer);

            // as already mentioned, nodes should not appear before subgraphs and clusters
            WriteNodes(graphSection.Nodes, writer);

            WriteEdges(graphSection.Edges, writer);
        }

        protected virtual void WriteGlobalAttributes(TGraphAttributes graphAttributes, IDotNodeAttributeCollection nodeAttributes, IDotEdgeAttributeCollection edgeAttributes, IDotGraphBodyWriter writer)
        {
            var writeGraphAttributes = graphAttributes.Any();

            // write graph attributes as a list of individual statements
            if (_options.Attributes.PreferGraphAttributesAsStatements)
            {
                WriteGlobalGraphAttributesAsStatementList(graphAttributes, writer);
                writeGraphAttributes = false;
            }

            if (!nodeAttributes.Any() && !edgeAttributes.Any() && !writeGraphAttributes)
            {
                return;
            }

            var globalAttributesWriter = writer.BeginGlobalEntityAttributesSection(_options.PreferStatementDelimiter);

            if (writeGraphAttributes)
            {
                // write graph attributes as a "graph [attr_list]" clause
                WriteGlobalGraphAttributesAsClause(graphAttributes, globalAttributesWriter);
            }

            WriteGlobalNodeAttributes(nodeAttributes, globalAttributesWriter);
            WriteGlobalEdgeAttributes(edgeAttributes, globalAttributesWriter);

            writer.EndGlobalEntityAttributesSection();
        }

        protected virtual void WriteGlobalGraphAttributesAsStatementList(TGraphAttributes attributes, IDotGraphBodyWriter writer)
        {
            if (attributes.Any())
            {
                var attributesStatementWriter = writer.BeginGlobalGraphAttributesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotGlobalGraphAttributeStatementWriter>(attributes).Generate(attributes, attributesStatementWriter);
                writer.EndGlobalGraphAttributesSection();
            }
        }

        protected virtual void WriteGlobalGraphAttributesAsClause(TGraphAttributes attributes, IDotGlobalEntityAttributesStatementWriter writer)
        {
            if (attributes.Any())
            {
                var graphAttributesWriter = writer.BeginGraphAttributesStatement();
                _entityGenerators.GetForEntity<IDotGlobalGraphAttributesWriter>(attributes).Generate(attributes, graphAttributesWriter);
                writer.EndGraphAttributesStatement();
            }
        }

        protected virtual void WriteGlobalNodeAttributes(IDotNodeAttributeCollection attributes, IDotGlobalEntityAttributesStatementWriter writer)
        {
            if (attributes.Any())
            {
                var nodeAttributesWriter = writer.BeginNodeAttributesStatement();
                _entityGenerators.GetForEntity<IDotGlobalNodeAttributesWriter>(attributes).Generate(attributes, nodeAttributesWriter);
                writer.EndNodeAttributesStatement();
            }
        }

        protected virtual void WriteGlobalEdgeAttributes(IDotEdgeAttributeCollection attributes, IDotGlobalEntityAttributesStatementWriter writer)
        {
            if (attributes.Any())
            {
                var edgeAttributesWriter = writer.BeginEdgeAttributesStatement();
                _entityGenerators.GetForEntity<IDotGlobalEdgeAttributesWriter>(attributes).Generate(attributes, edgeAttributesWriter);
                writer.EndEdgeAttributesStatement();
            }
        }

        protected virtual void WriteNodes(DotNodeCollection nodes, IDotGraphBodyWriter writer)
        {
            if (nodes.Any())
            {
                var nodeStatementWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotNodeStatementWriter>(nodes).Generate(nodes, nodeStatementWriter);
                writer.EndNodesSection();
            }
        }

        protected virtual void WriteEdges(DotEdgeCollection edges, IDotGraphBodyWriter writer)
        {
            if (edges.Any())
            {
                var edgeStatementWriter = writer.BeginEdgesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotEdgeStatementWriter>(edges).Generate(edges, edgeStatementWriter);
                writer.EndEdgesSection();
            }
        }

        protected virtual void WriteSubgraphs(DotSubgraphCollection subgraphs, IDotGraphBodyWriter writer)
        {
            WriteCommonSubgraphs(subgraphs, writer);
        }

        protected virtual void WriteClusters(DotClusterCollection clusters, IDotGraphBodyWriter writer)
        {
            WriteCommonSubgraphs(clusters, writer);
        }

        protected virtual void WriteCommonSubgraphs<TSubgraph, TSubgraphAttributes>(DotGraphCollection<TSubgraph, TSubgraphAttributes> subgraphs, IDotGraphBodyWriter writer)
            where TSubgraph : DotCommonGraph<TSubgraphAttributes>
            where TSubgraphAttributes : IDotAttributeCollection
        {
            if (subgraphs.Any())
            {
                var subgraphWriterRoot = writer.BeginSubgraphsSection();
                _entityGenerators.GetForEntity<IDotSubgraphWriterRoot>(subgraphs).Generate(subgraphs, subgraphWriterRoot);
                writer.EndSubgraphsSection();
            }
        }
    }
}