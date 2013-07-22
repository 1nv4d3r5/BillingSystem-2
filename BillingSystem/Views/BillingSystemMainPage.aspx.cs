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

        protected void Income_Click(object sender, EventArgs e)
        {
            Session["Index"] = 1;
            //this.navigate.Src = "http://localhost:4926/Views/Navigate.aspx";
            //this.navigate.Src = "~/Views/Navigate.aspx";
            //this.content.Src = "~/Salary.aspx";
            //this.content.Src = "~/Views/InCome.aspx";InCome
            //this.content.Src = "~/Views/InCome.aspx";

        }

        protected void Expenses_Click(object sender, EventArgs e)
        {
            Session["Index"] = 2;
        }

        protected void taobao_Click(object sender, EventArgs e)
        {
            Session["Index"] = 3;
        }

        //protected void sysSet_Click(object sender, EventArgs e)
        //{
        //    Session["Index"] = 0;
        //    this.content.Src = "~/Views/SystemSetting/SystemSetting.aspx";
        //}

        //public void LoadContentPage()
        //{
        //    if ((int)Session["Index"] == 1)
        //    {
        //        this.content.Src = "~/Views/Salary.aspx";
        //    }
        //    else if ((int)Session["Index"] == 2)
        //    {
        //        this.content.Src = "~/Views/Salary.aspx";

        //    }
        //    else if ((int)Session["Index"] == 3)
        //    {
        //        this.content.Src = "~/Views/Salary.aspx";
        //    }
        //    else if ((int)Session["Index"] == 0)
        //    {
        //        this.content.Src = "~/Views/Salary.aspx";
        //    }
        //}

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}