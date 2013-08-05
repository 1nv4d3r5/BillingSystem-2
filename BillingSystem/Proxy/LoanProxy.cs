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
        public static BorrowORLoanInfo GetLoanById(int id)
        {
            return LoanDAL.GetLoanById(id);
        }

        public static BorrowORLoanCollection GetLoanList(List<QueryElement> list)
        {
            return LoanDAL.GetLoanList(list);
        }

        public static int InsertOrUpdatetoLoan(BorrowORLoanInfo info)
        {
            int iSuccess = 0;
            int uSuccess = 0;
            BorrowORLoanInfo loanInfo = new BorrowORLoanInfo();
            UserInfo userInfo = UserDAL.GetUserByName(info.Lender);
            CardInfo cardInfo = CardDAL.GetCardByCardNumber(info.LoanAccount, userInfo.Id);
            if (info.Id > 0)
            {
                loanInfo = LoanDAL.GetLoanById(info.Id);
            }
            LoanDAL.InsertOrUpdatetoLoan(info, out iSuccess);
            if (iSuccess > 0 && info.BorrowORLoanType == 2)
            {
                float amount = 0;
                float loanAmount = 0;
                if (info.Id > 0)
                {
                    amount = cardInfo.Amount + (info.Amount - loanInfo.Amount);
                    loanAmount = cardInfo.Amount + (info.Amount - loanInfo.Amount);
                }
                else
                {
                    amount = cardInfo.Amount + info.Amount;
                    loanAmount = cardInfo.Amount + info.Amount;
                }
                CardDAL.UpdateCardAmount(amount, loanAmount, cardInfo.Id, 4, out uSuccess);
            }

            if ((iSuccess > 0 && info.Id > 0) && ((info.BorrowORLoanType == 2 && uSuccess > 0) || (info.BorrowORLoanType != 2 && uSuccess == 0)))
            {
                return 2;
            }
            else if ((iSuccess > 0 && info.Id == 0) && ((info.BorrowORLoanType == 2 && uSuccess > 0) || (info.BorrowORLoanType != 2 && uSuccess == 0)))
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

            BorrowORLoanInfo loanInfo = LoanDAL.GetLoanById(id);
            UserInfo userInfo = UserDAL.GetUserByName(loanInfo.Lender);
           
            LoanDAL.DeleteLoanById(id,out iSuccess);

            if (iSuccess > 0)
            {
                if (loanInfo.BorrowORLoanType == 2)
                {
                    CardInfo cardInfo = CardDAL.GetCardByCardNumber(loanInfo.Lender,userInfo.Id);
                    float amount = cardInfo.Amount - loanInfo.Amount;
                    float LoanAmount = cardInfo.LoanAmount - loanInfo.Amount;
                    CardDAL.UpdateCardAmount(amount,LoanAmount,cardInfo.Id,4,out uSuccess);
                }
            }
            if (iSuccess > 0 && ((loanInfo.BorrowORLoanType == 2 && uSuccess > 0) || (loanInfo.BorrowORLoanType != 2 && uSuccess == 0)))
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