﻿using System;
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
    public static class LoanDAL
    {
        public static LoanInfo GetLoanById(int id)
        {
            LoanInfo loanInfo = new LoanInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from Loan where id = @Id ");
            MySqlParameter par = new MySqlParameter("@Id",MySqlDbType.Int32);

            par.Value = id;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    loanInfo = new LoanInfo(reader);
                }
            }
            return loanInfo;
        }

        public static LoanCollection GetLoanList(List<QueryElement> list)
        {
            LoanCollection coll = new LoanCollection();
            StringBuilder sb = new StringBuilder();

            sb.Append(" select * from Loan where 1=1 ");
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
                        coll.Add(new LoanInfo(reader));
                    }
                }
            }
            else
            {
                using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString()))
                {
                    while (reader.Read())
                    {
                        coll.Add(new LoanInfo(reader));
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
        public static void InsertOrUpdatetoLoan(LoanInfo info, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            if (info.Id > 0)
            {
                sb.Append(" update Loan set LoanType = @LoanType,LoanAccount = @LoanAccount,BorrowType = @BorrowType,BorrowAccount=@BorrowAccount,");
                sb.Append("Borrower = @Borrower,LoanAmount = @LoanAmount,LoanDate = @LoanDate,ReturnDate = @ReturnDate,Content = @Content ");
                sb.Append(" where Id = @Id");
            }
            else
            {
                sb.Append(" insert into Loan (LoanType,LoanAccount,Lender,BorrowType,BorrowAccount,Borrower,LoanAmount,LoanDate,ReturnDate,Content) ");
                sb.Append(" Values (@LoanType,@LoanAccount,@Lender,@BorrowType,@BorrowAccount,@Borrower,@LoanAmount,@LoanDate,@ReturnDate,@Content) ");
            }
            MySqlParameter[] pars = new MySqlParameter[] 
            {
                new MySqlParameter("@Id",MySqlDbType.Int32),
                new MySqlParameter("@LoanType",MySqlDbType.Int32),
                new MySqlParameter("@LoanAccount",MySqlDbType.String),
                new MySqlParameter("@Lender",MySqlDbType.String),
                new MySqlParameter("@BorrowType",MySqlDbType.Int32),
                new MySqlParameter("@BorrowAccount",MySqlDbType.String),
                new MySqlParameter("@Borrower",MySqlDbType.String),
                new MySqlParameter("@LoanAmount",MySqlDbType.Float),
                new MySqlParameter("@LoanDate",MySqlDbType.DateTime),
                new MySqlParameter("@ReturnDate",MySqlDbType.DateTime),
                new MySqlParameter("@Content",MySqlDbType.String)

            };
            pars[0].Value = info.Id;
            pars[1].Value = info.LoanType;
            pars[2].Value = info.LoanAccount;
            pars[3].Value = info.Lender;
            pars[4].Value = info.BorrowType;
            pars[5].Value = info.BorrowAccount;
            pars[6].Value = info.Borrower;
            pars[7].Value = info.LoanAmount;
            pars[8].Value = info.LoanDate;
            pars[9].Value = info.ReturnDate;
            pars[10].Value = info.Content;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), pars);
        }

        public static void DeleteLoanById(int id, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from Loan where Id = @Id ");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int32);
            par.Value = id;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), par);
        }
    }
}