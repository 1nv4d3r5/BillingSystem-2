using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data;
using System.Data;

namespace FBJHelper
{
   public class ProviderFactory
    {
       private static Dictionary<DbProviderType, string> providerInvariantNames = new Dictionary<DbProviderType, string>();
       private static Dictionary<DbProviderType, DbProviderFactory> providerFactoies = new Dictionary<DbProviderType, DbProviderFactory>();

       static ProviderFactory()
       {
           /*加载已知的数据库访问类的程序集 */
           providerInvariantNames.Add(DbProviderType.SqlServer,"System.Data.SqlClient");
           providerInvariantNames.Add(DbProviderType.OleDb, "System.Data.OleDb");
           providerInvariantNames.Add(DbProviderType.ODBC, "System.Data.Odbc");
           providerInvariantNames.Add(DbProviderType.Oracle, "Oracle.DataAccess.Client");
           providerInvariantNames.Add(DbProviderType.MySql,"MySql.Data.MySqlClient");
           providerInvariantNames.Add(DbProviderType.SQLite, "System.Data.SQLite");
       }

       /// <summary>
       /// 获取指定数据库类型对应的程序集名称 
       /// </summary>
       /// <param name="providerType">数据库类型枚举</param>
       /// <returns></returns>
       public static string GetPorviderInvariantName(DbProviderType providerType)
       {
           return providerInvariantNames[providerType];
       }

       /// <summary>
       /// 获取指定类型的数据库对应的DbProviderFactory
       /// </summary>
       /// <param name="providerType">数据库类型枚举</param>
       /// <returns></returns>
       public static DbProviderFactory GetProviderFactory(DbProviderType providerType)
       {
           if (!providerFactoies.ContainsKey(providerType))
           {
               providerFactoies.Add(providerType,ImportDbProviderFactory(providerType));  

           }
           return providerFactoies[providerType];
       }

       /// <summary>
       /// 加载指定数据库类型的DbProviderFactory 
       /// </summary>
       /// <param name="providerType">数据库类型枚举</param>
       /// <returns></returns>
       private static DbProviderFactory ImportDbProviderFactory(DbProviderType providerType)
       {
           string providerName = providerInvariantNames[providerType];
           DbProviderFactory factory = null;
           try
           {
               //从全局程序集中查找  
               factory = DbProviderFactories.GetFactory(providerName);
           }
           catch(ArgumentException e)
           {
               factory = null;
           }
           return factory;
       }
    }
}
