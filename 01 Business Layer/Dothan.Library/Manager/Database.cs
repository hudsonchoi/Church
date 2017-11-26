using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using Dothan;

namespace Dothan.Library
{
    public class Database
    {
        public static string ConnectionString
        {
            get
            {

                return string.Format("Server={0}; Database={1};User ID={2};Password={3};",
                            ConfigurationManager.AppSettings["DBServer"].ToString(),
                            ConfigurationManager.AppSettings["DBName"].ToString(),
                            ConfigurationManager.AppSettings["DBUserID"].ToString(),
                            ConfigurationManager.AppSettings["DBPassword"].ToString()
                            );
            }
        }

       
    }
}
