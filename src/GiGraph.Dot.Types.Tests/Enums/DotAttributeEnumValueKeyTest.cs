using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Output.EnumHelpers;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Metadata.Html;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Enums
{
    public class DotAttributeEnumValueKeyTest
    {
        private static readonly HashSet<Type> IgnoredEnums = new()
        {
            // these enums are not expected to have any attribute names assigned
            typeof(DotNodeFillStyle),
            typeof(DotClusterFillStyle),
            typeof(DotBorderStyle),
            typeof(DotBorderWeight),
            typeof(DotCornerStyle),
            typeof(DotLineStyle),
            typeof(DotLineWeight)
        };

        public static IEnumerable<object[]> EnumTypes { get; } = GetAllEnumTypes()
           .Where(t => !IgnoredEnums.Contains(t))
           .Select(t => new[] { t })
           .ToArray();

        public static IEnumerable<object[]> FlagsEnumTypes { get; } = GetAllEnumTypes()
           .Where(t => !IgnoredEnums.Contains(t))
           .Where(t =>
                t.GetCustomAttribute<DotJoinableTypeAttribute>() is not null ||
                t.GetCustomAttribute<DotHtmlJoinableTypeAttribute>() is not null
            )
           .Select(t => new[] { t })
           .ToArray();

        private static IEnumerable<Type> GetAllEnumTypes()
        {
            var types = Assembly.LoadFrom("GiGraph.Dot.Types.dll")!.GetTypes()
               .Where(t => t.IsEnum)
               .ToArray();

            Assert.NotEmpty(types);
            return types;
        }

        [Theory]
        [MemberData(nameof(EnumTypes))]
        public void all_enum_properties_have_a_non_empty_attribute_value_assigned(Type enumType)
        {
            var metadata = new DotEnumMetadata(enumType);

            foreach (var value in metadata.GetSingleFlagValues())
            {
                var enumMember = enumType.GetMember(value.ToString()!).First();

                IDotAttributeValueAttribute dotAttribute = enumMember.GetCustomAttribute<DotAttributeValueAttribute>();
                IDotAttributeValueAttribute htmlAttribute = enumMember.GetCustomAttribute<DotHtmlAttributeValueAttribute>();

                // at least one of these attributes has to be specified
                Assert.NotNull(dotAttribute ?? htmlAttribute);

                foreach (var attribute in new[] { dotAttribute, htmlAttribute }.Where(a => a is not null))
                {
                    // null is allowed, but an empty string is considered to be a mistake
                    Assert.True(attribute!.Value is null || attribute.Value.Length > 0);
                }
            }
        }

        [Theory]
        [MemberData(nameof(FlagsEnumTypes))]
        public void multiflag_enum_properties_do_not_have_an_attribute_value_assigned_for_joinable_types(Type enumType)
        {
            var metadata = new DotEnumMetadata(enumType);

            foreach (var value in metadata.GetMultiFlagValues())
            {
                var enumMember = enumType.GetMember(value.ToString()!).First();

                IDotAttributeValueAttribute dotAttribute = enumMember.GetCustomAttribute<DotAttributeValueAttribute>();
                IDotAttributeValueAttribute htmlAttribute = enumMember.GetCustomAttribute<DotHtmlAttributeValueAttribute>();

                Assert.Null(dotAttribute?.Value ?? htmlAttribute?.Value);
            }
        }

        [Theory]
        [MemberData(nameof(EnumTypes))]
        public void enum_properties_have_non_repeating_attribute_values_assigned(Type enumType)
        {
            var mapping = DotAttributeValue.GetMapping(enumType);
            foreach (var (key, value) in mapping)
            {
                Assert.DoesNotContain(
                    mapping,
                    item2 => !Equals(key, item2.Key) &&
                        string.Equals(value, item2.Value, StringComparison.OrdinalIgnoreCase)
                );
            }
        }
    }
}