using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FBJHelper;
using System.Text;
using System.Xml;
using BillingSystem.Models;
using BillingSystem.DAL;
using Newtonsoft.Json;
using BillingSystem.Proxy;
using BillingSystem.Services;

namespace BillingSystem.Views
{
    public partial class Login : System.Web.UI.Page
    {
        private UserInfo userInfo = new UserInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                this.txtUserName.Focus();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtPassword.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtUserName.Focus();
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //coll = FBJHelper.Universal<UserCollection>.DeSerializeXMLToObject(str);
            //coll = JavaScriptConvert.DeserializeObject<UserCollection>(JavaScriptConvert.SerializeObject(str));
            if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
            {
                Alert.Show(this,"用户名不能为空！");
                this.txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                Alert.Show(this,"密码不能为空！");
                this.txtPassword.Focus();
                return;
            }
            userInfo = UserMethods.GetUserByCode(this.txtUserName.Text.Trim());
            if (userInfo.Id > 0)
            {
                string str = Encryption.DESEncrypt(this.txtPassword.Text.Trim(),"19850627");
                if (userInfo.Password.Equals(str))
                {
                    Session["UserCode"] = userInfo.Code;
                    Server.Transfer("~/Views/BillingSystemMainPage.aspx");
                }
                else
                {
                    Alert.Show(this, "密码不正确");
                    this.txtPassword.Focus();
                }
            }
            else if (userInfo.Id == 0)
            {
                Alert.Show(this,"此账号不存在");
            }
            //    //Response.Redirect("~/Views/BillingSystemMainPage.aspx");
        }
    }
}