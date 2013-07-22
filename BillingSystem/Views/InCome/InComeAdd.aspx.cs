using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Proxy;
using BillingSystem.Models;
using BillingSystem.Common;

namespace BillingSystem
{
    public partial class InComeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitDropDownList();
            }
        }

        protected void dropPrefix_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitRelevanceDropDownList();
        }

        private void InitDropDownList()
        {
            #region 收入类型
            this.dropInComeType.DataSource = StaticRescourse.GetIncomeType();
            Helper.SetDropDownList(this.dropInComeType);
            #endregion

            #region 存款类型前缀
            this.dropPrefix.DataSource = StaticRescourse.GetRateType();
            Helper.SetDropDownList(this.dropPrefix);
            #endregion
            InitRelevanceDropDownList();
        }

        private void InitRelevanceDropDownList()
        {
            #region 利率
            this.dropRate.DataSource = StaticRescourse.GetRate(this.dropPrefix.SelectedItem.Text);
            Helper.SetDropDownList(this.dropRate);
            #endregion

            #region 存款类型
           // this.dropMode.DataSource = StaticRescourse.GetStatus(this.dropPrefix.SelectedItem.Text);
            Helper.SetDropDownList(this.dropMode);
            #endregion
        }

        //private void SetDropDownList(DropDownList dropDownList)
        //{
        //    dropDownList.DataTextField = "DisplayField";
        //    dropDownList.DataValueField = "ValueField";
        //    dropDownList.DataBind();
        //}

        private void InitCardNumber()
        {
            //this.dropCardNumber.DataSource = CardProxy.GetCard(string.Empty);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dropCardNumber.SelectedItem.Text.Trim()))
            {
                Alert.Show(this,"请选择卡号！");
                this.dropCardNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtAmount.Text.Trim()))
            {
                Alert.Show(this, "请输入收入金额！");
                this.txtAmount.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.depositDate.Text.Trim()))
            {
                Alert.Show(this,"请输入存入日期！");
                this.depositDate.Focus();
                return;
            }
            if (this.dropMode.SelectedValue != "1")
            {
                if (string.IsNullOrEmpty(this.bdate.Text.Trim()))
                {
                    Alert.Show(this, "请输入开始日期！");
                    this.bdate.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.edate.Text.Trim()))
                {
                    Alert.Show(this, "请输入结束日期！");
                    this.edate.Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(this.DepositorName.Text.Trim()))
            {
                Alert.Show(this,"请输入存款人！");
                this.DepositorName.Focus();
                return;
            }

        }
    }
}