using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem
{
    public static class HelperCommon
    {
        public static bool ValidDateTime(string bdateStr, string edateStr)
        {
            DateTime bdate, edate;
            bdate = ConverToDateTime(bdateStr);
            edate = ConverToDateTime(edateStr);
            if (bdate > edate)
            {
                return false;
            }
            return true;
        }

        public static DateTime ConverToDateTime(string dateStr)
        {
            DateTime date;
            int year, month, day;
            year = Convert.ToInt32(dateStr.Substring(0, 4));
            month = Convert.ToInt32(dateStr.Substring(5, 2));
            day = Convert.ToInt32(dateStr.Substring(8, 2));
            date = new DateTime(year, month, day);
            return date;
        }

        public static bool ComparDay(string bdateStr,string edateStr)
        {
            DateTime bdate, edate;
            bdate = ConverToDateTime(bdateStr);
            edate = ConverToDateTime(edateStr);
            System.TimeSpan span=edate-bdate;
            if (span.Days<91)
            {
                return false;
            }
            return true;
        }

        public static bool CompareAccordToRequired(DateTime date)
        {
            DateTime newdate = new DateTime(2000,01,01);
            if (DateTime.Compare(date,newdate)>0)
            {
                return true;
            }
            return false;
        }
    }
}