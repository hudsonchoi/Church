using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.Design;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Dothan.Web.Design
{
    public class ObjectViewSchema : IDataSourceViewSchema
    {
        private string _typeAssemblyName = string.Empty;
        private string _typeName = string.Empty;

   
        public ObjectViewSchema(string assemblyName, string typeName)
        {
            _typeAssemblyName = assemblyName;
            _typeName = typeName;
        }

       
        public IDataSourceViewSchema[] GetChildren()
        {
            return null;
        }

      
        public IDataSourceFieldSchema[] GetFields()
        {
            List<ObjectFieldInfo> result =  new List<ObjectFieldInfo>();
            Type t = DothanDataSource.GetType(
              _typeAssemblyName, _typeName);
            if (typeof(IEnumerable).IsAssignableFrom(t))
            {
                // this is a list so get the item type
                t = Utilities.GetChildItemType(t);
            }
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(t);
            foreach (PropertyDescriptor item in props)
                if (item.IsBrowsable)
                    result.Add(new ObjectFieldInfo(item));
            return result.ToArray();
        }

        
        public string Name
        {
            get { return "Default"; }
        }

    }
}
