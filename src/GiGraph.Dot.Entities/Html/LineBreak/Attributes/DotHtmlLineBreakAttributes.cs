﻿using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak.Attributes
{
    public class DotHtmlLineBreakAttributes : DotHtmlEntityAttributes<IDotHtmlLineBreakAttributes, DotHtmlLineBreakAttributes>, IDotHtmlLineBreakAttributes
    {
        private static readonly Lazy<DotMemberAttributeKeyLookup> HtmlLineBreakAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlLineBreakAttributes, IDotHtmlLineBreakAttributes>().BuildLazy();

        public DotHtmlLineBreakAttributes(DotHtmlAttributeCollection attributes)
            : base(attributes, HtmlLineBreakAttributesKeyLookup)
        {
        }

        [DotAttributeKey("align")]
        public virtual DotHorizontalAlignment? LineAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}