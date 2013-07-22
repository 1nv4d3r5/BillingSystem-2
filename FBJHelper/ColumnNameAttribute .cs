using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBJHelper
{
    public class ColumnNameAttribute : Attribute
    {
        /// <summary>   
        /// 类属性对应的列名   
        /// </summary>   
        public string ColumnName { get; set; }
        /// <summary>   
        /// 构造函数   
        /// </summary>   
        /// <param name="columnName">类属性对应的列名</param>   
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
