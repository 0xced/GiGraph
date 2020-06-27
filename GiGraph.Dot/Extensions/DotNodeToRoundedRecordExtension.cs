﻿using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Records;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    /// Provides helper methods for <see cref="DotNode"/>.
    /// </summary>
    public static class DotNodeToRoundedRecordExtension
    {
        /// <summary>
        /// Converts the current node to a rounded record node.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="record">The record to use as the label of the node.</param>
        public static void ToRoundedRecord(this DotNode node, DotRecord record)
        {
            node.Attributes.Shape = DotShape.RoundedRecord;
            node.Attributes.Label = record;
        }

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRoundedRecord(this DotNode node, params DotRecordField[] fields) => ToRoundedRecord(node, new DotRecord(fields));

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRoundedRecord(this DotNode node, IEnumerable<DotRecordField> fields) => ToRoundedRecord(node, new DotRecord(fields));

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRoundedRecord(this DotNode node, bool flip, params DotRecordField[] fields) => ToRoundedRecord(node, new DotRecord(flip, fields));

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRoundedRecord(this DotNode node, bool flip, IEnumerable<DotRecordField> fields) => ToRoundedRecord(node, new DotRecord(fields, flip));

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRoundedRecord(this DotNode node, params string[] fields) => ToRoundedRecord(node, new DotRecord(fields));

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRoundedRecord(this DotNode node, IEnumerable<string> fields) => ToRoundedRecord(node, new DotRecord(fields));

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRoundedRecord(this DotNode node, bool flip, params string[] fields) => ToRoundedRecord(node, new DotRecord(flip, fields));

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRoundedRecord(this DotNode node, bool flip, IEnumerable<string> fields) => ToRoundedRecord(node, new DotRecord(fields, flip));
    }
}