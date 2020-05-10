﻿namespace Gigraph.Dot.Entities.Subgraphs
{
    public class DotSubgraphCollection : DotGenericSubgraphCollection<DotSubgraph>
    {
        public override int Remove(string id)
        {
            return RemoveAll(subgraph => subgraph.Id == id);
        }
    }
}
