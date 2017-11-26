using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellReportList : ReadOnlyListBase<CellReportList, CellReportInfo>
    {
        public static CellReportList GetList(int code,string startdate, string enddate , string createby)
        {
           
                return DataPortal.Fetch<CellReportList>(new Criteria(code,startdate,enddate, createby));
        }
       

        private CellReportList()
        { }

        [Serializable()]
        private class Criteria
        {

            private int _code;
            private SmartDate _from = new SmartDate(false);
            private SmartDate _to = new SmartDate(false);
            private string _createby = string.Empty;

            public SmartDate FromRegDate
            {
                get { return _from; }
            }
            public SmartDate ToRegDate
            {
                get { return _to; }
            }
            public int Code
            {
                get { return _code; }
            }
            public string CreateBy
            {
                get
                {
                    return _createby;
                }
            }

            public Criteria(int code,string startdate , string enddate , string createby)
            {
                _from.Text = startdate;
                _to.Text = enddate;
                _code = code;
                _createby = createby;
            }
        }

        private void DataPortal_Fetch(Criteria criteria)
        {

            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_cell].[report_list]";
                    cm.Parameters.AddWithValue("@code", criteria.Code);
                    cm.Parameters.AddWithValue("@from", criteria.FromRegDate.DBValue);
                    cm.Parameters.AddWithValue("@to", criteria.ToRegDate.DBValue);
                   
                    if(!string.IsNullOrEmpty(criteria.CreateBy))
                        cm.Parameters.AddWithValue("@createby", criteria.CreateBy);
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new CellReportInfo(dr));
                        IsReadOnly = true;
                    }
                }
            }
        }
    }
}