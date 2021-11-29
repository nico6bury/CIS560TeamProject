using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GURPSData {
    public static class Statics {
        public static string BuildConnectionString() {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb["Data Source"] = "mssql.cs.ksu.edu";
            scsb["User ID"] = "nico6bury";
            scsb["Password"] = "D@t4B4s3:-)";

            return scsb.ConnectionString;
        }//end BuildConnectionString()
    }//end class
}//end namespace
