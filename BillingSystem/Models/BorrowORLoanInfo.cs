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
    public sealed class BorrowORLoanInfo
    {
        #region 成员变量、构造函数
        private int id;
        private int borrowORLoan;
        private int borrowORLoanType;
        private int borrowORLoanAccountId;
        private string borrowedAccount;
        private string borrower;
        //private int loanType;
        private string loanAccount;
        private string lender;
        private float amount;
        private DateTime happenedDate;
        private DateTime returnDate;
        private string content;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public BorrowORLoanInfo()
        {
            this.id = 0;
            this.borrowORLoan = 0;
            this.borrowORLoanType = 0;
            this.borrowORLoanAccountId = 0;
            this.borrowedAccount = string.Empty;
            this.borrower = string.Empty;
            //this.loanType = 0;
            this.loanAccount = string.Empty;
            this.lender = string.Empty;
            this.amount = 0;
            this.happenedDate = DateTime.MinValue;
            this.returnDate = DateTime.MinValue;
            this.content = string.Empty;
        }

        public BorrowORLoanInfo(BorrowORLoanInfo borrowInfo)
        {
            this.id = borrowInfo.Id;
            this.borrowORLoan = borrowInfo.BorrowORLoan;
            this.borrowORLoanType = borrowInfo.BorrowORLoanType;
            this.borrowORLoanAccountId = borrowInfo.BorrowORLoanAccountId;
            this.borrowedAccount = borrowInfo.BorrowedAccount;
            this.borrower = borrowInfo.Borrower;
            //this.loanType = borrowInfo.LoanType;
            this.loanAccount = borrowInfo.LoanAccount;
            this.lender = borrowInfo.Lender;
            this.amount = borrowInfo.Amount;
            this.happenedDate = borrowInfo.HappenedDate;
            this.returnDate = borrowInfo.ReturnDate;
            this.content = borrowInfo.Content;
        }

        public BorrowORLoanInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);
            loader.LoadInt32("Id", ref this.id);
            loader.LoadInt32("BorrowORLoan", ref this.borrowORLoan);
            loader.LoadInt32("BorrowORLoanType", ref this.borrowORLoanType);
            loader.LoadInt32("BorrowORLoanAccountId", ref this.borrowORLoanAccountId);
            loader.LoadString("BorrowedAccount", ref this.borrowedAccount);
            loader.LoadString("Borrower", ref this.borrower);
            //loader.LoadInt32("LoanType",ref this.loanType);
            loader.LoadString("LoanAccount", ref this.loanAccount);
            loader.LoadString("Lender", ref this.lender);
            loader.LoadFloat("Amount", ref this.amount);
            loader.LoadDateTime("HappenedDate", ref this.happenedDate);
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
        /// 1:借入；2：借出
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int BorrowORLoan
        {
            get
            {
                return borrowORLoan;
            }
            set
            {
                borrowORLoan = value;
            }
        }

        /// <summary>
        /// 借款方式：1，现金；2，转账
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int BorrowORLoanType
        {
            get
            {
                return borrowORLoanType;
            }
            set
            {
                borrowORLoanType = value;
            }
        }

        /// <summary>
        /// 借入：借入账户Id；借出：借出账户Id；
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int BorrowORLoanAccountId
        {
            get
            {
                return borrowORLoanAccountId;
            }
            set
            {
                borrowORLoanAccountId = value;
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

        ///// <summary>
        ///// 借出方式：1，现金；2，转账
        ///// </summary>
        //[Browsable(true)]
        //[ReadOnly(false)]
        //public int LoanType
        //{
        //    get
        //    {
        //        return loanType;
        //    }
        //    set
        //    {
        //        loanType = value;
        //    }
        //}

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
        /// 借款日期
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public DateTime HappenedDate
        {
            get
            {
                return happenedDate;
            }
            set
            {
                happenedDate = value;
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
            sb.AppendFormat("<BorrowORLoan>{0}</BorrowORLoan>", this.BorrowORLoan);
            sb.AppendFormat("<BorrowORLoanType>{0}</BorrowORLoanType>", this.BorrowORLoanType);
            sb.AppendFormat("<BorrowORLoanAccountId>{0}</BorrowORLoanAccountId>", this.BorrowORLoanAccountId);
            sb.AppendFormat("<BorrowedAccount>{0}</BorrowedAccount>", this.BorrowedAccount);
            sb.AppendFormat("<Borrower>{0}</Borrower>", this.Borrower);
            //sb.AppendFormat("<LoanType>{0}</LoanType>", this.LoanType);
            sb.AppendFormat("<LoanAccount>{0}</LoanAccount>", this.LoanAccount);
            sb.AppendFormat("<Lender>{0}</Lender>", this.Lender);
            sb.AppendFormat("<Amount>{0}</Amount>", this.Amount);
            sb.AppendFormat("<HappenedDate>{0}</HappenedDate>", this.HappenedDate.ToString("yyyy-MM-dd"));
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

            jsonStringBuilder.Append("BorrowORLoan:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowORLoan);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowORLoanType:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowORLoanType);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowORLoanAccountId:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowORLoanAccountId);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("BorrowedAccount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrowedAccount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Borrower:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.borrower);
            jsonStringBuilder.Append(",");

            //jsonStringBuilder.Append("LoanType:");
            //FbjJsonHelper.WriteValue(jsonStringBuilder, this.loanType);
            //jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("LoanAccount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.loanAccount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Lender:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.lender);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Amount:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.amount);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("HappenedDate:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.happenedDate);
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
            XmlSerializer s = new XmlSerializer(typeof(BorrowORLoanInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static BorrowORLoanInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(BorrowORLoanInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as BorrowORLoanInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new BorrowORLoanInfo(this);
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

            BorrowORLoanInfo borrowInfo = obj as BorrowORLoanInfo;

            return (this.id.Equals(borrowInfo.Id));
        }

        public static bool operator ==(BorrowORLoanInfo sourceObject, BorrowORLoanInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(BorrowORLoanInfo sourceObject, BorrowORLoanInfo targetObject)
        {
            return !(sourceObject == targetObject);
        }

        public static DataTable GenerateDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("BorrowORLoan", typeof(int));
            table.Columns.Add("BorrowORLoanType", typeof(int));
            table.Columns.Add("BorrowORLoanAccountId", typeof(int));
            table.Columns.Add("BorrowedAccount", typeof(string));
            table.Columns.Add("Borrower", typeof(string));
            //table.Columns.Add("LoanType", typeof(int));
            table.Columns.Add("LoanAccount", typeof(string));
            table.Columns.Add("Lender", typeof(string));
            table.Columns.Add("Amount", typeof(float));
            table.Columns.Add("HappenedDate", typeof(DateTime));
            table.Columns.Add("ReturnDate", typeof(DateTime));
            table.Columns.Add("Content", typeof(string));
            return table;
        }

        public static void AddTableRow(DataTable table, BorrowORLoanInfo borrowInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = borrowInfo.id;
            dr["BorrowORLoan"] = borrowInfo.borrowORLoan;
            dr["BorrowORLoanType"] = borrowInfo.borrowORLoanType;
            dr["BorrowORLoanAccountId"] = borrowInfo.borrowORLoanAccountId;
            dr["BorrowedAccount"] = borrowInfo.borrowedAccount;
            dr["Borrower"] = borrowInfo.borrower;
            //dr["LoanType"] = borrowInfo.loanType;
            dr["LoanAccount"] = borrowInfo.loanAccount;
            dr["Lender"] = borrowInfo.lender;
            dr["Amount"] = borrowInfo.amount;
            dr["HappenedDate"] = borrowInfo.happenedDate;
            dr["ReturnDate"] = borrowInfo.returnDate;
            dr["Content"] = borrowInfo.content;
            table.Rows.Add(dr);
        }
        #endregion
    }
}