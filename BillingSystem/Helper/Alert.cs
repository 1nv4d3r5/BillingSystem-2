using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem
{
    public class Alert
    {
        public static void Show(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
    }
}