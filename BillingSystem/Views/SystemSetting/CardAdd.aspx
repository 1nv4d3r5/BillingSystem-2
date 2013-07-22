<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardAdd.aspx.cs" Inherits="BillingSystem.Views.SystemSetting.CardAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function closeWin() {
            window.opener.location = window.opener.location;
            window.close();
        }
        function closeWinCanel() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; margin-left: 15px;">
            <div style="width: 100%; height: 22px;">
                <asp:Label runat="server" ID="labTitle" Font-Bold="true" />
            </div>
            <div style="width: 100%; height: 22px; margin-top: 10px;">
                <asp:Label ID="Label2" runat="server" Text="卡号:" Width="75px" />
                <asp:TextBox runat="server" ID="txtAddCardNumber" Width="230px" />
            </div>
            <div style="width: 100%; height: 22px; margin-top: 10px;">
                <div style="width: 260px; height: 22px; float: left;">
                    <asp:Label runat="server" Text="账户类型:" Width="75px" />
                    <asp:DropDownList runat="server" ID="dropCardAddAccountType" Width="164px" Height="22px" />
                </div>
                <div style="width: 260px; height: 22px; float: left;">
                    <asp:Label ID="Label1" runat="server" Text="所属银行:" Width="75px" />
                    <asp:DropDownList runat="server" Width="164px" Height="22px" ID="dropAddBank" />
                </div>
            </div>
            <div style="width: 100%; height: 22px; margin-top: 10px;">
                <div style="width: 260px; height: 22px; float: left">
                    <asp:Label ID="Label3" runat="server" Text="卡所有者:" Width="75px" />
                    <asp:DropDownList runat="server" Width="164px" Height="22px" ID="dropAddCardOwner" />
                </div>
                <div style="width: 260px; height: 22px; float: left">
                    <asp:Label ID="Label6" runat="server" Text="使用者:" Width="75px" />
                    <asp:DropDownList runat="server" ID="dropAddCardUser" Width="164px" />
                </div>
            </div>
            <div style="width: 100%; height: 22px; margin-top: 10px;">

                <div style="width: 260px; height: 22px; float: left;">
                    <asp:Label ID="Label4" runat="server" Text="开户银行:" Width="75px" />
                    <asp:TextBox runat="server" ID="txtAddBankName" Width="160px" />
                </div>
                <div style="width: 260px; height: 22px; float: left">
                    <asp:Label ID="Label5" runat="server" Text="开户日期:" Width="75px" />
                    <asp:TextBox runat="server" ID="txtAddCardOpenDate" Width="160px" />
                </div>
            </div>
            <div style="width: 100%; height: 44px; margin-top: 10px;">
                <div style="width: 83px; height: 22px; float: left">
                    <asp:Label ID="Label7" runat="server" Text="备注:" Width="75px" />
                </div>
                <div style="width: 395px; height: 44px;float:left">
                    <asp:TextBox runat="server" ID="txtCardAddContent" Width="420px" Height="44px" />
                </div>


            </div>
        </div>
        <div style="width: 520px; height: 30px; text-align: center; margin-top: 30px;">
            <%--     <asp:Button runat="server" ID="btnCardAddClear" Text="清空" Width="50px" Height="25px" OnClick="btnCardAddClear_Click" />--%>
            <asp:Button runat="server" ID="btnCardAddSave" Text="保存" Width="50px" Height="25px" OnClick="btnCardAddSave_Click" />
            <asp:Button runat="server" ID="btnCardAddCanel" Text="取消" Width="50px" Height="25px" OnClick="btnCardAddCanel_Click" />
        </div>
    </form>
</body>
</html>
