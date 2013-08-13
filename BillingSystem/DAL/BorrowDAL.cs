using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using MySql.Data ;
using MySql.Data.MySqlClient;
using System.Text;
using FBJHelper;

namespace BillingSystem.DAL
{
    public static class BorrowDAL
    {
        public static BorrowORLoanInfo GetBorrowById(int id)
        {
            BorrowORLoanInfo borrowInfo = new BorrowORLoanInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from borrowing where id = @Id ");
            MySqlParameter par = new MySqlParameter("@Id",MySqlDbType.Int32);

            par.Value = id;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    borrowInfo = new BorrowORLoanInfo(reader);
                }
            }
            return borrowInfo;
        }

        public static BorrowORLoanCollection GetBorrowList(List<QueryElement> list)
        {
            BorrowORLoanCollection coll = new BorrowORLoanCollection();
            StringBuilder sb = new StringBuilder();

            sb.Append(" select * from borrowing where BorrowORLoan=1");
            if (list.Count > 0)
            {
                MySqlParameter[] pars = new MySqlParameter[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    QueryElement query = list[i];

                    if (query.QueryElementType == MySqlDbType.DateTime)
                    {
                        sb.AppendFormat(" {0} {1} {2} @{3} ", query.QueryLogic, query.Queryname, query.QueryOperation, query.Queryname + i);
                        pars[i] = new MySqlParameter("@" + query.Queryname + i, query.QueryElementType);
                    }
                    else
                    {
                        sb.AppendFormat(" {0} {1} {2} @{3} ", query.QueryLogic, query.Queryname, query.QueryOperation, query.Queryname);
                        pars[i] = new MySqlParameter("@" + query.Queryname, query.QueryElementType);
                    }
                    if (query.QueryOperation.Equals("like"))
                    {
                        pars[i].Value = "%" + query.Queryvalue + "%";
                    }
                    else
                    {
                        pars[i].Value = query.Queryvalue;
                    }
                }
                using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), pars))
                {
                    while (reader.Read())
                    {
                        coll.Add(new BorrowORLoanInfo(reader));
                    }
                }
            }
            else
            {
                using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString()))
                {
                    while (reader.Read())
                    {
                        coll.Add(new BorrowORLoanInfo(reader));
                    }
                }
            }
            return coll;
        }

        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="mySqlTransaction"></param>
        /// <param name="info"></param>
        /// <param name="iSuccess"></param>
        public static void InsertOrUpdatetoBorrowed(BorrowORLoanInfo info, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            if (info.Id > 0)
            {
                sb.Append(" update borrowing set BorrowORLoanType = @BorrowORLoanType,BorrowORLoanAccountId=@BorrowORLoanAccountId,BorrowedAccount = @BorrowedAccount,LoanAccount=@LoanAccount,");
                sb.Append("Lender = @Lender,Amount = @Amount,HappenedDate = @HappenedDate,ReturnDate = @ReturnDate,Content = @Content ");
                sb.Append(" where Id = @Id ");
            }
            else
            {
                sb.Append(" insert into borrowing (borrowORLoan,BorrowORLoanType,BorrowORLoanAccountId,BorrowedAccount,Borrower,LoanAccount,Lender,Amount,HappenedDate,ReturnDate,Content) ");
                sb.Append(" Values (@borrowORLoan,@BorrowORLoanType,@BorrowORLoanAccountId,@BorrowedAccount,@Borrower,@LoanAccount,@Lender,@Amount,@HappenedDate,@ReturnDate,@Content) ");
            }
            MySqlParameter[] pars = new MySqlParameter[] 
            {
                new MySqlParameter("@Id",MySqlDbType.Int32),
                new MySqlParameter("@borrowORLoan",MySqlDbType.Int32),
                new MySqlParameter("@BorrowORLoanType",MySqlDbType.Int32),
                new MySqlParameter("@BorrowORLoanAccountId",MySqlDbType.Int32),
                new MySqlParameter("@BorrowedAccount",MySqlDbType.String),
                new MySqlParameter("@Borrower",MySqlDbType.String),
                //new MySqlParameter("@LoanType",MySqlDbType.Int32),
                new MySqlParameter("@LoanAccount",MySqlDbType.String),
                new MySqlParameter("@Lender",MySqlDbType.String),
                new MySqlParameter("@Amount",MySqlDbType.Float),
                new MySqlParameter("@HappenedDate",MySqlDbType.DateTime),
                new MySqlParameter("@ReturnDate",MySqlDbType.DateTime),
                new MySqlParameter("@Content",MySqlDbType.String)

            };
            pars[0].Value = info.Id;
            pars[1].Value = 1;
            pars[2].Value = info.BorrowORLoanType;
            pars[3].Value = info.BorrowORLoanAccountId;
            pars[4].Value = info.BorrowedAccount;
            pars[5].Value = info.Borrower;
            //pars[4].Value = info.LoanType;
            pars[6].Value = info.LoanAccount;
            pars[7].Value = info.Lender;
            pars[8].Value = info.Amount;
            pars[9].Value = info.HappenedDate;
            pars[10].Value = info.ReturnDate;
            pars[11].Value = info.Content;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), pars);
        }

        public static void DeleteBorrowed(int id, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from borrowing where Id = @Id ");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int32);
            par.Value = id;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), par);
        }
    }
}