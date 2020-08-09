﻿using GiGraph.Dot.Output.Writers.Attributes.Edge;
using GiGraph.Dot.Output.Writers.Attributes.Graph;
using GiGraph.Dot.Output.Writers.Attributes.Node;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotGlobalEntityAttributesStatementWriter : DotEntityWriter, IDotGlobalEntityAttributesStatementWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotGlobalEntityAttributesStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual IDotGlobalGraphAttributesWriter BeginGraphAttributesStatement()
        {
            return new DotGlobalGraphAttributesWriter(_tokenWriter, _context);
        }

        public virtual void EndGraphAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalNodeAttributesWriter BeginNodeAttributesStatement()
        {
            return new DotGlobalNodeAttributesWriter(_tokenWriter, _context);
        }

        public virtual void EndNodeAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalEdgeAttributesWriter BeginEdgeAttributesStatement()
        {
            return new DotGlobalEdgeAttributesWriter(_tokenWriter, _context);
        }

        public virtual void EndEdgeAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        protected virtual void EndEntityAttributesStatement()
        {
            if (_useStatementDelimiter)
            {
                _tokenWriter.StatementEnd();
            }

            _tokenWriter.LineBreak()
               .Indentation(linger: true);
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}