using BillingSystem.Models;
using BillingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BillingSystem.Views
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<string> getLoanAccountByPerson(string loanName)
        {
            UserInfo userInfo = UserMethods.GetUserByName(loanName);
            if (userInfo.Id > 0)
            {
                CardCollection coll = CardMethods.GetCardByUserId(userInfo.Id);
                List<string> list = new List<string>();
                for (int i = 0; i < coll.Count; i++)
                {
                    string bank = StaticRescourse.DisplayBank(coll[i].BankId);
                    list.Add( coll[i].CardNumber + " " + bank );
                }
                return list;
            }
            return new List<string>(0);
        }

    }
}