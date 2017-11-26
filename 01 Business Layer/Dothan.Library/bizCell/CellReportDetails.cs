using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizCell
{
    [Serializable()]
    public class CellReportDetails : BusinessListBase<CellReportDetails, CellReportDetail>
    {

        public int ParentCode { get; set; }
        public static CellReportDetails Get(int code , bool isNew)
        {
            return DataPortal.Fetch<CellReportDetails>(new Criteria(code , isNew ));
        }

        #region Criteria
        [Serializable()]
        public class Criteria
        {
            private int _code;
            private bool _isNew;
            public int Code
            {
                get { return _code; }
            }
            public bool IsNew { get { return _isNew; } }
            public Criteria(int code, bool isNew)
            {
                _code = code;
                _isNew = isNew;
            }
        }


        #endregion

        #region Authorization Rules

        public static bool CanAddObject()
        {
            return true;
        }

        public static bool CanGetObject()
        {
            return true;
        }

        public static bool CanDeleteObject()
        {
            return true;
        }

        public static bool CanEditObject()
        {
            return true;
        }

        #endregion

        private CellReportDetails()
        {
            this.AllowNew = true;

        }
        private CellReportDetails(int cellcode)
        {
            this.AllowNew = true;
        }

        public CellReportDetail GetRow( int id )
        {
            CellReportDetail result = null ; 
            foreach (CellReportDetail info in this)
            {
                if (info.ID == id)
                {
                    result = info;
                    break;
                }
            }
            return result;

        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_cell].[reportdetail_get]";
                    cm.Parameters.AddWithValue("@code", criteria.Code);
                    cm.Parameters.AddWithValue("@isNew", criteria.IsNew);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            if (criteria.IsNew)
                                this.Add(CellReportDetail.New(dr));
                            else
                                this.Add(CellReportDetail.Get(dr));
                            
                        }
                    }
                }
            }
            RaiseListChangedEvents = true;
        }



        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                foreach (CellReportDetail item in DeletedList)
                    item.DeleteSelf(cn);
                DeletedList.Clear();

                foreach (CellReportDetail item in this)
                {
                    if (item.IsNew)
                        item.Insert(cn, ParentCode);
                    else
                        item.Update(cn);
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}
