using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.DAL;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace BillingSystem.Proxy
{
    public class CardProxy
    {
        public static CardInfo GetCardById(int id)
        {
            return CardDAL.GetCardById(id);
        }

        public static CardCollection GetCard(List<QueryElement> list)
        {
            return CardDAL.GetCard(list);
        }

        public static CardInfo GetCardByCardNumber(string cardNumber,int ownerId)
        {
            return CardDAL.GetCardByCardNumber(cardNumber,ownerId);
        }

        public static int InsertOrUpdatetoCard(CardInfo info)
        {
            int iSuccess = 0;
            MySqlTransaction mySqlTransaction = null;
            CardDAL.InsertOrUpdatetoCard(mySqlTransaction,info,out iSuccess);
            if (iSuccess > 0)
            {
                return 1;
            }
            else if (iSuccess == -1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int DeleteCard(int id)
        {
            int iSuccess = 0;
            CardDAL.DeleteCard( id, out iSuccess);
            if (iSuccess > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static CardCollection GetCardByUserId(int userId)
        {
            return CardDAL.GetCardByUserId(userId);
        }
    }
}