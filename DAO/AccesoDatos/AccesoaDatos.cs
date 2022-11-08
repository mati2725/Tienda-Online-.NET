using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO.AccesoDatos
{
    class AccesoaDatos
    {
        private static SqlConnection sqlcn;
        private static string _connectionString;
        private AccesoaDatos()
        {
            
        }

        public static SqlConnection GetConnection()
        {
            if (sqlcn == null)
            {
                _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                sqlcn = new SqlConnection(_connectionString);
                
                try
                {
                    sqlcn.Open();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    sqlcn.Close();
                }
            }
            return sqlcn;
        }

        public static DataTable GetDatatable(string query)
        {
            return GetDatatable(GetCommand(query));
        }

        public static DataTable GetDatatable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public static SqlCommand GetCommand(string query)
        {
            return new SqlCommand(query, GetConnection());
        }

        public static SqlCommand GetCommandSp(string spQuery)
        {
            SqlCommand cmd = GetCommand(spQuery);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public static Boolean ExistData(string query)
        {
            return ExistData(GetCommand(query));
        }

        public static Boolean ExistData(SqlCommand cmd)
        {

            bool exist = false;
            try
            {
                var reader = cmd.ExecuteReader();
                exist = reader.HasRows;
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return exist;
        }

        public static int ModifyData(string query)
        {

            using (SqlCommand cmd = new SqlCommand(query, GetConnection()))
            {
                return ModifyData(cmd);
            }
        }

        public static int ModifyData(SqlCommand cmd)
        {
            try
            {
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }
}
