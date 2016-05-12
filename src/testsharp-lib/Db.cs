using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace testsharp.lib
{
    public class Db
    {
        private SqlConnection _con;
        private SqlCommand _cmd;
        
        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["dbcon"].ToString();
            }
        }

        public void Open(string connectionString)
        {
            _con = new SqlConnection(connectionString);
            _con.Open();
        }

        public void Open()
        {
            Open(ConnectionString);
        }

        public System.Data.IDataReader Execute(string sql)
        {
            _cmd = _con.CreateCommand();
            _cmd.CommandText = sql;
            return _cmd.ExecuteReader();
        }

        public void Close()
        {
            _con.Close();
        }


    }
}
