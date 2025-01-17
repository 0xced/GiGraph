using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties;

public abstract partial class DotEntityAttributes : IDotEntityAttributes
{
    protected readonly Lazy<DotMemberAttributeKeyLookup> _attributeKeyLookup;
    protected readonly DotAttributeCollection _attributes;

    protected DotEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
    {
        _attributes = attributes;
        _attributeKeyLookup = attributeKeyLookup;
    }

    internal DotAttributeCollection Collection => _attributes;

    DotEntityAttributesAccessor IDotEntityAttributes.Accessor => GetAccessor();
    protected abstract DotEntityAttributesAccessor GetAccessor();

    protected virtual string GetKey(MethodBase accessor)
    {
        // the lookup contains only interface properties and property accessors of implementing classes
        return _attributeKeyLookup.Value.GetPropertyAccessorKey((MethodInfo) accessor);
    }

    protected internal virtual string GetKey(PropertyInfo property)
    {
        // the lookup contains only interface properties and property accessors of implementing classes
        return _attributeKeyLookup.Value.GetPropertyKey(property);
    }
}