using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library
{
    [Serializable()]
    public class Familys : BusinessListBase<Familys , Family>
    {
        public void Remove(int id)
        {
            foreach (Family item in this)
            {
                if (item.Code == id)
                {
                    Remove(item);
                    break;
                }
            }
        }
        
        public void SetFamilycode(int familycode)
        {
            foreach (Family item in this)
            { 
                item.Family_Code = familycode;
                if (item.Code == familycode)
                    item.Relationship = 0;
                else
                {
                    if (item.Relationship == 0)
                        item.Relationship = 1;
                   
                }
            }
        }



        public int DefaultRelationShip()
        {
            int relationship = 0;
            foreach (Family item in this)
            {
                if (relationship <= item.Relationship)
                    relationship = item.Relationship + 1;

            }
            return relationship;
        }
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
            private int _code;
            public int Code
            {
                get { return _code; }
            }
            public Criteria(int code)
            {
                _code = code;
            }
        }

        [Serializable()]
        public class FilterCriteria
        {
            private int _code;
            private string _div;
            public string div
            {
                get
                {
                    return _div;
                }
            }
            public int code
            {
                get { return _code; }
            }
            public FilterCriteria(int code, string div)
            {
                _code = code;
                _div = div;
            }
        }

        #endregion

        private Familys() { this.AllowNew = true; }

        public static Familys GetList(int code)
        {
            return DataPortal.Fetch<Familys>(new Criteria(code));
        }

     
        protected override object AddNewCore()
        {
            Family item = Family.New();
            item.Code = GetNewID();
            Add(item);
            return item;
        }
        public int GetNewID()
        {
           
            int max = 0;
            foreach (Family item in this)
            {
                if (item.Code > max)
                    max = item.Code;
            }
           return  max + 1;
        }
        public Family AddNewFamily()
        {
            Family item = Family.New();
            item.Code = GetNewID();
            Add(item);
            return item;
        }

        public Family GetItem(int code)
        {
            foreach (Family items in this)
            {
                if (items.Code == code)
                      return items;
            }
            return null;
            
        }

     
        public void FamilycodeChange(int familycode)
        {
            foreach (Family item in this)
            {
                item.Family_Code = familycode;
            }
        }

        public override Familys Save()
        {
            if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to save roles");
            Familys result;
            result = base.Save();
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
                    cm.CommandText = "GetFamily";
                    cm.Parameters.AddWithValue("@family_code", criteria.Code);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(Family.Get(dr));
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
               
                foreach (Family item in this)
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
