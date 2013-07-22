using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillingSystem.Views
{
    public partial class InCome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InComeTree.Nodes.Add(new TreeNode { Text = "工资", Value = "salary"});
                this.InComeTree.Nodes.Add(new TreeNode { Text = "奖金", Value = "bonus" });
            }
        }

        protected void InComeTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.InComeTree.SelectedNode.Value == "salary")
            {
                this.content.Src = "~/Views/Salary.aspx";
            }
            else if (this.InComeTree.SelectedNode.Value == "bonus")
            {
            }
        }
    }
}