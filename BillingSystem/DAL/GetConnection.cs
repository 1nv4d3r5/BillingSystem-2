using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using FBJHelper;

namespace BillingSystem.DAL
{
    public class GetConnection
    {
        //public static string connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
        public static string connectionString = "Server=localhost;Port=3306;DataBase=accountingds;Persist Security Info=False;User ID=root;Password=;Allow Zero Datetime=true";
        public DbUtility dbu { get; set; }
        public GetConnection()
        {
            DbUtility du = new DbUtility(connectionString, DbProviderType.MySql);
            this.dbu = du;
        }
    }
}