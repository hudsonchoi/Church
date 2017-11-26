using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class DonateMemberList : ReadOnlyListBase<DonateMemberList, DonateMemberInfo>
    {
        public static DonateMemberList GetList(int id)
        {
            DonateMemberList list = DataPortal.Fetch<DonateMemberList>(new Criteria(id));

           
            return list;
        }

        public static DonateMemberList GetList(int memberid, string koName, string enFullName, string enLastName, string enFirstName, string address)
        {
            DonateMemberList list = DataPortal.Fetch<DonateMemberList>(new Criteria(memberid, koName, enFullName, enLastName, enFirstName, address));
         
            return list;
        }

        [Serializable()]
        private class Criteria
        {
            private string _name = string.Empty;
            private string _firstname = string.Empty;
            private string _lastname = string.Empty;
            private string _address = string.Empty;
            private int _memberid;
            private string  _enfullanme;
            private int _donateid;

            public int ID { get { return _donateid; } }
            public string KoName { get { return _name; } }
            public string EnFirstName { get { return _firstname; } }
            public string EnLastName { get { return  _lastname; } }
            public int MamberID { get { return _memberid; } }
            public string Address { get { return _address; } }
            public string EnFullName { get { return _enfullanme; } }

            public Criteria(int donateid)
            {
                _donateid = donateid;
            }

            public Criteria(int memberid , string koName , string enFullName,  string enLastName , string enFirstName, string address)
            {
                _name = koName;
                _memberid = memberid;
                _lastname = enLastName;
                _firstname = enFirstName;
                _address = address;
                _enfullanme = enFullName;
         
            }
        }

        private void DataPortal_Fetch(Criteria critera)
        {
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_donate].[donatemember_list]";
                    cm.Parameters.AddWithValue("@donateid", critera.ID);
                    cm.Parameters.AddWithValue("@memberid", critera.MamberID);
                    cm.Parameters.AddWithValue("@enName", critera.EnFullName);
                    cm.Parameters.AddWithValue("@name", critera.KoName);
                    cm.Parameters.AddWithValue("@address", critera.Address);
                    cm.Parameters.AddWithValue("@enFirstName", critera.EnFirstName);
                    cm.Parameters.AddWithValue("@enLastName", critera.EnLastName);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            DonateMemberInfo info = new DonateMemberInfo(dr);
                            this.Add(info);
                        }
                        IsReadOnly = false;
                    }
                }
            }
        }
    }
          
}
