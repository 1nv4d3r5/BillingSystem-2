using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Proxy;

namespace BillingSystem.Services
{
    public static class FirstLoadMethods
    {
        public static int CreateTable()
        {
            return FirstLoadProxy.CreateTable();
        }
    }
}