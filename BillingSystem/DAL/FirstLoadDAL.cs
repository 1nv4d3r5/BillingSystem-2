using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.IO;

namespace BillingSystem.DAL
{
    public static class FirstLoadDAL
    {
        public static void CreateTable()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" {0} ","create table tb1(");
            sb.AppendFormat(" {0} ", "id int(10) not null auto_increment,");
        }
    }
}