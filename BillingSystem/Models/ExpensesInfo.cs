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
    public sealed class ExpensesInfo
    {
      #region 成员变量、构造函数
        private int id;
        private int ownerId;
        private string ownerName;
        private int cardId;
        private string cardNumber;
        private string bankCardNumber;
        private int spendType;
        private string howToUse;
        private float price;
        private int number;
        private float amount;
        private DateTime spendDate;
        private int spendMode;
        private int consumerId;
        private string consumerName;
        private string content;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public ExpensesInfo()
        {
            this.id = 0;
            this.ownerId = 0;
            this.ownerName = string.Empty;
            this.cardId = 0;
            this.cardNumber = string.Empty;
            this.bankCardNumber = string.Empty;
            this.spendType = 0;
            this.howToUse = string.Empty;
            this.price = 0;
            this.number = 0;
            this.amount = 0;
            this.spendDate = DateTime.MinValue;
            this.spendMode = 0;
            this.consumerId = 0;
            this.consumerName = string.Empty;
            this.content = string.Empty;
        }

        public ExpensesInfo(ExpensesInfo expensesInfo)
        {
            this.id = expensesInfo.Id;
            this.ownerId = expensesInfo.OwnerId;
            this.ownerName = expensesInfo.OwnerName;
            this.cardId = expensesInfo.CardId;
            this.cardNumber = expensesInfo.CardNumber;
            this.bankCardNumber = expensesInfo.BankCardNumber;
            this.spendType = expensesInfo.SpendType;
            this.howToUse = expensesInfo.HowToUse;
            this.price = expensesInfo.Price;
            this.number = expensesInfo.Number;
            this.amount = expensesInfo.Amount;
            this.spendDate = expensesInfo.SpendDate;
            this.spendMode = expensesInfo.SpendMode;
            this.consumerId = expensesInfo.ConsumerId;
            this.consumerName = expensesInfo.ConsumerName;
            this.content = expensesInfo.Content;
        }

        public ExpensesInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);

            loader.LoadInt32("Id", ref this.id);
            loader.LoadInt32("OwnerId", ref this.ownerId);
            loader.LoadString("OwnerName", ref this.ownerName);
            loader.LoadInt32("CardId", ref this.cardId);
            loader.LoadString("CardNumber", ref this.cardNumber);
            loader.LoadString("BankCardNumber", ref this.bankCardNumber);
            loader.LoadInt32("SpendType", ref this.spendType);
            loader.LoadString("HowToUse", ref this.howToUse);
            loader.LoadFloat("Price", ref this.price);
            loader.LoadInt32("Number", ref this.number);
            loader.LoadFloat("Amount", ref this.amount);
            loader.LoadDateTime("SpendDate", ref this.spendDate);
            loader.LoadInt32("SpendMode", ref this.spendMode);
            loader.LoadInt32("ConsumerId", ref this.consumerId);
            loader.LoadString("ConsumerName", ref this.consumerName);
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
        /// 资产所有者Id
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
        /// 资产所有者name
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

        [Browsable(true)]
        [ReadOnly(false)]
        public int SpendType
        {
            get
            {
                return spendType;
            }
            set
            {
                spendType = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public string HowToUse
        {
            get
            {
                return howToUse;
            }
            set
            {
                howToUse = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public float Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime SpendDate
        {
            get
            {
                return spendDate;
            }
            set
            {
                spendDate = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public int SpendMode
        {
            get
            {
                return spendMode;
            }
            set
            {
                spendMode = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public int ConsumerId
        {
            get
            {
                return consumerId;
            }
            set
            {
                consumerId = value;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        public string ConsumerName
        {
            get
            {
                return consumerName;
            }
            set
            {
                consumerName = value;
            }
        }

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
            sb.Append("<ExpensesInfo>");
            sb.AppendFormat("<Id>{0}</Id>", this.Id);
            sb.AppendFormat("<OwnerId>{0}</OwnerId>", this.OwnerId);
            sb.AppendFormat("<OwnerName>{0}</OwnerName>", this.OwnerName);
            sb.AppendFormat("<CardId>{0}</CardId>", this.CardId);
            sb.AppendFormat("<CardNumber>{0}</CardNumber>", this.CardNumber);
            sb.AppendFormat("<BankCardNumber>{0}</BankCardNumber>", this.BankCardNumber);
            sb.AppendFormat("<SpendType>{0}</SpendType>", this.SpendType);
            sb.AppendFormat("<HowToUse>{0}</HowToUse>", this.HowToUse);
            sb.AppendFormat("<Price>{0}</Price>", this.Price);
            sb.AppendFormat("<Number>{0}</Number>", this.Number);
            sb.AppendFormat("<Amount>{0}</Amount>", this.Amount);
            sb.AppendFormat("<SpendDate>{0}</SpendDate>", this.SpendDate);
            sb.AppendFormat("<SpendMode>{0}</SpendMode>", this.SpendMode);
            sb.AppendFormat("<ConsumerId>{0}</ConsumerId>", this.ConsumerId);
            sb.AppendFormat("<ConsumerName>{0}</ConsumerName>", this.ConsumerName);
            sb.AppendFormat("<Content>{0}</Content>", this.Content);
            sb.Append("</ExpensesInfo>");
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
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.cardId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("CardNumber:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.cardNumber);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BankCardNumber:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.bankCardNumber);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("SpendType:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.spendType);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("HowToUse:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.howToUse);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Price:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.price);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Number:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.number);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Amount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.amount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("SpendDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.spendDate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("SpendMode:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.spendMode);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("ConsumerId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.consumerId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("ConsumerName:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.consumerName);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Content:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.content);

            jsonStringBuilder.Append("}");
            return jsonStringBuilder.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(ExpensesInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static ExpensesInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(ExpensesInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as ExpensesInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new ExpensesInfo(this);
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

            ExpensesInfo expensesInfo = obj as ExpensesInfo;

            return (this.id.Equals(expensesInfo.Id));
        }

        public static bool operator ==(ExpensesInfo sourceObject, ExpensesInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(ExpensesInfo sourceObject, ExpensesInfo targetObject)
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
            table.Columns.Add("SpendType", typeof(int));
            table.Columns.Add("HowToUse", typeof(string));
            table.Columns.Add("Price", typeof(float));
            table.Columns.Add("Number", typeof(int));
            table.Columns.Add("Amount", typeof(float));
            table.Columns.Add("SpendDate", typeof(DateTime));
            table.Columns.Add("SpendMode", typeof(int));
            table.Columns.Add("ConsumerId", typeof(int));
            table.Columns.Add("ConsumerName", typeof(string));
            table.Columns.Add("Content", typeof(string));
            return table;
        }

        public static void AddTableRow(DataTable table, ExpensesInfo expensesInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = expensesInfo.id;
            dr["OwnerId"] = expensesInfo.ownerId;
            dr["OwnerName"] = expensesInfo.ownerName;
            dr["CardId"] = expensesInfo.cardId;
            dr["CardNumber"] = expensesInfo.cardNumber;
            dr["BankCardNumber"] = expensesInfo.bankCardNumber;
            dr["SpendType"] = expensesInfo.spendType;
            dr["HowToUse"] = expensesInfo.howToUse;
            dr["Price"] = expensesInfo.price;
            dr["Number"] = expensesInfo.number;
            dr["Amount"] = expensesInfo.amount;
            dr["SpendDate"] = expensesInfo.spendDate;
            dr["SpendMode"] = expensesInfo.spendMode;
            dr["ConsumerId"] = expensesInfo.consumerId;
            dr["ConsumerName"] = expensesInfo.consumerName;
            dr["Content"] = expensesInfo.content;
            table.Rows.Add(dr);
        }
        #endregion
    }
}