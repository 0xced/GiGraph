﻿using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.GraphWriters;

namespace GiGraph.Dot.Output.Generators.GraphGenerators
{
    public abstract class DotCommonGraphGenerator<TGraph, TWriter> : DotEntityGenerator<TGraph, TWriter>
        where TGraph : DotCommonGraph
        where TWriter : IDotEntityWriter
    {
        protected DotCommonGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null)
        {
        }

        protected virtual void WriteBody(DotCommonGraph graphBody, IDotCommonGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Generate(graphBody, bodyWriter);
            writer.EndBody();
        }
    }
}