﻿using GiGraph.Dot.Output.Writers.EdgeWriters;
using GiGraph.Dot.Output.Writers.GraphWriters;
using GiGraph.Dot.Output.Writers.NodeWriters;

namespace GiGraph.Dot.Output.Writers.GlobalAttributesWriters
{
    public interface IDotGlobalAttributesStatementWriter
    {
        IDotGraphAttributesWriter BeginGraphAttributes();
        void EndGraphAttributes();

        IDotNodeDefaultsWriter BeginNodeDefaults();
        void EndNodeDefaults();

        IDotEdgeDefaultsWriter BeginEdgeDefaults();
        void EndEdgeDefaults();
    }
}