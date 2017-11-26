using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dothan.Library.bizReport
{
    public class ReportDataAccess
    {

        public ReportDataAccess() { }

        public T ReadIntoTypeDs<T>(T dsTypeDs, string storedProc, List<SqlParameter> paramList) where T : DataSet
        {
            return this.ReadIntoTypeDs(dsTypeDs, storedProc, paramList, 0);
        }

        public T ReadIntoTypeDs<T>(T dsTypedDs, string storedProc, List<SqlParameter> paramList, int nCommandTimeOut) where T : DataSet
        {
            SqlConnection cn = new SqlConnection(Database.ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(storedProc, cn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (nCommandTimeOut > 0)
                adapter.SelectCommand.CommandTimeout = nCommandTimeOut;


            foreach (SqlParameter oParm in paramList) adapter.SelectCommand.Parameters.Add(oParm);

            int nTableCtr = 0;
            foreach (DataTable Dt in dsTypedDs.Tables)
            {
                string cSource = "";
                // tricky part...first result set from sql is Table, 2nd is Table1,
                //  3rd, is Table2
                // So we have to check the counter and set the source string correctly
                if (nTableCtr == 0)
                    cSource = "Table";
                else
                    cSource = "Table" + nTableCtr.ToString().Trim();
                adapter.TableMappings.Add(cSource, Dt.TableName.ToString());
                // set the mapping from the original table name 
                // to the corresponding one in our typed dS

                nTableCtr++;
            }

            adapter.Fill(dsTypedDs);
            cn.Close();

            return dsTypedDs;
        }
    }
}
