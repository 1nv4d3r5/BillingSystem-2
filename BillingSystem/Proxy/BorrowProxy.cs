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
            UserInfo userInfo = UserDAL.GetUserByName(info.Borrower);
            CardInfo cardInfo = CardDAL.GetCardByCardNumber(info.BorrowedAccount, info.Id);
            float amount = 0;
            float borrowAmount = 0;
            if (info.Id > 0)
            {
                
            }
            return 0;
        }
    }
}