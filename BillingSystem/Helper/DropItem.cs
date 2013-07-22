using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class DropItem
    {
        private string _valueField;
        private string _displayField;

        public DropItem()
        {
            this._valueField = string.Empty;
            this._displayField = string.Empty;
        }

        public DropItem(string valueField,string displayField)
        {
            this._valueField = valueField;
            this._displayField = displayField;
        }

        public string ValueField
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }

        public string DisplayField
        {
            get
            {
                return _displayField;
            }
            set
            {
                _displayField = value;
            }
        }
    }
}
