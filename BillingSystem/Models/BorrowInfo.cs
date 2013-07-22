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
    public sealed class BorrowInfo
    {
        #region 成员变量、构造函数
        private int id;
        private int borrowType;
        private string borrowedAccount;
        private string borrower;
        private string loanAccount;
        private string lender;
        private float borrowAmount;
        private DateTime borrowDate;
        private DateTime returnDate;
        private string content;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public BorrowInfo()
        {
            this.id = 0;
            this.borrowType = 0;
            this.borrowedAccount = string.Empty;
            this.borrower = string.Empty;
            this.loanAccount = string.Empty;
            this.lender = string.Empty;
            this.borrowAmount = 0;
            this.borrowDate = DateTime.MinValue;
            this.returnDate = DateTime.MinValue;
            this.content = string.Empty;
        }

        public BorrowInfo(BorrowInfo borrowInfo)
        {
            this.id = borrowInfo.Id;
            this.borrowType = borrowInfo.BorrowType;
            this.borrowedAccount = borrowInfo.BorrowedAccount;
            this.borrower = borrowInfo.Borrower;
            this.loanAccount = borrowInfo.LoanAccount;
            this.lender = borrowInfo.Lender;
            this.borrowAmount = borrowInfo.BorrowAmount;
            this.borrowDate = borrowInfo.BorrowDate;
            this.returnDate = borrowInfo.ReturnDate;
            this.content = borrowInfo.Content;
        }

        public BorrowInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);
            loader.LoadInt32("Id", ref this.id);
            loader.LoadInt32("BorrowType", ref this.borrowType);
            loader.LoadString("BorrowedAccount", ref this.borrowedAccount);
            loader.LoadString("Borrower", ref this.borrower);
            loader.LoadString("LoanAccount", ref this.loanAccount);
            loader.LoadString("Lender", ref this.lender);
            loader.LoadFloat("BorrowAmount", ref this.borrowAmount);
            loader.LoadDateTime("BorrowDate", ref this.borrowDate);
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
        /// 借款方式：1，现金；2，转账
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
        public string BorrowedAccount
        {
            get
            {
                return borrowedAccount;
            }
            set
            {
                borrowedAccount = value;
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
       /// 借款金额
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
        /// 借款日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime BorrowDate
        {
            get
            {
                return borrowDate;
            }
            set
            {
                borrowDate = value;
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
            sb.Append("<BorrowInfo>");
            sb.AppendFormat("<Id>{0}</Id>", this.Id);
            sb.AppendFormat("<BorrowType>{0}</BorrowType>", this.BorrowType);
            sb.AppendFormat("<BorrowedAccount>{0}</BorrowedAccount>", this.BorrowedAccount);
            sb.AppendFormat("<Borrower>{0}</Borrower>", this.Borrower);
            sb.AppendFormat("<LoanAccount>{0}</LoanAccount>", this.LoanAccount);
            sb.AppendFormat("<Lender>{0}</Lender>", this.Lender);
            sb.AppendFormat("<BorrowAmount>{0}</BorrowAmount>", this.BorrowAmount);
            sb.AppendFormat("<BorrowDate>{0}</BorrowDate>", this.BorrowDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<ReturnDate>{0}</ReturnDate>", this.ReturnDate.ToString("yyyy-MM-dd"));
            sb.AppendFormat("<Content>{0}</Content>", this.Content);
            //sb.AppendFormat("<EnterTime>{0}</EnterTime>", this.EnterTime.ToString("yyyy-MM-ddTHH:mm:ss"));
            //sb.AppendFormat("<ModifyTime>{0}</ModifyTime>", this.ModifyTime.ToString("yyyy-MM-ddTHH:mm:ss"));
            sb.Append("</BorrowInfo>");
            return sb.ToString();
        }

        public string ToJson()
        {
            StringBuilder jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.Append("{");

            jsonStringBuilder.Append("Id:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.id);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowType:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowType);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowedAccount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowedAccount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Borrower:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrower);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("LoanAccount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.loanAccount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Lender:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.lender);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowAmount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowAmount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowDate);
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
            XmlSerializer s = new XmlSerializer(typeof(BorrowInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static BorrowInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(BorrowInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as BorrowInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new BorrowInfo(this);
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

            BorrowInfo borrowInfo = obj as BorrowInfo;

            return (this.id.Equals(borrowInfo.Id));
        }

        public static bool operator ==(BorrowInfo sourceObject, BorrowInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(BorrowInfo sourceObject, BorrowInfo targetObject)
        {
            return !(sourceObject == targetObject);
        }

        public static DataTable GenerateDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("BorrowType", typeof(int));
            table.Columns.Add("BorrowedAccount", typeof(string));
            table.Columns.Add("Borrower", typeof(string));
            table.Columns.Add("LoanAccount", typeof(string));
            table.Columns.Add("Lender", typeof(string));
            table.Columns.Add("BorrowAmount", typeof(float));
            table.Columns.Add("BorrowDate", typeof(DateTime));
            table.Columns.Add("ReturnDate", typeof(DateTime));
            table.Columns.Add("Content", typeof(string));
            return table;
        }

        public static void AddTableRow(DataTable table, BorrowInfo borrowInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = borrowInfo.id;
            dr["BorrowType"] = borrowInfo.borrowType;
            dr["BorrowedAccount"] = borrowInfo.borrowedAccount;
            dr["Borrower"] = borrowInfo.borrower;
            dr["LoanAccount"] = borrowInfo.loanAccount;
            dr["Lender"] = borrowInfo.lender;
            dr["BorrowAmount"] = borrowInfo.borrowAmount;
            dr["BorrowDate"] = borrowInfo.borrowDate;
            dr["ReturnDate"] = borrowInfo.returnDate;
            dr["Content"] = borrowInfo.content;
            table.Rows.Add(dr);
        }
        #endregion
    }
}