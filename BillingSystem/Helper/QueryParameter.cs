using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BillingSystem
{
    public class QueryParameter
    {
        private string _parameter;
        private MySqlDbType _parameterType;
        private object _parameterValue;
        private string _qConnector;

        public QueryParameter()
        {
        }

        /// <summary>
        /// 参数名
        /// </summary>
        public string QParameter
        {
            get
            {
                return _parameter;
            }
            set
            {
                _parameter = value;
            }
        }

        /// <summary>
        /// 参数类型
        /// </summary>
        public MySqlDbType QType
        {
            get
            {
                return _parameterType;
            }
            set
            {
                _parameterType = value;
            }
        }

        /// <summary>
        /// 参数值
        /// </summary>
        public object QVale
        {
            get
            {
                return _parameterValue;
            }
            set
            {
                _parameterValue = value;
            }
        }
    }
}