using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace BillingSystem.Views.SystemSetting
{
    public partial class UserQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUserQuerySave_Click(object sender, EventArgs e)
        {
            //int pageControlCount = Page.Controls.Count;
            //int count = 0;
           
            //for (int i = 0; i < pageControlCount; i++)
            //{
            //    foreach(var control in Page.Controls[i].Controls)
            //    {
            //        if (control is TextBox && !string.IsNullOrEmpty((control as TextBox).Text))  //) ||(control is DropDownList && !string.IsNullOrEmpty((control as DropDownList).SelectedValue))
            //        {
            //            count += 1;
            //        }
            //    }
            //}
            //if (count > 0)
            //{
            //    string[] strFields = new string[count];
            //    string[] strValues = new string[count];
            //    for (int i = 0,j=0; i < pageControlCount; i++)
            //    {
            //        foreach (var control in Page.Controls[i].Controls)
            //        {
            //            if (control is TextBox && !string.IsNullOrEmpty((control as TextBox).Text))
            //            {
            //                if ((control as TextBox).ID.Equals("txtUserIdCodeSelect"))
            //                {
            //                    strFields[j] = "Code";
            //                }
            //            }
            //        }
            //    }
            //}



            //StringBuilder strFields = new StringBuilder();
            //StringBuilder strValues = new StringBuilder();  //¢
            //if (!string.IsNullOrEmpty(this.txtUserNameSelect.Text.Trim()))
            //{
            //    strFields.Append("Name");
            //    strValues.AppendFormat("{0}", this.txtUserNameSelect.Text.Trim());
            //}

            //if (!string.IsNullOrEmpty(this.txtUserIdCodeSelect.Text.Trim()))
            //{
            //    if (strFields.Length>0)
            //    {
            //        strFields.Append("¢");
            //    }
            //    if (strValues.Length > 0)
            //    {
            //        strValues.Append("¢");
            //    }
            //    strFields.Append("Code");
            //    strValues.AppendFormat("{0}", this.txtUserIdCodeSelect.Text.Trim());
            //}

            //if (strFields.Length > 0)
            //{
            //    Session["userSelectName"] = strFields.ToString();
            //}
            //else
            //{
            //    Session["userSelectName"] = null;
            //}

            //if (strValues.Length > 0)
            //{
            //    Session["userSelectValue"] = strValues.ToString();
            //}
            //else
            //{
            //    Session["userSelectValue"] = null;
            //}
            //this.ClientScript.RegisterStartupScript(this.GetType(), "", "closeWinWindow()", true);
        }

        protected void btnUserQueryCancel_Click(object sender, EventArgs e)
        {
            //this.ClientScript.RegisterStartupScript(this.GetType(), "", "closeWinWindow()", true);
        }
    }
}