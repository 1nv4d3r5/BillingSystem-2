using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;

namespace BillingSystem.ViewModels
{
    public class BorrowORLoanViewInfo
    {
        public int Id
        {
            get;
            set;
        }

        public int BorrowORLoan
        {
            get;
            set;
        }

        public int BorrowORLoanType
        {
            get;
            set;
        }

        public int BorrowORLoanAccountId
        {
            get;
            set;
        }

        public string BorrowedAccount
        {
            get;
            set;
        }

        public string Borrower
        {
            get;
            set;
        }

        public string LoanAccount
        {
            get;
            set;
        }

        public string Lender
        {
            get;
            set;
        }

        public float Amount
        {
            get;
            set;
        }

        public String HappenedDate
        {
            get;
            set;
        }

        public String ReturnDate
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public List<DropItem> BorrowedAccountList
        {
            get;
            set;
        }
    }
}