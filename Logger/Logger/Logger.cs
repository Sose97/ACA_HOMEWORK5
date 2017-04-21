using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logger
{
     static class Logger
    {
        static int i = 0;
        private static Object thisLock = new Object();
        public static void AddLog(Log current)
        {
            lock (thisLock)
            {
                current.ID = ++i;
                
            }
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
            {
                string sql = "INSERT INTO Logs(ID, Time, SourceIP, Message)"+
                             "VALUES("+current.ID+","+current.time+","+current.sourceIP+","+current.message+")";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
            }






        }
    }
}
