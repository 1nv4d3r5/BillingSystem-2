using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingSystem.Views;
using FBJHelper;
using BillingSystem.Services;

namespace BillingSystem.Views
{
    public partial class Install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
           int iSuccess= FirstLoadMethods.CreateTable();
           if (iSuccess > 0)
           {
               Alert.Show(this, "初始化表成功！");
           }
           else
           {
               Alert.Show(this,"初始化失败！");
           }
        }
    }
}