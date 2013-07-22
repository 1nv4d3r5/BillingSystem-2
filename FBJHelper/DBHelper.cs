using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FBJHelper
{
    public class DBHelper
    {
        private const string defaultConfigKeyName = "DbHelper";
        private static string connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
        private static string providerName = ConfigurationManager.ConnectionStrings["MySql"].ProviderName;


        //不带参数的执行命令   
        public static int ExecuteCommand(string safeSql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                return cmd.ExecuteNonQuery();
            }
        }
        //带参数的执行命令   
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int GetScalar(string safeSql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static SqlDataReader GetReader(string safeSql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(safeSql, connection);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static DataTable GetDataSet(string safeSql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
    }
}
