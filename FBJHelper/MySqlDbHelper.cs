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
    public class MySqlDBHelper
    {
        private const string defaultConfigKeyName = "DbHelper";
        private static string connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
        private static string providerName = ConfigurationManager.ConnectionStrings["MySql"].ProviderName;


        #region  新增、修改、删除
        /// <summary>
        /// 一般用于UPDATE、INSERT或DELETE语句，其中唯一的返回值是受影响的记录个数
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>  
         public static int ExecuteCommand(string safeSql)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(safeSql, connection);
                return cmd.ExecuteNonQuery();
            }
        }
        //带参数的执行命令   
        public static int ExecuteCommand(string sql, params MySqlParameter[] values)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                return cmd.ExecuteNonQuery();   // ExecuteNonQuery()一般用于UPDATE、INSERT或DELETE语句，其中唯一的返回值是受影响的记录个数
            }
        }

        //带参数的执行命令   
        public static int ExecuteCommand(MySqlTransaction mySqlTransaction,string sql, params MySqlParameter[] values)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    mySqlTransaction = connection.BeginTransaction();
                    MySqlCommand cmd = new MySqlCommand(sql, connection, mySqlTransaction);
                    cmd.Parameters.AddRange(values);
                    cmd.ExecuteNonQuery();   // ExecuteNonQuery()一般用于UPDATE、INSERT或DELETE语句，其中唯一的返回值是受影响的记录个数
                    mySqlTransaction.Commit();
                    return 1;
                }
                catch
                {
                    mySqlTransaction.Rollback();
                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion


        #region 查询，返回第一行第一列
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列，其他所有的行和列被忽略
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static int GetScalar(string safeSql)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(safeSql, connection);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        #endregion


        #region 返回MySqlDataReader对象
        /// <summary>
        /// 返回MySqlDataReader对象
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static MySqlDataReader GetReader(string safeSql)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(safeSql, connection);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static MySqlDataReader GetReader(string sql, params MySqlParameter[] values)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region 返回DataTable 对象
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(string safeSql)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(safeSql, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

        public static DataTable GetDataSet(string sql, params MySqlParameter[] values)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
        #endregion
    }
}
