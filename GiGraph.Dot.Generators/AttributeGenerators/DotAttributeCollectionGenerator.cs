﻿using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.AttributeWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public class DotAttributeCollectionGenerator : DotEntityGenerator<DotAttributeCollection, IDotAttributeStatementWriter>
    {
        protected DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotAttributeCollection attributes, IDotAttributeStatementWriter writer)
        {
            var orderedAttributes = attributes.OrderBy((IDotAttribute a) => a.Key).ToList();

            foreach (var attribute in orderedAttributes)
            {
                var nodeWriter = writer.BeginAttribute();
                _entityGenerators.GetForEntity<IDotAttributeWriter>(attribute).Generate(attribute, nodeWriter);
                writer.EndAttribute();
            }
        }
    }
}