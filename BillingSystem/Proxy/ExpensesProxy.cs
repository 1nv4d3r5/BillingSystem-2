using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.DAL;

namespace BillingSystem.Proxy
{
    public static class ExpensesProxy
    {
        public static ExpensesInfo GetExpensesById(int id)
        {
            return ExpensesDAL.GetExpensesById(id);
        }

        public static int InsertOrUpdatetoExpenses(ExpensesInfo info)
        {
            int iSuccess = 0;
            int uSuccess = 0;
            ExpensesInfo expenses = new ExpensesInfo();
            if (info.Id > 0)
            {
                expenses = ExpensesDAL.GetExpensesById(info.Id);
            }
            ExpensesDAL.InsertOrUpdatetoExpenses(info, out iSuccess);

            if (iSuccess > 0 || iSuccess == -1)
            {
                CardInfo cardInfo = CardDAL.GetCardById(info.CardId);
                float amount = 0;
                float expenditureAmount = 0;
                if (info.Id > 0)
                {
                    amount = cardInfo.Amount - (info.Amount - expenses.Amount);
                    expenditureAmount = cardInfo.ExpenditureAmount + (info.Amount - expenses.Amount);
                }
                else
                {
                    amount = cardInfo.Amount + info.Amount;
                    expenditureAmount = cardInfo.ExpenditureAmount + info.Amount;
                }
                CardDAL.UpdateCardAmount(amount, expenditureAmount, info.CardId, 2, out uSuccess);
            }

            if (iSuccess > 0 && uSuccess > 0)
            {
                return 1;
            }
            else if (iSuccess == -1 && uSuccess > 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static ExpensesCollection GetExpensesList(List<QueryElement> list)
        {
            return ExpensesDAL.GetExpensesList(list);
        }

        public static int DeleteExpenses(int id)
        {
            int iSuccess = 0;
            int uSuccess = 0;

            ExpensesInfo expenses = ExpensesDAL.GetExpensesById(id);
            CardInfo cardInfo = CardDAL.GetCardById(expenses.CardId);
            ExpensesDAL.DeleteExpenses(id, out iSuccess);
            if (iSuccess > 0)
            {
                float amount = cardInfo.Amount + expenses.Amount;
                float expenditureAmount = cardInfo.ExpenditureAmount - expenses.Amount;
                CardDAL.UpdateCardAmount(amount, expenditureAmount, expenses.CardId, 2, out uSuccess);
            }

            if (iSuccess > 0 && uSuccess > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static UserCollection GetOwnerByCardNumber(string cardnumber)
        {
            return ExpensesDAL.GetOwnerByCardNumber(cardnumber);
        }
    }
}