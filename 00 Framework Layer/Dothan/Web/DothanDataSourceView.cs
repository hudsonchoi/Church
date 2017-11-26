using System;
using System.Collections;
using System.Web.UI;

namespace Dothan.Web
{
    public class DothanDataSourceView : DataSourceView
    {

        private DothanDataSource _owner;
        private string _typeName;
        private string _typeAssemblyName;

        public DothanDataSourceView(DothanDataSource owner, string viewName)
            : base(owner, viewName)
        {
            _owner = owner;
        }

   
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

     
        public string TypeAssemblyName
        {
            get { return _typeAssemblyName; }
            set { _typeAssemblyName = value; }
        }

        #region Select

        protected override System.Collections.IEnumerable
          ExecuteSelect(DataSourceSelectArguments arguments)
        {
            // get the object from the page
            SelectObjectArgs args = new SelectObjectArgs();
            _owner.OnSelectObject(args);
            object obj = args.BusinessObject;

            object result;
            if (arguments.RetrieveTotalRowCount)
            {
                if (obj == null)
                    result = 0;
                else if (obj is IList)
                    result = ((IList)obj).Count;
                else if (obj is IEnumerable)
                {
                    IEnumerable temp = (IEnumerable)obj;
                    int count = 0;
                    foreach (object item in temp)
                        count++;
                    result = count;
                }
                else
                    result = 1;
            }
            else
                result = obj;

            if (!(result is IEnumerable))
            {
                ArrayList list = new ArrayList();
                list.Add(result);
                result = list;
            }

            // now return the object as a result
            return (IEnumerable)result;
        }

        #endregion

        #region Insert

       
        public override bool CanInsert
        {
            get
            {
                if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(
                  DothanDataSource.GetType(_typeAssemblyName, _typeName)))
                    return true;
                else
                    return false;
            }
        }

        protected override int ExecuteInsert(
          IDictionary values)
        {
            // tell the page to insert the object
            InsertObjectArgs args =
              new InsertObjectArgs(values);
            _owner.OnInsertObject(args);
            return args.RowsAffected;
        }

        #endregion

        #region Delete

       
        public override bool CanDelete
        {
            get
            {
                if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(
                  DothanDataSource.GetType(_typeAssemblyName, _typeName)))
                    return true;
                else
                    return false;
            }
        }

        protected override int ExecuteDelete(IDictionary keys, IDictionary oldValues)
        {

            DeleteObjectArgs args = new DeleteObjectArgs(keys, oldValues);
            _owner.OnDeleteObject(args);
            return args.RowsAffected;
        }

        #endregion

        #region Update

        public override bool CanUpdate
        {
            get
            {
                if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(
                  DothanDataSource.GetType(_typeAssemblyName, _typeName)))
                    return true;
                else
                    return false;
            }
        }

        protected override int ExecuteUpdate(IDictionary keys, IDictionary values, IDictionary oldValues)
        {
           
            UpdateObjectArgs args = new UpdateObjectArgs(keys, values, oldValues);
            _owner.OnUpdateObject(args);
            return args.RowsAffected;
        }

        #endregion

        #region Other Operations

        public override bool CanPage
        {
            get { return false; }
        }

     
        public override bool CanRetrieveTotalRowCount
        {
            get { return true; }
        }

  
        public override bool CanSort
        {
            get { return false; }
        }

        #endregion

    }
}
