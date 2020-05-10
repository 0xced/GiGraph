﻿using Gigraph.Dot.Core;
using Gigraph.Dot.Generators;
using Gigraph.Dot.Generators.Options;

namespace Gigraph.Dot.Generators.GraphGenerators
{
    public interface IDotGraphGeneratorBuilder
    {
        IDotEntityGenerator Build(DotSyntaxRules syntaxRules, DotGenerationOptions options);
    }
}