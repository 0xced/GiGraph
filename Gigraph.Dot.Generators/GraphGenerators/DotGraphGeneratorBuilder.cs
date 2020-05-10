﻿using Gigraph.Dot.Core;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;

namespace Gigraph.Dot.Generators.GraphGenerators
{
    public class DotGraphGeneratorBuilder : IDotGraphGeneratorBuilder
    {
        protected readonly IDotEntityGeneratorsProviderBuilder _dotEntityGeneratorsProviderBuilder;

        public DotGraphGeneratorBuilder(IDotEntityGeneratorsProviderBuilder dotEntityGeneratorsProviderBuilder)
        {
            _dotEntityGeneratorsProviderBuilder = dotEntityGeneratorsProviderBuilder;
        }

        /// <summary>
        /// Builds a DOT graph generator initialized with entity generators provided to the current instance.
        /// </summary>
        /// <param name="syntaxRules">The syntax rules to follow.</param>
        /// <param name="options">The DOT language generation options to use for graph generation and its components.</param>
        public virtual IDotEntityGenerator Build(DotSyntaxRules syntaxRules, DotGenerationOptions options)
        {
            var providers = _dotEntityGeneratorsProviderBuilder.Build(syntaxRules, options);
            return providers.Get<DotGraphGenerator>();
        }
    }
}