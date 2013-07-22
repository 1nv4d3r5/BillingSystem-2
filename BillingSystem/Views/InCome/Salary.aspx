<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salary.aspx.cs" Inherits="BillingSystem.Views.Salary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script lang="JavaScript" type ="text/javascript">
        function OpenWin(str)
        {
           window.open(str, "new", "height=300px,width=400px,top=0,left=0,toolbar=0,menubar=no,scrollbars=yes,resizable=no,location=no,status=no");
        }

    </script>
</head>
<body>
    <form id="income" runat="server" style="width: 100%; height: 100%;">
<div style="width: 100%; height: auto; margin-left: 1%;">
            <div style="width: 100%; height: auto;">
                <div id="divCardTitle" style="width: 100%; height: 22px; margin-left: 5px; font-size: 18px; font-style: normal; vertical-align: central;">
                    收入管理
                </div>
                <div id="divSet" style="width: 100%; height: auto; margin-top: 15px;">
                    <div style="width: 5%; height: 3%; margin-left: 3px; margin-top: 3px; display: inline">
                        <asp:Button runat="server" Text="新增" ID="btnInComeAdd" Width="60px" />
                    </div>
                    <div style="width: 5%; height: 3%; margin-left: 3px; display: inline">
                        <asp:Button runat="server" Text="高级查询" ID="btnInComeQuery"/>
                    </div>
                </div>
                <div id="InComeEdit" style="width: auto; height: auto;">
                    <div style="width: 100%; height: 28px; margin-top: 15px;">
                        <div style="width: 44%; height: 28px; vertical-align: middle; float: left;">
                            <asp:Label ID="Label2" runat="server" Text="卡号:" Width="75px" Height="22px" />
                            <asp:DropDownList runat="server" ID="dropInComeAddCardNumber" Width="264" Height="28px" />
                        </div>
                        <div style="width: 22%; height: 28px; float: left; vertical-align: middle">
                            <asp:Label ID="Label1" runat="server" Text="收入类型:" Width="75px" Height="22px" />
                            <asp:DropDownList runat="server" ID="dropInComeAddInComeType" Width="134px" Height="28px" />
                        </div>
                        <div style="width: 22%; height: 28px; vertical-align: middle; float: left">
                            <asp:Label ID="Label3" runat="server" Text="存款类型:" Width="75px" Height="22px" />
                            <asp:DropDownList runat="server" Width="134px" Height="28px" ID="dropInComeAddMode" />
                        </div>
                    </div>
                    <div style="width: 100%; height: 28px; margin-top: 15px;">
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label4" runat="server" Text="金额:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" Width="130px" Height="18px" ID="txtInComeAddAmount" />
                        </div>
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label6" runat="server" Text="利率:" Width="75px" Height="22px" />
                            <asp:DropDownList runat="server" ID="dropInComeAddRate" Width="134px" Height="22px" />
                        </div>
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label5" runat="server" Text="存入日期:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" ID="txtInComeAddDepositDate" Width="130px" Height="18px" />
                        </div>
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label7" runat="server" Text="存款人:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" ID="txtInComeAddDepositorName" Width="130px" Height="18px" />
                        </div>
                    </div>
                    <div style="width: 100%; height: 28px; margin-top: 15px;">
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label16" runat="server" Text="开始日期:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" Width="130px" Height="18px" ID="txtInComeAddBDate" />
                        </div>
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label18" runat="server" Text="到期日期:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" ID="txtInComeAddEDate" Width="130px" Height="18px" />
                        </div>
                        <div style="width: 22%; height: 28px; vertical-align: middle; float: left">
                            <asp:Label ID="Label17" runat="server" Text="状态:" Width="75px" Height="22px" />
                            <asp:DropDownList runat="server" Width="134px" Height="28px" ID="dropInComeAddStatus" />
                        </div>
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle;">
                            <asp:CheckBox runat ="server" ID="checkInComeAddAutoSave" Text="是否自动转存" Width="210px" Height="22px" />
                        </div>
                    </div>

                    <div style="width: 100%; height: 44px; margin-top: 15px;">
                        <div style="width: 82px; height: auto; float: left">
                            <asp:Label ID="Label8" runat="server" Text="备注:" Width="82px" Height="22px" />
                        </div>
                        <div style="width: 85%; height: 44px; float: left">
                            <asp:TextBox runat="server" ID="txtInComeAddContent" Width="89%" Height="36px" />
                        </div>
                        <div style="width: auto; height: 22px; text-align: right; float: left; margin-top: 15px; vertical-align: central">
                            <asp:Button runat="server" Text="提交" ID="btnInComeEditSave" Width="40px" OnClick="btnInComeEditSave_Click" />
                            <asp:Button runat="server" Text="后退" ID="btnInComeEditCanel" Width="40px" OnClick="btnInComeEditCanel_Click" />
                        </div>
                    </div>
                </div>
                <div id="cardQuery" style="width: auto; height: auto;">
                    <div style="width: 100%; height: 22px; margin-top: 15px;">
                        <div style="width: 44%; height: 22px; vertical-align: middle; float: left;">
                            <asp:Label ID="Label9" runat="server" Text="卡号:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" ID="txtCardQueryCardNumber" Width="260px" Height="18px" />
                        </div>
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle">
                            <asp:Label ID="Label10" runat="server" Text="账户类型:" Width="75px" />
                            <asp:DropDownList runat="server" ID="dropCardQueryAccountType" Width="134px" Height="28px" />
                        </div>
                        <div style="width: 22%; height: 22px; float: left; vertical-align: middle">
                            <asp:Label ID="Label11" runat="server" Text="所属银行:" Width="75px" Height="22px" />
                            <asp:DropDownList runat="server" ID="dropCardQueryBank" Width="134px" Height="28px" />
                        </div>
                    </div>
                    <div style="width: 100%; height: 28px; margin-top: 15px;">
                        <div style="width: 22%; height: 28px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label12" runat="server" Text="卡使用者:" Width="75px" Height="22px" />
                            <asp:DropDownList runat="server" ID="dropCardQueryUser" Width="134px" Height="28px" />
                        </div>
                        <div style="width: 22%; height: 28px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label13" runat="server" Text="开户银行:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" ID="txtCardQueryBankName" Width="130px" Height="22px" />
                        </div>
                        <div style="width: 22%; height: 28px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label14" runat="server" Text="开户日期:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" ID="txtCardQueryBOpenDate" Width="130px" Height="22px" />
                        </div>
                        <div style="width: 22%; height: 28px; float: left; vertical-align: middle;">
                            <asp:Label ID="Label15" runat="server" Text="到:" Width="75px" Height="22px" />
                            <asp:TextBox runat="server" ID="txtCardQueryEOpenDate" Width="130px" Height="22px" />
                        </div>

                        <div style="width: 127px; height: 22px; text-align: right; float: left;">
                            <asp:Button runat="server" Text="查询" ID="btnCardQuerySelect" Width="40px" OnClick="btnCardQuerySelect_Click" />
                            <asp:Button runat="server" Text="后退" ID="btnCardQueryCanel" Width="40px" OnClick="btnCardQueryCanel_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 100%; height: auto; margin-top: 15px;">
                <hr />
            </div>
            <div style="width: 100%; height: auto; margin-left: 2px; margin-top: 20px;">
                <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="CardListDataGrid" Width="100%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle">
                    <AlternatingItemStyle BorderStyle="None" />
                    <Columns>
                        <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" Visible="false" />
                        <asp:HyperLinkColumn HeaderText="CardNumber" DataTextField="CardNumber" DataNavigateUrlField="CardNumber" DataNavigateUrlFormatString="javascript:openCardEditWin({0})" ItemStyle-Width="8%" Target="_blank" />
                        <asp:BoundColumn ReadOnly="true" DataField="AccountType" HeaderText="AccountType" ItemStyle-Width="3%" />
                        <asp:BoundColumn ReadOnly="true" DataField="BankId" HeaderText="BankName" ItemStyle-Width="5%" />
                        <asp:BoundColumn ReadOnly="true" DataField="Amount" HeaderText="Amount" ItemStyle-Width="3%" />
                        <asp:BoundColumn ReadOnly="true" DataField="ExpenditureAmount" HeaderText="ExpenditureAmount" ItemStyle-Width="3%" />
                        <asp:BoundColumn ReadOnly="true" DataField="BorrowAmount" HeaderText="BorrowAmount" ItemStyle-Width="3%" />
                        <asp:BoundColumn ReadOnly="true" DataField="IncomeAmount" HeaderText="IncomeAmount" ItemStyle-Width="3%" />
                        <asp:BoundColumn ReadOnly="true" DataField="OwnerName" HeaderText="OwnerName" ItemStyle-Width="5%" />
                        <asp:BoundColumn ReadOnly="true" DataField="UserName" HeaderText="UserName" ItemStyle-Width="5%" />
                        <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="8%">
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnCardDelete" runat="server" />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </div>
        </div>
    </form>
</body>
</html>
