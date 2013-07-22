using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BillingSystem
{
    public sealed class OpenNewWindow
    {
        public OpenNewWindow()
        {
        }

        #region 打开一个窗口，并且这个窗口位于最前面
        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面
        /// </summary>
        /// <param name="page">调用的页面</param>
        /// <param name="url">要打开的URL</param>
        /// <param name="pageName">要打开页面的名称</param>
        /// <param name="win_width">窗口宽度</param>
        /// <param name="win_height">窗口高度</param>
        /// <param name="left">窗口左侧位置</param>
        /// <param name="top">窗口右侧位置</param>
        /// <param name="centerFlag">是否居中 yes/no</param>
        /// <param name="status">是否显示状态栏 yes/no</param>
        /// <param name="parentFlag">true:不关闭弹出窗口，将不能操作父窗口 false 可以操作父窗口</param>
        public static void OpenANewWindow(Page page, string url, string pageName, string win_width, string win_height, string left, string top, string centerFlag, string status, bool parentFlag)
        {
            string scriptStr = string.Empty;
            if (parentFlag)
            {
                scriptStr = "<Script language=javascript>showModalDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                    + " dialogHeight:" + win_height + "px;dialogLeft:" + left + "px;dialogTop:" + top + "px;center:" + centerFlag.ToString() + ";help:no;resizeable:yes;status:" + status + "')</scirpt>";
            }
            else
            {
                scriptStr = "<script language=javascript>showModelessDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                    + "dialogHeight:" + win_height + "px;dialogLeft:" + left + "px;dialogTop:" + top + "px;center:" + centerFlag.ToString() + ";help:no;resizeable:yes;status:" + status + "')</script>";
            }
            page.Response.Write(scriptStr);
        }

        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        /// <param name="pageName"></param>
        /// <param name="win_width"></param>
        /// <param name="win_height"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="centerFlag"></param>
        /// <param name="parentFlag"></param>
        public static void OpenANewWindow(Page page, string url, string pageName, string win_width, string win_height, string left, string top, string centerFlag, bool parentFlag)
        {
            string scriptStr = string.Empty;
            if (parentFlag)
            {
                scriptStr = "<script language=javascript>showModalDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                    + "dialogHeight:" + win_height + "px;dialogLeft:" + left + "px;dialogTop:" + top + "px;center:" + centerFlag + ";help:no;resizeable:yes;status:no')</script>";

            }
            else
            {
                scriptStr = "<script language=javascript>showModelessDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                   + "dialogHeight:" + win_height + "px;dialogLeft:" + left + "px;dialogTop:" + top + "px;center:" + centerFlag + ";help:no;resizeable:yes;status:no')</script>";

            }
            page.Response.Write(scriptStr);
        }

        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        /// <param name="pageName"></param>
        /// <param name="win_width"></param>
        /// <param name="win_height"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="parentFlag"></param>
        public static void OpenANewWindow(Page page, string url, string pageName, string win_width, string win_height, string left, string top, bool parentFlag)
        {
            string scriptStr = string.Empty;
            if (parentFlag)
            {
                scriptStr = "<script language=javascript>showModalDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                    + "dialogHeight:" + win_height + "px;dialogLeft:" + left + "px;dialogTop:" + top + "px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            else
            {
                scriptStr = "<script language=javascript>showModelessDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                    + "dialogHeight:" + win_height + "px;dialogLeft:" + left + "px;dialogTop:" + top + "px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            page.Response.Write(scriptStr);
        }

        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        /// <param name="pageName"></param>
        /// <param name="win_width"></param>
        /// <param name="win_height"></param>
        /// <param name="parentFlag"></param>
        public static void OpenANewWindow(Page page, string url, string pageName, string win_width, string win_height, bool parentFlag)
        {
            string scriptStr = string.Empty;
            if (parentFlag)
            {
                scriptStr = "<script language=javascript>showModalDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                    + "dialogHeight:" + win_height + "px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";

            }
            else
            {
                scriptStr = "<script language=javascript>showModelessDialog('" + url + "','" + pageName + "','dialogWidth:" + win_width + "px;"
                    + "dialogHeight:" + win_height + "px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            page.Response.Write(scriptStr);
        }

        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        /// <param name="win_width"></param>
        /// <param name="win_height"></param>
        /// <param name="parentFlag"></param>
        public static void OpenANewWindow(Page page, string url, string win_width, string win_height, bool parentFlag)
        {
            string scriptStr = string.Empty;
            if (parentFlag)
            {
                scriptStr = "<script language=javascript>showModalDialog('" + url + "','','dialogWidth:" + win_width + "px;"
                   + "dialogHeight:" + win_height + "px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            else
            {
                scriptStr = "<script language=javascript>showModelessDialog('" + url + "','','dialogWidth:" + win_width + "px;"
                    + "dialogHeight:" + win_height + "px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            page.Response.Write(scriptStr);
        }
        #endregion
    }
}