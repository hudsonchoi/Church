using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dothan.Library
{
    public class Configurations
    {
        public static string DateFomating
        {
            get
            {
                return ConfigurationManager.AppSettings["DateTimeFormat"].ToString();
            }
        }
    }
}
