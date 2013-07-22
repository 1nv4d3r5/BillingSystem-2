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
    public sealed class Out_Type_DictionaryInfo
    {
      #region 成员变量、构造函数
        private int id;
        private string name;

        /// <summary>
        /// 初始化类 DefaultEntity 的新实例。
        /// </summary>
        public Out_Type_DictionaryInfo()
        {
            this.id = 0;
            this.name = string.Empty;
        }

        public Out_Type_DictionaryInfo(Out_Type_DictionaryInfo out_Type_DictionaryInfo)
        {
            this.id = out_Type_DictionaryInfo.Id;
            this.name = out_Type_DictionaryInfo.Name;
        }

        public Out_Type_DictionaryInfo(IDataRecord record)
        {
            FieldLoader loader = new FieldLoader(record);
            loader.LoadInt32("Id", ref this.id);
            loader.LoadString("Name", ref this.name);
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
        #endregion

        public string ToXmlTree()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Out_Type_DictionaryInfo>");
            sb.AppendFormat("<Id>{0}</Id>", this.Id);
            sb.AppendFormat("<Name>{0}</Name>", this.name);
            return sb.ToString();
        }

        public string ToJson()
        {
            StringBuilder jsonStringBuilder = new StringBuilder();

            jsonStringBuilder.Append("{");

            jsonStringBuilder.Append("Id:");
            FbjJsonHelper.WriteValue(jsonStringBuilder, this.id);
            jsonStringBuilder.Append(",");

            jsonStringBuilder.Append("Name:");
            FbjJsonHelper.WriteValue(jsonStringBuilder,this.name);


            jsonStringBuilder.Append("}");
            return jsonStringBuilder.ToString();
        }

        public string Serialize()
        {
            XmlSerializer s = new XmlSerializer(typeof(Out_Type_DictionaryInfo));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(sb);
            s.Serialize(stringWriter, this);
            return sb.ToString();
        }

        public static Out_Type_DictionaryInfo DeSerialize(string xmlObject)
        {
            XmlSerializer s = new XmlSerializer(typeof(Out_Type_DictionaryInfo));
            try
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(xmlObject);
                return s.Deserialize(stringReader) as Out_Type_DictionaryInfo;
            }
            catch (System.Exception e)
            {

            }
            return null;
        }

        public object Clone()
        {
            return new Out_Type_DictionaryInfo(this);
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

            Out_Type_DictionaryInfo out_Type_DictionaryInfo = obj as Out_Type_DictionaryInfo;

            return (this.id.Equals(out_Type_DictionaryInfo.Id));
        }

        public static bool operator ==(Out_Type_DictionaryInfo sourceObject, Out_Type_DictionaryInfo targetObject)
        {
            return object.Equals(sourceObject, targetObject);
        }

        public static bool operator !=(Out_Type_DictionaryInfo sourceObject, Out_Type_DictionaryInfo targetObject)
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
            table.Columns.Add("Role", typeof(int));
            table.Columns.Add("Content", typeof(string));
            //table.Columns.Add("ModifyTime", typeof(DateTime));
            return table;
        }

        public static void AddTableRow(DataTable table, Out_Type_DictionaryInfo out_Type_DictionaryInfo)
        {
            System.Data.DataRow dr = table.NewRow();

            dr["Id"] = out_Type_DictionaryInfo.id;
            dr["Name"] = out_Type_DictionaryInfo.name;
            table.Rows.Add(dr);
        }
        #endregion
    }
}