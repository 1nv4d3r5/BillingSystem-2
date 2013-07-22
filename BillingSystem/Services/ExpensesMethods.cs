using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.Proxy;

namespace BillingSystem.Services
{
    public static class ExpensesMethods
    {
        public static ExpensesInfo GetExpensesById(int id)
        {
            return ExpensesProxy.GetExpensesById(id);
        }

        public static int InsertOrUpdatetoExpenses(ExpensesInfo info)
        {
            return ExpensesProxy.InsertOrUpdatetoExpenses(info);
        }

        public static ExpensesCollection GetExpensesList(List<QueryElement> list)
        {
            return ExpensesProxy.GetExpensesList(list);
        }

        public static int DeleteExpenses(int id)
        {
            return ExpensesProxy.DeleteExpenses(id);
        }

        public static UserCollection GetOwnerByCardNumber(string cardnumber)
        {
            return ExpensesProxy.GetOwnerByCardNumber(cardnumber);
        }
    }
}