using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Models;
using BillingSystem.Services;
using FBJHelper;
using System.Drawing;
using System.Windows;

namespace BillingSystem.Views.SystemSetting
{
    public partial class UserSetting : System.Web.UI.Page
    {
        private UserCollection userColl = new UserCollection();
        private Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] strfields;
                string[] strvalues;
                if (Session["userSelectName"] != null && Session["userSelectValue"] != null)
                {
                    strfields = Session["userSelectName"].ToString().Split('¢');
                    strvalues = Session["userSelectValue"].ToString().Split('¢');
                }
                else
                {
                    strfields = null;
                    strvalues = null;
                }
                userColl = UserMethods.GetUser(strfields, strvalues);
                this.UserListDataGrid.DataSource = userColl;
                this.UserListDataGrid.DataBind();
            }
        }

        protected void btnUserAdd_Click(object sender, EventArgs e)
        {
            double height = rect.Height - rect.Height * 0.8;
            double width = rect.Width - rect.Width * 0.8;
            OpenNewWindow.OpenANewWindow(this.Page, "UserAdd.aspx", "UserAdd.aspx", width.ToString(), height.ToString(), "50", "50", "yes", true);
            Server.Transfer("UserAdd.aspx");
        }

        protected void btnUserSelect_Click(object sender, EventArgs e)
        {
            double height = rect.Height - rect.Height * 0.8;
            double width = rect.Width - rect.Width * 0.8;
            OpenNewWindow.OpenANewWindow(this.Page, "UserQuery.aspx", "UserQuery.aspx", width.ToString(), height.ToString(), "50", "50", "yes", true);
        }


    }
}