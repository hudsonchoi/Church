using System;
using System.Web.UI;
using System.Web.UI.Design;
using System.ComponentModel;
using System.Reflection;


namespace Dothan.Web
{
    [Designer(typeof(Dothan.Web.Design.DothanDataSourceDesigner))]
    [ToolboxData("<{0}:DothanDataSource runat=\"server\"></{0}:DothanDataSource>")]
    public class DothanDataSource : DataSourceControl
    {

        private DothanDataSourceView _defaultView;
        public event EventHandler<SelectObjectArgs> SelectObject;
        public event EventHandler<InsertObjectArgs> InsertObject;
        public event EventHandler<UpdateObjectArgs> UpdateObject;
        public event EventHandler<DeleteObjectArgs> DeleteObject;

        protected override DataSourceView GetView(string viewName)
        {
            if (_defaultView == null)
                _defaultView = new DothanDataSourceView(this, "Default");
            return _defaultView;
        }

    
        public string TypeAssemblyName
        {
            get { return ((DothanDataSourceView)this.GetView("Default")).TypeAssemblyName; }
            set { ((DothanDataSourceView)this.GetView("Default")).TypeAssemblyName = value; }
        }

      
        public string TypeName
        {
            get { return ((DothanDataSourceView)this.GetView("Default")).TypeName; }
            set { ((DothanDataSourceView)this.GetView("Default")).TypeName = value; }
        }

       
        internal static Type GetType(string assemblyName, string typeName)
        {
            if (!string.IsNullOrEmpty(assemblyName))
            {
                Assembly asm = Assembly.Load(assemblyName);
                return asm.GetType(typeName, true, true);
            }
            else
                return Type.GetType(typeName, true, true);
        }

    
        protected override System.Collections.ICollection GetViewNames()
        {
            return new string[] { "Default" };
        }

        internal void OnSelectObject(SelectObjectArgs e)
        {
            if (SelectObject != null)
                SelectObject(this, e);
        }

       
        internal void OnInsertObject(InsertObjectArgs e)
        {
            if (InsertObject != null)
                InsertObject(this, e);
        }

      
        internal void OnUpdateObject(UpdateObjectArgs e)
        {
            if (UpdateObject != null)
                UpdateObject(this, e);
        }

       
        internal void OnDeleteObject(DeleteObjectArgs e)
        {
            if (DeleteObject != null)
                DeleteObject(this, e);
        }

    }

    public class SelectObjectArgs : EventArgs
    {

        private object _businessObject;

        
        public object BusinessObject
        {
            get { return _businessObject; }
            set { _businessObject = value; }
        }
    }

 
    public class InsertObjectArgs : EventArgs
    {

        private System.Collections.IDictionary _values;
        private int _rowsAffected;

        
        public int RowsAffected
        {
            get { return _rowsAffected; }
            set { _rowsAffected = value; }
        }

        
        public System.Collections.IDictionary Values
        {
            get { return _values; }
        }

        
        public InsertObjectArgs(System.Collections.IDictionary values)
        {
            _values = values;
        }

    }

   
    public class UpdateObjectArgs : EventArgs
    {

        private System.Collections.IDictionary _keys;
        private System.Collections.IDictionary _values;
        private System.Collections.IDictionary _oldValues;
        private int _rowsAffected;

        public int RowsAffected
        {
            get { return _rowsAffected; }
            set { _rowsAffected = value; }
        }

  
        public System.Collections.IDictionary Keys
        {
            get { return _keys; }
        }

        
        public System.Collections.IDictionary Values
        {
            get { return _values; }
        }

   
        public System.Collections.IDictionary OldValues
        {
            get { return _oldValues; }
        }

    
        public UpdateObjectArgs(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            _keys = keys;
            _values = values;
            _oldValues = oldValues;
        }

    }

   
    public class DeleteObjectArgs : EventArgs
    {
        private System.Collections.IDictionary _keys;
        private System.Collections.IDictionary _oldValues;
        private int _rowsAffected;

     
        public int RowsAffected
        {
            get { return _rowsAffected; }
            set { _rowsAffected = value; }
        }

        
        public System.Collections.IDictionary Keys
        {
            get { return _keys; }
        }

        public System.Collections.IDictionary OldValues
        {
            get { return _oldValues; }
        }

        /// <summary>
        /// Create an instance of the object.
        /// </summary>
        public DeleteObjectArgs(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            _keys = keys;
            _oldValues = oldValues;
        }

    }
}
