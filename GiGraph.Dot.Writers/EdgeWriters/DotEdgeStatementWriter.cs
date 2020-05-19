﻿using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public class DotEdgeStatementWriter : DotEntityStatementWriter, IDotEdgeStatementWriter
    {
        public DotEdgeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, useStatementDelimiter)
        {
        }

        public virtual IDotEdgeWriter BeginEdge()
        {
            return new DotEdgeWriter(_tokenWriter, _context);
        }

        public virtual void EndEdge()
        {
            EndStatement();
        }
    }
}