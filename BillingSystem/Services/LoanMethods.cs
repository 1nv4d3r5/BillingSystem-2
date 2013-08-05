using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Proxy;
using BillingSystem.Models;

namespace BillingSystem.Services
{
    public static class LoanMethods
    {
        public static BorrowORLoanInfo GetBorrowById(int id)
        {
            return LoanProxy.GetLoanById(id);
        }

        public static BorrowORLoanCollection GetLoanList(List<QueryElement> list)
        {
            return LoanProxy.GetLoanList(list);
        }

        public static int InsertOrUpdatetoLoan(BorrowORLoanInfo info)
        {
            return LoanProxy.InsertOrUpdatetoLoan(info);
        }

        public static int DeleteLoanById(int id)
        {
            return LoanProxy.DeleteLoanById(id);
        }
    }
}