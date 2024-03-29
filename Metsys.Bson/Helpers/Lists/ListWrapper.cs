using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Metsys.Bson
{
    internal class ListWrapper : BaseWrapper
    {
        private IList _list;

        public override object Collection
        {
            get { return _list; }
        }
        public override void Add(object value)
        {
            _list.Add(value);
        }
        
        protected override object CreateContainer(Type type, Type itemType)
        {
            if (type.IsInterface)
            {
                return Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));
            }
            if (type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null) != null)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
        protected override void SetContainer(object container)
        {
            _list = container == null ? new ArrayList() : (IList)container;
        }               
    }
}