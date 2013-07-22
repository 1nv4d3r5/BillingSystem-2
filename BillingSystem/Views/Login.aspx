<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BillingSystem.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <asp:Label runat ="server" Text="用户名：" Width="70" Font-Size="12" />
            </td>
            <td>
                <asp:TextBox runat="server" ID ="txtUserName" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="密码：" Width="70" Font-Size="12" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnlogin" Text="登陆" OnClick="btnlogin_Click"/>
            </td>
            <td>
                <asp:Button runat ="server" ID ="btnCancel" Text="取消" OnClick="btnCancel_Click"/>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:right">
                <asp:Label runat="server" Text="注册" Font-Size="8" ForeColor="Blue" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
