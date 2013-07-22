using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BillingSystem.Common
{
    public static class Helper
    {
        public static void SetDropDownList(DropDownList dropDownList)
        {
            dropDownList.DataTextField = "DisplayField";
            dropDownList.DataValueField = "ValueField";
            dropDownList.DataBind();
        }
    }
}