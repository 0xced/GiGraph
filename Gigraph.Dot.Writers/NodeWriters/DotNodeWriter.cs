﻿using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public class DotNodeWriter : DotEntityWithAttributeListWriter, IDotNodeWriter
    {
        public DotNodeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteNodeIdentifier(string id, bool quote)
        {
            _tokenWriter.Identifier(id, quote)
                        .Space(linger: true);
        }
    }
}