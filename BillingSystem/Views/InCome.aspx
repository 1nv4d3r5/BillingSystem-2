<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InCome.aspx.cs" Inherits="BillingSystem.Views.InCome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="height: initial;">
        <table style="width: 100%; height: 100%">
            <tr>
                <td style="width: 13%;height:100%">
                    <table style="width:100%; height:100%;">
                        <tr>
                            <td style="text-align:left;width:100%;height:20%">导航</td>
                        </tr>
                        <tr>
                            <td style="width:100%;height:80%">
                                <asp:TreeView runat="server" ID="InComeTree" Width="100%" OnSelectedNodeChanged="InComeTree_SelectedNodeChanged" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 87%;">
                    <iframe runat="server" id="content" style="width: 100%;border-left:1px solid black;border-bottom:0;border-top:0;border-right:0" frameborder="0"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
