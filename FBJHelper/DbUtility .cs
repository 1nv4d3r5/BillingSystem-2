using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Data;
using System.Web;
using System.Collections.ObjectModel;

namespace FBJHelper
{
    /// <summary>
    /// 通用数据库访问类，封装了对数据库的常见操作 
    /// </summary>
    public sealed class DbUtility
    {
        public String ConnectionString { get; set; }
        private DbProviderFactory providerFactory;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="providerType">数据库类型枚举，参见<paramref name="providerType"/></param>
        //public DbUtility(string connectionString, DbProviderType providerType)
        public DbUtility(string connectionString, DbProviderType providerType)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load("D:\\BillingSystem\\BillingSystem\\Web.config");
            //XmlNode node = doc.SelectSingleNode("configuration/connectionStrings");
            //string str = node.InnerText;

            this.ConnectionString = connectionString;
            this.providerFactory = ProviderFactory.GetProviderFactory(providerType);
            if (providerFactory == null)
            {
                throw new ArgumentException("Can't load DbProviderFactory for given value of providerType");
            }
        }

        public DbUtility(string con)
        {
            this.ConnectionString = con;
        }

        public static string GetConfig(string key)
        {
            string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                val = ConfigurationManager.AppSettings[key];
            }
            return val;
        }

        /// <summary>
        /// 创建一个DbCommand对象 
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        private DbCommand CreateDbCommand(string sql, List<DbParameter> parameters, CommandType commandType)
        {
            DbConnection connection = providerFactory.CreateConnection();
            DbCommand command = providerFactory.CreateCommand();
            connection.ConnectionString = ConnectionString;
            command.CommandText = sql;
            command.CommandType = commandType;
            command.Connection = connection;
            if (!(parameters == null || parameters.Count == 0))
            {
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }


        public DbParameter CreateDbParameter(string name, ParameterDirection parameterDirection, object value)
        {
            DbParameter parameter = providerFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = parameterDirection;
            return parameter;
        }

        public DbParameter CreateDbParameter(string name, object value)
        {
            return CreateDbParameter(name, ParameterDirection.Input, value);
        }

        /// <summary>      
        /// 对数据库执行增删改操作，返回受影响的行数。      
        /// </summary>      
        /// <param name="sql">要执行的增删改的SQL语句</param>      
        /// <param name="parameters">执行增删改语句所需要的参数</param>   
        /// <returns></returns>     
        public int ExecuteNonQuery(string sql, List<DbParameter> parameters)
        {
            return ExecuteNonQuery(sql, parameters, CommandType.Text);
        }

        /// <summary>
        /// 对数据库执行增删改操作，返回受影响的行数
        /// </summary>
        /// <param name="sql">要执行的增删改的SQL语句</param>
        /// <param name="parameters">执行增删改语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, List<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                command.Connection.Close();
                return affectedRows;
            }
        }

        /// <summary>
        /// 执行一个查询语句，返回一个关联的DataReader实例 
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string sql, List<DbParameter> parameters)
        {
            return ExecuteReader(sql, parameters, CommandType.Text);
        }

        /// <summary>      
        /// 执行一个查询语句，返回一个关联的DataReader实例      
        /// </summary>      
        /// <param name="sql">要执行的查询语句</param>      
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <param name="commandType">执行的SQL语句的类型</param>   
        /// <returns></returns>    
        public DbDataReader ExecuteReader(string sql, List<DbParameter> parameters, CommandType commandType)
        {
            DbCommand command = CreateDbCommand(sql, parameters, commandType);
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行一个查询语句，返回一个包含查询结果的DataTable
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, List<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                using (DbDataAdapter adapter = providerFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }

        /// <summary>
        /// 执行一个查询语句，返回一个包含查询结果的DataTable
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, List<DbParameter> parameters)
        {
            return ExecuteDataTable(sql, parameters, CommandType.Text);
        }

        /// <summary>
        /// 执行一个查询语句，返回查询结果的第一行第一列
        /// </summary>
        /// <param name="sql">要执行的查询语句</param>
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<DbParameter> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(sql, parameters, commandType))
            {
                command.Connection.Open();
                object result = command.ExecuteScalar();
                command.Connection.Close();
                return result;
            }
        }

        /// <summary>      
        /// 执行一个查询语句，返回查询结果的第一行第一列      
        /// </summary>      
        /// <param name="sql">要执行的查询语句</param>      
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>      
        /// <returns></returns>  
        public object ExecuteScalar(string sql, List<DbParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, CommandType.Text);
        }

        /// <summary>   
        ///  查询多个实体集合   
        /// </summary>   
        /// <typeparam name="T">返回的实体集合类型</typeparam>   
        /// <param name="sql">要执行的查询语句</param>      
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>      
        /// <param name="commandType">执行的SQL语句的类型</param>   
        /// <returns></returns>  
        public List<T> QueryForList<T>(string sql, List<DbParameter> parameters, CommandType commandType) where T : new()
        {
            DataTable data = ExecuteDataTable(sql, parameters, commandType);
            return EntityReader.GetEntities<T>(data);
        }

        public void Get<T>(string sql, List<DbParameter> parameters, CommandType commandType) where T : new()
        {
            DataTable data = ExecuteDataTable(sql,parameters,commandType);
        }

        /// 查询多个实体集合   
        /// </summary>   
        /// <typeparam name="T">返回的实体集合类型</typeparam>   
        /// <param name="sql">要执行的查询语句</param>      
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <returns></returns>  
        public List<T> QueryForList<T>(string sql, List<DbParameter> parameters) where T : new()
        {
            return QueryForList<T>(sql, parameters, CommandType.Text);
        }

        /// <summary>   
        /// 查询单个实体   
        /// </summary>   
        /// <typeparam name="T">返回的实体集合类型</typeparam>   
        /// <param name="sql">要执行的查询语句</param>      
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <returns></returns>   
        public T QueryForObject<T>(string sql, List<DbParameter> parameters) where T : new()
        {
            return QueryForObject<T>(sql, parameters, CommandType.Text);
        }

        /// <summary>   
        /// 查询单个实体   
        /// </summary>   
        /// <typeparam name="T">返回的实体集合类型</typeparam>   
        /// <param name="sql">要执行的查询语句</param>      
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>      
        /// <param name="commandType">执行的SQL语句的类型</param>   
        /// <returns></returns>   
        public T QueryForObject<T>(string sql, List<DbParameter> parameters, CommandType commandType) where T : new()
        {
            List<T> list = QueryForList<T>(sql, parameters, commandType);
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
