using System;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Types.Attributes
{
    /// <summary>
    ///     Assigns a DOT attribute key to an enumeration value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DotAttributeValueAttribute : Attribute
    {
        /// <summary>
        ///     Creates a new instance.
        /// </summary>
        /// <param name="value">
        ///     The value of the DOT attribute.
        /// </param>
        public DotAttributeValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets the value of the DOT attribute.
        /// </summary>
        public string Value { get; }

        public static bool TryGetValue<TEnum>(TEnum value, out string dotValue)
            where TEnum : struct
        {
            var enumMember = typeof(TEnum).GetMember(value.ToString()).First();

            if (enumMember.GetCustomAttribute<DotAttributeValueAttribute>() is {} attribute)
            {
                dotValue = attribute.Value;
                return true;
            }

            dotValue = null;
            return false;
        }
    }
}