using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BillingSystem
{
    public class QueryElement
    {
        public QueryElement()
        {
            this._queryLogic = "AND";
            this._queryOperation = "=";
            this._queryMulitalue = false;
            this._queryMulitsplit = ",";
            this._queryMulitlogic = "OR";
            this._queryGroups = true;
        }

        private string _queryname;           //参数名

        public string Queryname
        {
            get { return _queryname; }
            set { _queryname = value; }
        }
        private MySqlDbType _queryElementType;      //值类型

        public MySqlDbType QueryElementType
        {
            get { return _queryElementType; }
            set { _queryElementType = value; }
        }
        private object _queryvalue;          //值

        public object Queryvalue
        {
            get { return _queryvalue; }
            set { _queryvalue = value; }
        }
        private string _queryLogic;          //条件间逻辑，默认为AND

        public string QueryLogic
        {
            get { return _queryLogic; }
            set { _queryLogic = value; }
        }
        private string _queryOperation;      //操作符，默认为=

        public string QueryOperation
        {
            get { return _queryOperation; }
            set { _queryOperation = value; }
        }
        private string _queryFormat;         //{0} 字段名；{1} 操作符；{2} 值

        public string QueryFormat
        {
            get { return _queryFormat; }
            set { _queryFormat = value; }
        }
        private bool _queryMulitalue;       //接受到的value值为多值参数，默认为false，类似于1,2,3需要转为类似条件T1.state = 1 OR T1.state = 2 OR 

        public bool QueryMulitalue
        {
            get { return _queryMulitalue; }
            set { _queryMulitalue = value; }
        }
        private string _queryMulitsplit;     //多值参数的分割符，默认为 ,

        public string QueryMulitsplit
        {
            get { return _queryMulitsplit; }
            set { _queryMulitsplit = value; }
        }
        private string _queryMulitlogic;     //多值参数时每个值条件之间的逻辑，默认为OR

        public string QueryMulitlogic
        {
            get { return _queryMulitlogic; }
            set { _queryMulitlogic = value; }
        }
        private bool _queryGroups;            //多值参数时，转换后的条件是否有括号，默认为true

        public bool QueryGroups
        {
            get { return _queryGroups; }
            set { _queryGroups = value; }
        }
    }
}