<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillingSystemMainPage.aspx.cs" Inherits="BillingSystem.Views.BillingSystemMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/bootstrap.css" />
    <script type="text/ecmascript" lang="ja">
        function displayWelcome() {

        }
    </script>
</head>
<body style="width:100%">
    <form id="form1" style="width: 100%;" runat="server">
        <div style="width: 100%; background-color: #cccfd2;">
            <div style="width:100%" >
                <iframe id="Iframe1" style="width:100%; height: 90.5px;" frameborder="0" src="Default.aspx"></iframe>
            </div>
        </div>
        <div  style="width:100%">
            <div style="width:100%">
                <div style="width: 13%;float:left">
                    <div style="background-color:#cccfd2;height:20px;">
                        <asp:Label runat="server" Text="导航" Font-Bold="true" CssClass="span1" />
                    </div>
                    <div style="margin-left: 5px; height: 771px;">
                        <asp:TreeView ID="tree" runat="server" Height="700px" ImageSet="Arrows" Width="100%"
                            EnableTheming="True" ForeColor="Blue" ShowCheckBoxes="Parent">
                            <Nodes>
                                <asp:TreeNode Text="系统设置" Value="system" Target="content">
                                    <asp:TreeNode Text="用户信息维护" Value="用户信息维护" NavigateUrl="~/Views/SystemSetting/UserSetting.aspx" Target="content" />
                                    <asp:TreeNode Text="卡信息维护" Value="卡信息维护" NavigateUrl="~/Views/SystemSetting/CardSetting.aspx" Target="content" />                              
                                    <asp:TreeNode Text="修改密码" Value="修改密码" NavigateUrl="~/Views/SystemSetting/ModifyPassword.aspx" Target="content" />
                                </asp:TreeNode>
                                <asp:TreeNode Text="收入管理" Value="InCome" Target="content" >
                                    <asp:TreeNode Text="收入管理" Value="收入管理" NavigateUrl="~/views/InCome/InCome.aspx" Target="content" />
                                </asp:TreeNode>
                                <asp:TreeNode Text="支出管理" Value="Expenses" Target="content" >
                                    <asp:TreeNode Text="支出管理" Value="支出管理" NavigateUrl="~/Views/Expenses/Expenses.aspx" Target="content" />
                                </asp:TreeNode>
                                <asp:TreeNode Text="借贷管理" Value="BorrowORLoan" Target="content" >
                                    <asp:TreeNode Text="借入管理" Value="借入管理" NavigateUrl="~/Views/Borrowing/Borrowed.aspx" Target="content" />
                                    <asp:TreeNode Text="借出管理" Value="借出管理" NavigateUrl="~/Views/Borrowing/Loan.aspx" Target="content" />
                                </asp:TreeNode>
                                <asp:TreeNode Text="资产管理" Value="asset_management" Target="content"></asp:TreeNode>
                            </Nodes>
                            <HoverNodeStyle BackColor="#0099FF" />
                            <SelectedNodeStyle BackColor="SkyBlue" />
                        </asp:TreeView>
                    </div>
                </div>
                <div style="width: 87%; float: left; height: 794px;">
                    <%--                    <iframe id="content" style="width: 100%; height: 100%;border-left:1px;border-left-style:inset;border-top-style:none"  ></iframe>--%>
                    <iframe id="content" style="width: 100%; height: 100%; border-left-style: inset; border-top-style: none; border-left-color: inherit; border-left-width: 1px;"></iframe>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
