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
    public sealed class CardInfo
    {
      #region 成员变量、构造函数
        private int id;
        private int bankId;
        private string cardnumber;
        private int accountType;
        private float amount;
        private float expenditureAmount;
        private float borrowAmount;
        private float incomeAmount;
        private int ownerId;
        private string ownerCode;
        private string ownerName;
        private int userId;
        private string userCode;
        private string userName;
        private string bankName;
        private DateTime openDate;
        private string content;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public CardInfo()
        {
            this.id = 0;
            this.bankId = 0;
            this.cardnumber = string.Empty;
            this.accountType = 0;
            this.amount = 0;
            this.expenditureAmount = 0;
            this.borrowAmount = 0;
            this.incomeAmount = 0;
            this.ownerId = 0;
            this.ownerCode = string.Empty;
            this.ownerName = string.Empty;
            this.userId = 0;
            this.userCode = string.Empty;
            this.userName = string.Empty;
            this.bankName = string.Empty;
            this.openDate = DateTime.MinValue;
            this.content = string.Empty;
        }

        public CardInfo(CardInfo cardInfo)
        {
            this.id = cardInfo.Id;
            this.bankId = cardInfo.BankId;
            this.cardnumber = cardInfo.CardNumber;
            this.accountType = cardInfo.AccountType;
            this.amount = cardInfo.Amount;
            this.expenditureAmount = cardInfo.ExpenditureAmount;
            this.borrowAmount = cardInfo.BorrowAmount;
            this.incomeAmount = cardInfo.IncomeAmount;
            this.ownerId = cardInfo.OwnerId;
            this.ownerCode = cardInfo.OwnerCode;
            this.ownerName = cardInfo.OwnerName;
            this.userId = cardInfo.UserId;
            this.userCode = cardInfo.UserCode;
            this.userName = cardInfo.UserName;
            this.bankName = cardInfo.BankName;
            this.openDate = cardInfo.OpenDate;
            this.content = cardInfo.Content;
        }

        public CardInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);
            loader.LoadInt32("Id", ref this.id);
            loader.LoadInt32("BankId", ref this.bankId);
            loader.LoadString("CardNumber", ref this.cardnumber);
            loader.LoadInt32("AccountType", ref this.accountType);
            loader.LoadFloat("Amount", ref this.amount);
            loader.LoadFloat("ExpenditureAmount", ref this.expenditureAmount);
            loader.LoadFloat("BorrowAmount", ref this.borrowAmount);
            loader.LoadFloat("IncomeAmount", ref this.incomeAmount);
            loader.LoadInt32("OwnerId", ref this.ownerId);
            loader.LoadString("UserCode", ref this.ownerCode);
             loader.LoadString("OwnerName", ref this.ownerName);
            loader.LoadInt32("UserId", ref this.userId);
            loader.LoadString("UserCode", ref this.userCode);
            loader.LoadString("UserName", ref this.userName);
            loader.LoadString("BankName", ref this.bankName);
            loader.LoadDateTime("OpenDate", ref this.openDate);
            loader.LoadString("Content", ref this.content);
            //loader.LoadDateTime("ModifyTime", ref this.modifyTime);

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
        /// 银行Id
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int BankId
        {
            get
            {
                return bankId;
            }
            set
            {
                bankId = value;
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
                return cardnumber;
            }
            set
            {
                cardnumber = value;
            }
        }

        /// <summary>
        /// 账户类型
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;
            }
        }

        /// <summary>
        /// 账户金额
        /// </summary>
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

        /// <summary>
        /// 支出金额
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public float ExpenditureAmount
        {
            get
            {
                return expenditureAmount;
            }
            set
            {
                expenditureAmount = value;
            }
        }

        /// <summary>
        /// 借入金额
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public float BorrowAmount
        {
            get
            {
                return borrowAmount;
            }
            set
            {
                borrowAmount = value;
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


        /// <summary>
        /// 所有者Id
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
        /// 所有者Code
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string OwnerCode
        {
            get
            {
                return ownerCode;
            }
            set
            {
                ownerCode = value;
            }
        }

        /// <summary>
        /// 所有者名称
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
        /// 使用者id
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        /// <summary>
        /// 使用者Code
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string UserCode
        {
            get
            {
                return userCode;
            }
            set
            {
                userCode = value;
            }
        }

        /// <summary>
        /// 卡持有者名称
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        /// <summary>
        /// 开户行名称
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string BankName
        {
            get
            {
                return bankName;
            }
            set
            {
                bankName = value;
            }
        }

        /// <summary>
        /// 开户日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime OpenDate
        {
            get
            {
                return openDate;
            }
            set
            {
                openDate = value;
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
            sb.Append("<CardInfo>");
            sb.AppendFormat("<Id>{0}</Id>", this.Id);
            sb.AppendFormat("<BankId>{0}</BankId>", this.BankId);
            sb.AppendFormat("<CardNumber>{0}</CardNumber>", this.CardNumber);
            sb.AppendFormat("<AccountType>{0}</AccountType>", this.AccountType);
            sb.AppendFormat("<Amount>{0}</Amount>", this.Amount);
            sb.AppendFormat("<ExpenditureAmount>{0}</ExpenditureAmount>", this.ExpenditureAmount);
            sb.AppendFormat("<BorrowAmount>{0}</BorrowAmount>", this.BorrowAmount);
            sb.AppendFormat("<IncomeAmount>{0}</IncomeAmount>", this.IncomeAmount);
            sb.AppendFormat("<OwnerId>{0}</OwnerId>", this.OwnerId);
            sb.AppendFormat("<OwnerCode>{0}</OwnerCode>", this.OwnerCode);
            sb.AppendFormat("<OwnerName>{0}</OwnerName>", this.OwnerName);
            sb.AppendFormat("<UserId>{0}</UserId>", this.UserId);
            sb.AppendFormat("<UserCode>{0}</UserCode>", this.UserCode);
            sb.AppendFormat("<UserName>{0}</UserName>", this.UserName);
            sb.AppendFormat("<BankName>{0}</BankName>", this.BankName);
            sb.AppendFormat("<OpenDate>{0}</OpenDate>", this.OpenDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<Content>{0}</Content>", this.Content);
            //sb.AppendFormat("<EnterTime>{0}</EnterTime>", this.EnterTime.ToString("yyyy-MM-ddTHH:mm:ss"));
            //sb.AppendFormat("<ModifyTime>{0}</ModifyTime>", this.ModifyTime.ToString("yyyy-MM-ddTHH:mm:ss"));
            sb.Append("</CardInfo>");
            return sb.ToString();
        }

        public string ToJson()
        {
            StringBuilder jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.Append("{");

            jsonStringBuilder.Append("Id:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.id);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BankId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.bankId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("CardNumber:");
            FbjJsonHelper.WriteValue(jsonStringBuilder,this.cardnumber);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("AccountType:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.accountType);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Amount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.amount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("ExpenditureAmount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.expenditureAmount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowAmount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowAmount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("IncomeAmount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.incomeAmount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("OwnerId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.ownerCode);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("OwnerCode:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.OwnerCode);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("OwnerName:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.OwnerName);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("UserId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder,this.userId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("UserCode:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.userCode);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("UserName:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.userName);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BankName:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.bankName);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("OpenDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.openDate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Content:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.content);

            jsonStringBuilder.Append("}");
            return jsonStringBuilder.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(CardInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static CardInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(CardInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as CardInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new CardInfo(this);
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

            CardInfo cardInfo = obj as CardInfo;

            return (this.id.Equals(cardInfo.Id));
        }

        public static bool operator ==(CardInfo sourceObject, CardInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(CardInfo sourceObject, CardInfo targetObject)
        {
            return !(sourceObject == targetObject);
        }

        public static DataTable GenerateDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("BankId", typeof(int));
            table.Columns.Add("CardNumber", typeof(string));
            table.Columns.Add("AccountType", typeof(int));
            table.Columns.Add("Amount", typeof(float));
            table.Columns.Add("ExpenditureAmount", typeof(float));
            table.Columns.Add("BorrowAmount", typeof(float));
            table.Columns.Add("IncomeAmount", typeof(float)); 
            table.Columns.Add("OwnerId", typeof(int));
            table.Columns.Add("OwnerCode", typeof(string));
            table.Columns.Add("OwnerName", typeof(string));
            table.Columns.Add("UserId", typeof(int));
            table.Columns.Add("UserCode", typeof(string));
            table.Columns.Add("UserName", typeof(string));
            table.Columns.Add("BankName", typeof(string));
            table.Columns.Add("OpenDate", typeof(DateTime));
            table.Columns.Add("Content",typeof(string));
            return table;
        }

        public static void AddTableRow(DataTable table, CardInfo cardInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = cardInfo.id;
            dr["BankId"] = cardInfo.bankId;
            dr["Card_Number"] = cardInfo.cardnumber;
            dr["AccountType"] = cardInfo.accountType;
            dr["Amount"] = cardInfo.amount;
            dr["ExpenditureAmount"] = cardInfo.expenditureAmount;
            dr["BorrowAmount"] = cardInfo.borrowAmount;
            dr["IncomeAmount"] = cardInfo.incomeAmount;
            dr["OwnerId"] = cardInfo.ownerId;
            dr["OwnerCode"] = cardInfo.ownerCode;
            dr["OwnerName"] = cardInfo.ownerName;
            dr["UserId"] = cardInfo.userId;
            dr["UserCode"] = cardInfo.userCode;
            dr["UserName"] = cardInfo.userName;
            dr["BankName"] = cardInfo.bankName;
            dr["OpenDate"] = cardInfo.openDate;
            dr["Content"] = cardInfo.content;
            table.Rows.Add(dr);
        }
        #endregion
    }
}