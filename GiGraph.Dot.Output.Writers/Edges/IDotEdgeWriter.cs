﻿using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Writers.Edges
{
    public interface IDotEdgeWriter : IDotEntityWithAttributeListWriter
    {
        IDotEndpointWriter BeginEndpoint();
        void EndEndpoint();

        IDotSubgraphWriter BeginSubgraph(bool preferExplicitDeclaration);
        void EndSubgraph();

        void WriteEdge();
    }
}