<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Borrowed.aspx.cs" Inherits="BillingSystem.Views.Borrowed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="margin-left">
            <div>
                <div id="divBorrowTitle" style="font-size: 18px; margin-top: 5px;">
                    支出管理
                </div>
                <br />
                <div id="divSet">
                    <div class="controls controls-row">
                        <div class="span3">
                            <asp:Button runat="server" Text="新增" ID="btnBorrowAdd" CssClass="btn btn-primary" OnClick="btnBorrowAdd_Click"/>
                            <asp:Button runat="server" Text="高级查询" ID="btnBorrowQuery" CssClass="btn btn-primary" OnClick="btnBorrowQuery_Click" />
                        </div>
                    </div>
                </div>
                <div id="BorrowEdit">
                    <div class="controls controls-row">
                    </div>
                    <div class="controls controls-row">
                    </div>
                    <div class="controls controls-row">
                    </div>
                    <div class="controls controls-row">
                        <label class="span1">&nbsp;</label>
                        <div class="span2">
                            <asp:Button runat="server" ID="btnBorrowAddSubmit" CssClass="btn btn-primary" Text="提交" OnClick="btnBorrowAddSubmit_Click" />
                            <asp:Button runat="server" ID="btnBorrowAddCanel" CssClass="btn btn-primary" Text="后退" OnClick="btnBorrowAddCanel_Click" />
                        </div>
                    </div>
                </div>

                <div id="BorrowQuery" style="margin-top: 15px;">
                    <div class="controls controls-row">
<%--                        <asp:Label ID="Label1" runat="server" Text="卡号:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryCardNumber" CssClass="span3" />
                        <asp:Label ID="Label2" runat="server" Text="分类:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropExpensesQuerySpendType" CssClass="span2" />
                        <asp:Label ID="Label3" runat="server" Text="方式:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropExpensesQuerySpendMode" CssClass="span2" />--%>
                    </div>
                    <div class="controls controls-row">
<%--                        <asp:Label ID="Label4" runat="server" Text="消费者:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryConsumerName" CssClass="span2" />
                        <label class="span1">&nbsp;</label>
                        <asp:Label ID="Label5" runat="server" Text="消费日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryBSpendDate" CssClass="span2" />
                        <asp:Label ID="Label6" runat="server" Text="到:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryESpendDate" CssClass="span2" />--%>
                        <div class="span2">
                            <asp:Button runat="server" ID="btnBorrowQuerySubmit" Text="查询" CssClass="btn btn-primary" OnClick="btnBorrowQuerySubmit_Click" />
                            <asp:Button runat="server" ID="btnBorrowQueryCanel" Text="后退" CssClass="btn btn-primary" OnClick="btnBorrowQueryCanel_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="BorrowListDataGrid" Width="100%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" Font-Size="Small"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" SelectedItemStyle-BorderColor="Red" OnItemCommand="BorrowListDataGrid_ItemCommand" >
                            <Columns>
                                <%--<asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" Visible="false" />
                                <asp:HyperLinkColumn HeaderText="卡号" DataTextField="BankCardNumber" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openBorrowEditWin('{0}')" ItemStyle-Width="10%" />
                                <asp:BoundColumn ReadOnly="true" DataField="OwnerName" HeaderText="所有者" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Amount" HeaderText="金额" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="SpendType" HeaderText="分类" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="HowToUse" HeaderText="用途" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="SpendDate" HeaderText="消费日期" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="SpendMode" HeaderText="消费方式" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="ConsumerName" HeaderText="消费者" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Price" HeaderText="单价" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Number" HeaderText="数量" ItemStyle-Width="6%" />--%>
                                <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="btnBorrowDelete" ImageUrl="~/Images/delete/1.jpg" CommandName="BorrowImageDelete" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
