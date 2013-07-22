using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using FBJHelper;

namespace BillingSystem.DAL
{
    public static class ExpensesDAL
    {
        public static ExpensesInfo GetExpensesById(int id)
        {
            ExpensesInfo expensesInfo = new ExpensesInfo();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" {0} ","select * from Expenses where id = @Id");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int32);
            par.Value = id;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(),par))
            {
                while (reader.Read())
                {
                    expensesInfo = new ExpensesInfo(reader);
                }
            }
            return expensesInfo;
        }

        public static ExpensesCollection GetExpensesList(List<QueryElement> list)
        {
            ExpensesCollection coll = new ExpensesCollection();
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" {0} ", "select * from expenses where 1=1");
            if (list.Count > 0)
            {
                MySqlParameter[] pars = new MySqlParameter[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    QueryElement query = list[i];

                    if (query.QueryElementType == MySqlDbType.DateTime)
                    {
                        sb.AppendFormat("{0} {1} {2} @{3} ", query.QueryLogic, query.Queryname, query.QueryOperation, query.Queryname + i);
                        pars[i] = new MySqlParameter("@" + query.Queryname + i, query.QueryElementType);
                    }
                    else
                    {
                        sb.AppendFormat("{0} {1} {2} @{3} ", query.QueryLogic, query.Queryname, query.QueryOperation, query.Queryname);
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
                        coll.Add(new ExpensesInfo(reader));
                    }
                }
            }
            else
            {
                using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString()))
                {
                    while (reader.Read())
                    {
                        coll.Add(new ExpensesInfo(reader));
                    }
                }
            }
            return coll;
        }

        public static void InsertOrUpdatetoExpenses(ExpensesInfo info, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            ExpensesInfo expenses = GetExpensesById(info.Id);
            if (expenses.Id > 0)
            {
                sb.Append(" update Expenses set OwnerId=@OwnerId,OwnerName=@OwnerName,SpendType=@SpendType,HowToUse=@HowToUse, ");
                sb.Append(" Price = @Price,Number = @Number,Amount=@Amount,SpendDate=@SpendDate,SpendMode=@SpendMode,ConsumerId=@ConsumerId,ConsumerName=@ConsumerName,Content=@Content");
                sb.Append(" where Id=@Id");
            }
            else
            {
                sb.Append(" insert into Expenses (OwnerId,OwnerName,CardId,CardNumber,BankCardNumber,SpendType,HowToUse,Price,Number,Amount,SpendDate,SpendMode,ConsumerId,ConsumerName,Content) ");
                sb.Append(" Values(@OwnerId,@OwnerName,@CardId,@CardNumber,@BankCardNumber, @SpendType,@HowToUse,@Price,@Number,@Amount,@SpendDate,@SpendMode,@ConsumerId,@ConsumerName,@Content)");
            }
            MySqlParameter[] pars = new MySqlParameter[] 
            {
                new MySqlParameter("@Id",MySqlDbType.Int32),
                new MySqlParameter("@OwnerId",MySqlDbType.Int32),
                new MySqlParameter("@OwnerName",MySqlDbType.String),
                new MySqlParameter("@CardId",MySqlDbType.Int32),
                new MySqlParameter("@CardNumber",MySqlDbType.String),
                new MySqlParameter("@BankCardNumber",MySqlDbType.String),
                new MySqlParameter("@SpendType",MySqlDbType.Int32),
                new MySqlParameter("@HowToUse",MySqlDbType.String),
                new MySqlParameter("@Price",MySqlDbType.Float),
                new MySqlParameter("@Number",MySqlDbType.Int32),
                new MySqlParameter("@Amount",MySqlDbType.Float),
                new MySqlParameter("@SpendDate",MySqlDbType.DateTime),
                new MySqlParameter("@SpendMode",MySqlDbType.Int32),
                new MySqlParameter("@ConsumerId",MySqlDbType.Int32),
                new MySqlParameter("@ConsumerName",MySqlDbType.String),
                new MySqlParameter("@Content",MySqlDbType.String)
            };
            pars[0].Value = info.Id;
            pars[1].Value = info.OwnerId;
            pars[2].Value = info.OwnerName;
            pars[3].Value = info.CardId;
            pars[4].Value = info.CardNumber;
            pars[5].Value = info.BankCardNumber;
            pars[6].Value = info.SpendType;
            pars[7].Value = info.HowToUse;
            pars[8].Value = info.Price;
            pars[9].Value = info.Number;
            pars[10].Value = info.Amount;
            pars[11].Value = info.SpendDate;
            pars[12].Value = info.SpendMode;
            pars[13].Value = info.ConsumerId;
            pars[14].Value = info.ConsumerName;
            pars[15].Value = info.ConsumerName;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), pars);
            if (expenses.Id > 0)
            {
                iSuccess = -1;
            }
        }

        public static void DeleteExpenses(int id, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from expenses where Id = @Id ");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int32);
            par.Value = id;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), par);
        }

        public static UserCollection GetOwnerByCardNumber(string cardNumber)
        {
            UserCollection userColl = new UserCollection();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" {0} ", "SELECT user.* FROM user,card WHERE user.Id=card.OwnerId and CardNumber=@CardNumber");
            MySqlParameter par = new MySqlParameter("@CardNumber", MySqlDbType.String);
            par.Value = cardNumber;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    userColl.Add(new UserInfo(reader));
                }
            }
            return userColl;
        }
    }
}