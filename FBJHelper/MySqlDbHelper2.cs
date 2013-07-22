using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBJHelper
{
   public class MySqlDbHelper2
    {
       private const string defaultConfigKeyName = "DbHelper";
       private string connectionString;
       private string providerName;

       public MySqlDbHelper2()
       {
           this.connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
           this.providerName = ConfigurationManager.ConnectionStrings["MySql"].ProviderName;
       }

       public MySqlDbHelper2(string keyName)
       {
           this.connectionString = ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
           this.providerName = ConfigurationManager.ConnectionStrings[keyName].ProviderName;
       }

       public int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
       {
           MySqlConnection con = new MySqlConnection(connectionString);
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sql,con);
           foreach (MySqlParameter parameter in parameters)
           {
               cmd.Parameters.Add(parameter);
           }
           int res = 0;
           try
           {
               res = cmd.ExecuteNonQuery();
           }
           catch (Exception e)
           {
               res = -1;
               throw e;
           }
           cmd.Dispose();
           con.Close();
           return res;
       }

       public object ExecuteScalar(string sql, params MySqlParameter[] parameters)
       {
           MySqlConnection con = new MySqlConnection(connectionString);
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sql, con);
           foreach (MySqlParameter parameter in parameters)
           {
               cmd.Parameters.Add(parameter);
           }

           object res = cmd.ExecuteScalar();
           cmd.Dispose();
           con.Close();
           return res;
       }

       public DataTable ExecuteDataTable(String sql, params MySqlParameter[] parameters)
       {
           MySqlConnection con = new MySqlConnection(connectionString);
           con.Open();
           MySqlCommand cmd = new MySqlCommand(sql,con);
           foreach (MySqlParameter parameter in parameters)
           {
               cmd.Parameters.Add(parameter);
           }
           DataSet dataset = new DataSet();
           MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
           adapter.Fill(dataset);
           cmd.Dispose();
           con.Close();
           return dataset.Tables[0];
       }

       /// <summary>   
       ///  查询多个实体集合   
       /// </summary>   
       /// <typeparam name="T">返回的实体集合类型</typeparam>   
       /// <param name="sql">要执行的查询语句</param>      
       /// <param name="parameters">执行SQL查询语句所需要的参数</param>      
       /// <param name="commandType">执行的SQL语句的类型</param>   
       /// <returns></returns>
       public List<T> QueryForList<T>(string sql, params MySqlParameter[] parameters) where T :new()
       {
           DataTable data = ExecuteDataTable(sql, parameters);
           return EntityReader.GetEntities<T>(data);
       }

       public void Get<T>(string sql, params MySqlParameter[] parameters) where T : class
       {
           DataTable data = ExecuteDataTable(sql, parameters);
       }

       /// <summary>   
       /// 查询单个实体   
       /// </summary>   
       /// <typeparam name="T">返回的实体集合类型</typeparam>   
       /// <param name="sql">要执行的查询语句</param>      
       /// <param name="parameters">执行SQL查询语句所需要的参数</param>      
       /// <param name="commandType">执行的SQL语句的类型</param>   
       /// <returns></returns>   
       public T QueryForObject<T>(string sql, params MySqlParameter[] parameters) where T : new()
       {
           List<T> list = QueryForList<T>(sql, parameters);
           if (list.Count > 0)
           {
               return list[0];
           }
           else
           {
               return default(T);
           }
       }
    }
}
