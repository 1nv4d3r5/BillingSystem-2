<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expenses.aspx.cs" Inherits="BillingSystem.Views.Expenses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../../Css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/css.css" />
    <script src="../../Scripts/jquery-2.0.3.min.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript" lang="ja">
        function openExpensesEditWin(id) {
            location.replace(" Expenses.aspx?ExpensesId=" + id);
        }

        function DisplaySysdiv() {
            document.getElementById("divSet").style.display = '';
            document.getElementById("ExpensesEdit").style.display = 'none';
            document.getElementById("ExpensesQuery").style.display = 'none';
            document.getElementById("divExpensesTitle").innerText = "支出管理";
        }

        function DisplayExpensesAdddiv() {
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("ExpensesEdit").style.display = '';
            document.getElementById("ExpensesQuery").style.display = 'none';
            document.getElementById("divExpensesTitle").innerText = "支出管理--新增";
        }

        function DisplayExpensesQuerydiv() {
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("ExpensesEdit").style.display = 'none';
            document.getElementById("ExpensesQuery").style.display = '';
            document.getElementById("divExpensesTitle").innerText = "支出管理--查询";
        }

        function DisplayExpensesEditdiv(cardNumber) {

            document.getElementById("divSet").style.display = 'none';
            document.getElementById("ExpensesEdit").style.display = '';
            document.getElementById("ExpensesQuery").style.display = 'none';
            document.getElementById("divExpensesTitle").innerText = "支出管理--编辑";
        }

        //$(function () {
        //    $("#ExpensesListDataGrid tr").first().nextAll().bind('click', function () {
        //        if ($(this).css("background-color") != $("#ExpensesListDataGrid").css("background-color"))
        //            $(this).css('background-color', '#ffffff');
        //        else
        //            $(this).css('background-color', '#dff');
        //    });
        //});
        $(function () {
            $("#ExpensesListDataGrid tr").bind('click', function () {
                //var tr1 = $("#ExpensesListDataGrid tr").first().nextAll();
                //tr1.each(function (i) {this.style.backgroundColor=['#ccc'] });
                $("#ExpensesListDataGrid tr.highlight").removeClass('highlight');
                $(this).toggleClass("highlight");
            });
        });
    </script>

</head>
<body>
    <form id="Expenses" runat="server" style="width: 99%; height: 100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="margin-left">
            <div>
                <div id="divExpensesTitle" class="title">
                    支出管理
                </div>
                <br />
                <div id="divSet">
                    <div class="controls controls-row">
                        <div class="span4">
                            <asp:Button runat="server" Text="新增" ID="btnExpensesAdd" CssClass="btn btn-primary" OnClick="btnExpensesAdd_Click" />
                            <asp:Button runat="server" Text="高级查询" ID="btnExpensesQuery" CssClass="btn btn-primary" OnClick="btnExpensesQuery_Click" />
                        </div>
                    </div>
                </div>
                <div id="ExpensesEdit">
                    <div class="controls controls-row">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" Text="卡号:" CssClass="span1" />
                                <asp:DropDownList runat="server" ID="dropExpensesAddCardNumber" CssClass="span3" AutoPostBack="true" OnSelectedIndexChanged="dropExpensesAddCardNumber_SelectedIndexChanged" />
                                <label class="span2">&nbsp;</label>
                                <asp:Label ID="Label2" runat="server" Text="所有者:" CssClass="span1" />
                                <asp:DropDownList runat="server" ID="dropExpensesAddOwner" CssClass="span2" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Label runat="server" Text="金额:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesAddAmount" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label1" runat="server" Text="消费日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesAddSpendDate" CssClass="span2" />

                        <asp:Label runat="server" Text="分类:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropExpensesAddSpendType" CssClass="span2" />
                        <asp:Label runat="server" Text="消费方式:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropExpensesAddSpendMode" CssClass="span2" />
                        <asp:Label runat="server" Text="消费者:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesAddConsumerName" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="用途" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesAddHowToUse" CssClass="span2" />
                        <asp:Label runat="server" Text="单价:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesAddPrice" CssClass="span2" />
                        <asp:Label runat="server" Text="数量:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesAddNumber" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="备注:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesAddContent" CssClass="span8" TextMode="MultiLine" />
                        <label class="span1">&nbsp;</label>
                        <div class="span2">
                            <asp:Button runat="server" ID="btnExpensesAddSubmit" CssClass="btn btn-primary" Text="提交" OnClick="btnExpensesAddSubmit_Click" />
                            <asp:Button runat="server" ID="btnExpensesAddCanel" CssClass="btn btn-primary" Text="后退" OnClick="btnExpensesAddCanel_Click" />
                        </div>
                    </div>
                </div>
                <div id="ExpensesQuery" style="margin-top: 15px;">
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="卡号:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryCardNumber" CssClass="span3" />
                        <asp:Label runat="server" Text="分类:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropExpensesQuerySpendType" CssClass="span2" />
                        <asp:Label runat="server" Text="方式:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropExpensesQuerySpendMode" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="消费者:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryConsumerName" CssClass="span2" />
                        <label class="span1">&nbsp;</label>
                        <asp:Label runat="server" Text="消费日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryBSpendDate" CssClass="span2" />
                        <asp:Label runat="server" Text="到:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtExpensesQueryESpendDate" CssClass="span2" />
                        <div class="span2">
                            <asp:Button runat="server" ID="btnExpensesQuerySubmit" Text="查询" CssClass="btn btn-primary" OnClick="btnExpensesQuerySubmit_Click" />
                            <asp:Button runat="server" ID="btnExpensesQueryCanel" Text="后退" CssClass="btn btn-primary" OnClick="btnExpensesQueryCanel_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="width: 100%; height: auto; margin-top: 15px;">
                <hr />
            </div>
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="ExpensesListDataGrid" Width="100%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" Font-Size="Small"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" SelectedItemStyle-BorderColor="Red" OnItemCommand="ExpensesListDataGrid_ItemCommand">
                            <Columns>
                                <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" Visible="false" />
                                <asp:HyperLinkColumn HeaderText="卡号" DataTextField="BankCardNumber" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openExpensesEditWin('{0}')" ItemStyle-Width="10%" />
                                <asp:BoundColumn ReadOnly="true" DataField="OwnerName" HeaderText="所有者" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Amount" HeaderText="金额" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="SpendType" HeaderText="分类" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="HowToUse" HeaderText="用途" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="SpendDate" HeaderText="消费日期" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="SpendMode" HeaderText="消费方式" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="ConsumerName" HeaderText="消费者" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Price" HeaderText="单价" ItemStyle-Width="6%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Number" HeaderText="数量" ItemStyle-Width="6%" />
                                <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="btnExpensesDelete" ImageUrl="~/Images/delete/1.jpg" CommandName="ExpensesImageDelete" />
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
