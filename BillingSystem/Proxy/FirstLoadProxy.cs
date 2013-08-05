using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.DAL;
using BillingSystem.Models;

namespace BillingSystem.Proxy
{
    public static class FirstLoadProxy
    {
        public static int CreateTable()
        {
            return FirstLoadDAL.CreateTable();
        }
    }
}