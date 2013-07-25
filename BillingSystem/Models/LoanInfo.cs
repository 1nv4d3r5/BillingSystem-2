using FBJHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace BillingSystem.Models
{
    [Serializable]
    public sealed class LoanInfo
    {
        #region 成员变量、构造函数
        private int id;
        private int loanType;
        private string lender;
        private string loanAccount;
        private int borrowType;
        private string borrower;
        private string borrowAccount;
        private float loanAmount;
        private DateTime loanDate;
        private DateTime returnDate;
        private string content;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public LoanInfo()
        {
            this.id = 0;
            this.loanType = 0;
            this.lender = string.Empty;
            this.loanAccount = string.Empty;
            this.borrowType = 0;
            this.borrowAccount = string.Empty;
            this.borrower = string.Empty;
            this.loanAmount = 0;
            this.loanDate = DateTime.MinValue;
            this.returnDate = DateTime.MinValue;
            this.content = string.Empty;
        }

        public LoanInfo(LoanInfo loanInfo)
        {
            this.id = loanInfo.Id;
            this.loanType = loanInfo.LoanType;
            this.loanAccount = loanInfo.LoanAccount;
            this.lender = loanInfo.Lender;
            this.borrower = loanInfo.Borrower;
            this.borrowType = loanInfo.BorrowType;
            this.borrowAccount = loanInfo.BorrowAccount;
            this.loanAmount = loanInfo.LoanAmount;
            this.loanDate = loanInfo.LoanDate;
            this.returnDate = loanInfo.ReturnDate;
            this.content = loanInfo.Content;
        }

        public LoanInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);
            loader.LoadInt32("Id", ref this.id);
            loader.LoadInt32("LoanType", ref this.loanType);
            loader.LoadString("LoanAccount", ref this.loanAccount);
            loader.LoadString("Lender", ref this.lender);
            loader.LoadInt32("BorrowType", ref this.borrowType);
            loader.LoadString("BorrowAccount", ref this.borrowAccount);
            loader.LoadString("Borrower", ref this.borrower);
            loader.LoadFloat("LoanAmount", ref this.loanAmount);
            loader.LoadDateTime("LoanDate", ref this.loanDate);
            loader.LoadDateTime("ReturnDate", ref this.returnDate);
            loader.LoadString("Content", ref this.content);
        }

        #region 字段属性

        /// <summary>
        /// Id
        /// </summary>
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
        /// 借款方式(出)：1，现金；2，转账
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int LoanType
        {
            get
            {
                return loanType;
            }
            set
            {
                loanType = value;
            }
        }

        /// <summary>
        /// 借出账户
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string LoanAccount
        {
            get
            {
                return loanAccount;
            }
            set
            {
                loanAccount = value;
            }
        }

        /// <summary>
        /// 借款人（出）
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string Lender
        {
            get
            {
                return lender;
            }
            set
            {
                lender = value;
            }
        }

        /// <summary>
        /// 借入方式：1，现金；2，转账
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int BorrowType
        {
            get
            {
                return borrowType;
            }
            set
            {
                borrowType = value;
            }
        }

        /// <summary>
        /// 借入账户
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string BorrowAccount
        {
            get
            {
                return borrowAccount;
            }
            set
            {
                borrowAccount = value;
            }
        }

        /// <summary>
        /// 借款人（入）
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string Borrower
        {
            get
            {
                return borrower;
            }
            set
            {
                borrower = value;
            }
        }

       /// <summary>
       /// 借款金额
       /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public float LoanAmount
        {
            get
            {
                return loanAmount;
            }
            set
            {
                loanAmount = value;
            }
        }

        /// <summary>
        /// 借款日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime LoanDate
        {
            get
            {
                return loanDate;
            }
            set
            {
                loanDate = value;
            }
        }

        /// <summary>
        /// 归还日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime ReturnDate
        {
            get
            {
                return returnDate;
            }
            set
            {
                returnDate = value;
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
            sb.Append("<LoanInfo>");
            sb.AppendFormat("<Id>{0}</Id>", this.Id);
            sb.AppendFormat("<LoanType>{0}</LoanType>", this.LoanType);
            sb.AppendFormat("<LoanAccount>{0}</LoanAccount>", this.LoanAccount);
            sb.AppendFormat("<Lender>{0}</Lender>", this.Lender);
            sb.AppendFormat("<BorrowType>{0}</BorrowType>", this.BorrowType);
            sb.AppendFormat("<BorrowAccount>{0}</BorrowAccount>", this.BorrowAccount);
            sb.AppendFormat("<Borrower>{0}</Borrower>", this.Borrower);
            sb.AppendFormat("<LoanAmount>{0}</LoanAmount>", this.LoanAmount);
            sb.AppendFormat("<LoanDate>{0}</LoanDate>", this.LoanDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<ReturnDate>{0}</ReturnDate>", this.ReturnDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<Content>{0}</Content>", this.Content);
            sb.Append("</LoanInfo>");
            return sb.ToString();
        }

        public string ToJson()
        {
            StringBuilder jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.Append("{");

            jsonStringBuilder.Append("Id:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.id);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("LoanType:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.loanType);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("LoanAccount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.loanAccount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Lender:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.lender);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowType:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowType);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowAccount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowAccount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Borrower:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrower);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("LoanAmount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.loanAmount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("LoanDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.loanDate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("ReturnDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.returnDate);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Content:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.content);
            
            jsonStringBuilder.Append("}");
            return jsonStringBuilder.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(LoanInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static LoanInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(LoanInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as LoanInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new LoanInfo(this);
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

            LoanInfo loanInfo = obj as LoanInfo;

            return (this.id.Equals(loanInfo.Id));
        }

        public static bool operator ==(LoanInfo sourceObject, LoanInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(LoanInfo sourceObject, LoanInfo targetObject)
        {
            return !(sourceObject == targetObject);
        }

        public static DataTable GenerateDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("LoanType", typeof(int));
            table.Columns.Add("LoanAccount", typeof(string));
            table.Columns.Add("Lender", typeof(string));
            table.Columns.Add("BorrowType", typeof(int));
            table.Columns.Add("BorrowAccount", typeof(string));
            table.Columns.Add("Borrower", typeof(string));
            table.Columns.Add("LoanAmount", typeof(float));
            table.Columns.Add("LoanDate", typeof(DateTime));
            table.Columns.Add("ReturnDate", typeof(DateTime));
            table.Columns.Add("Content", typeof(string));
            return table;
        }

        public static void AddTableRow(DataTable table, LoanInfo loanInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = loanInfo.id;
            dr["LoanType"] = loanInfo.loanType;
            dr["LoanAccount"] = loanInfo.loanAccount;
            dr["Lender"] = loanInfo.lender;
            dr["BorrowType"] = loanInfo.loanType;
            dr["BorrowAccount"] = loanInfo.borrowAccount;
            dr["Borrower"] = loanInfo.borrower;
            dr["LoanAmount"] = loanInfo.loanAmount;
            dr["LoanDate"] = loanInfo.loanDate;
            dr["ReturnDate"] = loanInfo.returnDate;
            dr["Content"] = loanInfo.content;
            table.Rows.Add(dr);
        }
        #endregion
    }
}