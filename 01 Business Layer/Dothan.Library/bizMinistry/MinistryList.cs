﻿using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizMinistry
{
    [Serializable()]
    public class MinistryList : NameValueListBase<int,string>
    {
           public static MinistryList  Get(bool set)
        {
            return DataPortal.Fetch<MinistryList>(new Criteria(set));
        }

        private MinistryList () 
        {   }

        [Serializable()]
        private class Criteria
        {
            private bool _set;

            public string set { get { return _set ? "All" : ""; } }
            public Criteria(bool set)
            {
                _set = set;
            }
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;
            IsReadOnly = false;
            using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[app_ministry].[ministry_list]";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                        {
                            int code = dr.GetInt32("code");
                            if (code == 0)
                            {
                                this.Add(new NameValuePair(dr.GetInt32("code"), criteria.set));
                            }
                            else
                            this.Add(new NameValuePair(dr.GetInt32("code"), dr.GetString("name")));
                        }
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }
    }
}
