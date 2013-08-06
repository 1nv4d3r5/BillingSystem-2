using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Proxy;
using BillingSystem.Models;

namespace BillingSystem.Services
{
    public static class BorrowedMethods
    {
        public static BorrowORLoanInfo GetBorrowById(int id)
        {
            return BorrowProxy.GetBorrowById(id);
        }

        public static BorrowORLoanCollection GetBorrowList(List<QueryElement> list)
        {
            return BorrowProxy.GetBorrowList(list);
        }

        public static int InsertOrUpdatetoBorrowed(BorrowORLoanInfo info)
        {
            return BorrowProxy.InsertOrUpdatetoBorrowed(info);
        }

        public static int DeleteBorrowedById(int id)
        {
            return BorrowProxy.DeleteBorrowedById(id);
        }
    }
}