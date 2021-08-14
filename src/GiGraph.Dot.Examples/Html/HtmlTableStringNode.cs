﻿using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Examples.Html
{
    public static class HtmlTableStringNode
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            graph.Nodes.Add("Bar").ToPlainHtmlNode
            (
                @"<TABLE BORDER=""0"" CELLBORDER=""1"" CELLSPACING=""0"" CELLPADDING=""4"">
                    <TR>
                        <TD ROWSPAN=""3"">Foo<BR/>Bar</TD>
                        <TD COLSPAN=""3"" ALIGN=""LEFT"">Baz</TD>
                        <TD ROWSPAN=""3"">Qux</TD>
                        <TD ROWSPAN=""3"">Quux</TD>
                    </TR>
                    <TR>
                        <TD>Garply</TD>
                        <TD>Waldo</TD>
                        <TD PORT=""port1""><FONT COLOR=""royalblue""><B><I>Fred</I></B></FONT></TD>
                    </TR>
                    <TR>
                        <TD COLSPAN=""3"" ALIGN=""RIGHT"">Plugh</TD>
                    </TR>
                </TABLE>"
            );

            // the following line is equivalent to the next one as far as visualization is concerned
            graph.Edges.Add("Foo", "Bar").Attributes.Head.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

            // an equivalent method of defining a port
            graph.Edges.Add("Foo", "Bar").Head.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

            return graph;
        }
    }
}