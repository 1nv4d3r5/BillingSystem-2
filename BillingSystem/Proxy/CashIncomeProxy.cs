using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.DAL;
using MySql.Data.MySqlClient;

namespace BillingSystem.Proxy
{
    public static class CashIncomeProxy
    {
        public static CashIncomeInfo GetCashIncomeById(int id)
        {
            return CashInComeDAL.GetCashIncomeById(id);
        }

        public static CashIncomeCollection GetCashIncome(List<QueryElement> list)
        {
            return CashInComeDAL.GetCashInCome(list);
        }

        public static int InsertOrUpdatetocashincome(CashIncomeInfo info)
        {
            int iSuccess = 0;
            int uSuccess = 0;
            CashIncomeInfo cashIncomeInfo = new CashIncomeInfo();
            if (info.Id > 0)
            {
                cashIncomeInfo = CashInComeDAL.GetCashIncomeById(info.Id);
            }
            CashInComeDAL.InsertOrUpdatetocashincome(info,out iSuccess);

            if (iSuccess > 0 || iSuccess==-1)
            {
                CardInfo cardInfo = CardDAL.GetCardById(info.CardId);
                float amount = 0;
                float incomeamount = 0;
                if (info.Id > 0)
                {
                    amount =cardInfo.Amount+(info.IncomeAmount - cashIncomeInfo.IncomeAmount);
                    incomeamount = cardInfo.IncomeAmount + (info.IncomeAmount - cashIncomeInfo.IncomeAmount);
                }
                else
                {
                    amount = cardInfo.Amount+ info.IncomeAmount;
                    incomeamount = cardInfo.IncomeAmount + info.IncomeAmount;
                }
                CardDAL.UpdateCardAmount(amount,incomeamount,info.CardId,1,out uSuccess);
            }

            if (iSuccess > 0 && uSuccess>0)
            {
                return 1;
            }
            else if (iSuccess == -1 && uSuccess>0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int DeleteCashIncome(int id)
        {
            int iSuccess = 0;
            int uSuccess = 0;

            CashIncomeInfo cashInfo = CashInComeDAL.GetCashIncomeById(id);
            CardInfo cardInfo = CardDAL.GetCardById(cashInfo.CardId);
            CashInComeDAL.DeleteCashIncome(id,out iSuccess);
            if (iSuccess > 0)
            {
                float amount = cardInfo.Amount - cashInfo.IncomeAmount;
                float incomeAmount = cardInfo.IncomeAmount - cashInfo.IncomeAmount;
                CardDAL.UpdateCardAmount(amount,incomeAmount,cashInfo.CardId,1,out uSuccess);
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
    }
}