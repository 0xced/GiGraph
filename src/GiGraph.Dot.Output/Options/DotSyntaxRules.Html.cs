﻿using GiGraph.Dot.Output.TextEscaping.Escapers;
using GiGraph.Dot.Output.TextEscaping.Pipelines;

namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxRules
    {
        public class HtmlRules
        {
            /// <summary>
            ///     A text escaper to use for HTML attribute values in general (unless another escaper is used in some contexts).
            /// </summary>
            public virtual IDotTextEscaper AttributeValueEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlAttributeStringValue();

            /// <summary>
            ///     A text escaper to use for HTML attribute values of the escape string type.
            /// </summary>
            public virtual IDotTextEscaper AttributeEscapeStringValueEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlAttributeEscapeStringValue();

            /// <summary>
            ///     A text escaper to use for textual content of HTML elements.
            /// </summary>
            public virtual IDotTextEscaper ElementTextContentEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlElementTextContent();

            /// <summary>
            ///     A text escaper to use for the textual content of HTML comment tags.
            /// </summary>
            public virtual IDotTextEscaper CommentTextEscaper { get; set; } = DotTextEscapingPipeline.ForHtmlCommentText();
        }
    }
}