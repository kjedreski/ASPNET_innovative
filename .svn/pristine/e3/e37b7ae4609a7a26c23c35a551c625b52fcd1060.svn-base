/*
 *  DBconn.cs
 *  
 *  Controls all connections and operations to the
 *  internal database.
 *  
 *  Security: server-side only, should be accessible by all pages.
 *  
 *  vsalvino 2011-12-19
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Newsform
{
    class DBconn
    {

        private string connStr = null;

        private SqlConnection objconn;

        public DBconn(String server, String database, String user, String userpwd)
        {
            connStr = "user id=" + user + ";password=" + userpwd + ";server=" + server + ";Trusted_Connection=yes;database=" + database + ";connection timeout=30";
        }

        public DBconn()
        {
            connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        }

        public void connect()
        {
            objconn = new SqlConnection(connStr);
            objconn.Open();
        }

        /*
         *  Execute a stored procedure 'procedure' with two dimensional array 'param' as parameters
         *  param[0][0] = @param1
         *  param[0][1] = param1value
         *  etc.
         *  Returns a reader with fetched data.
         */
        public SqlDataReader execsp(String procedure, Object[,] param)
        {
            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand(procedure, objconn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (param!=null)
            {
                for (int i = 0; i < param.Length / 2; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(param[i, 0].ToString(), param[i, 1]));
                }
            }
            rdr = cmd.ExecuteReader();
            cmd.Dispose();
            return rdr;
        }

        public void close()
        {
            objconn.Close();
            objconn.Dispose();
        }
    }
}