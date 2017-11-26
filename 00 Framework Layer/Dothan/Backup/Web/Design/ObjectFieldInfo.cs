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
    public class ObjectFieldInfo : IDataSourceFieldSchema
    {
        private PropertyDescriptor _field;
        private bool _primaryKey;
        private bool _isIdentity;
        private bool _isNullable;
        private int _length;

      
        public ObjectFieldInfo(PropertyDescriptor field)
        {
            _field = field;
            GetDataObjectAttributes();
        }

        private void GetDataObjectAttributes()
        {
            DataObjectFieldAttribute attribute =
              (DataObjectFieldAttribute)
              _field.Attributes[typeof(DataObjectFieldAttribute)];
            if (attribute != null)
            {
                _primaryKey = attribute.PrimaryKey;
                _isIdentity = attribute.IsIdentity;
                _isNullable = attribute.IsNullable;
                _length = attribute.Length;
            }
        }

     
        public Type DataType
        {
            get
            {
                return Utilities.GetPropertyType(
                  _field.PropertyType);
            }
        }


        public bool Identity
        {
            get { return _isIdentity; }
        }

        public bool IsReadOnly
        {
            get { return !_field.IsReadOnly; }
        }


        public bool IsUnique
        {
            get { return _primaryKey; }
        }

        public int Length
        {
            get { return _length; }
        }

        public string Name
        {
            get { return _field.Name; }
        }

  
        public bool Nullable
        {
            get
            {
                Type t = _field.PropertyType;
                if (!t.IsValueType || _isNullable)
                    return true;
                if (t.IsGenericType)
                    return (t.GetGenericTypeDefinition() == typeof(Nullable));
                return false;
            }
        }

    
        public int Precision
        {
            get { return -1; }
        }

      
        public bool PrimaryKey
        {
            get { return _primaryKey; }
        }

       
        public int Scale
        {
            get { return -1; }
        }
    }
}
