using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Proxy;
using BillingSystem.Models;

namespace BillingSystem.Services
{
    public static class UserMethods
    {
        public static UserInfo GetUserByCode(string code)
        {
            return UserProxy.GetUserByCode(code);
        }

        public static UserInfo GetUserByName(string name)
        {
            return UserProxy.GetUserByName(name);
        }

        public static UserCollection GetUser(List<QueryElement> list)
        {
            return UserProxy.GetUser(list);
        }

        public static UserInfo GetUserById(int id)
        {
            return UserProxy.GetUserById(id);
        }

        public static int DeleteUser(int id)
        {
            return UserProxy.DeleteUser(id);
        }

        public static int InsertOrUpdatetoUser(UserInfo info)
        {
            return UserProxy.InsertOrUpdatetoUser(info);
        }
    }
}