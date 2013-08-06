﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BillingSystem.Models;
using BillingSystem.Services;
using BillingSystem.Common;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace BillingSystem.Views
{
    public partial class Borrowed : System.Web.UI.Page
    {
        private List<QueryElement> queryList = null;
        private bool deleteflag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Application["user"] != null)
                //{
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
                    queryList = new List<QueryElement>();
                    BindBorrowListDataGrid(queryList);
                //}
                //else
                //{
                //    Response.Redirect("~/Views/Login.aspx");
                //    Alert.Show(this, "请先登录！");
                //}
            }
        }

        private void BindBorrowListDataGrid(List<QueryElement> list)
        {
            BorrowORLoanCollection coll = BorrowedMethods.GetBorrowList(list);
            this.BorrowListDataGrid.DataSource = coll;
            this.BorrowListDataGrid.DataBind();
            for (int i = 0; i < coll.Count; i++)
            {
                this.BorrowListDataGrid.Items[i].Cells[7].Text = coll[i].HappenedDate.ToString("yyyy-MM-dd");
                this.BorrowListDataGrid.Items[i].Cells[2].Text = StaticRescourse.DisplayBorrowORLoanType(coll[i].BorrowORLoanType);
                bool dateFlag=HelperCommon.CompareAccordToRequired(coll[i].ReturnDate);
                if (dateFlag)
                {
                    this.BorrowListDataGrid.Items[i].Cells[8].Text = coll[i].ReturnDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    this.BorrowListDataGrid.Items[i].Cells[8].Text = string.Empty;
                }
            }
        }

        protected void btnBorrowAddSubmit_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrEmpty(this.txtBorrowAddBorrower.Text.Trim()))
            {
                Alert.Show(this,"请输入借款人！");
                this.txtBorrowAddBorrower.Focus();
                return;
            }

            if (RadioBorrowAddBorrowType.SelectedValue == "2" )
            {

                if (string.IsNullOrEmpty(this.txtBorrowAddBorrowAccount.Text.Trim()))
                {
                    Alert.Show(this, "请输入借款账户！");
                    this.txtBorrowAddBorrowAccount.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(this.txtBorrowAddLoanAccount.Text.Trim()))
                {
                    Alert.Show(this, "请输入出借账户！");
                    this.txtBorrowAddLoanAccount.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.txtBorrowAddLender.Text.Trim()))
            {
                Alert.Show(this,"请输入出借人！");
                this.txtBorrowAddLender.Focus();
                return;
            }


            if (string.IsNullOrEmpty(this.txtBorrowAddBorrowAmount.Text.Trim()))
            {
                Alert.Show(this, "请输入借款金额!");
                this.txtBorrowAddBorrowAmount.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtBorrowAddBorrowDate.Text.Trim()))
            {
                Alert.Show(this, "请输入借款日期！");
                this.txtBorrowAddBorrowDate.Focus();
                return;
            }
            #endregion

            BorrowORLoanInfo borrowInfo = new BorrowORLoanInfo();
            if (!string.IsNullOrEmpty(this.HiddenField1.Value.Trim()))
            {
                borrowInfo.Id = Convert.ToInt32(this.HiddenField1.Value.Trim());
            }
            else
            {
                borrowInfo.Id = 0;
            }

            borrowInfo.BorrowORLoanType = Convert.ToInt32(this.RadioBorrowAddBorrowType.SelectedValue);
            borrowInfo.Borrower = this.txtBorrowAddBorrower.Text.Trim();
            borrowInfo.BorrowedAccount = this.txtBorrowAddBorrowAccount.Text.Trim();
            borrowInfo.Lender = this.txtBorrowAddLender.Text.Trim();
            borrowInfo.LoanAccount = this.txtBorrowAddLoanAccount.Text.Trim();
            borrowInfo.Amount = Convert.ToSingle(this.txtBorrowAddBorrowAmount.Text.Trim());
            borrowInfo.HappenedDate = HelperCommon.ConverToDateTime(string.Format("{0:d}", this.txtBorrowAddBorrowDate.Text.Trim()));
            if (!string.IsNullOrEmpty(this.txtBorrowAddReturnDate.Text.Trim()))
            {
                borrowInfo.ReturnDate = HelperCommon.ConverToDateTime(string.Format("{0:d}", this.txtBorrowAddReturnDate.Text.Trim()));
            }
            borrowInfo.Content = this.txtBorrowAddContent.Text.Trim();

            int iSuccess = BorrowedMethods.InsertOrUpdatetoBorrowed(borrowInfo);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayAddBorrowdiv();", true);
            if (iSuccess ==1)
            {
                Alert.Show(this, "新增一条收入成功！");
            }
            else if (iSuccess == 2)
            {
                Alert.Show(this, "修改成功！");
            }
            else
            {
                Alert.Show(this, "操作失败！");
            }
            InitializeBorrowAdd();
            queryList = new List<QueryElement>();
            BindBorrowListDataGrid(queryList);
        }

        //protected void btnBorrowAddCanel_Click(object sender, EventArgs e)
        //{
        //    this.HiddenField1.Value = string.Empty;
        //    this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
        //}

        protected void btnBorrowQuerySubmit_Click(object sender, EventArgs e)
        {
            queryList = new List<QueryElement>();

            #region 查询条件验证
            if (!string.IsNullOrEmpty(this.txtBorrowQueryBBorrowDate.Text.Trim()) || !string.IsNullOrEmpty(this.txtBorrowQueryEBorrowDate.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(this.txtBorrowQueryBBorrowDate.Text.Trim()) && string.IsNullOrEmpty(this.txtBorrowQueryEBorrowDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入一个时间段！");
                    this.txtBorrowQueryEBorrowDate.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(this.txtBorrowQueryBBorrowDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtBorrowQueryEBorrowDate.Text.Trim()))
                {
                    Alert.Show(this, "请输入一个时间段！");
                    this.txtBorrowQueryBBorrowDate.Focus();
                    return;
                }
                else
                {
                    bool flag = HelperCommon.ValidDateTime(this.txtBorrowQueryBBorrowDate.Text.Trim(), this.txtBorrowQueryEBorrowDate.Text.Trim());
                    if (!flag)
                    {
                        Alert.Show(this, "开始日期不能大于结束日期！");
                        this.txtBorrowQueryEBorrowDate.Focus();
                        return;
                    }
                }
            }
            #endregion
            if (!string.IsNullOrEmpty(this.txtBorrowQueryBorrower.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "Borrower", QueryElementType = MySqlDbType.String, Queryvalue = this.txtBorrowQueryBorrower.Text.Trim(), QueryOperation = "like" };
                queryList.Add(query);
            }

            if (!string.IsNullOrEmpty(this.txtBorrowQueryBBorrowDate.Text.Trim()) && !string.IsNullOrEmpty(this.txtBorrowQueryEBorrowDate.Text.Trim()))
            {
                QueryElement query = new QueryElement { Queryname = "HappenedDate", QueryElementType = MySqlDbType.DateTime, Queryvalue = this.txtBorrowQueryBBorrowDate.Text.Trim(), QueryOperation = ">=" };
                queryList.Add(query);
                query = new QueryElement { Queryname = "HappenedDate", QueryElementType = MySqlDbType.DateTime, Queryvalue = this.txtBorrowQueryEBorrowDate.Text.Trim(), QueryOperation = "<" };
                queryList.Add(query);
            }
            BindBorrowListDataGrid(queryList);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplayQueryBorrowdiv();", true);
            InitializeBorrowQuery();
        }

        //protected void btnBorrowQueryCanel_Click(object sender, EventArgs e)
        //{
        //    this.ClientScript.RegisterStartupScript(this.GetType(), "", "DisplaySysdiv();", true);
        //}

        protected void BorrowListDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string id = string.Empty;
            if (e.CommandName == "BorrowImageDelete")
            {
                int selectindex = e.Item.ItemIndex;
                id = this.BorrowListDataGrid.Items[selectindex].Cells[0].Text;
            }
            if (!string.IsNullOrEmpty(id) && this.deleteflag==true)
            {
                int iSuccess = BorrowedMethods.DeleteBorrowedById(Convert.ToInt32(id));
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
                BindBorrowListDataGrid(queryList);
            }
        }

        private void InitializeBorrowQuery()
        {
            this.txtBorrowQueryBorrower.Text = string.Empty;
            this.txtBorrowQueryBBorrowDate.Text = string.Empty;
            this.txtBorrowQueryEBorrowDate.Text = string.Empty;
        }

        private void InitializeBorrowAdd()
        {
            this.txtBorrowAddBorrower.Enabled = true;
            this.RadioBorrowAddBorrowType.SelectedValue = "1";
            this.txtBorrowAddBorrower.Text = string.Empty;
            this.txtBorrowAddLender.Text = string.Empty;
            this.txtBorrowAddBorrowAmount.Text = string.Empty;
            this.txtBorrowAddBorrowDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txtBorrowAddReturnDate.Text = string.Empty;
            this.txtBorrowAddContent.Text = string.Empty;
        }

        protected void btnBorrowDelete_Click(object sender, ImageClickEventArgs e)
        {
            this.deleteflag = true;
        }
    }
}