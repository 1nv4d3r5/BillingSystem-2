<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardSetting.aspx.cs" Inherits="BillingSystem.Views.CardSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title></title>
    <!--<link rel="stylesheet" type="text/css" href="/Css/css.css"/>-->
    <link rel="stylesheet" type="text/css" href="/Css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="/Css/css.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/jquery-ui-1.10.3.custom.min.css" />
    <script src="../../Scripts/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" lang="ja">
        function openCardEditWin(Id) {
            location.replace(" CardSetting.aspx?CardSettingId=" + Id);
        }

        function DisplaySysdiv() {
            document.getElementById("divSet").style.display = '';
            document.getElementById("cardEdit").style.display = 'none';
            document.getElementById("cardQuery").style.display = 'none';
            document.getElementById("fgdiv").style.display = 'none';
            document.getElementById("divCardTitle").innerText = "卡信息管理";
        }

        function DisplayCardAdddiv() {
            document.getElementById("cardEdit").style.display = '';
            document.getElementById("cardQuery").style.display = 'none';
            document.getElementById("fgdiv").style.display = '';
            document.getElementById("divCardTitle").innerText = "卡信息管理--新增";
            $('#btnCardEditSave').hide();
        }

        function DisplayCardQuerydiv() {
            document.getElementById("cardEdit").style.display = 'none';
            document.getElementById("cardQuery").style.display = '';
            document.getElementById("fgdiv").style.display = '';
            document.getElementById("divCardTitle").innerText = "卡信息管理--查询";
            $('#btnCardQuerySelect').hide();
        }

        function DisplayCardEditdiv(cardNumber) {
            document.getElementById("cardEdit").style.display = '';
            document.getElementById("cardQuery").style.display = 'none';
            document.getElementById("fgdiv").style.display = '';
            document.getElementById("divCardTitle").innerText = "卡信息管理--编辑";
            $('#btnCardEditSave').hide();
        }

        //$(function () {
        //    $("#CardListDataGrid tr").first().nextAll().bind('click', function () {
        //        $(this).css('background-color', '#dff');
        //    });
        //});
        function InitializeEditDivForm() {
            $('input[type="text"]').val('');
            //$('input[type="password"]').val('');
            //$('#HiddenField1').val('');
            $("#txtContent").val('');
        }

        $(function () {
            $("#CardListDataGrid tr").first().nextAll().bind('click', function () {
                $("#CardListDataGrid tr.highlight").removeClass('highlight');
                $(this).toggleClass("highlight");
            });
        });

        $(document).ready(function () {
            $('#txtAddCardOpenDate').datepicker({ dateFormate: "yy-mm-dd" });
            $('#txtCardQueryBOpenDate').datepicker({ dateFormate: "yy-mm-dd" });
            $('#txtCardQueryEOpenDate').datepicker({ dateFormate: "yy-mm-dd" });
            $('#btnCardEditSave').hide();
            $('#btnCardQuerySelect').hide();
            $('#btnCardAddS').hide();
            $('#btnCardQueryS').hide();
        });

        $(function () {
            $("#btnCardAdd").button();
            $("#btnCardQuery").button();
            $("#btnCardEditConfirm").button();
            $("#btnCardEditCanel").button();

            $("#btnCardQueryConfirm").button();
            $("#btnCardQueryCanel").button();
        });

        function onclicksub(id) {
            if (id == 1) {
                document.getElementById("btnCardEditSave").click();
            }
            else {
                document.getElementById("btnCardQuerySelect").click();
            }
        }
        function oncardaddclick() {
            DisplayCardAdddiv();
            $('#btnCardAddS').click();
        }
        function oncardqueryclick() {
            DisplayCardQuerydiv();
            $('#btnCardQueryS').click();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; height: auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div>
                <div id="divCardTitle" class="title">
                    卡信息管理
                </div>
                <div id="divSet" style="height: 30px; margin-top: 5px; vertical-align: middle; margin-left: 5px;">
                    <div class="row">
                        <div class="span3">
                            <asp:Button runat="server" ID="btnCardAddS" OnClick="btnCardAddS_Click" />
                            <button type="button" title="新增" id="btnCardAdd" onclick="oncardaddclick();">
                                <img src="../Image/add3_16.png" />
                                新增
                            </button>
                            <asp:Button runat="server" ID="btnCardQueryS" OnClick="btnCardQueryS_Click" />
                            <button type="button" title="查询" id="btnCardQuery" onclick="oncardqueryclick();">
                                <img src="../Image/query1_16.png" />
                                查询
                            </button>
                        </div>
                    </div>
                </div>
                <hr style="border-color: #cccfd2; margin-top: 10px;" />

                <div id="cardEdit" class="margin-top">
                    <div class="controls controls-row">
                        <asp:Label ID="Label16" runat="server" Text="卡号:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtAddCardNumber" CssClass="span3" />
                        <label class="span2">&nbsp;</label>
                        <asp:Label ID="Label17" runat="server" Text="账户类型:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropCardAddAccountType" CssClass="span2" />
                        <asp:Label ID="Label18" runat="server" Text="所属银行:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropAddBank" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label4" runat="server" Text="卡所有者:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropAddCardOwner" CssClass="span2" />
                        <asp:Label ID="Label6" runat="server" Text="使用者:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropAddCardUser" CssClass="span2" />
                        <asp:Label ID="Label5" runat="server" Text="开户银行:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtAddBankName" CssClass="span2" />
                        <asp:Label ID="Label7" runat="server" Text="开户日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtAddCardOpenDate" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label8" runat="server" Text="备注:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtCardAddContent" TextMode="MultiLine" CssClass="span8" />
                        <div class="span3">
                            <asp:Button runat="server" Text="提交" ID="btnCardEditSave" OnClick="btnCardEditSave_Click" CssClass="btn btn-primary" />
                            <button type="button" title="提交" id="btnCardEditConfirm" onclick="onclicksub('1')">
                                <img src="../Image/query2_16.png" />
                                提交
                            </button>
                            <button type="button" title="返回" id="btnCardEditCanel" onclick="DisplaySysdiv();">
                                <img src="../Image/back2_16.ico" />
                                返回
                            </button>
                        </div>
                    </div>
                </div>
                <div id="cardQuery" class="margin-top">
                    <div class="controls controls-row">
                        <asp:Label ID="Label9" runat="server" Text="卡号:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtCardQueryCardNumber" CssClass="span2" />
                        <asp:Label ID="Label12" runat="server" Text="卡使用者:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropCardQueryUser" CssClass="span2" />
                        <asp:Label ID="Label10" runat="server" Text="账户类型:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropCardQueryAccountType" CssClass="span2" />
                        <asp:Label ID="Label11" runat="server" Text="所属银行:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropCardQueryBank" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label13" runat="server" Text="开户银行:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtCardQueryBankName" CssClass="span2" />
                        <asp:Label ID="Label14" runat="server" Text="开户日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtCardQueryBOpenDate" CssClass="span2" />
                        <asp:Label ID="Label15" runat="server" Text="到:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtCardQueryEOpenDate" CssClass="span2" />
                        <div class="span3">
                            <asp:Button runat="server" ID="btnCardQuerySelect" OnClick="btnCardQuerySelect_Click" />
                            <button type="button" id="btnCardQueryConfirm" onclick="onclicksub('2')">
                                <img src="../Image/submit1_16.png" />
                                查询
                            </button>
                            <button type="button" title="返回" id="btnCardQueryCanel" onclick="DisplaySysdiv();">
                                <img src="../Image/query2_16.png" />
                                返回
                            </button>
<%--                            <asp:Button runat="server" Text="后退" ID="btnCardQueryCanel" OnClick="btnCardQueryCanel_Click" CssClass="btn btn-primary" />--%>
                        </div>
                    </div>
                </div>
            </div>
            <hr id="fgdiv" style="border-color: #cccfd2; margin-top: 10px;" />
            <div class="margin-left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="CardListDataGrid" Width="98%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" Font-Size="Small"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" OnDeleteCommand="CardListDataGrid_DeleteCommand">
                            <AlternatingItemStyle BorderStyle="None" />
                            <Columns>
                                <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" Visible="false" />
                                <asp:HyperLinkColumn HeaderText="CardNumber" DataTextField="CardNumber" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openCardEditWin({0})" ItemStyle-Width="8%" Target="_blank" />
                                <asp:BoundColumn ReadOnly="true" DataField="AccountType" HeaderText="AccountType" ItemStyle-Width="3%" />
                                <asp:BoundColumn ReadOnly="true" DataField="BankId" HeaderText="BankName" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Amount" HeaderText="Amount" ItemStyle-Width="3%" />
                                <asp:BoundColumn ReadOnly="true" DataField="ExpenditureAmount" HeaderText="ExpenditureAmount" ItemStyle-Width="3%" />
                                <asp:BoundColumn ReadOnly="true" DataField="BorrowAmount" HeaderText="BorrowAmount" ItemStyle-Width="3%" />
                                <asp:BoundColumn ReadOnly="true" DataField="IncomeAmount" HeaderText="IncomeAmount" ItemStyle-Width="3%" />
                                <asp:BoundColumn ReadOnly="true" DataField="OwnerName" HeaderText="OwnerName" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="UserName" HeaderText="UserName" ItemStyle-Width="5%" />
                                <asp:ButtonColumn HeaderText="操作" Text="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" CommandName="Delete" />
                            </Columns>
                        </asp:DataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
