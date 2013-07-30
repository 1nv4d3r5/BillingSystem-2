using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.DAL;
using BillingSystem.Models;

namespace BillingSystem.Proxy
{
    public static class LoanProxy
    {
        public static LoanInfo GetLoanById(int id)
        {
            return LoanDAL.GetLoanById(id);
        }

        public static LoanCollection GetLoanList(List<QueryElement> list)
        {
            return LoanDAL.GetLoanList(list);
        }

        public static int InsertOrUpdatetoLoan(LoanInfo info)
        {
            int iSuccess = 0;
            int uSuccess = 0;
            LoanInfo loanInfo = new LoanInfo();
            UserInfo userInfo = UserDAL.GetUserByName(info.Lender);
            CardInfo cardInfo = CardDAL.GetCardByCardNumber(info.LoanAccount, userInfo.Id);
            if (info.Id > 0)
            {
                loanInfo = LoanDAL.GetLoanById(info.Id);
            }
            LoanDAL.InsertOrUpdatetoLoan(info, out iSuccess);
            if (iSuccess > 0 && info.LoanType == 2)
            {
                float amount = 0;
                float loanAmount = 0;
                if (info.Id > 0)
                {
                    amount = cardInfo.Amount + (info.LoanAmount - loanInfo.LoanAmount);
                    loanAmount = cardInfo.LoanAmount + (info.LoanAmount - loanInfo.LoanAmount);
                }
                else
                {
                    amount = cardInfo.Amount + info.LoanAmount;
                    loanAmount = cardInfo.LoanAmount + info.LoanAmount;
                }
                CardDAL.UpdateCardAmount(amount, loanAmount, cardInfo.Id, 4, out uSuccess);
            }

            if ((iSuccess > 0 && info.Id > 0) && ((info.LoanType == 2 && uSuccess > 0) || (info.LoanType != 2 && uSuccess == 0)))
            {
                return 2;
            }
            else if ((iSuccess > 0 && info.Id == 0) && ((info.LoanType == 2 && uSuccess > 0) || (info.LoanType != 2 && uSuccess == 0)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int DeleteLoanById(int id)
        {
            int iSuccess = 0;
            int uSuccess = 0;

            LoanInfo loanInfo = LoanDAL.GetLoanById(id);
            UserInfo userInfo = UserDAL.GetUserByName(loanInfo.Lender);
           
            LoanDAL.DeleteLoanById(id,out iSuccess);

            if (iSuccess > 0)
            {
                if (loanInfo.LoanType == 2)
                {
                    CardInfo cardInfo = CardDAL.GetCardByCardNumber(loanInfo.Lender,userInfo.Id);
                    float amount = cardInfo.Amount - loanInfo.LoanAmount;
                    float LoanAmount = cardInfo.LoanAmount - loanInfo.LoanAmount;
                    CardDAL.UpdateCardAmount(amount,LoanAmount,cardInfo.Id,4,out uSuccess);
                }
            }
            if (iSuccess > 0 && ((loanInfo.LoanType == 2 && uSuccess > 0) || (loanInfo.LoanType != 2 && uSuccess == 0)))
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