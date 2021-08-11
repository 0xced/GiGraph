using System;
using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Text;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Text
{
    /// <summary>
    ///     Textual content of an HTML element.
    /// </summary>
    public class DotHtmlText : DotHtmlEntity
    {
        protected static readonly string[] LineBreaks = { DotNewLine.Windows, DotNewLine.Unix };
        protected readonly DotHorizontalAlignment? _lineAlignment;
        protected readonly string _text;

        /// <summary>
        ///     Initializes a new HTML text instance.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the instance with.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public DotHtmlText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            _text = text;
            _lineAlignment = lineAlignment;
        }

        public override string ToString()
        {
            return _text;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var br = DotHtmlLineBreak.Html(_lineAlignment, options, syntaxRules);
            var escaped = syntaxRules.Attributes.Html.ElementTextContentEscaper.Escape(_text);
            var lines = SplitMultiline(escaped, LineBreaks);

            return string.Join(br, lines);
        }

        protected static string[] SplitMultiline(string text, string[] lineBreaks)
        {
            return text?.Split(lineBreaks, StringSplitOptions.None) ?? Array.Empty<string>();
        }

        /// <summary>
        ///     Creates a collection of entities to represent the specified text as HTML. All line breaks will be replaced with &lt;br /&gt;
        ///     tags.
        /// </summary>
        /// <param name="text">
        ///     The input text.
        /// </param>
        /// <param name="lineBreaks">
        ///     The line break sequences to replace with HTML line break tags (see <see cref="DotNewLine" />).
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public static DotHtmlEntity FromMultilineText(string text, string[] lineBreaks, DotHorizontalAlignment? lineAlignment = null)
        {
            var lines = SplitMultiline(text, lineBreaks);
            if (lines.Length <= 1)
            {
                return new DotHtmlText(text);
            }

            var result = new DotHtmlEntityCollection();

            for (var i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    result.Add(new DotHtmlLineBreak(lineAlignment));
                }

                result.Add(new DotHtmlText(lines[i]));
            }

            return new DotHtmlEntity<DotHtmlEntityCollection>(result);
        }

        /// <summary>
        ///     Creates a collection of entities to represent the specified text as HTML. Line breaks will be replaced with &lt;br /&gt;
        ///     tags.
        /// </summary>
        /// <param name="text">
        ///     The input text.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public static DotHtmlEntity FromMultilineText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return FromMultilineText(text, LineBreaks, lineAlignment);
        }
    }
}