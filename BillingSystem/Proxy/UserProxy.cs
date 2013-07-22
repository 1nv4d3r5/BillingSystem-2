using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.DAL;
using BillingSystem.Models;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Text;

namespace BillingSystem.Proxy
{
    public static class UserProxy
    {
        public static int InsertOrUpdatetoUser(UserInfo info)
        {
            int iSuccess = 0;
            MySqlTransaction mySqlTransaction = null;
            UserDAL.InsertOrUpdatetoUser(mySqlTransaction, info, out iSuccess);
            if (iSuccess > 0)
            {
                return 1;
            }
            else if (iSuccess == -1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static UserInfo CheckUser(string code)
        {
            return UserDAL.CheckUser(code);
        }

        public static UserInfo GetUserByName(string name)
        {
            return UserDAL.GetUserByName(name);
        }

        public static UserInfo GetUserById(int id)
        {
            return UserDAL.GetUserById(id);
        }

        public static UserCollection GetUser(List<QueryElement> list)
        {
            UserCollection coll = new UserCollection();
            coll = UserDAL.GetUser(list);
            return coll;
        }

        public static int DeleteUser(int id)
        {
            int iSuccess = 0;
            MySqlTransaction mySqlTransaction = null;
            UserDAL.DeleteUser(mySqlTransaction,id,out iSuccess);
            if (iSuccess > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}