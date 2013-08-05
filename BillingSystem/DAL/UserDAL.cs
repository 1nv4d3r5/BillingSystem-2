using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FBJHelper;
using BillingSystem.Models;
using System.Data.Common;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Text;
using System.Data;


namespace BillingSystem.DAL
{
    public static class UserDAL
    {
        /// <summary>
        /// 根据Code查询用户
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static UserInfo GetUserByCode(string code)
        {
            UserInfo userInfo = new UserInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from user where Code =@Code");
            MySqlParameter par = new MySqlParameter("@Code", MySqlDbType.String);
            par.Value = code;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    //coll.Add(new UserInfo(reader));
                    userInfo = new UserInfo(reader);
                }
            }
            return userInfo;
        }

        public static UserInfo GetUserByName(string name)
        {
            UserInfo userInfo = new UserInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from user where name =@name");
            MySqlParameter par = new MySqlParameter("@name", MySqlDbType.String);
            par.Value = name;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    //coll.Add(new UserInfo(reader));
                    userInfo = new UserInfo(reader);
                }
            }
            return userInfo;
        }

        public static UserInfo GetUserById(int id)
        {
            UserInfo userInfo = new UserInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from user where Id = @Id ");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int16);
            par.Value = id;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    userInfo = new UserInfo(reader);
                }
            }
            return userInfo;
        }

        /// <summary>
        /// 根据动态参数查询用户
        /// </summary>
        /// <param name="strFields"></param>
        /// <param name="strValues"></param>
        /// <returns></returns>
        public static UserCollection GetUser(List<QueryElement> list)
        {
            StringBuilder sb = new StringBuilder();
            UserCollection coll = new UserCollection();
            sb.AppendFormat("{0} ","select * from user where 1=1");
            if (list.Count > 0)
            {
                MySqlParameter[] pars = new MySqlParameter[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    QueryElement query = list[i];

                    sb.AppendFormat("{0} {1} {2} @{3} ", query.QueryLogic, query.Queryname, query.QueryOperation, query.Queryname);
                    pars[i] = new MySqlParameter("@" + query.Queryname, query.QueryElementType);
                    if (query.QueryOperation.Equals("like"))
                    {
                        pars[i].Value = "%" + query.Queryvalue + "%";
                    }
                    else
                    {
                        pars[i].Value = query.Queryvalue;
                    }
                }
                using(MySqlDataReader reader=MySqlDBHelper.GetReader(sb.ToString(),pars))
                {
                    while(reader.Read())
                    {
                        coll.Add(new UserInfo(reader));
                    }
                }
            }
            else
            {
                using(MySqlDataReader reader=MySqlDBHelper.GetReader(sb.ToString()))
                {
                    while(reader.Read())
                    {
                        coll.Add(new UserInfo(reader));
                    }
                }
            }
            return coll;
        }

        #region  备份
        //public static UserCollection GetUser(string[] strFields, string[] strValues)
        //{
        //UserCollection coll = new UserCollection();
        //StringBuilder sb = new StringBuilder();
        //sb.Append("select * from user ");
        //if (strFields != null && strFields.Length > 0)
        //{
        //    MySqlParameter[] pars = new MySqlParameter[strFields.Length];
        //    for (int i = 0; i < strFields.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            sb.Append("where");
        //        }
        //        else
        //        {
        //            sb.Append("AND ");
        //        }
        //        sb.AppendFormat(" {0}=@{1}", strFields[i], strFields[i]);
        //        pars[i] = GetParType("@" + strFields[i]);
        //        int backvalue = SetValue(strFields[i]);
        //        if (backvalue == 1)
        //        {
        //            pars[i].Value = strValues[i];
        //        }
        //        else if (backvalue == 2)
        //        {
        //            pars[i].Value = Convert.ToInt32(strValues[i]);
        //        }
        //    }
        //    using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), pars))
        //    {
        //        while (reader.Read())
        //        {
        //            coll.Add(new UserInfo(reader));
        //        }
        //    }
        //}
        //else
        //{
        //    using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString()))
        //    {
        //        while (reader.Read())
        //        {
        //            coll.Add(new UserInfo(reader));
        //        }
        //    }
        //}
        //return coll;
        //}
        #endregion


        /*INSERT INTO table_name VALUES (value1,value2,value3,...);
         INSERT INTO table_name (column1,column2,column3,...)
        VALUES (value1,value2,value3,...);
        */
        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="mySqlTransaction"></param>
        /// <param name="info"></param>
        /// <param name="iSuccess"></param>
        public static void InsertOrUpdatetoUser(MySqlTransaction mySqlTransaction, UserInfo info, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            UserInfo userInfo = GetUserByCode(info.Code);
            if (userInfo.Id > 0)
            {
                sb.Append(" update user set Code = @Code,Name = @Name,Password=@Password,Role = @Role,Content = @Content where id = @id ");
                info.Id = userInfo.Id;
            }
            else
            {
                sb.Append(" insert into user (Code,Name,Password,EMail,Role,Content) Values (@Code,@Name,@Password,@EMail,@Role,@Content ) ");
            }
            MySqlParameter[] pars = new MySqlParameter[] 
            {
                new MySqlParameter("@id",MySqlDbType.Int32),
                new MySqlParameter("@Code",MySqlDbType.String),
                new MySqlParameter("@Name",MySqlDbType.String),
                new MySqlParameter("@Password",MySqlDbType.String),
                new MySqlParameter("@EMail",MySqlDbType.String),
                new MySqlParameter("@Role",MySqlDbType.Int32),
                new MySqlParameter("@Content",MySqlDbType.String)
            };
            pars[0].Value = info.Id;
            pars[1].Value = info.Code;
            pars[2].Value = info.Name;
            pars[3].Value = info.Password;
            pars[4].Value = info.EMail;
            pars[5].Value = info.Role;
            pars[6].Value = info.content;
            iSuccess = MySqlDBHelper.ExecuteCommand(mySqlTransaction, sb.ToString(), pars);
            if (info.Id > 0)
            {
                iSuccess = -1;
            }
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="mySqlTransaction"></param>
        /// <param name="id"></param>
        /// <param name="iSuccess"></param>
        public static void DeleteUser(MySqlTransaction mySqlTransaction, int id, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from user where id = @id ");
            MySqlParameter par = new MySqlParameter("@id", MySqlDbType.Int32);
            par.Value = id;
            iSuccess = MySqlDBHelper.ExecuteCommand(mySqlTransaction, sb.ToString(), par);
        }

        /// <summary>
        /// 根据参数名称设置MySqlParameter参数类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static MySqlParameter GetParType(string str)
        {
            if (str == "@Code" || str == "@Name" || str == "@Password" || str == "@EMail" || str == "@Content")
            {
                return new MySqlParameter(str, MySqlDbType.String);
            }
            else if (str == "@Role")
            {
                return new MySqlParameter(str, MySqlDbType.Int32);
            }
            else
            {
                return new MySqlParameter();
            }
        }


        /// <summary>
        /// 1:par[i].value是字符串类型，2:par[i].value是整型
        /// </summary>
        /// <param name="strfield"></param>
        /// <returns></returns>
        private static int SetValue(string strfield)
        {
            if (strfield == "Code" || strfield == "Name" || strfield == "Password" || strfield == "EMail" || strfield == "Content")
            {
                return 1;
            }
            else if (strfield == "Role")
            {
                return 2;
            }
            else
                return 0;
        }
    }
}