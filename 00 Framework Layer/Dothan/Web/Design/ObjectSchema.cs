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
    public class ObjectSchema : IDataSourceSchema
    {

        private string _typeAssemblyName = string.Empty;
        private string _typeName = string.Empty;

        public ObjectSchema(string assemblyName, string typeName)
        {
            _typeAssemblyName = assemblyName;
            _typeName = typeName;
        }

       
        public IDataSourceViewSchema[] GetViews()
        {
            return new IDataSourceViewSchema[] { new ObjectViewSchema(_typeAssemblyName, _typeName) };
        }
    }
}
