<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InComeAdd.aspx.cs" Inherits="BillingSystem.InComeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function closeWin() {
            window.opener.location.reload();
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server" style="width:30%;height:40%">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="卡号：" Width="80" />
                    </td>
                    <td>
                        <asp:DropDownList runat="server" Width="200" ID="dropCardNumber">
                            
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="收入类型：" Width="80" />
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="dropInComeType" Width="100" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="存款类型:" />
                    </td>
                    <td>
                        <asp:DropDownList runat="server" Width="60" ID="dropPrefix" OnSelectedIndexChanged="dropPrefix_SelectedIndexChanged" AutoPostBack="true"/>
                        <asp:DropDownList runat="server" Width="100" ID="dropMode"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="金额:" Width="80" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID ="txtAmount"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="利率：" />
                    </td>
                    <td>
                        <asp:DropDownList runat="server" Width="100" ID="dropRate" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="存入日期" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="depositDate" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="开始日期：" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="bdate" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="结束日期：" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="edate" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="存款人:" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="DepositorName" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox runat="server" Text="是否自动转存" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button runat="server" Text="保存" ID="btnSave" OnClick="btnSave_Click"/>
                        <input type="button" value="取消" onclick="closeWin()" />
<%--                        <asp:Button runat="server" Text="取消" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
