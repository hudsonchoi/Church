using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library
{
    [Serializable()]
    public class GridViewAutoSizeList : NameValueListBase<string, string>
    {

        public static GridViewAutoSizeList GetList()
        {
           return DataPortal.Fetch<GridViewAutoSizeList>(new Criteria(typeof(GridViewAutoSizeList)));
        }
 
        private GridViewAutoSizeList() { }

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;
            this.IsReadOnly = false;
            this.Add(new NameValuePair("NotSet", "NotSet"));
            this.Add(new NameValuePair("None", "None"));
            this.Add(new NameValuePair("AllCells", "AllCells"));
            this.Add(new NameValuePair("AllCellsExceptHeader", "AllCellsExceptHeader"));
            this.Add(new NameValuePair("DisplayedCells", "DisplayedCells"));
            this.Add(new NameValuePair("DisplayedCellsExceptHeader", "DisplayedCellsExceptHeader"));
            this.Add(new NameValuePair("ColumnHeader", "ColumnHeader"));
            this.Add(new NameValuePair("Fill", "Fill"));
            this.IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
    }
}

 