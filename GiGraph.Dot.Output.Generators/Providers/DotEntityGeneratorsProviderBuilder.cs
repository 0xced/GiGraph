﻿using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Generators.Attributes;
using GiGraph.Dot.Output.Generators.Attributes.Edge;
using GiGraph.Dot.Output.Generators.Attributes.Graph;
using GiGraph.Dot.Output.Generators.Attributes.Node;
using GiGraph.Dot.Output.Generators.Clusters;
using GiGraph.Dot.Output.Generators.Edges;
using GiGraph.Dot.Output.Generators.Graphs;
using GiGraph.Dot.Output.Generators.Nodes;
using GiGraph.Dot.Output.Generators.Subgraphs;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Providers
{
    public class DotEntityGeneratorsProviderBuilder : IDotEntityGeneratorsProviderBuilder
    {
        /// <summary>
        ///     Builds a provider with all generators necessary to generate a graph.
        /// </summary>
        /// <param name="syntaxRules">
        ///     The syntax rules to follow.
        /// </param>
        /// <param name="options">
        ///     The DOT language generation options to use for graph generation and its components.
        /// </param>
        public virtual IDotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotGenerationOptions options)
        {
            var provider = new DotEntityGeneratorsProvider();

            provider.Register(new DotGraphGenerator(syntaxRules, options, provider));
            provider.Register(new DotGraphBodyGenerator(syntaxRules, options, provider));

            provider.Register(new DotGlobalGraphAttributeCollectionGenerator(syntaxRules, options, provider));
            provider.Register(new DotGlobalGraphAttributesGenerator(syntaxRules, options, provider));
            provider.Register(new DotGlobalNodeAttributesGenerator(syntaxRules, options, provider));
            provider.Register(new DotGlobalEdgeAttributesGenerator(syntaxRules, options, provider));

            provider.Register(new DotClusterGenerator(syntaxRules, options, provider));
            provider.Register(new DotSubgraphGenerator<DotSubgraph>(syntaxRules, options, provider));
            provider.Register(new DotSubgraphCollectionGenerator<DotSubgraph>(syntaxRules, options, provider));
            provider.Register(new DotSubgraphCollectionGenerator<DotCluster>(syntaxRules, options, provider));

            provider.Register(new DotAttributeGenerator(syntaxRules, options, provider));
            provider.Register(new DotLabelAttributeGenerator(syntaxRules, options, provider));
            provider.Register(new DotAttributeListGenerator(syntaxRules, options, provider));

            provider.Register(new DotNodeGenerator(syntaxRules, options, provider));
            provider.Register(new DotNodeGroupGenerator(syntaxRules, options, provider));
            provider.Register(new DotNodeCollectionGenerator(syntaxRules, options, provider));

            provider.Register(new DotEdgeGenerator(syntaxRules, options, provider));
            provider.Register(new DotEdgeCollectionGenerator(syntaxRules, options, provider));
            provider.Register(new DotEndpointGenerator(syntaxRules, options, provider));

            return provider;
        }
    }
}