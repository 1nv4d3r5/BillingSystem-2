using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Proxy;
using BillingSystem.Models;

namespace BillingSystem.Services
{
    public static class CashIncomeMethods
    {
        public static CashIncomeInfo GetCashIncomeById(int id)
        {
            return CashIncomeProxy.GetCashIncomeById(id);
        }

        public static CashIncomeCollection GetCashIncome(List<QueryElement> list)
        {
            return CashIncomeProxy.GetCashIncome(list);
        }

        public static int InsertOrUpdatetocashincome(CashIncomeInfo info)
        {
            return CashIncomeProxy.InsertOrUpdatetocashincome(info);
        }

        public static int DeleteCashIncome(int id)
        {
            return CashIncomeProxy.DeleteCashIncome(id);
        }
    }
}