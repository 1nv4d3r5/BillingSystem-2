<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="BillingSystem.Views.SystemSetting.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript">
            function closeWin() {
                //window.opener.location.reload();
                //window.opener = null;
               // window.close();
                window.opener.location = window.opener.location;
                window.close();
                //window.opener.close();
            }
            function setSize() {
                window.moveTo(window.screen.availWidth-window.screen.availWidth*0.8,window.screen.availHeight-window.screen.availHeight*0.8);
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-top:1px;">
<%--            <asp:Label runat="server" Text="用户名:" Width="70px"/>
            <asp:TextBox runat="server" ID="txtUserName" style="margin-left:1px;width:130px;height:16px;"/>--%>
        </div>
        <div style="margin-top:1px;">

        </div>
        <div style="margin-top:1px;">

        </div>
        <div style="margin-top:1px;">

        </div>
        <div style="margin-top:1px;">
        </div>
        <div style="margin-top:1px;">
            <asp:Label ID="Label4" runat="server" Text="备注:" Width="70px" />
            
        </div>
        <div style="float:left;margin-left:115px;margin-top:10px;">
            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick ="btnSave_Click" />
            <input type="button" id="btnCancel" onclick="closeWin()" value="取消"/>
        </div>
    </form>
</body>
</html>
