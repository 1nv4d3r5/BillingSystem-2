using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingSystem.Models;
using BillingSystem.Proxy;
using MySql.Data.MySqlClient;
using BillingSystem.DAL;

namespace BillingSystem.Services
{
    public static class CardMethods
    {
        public static CardInfo GetCardById(int id)
        {
            return CardProxy.GetCardById(id);
        }

        public static CardCollection GetCard(List<QueryElement> list)
        {
            return CardProxy.GetCard(list);
        }

        public static CardInfo GetCardByCardNumber(string cardNumber,int ownerId)
        {
            return CardProxy.GetCardByCardNumber(cardNumber,ownerId);
        }

        public static int InsertOrUpdatetoCard(CardInfo info)
        {
            return CardProxy.InsertOrUpdatetoCard(info);
        }

        public static int DeleteCard(int id)
        {
            return CardProxy.DeleteCard(id);
        }

        public static CardCollection GetCardByUserId(int userId)
        {
            return CardProxy.GetCardByUserId(userId);
        }
    }
}