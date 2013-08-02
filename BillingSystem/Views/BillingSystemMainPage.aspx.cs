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
            //if (!IsPostBack)
            //{
            //    if (Session["UserCode"] == null || Session["UserCode"].ToString() == "")
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //}

            //labWel.Text = "Welcome to login, " + Session["UserCode"];
        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}