using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BillingSystem.DAL;
using BillingSystem.Models;
using BillingSystem.Common;
using BillingSystem.Services;
using MySql.Data.MySqlClient;

namespace BillingSystem.Views
{
    public partial class Income : System.Web.UI.Page
    {
        private List<QueryElement> queryList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["user"] != null)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["IncomeId"])) //带参数访问为编辑状态
                    {
                        Session["editFlag"] = "true";
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayEditIncomediv();", true);
                        CashIncomeInfo cashInfo = CashIncomeMethods.GetCashIncomeById(Convert.ToInt32(Request.QueryString["IncomeId"]));
                        InitializeIncomeAdd(cashInfo);
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
                    }

                    queryList = new List<QueryElement>();
                    BindIncomeListDataGrid(queryList);
                }
                else
                {
                    Response.Redirect("~/Views/Login.aspx");
                    Alert.Show(this, "请先登录！");
                }

            }
        }

        private void BindIncomeListDataGrid(List<QueryElement> list)
        {
            CashIncomeCollection coll = CashIncomeMethods.GetCashIncome(list);
            this.IncomeListDataGrid.DataSource = coll;
            this.IncomeListDataGrid.DataBind();
            for (int i = 0; i < coll.Count; i++)
            {
                CashIncomeInfo cashInfo = coll[i];
                CardInfo cardInfo = CardMethods.GetCardByCardNumber(cashInfo.CardNumber,cashInfo.OwnerId);
                string bank = StaticRescourse.DisplayBank(cardInfo.BankId);
                this.IncomeListDataGrid.Items[i].Cells[1].Text = StaticRescourse.DisplayIncomeStatus(cashInfo.Status);
                this.IncomeListDataGrid.Items[i].Cells[4].Text = StaticRescourse.DisplayIncomeType(cashInfo.IncomeType);
                this.IncomeListDataGrid.Items[i].Cells[6].Text = StaticRescourse.DisplayMode(cashInfo.Mode);
                this.IncomeListDataGrid.Items[i].Cells[7].Text = StaticRescourse.DisplayRate(cashInfo.Rate);
                this.IncomeListDataGrid.Items[i].Cells[8].Text = cashInfo.DepositDate.ToString("yyyy-MM-dd");
                if (cashInfo.AutoSave == 1)
                {
                    this.IncomeListDataGrid.Items[i].Cells[12].Text = "是";
                }
                else
                {
                    this.IncomeListDataGrid.Items[i].Cells[12].Text = "否";
                }
                if (HelperCommon.CompareAccordToRequired(cashInfo.BDate))
                {
                    this.IncomeListDataGrid.Items[i].Cells[9].Text = cashInfo.BDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    this.IncomeListDataGrid.Items[i].Cells[9].Text = string.Empty;
                }
                if (HelperCommon.CompareAccordToRequired(cashInfo.EDate))
                {
                    this.IncomeListDataGrid.Items[i].Cells[10].Text = cashInfo.EDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    this.IncomeListDataGrid.Items[i].Cells[10].Text = string.Empty;
                }

                this.IncomeListDataGrid.Items[i].Cells[13].Text = StaticRescourse.DisplayIncomeDepositMode(cashInfo.DepositMode);
            }
        }

        protected void btnIncomeEditSave_Click(object sender, EventArgs e)
        {
            CashIncomeInfo info = new CashIncomeInfo();
            #region 验证
            if (Session["editFlag"].Equals("true"))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayEditIncomediv();", true);
                info.Id = Convert.ToInt32(Request.QueryString["IncomeId"]);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayAddIncomediv();", true);
            }
            if (string.IsNullOrEmpty(this.dropIncomeAddCardNumber.SelectedValue))
            {
                Alert.Show(this, "请选择卡号！");
                this.dropIncomeAddCardNumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.dropIncomeAddInComeType.SelectedValue))
            {
                Alert.Show(this, "请输入收入类型！");
                this.dropIncomeAddInComeType.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.dropIncomeAddMode.SelectedValue))
            {
                Alert.Show(this, "请输入存款状态！");
                this.dropIncomeAddMode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtIncomeAddAmount.Text.Trim()))
            {
                Alert.Show(this, "请输入收入金额！");
                this.txtIncomeAddAmount.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.dropIncomeAddRate.SelectedValue))
            {
                Alert.Show(this, "请输入利率！");
                this.dropIncomeAddRate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtIncomeAddDepositDate.Text.Trim()))
            {
                Alert.Show(this, "请输入存款日期！");
                this.txtIncomeAddDepositDate.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtIncomeAddDepositorName.Text.Trim()))
            {
                Alert.Show(this,"请输入存款人！");
                this.txtIncomeAddDepositDate.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(this.txtIncomeAddBDate.Text.Trim()) || !string.IsNullOrEmpty(this.txtIncomeAddEDate.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(this.txtIncomeAddBDate.Text.Trim()) && string.IsNullOrEmpty(this.txtIncomeAddEDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入到期日期!");
                    this.txtIncomeAddEDate.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(this.txtIncomeAddBDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtIncomeAddEDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入定存开始日期！");
                    this.txtIncomeAddBDate.Focus();
                    return;
                }
                else
                {
                    bool comparflag = true;
                    comparflag = HelperCommon.ValidDateTime(string.Format("{0:d}", this.txtIncomeAddBDate.Text.Trim()),string.Format("{0:d}" ,this.txtIncomeAddEDate.Text.Trim()));
                    if (!comparflag)
                    {
                        Alert.Show(this, "到期日期不能小于开始日期");
                        this.txtIncomeAddEDate.Focus();
                        return;
                    }

                    comparflag = HelperCommon.ComparDay(string.Format("{0:d}", this.txtIncomeAddBDate.Text.Trim()), string.Format("{0:d}", this.txtIncomeAddEDate.Text.Trim()));
                    if (!comparflag)
                    {
                        Alert.Show(this, "定存日期必须大于等于三个月！");
                        this.txtIncomeAddEDate.Focus();
                        return;
                    }
                }

            }
            if (string.IsNullOrEmpty(this.dropIncomeAddStatus.SelectedValue))
            {
                Alert.Show(this,"请选择收入状态！");
                this.dropIncomeAddStatus.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.dropIncomeAddDepositMode.SelectedValue))
            {
                Alert.Show(this, "请选存款方式！");
                this.dropIncomeAddDepositMode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtIncomeAddOwner.Text.Trim()))
            {
                Alert.Show(this, "请输入资产所有者！");
                this.txtIncomeAddOwner.Focus();
                return;
            }

            #endregion

            #region 赋值
            UserInfo userInfo = UserMethods.GetUserByName(this.txtIncomeAddOwner.Text.Trim());
            info.OwnerName = this.txtIncomeAddOwner.Text.Trim();
            userInfo = UserMethods.GetUserByName(this.txtIncomeAddOwner.Text.Trim());
            if (userInfo.Id > 0)
            {
                info.OwnerId = userInfo.Id;
            }
            else
            {
                info.OwnerId = 0;
            }
            CardInfo cardInfo = CardMethods.GetCardById(Convert.ToInt32(this.dropIncomeAddCardNumber.SelectedValue));
            info.CardNumber = cardInfo.CardNumber;
            info.BankCardNumber = cardInfo.CardNumber + " " +StaticRescourse.DisplayBank(cardInfo.BankId);
            info.CardId =Convert.ToInt32(this.dropIncomeAddCardNumber.SelectedItem.Value);
            info.IncomeAmount = Convert.ToSingle(this.txtIncomeAddAmount.Text.Trim());
            info.PreMode = Convert.ToInt32(this.dropIncomeAddPreMode.SelectedValue);
            info.Mode = Convert.ToInt32(this.dropIncomeAddMode.SelectedValue);
            info.PreRate = Convert.ToInt32(this.dropIncomeAddPreRate.SelectedValue);
            info.Rate = Convert.ToInt32(this.dropIncomeAddRate.SelectedValue);
            info.DepositDate = HelperCommon.ConverToDateTime(string.Format("{0:d}",this.txtIncomeAddDepositDate.Text.Trim()));
            if (!string.IsNullOrEmpty(this.txtIncomeAddBDate.Text.Trim()))
            {
                info.BDate = HelperCommon.ConverToDateTime(string.Format("{0:d}", this.txtIncomeAddBDate.Text.Trim()));
            }

            if (!string.IsNullOrEmpty(this.txtIncomeAddEDate.Text.Trim()))
            {
                info.EDate = HelperCommon.ConverToDateTime(string.Format("{0:d}",this.txtIncomeAddEDate.Text.Trim()));
            }

            if (this.checkIncomeAddAutoSave.Checked)
            {
                info.AutoSave = 1;
            }
            else
            {
                info.AutoSave = 0;
            }

            userInfo = UserMethods.GetUserByName(this.txtIncomeAddDepositorName.Text.Trim());
            if (userInfo.Id > 0)
            {
                info.DepositorId = userInfo.Id;
            }
            else
            {
                info.DepositorId = 0;
            }

            info.DepositorName = this.txtIncomeAddDepositorName.Text.Trim();
            info.DepositMode = Convert.ToInt32(this.dropIncomeAddDepositMode.SelectedValue);
            info.Status = Convert.ToInt32(this.dropIncomeAddStatus.SelectedValue);
            info.IncomeType = Convert.ToInt32(this.dropIncomeAddInComeType.SelectedValue);
            info.TAmount = info.IncomeAmount;
            info.Content = !string.IsNullOrEmpty(this.txtIncomeAddContent.Text.Trim()) ? this.txtIncomeAddContent.Text.Trim() : string.Empty;
            #endregion
            int iSuccess = CashIncomeMethods.InsertOrUpdatetocashincome(info);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayAddIncomediv();", true);
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
            InitializeIncomeAdd(new CashIncomeInfo());
            queryList = new List<QueryElement>();
            BindIncomeListDataGrid(queryList);
        }

        protected void btnIncomeEditCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
        }

        protected void btnIncomeQuerySelect_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayQueryIncomediv();", true);

            #region 查询条件验证
            if (!string.IsNullOrEmpty(this.txtIncomeQueryBDepositDate.Text.Trim()) || !string.IsNullOrEmpty(this.txtIncomeQueryEDepositDate.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(this.txtIncomeQueryBDepositDate.Text.Trim()) && string.IsNullOrEmpty(this.txtIncomeQueryEDepositDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入一个时间段！");
                    this.txtIncomeQueryEDepositDate.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(this.txtIncomeQueryBDepositDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtIncomeQueryEDepositDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入一个时间段！");
                    this.txtIncomeQueryBDepositDate.Focus();
                    return;
                }
                else
                {
                    bool flag = HelperCommon.ValidDateTime(this.txtIncomeQueryBDepositDate.Text.Trim(), this.txtIncomeQueryEDepositDate.Text.Trim());
                    if (!flag)
                    {
                        Alert.Show(this, "开始日期不能大于结束日期！");
                        this.txtIncomeQueryEDepositDate.Focus();
                        return;
                    }
                }
            }
            #endregion
            queryList = new List<QueryElement>();
            if (!string.IsNullOrEmpty(this.txtIncomeQueryCardNumber.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "CardNumber", QueryElementType = MySqlDbType.String, Queryvalue = this.txtIncomeQueryCardNumber.Text.Trim()};
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.dropIncomeQueryIncomeType.SelectedValue))
            {
                QueryElement query = new QueryElement { Queryname = "IncomeType", QueryElementType = MySqlDbType.Int32, Queryvalue = Convert.ToInt32(this.dropIncomeQueryIncomeType.SelectedValue) };
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.txtIncomeQueryOwnerName.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "OwnerName",QueryElementType=MySqlDbType.String,Queryvalue=this.txtIncomeQueryOwnerName.Text.Trim(),QueryOperation="like" };
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.dropIncomeQueryMode.SelectedValue))
            {
                QueryElement query = new QueryElement { Queryname = "Mode" ,QueryElementType=MySqlDbType.Int32,Queryvalue=this.dropIncomeQueryMode.SelectedValue};
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.txtIncomeQueryDepositorName.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "DepositorName", QueryElementType = MySqlDbType.String, Queryvalue = this.txtIncomeQueryDepositorName.Text.Trim(),QueryOperation="like" };
                queryList.Add(query);
            }
            if (!string.IsNullOrEmpty(this.dropIncomeQueryDepositMode.SelectedValue))
            {
                QueryElement query = new QueryElement { Queryname = "DepositMode", QueryElementType = MySqlDbType.Int32, Queryvalue = this.dropIncomeQueryDepositMode.SelectedValue };
                queryList.Add(query);
            }
            if (!string.IsNullOrEmpty(this.txtIncomeQueryBDepositDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtIncomeQueryEDepositDate.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "DepositDate",QueryElementType=MySqlDbType.DateTime,Queryvalue=this.txtIncomeQueryBDepositDate.Text.Trim(),QueryOperation=">=" };
                queryList.Add(query);
                query = new QueryElement { Queryname = "DepositDate",QueryElementType=MySqlDbType.DateTime,Queryvalue=this.txtIncomeQueryEDepositDate.Text.Trim(),QueryOperation="<" };
                queryList.Add(query);
            }
            BindIncomeListDataGrid(queryList);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayQueryIncomediv();", true);
            InitializeIncomeQuery();
        }

        protected void btnIncomeQueryCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
        }

        protected void btnIncomeAdd_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayAddIncomediv();", true);
            Session["editFlag"] = "false";
            CashIncomeInfo info = new CashIncomeInfo();
            InitializeIncomeAdd(info);
        }

        protected void btnIncomeQuery_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayQueryIncomediv();", true);
            InitializeIncomeQuery();
        }


        /// <summary>
        ///新增初始化
        /// </summary>
        /// <param name="info"></param>
        private void InitializeIncomeAdd(CashIncomeInfo info)
        {
            if (info.Id > 0)
            {
                #region 编辑时初始化
                this.dropIncomeAddCardNumber.Enabled = false;
                List<DropItem> card = new List<DropItem>();
                card.Add(new DropItem { DisplayField = info.CardNumber, ValueField = info.CardId.ToString() });
                this.dropIncomeAddCardNumber.DataSource = card;
                Helper.SetDropDownList(this.dropIncomeAddCardNumber);
                this.dropIncomeAddCardNumber.SelectedValue = info.CardId.ToString();
                #endregion

            }
            else
            {
                this.dropIncomeAddCardNumber.Enabled = true;

                InitializeDropIncomeCardNumber();
            }
            DateTime date = new DateTime(2000, 1, 1);
            this.txtIncomeAddAmount.Text = info.IncomeAmount > 0 ? info.IncomeAmount.ToString() : string.Empty;
            this.txtIncomeAddDepositDate.Text = info.DepositDate > date ? info.DepositDate.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
            this.txtIncomeAddDepositorName.Text = !string.IsNullOrEmpty(info.DepositorName) ? info.DepositorName : string.Empty;
            this.txtIncomeAddBDate.Text = info.BDate > date ? info.BDate.ToString("yyyy-MM-dd") : string.Empty;
            this.txtIncomeAddContent.Text = !string.IsNullOrEmpty(info.Content) ? info.Content : string.Empty;
            this.txtIncomeAddOwner.Text = !string.IsNullOrEmpty(info.OwnerName) ? info.OwnerName : string.Empty;

            if (info.AutoSave == 1)
            {
                this.checkIncomeAddAutoSave.Checked = true;
            }
            else
            {
                this.checkIncomeAddAutoSave.Checked = false;
            }
            InitializeEditDropControl(info);
        }

       /// <summary>
       /// 查询初始化
       /// </summary>
        private void InitializeIncomeQuery()
        {
            this.dropIncomeQueryMode.Enabled = false;
            this.txtIncomeQueryCardNumber.Text = string.Empty;
            this.txtIncomeQueryOwnerName.Text = string.Empty;
            this.txtIncomeQueryDepositorName.Text = string.Empty;
            this.txtIncomeQueryBDepositDate.Text = string.Empty;
            this.txtIncomeQueryEDepositDate.Text = string.Empty;
            InitializeQueryDropControl();
        }

        /// <summary>
        /// 初始化卡号（新增）
        /// </summary>
        private void InitializeDropIncomeCardNumber()
        {
            CardCollection cardcoll = new CardCollection();
            List<QueryElement> list = new List<QueryElement>();
            cardcoll = CardMethods.GetCard(list);
            List<DropItem> card = new List<DropItem>();
            card.Add(new DropItem { ValueField = "", DisplayField = " " });

            for (int i = 0; i < cardcoll.Count; i++)
            {
                CardInfo cardInfo = cardcoll[i];
                string bank = StaticRescourse.DisplayBank(cardInfo.BankId);
                card.Add(new DropItem { ValueField = cardInfo.Id.ToString(), DisplayField = cardInfo.CardNumber+" "+bank});// +" "+bank 
            }
            this.dropIncomeAddCardNumber.DataSource = card;
            Helper.SetDropDownList(this.dropIncomeAddCardNumber);
            this.dropIncomeAddCardNumber.SelectedValue = string.Empty;
        }

        /// <summary>
        ///编辑时初始化dropdownlist
        /// </summary>
        private void InitializeEditDropControl(CashIncomeInfo info)
        {
            this.dropIncomeAddInComeType.DataSource = StaticRescourse.GetIncomeType();
            Helper.SetDropDownList(this.dropIncomeAddInComeType);


            this.dropIncomeAddPreRate.DataSource = StaticRescourse.GetRateType();
            Helper.SetDropDownList(this.dropIncomeAddPreRate);


            this.dropIncomeAddRate.DataSource = StaticRescourse.GetRate(this.dropIncomeAddPreRate.SelectedItem.Text);
            Helper.SetDropDownList(this.dropIncomeAddRate);


            this.dropIncomeAddStatus.DataSource = StaticRescourse.GetIncomeStatus();
            Helper.SetDropDownList(this.dropIncomeAddStatus);


            this.dropIncomeAddDepositMode.DataSource = StaticRescourse.GetIncomDepositMode();
            Helper.SetDropDownList(this.dropIncomeAddDepositMode);


            this.dropIncomeAddPreMode.DataSource = StaticRescourse.GetRateType();
            Helper.SetDropDownList(this.dropIncomeAddPreMode);


            this.dropIncomeAddMode.DataSource = StaticRescourse.GetMode(this.dropIncomeAddPreMode.SelectedItem.Text);
            Helper.SetDropDownList(this.dropIncomeAddMode);


            if (info.Id>0)
            {
                this.dropIncomeAddInComeType.SelectedValue = info.IncomeType.ToString();
                this.dropIncomeAddPreRate.SelectedValue = info.PreRate.ToString();
                this.dropIncomeAddRate.SelectedValue = info.Rate.ToString();
                this.dropIncomeAddStatus.SelectedValue = info.Status.ToString();
                this.dropIncomeAddDepositMode.SelectedValue = info.DepositMode.ToString();
                this.dropIncomeAddPreMode.SelectedValue = info.PreMode.ToString();
                this.dropIncomeAddMode.SelectedValue = info.Mode.ToString();  
            }
            else
            {
                this.dropIncomeAddInComeType.SelectedValue = "1";
                this.dropIncomeAddPreRate.SelectedValue = "1";
                this.dropIncomeAddRate.SelectedValue = "1";
                this.dropIncomeAddStatus.SelectedValue = "1";
                this.dropIncomeAddDepositMode.SelectedValue = "1";
                this.dropIncomeAddPreMode.SelectedValue = "1";
                this.dropIncomeAddMode.SelectedValue = "1";                
            }
        }

        /// <summary>
        /// 查询时初始化dropdownlist
        /// </summary>
        private void InitializeQueryDropControl()
        {
            this.dropIncomeQueryIncomeType.DataSource = StaticRescourse.GetIncomeType();
            Helper.SetDropDownList(this.dropIncomeQueryIncomeType);
            this.dropIncomeQueryIncomeType.SelectedValue = string.Empty;

            this.dropIncomeQueryDepositMode.DataSource = StaticRescourse.GetIncomDepositMode();
            Helper.SetDropDownList(this.dropIncomeQueryDepositMode);
            this.dropIncomeQueryDepositMode.SelectedValue = string.Empty;

            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField="",DisplayField=" "});
            list.AddRange(StaticRescourse.GetRateType());
            this.dropIncomeQueryPreMode.DataSource = list;
            Helper.SetDropDownList(this.dropIncomeQueryPreMode);
            this.dropIncomeQueryPreMode.SelectedValue = string.Empty;
        }

        protected void dropIncomeAddPreMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dropIncomeAddPreMode.SelectedValue))
            {
                this.dropIncomeAddMode.SelectedValue = string.Empty;
                this.dropIncomeAddMode.Enabled = false;
            }
            else
            {
                this.dropIncomeAddMode.Enabled = true;
                this.dropIncomeAddMode.DataSource = StaticRescourse.GetMode(this.dropIncomeAddPreMode.SelectedItem.Text);
                Helper.SetDropDownList(this.dropIncomeAddMode);
            }
        }

        protected void dropIncomeQueryPreMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dropIncomeQueryPreMode.SelectedValue))
            {
                List<DropItem> list = new List<DropItem>();
                list.Add(new DropItem { ValueField = "", DisplayField = " " });
                this.dropIncomeQueryMode.DataSource = list;
                Helper.SetDropDownList(this.dropIncomeQueryMode);
                this.dropIncomeQueryMode.Enabled = false;
            }
            else
            {
                List<DropItem> list = new List<DropItem>();
                list.Add(new DropItem { ValueField = "", DisplayField = "" });
                list.AddRange(StaticRescourse.GetMode(this.dropIncomeQueryPreMode.SelectedItem.Text));
                this.dropIncomeQueryMode.DataSource = list;
                Helper.SetDropDownList(this.dropIncomeQueryMode);
                this.dropIncomeQueryMode.SelectedIndex = 0; ;
            }
        }

        protected void dropIncomeAddPreRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.dropIncomeAddPreRate.SelectedValue))
            {
                this.dropIncomeAddRate.SelectedValue = string.Empty;
                this.dropIncomeAddRate.Enabled = false;
            }
            else
            {
                this.dropIncomeAddRate.Enabled = true;
                this.dropIncomeAddRate.DataSource = StaticRescourse.GetRate(this.dropIncomeAddPreRate.SelectedItem.Text);
                Helper.SetDropDownList(this.dropIncomeAddRate);
            }
        }

        protected void IncomeListDataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            //TableCell itemcell = e.Item.Cells[0];
            //string ids = itemcell.Text;
            //int id = Convert.ToInt32(ids);
        }

        protected void IncomeListDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string id = string.Empty;
            if (e.CommandName == "IncomeImageDelete")
            {
                int selectindex = e.Item.ItemIndex;
                id = this.IncomeListDataGrid.Items[selectindex].Cells[0].Text;
            }
            if (!string.IsNullOrEmpty(id))
            {
                int iSuccess = CashIncomeMethods.DeleteCashIncome(Convert.ToInt32(id));
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
                BindIncomeListDataGrid(queryList);
            }
        }
    }
}