<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="BillingSystem.Views.Loan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/css.css" />
    <link href="../../Css/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="../../Scripts/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.10.3.custom.min.js"></script>
    <script lang="ja" type="text/javascript">
        function openLoanEditWin(id) {
            DisplayEditLoandiv();
            EditLoan(id);
        }

        //隐藏编辑、查询的div
        function DisplaySysdiv() {
            document.getElementById("LoanEdit").style.display = 'none';
            document.getElementById("LoanQuery").style.display = 'none';
            document.getElementById("divSet").style.display = '';
            document.getElementById("divLoanTitle").innerText = "借出管理";
            $("#HiddenField1").val("");
        }

        //显示新增的div
        function DisplayAddLoandiv() {
            $("#divLoan").hide();
            $("#divBorrow").hide();
            InitializeEditDivForm();
            document.getElementById("LoanEdit").style.display = '';
            document.getElementById("LoanQuery").style.display = 'none';
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("divLoanTitle").innerText = "借出管理--新增";

        }

        //显示编辑的div
        function DisplayEditLoandiv() {
            document.getElementById("LoanEdit").style.display = '';
            document.getElementById("LoanQuery").style.display = 'none';
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("divLoanTitle").innerText = "借出管理--编辑";
        }

        //显示查询的div
        function DisplayQueryLoandiv() {
            document.getElementById("LoanEdit").style.display = 'none';
            document.getElementById("LoanQuery").style.display = '';
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("divLoanTitle").innerText = "借出管理--查询";
            //InitializeQueryDivForm();
        }

        //编辑div的值
        function InitializeEditDivForm() {
            $('input[type="text"]').val('');
            $('#HiddenField1').val('');

            $("txtLoanAddContent").val('');

            $('input:radio').eq(0).attr('checked', 'true');
            $('input:radio').eq(2).attr('checked', 'true');
        }

        function InitializeQueryDivForm() {
            var t = document.getElementsByTagName("input");
            for (var i = 0; i < t.length; i++) {
                if (t[i].type == 'text') {
                    t[i].value = "";
                }
            }
        }

        //点击借款人修改一条记录
        function EditLoan(id) {

            //清空编辑div
            InitializeEditDivForm();

            
            //给出借方式赋值
            if ($("tr.highlight").children("td")[1].innerText == "2") {
                $('input:radio').eq(1).attr('checked', 'true');
                $("#divLoan").show();
                $("#txtLoanAddLoanAccount").val($("tr.highlight").children("td")[2].innerText);
            }
            else {
                $('input:radio').eq(0).attr('checked', 'true');
                $("#divLoan").hide();

            }

            //给借款方式赋值
            if ($("tr.highlight").children("td")[4].innerText == "2") {
                $('input:radio').eq(3).attr('checked', 'true');
                $("#txtLoanAddLoanAccount").val($("tr.highlight").children("td")[2].innerText);
                $("#divBorrow").show();
            }
            else {
                $('input:radio').eq(2).attr('checked', 'true');
                $("#divBorrow").hide();
            }

            $("#HiddenField1").val(id);
            $("#txtLoanAddLender").val($("tr.highlight").children("td")[0].innerText);
            $("#txtLoanAddBorrower").val($("tr.highlight").children("td")[3].innerText);
            $("#txtLoanAddLoanAmount").val($("tr.highlight").children("td")[6].innerText);
            $("#txtLoanAddLoanDate").val($("tr.highlight").children("td")[7].innerText);
            $("#txtLoanAddReturnDate").val($("tr.highlight").children("td")[8].innerText);
            $("#txtLoanAddContent").val($("tr.highlight").children("td")[9].innerText);
        }

        //默认加载，隐藏DataGrid的Id这一列
        $(document).ready(function () {
            //DisplaySysdiv();
            // HideORShowColumn();
            $('#txtLoanAddLoanDate').datepicker({ dateFormat: "yy-mm-dd" });
        });

        function HideORShowColumn() {
            $("td:eq(0)", $("#LoanListDataGrid tr")).hide();
        }

        //DataGrid行选择的click事件，添加行样式
        $(function () {
            $("#LoanListDataGrid tr").first().nextAll().bind('click', function () {
                //行单击事件时，取消所有行样式
                $("#LoanListDataGrid tr.highlight").removeClass('highlight');
                //设置当前行样式
                $(this).toggleClass("highlight");
            });
        });

        //出借方式选择，当选择现金，会隐藏和清空账户
        $(function () {
            $("#RadioLoanAddLoanType").click(function () {
                var s = $("input[name='RadioLoanAddLoanType']:checked").val();
                if (s == 2) {
                    $("#divLoan").show();
                }
                else {
                    $("#divLoan").hide();
                    $("#txtLoanAddLoanAccount").val("");
                }
            });
        });

        //借款方式选择，当选择现金，会隐藏和清空账户
        $(function () {
            $("#RadioLoanAddBorrowType").click(function () {
                var s = $("input[name='RadioLoanAddBorrowType']:checked").val();
                if (s == 2) {
                    $("#divBorrow").show();
                }
                else {
                    $("#divBorrow").hide();
                    $("#txtLoanAddLoanAccount").val("");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="margin-left">
            <div>
                <div id="divLoanTitle" class="title">
                    借出管理
                </div>
                <br />
                <div id="divSet">
                    <div class="controls controls-row">
                        <div class="span3">
                            <input type="button" value="新增" id="btnLoanAdd" class="btn btn-primary"  onclick="DisplayAddLoandiv()" />
                            <input  type="button" value="高级查询" id="btnLoanQuery" class="btn btn-primary" onclick="DisplayQueryLoandiv()" />
                        </div>
                    </div>
                </div>
                <div id="LoanEdit">
                    <div class="controls controls-row">
                        出借方式：
                    </div>
                    <div class="controls controls-row">
                        <asp:RadioButtonList ID="RadioLoanAddLoanType" runat="server" RepeatDirection="Horizontal" CssClass="span2">
                            <asp:ListItem Value="1">现金</asp:ListItem>
                            <asp:ListItem Value="2">刷卡</asp:ListItem>
                        </asp:RadioButtonList>
                        <label class="span1">&nbsp;</label>
                        <asp:Label ID="Label1" runat="server" Text="出借人:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanAddLender" CssClass="span2" />
                        <div runat="server" id="divLoan">
                            <asp:Label ID="Label2" runat="server" Text="出借账户:" CssClass="span1" />
                            <asp:TextBox runat="server" ID="txtLoanAddLoanAccount" CssClass="span2" />
                        </div>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div class="controls controls-row">
                        借款方式：
                    </div>
                    <div class="controls controls-row">
                        <asp:RadioButtonList runat="server" ID="RadioLoanAddBorrowType" RepeatDirection="Horizontal" CssClass="span2">
                            <asp:ListItem Value="1">现金</asp:ListItem>
                            <asp:ListItem Value="2">转账</asp:ListItem>
                        </asp:RadioButtonList>
                        <label class="span1">&nbsp;</label>
                        <asp:Label ID="Label3" runat="server" Text="借款人:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanAddBorrower" CssClass="span2" />
                        <div runat="server" id="divBorrow">
                            <asp:Label ID="Label4" runat="server" Text="借款账户:" CssClass="span1" />
                            <asp:TextBox runat="server" ID="txtLoanAddBorrowAccount" CssClass="span2" />
                        </div>
                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label5" runat="server" Text="借出金额:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanAddLoanAmount" CssClass="span2" />
                        <asp:Label ID="Label6" runat="server" Text="借款日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanAddLoanDate" CssClass="span2" />
                        <asp:Label ID="Label7" runat="server" Text="归还日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanAddReturnDate" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label8" runat="server" Text="备注:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanAddContent" CssClass="span8" TextMode="MultiLine" />
                    </div>
                    <div class="controls controls-row">
                        <label class="span7">&nbsp;</label>
                        <div class="span2" style="text-align: right">
                            <asp:Button runat="server" ID="btnLoanAddSubmit" CssClass="btn btn-primary" Text="提交" OnClick="btnLoanAddSubmit_Click" />
                            <input type="button" id ="btnLoanAddCanel" class="btn btn-primary" value="返回" onclick="DisplaySysdiv()" />
                        </div>
                    </div>
                </div>

                <div id="LoanQuery">
                    <div class="controls controls-row">
                        <asp:Label ID="Label9" runat="server" Text="出借人:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanQueryLoaner" CssClass="span2" />
                        <asp:Label ID="Label10" runat="server" Text="借款日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanQueryBLoanDate" CssClass="span2" />
                        <asp:Label ID="Label11" runat="server" Text="到:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtLoanQueryELoanDate" CssClass="span2" />
                        <label class="span1">&nbsp;</label>
                        <div class="span2">
                            <asp:Button runat="server" ID="btnLoanQuerySubmit" Text="查询" CssClass="btn btn-primary" OnClick="btnLoanQuerySubmit_Click" />
                            <input type="button" id ="btnLoanQueryCanel" value="返回" class="btn btn-primary" onclick="DisplaySysdiv()" />
<%--                            <asp:Button runat="server" ID="btnLoanQueryCanel" Text="后退" CssClass="btn btn-primary" />--%>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="LoanListDataGrid" Width="100%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" Font-Size="Small"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" SelectedItemStyle-BorderColor="Red"
                            OnItemCommand="LoanListDataGrid_ItemCommand">
                            <Columns>
                                <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" Visible="false"/>
                                <asp:HyperLinkColumn HeaderText="出借人" DataTextField="Lender" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openLoanEditWin('{0}')" ItemStyle-Width="5%"></asp:HyperLinkColumn>
                                <asp:BoundColumn ReadOnly="true" DataField="LoanType" HeaderText="出借方式" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="LoanAccount" HeaderText="出借账户" ItemStyle-Width="10%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Borrower" HeaderText="借款人" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="BorrowType" HeaderText="借款方式" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="BorrowAccount" HeaderText="借款账户" ItemStyle-Width="10%" />
                                <asp:BoundColumn ReadOnly="true" DataField="LoanAmount" HeaderText="金额" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="LoanDate" HeaderText="借款日期" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="ReturnDate" HeaderText="归还日期" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Content" HeaderText="备注" ItemStyle-Width="15%" />
                                <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="btnLoanDelete" ImageUrl="~/Images/delete/1.jpg" CommandName="LoanImageDelete" />
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
