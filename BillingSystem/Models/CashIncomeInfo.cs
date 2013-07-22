using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using FBJHelper;
using System.ComponentModel;

namespace BillingSystem.Models
{
    [Serializable]
    public sealed class CashIncomeInfo
    {
      #region 成员变量、构造函数
        private int id;
        private int ownerId;
        private string ownerName;
        private int cardId;
        private string cardNumber;
        private string bankCardNumber;
        private float incomeAmount;
        private int preMode;
        private int mode;
        private int preRate;
        private int rate;
        private DateTime depositDate;
        private DateTime bDate;
        private DateTime eDate;
        private int autoSave;
        private int depositorId;
        private string depositorName;
        private int depositMode;
        private int status;
        private int incomeType;
        private float tAmount;
        private string content;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public CashIncomeInfo()
        {
            this.id = 0;
            this.ownerId = 0;
            this.ownerName = string.Empty;
            this.cardId = 0;
            this.cardNumber = string.Empty;
            this.bankCardNumber = string.Empty;
            this.incomeAmount = 0;
            this.preMode = 0;
            this.mode = 0;
            this.preRate = 0;
            this.rate = 0;
            this.depositDate = DateTime.MinValue;
            this.bDate = DateTime.MinValue;
            this.eDate = DateTime.MinValue;
            this.autoSave = 0;
            this.depositorId = 0;
            this.depositorName = string.Empty;
            this.depositMode = 0;
            this.status = 0;
            this.incomeType = 0;
            this.tAmount = 0;
            this.content = string.Empty;
        }

        public CashIncomeInfo(CashIncomeInfo cashIncomeInfo)
        {
            this.id = cashIncomeInfo.Id;
            this.ownerId = cashIncomeInfo.OwnerId;
            this.ownerName = cashIncomeInfo.OwnerName;
            this.cardId = cashIncomeInfo.CardId;
            this.cardNumber = cashIncomeInfo.CardNumber;
            this.bankCardNumber = cashIncomeInfo.BankCardNumber;
            this.incomeAmount = cashIncomeInfo.IncomeAmount;
            this.preMode = cashIncomeInfo.PreMode;
            this.mode = cashIncomeInfo.Mode;
            this.preRate = cashIncomeInfo.PreRate;
            this.rate = cashIncomeInfo.Rate;
            this.depositDate = cashIncomeInfo.DepositDate;
            this.bDate = cashIncomeInfo.BDate;
            this.eDate = cashIncomeInfo.EDate;
            this.autoSave = cashIncomeInfo.AutoSave;
            this.depositorId = cashIncomeInfo.DepositorId;
            this.depositorName = cashIncomeInfo.DepositorName;
            this.depositMode = cashIncomeInfo.DepositMode;
            this.status = cashIncomeInfo.Status;
            this.incomeType = cashIncomeInfo.IncomeType;
            this.tAmount = cashIncomeInfo.TAmount;
            this.content = cashIncomeInfo.Content;
        }

        public CashIncomeInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);

            loader.LoadInt32("Id", ref this.id);
            loader.LoadInt32("OwnerId", ref this.ownerId);
            loader.LoadString("OwnerName", ref this.ownerName);
            loader.LoadInt32("CardId", ref this.cardId);
            loader.LoadString("CardNumber", ref this.cardNumber);
            loader.LoadString("BankCardNumber", ref this.bankCardNumber);
            loader.LoadFloat("IncomeAmount", ref this.incomeAmount);
            loader.LoadInt32("PreMode", ref this.preMode);
            loader.LoadInt32("Mode", ref this.mode);
            loader.LoadInt32("PreRate", ref this.preRate);
            loader.LoadInt32("Rate", ref this.rate);
            loader.LoadDateTime("DepositDate", ref this.depositDate);
            loader.LoadDateTime("BDate", ref this.bDate);
            loader.LoadDateTime("EDate", ref this.eDate);
            loader.LoadInt32("AutoSave", ref this.autoSave);
            loader.LoadInt32("DepositorId", ref this.depositorId);
            loader.LoadString("DepositorName", ref this.depositorName);
            loader.LoadInt32("DepositMode", ref this.depositMode);
            loader.LoadInt32("Status", ref this.status);
            loader.LoadInt32("IncomeType", ref this.incomeType);
            loader.LoadFloat("TAmount", ref this.tAmount);
            loader.LoadString("Content", ref this.content);
        }

        #region 字段属性

        /// <summary>
        /// 卡ID
        /// </summary>
        ///
        [Browsable(true)]
        [ReadOnly(false)]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        /// <summary>
        /// 卡所有者id
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int OwnerId
        {
            get
            {
                return ownerId;
            }
            set
            {
                ownerId = value;
            }
        }

        /// <summary>
        /// 卡所有者名称
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string OwnerName
        {
            get
            {
                return ownerName;
            }
            set
            {
                ownerName = value;
            }
        }

        /// <summary>
        /// 卡Id
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int CardId
        {
            get
            {
                return cardId;
            }
            set
            {
                cardId = value;
            }
        }

        /// <summary>
        /// 卡号
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string CardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                cardNumber = value;
            }
        }

        /// <summary>
        /// 卡号+银行
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string BankCardNumber
        {
            get
            {
                return bankCardNumber;
            }
            set
            {
                bankCardNumber = value;
            }
        }

        /// <summary>
        /// 收入金额
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public float IncomeAmount
        {
            get
            {
                return incomeAmount;
            }
            set
            {
                incomeAmount = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public int PreMode
        {
            get
            {
                return preMode;
            }
            set
            {
                preMode = value;
            }
        }

        /// <summary>
        /// 存款类型（1.活期，2定存三个月，3.定存六个月，4.定存一年，5.定存三年，6.定存五年）
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public int PreRate
        {
            get
            {
                return preRate;
            }
            set
            {
                preRate = value;
            }
        }

        /// <summary>
        /// 利率
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }

        /// <summary>
        /// 存入日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime DepositDate
        {
            get
            {
                return depositDate;
            }
            set
            {
                depositDate = value;
            }
        }

        /// <summary>
        /// 定存开始日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime BDate
        {
            get
            {
                return bDate;
            }
            set
            {
                bDate = value;
            }
        }

        /// <summary>
        /// 到期日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime EDate
        {
            get
            {
                return eDate;
            }
            set
            {
                eDate = value;
            }
        }

        /// <summary>
        /// 是否自动转存
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int AutoSave
        {
            get
            {
                return autoSave;
            }
            set
            {
                autoSave = value;
            }
        }

        /// <summary>
        /// 存款人id
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int DepositorId
        {
            get
            {
                return depositorId;
            }
            set
            {
                depositorId = value;
            }
        }

        /// <summary>
        /// 存款人名称
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string DepositorName
        {
            get
            {
                return depositorName;
            }
            set
            {
                depositorName = value;
            }
        }

        /// <summary>
        /// 存款方式
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int DepositMode
        {
            get
            {
                return depositMode;
            }
            set
            {
                depositMode = value;
            }
        }

        /// <summary>
        /// 状态（1.到期，2.未到期，自动转存未到期）
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        /// <summary>
        /// 收入类型（1.工资，2.奖金，3.股票）
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int IncomeType
        {
            get
            {
                return incomeType;
            }
            set
            {
                incomeType = value;
            }
        }

        /// <summary>
        /// 到期总金额
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public float TAmount
        {
            get
            {
                return tAmount;
            }
            set
            {
                tAmount = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        #endregion

        public string ToXmlTree()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<CashIncomeInfo>");
            sb.AppendFormat("<Id>{0}</Id>", this.Id);
            sb.AppendFormat("<OwnerId>{0}</OwnerId>", this.OwnerId);
            sb.AppendFormat("<OwnerName>{0}</OwnerName>", this.OwnerName);
            sb.AppendFormat("<CardId>{0}</CardId>", this.CardId);
            sb.AppendFormat("<CardNumber>{0}</CardNumber>", this.CardNumber);
            sb.AppendFormat("<BankCardNumber>{0}</BankCardNumber>", this.BankCardNumber);
            sb.AppendFormat("<IncomeAmount>{0}</IncomeAmount>", this.IncomeAmount);
            sb.AppendFormat("<PreMode>{0}</PreMode>", this.PreMode);
            sb.AppendFormat("<Mode>{0}</Mode>", this.Mode);
            sb.AppendFormat("<PreRate>{0}</PreRate>", this.PreRate);
            sb.AppendFormat("<Rate>{0}</Rate>", this.Rate);
            //sb.AppendFormat("<DepositDate>{0}</DepositDate>", this.DepositDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            sb.AppendFormat("<DepositDate>{0}</DepositDate>", this.DepositDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<BDate>{0}</BDate>", this.BDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<EDate>{0}</EDate>", this.EDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<AutoSave>{0}</AutoSave>", this.AutoSave);
            sb.AppendFormat("<DepositorId>{0}</DepositorId>", this.DepositorId);
            sb.AppendFormat("<DepositorName>{0}</DepositorName>", this.DepositorName);
            sb.AppendFormat("<DepositMode>{0}</DepositMode>", this.DepositMode);
            sb.AppendFormat("<Status>{0}</Status>", this.Status);
            sb.AppendFormat("<IncomeType>{0}</IncomeType>", this.IncomeType);
            sb.AppendFormat("<TAmount>{0}</TAmount>", this.TAmount);
            sb.AppendFormat("<Content>{0}</Content>", this.Content);
            sb.Append("</CashIncomeInfo>");
            return sb.ToString();
        }

        public string ToJson()
        {
            StringBuilder jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.Append("{");

            jsonStringBuilder.Append("Id:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.id);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("OwnerId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.ownerId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("OwnerName:");
            FbjJsonHelper.WriteValue(jsonStringBuilder,this.ownerName);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("CardId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder,this.cardId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("CardNumber:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.cardNumber);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BankCardNumber:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.bankCardNumber);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("IncomeAmount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.incomeAmount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("PreMode:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.preMode);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Mode:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.mode);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("PreRate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.preRate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Rate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.rate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("DepositDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.depositDate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.bDate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("EDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.eDate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("AutoSave:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.autoSave);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("DepositorId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.depositorId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("DepositorName:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.depositorName);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("DepositMode:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.depositMode);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Status:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.status);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("IncomeType:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.incomeType);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("TAmount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.tAmount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Content:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.content);

            jsonStringBuilder.Append("}");
            return jsonStringBuilder.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(CashIncomeInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static CashIncomeInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(CashIncomeInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as CashIncomeInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new CashIncomeInfo(this);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;

            CashIncomeInfo cashIncomeInfo = obj as CashIncomeInfo;

            return (this.id.Equals(cashIncomeInfo.Id));
        }

        public static bool operator ==(CashIncomeInfo sourceObject, CashIncomeInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(CashIncomeInfo sourceObject, CashIncomeInfo targetObject)
        {
            return !(sourceObject == targetObject);
        }

        public static DataTable GenerateDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("OwnerId", typeof(int));
            table.Columns.Add("OwnerName", typeof(string));
            table.Columns.Add("CardId", typeof(int));
            table.Columns.Add("CardNumber", typeof(string));
            table.Columns.Add("BankCardNumber", typeof(string));
            table.Columns.Add("IncomeAmount", typeof(float));
            table.Columns.Add("PreMode", typeof(int));
            table.Columns.Add("Mode", typeof(int));
            table.Columns.Add("PreRate", typeof(int));
            table.Columns.Add("Rate", typeof(int));
            table.Columns.Add("DepositDate", typeof(DateTime));
            table.Columns.Add("BDate", typeof(DateTime));
            table.Columns.Add("EDate", typeof(DateTime));
            table.Columns.Add("AutoSave", typeof(int));
            table.Columns.Add("DepositorId", typeof(int));
            table.Columns.Add("DepositorName", typeof(string));
            table.Columns.Add("DepositMode", typeof(int));
            table.Columns.Add("Status", typeof(int));
            table.Columns.Add("IncomeType", typeof(int));
            table.Columns.Add("TAmount", typeof(float));
            table.Columns.Add("Content", typeof(string));
            return table;
        }

        public static void AddTableRow(DataTable table, CashIncomeInfo cashIncomeInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = cashIncomeInfo.id;
            dr["OwnerId"] = cashIncomeInfo.ownerId;
            dr["OwnerName"] = cashIncomeInfo.ownerName;
            dr["CardId"] = cashIncomeInfo.cardId;
            dr["CardNumber"] = cashIncomeInfo.cardNumber;
            dr["BankCardNumber"] = cashIncomeInfo.bankCardNumber;
            dr["IncomeAmount"] = cashIncomeInfo.incomeAmount;
            dr["PreMode"] = cashIncomeInfo.preMode;
            dr["Mode"] = cashIncomeInfo.mode;
            dr["PreRate"] = cashIncomeInfo.preRate;
            dr["Rate"] = cashIncomeInfo.rate;
            dr["DepositDate"] = cashIncomeInfo.depositDate;
            dr["BDate"] = cashIncomeInfo.bDate;
            dr["EDate"] = cashIncomeInfo.eDate;
            dr["AutoSave"] = cashIncomeInfo.autoSave;
            dr["DepositorId"] = cashIncomeInfo.depositorId;
            dr["DepositorName"] = cashIncomeInfo.depositorName;
            dr["DepositMode"] = cashIncomeInfo.depositMode;
            dr["Status"] = cashIncomeInfo.status;
            dr["IncomeType"] = cashIncomeInfo.incomeType;
            dr["TAmount"] = cashIncomeInfo.tAmount;
            dr["Content"] = cashIncomeInfo.content;
            table.Rows.Add(dr);
        }
        #endregion
    }
}