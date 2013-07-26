using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.DAL;
using BillingSystem.Models;

namespace BillingSystem.Proxy
{
    public static class BorrowProxy
    {
        public static BorrowInfo GetBorrowById(int id)
        {
            return BorrowDAL.GetBorrowById(id);
        }

        public static BorrowCollection GetBorrowList(List<QueryElement> list)
        {
            return BorrowDAL.GetBorrowList(list);
        }

        public static int InsertOrUpdatetoBorrowed(BorrowInfo info)
        {
            int iSuccess = 0;
            int uSuccess = 0;
            BorrowInfo borrowInfo = new BorrowInfo();
            UserInfo userInfo = UserDAL.GetUserByName(info.Borrower);
            CardInfo cardInfo = CardDAL.GetCardByCardNumber(info.BorrowedAccount, userInfo.Id);
            if (info.Id > 0)
            {
                borrowInfo = BorrowDAL.GetBorrowById(info.Id);
            }
            BorrowDAL.InsertOrUpdatetoBorrowed(info, out iSuccess);
            if (iSuccess > 0 && info.BorrowType == 2)
            {
                float amount = 0;
                float borrowAmount = 0;
                if (info.Id > 0)
                {
                    amount = cardInfo.Amount + (info.BorrowAmount - borrowInfo.BorrowAmount);
                    borrowAmount = cardInfo.BorrowAmount + (info.BorrowAmount - borrowInfo.BorrowAmount);
                }
                else
                {
                    amount = cardInfo.Amount + info.BorrowAmount;
                    borrowAmount = cardInfo.BorrowAmount + info.BorrowAmount;
                }
                CardDAL.UpdateCardAmount(amount, borrowAmount, cardInfo.Id, 3, out uSuccess);
            }

            if ((iSuccess > 0 && info.Id > 0) && ((info.BorrowType == 2 && uSuccess > 0) || (info.BorrowType != 2 && uSuccess == 0)))
            {
                return 2;
            }
            else if ((iSuccess > 0 && info.Id == 0) && ((info.BorrowType == 2 && uSuccess > 0) || (info.BorrowType != 2 && uSuccess == 0)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int DeleteBorrowedById(int id)
        {
            int iSuccess = 0;
            int uSuccess = 0;

            BorrowInfo borrowInfo = BorrowDAL.GetBorrowById(id);
            UserInfo userInfo = UserDAL.GetUserByName(borrowInfo.Borrower);
           
            BorrowDAL.DeleteBorrowed(id,out iSuccess);

            if (iSuccess > 0)
            {
                if (borrowInfo.BorrowType == 2)
                {
                    CardInfo cardInfo = CardDAL.GetCardByCardNumber(borrowInfo.BorrowedAccount,userInfo.Id);
                    float amount = cardInfo.Amount - borrowInfo.BorrowAmount;
                    float borrowAmount = cardInfo.BorrowAmount - borrowInfo.BorrowAmount;
                    CardDAL.UpdateCardAmount(amount,borrowAmount,cardInfo.Id,3,out uSuccess);
                }
            }
            if (iSuccess > 0 && ((borrowInfo.BorrowType == 2 && uSuccess > 0) || (borrowInfo.BorrowType != 2 && uSuccess == 0)))
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