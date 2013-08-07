using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Services;
using BillingSystem.DAL;
using BillingSystem.Models;

namespace BillingSystem.Views
{
    public partial class BillingSystemMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["UserCode"] == null || Session["UserCode"].ToString() == "")
                //{
                //    Response.Redirect("Login.aspx");
                //}
                //else
                //{
                //    UserInfo info= UserMethods.GetUserByCode(Session["UserCode"].ToString());
                //    Application["user"] = info.Code;
                //    this.labWel.Text = "欢迎您，"+info.Name;
                //}
            }

            //labWel.Text = "Welcome to login, " + Session["UserCode"];
        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public string GetUser()
        {
            if (Session["UserCode"] != null)
            {
                return Session["UserCode"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

    }
}