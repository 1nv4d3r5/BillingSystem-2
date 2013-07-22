<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Install.aspx.cs" Inherits="BillingSystem.Views.Install" %>

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
                <asp:Button runat ="server" ID ="btnCreate" text="初始化系统" OnClick="BtnCreate_Click"/>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
