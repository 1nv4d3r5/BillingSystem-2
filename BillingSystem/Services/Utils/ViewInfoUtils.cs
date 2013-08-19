using BillingSystem.Models;
using BillingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem.Services.Utils
{
    public class ViewInfoUtils
    {
        private ViewInfoUtils() { }

        public static BorrowORLoanViewInfo BuildBorrowORLoanViewInfo(BorrowORLoanInfo info)
        {
            BorrowORLoanViewInfo viewInfo = new BorrowORLoanViewInfo();
            viewInfo.Id = info.Id;
            viewInfo.Lender = info.Lender;
            viewInfo.LoanAccount = info.LoanAccount;

            if (info.ReturnDate.CompareTo(new DateTime(2001, 1, 1)) > 0)
            {
                viewInfo.ReturnDate = info.ReturnDate.ToString("yyyy-MM-dd");
            }
            if (info.HappenedDate.CompareTo(new DateTime(2001, 1, 1)) > 0)
            {
                viewInfo.HappenedDate = info.HappenedDate.ToString("yyyy-MM-dd");
            }
            viewInfo.Status = info.Status;
            viewInfo.Amount = info.Amount;
            viewInfo.BorrowedAccount = info.BorrowedAccount;
            viewInfo.Borrower = info.Borrower;
            viewInfo.BorrowORLoan = info.BorrowORLoan;
            viewInfo.BorrowORLoanAccountId = info.BorrowORLoanAccountId;
            viewInfo.BorrowORLoanType = info.BorrowORLoanType;
            viewInfo.Content = info.Content;
            return viewInfo;
        }
    }
}