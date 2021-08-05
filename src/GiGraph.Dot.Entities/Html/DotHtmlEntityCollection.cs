using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML entity collection.
    /// </summary>
    public class DotHtmlEntityCollection : List<IDotHtmlEntity>, IDotHtmlEntity
    {
        /// <summary>
        ///     Creates a new entity collection.
        /// </summary>
        /// <param name="entities">
        ///     The entities to initialize the collection with.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when a null collection is passed.
        /// </exception>
        public DotHtmlEntityCollection(params IDotHtmlEntity[] entities)
            : base(entities)
        {
        }

        /// <summary>
        ///     Creates a new entity collection.
        /// </summary>
        /// <param name="entities">
        ///     The entities to initialize the collection with.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when a null collection is passed.
        /// </exception>
        public DotHtmlEntityCollection(IEnumerable<IDotHtmlEntity> entities)
            : base(entities)
        {
        }

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml()" />
        public virtual DotHtmlString ToHtml()
        {
            return ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }

        string IDotHtmlEncodable.ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ToHtml(options, syntaxRules);
        }

        public override string ToString()
        {
            return ToHtml();
        }

        protected virtual string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(string.Empty, this.Select(entity => entity.ToHtml(options, syntaxRules)));
        }
    }
}