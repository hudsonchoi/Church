using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library
{
    [Serializable()]
    public class FileLog : NameValueListBase<int, string>
    {
        public static FileLog Get(string lastupdated)
        {
            return DataPortal.Fetch<FileLog>(new Criteria(lastupdated));
        }

        private FileLog() { }

        [Serializable()]
        private class Criteria
        {
            private SmartDate _lastupdated = new SmartDate(false);

            public SmartDate LastUpdated { get { return _lastupdated; } }
            public Criteria(string lastupdated)
            {
                _lastupdated.Text = lastupdated;
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
                    cm.CommandText = "app_common.filelog_getlastupdated";
                    cm.Parameters.AddWithValue("@lastupdated", criteria.LastUpdated.DBValue);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        IsReadOnly = false;
                        while (dr.Read())
                            this.Add(new NameValuePair(dr.GetInt32("id"), dr.GetString("filename")));
                        IsReadOnly = true;
                    }
                }
            }

            this.RaiseListChangedEvents = true;
        }

        public static string UpdateFileLog(string filename, string user, string update)
        {
            CommandUpdateFileLog result = DataPortal.Execute<CommandUpdateFileLog>(new CommandUpdateFileLog(filename, user, update));
            return result.UpdatedDate;
        }


        [Serializable()]
        private class CommandUpdateFileLog : CommandBase
        {
            private string _filename = string.Empty;
            private string _user = string.Empty;
            private SmartDate _updatedate = new SmartDate(true);

            public string UpdatedDate
            {
                get
                {
                    return _updatedate.Text;
                }
            }

            public CommandUpdateFileLog(string filename, string user, string update)
            {
                _filename = filename;
                _user = user;
                _updatedate.Text = update;
            }

            protected override void DataPortal_Execute()
            {
                using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "app_common.filelog_update";
                        cm.Parameters.AddWithValue("@filename", _filename);
                        cm.Parameters.AddWithValue("@user", _user);
                        cm.Parameters.AddWithValue("@updatedate", _updatedate.DBValue);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
