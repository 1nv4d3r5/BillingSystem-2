<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Income.aspx.cs" Inherits="BillingSystem.Views.Income" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/css.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/jquery-ui-1.10.3.custom.min.css" />
    <script src="../../Scripts/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script lang="ja" type="text/javascript">
        function openIncomEditWin(id) {
            location.replace(" InCome.aspx?IncomeId=" + id);
        }

        function DisplaySysdiv() {
            document.getElementById("IncomeEdit").style.display = 'none';
            document.getElementById("IncomeQuery").style.display = 'none';
            document.getElementById("divSet").style.display = '';
            document.getElementById("fgdiv").style.display = 'none';
            document.getElementById("divIncomeTitle").innerText = "收入管理";
        }

        function DisplayAddIncomediv() {
            document.getElementById("IncomeEdit").style.display = '';
            document.getElementById("IncomeQuery").style.display = 'none';
            document.getElementById("fgdiv").style.display = '';
            document.getElementById("divIncomeTitle").innerText = "收入管理--新增";
        }

        function DisplayEditIncomediv() {
            document.getElementById("IncomeEdit").style.display = '';
            document.getElementById("IncomeQuery").style.display = 'none';
            document.getElementById("fgdiv").style.display = '';
            document.getElementById("divIncomeTitle").innerText = "收入管理--编辑";
        }

        function DisplayQueryIncomediv() {
            document.getElementById("IncomeEdit").style.display = 'none';
            document.getElementById("IncomeQuery").style.display = '';
            document.getElementById("fgdiv").style.display = '';
            document.getElementById("divIncomeTitle").innerText = "收入管理--查询";
        }

        $(function () {
            $("#IncomeListDataGrid tr").first().nextAll().bind('click', function () {
                $("#IncomeListDataGrid tr.highlight").removeClass('highlight');
                $(this).toggleClass("highlight");
            });
        });

        $(document).ready(function () {
            $('#txtIncomeAddDepositDate').datepicker({ dateFormat: "yy-mm-dd" });
            $('#txtIncomeAddBDate').datepicker({ dateFormat: "yy-mm-dd" });
            $('#txtIncomeAddEDate').datepicker({ dateFormat: "yy-mm-dd" });

            $('#txtIncomeQueryBDepositDate').datepicker({ dateFormat: "yy-mm-dd" });
            $('#txtIncomeQueryEDepositDate').datepicker({ dateFormat: "yy-mm-dd" });
            $('#btnIncomeAdd').hide();
            $('#btnIncomeQuery').hide();
            $('#btnIncomeEditSave').hide();
            $('#btnIncomeQuerySelect').hide();
        });

        $(function () {
            $('#btnIncomeAddC').button();
            $('#btnIncomeQueryC').button();
            $('#btnIncomeQueryConfirm').button();
            $('#btnIncomeQueryCanel').button();
            $('#btnIncomeEditConfirm').button();
            $('#btnIncomeEditCanel').button();
        });

        function onincomeEditCclick() {
            DisplayAddIncomediv();
            $('#btnIncomeAdd').click();
        }
        function onincomequeryCclick() {
            DisplayQueryIncomediv();
            $('#btnIncomeQuery').click();
        }

        function onIncomeeditconfirmclick() {
            $('#btnIncomeEditSave').click();
        }
        function onincomequeryconfirmclick() {
            $('#btnIncomeQuerySelect').click();
        }
    </script>
</head>
<body>
    <form id="income" runat="server" style="width: 100%; height: 100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div>
<%--                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>--%>
                        <div id="divIncomeTitle" class="title">
                            收入管理
                        </div>
                        <div id="divSet" style="height: 30px; margin-top: 5px; vertical-align: middle; margin-left: 5px;">
                            <div class="row">
                                <div class="span3">
                                    <asp:Button runat="server" ID="btnIncomeAdd" OnClick="btnIncomeAdd_Click" />
                                    <button type="button" title="新增" id="btnIncomeAddC" onclick="onincomeEditCclick();">
                                        <img src="../Image/add3_16.png" />
                                        新增
                                    </button>
                                    <asp:Button runat="server" ID="btnIncomeQuery" OnClick="btnIncomeQuery_Click" />
                                    <button type="button" id="btnIncomeQueryC" title="查询" onclick="onincomequeryCclick();">
                                        <img src="../Image/query1_16.png" />
                                        查询
                                    </button>
                                </div>
                            </div>
                        </div>
                        <hr style="border-color: #cccfd2; margin-top: 10px;" />
                        <div id="IncomeEdit" class="margin-top">
                            <div class="controls controls-row">
                                <asp:Label ID="Label2" runat="server" Text="卡号:" CssClass="span1" />
                                <asp:DropDownList runat="server" ID="dropIncomeAddCardNumber" CssClass="span3" />
                                <asp:Label ID="Label4" runat="server" Text="金额:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeAddAmount" CssClass="span2" />
                                <label class="span1">&nbsp;</label>
                                <asp:Label ID="Label21" runat="server" Text="所有者:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeAddOwner" CssClass="span2" />
                            </div>
                            <div class="controls controls-row">
                                <asp:Label ID="Label5" runat="server" Text="存入日期:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeAddDepositDate" CssClass="span2" />
                                <label class="span1">&nbsp;</label>
                                <asp:Label ID="Label20" runat="server" Text="存款方式:" CssClass="span1" />
                                <asp:DropDownList runat="server" ID="dropIncomeAddDepositMode" CssClass="span2" />
                                <label class="span1">&nbsp;</label>
                                <asp:Label ID="Label7" runat="server" Text="存款人:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeAddDepositorName" CssClass="span2" />
                            </div>
                            <div class="controls controls-row">
                                <asp:Label ID="Label1" runat="server" Text="收入类型:" CssClass="span1" />
                                <asp:DropDownList runat="server" ID="dropIncomeAddInComeType" CssClass="span2" />
                                <label class="span1">&nbsp;</label>
                                <asp:Label ID="Label3" runat="server" Text="存款状态:" CssClass="span1" />
                                <div class="span3">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList runat="server" ID="dropIncomeAddPreMode" AutoPostBack="true" OnSelectedIndexChanged="dropIncomeAddPreMode_SelectedIndexChanged" CssClass="input-small" />
                                            <asp:DropDownList runat="server" ID="dropIncomeAddMode" CssClass="input-small" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:Label ID="Label6" runat="server" Text="利率:" CssClass="span1" />
                                <div class="span3">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList runat="server" ID="dropIncomeAddPreRate" CssClass="input-small" AutoPostBack="true" OnSelectedIndexChanged="dropIncomeAddPreRate_SelectedIndexChanged" />
                                            <asp:DropDownList runat="server" ID="dropIncomeAddRate" CssClass="input-small" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="controls controls-row">
                                <asp:Label ID="Label17" runat="server" Text="状态:" CssClass="span1" />
                                <asp:DropDownList runat="server" ID="dropIncomeAddStatus" CssClass="span2" />
                                <label class="span1">&nbsp;</label>
                                <asp:Label ID="Label16" runat="server" Text="起息日:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeAddBDate" CssClass="span2" />
                                <label class="span1">&nbsp;</label>
                                <asp:Label ID="Label18" runat="server" Text="到期日:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeAddEDate" CssClass="span2" />
                            </div>
                            <div class="controls controls-row">
                                <asp:Label ID="Label8" runat="server" Text="备注:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeAddContent" TextMode="MultiLine" CssClass="span6" />
                                <asp:CheckBox runat="server" ID="checkIncomeAddAutoSave" Text="是否自动转存" CssClass="span2" />
                                <div class="span3">
                                    <asp:Button runat="server" ID="btnIncomeEditSave" OnClick="btnIncomeEditSave_Click" />
                                    <button type="button" title="提交" id="btnIncomeEditConfirm" onclick="onIncomeeditconfirmclick();">
                                        <img src="../Image/submit1_16.png" />
                                        提交
                                    </button>
                                    <button type="button" id="btnIncomeEditCanel" onclick="DisplaySysdiv();">
                                        <img src="../Image/back2_16.ico" />
                                        返回
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div id="IncomeQuery" class="margin-top">
                            <div class="controls controls-row">
                                <asp:Label ID="Label9" runat="server" Text="卡号:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeQueryCardNumber" CssClass="span3" />
                                <asp:Label ID="Label13" runat="server" Text="收入类型:" CssClass="span1" />

                                <asp:DropDownList runat="server" ID="dropIncomeQueryIncomeType" CssClass="span2" />
                                <asp:Label ID="Label12" runat="server" Text="所有者:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeQueryOwnerName" CssClass="span3" />
                            </div>
                            <div class="controls controls-row">
                                <asp:Label ID="Label10" runat="server" Text="存款状态:" CssClass="span1" />
                                <div class="span3">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList runat="server" ID="dropIncomeQueryPreMode" CssClass="drop-small" AutoPostBack="true" OnSelectedIndexChanged="dropIncomeQueryPreMode_SelectedIndexChanged" />
                                            <asp:DropDownList runat="server" ID="dropIncomeQueryMode" CssClass="drop-middle" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:Label ID="Label11" runat="server" Text="存款人:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeQueryDepositorName" CssClass="span2" />
                                <asp:Label ID="Label19" runat="server" Text="存款方式:" CssClass="span1" />
                                <asp:DropDownList runat="server" ID="dropIncomeQueryDepositMode" CssClass="span2" />
                            </div>
                            <div class="controls controls-row">
                                <asp:Label ID="Label14" runat="server" Text="存款日期:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeQueryBDepositDate" CssClass="span2" />
                                <label class="span1">&nbsp;</label>
                                <asp:Label ID="Label15" runat="server" Text="到:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtIncomeQueryEDepositDate" CssClass="span2" />
                                <div class="span3">
                                    <asp:Button runat="server" ID="btnIncomeQuerySelect" OnClick="btnIncomeQuerySelect_Click" />
                                    <button type="button" title="查询" id="btnIncomeQueryConfirm" onclick="onincomequeryconfirmclick();">
                                        <img src="../Image/query2_16.png" />
                                        查询
                                    </button>
                                    <button type="button" title="返回" id="btnIncomeQueryCanel" onclick="DisplaySysdiv();">
                                        <img src="../Image/back2_16.ico" />
                                        返回
                                    </button>
                                </div>
                            </div>
                        </div>
<%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
            <hr id="fgdiv" style="border-color: #cccfd2; margin-top: 10px;" />
            <div class="margin-left">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="IncomeListDataGrid" Width="99%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" HeaderStyle-HorizontalAlign="Center"
                            HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" Font-Size="Small" OnDeleteCommand="IncomeListDataGrid_DeleteCommand"
                            OnItemCommand="IncomeListDataGrid_ItemCommand">
                            <SelectedItemStyle ForeColor="White" BackColor="Red" />
                            <AlternatingItemStyle BorderStyle="None" />
                            <Columns>
                                <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="3%" Visible="false" />
                                <asp:BoundColumn ReadOnly="true" DataField="Status" HeaderText="状态" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Left" />
                                <asp:HyperLinkColumn HeaderText="卡号" DataTextField="BankCardNumber" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openIncomEditWin({0})" ItemStyle-Width="16%" Target="_blank" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundColumn ReadOnly="true" DataField="OwnerName" HeaderText="所有者" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundColumn ReadOnly="true" DataField="IncomeType" HeaderText="收入类型" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundColumn ReadOnly="true" DataField="IncomeAmount" HeaderText="金额" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundColumn ReadOnly="true" DataField="Mode" HeaderText="存款状态" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundColumn ReadOnly="true" DataField="Rate" HeaderText="利率" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundColumn ReadOnly="true" DataField="DepositDate" HeaderText="存入日期" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundColumn ReadOnly="true" DataField="BDate" HeaderText="开始日期" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundColumn ReadOnly="true" DataField="EDate" HeaderText="到期日期" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundColumn ReadOnly="true" DataField="TAmount" HeaderText="到期总额" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundColumn ReadOnly="true" DataField="AutoSave" HeaderText="自动转存" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundColumn ReadOnly="true" DataField="DepositMode" HeaderText="存款方式" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundColumn ReadOnly="true" DataField="DepositorName" HeaderText="存款人" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Left" />
                                <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="btnIncomeDelete" ImageUrl="~/Images/delete/1.jpg" CommandName="IncomeImageDelete" OnClientClick="return confirm('确定删除？')" OnClick="btnIncomeDelete_Click" />
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
