using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.ObjectModel;

namespace BillingSystem
{
    public class StaticRescourse
    {
       /// <summary>
       /// 存款类型
       /// </summary>
       /// <param name="deposit_form"></param>
       /// <returns></returns>
        public static List<DropItem> GetMode(string deposit_form)
        {
            List<DropItem> list = new List<DropItem>();
            if (deposit_form.Equals("ZCZQ"))
            {
                list.Add(new DropItem { ValueField = "1", DisplayField = "活期" });
                list.Add(new DropItem { ValueField = "2", DisplayField = "定存三个月" });
                list.Add(new DropItem { ValueField = "3", DisplayField = "定存六个月" });
                list.Add(new DropItem { ValueField = "4", DisplayField = "定存一年" });
                list.Add(new DropItem { ValueField = "5", DisplayField = "定存二年" });
                list.Add(new DropItem { ValueField = "6", DisplayField = "定存三年" });
                list.Add(new DropItem { ValueField = "7", DisplayField = "定存五年" });
            }
            else
            {
                list.Add(new DropItem { ValueField = "8", DisplayField = "定存一年" });
                list.Add(new DropItem { ValueField = "9", DisplayField = "定存三年" });
                list.Add(new DropItem { ValueField = "10", DisplayField = "定存五年" });
            }
            return list;
        }

        public static string DisplayMode(int value)
        {
            if (value == 1)
            {
                return "活期";
            }
            else if (value == 2)
            {
                return "定存三个月";
            }
            else if (value == 3)
            {
                return "定存六个月";
            }
            else if (value == 4 || value ==8)
            {
                return "定存一年";
            }
            else if (value == 5)
            {
                return "定存二年";
            }
            else if (value == 6 || value ==9)
            {
                return "定存三年";
            }
            else if (value == 7 || value ==10)
            {
                return "定存五年";
            }
            else
            {
                return "";
            }
        }




        /// <summary>
        /// 银行
        /// </summary>
        /// <returns></returns>
        public static List<DropItem> GetBank()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField = "1", DisplayField = "招商银行" });
            list.Add(new DropItem { ValueField = "2", DisplayField = "中国银行" });
            list.Add(new DropItem { ValueField = "3", DisplayField = "建设银行" });
            list.Add(new DropItem { ValueField = "4", DisplayField = "北京银行" });
            list.Add(new DropItem { ValueField = "5", DisplayField = "广发银行" });
            list.Add(new DropItem { ValueField = "6", DisplayField = "工商银行" });
            list.Add(new DropItem { ValueField = "7", DisplayField = "交通银行" });
            list.Add(new DropItem { ValueField = "8", DisplayField = "农业银行" });
            return list;
        }

        public static string DisplayBank(int value)
        {
            if (value == 1)
            {
                return "招商银行";
            }
            else if (value == 2)
            {
                return "中国银行";
            }
            else if (value == 3)
            {
                return "建设银行";
            }
            else if (value == 4)
            {
                return "北京银行";
            }
            else if (value == 5)
            {
                return "广发银行";
            }
            else if (value == 6)
            {
                return "工商银行";
            }
            else if (value == 7)
            {
                return "交通银行";
            }
            else if (value == 8)
            {
                return "农业银行";
            }
            else 
            {
                return "";
            }
        }

        /// <summary>
        /// 利率
        /// </summary>
        /// <param name="deposit_form"></param>
        /// <returns></returns>
        public static List<DropItem> GetRate(string deposit_form)
        {
            List<DropItem> list = new List<DropItem> ();
            if (deposit_form.Equals("ZCZQ"))
            {
                list.Add(new DropItem { ValueField = "1", DisplayField = "0.3500" });
                list.Add(new DropItem { ValueField = "2", DisplayField = "2.8500" });
                list.Add(new DropItem { ValueField = "3", DisplayField = "3.0500" });
                list.Add(new DropItem { ValueField = "4", DisplayField = "3.2500" });
                list.Add(new DropItem { ValueField = "5", DisplayField = "3.7500" });
                list.Add(new DropItem { ValueField = "6", DisplayField = "4.2500" });
                list.Add(new DropItem { ValueField = "7", DisplayField = "4.7500" });
            }
            else
            {
                list.Add(new DropItem { ValueField = "8", DisplayField = "2.8500"});
                list.Add(new DropItem { ValueField = "9", DisplayField = "2.9000" });
                list.Add(new DropItem { ValueField = "10", DisplayField = "3.0000" });
            }
            return list;
        }

        public static string DisplayRate(int value)
        {
            if (value == 1)
            {
                return "0.3500";
            }
            else if (value == 2 || value ==8)
            {
                return "2.8500";
            }
            else if (value == 3)
            {
                return "3.0500";
            }
            else if (value == 4)
            {
                return "3.2500";
            }
            else if (value == 5)
            {
                return "3.7500";
            }
            else if (value == 6)
            {
                return "4.2500";
            }
            else if (value == 7)
            {
                return "4.7500";
            }
            else if (value == 9)
            {
                return "2.9000";
            }
            else if (value == 10)
            {
                return "3.0000";
            }
            else 
            {
                return "";
            }
        }

        /// <summary>
        /// 收入类型
        /// </summary>
        /// <returns></returns>
        public static List<DropItem> GetIncomeType()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField ="",DisplayField=" "});
            list.Add(new DropItem { ValueField = "1", DisplayField = "工资" });
            list.Add(new DropItem { ValueField = "2", DisplayField = "奖金" });
            list.Add(new DropItem { ValueField = "3", DisplayField = "工资+奖金" });
            list.Add(new DropItem { ValueField = "4", DisplayField = "股票" });
            list.Add(new DropItem { ValueField = "5", DisplayField = "购物卡" });
            list.Add(new DropItem { ValueField = "6", DisplayField = "其他" });
            return list;
        }

        public static string DisplayIncomeType(int value)
        {
            if (value == 1)
            {
                return "工资";
            }
            else if (value == 2)
            {
                return "奖金";
            }
            else if (value == 3)
            {
                return "工资+奖金";
            }
            else if (value == 4)
            {
                return "股票";
            }
            else if (value == 5)
            {
                return "购物卡";
            }
            else if (value == 6)
            {
                return "其他";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 利率前缀
        /// </summary>
        /// <returns></returns>
        public static List<DropItem> GetRateType()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField = "1", DisplayField = "ZCZQ" });
            list.Add(new DropItem { ValueField = "2", DisplayField = "ZCLQ" });
            list.Add(new DropItem { ValueField = "3", DisplayField = "LCZQ" });
            list.Add(new DropItem { ValueField = "4", DisplayField = "CBQX" });
            return list;
        }

        public static List<DropItem> GetRoleType()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField="1",DisplayField="管理员"});
            list.Add(new DropItem { ValueField = "2", DisplayField = "使用者" });
            return list;
        }

        public static string DisplayRole(int value)
        {
            if (value == 1)
            {
                return "管理员";
            }
            else if (value == 2)
            {
                return "使用者";
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<DropItem> GetAccountType()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField ="1",DisplayField="储蓄账户"});
            list.Add(new DropItem { ValueField = "2", DisplayField = "信用账户" });
            return list;
        }

        public static string DisplayAccountType(int value)
        {
            if (value == 1)
            {
                return "储蓄账户";
            }
            else if (value == 2)
            {
                return "信用账户";
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<DropItem> GetIncomeStatus()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField ="",DisplayField =" "});
            list.Add(new DropItem { ValueField="1",DisplayField="活期"});
            list.Add(new DropItem { ValueField = "2", DisplayField = "到期" });
            list.Add(new DropItem { ValueField = "3", DisplayField = "未到期" });
            list.Add(new DropItem { ValueField = "4", DisplayField = "自动转存未到期" });
            return list;
        }

        public static string DisplayIncomeStatus(int i)
        {
            if (i == 1)
            {
                return "活期";
            }
            else if (i == 2)
            {
                return "到期";
            }
            else if (i == 3)
            {
                return "未到期";
            }
            else if (i == 4)
            {
                return "自动转存未到期";
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<DropItem> GetIncomDepositMode()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField = "", DisplayField = " " });
            list.Add(new DropItem { ValueField = "1", DisplayField = "代发工资" });
            list.Add(new DropItem { ValueField = "2", DisplayField = "转账" });
            list.Add(new DropItem { ValueField = "3", DisplayField = "汇款" });
            list.Add(new DropItem { ValueField = "4", DisplayField = "现金" });
            list.Add(new DropItem { ValueField = "5", DisplayField = "其他" });
            return list;
        }

        public static string DisplayIncomeDepositMode(int i)
        {
            if (i == 1)
            {
                return "代发工资";
            }
            else if (i == 2)
            {
                return "转账";
            }
            else if (i == 3)
            {
                return "汇款";
            }
            else if (i == 4)
            {
                return "现金";
            }
            else if (i == 5)
            {
                return "其他";
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<DropItem> GetSpendMode()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField = "", DisplayField = " " });
            list.Add(new DropItem { ValueField = "1", DisplayField = "现金" });
            list.Add(new DropItem { ValueField = "2", DisplayField = "刷卡" });
            return list;
        }

        public static string DisplaySpendMode(int value)
        {
            if (value == 1)
            {
                return "现金";
            }
            else if (value == 2)
            {
                return "刷卡";
            }
            else
            {
                return string.Empty;
            }
        }

        public static List<DropItem> GetSpendType()
        {
            List<DropItem> list = new List<DropItem>();
            list.Add(new DropItem { ValueField = "", DisplayField = " " });
            list.Add(new DropItem { ValueField = "1", DisplayField = "超市" });
            list.Add(new DropItem { ValueField = "2", DisplayField = "吃饭" });
            list.Add(new DropItem { ValueField = "3", DisplayField = "交通" });
            list.Add(new DropItem { ValueField = "4", DisplayField = "购物" });
            list.Add(new DropItem { ValueField = "5", DisplayField = "生活" });
            list.Add(new DropItem { ValueField = "6", DisplayField = "旅游" });
            list.Add(new DropItem { ValueField = "7", DisplayField = "电影" });
            list.Add(new DropItem { ValueField = "8", DisplayField = "电子产品" });
            return list;
        }

        public static string DisplaySpendType(int value)
        {
            if (value == 1)
            {
                return "超市";
            }
            else if (value == 2)
            {
                return "吃饭";
            }
            else if (value == 3)
            {
                return "交通";
            }
            else if (value == 4)
            {
                return "购物";
            }
            else if (value == 5)
            {
                return "生活";
            }
            else if (value == 6)
            {
                return "旅游";
            }
            else if (value == 7)
            {
                return "电影";
            }
            else if (value == 8)
            {
                return "电子产品";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}