using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library
{
    [Serializable()]
    public class Ministries : BusinessListBase<Ministries,Ministry>
    {
        private string _div;

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

        #region Criteria
        [Serializable()]
        public class Criteria
        {
            private string _div;
            public string div
            {
                get { return _div; }
            }
            public Criteria(string div)
            {
                _div = div;
            }
        }

        #endregion

        public static Ministries GetList(string div)
        {
            return DataPortal.Fetch<Ministries>(new Criteria(div));
        }

        protected override object AddNewCore()
        {
            Ministry item = Ministry.New(_div);
            Add(item);
            return item;
        }

        public override Ministries Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            Ministries result;
            result = base.Save();
           // MinistryList.InvalidateCache();
            return result;
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            _div = criteria.div;
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "GetMinistryAll";
                    cm.Parameters.AddWithValue("@div", criteria.div);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(Ministry.Get(dr));
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
                /*
                foreach (StatusLabel item in DeletedList)
                {
                    item.DeleteSelf(cn);
                }
                DeletedList.Clear();
                */
                foreach (Fellowship item in this)
                {
                    if (item.IsNew)
                        item.Insert(cn);
                    else
                        item.Update(cn);
                }
            }
            this.RaiseListChangedEvents = true;
        }
    }
}
