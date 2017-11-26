using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizMember
{
    [Serializable()]
    public class StatusMemberList : ReadOnlyListBase<StatusMemberList,StatusMemberInfo>
    {
        public static StatusMemberList GetList(string from, string to, string statuscode , bool familyonly)
        {
            return DataPortal.Fetch<StatusMemberList>(new Criteria(from, to, statuscode , familyonly));
        }

        [Serializable()]
        private class Criteria
        {
            private SmartDate _from;
            private SmartDate _to;
            private string _statuscode;
            private bool _familyonly;


            public SmartDate DateFrom { get { return _from; } }
            public SmartDate DateTo { get { return _to; } }
            public string StatusCode { get { return _statuscode; } }
            public bool FamilyOnly { get { return _familyonly; } }

            public Criteria( string from, string to, string statuscode, bool familyonly)
            {
                _from.Text = from;
                _to.Text = to;
                _statuscode = statuscode;
                _familyonly = familyonly;
   
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
                    cm.CommandText = "[app_member].[status_list]";

                    cm.Parameters.AddWithValue("@to", criteria.DateTo.DBValue);
                    cm.Parameters.AddWithValue("@from", criteria.DateFrom.DBValue);

                    if (!string.IsNullOrEmpty(criteria.StatusCode))
                        cm.Parameters.AddWithValue("@statuslist", criteria.StatusCode);

                    cm.Parameters.AddWithValue("@onlyfamily", criteria.FamilyOnly);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new StatusMemberInfo(dr));
                        IsReadOnly = true;
                    }
                }
            }
        }
    }
}
