using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Models;
using BillingSystem.Services;
using System.Drawing;

namespace BillingSystem.Views.SystemSetting
{
    public partial class UserAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Code"]))
                {
                    //UserInfo info = UserMethods.CheckUser(Request.QueryString["Code"]);
                    //this.txtUserName.Text = !string.IsNullOrEmpty(info.Name) ? info.Name : string.Empty;
                    //this.txtIdCode.Text = !string.IsNullOrEmpty(info.Code) ? info.Code : string.Empty;
                    ////this.txtPassword.Text = !string.IsNullOrEmpty(info.Password) ? info.Password : string.Empty;
                    //this.txtEmail.Text = !string.IsNullOrEmpty(info.EMail) ? info.EMail : string.Empty;
                    //this.dropRole.SelectedValue = !string.IsNullOrEmpty(info.Role.ToString()) ? info.Role.ToString() : "1";
                    //this.txtContent.Text = !string.IsNullOrEmpty(info.content) ? info.content : string.Empty;
                    //this.txtPassword.Visible = false;
                    //this.Label1.Visible = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}