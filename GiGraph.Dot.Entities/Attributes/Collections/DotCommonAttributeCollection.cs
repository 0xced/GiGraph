﻿using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotCommonAttributeCollection : IDotEntity, IDotAttributeCollection
    {
        protected readonly IDictionary<string, DotCommonAttribute> _attributes = new Dictionary<string, DotCommonAttribute>(StringComparer.InvariantCulture);

        public virtual int Count => _attributes.Count;

        bool ICollection<DotCommonAttribute>.IsReadOnly => false;

        public virtual void Set(DotCommonAttribute attribute)
        {
            _attributes[attribute.Key] = attribute;
        }

        public virtual void SetRange(IEnumerable<DotCommonAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                Set(attribute);
            }
        }

        public virtual void Set(string key, string value)
        {
            _attributes[key] = new DotStringAttribute(key, value);
        }

        public virtual void SetHtml(string key, string value)
        {
            _attributes[key] = new DotHtmlAttribute(key, value);
        }

        public virtual void Set(string key, int value)
        {
            _attributes[key] = new DotIntAttribute(key, value);
        }

        public virtual void Set(string key, double value)
        {
            _attributes[key] = new DotDoubleAttribute(key, value);
        }

        public virtual void Set(string key, bool value)
        {
            _attributes[key] = new DotBoolAttribute(key, value);
        }

        public virtual void Set(string key, DotShape value)
        {
            _attributes[key] = new DotShapeAttribute(key, value);
        }

        public virtual void Set(string key, DotStyle value)
        {
            _attributes[key] = new DotStyleAttribute(key, value);
        }

        public virtual void Set(string key, DotArrowType value)
        {
            _attributes[key] = new DotArrowTypeAttribute(key, value);
        }

        public virtual void Set(string key, DotArrowDirection value)
        {
            _attributes[key] = new DotArrowDirectionAttribute(key, value);
        }

        public virtual void Set(string key, DotRank value)
        {
            _attributes[key] = new DotRankAttribute(key, value);
        }

        public virtual void Set(string key, DotRankDirection value)
        {
            _attributes[key] = new DotRankDirectionAttribute(key, value);
        }

        public virtual void SetCustom(string key, string value)
        {
            _attributes[key] = new DotCustomAttribute(key, value);
        }

        public virtual bool Contains(DotCommonAttribute attribute)
        {
            return _attributes.Values.Contains(attribute);
        }

        public virtual bool Contains(string key)
        {
            return _attributes.ContainsKey(key);
        }

        public virtual bool Remove(DotCommonAttribute attribute)
        {
            return Remove(attribute.Key);
        }

        public virtual bool Remove(string key)
        {
            return _attributes.Remove(key);
        }

        public virtual int RemoveAll(Predicate<DotCommonAttribute> match)
        {
            var result = 0;
            var matches = _attributes.Values.Where(a => match(a)).ToList();

            foreach (var attribute in matches)
            {
                result += _attributes.Remove(attribute.Key) ? 1 : 0;
            }

            return result;
        }

        public virtual void Clear()
        {
            _attributes.Clear();
        }

        public virtual T GetAs<T>(string key)
            where T : DotCommonAttribute
        {
            if (_attributes.TryGetValue(key, out var result))
            {
                return (T)result;
            }

            return null;
        }

        public virtual bool TryGetAs<T>(string key, out T attribute)
            where T : DotCommonAttribute
        {
            if (_attributes.TryGetValue(key, out var result))
            {
                attribute = result as T;
                return attribute is { };
            }

            attribute = null;
            return false;
        }

        public virtual bool TryGetValueAs<T>(string key, out T value)
        {
            if (_attributes.TryGetValue(key, out var attribute) && attribute is DotCommonAttribute<T> attributeWithValue)
            {
                value = attributeWithValue.Value;
                return true;
            }

            value = default;
            return false;
        }

        protected virtual void AddOrRemove<T>(string key, T attribute)
            where T : DotCommonAttribute
        {
            if (attribute is null)
            {
                Remove(key);
            }
            else
            {
                Set(attribute);
            }
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(string key, TValue value, Func<TValue, TAttribute> attribute)
            where TAttribute : DotCommonAttribute
        {
            AddOrRemove(key, value is null ? null : attribute(value));
        }

        void ICollection<DotCommonAttribute>.Add(DotCommonAttribute attribute)
        {
            Set(attribute);
        }

        public virtual void CopyTo(DotCommonAttribute[] array, int arrayIndex)
        {
            _attributes.Values.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<DotCommonAttribute> GetEnumerator()
        {
            return _attributes.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}