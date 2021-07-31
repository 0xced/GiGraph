using System;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
{
    public class DotHtmlTextTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void multiline_text_is_split_with_br_elements()
        {
            var entity = DotHtmlText.FromMultilineText($"Line 1{Environment.NewLine}Line 2");

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_multiline_text"
            );
        }

        [Fact]
        public void multiline_text_is_split_with_br_elements_with_alignment()
        {
            var entity = DotHtmlText.FromMultilineText($"Line 1{Environment.NewLine}Line 2", DotHorizontalAlignment.Right);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_multiline_right-aligned_text"
            );
        }

        [Fact]
        public void single_line_text_is_not_split()
        {
            var entity = DotHtmlText.FromMultilineText("Line 1");

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_single-line_text"
            );
        }
    }
}