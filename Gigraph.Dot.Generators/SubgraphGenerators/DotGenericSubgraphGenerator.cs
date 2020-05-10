﻿using Gigraph.Dot.Core;
using Gigraph.Dot.Core.TextEscaping;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.GraphWriters;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public abstract class DotGenericSubgraphGenerator<TSubgraph> : DotEntityGenerator<TSubgraph, IDotSubgraphWriter>
        where TSubgraph : DotGraphBody
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();

        public DotGenericSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual string EscapeSubgraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        protected virtual void WriteDeclaration(string id, bool isCluster, IDotSubgraphWriter writer)
        {
            id = FormatIdentifier(id, isCluster);
            writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
        }

        protected virtual string FormatIdentifier(string id, bool isCluster)
        {
            var cluster = "cluster";

            if (id is { })
            {
                id = EscapeSubgraphIdentifier(id);
            }

            if (isCluster && !string.IsNullOrEmpty(id))
            {
                return $"{cluster} {id}";
            }

            if (isCluster)
            {
                return cluster;
            }

            return id;
        }

        protected virtual void WriteBody(DotGraphBody subgraphBody, IDotSubgraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(subgraphBody).Generate(subgraphBody, bodyWriter);
            writer.EndBody();
        }
    }
}
