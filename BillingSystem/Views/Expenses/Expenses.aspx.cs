using BillingSystem.Common;
using BillingSystem.Models;
using BillingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Models;
using BillingSystem.Services;
using MySql.Data.MySqlClient;

namespace BillingSystem.Views
{
    public partial class Expenses : System.Web.UI.Page
    {
        private List<QueryElement> queryList = null;
        //private bool flag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["user"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ExpensesId"]))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayExpensesEditdiv();", true);
                        ExpensesInfo expensesInfo = ExpensesMethods.GetExpensesById(Convert.ToInt32(Request.QueryString["ExpensesId"]));
                        InitializeExpensesAdd(expensesInfo);
                        Session["expensensEditFlag"] = "true";
                        //flag = true;
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
                        InitializeExpensesAdd(new ExpensesInfo());
                    }
                    queryList = new List<QueryElement>();
                    BindExpensesListDataGrid(queryList);
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                    Alert.Show(this, "请先登录！");
                }
            }
        }

        private void BindExpensesListDataGrid(List<QueryElement> list)
        {
            ExpensesCollection coll = ExpensesMethods.GetExpensesList(list);
            this.ExpensesListDataGrid.DataSource = coll;
            this.ExpensesListDataGrid.DataBind();
            for (int i = 0; i < coll.Count; i++)
            {
                ExpensesInfo expenses = coll[i];
                CardInfo cardInfo = CardMethods.GetCardByCardNumber(expenses.CardNumber, expenses.OwnerId);
                string bank = StaticRescourse.DisplayBank(cardInfo.BankId);
                this.ExpensesListDataGrid.Items[i].Cells[4].Text = StaticRescourse.DisplaySpendType(expenses.SpendType);
                this.ExpensesListDataGrid.Items[i].Cells[6].Text = expenses.SpendDate.ToString("yyyy-MM-dd");
                this.ExpensesListDataGrid.Items[i].Cells[7].Text = StaticRescourse.DisplaySpendMode(expenses.SpendMode);
            }
        }

        protected void btnExpensesAdd_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayExpensesAdddiv();", true);
            Session["expensensEditFlag"] = "false";
            InitializeExpensesAdd(new ExpensesInfo());
        }

        protected void btnExpensesQuery_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayExpensesQuerydiv();", true);
            InitializeExpensesQuery();
        }

        /// <summary>
        /// 新增提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExpensesAddSubmit_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrEmpty(this.dropExpensesAddCardNumber.SelectedValue))
            {
                Alert.Show(this, "请输入卡号！");
                this.dropExpensesAddCardNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtExpensesAddAmount.Text.Trim()))
            {
                Alert.Show(this, "请输入支出金额！");
                this.txtExpensesAddAmount.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtExpensesAddSpendDate.Text.Trim()))
            {
                Alert.Show(this, "请输入支出日期！");
                this.txtExpensesAddSpendDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.dropExpensesAddOwner.SelectedValue))
            {
                Alert.Show(this, "请输入资产所有者！");
                this.dropExpensesAddOwner.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.dropExpensesAddSpendType.SelectedValue))
            {
                Alert.Show(this, "请输入消费方式！");
                this.dropExpensesAddSpendType.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtExpensesAddConsumerName.Text.Trim()))
            {
                Alert.Show(this, "请输入消费者！");
                this.txtExpensesAddConsumerName.Focus();
                return;
            }
            #endregion

            #region 赋值
            ExpensesInfo expensesInfo = new ExpensesInfo();
            if (Session["expensensEditFlag"].Equals("true"))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayExpensesEditdiv();", true);
                expensesInfo.Id = Convert.ToInt32(Request.QueryString["ExpensesId"]);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayExpensesAdddiv();", true);
            }
            expensesInfo.OwnerId = Convert.ToInt32(this.dropExpensesAddOwner.SelectedValue);
            expensesInfo.OwnerName = this.dropExpensesAddOwner.SelectedItem.Text;
            CardInfo cardInfo = CardMethods.GetCardById(Convert.ToInt32(this.dropExpensesAddCardNumber.SelectedValue));
            expensesInfo.CardId = Convert.ToInt32(this.dropExpensesAddCardNumber.SelectedValue);
            expensesInfo.CardNumber = cardInfo.CardNumber;
            expensesInfo.BankCardNumber = this.dropExpensesAddCardNumber.SelectedItem.Text;
            expensesInfo.SpendType = Convert.ToInt32(this.dropExpensesAddSpendType.SelectedValue);
            expensesInfo.HowToUse = this.txtExpensesAddHowToUse.Text.Trim();
            if (string.IsNullOrEmpty(this.txtExpensesAddPrice.Text.Trim()))
            {
                expensesInfo.Price = 0;
            }
            else
            {
                expensesInfo.Price = Convert.ToSingle(this.txtExpensesAddPrice.Text.Trim());
            }

            if (string.IsNullOrEmpty(this.txtExpensesAddNumber.Text.Trim()))
            {
                expensesInfo.Number = 0;
            }
            else
            {
                expensesInfo.Number = Convert.ToInt32(this.txtExpensesAddNumber.Text.Trim());
            }
            expensesInfo.Amount = Convert.ToSingle(this.txtExpensesAddAmount.Text.Trim());
            expensesInfo.SpendDate = Convert.ToDateTime(this.txtExpensesAddSpendDate.Text.Trim());
            expensesInfo.SpendMode = Convert.ToInt32(this.dropExpensesAddSpendMode.SelectedValue);
            UserInfo userInfo = UserMethods.GetUserByName(this.txtExpensesAddConsumerName.Text.Trim());
            if (userInfo.Id > 0)
            {
                expensesInfo.ConsumerId = userInfo.Id;
            }
            else
            {
                expensesInfo.ConsumerId = 0;
            }
            expensesInfo.ConsumerName = this.txtExpensesAddConsumerName.Text.Trim();
            expensesInfo.Content = this.txtExpensesAddContent.Text.Trim();
            #endregion
            int iSuccess = ExpensesMethods.InsertOrUpdatetoExpenses(expensesInfo);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayExpensesAdddiv();", true);
            if (iSuccess > 0)
            {
                Alert.Show(this, "新增一条收入成功！");
            }
            else if (iSuccess == -1)
            {
                Alert.Show(this, "修改成功！");
            }
            else
            {
                Alert.Show(this, "操作失败！");
            }
            InitializeExpensesAdd(new ExpensesInfo());
            queryList = new List<QueryElement>();
            BindExpensesListDataGrid(queryList);
        }

        protected void btnExpensesAddCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
            Session["expensensEditFlag"] = "false";
        }

       /// <summary>
       /// 查询提交
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void btnExpensesQuerySubmit_Click(object sender, EventArgs e)
        {
            #region 验证
            if (!string.IsNullOrEmpty(this.txtExpensesQueryBSpendDate.Text.Trim()) || !string.IsNullOrEmpty(this.txtExpensesQueryESpendDate.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(this.txtExpensesQueryBSpendDate.Text.Trim()) && string.IsNullOrEmpty(this.txtExpensesQueryESpendDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入一个时间段！");
                    this.txtExpensesQueryESpendDate.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(this.txtExpensesQueryBSpendDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtExpensesQueryESpendDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入一个时间段！");
                    this.txtExpensesQueryBSpendDate.Focus();
                    return;
                }
                else
                {
                    bool flag = HelperCommon.ValidDateTime(this.txtExpensesQueryBSpendDate.Text.Trim(), this.txtExpensesQueryESpendDate.Text.Trim());
                    if (!flag)
                    {
                        Alert.Show(this, "开始日期不能大于结束日期！");
                        this.txtExpensesQueryESpendDate.Focus();
                        return;
                    }
                }
            }
            #endregion
            queryList = new List<QueryElement>();

            if (!string.IsNullOrEmpty(this.txtExpensesQueryCardNumber.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "CardNumber", QueryElementType = MySqlDbType.String, Queryvalue = this.txtExpensesQueryCardNumber.Text.Trim() };
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.dropExpensesQuerySpendType.SelectedValue))
            {
                QueryElement query = new QueryElement { Queryname = "SpendType", QueryElementType = MySqlDbType.Int32, Queryvalue = Convert.ToInt32(this.dropExpensesQuerySpendType.SelectedValue) };
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.dropExpensesQuerySpendMode.SelectedValue))
            {
                QueryElement query = new QueryElement { Queryname = "SpendMode", QueryElementType = MySqlDbType.Int32, Queryvalue = Convert.ToInt32(this.dropExpensesQuerySpendMode.SelectedValue) };
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.txtExpensesQueryConsumerName.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "ConsumerName", QueryElementType = MySqlDbType.String, Queryvalue = this.txtExpensesQueryConsumerName.Text.Trim(), QueryOperation = "like" };
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.txtExpensesQueryBSpendDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtExpensesQueryESpendDate.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "SpendDate", QueryElementType = MySqlDbType.DateTime, Queryvalue = this.txtExpensesQueryBSpendDate.Text.Trim(), QueryOperation = ">=" };
                queryList.Add(query);
                query = new QueryElement { Queryname = "SpendDate", QueryElementType = MySqlDbType.DateTime, Queryvalue = this.txtExpensesQueryESpendDate.Text.Trim(), QueryOperation = "<" };
                queryList.Add(query);
            }

            BindExpensesListDataGrid(queryList);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayExpensesQuerydiv();", true);
            InitializeExpensesQuery();
        }

        protected void btnExpensesQueryCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
            Session["expensensEditFlag"] = "false";
        }

        /// <summary>
        /// 初始化卡号（新增）
        /// </summary>
        private void InitializeDropExpensesDropControl()
        {

            List<CardHelper> cardNumberList = new List<CardHelper>();
            List<CardHelper> cxList = new List<CardHelper>();

            CardCollection cardcoll = new CardCollection();      //返回的卡的collection
            cardcoll = CardMethods.GetCard(new List<QueryElement>());
            
            List<DropItem> card = new List<DropItem>();
            card.Add(new DropItem { ValueField = "", DisplayField = " " });

            for (int i = 0; i < cardcoll.Count; i++)
            {
                CardInfo info = cardcoll[i];
                cardNumberList.Add(new CardHelper { CardId = info.Id, BankId = info.BankId, CardNumber = info.CardNumber });
            }
            cxList.AddRange(cardNumberList.OrderBy(x=>x.CardNumber));
            cardNumberList.Clear();
            for (int i = 0; i < cxList.Count;i++ )
            {
                if (i == 0 || cxList[i].CardNumber != cxList[i - 1].CardNumber)
                {
                    cardNumberList.Add(new CardHelper { CardId = cxList[i].CardId, BankId = cxList[i].BankId, CardNumber = cxList[i].CardNumber });
                }
            }

            for (int i = 0; i < cardNumberList.Count; i++)
            {
                var cardInfo = cardNumberList[i];
                string bank = StaticRescourse.DisplayBank(cardInfo.BankId);
                card.Add(new DropItem { ValueField = cardInfo.CardId.ToString(), DisplayField = cardInfo.CardNumber + " " + bank });// +" "+bank 
            }
                this.dropExpensesAddCardNumber.DataSource = card;
            Helper.SetDropDownList(this.dropExpensesAddCardNumber);

            this.dropExpensesAddSpendMode.DataSource = StaticRescourse.GetSpendMode();
            Helper.SetDropDownList(this.dropExpensesAddSpendMode);

            this.dropExpensesAddSpendType.DataSource = StaticRescourse.GetSpendType();
            Helper.SetDropDownList(this.dropExpensesAddSpendType);
        }

        /// <summary>
        /// 新增初始化
        /// </summary>
        /// <param name="info"></param>
        private void InitializeExpensesAdd(ExpensesInfo info)
        {
            InitializeDropExpensesDropControl();

            if (info.Id > 0)
            {
                this.dropExpensesAddCardNumber.SelectedValue = info.CardId.ToString();
                this.dropExpensesAddCardNumber.Enabled = false;
                this.dropExpensesAddOwner.Enabled = true;
                this.dropExpensesAddOwner.SelectedValue = info.OwnerId.ToString();

                this.dropExpensesAddSpendMode.SelectedValue = info.SpendMode.ToString();
                this.dropExpensesAddSpendType.SelectedValue = info.SpendType.ToString();
                this.txtExpensesAddAmount.Text = info.Amount.ToString();
                this.txtExpensesAddSpendDate.Text = info.SpendDate.ToString("yyyy-MM-dd");
                this.txtExpensesAddConsumerName.Text = info.ConsumerName;
                this.txtExpensesAddHowToUse.Text = !string.IsNullOrEmpty(info.HowToUse) ? info.HowToUse : string.Empty;
                this.txtExpensesAddPrice.Text = !string.IsNullOrEmpty(info.Price.ToString()) ? info.Price.ToString() : string.Empty;
                this.txtExpensesAddNumber.Text = !string.IsNullOrEmpty(info.Number.ToString()) ? info.Number.ToString() : string.Empty;
                this.txtExpensesAddContent.Text = !string.IsNullOrEmpty(info.Content) ? info.Content : string.Empty;
            }
            else
            {
                this.dropExpensesAddCardNumber.Enabled = true;
                this.dropExpensesAddOwner.Enabled = false;
                this.dropExpensesAddCardNumber.SelectedValue = string.Empty;

                this.dropExpensesAddSpendMode.SelectedValue = string.Empty;
                this.dropExpensesAddSpendType.SelectedValue = string.Empty;
                this.txtExpensesAddAmount.Text = string.Empty;
                this.txtExpensesAddSpendDate.Text = string.Empty;
                this.txtExpensesAddConsumerName.Text = string.Empty;
                this.txtExpensesAddPrice.Text = string.Empty;
                this.txtExpensesAddNumber.Text = string.Empty;
                this.txtExpensesAddContent.Text = string.Empty;
            }
            dropExpensesAddCardNumber_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// 查询时初始化
        /// </summary>
        private void InitializeExpensesQuery()
        {
            this.txtExpensesQueryCardNumber.Text = string.Empty;
            this.dropExpensesQuerySpendMode.DataSource = StaticRescourse.GetSpendMode();
            Helper.SetDropDownList(this.dropExpensesQuerySpendMode);
            this.dropExpensesQuerySpendMode.SelectedValue = string.Empty;

            this.dropExpensesQuerySpendType.DataSource = StaticRescourse.GetSpendType();
            Helper.SetDropDownList(this.dropExpensesQuerySpendType);
            this.dropExpensesQuerySpendType.SelectedValue = string.Empty;

            this.txtExpensesQueryConsumerName.Text = string.Empty;
            this.txtExpensesQueryBSpendDate.Text = string.Empty;
            this.txtExpensesQueryESpendDate.Text = string.Empty;
        }

       /// <summary>
        /// 卡号选择SelectedIndexChanged事件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void dropExpensesAddCardNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.dropExpensesAddCardNumber.SelectedValue))
            {
                this.dropExpensesAddOwner.Enabled = true;
                List<DropItem> list = new List<DropItem>();
                list.Add(new DropItem { ValueField = "", DisplayField = " " });
                CardInfo cardInfo = CardMethods.GetCardById(Convert.ToInt32(this.dropExpensesAddCardNumber.SelectedValue));
                UserCollection coll = ExpensesMethods.GetOwnerByCardNumber(cardInfo.CardNumber);
                if (coll != null && coll.Count > 0)
                {
                    for (int i = 0; i < coll.Count; i++)
                    {
                        list.Add(new DropItem { ValueField = coll[i].Id.ToString(), DisplayField = coll[i].Name });
                    }
                    this.dropExpensesAddOwner.DataSource = list;
                    Helper.SetDropDownList(this.dropExpensesAddOwner);
                }
            }
            else
            {
                this.dropExpensesAddOwner.Enabled = false;
                this.dropExpensesAddOwner.DataSource = new List<DropItem>();
                this.dropExpensesAddOwner.SelectedValue = string.Empty;
            }
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void ExpensesListDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string id = string.Empty;
            int selectindex = e.Item.ItemIndex;
            if (e.CommandName == "ExpensesImageDelete")
            {
                id = this.ExpensesListDataGrid.Items[selectindex].Cells[0].Text;
                if (!string.IsNullOrEmpty(id))
                {
                    int iSuccess = ExpensesMethods.DeleteExpenses(Convert.ToInt32(id));
                    if (iSuccess > 0)
                    {
                        Alert.Show(this, "删除成功！");
                    }
                    else
                    {
                        Alert.Show(this, "删除失败！");
                    }
                    if (queryList == null)
                    {
                        queryList = new List<QueryElement>();
                    }
                    BindExpensesListDataGrid(queryList);
                }
            }
        }
    }
}