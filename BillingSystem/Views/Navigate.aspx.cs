using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillingSystem.Views
{
    public partial class Navigate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if ((int)Session["id"] == 1)
                //{
                //    this.navigateTree.Nodes.Add(new TreeNode { Text = "工资", Value = "salary", Target = "content", NavigateUrl = "~/Views/Salary.aspx" });//Target = "content",, NavigateUrl = "~/Salary.aspx"
                //    this.navigateTree.Nodes.Add(new TreeNode { Text = "奖金", Value = "bonus" });//, NavigateUrl = "~/Bonus.aspx" 
                //}
            }
        }

        //protected void navigateTree_SelectedNodeChanged(object sender, EventArgs e)
        //{
        //    if (this.navigateTree.SelectedNode.Value == "salary")
        //    {
           
        //    }
        //}
    }
}