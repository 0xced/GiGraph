using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Contains ready HTML text to be rendered as is, without further processing.
    /// </summary>
    public class DotHtml : DotHtmlEntity
    {
        // TODO: dodać osobną klasę z kodami HTML: https://www.rapidtables.com/web/html/html-codes.html

        /// <summary>
        ///     Non-breaking space.
        /// </summary>
        public static readonly DotHtml Nbsp = new("&nbsp;");

        protected readonly string _html;

        /// <summary>
        ///     Initializes a new instance with the specified HTML.
        /// </summary>
        /// <param name="html">
        ///     The HTML to initialize the instance with.
        /// </param>
        public DotHtml(string html)
        {
            _html = html;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _html;
    }
}