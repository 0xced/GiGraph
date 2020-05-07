﻿using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;
using Dotless.TextEscaping;

namespace Dotless.EntityGenerators.GraphGenerators
{
    public class DotGraphGenerator : DotEntityGenerator<DotGraph, IDotGraphWriter>
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();

        public DotGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual string? EscapeGraphIdentifier(string? id)
        {
            return _graphIdEscaper.Escape(id);
        }

        public override void Write(DotGraph graph, IDotGraphWriter writer)
        {
            WriteDeclaration(graph, writer);
            WriteBody(graph, writer);
        }

        protected virtual void WriteDeclaration(DotGraph graph, IDotGraphWriter writer)
        {
            var id = EscapeGraphIdentifier(graph.Id);

            writer.WriteGraphDeclaration
            (
                id,
                graph.IsDirected,
                graph.IsStrict,
                quoteId: id is { } && IdentifierRequiresQuoting(id!)
            );
        }

        protected virtual void WriteBody(DotGraphBody graphBody, IDotGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Write(graphBody, bodyWriter);
            writer.EndBody();
        }
    }
}