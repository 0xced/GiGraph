using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class DotEscapeStringConcatenationTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_not_null()
        {
            var value = @"\a" + DotEscapeString.GraphId;

            Assert.Equal(
                @"\\a\G",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void escape_string_concatenation_produces_a_valid_dot_encoded_value_when_left_side_is_null()
        {
            var value = (DotEscapeString) null + @"\a";

            Assert.Equal(
                @"\\a",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void escape_string_concatenation_produces_a_valid_dot_encoded_value_when_right_side_is_null()
        {
            var value = @"\a" + (DotEscapeString) null;

            Assert.Equal(
                @"\\a",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void escape_string_concatenation_produces_an_empty_dot_encoded_value_when_both_sides_are_null()
        {
            var value = null + (DotEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }
    }
}