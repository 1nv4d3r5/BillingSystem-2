<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salary.aspx.cs" Inherits="BillingSystem.Views.Salary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="income" runat="server" style="width: 100%; height: 100%;">
        <div>
            <table style="width: 100%; height: 100%" id="tab1">
                <tr>
                    <td style="width: 100%; height: 100%">
                        <asp:Button runat="server" Text="新增" ID="btnAdd" />
                        <asp:Button runat="server" Text="编辑" ID="btnEdit" Style="margin: 0 0 0 5px" />
                        <asp:Button runat="server" Text="删除" ID="btnDelete" Style="margin: 0 0 0 5px" />
                        <asp:Button runat="server" Text="查询" ID="btnQuery" Style="margin: 0 0 0 5px" />
                        <asp:Button runat="server" Text="导入" ID="btnImport" Style="margin: 0 0 0 5px" />
                        <asp:Button runat="server" Text="导出" ID="btnExport" Style="margin: 0 0 0 5px" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="上月收入:" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LabPreAmount" Text=""/>
                    </td>
                    <td>

                    </td>
                    <td>
                        <asp:Label runat="server" Text="本月收入:" />
                    </td>
                    <td>
                        <asp:Label runat="server" Text="" ID="LabDQAmount"/>

                    </td>
                </tr>
                <tr>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
