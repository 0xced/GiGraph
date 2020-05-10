﻿namespace Gigraph.Dot.Entities.Attributes
{
    public interface IDotAttribute : IDotEntity
    {
        /// <summary>
        /// The key of the attribute.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Indicates whether the attribute has a value assigned.
        /// False indicates that it should not be written to the DOT output.
        /// </summary>
        bool HasValue { get; }
    }
}