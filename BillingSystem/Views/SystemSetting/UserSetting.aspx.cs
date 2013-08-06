using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Models;
using BillingSystem.Services;
using FBJHelper;
using System.Drawing;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
using BillingSystem.Common;

namespace BillingSystem.Views
{
    public partial class UserSetting : System.Web.UI.Page
    {
        private UserCollection userColl = new UserCollection();
        private Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
        private List<QueryElement> queryList = new List<QueryElement>();
        private bool deleteflag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Application["user"] != null)
                //{
                    if (!string.IsNullOrEmpty(Request.QueryString["Code"]))
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserEditdiv();", true);
                        UserInfo info = UserMethods.GetUserByCode(Request.QueryString["Code"]);
                        string desecpassword = FBJHelper.Encryption.DESEdcrypt(info.Password, "19850627");
                        info.Password = desecpassword;
                        Initialize(info);
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserSet();", true);
                    }
                    BindDataGrid(queryList);
                //}
                //else
                //{
                //    Response.Redirect("~/Views/Login.aspx");
                //    Alert.Show(this, "请先登录！");
                //}
            }
        }

        private void BindDataGrid(List<QueryElement> list)
        {
            userColl = UserMethods.GetUser(list);
            this.UserListDataGrid.DataSource = userColl;
            this.UserListDataGrid.DataBind();
            for (int i = 0; i < userColl.Count; i++)
            {
                this.UserListDataGrid.Items[i].Cells[4].Text = StaticRescourse.DisplayRole(userColl[i].Role);
            }
        }

        protected void btnUserAdd_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserAdddiv();", true);
            UserInfo info = new UserInfo();
            Initialize(info);
            ClearEditFrom();
        }

        protected void btnUserSelect_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserQuery();", true);
            ClearQueryForm();
            //double height = rect.Height - rect.Height * 0.8;
            //double width = rect.Width - rect.Width * 0.8;
            //OpenNewWindow.OpenANewWindow(this.Page, "UserQuery.aspx", "UserQuery.aspx", width.ToString(), height.ToString(), "50", "50", "yes", true);
        }

        protected void btnUserEditSave_Click(object sender, EventArgs e)
        {
            #region 验证
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserAdddiv();", true);
            if (string.IsNullOrEmpty(this.txtIdCode.Text.Trim()))
            {
                Alert.Show(this, "请输入IdCode！");

                this.txtIdCode.Focus();
                return;
            }
            if (this.txtIdCode.Text.Trim().Length > 10 || this.txtIdCode.Text.Trim().Length < 5)
            {
                Alert.Show(this, "请输入长度在5到10之间的IdCode！");

                this.txtIdCode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Request.QueryString["Code"]))
            {
                if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
                {
                    Alert.Show(this, "请输入密码！");
                    this.txtPassword.Focus();
                    return;
                }

                if (this.txtPassword.Text.Trim().Length < 6 || this.txtPassword.Text.Trim().Length > 18)
                {
                    Alert.Show(this, "请输入长度在6到18之间的密码！");
                    this.txtPassword.Focus();
                    return;
                }
            }
            #endregion
            UserInfo userInfo = new UserInfo();
            userInfo.Name = this.txtUserName.Text.Trim();
            userInfo.Code = this.txtIdCode.Text.Trim();
            userInfo.Password = FBJHelper.Encryption.DESEncrypt(this.txtPassword.Text.Trim(),"19850627");
            userInfo.Role = Convert.ToInt32(this.dropRole.SelectedValue);
            userInfo.content = this.txtContent.Text.Trim();
            userInfo.EMail = this.txtEmail.Text.Trim();
            int isuccess = UserMethods.InsertOrUpdatetoUser(userInfo);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserAdddiv();", true);
            if (isuccess > 0)
            {
                Alert.Show(this, "新增用户成功！");
                ClearEditFrom();
            }
            else if (isuccess == -1)
            {
                Alert.Show(this, "修改用户成功！");
                ClearEditFrom();
            }
            else
            {
                Alert.Show(this, "操作失败！");
            }
            BindDataGrid(queryList);
            //if (i > 0)
            //{
                //this.ClientScript.RegisterStartupScript(this.GetType(), "", "closeWin();", true);
                //Response.Write("<script type='text/javascript'>window.opener = null; window.close();</script>");
            //}
        }

        protected void btnUserEditCanel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserSet();", true);
        }

        private void Initialize(UserInfo info)
        {
            this.dropRole.DataSource = StaticRescourse.GetRoleType();
            Helper.SetDropDownList(this.dropRole);
            this.dropRole.DataBind();
            if (info.Id > 0)
            {
                this.txtUserName.Text = !string.IsNullOrEmpty(info.Name) ? info.Name : string.Empty;
                this.txtIdCode.Text = info.Code;
                this.txtPassword.Attributes.Add("value",info.Password);
                this.dropRole.SelectedValue = info.Role.ToString();
                this.txtEmail.Text = !string.IsNullOrEmpty(info.EMail) ? info.EMail : string.Empty;
                this.txtContent.Text = !string.IsNullOrEmpty(info.content) ? info.content : string.Empty;
            }
            else
            {
                this.dropRole.SelectedValue = "1";
            }
        }

        protected void btnUserQueryCancel_Click(object sender, EventArgs e)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserSet();", true);
        }

        protected void btnUserQuerySave_Click(object sender, EventArgs e)
        {
            queryList = new List<QueryElement>();
            UserQuerySumbit(ref queryList);
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "displayUserQuery();", true);
            BindDataGrid(queryList);
            ClearQueryForm();
        }

        private void UserQuerySumbit(ref List<QueryElement> list)
        {
            if (!string.IsNullOrEmpty(this.txtUserQueryUserName.Text.Trim()))
            {
                QueryElement queryElement = new QueryElement { Queryname = "Name", QueryElementType = MySqlDbType.String, Queryvalue = this.txtUserQueryUserName.Text.Trim(), QueryOperation = "like" };
                list.Add(queryElement);
            }

            if (!string.IsNullOrEmpty(this.txtUserQueryIdCode.Text.Trim()))
            {
                QueryElement queryElement = new QueryElement { Queryname = "Code", QueryElementType = MySqlDbType.String, Queryvalue = this.txtUserQueryIdCode.Text.Trim() };
                list.Add(queryElement);
            }
        }

        private void ClearEditFrom()
        {
            this.txtUserName.Text = string.Empty;
            this.txtIdCode.Text = string.Empty;
            this.txtPassword.Attributes.Add("value","");
            this.dropRole.SelectedValue = "1";
            this.txtEmail.Text = string.Empty;
            this.txtContent.Text = string.Empty;
        }

        private void ClearQueryForm()
        {
            this.txtUserQueryIdCode.Text = string.Empty;
            this.txtUserQueryUserName.Text = string.Empty;
        }

        protected void UserListDataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string id = string.Empty;
            if (e.CommandName == "ImageDelete")
            {
                int selectindex = e.Item.ItemIndex;
                id = this.UserListDataGrid.Items[selectindex].Cells[0].Text;
            }
            if (!string.IsNullOrEmpty(id) && this.deleteflag==true)
            {
                int iSuccess = UserMethods.DeleteUser(Convert.ToInt32(id));
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
                BindDataGrid(queryList);
            }
        }

        protected void btnCardDelete_Click(object sender, ImageClickEventArgs e)
        {
            this.deleteflag = true;
        }
    }
}