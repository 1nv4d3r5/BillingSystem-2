using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using FBJHelper;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BillingSystem.DAL
{
    public static class CashInComeDAL
    {
        public static CashIncomeInfo GetCashIncomeById(int id)
        {
            CashIncomeInfo cashIncomeInfo = new CashIncomeInfo();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from cashincome where Id=@Id");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int32);
            par.Value = id;
            using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString(), par))
            {
                while (reader.Read())
                {
                    cashIncomeInfo = new CashIncomeInfo(reader);
                }
            }
            return cashIncomeInfo;
        }

        public static CashIncomeCollection GetCashInCome(List<QueryElement> list)
        {
            CashIncomeCollection coll = new CashIncomeCollection();
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" {0} ", "select * from cashincome where 1=1");
            if (list.Count > 0)
            {
                MySqlParameter[] pars = new MySqlParameter[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    QueryElement query = list[i];

                    if (query.QueryElementType == MySqlDbType.DateTime)
                    {
                        sb.AppendFormat("{0} {1} {2} @{3} ", query.QueryLogic, query.Queryname, query.QueryOperation, query.Queryname+i);
                        pars[i] = new MySqlParameter("@" + query.Queryname+i, query.QueryElementType);
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
                        coll.Add(new CashIncomeInfo(reader));
                    }
                }
            }
            else
            {
                using (MySqlDataReader reader = MySqlDBHelper.GetReader(sb.ToString()))
                {
                    while (reader.Read())
                    {
                        coll.Add(new CashIncomeInfo(reader));
                    }
                }
            }
            return coll;
        }

        public static void InsertOrUpdatetocashincome(CashIncomeInfo info, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            CashIncomeInfo cashIncomeInfo = GetCashIncomeById(info.Id);
            if (cashIncomeInfo.Id > 0)
            {
                sb.Append(" update cashincome set OwnerId=@OwnerId,OwnerName=@OwnerName,IncomeAmount = @IncomeAmount,PreMode = @PreMode,Mode = @Mode,PreRate=@PreRate,Rate=@Rate, ");
                sb.Append(" DepositDate = @DepositDate,BDate = @BDate,EDate=@EDate,AutoSave=@AutoSave,DepositorId=@DepositorId,DepositorName=@DepositorName,DepositMode=@DepositMode,");
                sb.Append(" Status=@Status,IncomeType=@IncomeType,TAmount=@TAmount,Content=@Content where Id=@Id");
            }
            else
            {
                sb.Append(" insert into cashincome (OwnerId,OwnerName,CardId,CardNumber,BankCardNumber,IncomeAmount,PreMode,Mode,PreRate,Rate,DepositDate,BDate,EDate,AutoSave,DepositorId, ");
                sb.Append(" DepositorName,DepositMode,Status,IncomeType,TAmount,Content) ");
                sb.Append(" Values(@OwnerId,@OwnerName,@CardId,@CardNumber,@BankCardNumber, @IncomeAmount,@PreMode,@Mode,@PreRate,@Rate,@DepositDate,@BDate,@EDate,@AutoSave,@DepositorId,");
                sb.Append(" @DepositorName,@DepositMode,@Status,@IncomeType,@TAmount,@Content)");
            }
            MySqlParameter[] pars = new MySqlParameter[] 
            {
                new MySqlParameter("@Id",MySqlDbType.Int32),
                new MySqlParameter("@OwnerId",MySqlDbType.Int32),
                new MySqlParameter("@OwnerName",MySqlDbType.String),
                new MySqlParameter("@CardId",MySqlDbType.Int32),
                new MySqlParameter("@CardNumber",MySqlDbType.String),
                new MySqlParameter("@BankCardNumber",MySqlDbType.String),
                new MySqlParameter("@IncomeAmount",MySqlDbType.Float),
                new MySqlParameter("@PreMode",MySqlDbType.Int32),
                new MySqlParameter("@Mode",MySqlDbType.Int32),
                new MySqlParameter("@PreRate",MySqlDbType.Int32),
                new MySqlParameter("@Rate",MySqlDbType.Int32),
                new MySqlParameter("@DepositDate",MySqlDbType.DateTime),
                new MySqlParameter("@BDate",MySqlDbType.DateTime),
                new MySqlParameter("@EDate",MySqlDbType.DateTime),
                new MySqlParameter("@AutoSave",MySqlDbType.Int32),
                new MySqlParameter("@DepositorId",MySqlDbType.Int32),
                new MySqlParameter("@DepositorName",MySqlDbType.String),
                new MySqlParameter("@DepositMode",MySqlDbType.Int32),
                new MySqlParameter("@Status",MySqlDbType.Int32),
                new MySqlParameter("@IncomeType",MySqlDbType.Int32),
                new MySqlParameter("@TAmount",MySqlDbType.Float),
                new MySqlParameter("@Content",MySqlDbType.String)
            };
            pars[0].Value = info.Id;
            pars[1].Value = info.OwnerId;
            pars[2].Value = info.OwnerName;
            pars[3].Value = info.CardId;
            pars[4].Value = info.CardNumber;
            pars[5].Value = info.BankCardNumber;
            pars[6].Value = info.IncomeAmount;
            pars[7].Value = info.PreMode;
            pars[8].Value = info.Mode;
            pars[9].Value = info.PreRate;
            pars[10].Value = info.Rate;
            pars[11].Value = info.DepositDate;
            pars[12].Value = info.BDate;
            pars[13].Value = info.EDate;
            pars[14].Value = info.AutoSave;
            pars[15].Value = info.DepositorId;
            pars[16].Value = info.DepositorName;
            pars[17].Value = info.DepositMode;
            pars[18].Value = info.Status;
            pars[19].Value = info.IncomeType;
            pars[20].Value = info.TAmount;
            pars[21].Value = info.Content;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), pars);
            if (cashIncomeInfo.Id > 0)
            {
                iSuccess = -1;
            }
        }

        public static void DeleteCashIncome(int id, out int iSuccess)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" delete from cashincome where Id = @Id ");
            MySqlParameter par = new MySqlParameter("@Id", MySqlDbType.Int32);
            par.Value = id;
            iSuccess = MySqlDBHelper.ExecuteCommand(sb.ToString(), par);
        }
    }
}