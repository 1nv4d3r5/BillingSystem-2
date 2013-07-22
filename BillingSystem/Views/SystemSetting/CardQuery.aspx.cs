using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Models;
using BillingSystem.Services;
using BillingSystem.Common;
using System.Text;

namespace BillingSystem.Views.SystemSetting
{
    public partial class CardQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DropItem> listUser = new List<DropItem>();

                this.labCardQueryTitle.Text = "卡信息维护--查询";
                Initialize();
            }
        }

        private void Initialize()
        {
        //    List<DropItem> listAccountType = new List<DropItem>();
        //    List<DropItem> listBank = new List<DropItem>();
        //    List<DropItem> listUser = new List<DropItem>();
        //    UserCollection userColl = new UserCollection();

        //    DropItem dr = new DropItem { ValueField ="",DisplayField=" "};
        //    listAccountType.Add(dr);
        //    listAccountType.AddRange(StaticRescourse.GetAccountType());
        //    this.dropCardQueryAccountType.DataSource = listAccountType;
        //    Helper.SetDropDownList(this.dropCardQueryAccountType);
        //    this.dropCardQueryAccountType.SelectedValue = string.Empty;


        //    listBank.Add(dr);
        //    listBank.AddRange(StaticRescourse.GetBank());
        //    this.dropCardQueryBank.DataSource = listBank;
        //    Helper.SetDropDownList(this.dropCardQueryBank);
        //    this.dropCardQueryBank.SelectedValue = string.Empty;


        //    userColl = UserMethods.GetUser(null, null);
        //    if (userColl != null && userColl.Count > 0)
        //    {
        //        listUser.Add(dr);
        //        foreach (var userInfo in userColl)
        //        {
        //            listUser.Add(new DropItem { ValueField = userInfo.Id.ToString(), DisplayField = userInfo.Name });
        //        }
        //        this.dropCardQueryUser.DataSource = listUser;
        //    }
        //    this.dropCardQueryUser.DataSource = listUser;
        //    Helper.SetDropDownList(this.dropCardQueryUser);
        //    this.dropCardQueryUser.SelectedValue = string.Empty;

        //    this.txtCardQueryBOpenDate.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
        //    this.txtCardQueryEOpenDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        //}

        //protected void btnCardQuerySelect_Click(object sender, EventArgs e)
        //{
        //    StringBuilder whereString = new StringBuilder();
        //    if (!string.IsNullOrEmpty(this.txtCardQueryCardNumber.Text.Trim()))
        //    {
        //        whereString.AppendFormat(" AND CardNumber ='{0}'",this.txtCardQueryCardNumber.Text.Trim());
        //    }

        //    if (!string.IsNullOrEmpty(this.dropCardQueryAccountType.SelectedValue))
        //    {
        //        whereString.AppendFormat(" AND AccountType={0}",Convert.ToInt32(this.dropCardQueryAccountType.SelectedValue));
        //    }

        //    if (!string.IsNullOrEmpty(this.dropCardQueryBank.SelectedValue))
        //    {
        //        whereString.AppendFormat(" AND BankId={0}",Convert .ToInt32(this.dropCardQueryBank.SelectedValue));
        //    }

        //    if (!string.IsNullOrEmpty(this.dropCardQueryUser.SelectedValue))
        //    {
        //        whereString.AppendFormat(" AND UserId={0}",Convert.ToInt32(this.dropCardQueryUser.SelectedValue));
        //    }

        //    if (!string.IsNullOrEmpty(this.txtCardQueryBOpenDate.Text.Trim()))
        //    {
        //        whereString.AppendFormat(" AND OpenDate>='{0}'",this.txtCardQueryBOpenDate.Text.Trim());
        //    }

        //    if (!string.IsNullOrEmpty(this.txtCardQueryEOpenDate.Text.Trim()))
        //    {
        //        whereString.AppendFormat(" AND OpenDate<'{0}'",this.txtCardQueryEOpenDate.Text.Trim());
        //    }

        //    if (whereString.Length > 0)
        //    {
        //        Session["CardSelectString"] = whereString.ToString();
        //    }
        //    else
        //    {
        //        Session["CardSelectString"] = string.Empty;
        //    }
        //    this.ClientScript.RegisterStartupScript(this.GetType(), "", "closeWin();", true);
        }

        protected void btnCardQueryCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "closeWinCanel();", true);
        }
    }
}