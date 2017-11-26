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
    public class DothanDesignerDataSourceView : DesignerDataSourceView
    {

        private DothanDataSourceDesigner _owner = null;
        public DothanDesignerDataSourceView(DothanDataSourceDesigner owner, string viewName)
            : base(owner, viewName)
        {
            _owner = owner;
        }

       
        public override System.Collections.IEnumerable
          GetDesignTimeData(int minimumRows, out bool isSampleData)
        {
            IDataSourceViewSchema schema = this.Schema;
            DataTable result = new DataTable();

            // create the columns
            foreach (IDataSourceFieldSchema item in schema.GetFields())
                result.Columns.Add(item.Name, item.DataType);

            // create sample data
            for (int index = 1; index <= minimumRows; index++)
            {
                object[] values = new object[result.Columns.Count];
                int colIndex = 0;
                foreach (DataColumn col in result.Columns)
                {
                    if (col.DataType.Equals(typeof(string)))
                        values[colIndex] = "abc";
                    else if (col.DataType.Equals(typeof(DateTime)))
                        values[colIndex] = DateTime.Today.ToShortDateString();
                    else if (col.DataType.Equals(typeof(bool)))
                        values[colIndex] = false;
                    else if (col.DataType.IsPrimitive)
                        values[colIndex] = index;
                    else if (col.DataType.Equals(typeof(Guid)))
                        values[colIndex] = Guid.Empty;
                    else if (col.DataType.IsValueType)
                        values[colIndex] =
                          Activator.CreateInstance(col.DataType);
                    else
                        values[colIndex] = null;
                    colIndex++;
                }
                result.LoadDataRow(values, LoadOption.OverwriteChanges);
            }

            isSampleData = true;
            return result.DefaultView as IEnumerable;
        }

     
        public override IDataSourceViewSchema Schema
        {
            get
            {
                return new ObjectSchema(
                  _owner.DataSourceControl.TypeAssemblyName,
                  _owner.DataSourceControl.TypeName).GetViews()[0];
            }
        }

      
        public override bool CanRetrieveTotalRowCount
        {
            get { return true; }
        }

     
        public override bool CanDelete
        {
            get
            {
                Type objectType = DothanDataSource.GetType(
                  _owner.DataSourceControl.TypeAssemblyName,
                  _owner.DataSourceControl.TypeName);
                if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(objectType))
                    return true;
                else if (objectType.GetMethod("Remove") != null)
                    return true;
                else
                    return false;
            }
        }

    
        public override bool CanInsert
        {
            get
            {
                Type objectType = DothanDataSource.GetType(
                  _owner.DataSourceControl.TypeAssemblyName,
                  _owner.DataSourceControl.TypeName);
                if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(objectType))
                    return true;
                else
                    return false;
            }
        }

        public override bool CanUpdate
        {
            get
            {
                Type objectType = DothanDataSource.GetType(
                  _owner.DataSourceControl.TypeAssemblyName,
                  _owner.DataSourceControl.TypeName);
                if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(objectType))
                    return true;
                else
                    return false;
            }
        }

  
        public override bool CanPage
        {
            get { return false; }
        }

      
        public override bool CanSort
        {
            get { return false; }
        }
    }
}
