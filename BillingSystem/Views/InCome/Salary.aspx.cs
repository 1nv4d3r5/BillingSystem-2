using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BillingSystem.DAL;
using BillingSystem.Models;

namespace BillingSystem.Views
{
    public partial class Salary : System.Web.UI.Page
    {
        private CardCollection coll = new CardCollection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void TreeViewIncome_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void btnInComeEditSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnInComeEditCanel_Click(object sender, EventArgs e)
        {

        }

        //private void AddControl(string name,string bankname,CardCollection cardcoll)
        //{
        //    HtmlGenericControl div = new HtmlGenericControl();
        //    div.TagName = "div";
        //    div.ID = "div"+name;
        //    GridView gridview = new GridView();
        //    gridview.ID = "gridview" + name;
        //    gridview.AutoGenerateColumns = true;
        //    this.income.Controls.Add(div);
        //    div.Controls.Add(gridview);
        //}
    }
}