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
    public sealed class UserInfo
    {
      #region 成员变量、构造函数
        private int id;
        private string code;
        private string name;
        private string password;
        private string eMail;
        private int role;
        public string content;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public UserInfo()
        {
            this.id = 0;
            this.code = string.Empty;
            this.name = string.Empty;
            this.password = string.Empty;
            this.eMail = string.Empty;
            this.role = 0;
            this.content = string.Empty;
        }

        public UserInfo(UserInfo userInfo)
        {
            this.id = userInfo.Id;
            this.code = userInfo.Code;
            this.name = userInfo.Name;
            this.password = userInfo.Password;
            this.role = userInfo.Role;
            this.content = userInfo.Content;
            this.eMail = userInfo.EMail;
        }

        public UserInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);
            loader.LoadInt32("Id", ref this.id);
            loader.LoadString("Code", ref this.code);
            loader.LoadString("Name", ref this.name);
            loader.LoadString("Password", ref this.password);
            loader.LoadString("EMail",ref this.eMail);
            loader.LoadInt32("Role", ref this.role);
            loader.LoadString("Content", ref this.content);
        }

        #region 字段属性

        /// <summary>
        /// ID
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
        /// 编号
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public string EMail
        {
            get
            {
                return eMail;
            }
            set
            {
                eMail = value;
            }
        }

        /// <summary>
        /// 角色
        /// </summary>
        [Browsable(true)]
        [ReadOnly(false)]
        public int Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
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
            sb.Append("<UserInfo>");
            sb.AppendFormat("<Id>{0}</Id>", this.Id);
            sb.AppendFormat("<Code>{0}</Code>", this.Code);
            sb.AppendFormat("<Name>{0}</Name>", this.Name);
            sb.AppendFormat("<Password>{0}</Password>", this.Password);
            sb.AppendFormat("<EMail>{0}</EMail>", this.Password);
            sb.AppendFormat("<Role>{0}</Role>", this.Role);
            sb.AppendFormat("<Content>{0}</Content>", this.Content);
            sb.Append("</UserInfo>");
            return sb.ToString();
        }

        public string ToJson()
        {
            StringBuilder jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.Append("{");

            jsonStringBuilder.Append("Id:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.id);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Code:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.id);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Name:");
            FbjJsonHelper.WriteValue(jsonStringBuilder,this.name);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Password:");
            FbjJsonHelper.WriteValue(jsonStringBuilder,this.password);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("EMail:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.eMail);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Role:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.role);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Content:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.content);

            jsonStringBuilder.Append("}");
            return jsonStringBuilder.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(UserInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static UserInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(UserInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as UserInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new UserInfo(this);
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

            UserInfo userInfo = obj as UserInfo;

            return (this.id.Equals(userInfo.Id));
        }

        public static bool operator ==(UserInfo sourceObject, UserInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(UserInfo sourceObject, UserInfo targetObject)
        {
            return !(sourceObject == targetObject);
        }

        public static DataTable GenerateDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Code", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Password", typeof(string));
            table.Columns.Add("EMail", typeof(string));
            table.Columns.Add("Role", typeof(int));
            table.Columns.Add("Content", typeof(string));
            //table.Columns.Add("ModifyTime", typeof(DateTime));
            return table;
        }

        public static void AddTableRow(DataTable table, UserInfo userInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = userInfo.id;
            dr["Code"] = userInfo.code;
            dr["Name"] = userInfo.name;
            dr["Password"] = userInfo.password;
            dr["EMail"] = userInfo.eMail;
            dr["Role"] = userInfo.role;
            dr["Content"] = userInfo.content;
            table.Rows.Add(dr);
        }
        #endregion
    }
}