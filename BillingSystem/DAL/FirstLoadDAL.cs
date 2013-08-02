using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.IO;
using FBJHelper;

namespace BillingSystem.DAL
{
    public static class FirstLoadDAL
    {
        public static void CreateTable()
        {

            string sqlFile = AppDomain.CurrentDomain.BaseDirectory + @"/DAL/ds1.sql";
            StreamReader reader = new StreamReader(sqlFile);
            StringBuilder sql = new StringBuilder();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine(); //读取每行数据
                if (line.StartsWith("--"))
                    continue;
                Console.WriteLine(line);
                sql.Append(line);
            }
            reader.Close();

            MySqlDBHelper.ExecuteCommand(sql.ToString());
        }

    }
}