﻿using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Metadata;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotEntityHyperlinkAttributes<TIEntityHyperlinkAttributes> : DotEntityAttributes<TIEntityHyperlinkAttributes>, IDotEntityHyperlinkAttributes
        where TIEntityHyperlinkAttributes : IDotEntityHyperlinkAttributes
    {
        protected DotEntityHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        [DotAttributeKey(DotAttributeKeys.Url)]
        public virtual DotEscapeString Url
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Href)]
        public virtual DotEscapeString Href
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Target)]
        public virtual DotEscapeString Target
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        /// <summary>
        ///     Specifies hyperlink properties.
        /// </summary>
        /// <param name="url">
        ///     The URL of the hyperlink.
        /// </param>
        /// <param name="target">
        ///     The target of the hyperlink. See <see cref="DotHyperlinkTargets" /> for accepted values.
        /// </param>
        public virtual void Set(DotEscapeString url, DotEscapeString target = null)
        {
            Url = url;
            Target = target;
        }

        /// <summary>
        ///     Specifies hyperlink properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotHyperlink attributes)
        {
            Href = attributes.Href;
            Set(attributes.Url, attributes.Target);
        }
    }
}