<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemSetting.aspx.cs" Inherits="BillingSystem.Views.SystemSetting.SystemSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: 800px;">
            <div style="width: 15%; float: left; height: 100%;">
                <div style="height: 3%;">
                    功能列表
                </div>
                <div style="height: 97%;">
                    <asp:TreeView runat="server" ID="SystemSettingTree" ImageSet="Arrows" EnableTheming="true" ShowCheckBoxes="Parent">
                        <Nodes>
                            <asp:TreeNode Text="卡信息维护" NavigateUrl="~/Views/SystemSetting/CardSetting.aspx" Target="Content" Value="卡信息维护"></asp:TreeNode>
                            <asp:TreeNode Text="用户信息维护" NavigateUrl="~/Views/SystemSetting/UserSetting.aspx" Target="Content" Value="用户信息维护">
                                <%--<asp:TreeNode Text="修改密码"  Target ="Content" Value ="修改密码" />--%>
                            </asp:TreeNode>

                        </Nodes>
                    </asp:TreeView>
                </div>
            </div>
            <div style="width: 85%; height: 100%; float: left">
                <iframe id="Content" style="width: 100%; height: 800px;" frameborder="0" scrolling="auto"></iframe>
            </div>
        </div>
    </form>
    <%--    <form id="form1" runat="server">
        <table style="width: 100%;height:800px;">
            <tr>
                <td style="width:15%;">
                    <div>
                        <div>
                            功能列表
                        </div>
                        <div id="tree">
                            <asp:TreeView runat="server" ID="SystemSettingTree" ImageSet="Arrows" EnableTheming="true" ShowCheckBoxes="Parent">
                                <Nodes>
                                    <asp:TreeNode Text="用户信息维护" NavigateUrl="~/Views/SystemSetting/UserSetting.aspx" Target="Content" Value="用户信息维护"></asp:TreeNode>
                                </Nodes>
                            </asp:TreeView>
                        </div>
                    </div>
                </td>
                <td >
                    <iframe id="Content" style="width: 100%;height:800px;" frameborder="0" scrolling="auto"></iframe>
                </td>
            </tr>
        </table>
    </form>--%>
</body>
</html>
