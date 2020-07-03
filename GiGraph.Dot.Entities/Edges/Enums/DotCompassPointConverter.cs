﻿using System;

namespace GiGraph.Dot.Entities.Edges.Enums
{
    public static class DotCompassPointConverter
    {
        public static string Convert(DotCompassPoint compassPoint)
        {
            switch (compassPoint)
            {
                case DotCompassPoint.Default:
                    return "_";

                case DotCompassPoint.Center:
                    return "c";

                case DotCompassPoint.North:
                    return "n";

                case DotCompassPoint.NorthEast:
                    return "ne";

                case DotCompassPoint.East:
                    return "e";

                case DotCompassPoint.SouthEast:
                    return "se";

                case DotCompassPoint.South:
                    return "s";

                case DotCompassPoint.SouthWest:
                    return "sw";

                case DotCompassPoint.West:
                    return "w";

                case DotCompassPoint.NorthWest:
                    return "nw";

                default:
                    throw new ArgumentOutOfRangeException(nameof(compassPoint), $"The specified compass point '{compassPoint}' is not supported.");
            }
        }
    }
}