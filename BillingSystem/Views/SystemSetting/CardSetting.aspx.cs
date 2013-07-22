using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.DAL;
using BillingSystem.Models;
using BillingSystem.Services;
using System.Drawing;
using BillingSystem.Common;
using BillingSystem;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BillingSystem.Views
{
    public partial class CardSetting : System.Web.UI.Page
    {
        private CardCollection cardColl = new CardCollection();
        private Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
        private List<QueryElement> queryList = new List<QueryElement>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayCardEditdiv();", true);
                    CardInfo info = CardMethods.GetCardById(Convert.ToInt32(Request.QueryString["Id"]));
                    Initialize(info);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
                }
                BindDataGrid(queryList);
            }
        }

        private void BindDataGrid(List<QueryElement> list)
        {
            cardColl = CardMethods.GetCard(list);
            this.CardListDataGrid.DataSource = cardColl;
            this.CardListDataGrid.DataBind();
            for (int i = 0; i < cardColl.Count; i++)
            {
                this.CardListDataGrid.Items[i].Cells[2].Text = StaticRescourse.DisplayAccountType(cardColl[i].AccountType);
                this.CardListDataGrid.Items[i].Cells[3].Text = StaticRescourse.DisplayBank(cardColl[i].BankId);
            }
        }

        protected void btnCardAdd_Click(object sender, EventArgs e)
        {
            CardInfo cardInfo = new CardInfo();
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayCardAdddiv();", true);
            ClearEditForm();
            Initialize(cardInfo);
        }

        protected void btnCardQuery_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayCardQuerydiv();", true);
            InitializeQuery();
        }

        protected void btnCardEditSave_Click(object sender, EventArgs e)
        {
            int isuccess = 0;
            CardEditSubmit(ref isuccess);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayCardAdddiv();", true);
            if (isuccess > 0)
            {
                Alert.Show(this, "新增一账户成功！");
                ClearEditForm();
            }
            else if (isuccess == -1)
            {
                Alert.Show(this, "修改成功！");
                ClearEditForm();
            }
            else
            {
                Alert.Show(this,"操作失败！");
            }
            BindDataGrid(queryList);
        }

        protected void btnCardEditCanel_Click(object sender, EventArgs e)
        {
            //this.divSet.Visible = true;
            //this.cardQuery.Visible = false;
            //this.cardEdit.Visible = false;
            //this.divCardTitle.InnerText = "卡信息管理";
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
        }

        protected void btnCardQuerySelect_Click(object sender, EventArgs e)
        {
            queryList = new List<QueryElement>();
            CardQuerySumbit(ref queryList);
            BindDataGrid(queryList);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayCardQuerydiv();", true);
            InitializeQuery();
        }

        protected void btnCardQueryCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
        }

        private void CardEditSubmit(ref int i)
        {
           this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayCardAdddiv();", true);
            #region 验证
           // if (string.IsNullOrEmpty(Request.Form["txtAddCardNumber"].ToString()))
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
            //cardInfo.CardNumber = Request.Form["txtAddCardNumber"].ToString().Trim();
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

            i = CardMethods.InsertOrUpdatetoCard(cardInfo);
        }

        private void CardQuerySumbit(ref List<QueryElement> parlist)
        {
            string str1 = this.txtCardQueryBOpenDate.Text.Trim();
            string str2 = this.txtCardQueryEOpenDate.Text.Trim();

            if (!string.IsNullOrEmpty(str1) || !string.IsNullOrEmpty(str2))
            {
                if (!string.IsNullOrEmpty(this.txtCardQueryBOpenDate.Text.Trim()))
                {
                    string[] bd = str1.Split('-');
                    DateTime bdate = new DateTime(Convert.ToInt32(bd[0]), Convert.ToInt32(bd[1]), Convert.ToInt32(bd[2]));
                    if (string.IsNullOrEmpty(this.txtCardQueryEOpenDate.Text.Trim()))
                    {
                        Alert.Show(this, "请输入一个时间段！");
                        this.txtCardQueryEOpenDate.Focus();
                        return;
                    }
                    else
                    {
                        string[] ed = str2.Split('-');
                        DateTime edate = new DateTime(Convert.ToInt32(ed[0]), Convert.ToInt32(ed[1]), Convert.ToInt32(ed[2]));
                        if (bdate > edate)
                        {
                            Alert.Show(this, "开始日期不能大于结束日期！");
                            return;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(this.txtCardQueryEOpenDate.Text.Trim()))
                {
                    string[] bd = str1.Split('-');
                    DateTime bdate = new DateTime(Convert.ToInt32(bd[0]), Convert.ToInt32(bd[1]), Convert.ToInt32(bd[2]));
                    if (string.IsNullOrEmpty(this.txtCardQueryBOpenDate.Text.Trim()))
                    {
                        Alert.Show(this, "请输入一个时间段！");
                        this.txtCardQueryEOpenDate.Focus();
                    }
                    else
                    {
                        string[] ed = str2.Split('-');
                        DateTime edate = new DateTime(Convert.ToInt32(ed[0]), Convert.ToInt32(ed[1]), Convert.ToInt32(ed[2]));
                        if (bdate > edate)
                        {
                            Alert.Show(this, "开始日期不能大于结束日期！");
                            return;
                        }
                    }
                }
            }

            QueryElement queryElement = null;

            if (!string.IsNullOrEmpty(this.txtCardQueryCardNumber.Text.Trim()))
            {
                queryElement = new QueryElement { Queryname = "CardNumber", QueryElementType = MySqlDbType.String, Queryvalue = this.txtCardQueryCardNumber.Text.Trim() };
                parlist.Add(queryElement);
            }

            if (!string.IsNullOrEmpty(this.dropCardQueryAccountType.SelectedValue))
            {
                queryElement = new QueryElement { Queryname = "AccountType", QueryElementType = MySqlDbType.Int32, Queryvalue = Convert.ToInt32(this.dropCardQueryAccountType.SelectedValue.Trim()) };
                parlist.Add(queryElement);
            }

            if (!string.IsNullOrEmpty(this.dropCardQueryBank.SelectedValue))
            {
                queryElement = new QueryElement { Queryname = "BankId", QueryElementType = MySqlDbType.Int32, Queryvalue = Convert.ToInt32(this.dropCardQueryBank.SelectedValue.Trim()) };
                parlist.Add(queryElement);
            }

            if (!string.IsNullOrEmpty(this.dropCardQueryUser.SelectedValue))
            {
                queryElement = new QueryElement { Queryname = "UserId", QueryElementType = MySqlDbType.Int32, Queryvalue = Convert.ToInt32(this.dropCardQueryUser.SelectedValue.Trim()) };
                parlist.Add(queryElement);
            }

            if (!string.IsNullOrEmpty(this.txtCardQueryBOpenDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtCardQueryEOpenDate.Text.Trim()))
            {
                queryElement = new QueryElement { Queryname = "OpenDate", QueryElementType = MySqlDbType.DateTime, Queryvalue = Convert.ToDateTime(this.txtCardQueryBOpenDate.Text.Trim()), QueryOperation = ">=" };
                parlist.Add(queryElement);

                queryElement = new QueryElement { Queryname = "OpenDate", QueryElementType = MySqlDbType.DateTime, Queryvalue = Convert.ToDateTime(this.txtCardQueryEOpenDate.Text.Trim()), QueryOperation = "<" };
                parlist.Add(queryElement);
            }
        }

        private void Initialize(CardInfo info)
        {
            List<DropItem> listUser = new List<DropItem>();
            UserCollection userColl = new UserCollection();
            UserInfo loginInfo = new UserInfo();

            if (Session["UserCode"] != null)
            {
                loginInfo = UserMethods.CheckUser(Session["UserCode"].ToString());
            }

            userColl = UserMethods.GetUser(new List<QueryElement>());
            if (userColl != null && userColl.Count > 0)
            {
                foreach (var userInfo in userColl)
                {
                    listUser.Add(new DropItem { ValueField = userInfo.Id.ToString(), DisplayField = userInfo.Name });
                }
            }

            this.dropAddBank.DataSource = StaticRescourse.GetBank();
            Helper.SetDropDownList(this.dropAddBank);

            this.dropAddCardOwner.DataSource = listUser;
            Helper.SetDropDownList(this.dropAddCardOwner);

            this.dropAddCardUser.DataSource = listUser;
            Helper.SetDropDownList(this.dropAddCardUser);

            this.dropCardAddAccountType.DataSource = StaticRescourse.GetAccountType();
            Helper.SetDropDownList(this.dropCardAddAccountType);

            if (info.Id > 0)
            {
                string str =info.OpenDate.ToString("yyyy-MM-dd");
                int date = Convert.ToInt32(str.Substring(0,4)+str.Substring(5,2)+str.Substring(8,2));
                this.dropAddBank.SelectedValue = info.BankId.ToString();
                this.dropAddCardOwner.SelectedValue = info.OwnerId.ToString();
                this.dropAddCardUser.SelectedValue = info.UserId.ToString();
                this.dropCardAddAccountType.SelectedValue = info.AccountType.ToString();
                this.txtAddCardNumber.Text = info.CardNumber;
                this.txtCardAddContent.Text = !string.IsNullOrEmpty(info.Content) ? info.Content : string.Empty;
                this.txtAddBankName.Text = !string.IsNullOrEmpty(info.BankName) ? info.BankName : string.Empty;
                this.txtAddCardOpenDate.Text = date > 20000101 ? info.OpenDate.ToString("yyyy-MM-dd") : string.Empty;
            }
            else
            {
                this.dropAddBank.SelectedIndex = 0;
                this.dropCardAddAccountType.SelectedIndex = 0;
                //this.dropAddCardOwner.SelectedValue = loginInfo.Id.ToString();
                //this.dropAddCardUser.SelectedValue = loginInfo.Id.ToString();
                this.txtAddCardOpenDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void InitializeQuery()
        {
            List<DropItem> listQueryAccountType = new List<DropItem>();
            List<DropItem> listBank = new List<DropItem>();
            List<DropItem> listUser = new List<DropItem>();
            UserCollection userColl = new UserCollection();

            DropItem dr = new DropItem { ValueField = "", DisplayField = " " };
            listQueryAccountType.Add(dr);
            listQueryAccountType.AddRange(StaticRescourse.GetAccountType());
            this.dropCardQueryAccountType.DataSource = listQueryAccountType;
            Helper.SetDropDownList(this.dropCardQueryAccountType);
            this.dropCardQueryAccountType.SelectedValue = string.Empty;


            listBank.Add(dr);
            listBank.AddRange(StaticRescourse.GetBank());
            this.dropCardQueryBank.DataSource = listBank;
            Helper.SetDropDownList(this.dropCardQueryBank);
            this.dropCardQueryBank.SelectedValue = string.Empty;


            userColl = UserMethods.GetUser(new List<QueryElement>());
            if (userColl != null && userColl.Count > 0)
            {
                listUser.Add(dr);
                foreach (var userInfo in userColl)
                {
                    listUser.Add(new DropItem { ValueField = userInfo.Id.ToString(), DisplayField = userInfo.Name });
                }
                this.dropCardQueryUser.DataSource = listUser;
            }
            this.dropCardQueryUser.DataSource = listUser;
            Helper.SetDropDownList(this.dropCardQueryUser);
            this.dropCardQueryUser.SelectedValue = string.Empty;

            //this.txtCardQueryBOpenDate.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            //this.txtCardQueryEOpenDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.txtCardQueryCardNumber.Text = string.Empty;
            this.txtCardQueryBankName.Text = string.Empty;
            this.txtCardQueryBOpenDate.Text = string.Empty;
            this.txtCardQueryEOpenDate.Text = string.Empty;
        }

        private void ClearEditForm()
        {
            this.txtAddBankName.Text = string.Empty;
            this.txtAddCardNumber.Text = string.Empty;
            this.txtAddCardOpenDate.Text = string.Empty;
            this.dropCardAddAccountType.SelectedValue = "1";
            this.dropAddBank.SelectedValue = "1";
            this.dropAddCardOwner.SelectedIndex = 0;
            this.dropAddCardUser.SelectedIndex = 0;
            this.txtCardAddContent.Text = string.Empty;
        }

        private void ClearQueryForm()
        {
            this.txtCardQueryCardNumber.Text = string.Empty;
            this.dropCardQueryAccountType.SelectedValue = string.Empty;
            this.dropCardQueryBank.SelectedValue = string.Empty;
            this.dropCardQueryUser.SelectedValue = "";
            this.txtCardQueryBankName.Text = string.Empty;
            this.txtCardQueryBOpenDate.Text = string.Empty;
            this.txtCardQueryEOpenDate.Text = string.Empty;
        }

        protected void CardListDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            TableCell itemcell = e.Item.Cells[0];
            string ids = itemcell.Text;
            int id = Convert.ToInt32(ids);
            int iSuccess = CardMethods.DeleteCard(id);
            if (iSuccess == 1)
            {
                Alert.Show(this, "删除成功！");
            }
            else
            {
                Alert.Show(this,"删除失败！");
            }
            if (queryList == null)
            {
                queryList = new List<QueryElement>();
            }
            BindDataGrid(queryList);
        }
    }
}