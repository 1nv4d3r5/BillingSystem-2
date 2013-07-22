<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardQuery.aspx.cs" Inherits="BillingSystem.Views.SystemSetting.CardQuery" %>

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
                <asp:Label runat="server" ID="labCardQueryTitle" Font-Bold="true" />
            </div>
            <div style="width: 100%; height: auto; margin-top: 10px;">
                <div style="width: 100%; height: 22px;">

                </div>
                <div style="width: 100%; height: 22px;margin-top:10px;">
                    
                </div>
                <div style="width: 100%; height: 22px; margin-top: 10px;">
                    
                </div>
                <div style="width: 100%; height: 22px; margin-top: 10px;">
                    
                </div>
            </div>
            <div style="width: 520px; height: 30px; text-align: center; margin-top: 30px;">
                <asp:Button runat="server" Text="确定" ID="btnCardQuerySelect" Width="50px" OnClick="btnCardQuerySelect_Click" />
                <asp:Button runat="server" Text="取消" ID="btnCardQueryCanel" Width="50px"  OnClick="btnCardQueryCanel_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
