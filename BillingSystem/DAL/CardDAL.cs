using BillingSystem.Models;
using FBJHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BillingSystem;

namespace BillingSystem.DAL
{
    public static class CardDAL
    {
        /// <summary>
        /// 根据Code查询用户
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static CardInfo GetCardByCardNumber(string cardNumber, int ownerId)
        {
            CardInfo cardInfo = new CardInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select card.*,a.name as ownerName,b.name as userName from card left join user a on card.ownerId=a.id left join user b on card.userId = b.id where CardNumber = @CardNumber and card.UserId=@UserId");
            MySqlParameter[] par = new MySqlParameter[]
            {
                new MySqlParameter( "@CardNumber", MySqlDbType.String),
                new MySqlParameter("@UserId",MySqlDbType.Int32)
            };
            par[0].Value = cardNumber;
            par[1].Value = ownerId;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    cardInfo = new CardInfo(reader);
                }
            }
            return cardInfo;
        }

        public static CardCollection GetCardByUserId(int userId)
        {
            CardCollection coll = new CardCollection();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select card.*,a.name as ownerName,b.name as userName from card left join user a on card.ownerId=a.id left join user b on card.userId = b.id where card.UserId=@UserId ");
            MySqlParameter par = new MySqlParameter("@UserId", MySqlDbType.Int32);
            par.Value = userId;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    coll .Add(new CardInfo(reader));
                }
            }
            return coll;
        }

        public static CardInfo GetCardById(int id)
        {
            CardInfo cardInfo = new CardInfo();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" {0} ", "select card.*,a.name as ownerName,b.name as userName from card left join user a on card.ownerId=a.id left join user b on card.userId = b.id where card.id =@Id");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int32);
            par.Value = id;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    cardInfo = new CardInfo(reader);
                }
            }
            return cardInfo;
        }

        /// <summary>
        /// 动态条件查询卡号
        /// </summary>
        /// <param name="strFields">条件字段</param>
        /// <param name="strValues">条件值</param>
        /// <returns></returns>
        public static CardCollection GetCard(List<QueryElement> list)
        {
            CardCollection coll = new CardCollection();
            StringBuilder sb = new StringBuilder();

            sb.Append(" select card.*,a.name as ownerName,b.name as userName from card left join user a on card.ownerId=a.id left join user b on card.userId = b.id where 1=1 ");
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
                        coll.Add(new CardInfo(reader));
                    }
                }
            }
            else
            {
                using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString()))
                {
                    while (reader.Read())
                    {
                        coll.Add(new CardInfo(reader));
                    }
                }
            }
            return coll;
        }

        public static void UpdateCardAmount(float amount, float updateAmount, int id, int type, out int uSuccess)
        {
            StringBuilder sb = new StringBuilder();
            MySqlParameter[] pars = new MySqlParameter[3];
            pars[0] = new MySqlParameter("@Id", MySqlDbType.Int32);
            pars[1] = new MySqlParameter("@Amount", MySqlDbType.Float);
            if (type == 1)
            {
                sb.AppendFormat(" {0} ", "update card set Amount=@Amount,IncomeAmount=@IncomeAmount where Id=@Id");
                pars[2] = new MySqlParameter("@IncomeAmount", MySqlDbType.Float);

            }
            else if (type == 2)
            {
                sb.AppendFormat(" {0} ", "update card set Amount=@Amount,ExpenditureAmount=@ExpenditureAmount where Id=@Id");
                pars[2] = new MySqlParameter("@ExpenditureAmount", MySqlDbType.Float);
            }
            else if (type == 3)
            {
                sb.AppendFormat(" {0} ", "update card set Amount=@Amount,BorrowAmount=@BorrowAmount where Id=@Id");
                pars[2] = new MySqlParameter("@BorrowAmount", MySqlDbType.Float);
            }
            else if (type == 4)
            {
                sb.AppendFormat(" {0} ", "update card set Amount=@Amount,LoanAmount=@LoanAmount where Id=@Id");
                pars[2] = new MySqlParameter("@LoanAmount", MySqlDbType.Float);
            }
            pars[0].Value = id;
            pars[1].Value = amount;
            pars[2].Value = updateAmount;
            uSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), pars);
        }



        /// <summary>
        /// 新增或修改
        /// </summary>
        /// <param name="mySqlTransaction"></param>
        /// <param name="info"></param>
        /// <param name="iSuccess"></param>
        public static void InsertOrUpdatetoCard(MySqlTransaction mySqlTransaction, CardInfo info, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            CardInfo cardInfo = GetCardByCardNumber(info.CardNumber, info.UserId);
            if (cardInfo.Id > 0)
            {
                sb.Append(" update card set BankId = @BankId,CardNumber = @CardNumber,AccountType = @AccountType,Amount=@Amount,");
                sb.Append("ExpenditureAmount = @ExpenditureAmount,BorrowAmount = @BorrowAmount,LoanAmount = @LoanAmount,IncomeAmount = @IncomeAmount,");
                sb.Append("OwnerId = @OwnerId,OwnerCode = @OwnerCode,UserId = @UserId,UserCode = @UserCode,BankName = @BankName,OpenDate = @OpenDate,Content=@Content ");
                sb.Append(" where Id = @Id");
                info.Id = cardInfo.Id;
                info.Amount = cardInfo.Amount;
                info.ExpenditureAmount = cardInfo.ExpenditureAmount;
                info.BorrowAmount = cardInfo.BorrowAmount;
                info.IncomeAmount = cardInfo.IncomeAmount;
            }
            else
            {
                sb.Append(" insert into card (BankId,CardNumber,AccountType,Amount,ExpenditureAmount,BorrowAmount,LoanAmount,IncomeAmount,OwnerId,OwnerCode,UserId,UserCode,BankName,OpenDate,Content) ");
                sb.Append(" Values (@BankId,@CardNumber,@AccountType,@Amount,@ExpenditureAmount,@BorrowAmount,@LoanAmount,@IncomeAmount,@OwnerId,@OwnerCode,@UserId,@UserCode,@BankName,@OpenDate,@Content)");
            }
            MySqlParameter[] pars = new MySqlParameter[] 
            {
                new MySqlParameter("@id",MySqlDbType.Int32),
                new MySqlParameter("@BankId",MySqlDbType.Int32),
                new MySqlParameter("@CardNumber",MySqlDbType.String),
                new MySqlParameter("@AccountType",MySqlDbType.Int32),
                new MySqlParameter("@Amount",MySqlDbType.Float),
                new MySqlParameter("@ExpenditureAmount",MySqlDbType.Float),
                new MySqlParameter("@BorrowAmount",MySqlDbType.Float),
                new MySqlParameter("@LoanAmount",MySqlDbType.Float),
                new MySqlParameter("@IncomeAmount",MySqlDbType.Float),
                new MySqlParameter("@OwnerId",MySqlDbType.Int32),
                new MySqlParameter("@OwnerCode",MySqlDbType.String),
                new MySqlParameter("@UserId",MySqlDbType.Int32),
                new MySqlParameter("@UserCode",MySqlDbType.String),
                new MySqlParameter("@BankName",MySqlDbType.String),
                new MySqlParameter("@OpenDate",MySqlDbType.DateTime),
                new MySqlParameter("@Content",MySqlDbType.String),

            };
            pars[0].Value = info.Id;
            pars[1].Value = info.BankId;
            pars[2].Value = info.CardNumber;
            pars[3].Value = info.AccountType;
            pars[4].Value = info.Amount;
            pars[5].Value = info.ExpenditureAmount;
            pars[6].Value = info.BorrowAmount;
            pars[7].Value = info.LoanAmount;
            pars[8].Value = info.IncomeAmount;
            pars[9].Value = info.OwnerId;
            pars[10].Value = info.OwnerCode;
            pars[11].Value = info.UserId;
            pars[12].Value = info.UserCode;
            pars[13].Value = info.BankName;
            pars[14].Value = info.OpenDate;
            pars[15].Value = info.Content;
            iSuccess = MySqlDBHelper.ExecuteCommand(mySqlTransaction, sb.ToString(), pars);
            if (cardInfo.Id > 0)
            {
                iSuccess = -1;
            }
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="mySqlTransaction"></param>
        /// <param name="id"></param>
        /// <param name="iSuccess"></param>
        public static void DeleteCard( int id, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from card where id = @id ");
            MySqlParameter par = new MySqlParameter("@id", MySqlDbType.Int32);
            par.Value = id;
            iSuccess = MySqlDBHelper.ExecuteCommand( sb.ToString(), par);
        }




        /// <summary>
        /// 根据参数名称设置MySqlParameter参数类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static MySqlParameter GetParType(string str)
        {
            if (str == "CardNumber")
            {
                return new MySqlParameter("@'" + str + "'", MySqlDbType.String);
            }
            else if (str == "UserId" || str == "BankId")
            {
                return new MySqlParameter("@'" + str + "'", MySqlDbType.Int32);
            }
            else
            {
                return new MySqlParameter();
            }
        }


        /// <summary>
        /// 1:par[i].value是字符串类型，2:par[i].value是整型
        /// </summary>
        /// <param name="strfield"></param>
        /// <returns></returns>
        private static int SetValue(string strfield)
        {
            if (strfield == "Code" || strfield == "CardNumber")
            {
                return 1;
            }
            else if (strfield == "UserId")
            {
                return 2;
            }
            else
                return 0;
        }

    }
}