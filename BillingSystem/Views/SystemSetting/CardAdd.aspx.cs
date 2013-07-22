using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Common;
using BillingSystem.Models;
using BillingSystem.Services;

namespace BillingSystem.Views.SystemSetting
{
    public partial class CardAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CardNumber"]))
                {
                    this.labTitle.Text = "卡信息维护--编辑";
                    this.txtAddCardNumber.Enabled = false;
                    this.dropAddCardOwner.Enabled = false;
                    this.dropAddBank.Enabled = false;
                    this.dropCardAddAccountType.Enabled = false;
                    this.txtAddCardOpenDate.Enabled = false;
                    this.dropAddCardUser.Focus();
                    CardInfo cardInfo = CardMethods.GetCardByCardNumber(Request.QueryString["CardNumber"]);
                    InitializeEdit(cardInfo);
                }
                else
                {
                    this.labTitle.Text = "卡信息维护--新增";
                    this.txtAddCardNumber.Focus();
                    Initialize();
                }
            }
        }

        private void Initialize()
        {

            List<DropItem> listOwner = new List<DropItem>();
            List<DropItem> listuser = new List<DropItem>();
            listuser.Add(new DropItem { ValueField = "", DisplayField = " " });

            this.dropAddBank.DataSource = StaticRescourse.GetBank();
            Helper.SetDropDownList(this.dropAddBank);
            this.dropAddBank.SelectedIndex = 0;

            UserCollection userColl = new UserCollection();
            //userColl = UserMethods.GetUser(null, null);
            if (userColl != null && userColl.Count > 0)
            {
                foreach (var userInfo in userColl)
                {
                    listOwner.Add(new DropItem { ValueField = userInfo.Id.ToString(), DisplayField = userInfo.Name });
                    listuser.Add(new DropItem { ValueField = userInfo.Id.ToString(), DisplayField = userInfo.Name });
                }
            }
            this.dropAddCardOwner.DataSource = listOwner;
            Helper.SetDropDownList(this.dropAddCardOwner);
            this.dropAddCardOwner.SelectedIndex = 0;
            this.dropAddCardUser.DataSource = listuser;
            Helper.SetDropDownList(this.dropAddCardUser);
            this.dropAddCardUser.SelectedIndex = 0;
            this.txtAddCardOpenDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            this.dropCardAddAccountType.DataSource = StaticRescourse.GetAccountType();
            Helper.SetDropDownList(this.dropCardAddAccountType);
            this.dropCardAddAccountType.SelectedIndex = 0;
        }

        private void InitializeEdit(CardInfo info)
        {
            List<DropItem> listOwner = new List<DropItem>();
            List<DropItem> listuser = new List<DropItem>();
            listuser.Add(new DropItem { ValueField = "", DisplayField = " " });
            this.dropAddBank.DataSource = StaticRescourse.GetBank();
            Helper.SetDropDownList(this.dropAddBank);
            this.dropAddBank.SelectedValue = info.BankId.ToString();

            UserCollection userColl = new UserCollection();
            //userColl = UserMethods.GetUser(null, null);
            if (userColl != null && userColl.Count > 0)
            {
                foreach (var userInfo in userColl)
                {
                    listOwner.Add(new DropItem { ValueField = userInfo.Id.ToString(), DisplayField = userInfo.Name });
                    listuser.Add(new DropItem { ValueField = userInfo.Id.ToString(), DisplayField = userInfo.Name });
                }
            }
            this.dropAddCardOwner.DataSource = listOwner;
            Helper.SetDropDownList(this.dropAddCardOwner);
            this.dropAddCardOwner.SelectedValue=info.OwnerId.ToString();
            this.dropAddCardUser.DataSource = listuser;
            Helper.SetDropDownList(this.dropAddCardUser);
            this.dropAddCardUser.SelectedValue=info.UserId>0?info.UserId.ToString():string.Empty;
            this.txtAddCardOpenDate.Text = !string.IsNullOrEmpty(info.OpenDate.ToString("yyyy-MM-dd")) ? info.OpenDate.ToString("yyyy-MM-dd") : string.Empty;

            this.dropCardAddAccountType.DataSource = StaticRescourse.GetAccountType();
            Helper.SetDropDownList(this.dropCardAddAccountType);
            this.dropCardAddAccountType.SelectedValue = info.AccountType.ToString();
            this.txtAddCardNumber.Text = info.CardNumber;
            this.txtAddBankName.Text = !string.IsNullOrEmpty(info.BankName) ? info.BankName : string.Empty;
            this.txtCardAddContent.Text = !string.IsNullOrEmpty(info.Content) ? info.Content : string.Empty;
        }

        protected void btnCardAddCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "closeWin();", true);
        }

        protected void btnCardAddSave_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrEmpty(this.txtAddCardNumber.Text.Trim()))
            {
                Alert.Show(this, "请输入卡号！");
                this.txtAddCardNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtAddCardOpenDate.Text.Trim()))
            {
                Alert.Show(this, "开户日期不能为空！");
                this.txtAddCardOpenDate.Focus();
                return;
            }
            #endregion

            CardInfo cardInfo = new CardInfo();

            cardInfo.BankId = Convert.ToInt32(this.dropAddBank.SelectedValue);
            cardInfo.CardNumber = this.txtAddCardNumber.Text.Trim();
            cardInfo.AccountType = Convert.ToInt32(this.dropCardAddAccountType.SelectedValue);
            cardInfo.OwnerId = Convert.ToInt32(this.dropAddCardOwner.SelectedValue);
            cardInfo.OwnerCode = UserMethods.GetUserById(Convert.ToInt32(this.dropAddCardOwner.SelectedValue)).Code;
            if (!string.IsNullOrEmpty(this.dropAddCardUser.SelectedValue))
            {
                cardInfo.UserId = Convert.ToInt32(this.dropAddCardUser.SelectedValue);
                cardInfo.UserCode = UserMethods.GetUserById(Convert.ToInt32(this.dropAddCardUser.SelectedValue)).Code;
            }
            else
            {
                cardInfo.UserId = 0;
                cardInfo.UserCode = string.Empty;
            }
            cardInfo.BankName = this.txtAddBankName.Text.Trim();
            cardInfo.OpenDate = Convert.ToDateTime(this.txtAddCardOpenDate.Text.Trim());
            cardInfo.Content = this.txtCardAddContent.Text.Trim();

            int i = CardMethods.InsertOrUpdatetoCard(cardInfo);
            if (i > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "closeWin();", true);
            }
        }
    }
}