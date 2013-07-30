<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Borrowed.aspx.cs" Inherits="BillingSystem.Views.Borrowed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Css/css.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/bootstrap.css" />
    <script type="text/javascript" src="../../Scripts/jquery-2.0.3.min.js"></script>

    <script lang="ja" type="text/javascript">
        function openBorrowEditWin(id) {
            //location.replace(" Borrowed.aspx?BorrowedId=" + id);         
            DisplayEditBorrowdiv();
            EditBorrow();
        }

        //隐藏编辑、查询的div
        function DisplaySysdiv() {
            document.getElementById("BorrowEdit").style.display = 'none';
            document.getElementById("BorrowQuery").style.display = 'none';
            document.getElementById("divSet").style.display = '';
            document.getElementById("divBorrowTitle").innerText = "借入管理";
            ClearForm();
        }

        //显示新增的div
        function DisplayAddBorrowdiv() {
            document.getElementById("BorrowEdit").style.display = '';
            document.getElementById("BorrowQuery").style.display = 'none';
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("divBorrowTitle").innerText = "借入管理--新增";
            $("#divBorrow").hide();
            $("#divLoan").hide();
            ClearForm();
        }

        //显示编辑的div
        function DisplayEditBorrowdiv() {
            document.getElementById("BorrowEdit").style.display = '';
            document.getElementById("BorrowQuery").style.display = 'none';
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("divBorrowTitle").innerText = "借入管理--编辑";
        }

        //显示查询的div
        function DisplayQueryBorrowdiv() {
            document.getElementById("BorrowEdit").style.display = 'none';
            document.getElementById("BorrowQuery").style.display = '';
            document.getElementById("divSet").style.display = 'none';
            document.getElementById("divBorrowTitle").innerText = "借入管理--查询";
        }

        //编辑div的值
        function ClearForm() {
            var t = document.getElementsByTagName("input");
            for (var i = 0; i < t.length; i++) {
                if (t[i].type == 'text') {
                    t[i].value = "";
                }
            }
            //var hd = document.getElementById("HiddenField1");
            //$("HiddenField1").val("");

            var ta = document.getElementById("txtBorrowAddContent");
            ta.textContent = "";

            $('input:radio').eq(0).attr('checked', 'true');
            $('input:radio').eq(2).attr('checked', 'true');
        }

        //点击借款人修改一条记录
        function EditBorrow() {
            //清空编辑div
            ClearForm();

            $("#HiddenField1").val($("tr.highlight").children("td")[0].innerText);
            //给借入方式赋值
            if ($("tr.highlight").children("td")[2].innerText == "2") {
                $('input:radio').eq(1).attr('checked', 'true');
                $("#divBorrow").show();
                $("#txtBorrowAddBorrowAccount").val($("tr.highlight").children("td")[3].innerText);
            }
            else {
                $('input:radio').eq(0).attr('checked', 'true');
                $("#divBorrow").hide();

            }
            $("#txtBorrowAddBorrower").val($("tr.highlight").children("td")[1].innerText);

            //给出借方式赋值
            if ($("tr.highlight").children("td")[5].innerText == "2") {
                $('input:radio').eq(3).attr('checked', 'true');
                $("#txtBorrowAddLoanAccount").val($("tr.highlight").children("td")[6].innerText);
                $("#divLoan").show();
            }
            else {
                $('input:radio').eq(2).attr('checked', 'true');
                $("#divLoan").hide();
            }

            $("#txtBorrowAddLender").val($("tr.highlight").children("td")[4].innerText);
            $("#txtBorrowAddBorrowAmount").val($("tr.highlight").children("td")[7].innerText);
            $("#txtBorrowAddBorrowDate").val($("tr.highlight").children("td")[8].innerText);
            // if ($("tr.highlight").children("td")[9].innerText > "2000-01-01") {
            $("#txtBorrowAddReturnDate").val($("tr.highlight").children("td")[9].innerText);
            // }

            $("#txtBorrowAddContent").val($("tr.highlight").children("td")[10].innerText);
        }

        //默认加载，隐藏DataGrid的Id这一列
        $(document).ready(function () {
            $("td:eq(0)", $("#BorrowListDataGrid tr")).hide();
        });

        //DataGrid行选择的click事件，添加行样式
        $(function () {
            $("#BorrowListDataGrid tr").first().nextAll().bind('click', function () {
                //行单击事件时，取消所有行样式
                $("#BorrowListDataGrid tr.highlight").removeClass('highlight');
                //设置当前行样式
                $(this).toggleClass("highlight");
            });
        });

        //借款方式选择，当选择现金，会隐藏和清空账户
        $(function () {
            $("#RadioBorrowAddBorrowType").click(function () {
                var s = $("input[name='RadioBorrowAddBorrowType']:checked").val();
                if (s == 2) {
                    $("#divBorrow").show();
                }
                else {
                    $("#divBorrow").hide();
                    $("#txtBorrowAddBorrowAccount").val("");
                }
            });
        });

        //出借方式选择，当选择现金，会隐藏和清空账户
        $(function () {
            $("#RadioBorrowAddLoanType").click(function () {
                var s = $("input[name='RadioBorrowAddLoanType']:checked").val();
                if (s == 2) {
                    $("#divLoan").show();
                }
                else {
                    $("#divLoan").hide();
                    $("#txtBorrowAddLoanAccount").val("");
                }
            });
        });

        $(function () {
            $("# BorrowListDataGrid tr").hover(function () {
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="margin-left">
            <div>
                <div id="divBorrowTitle" class="title">
                    借入管理
                </div>
                <br />
                <div id="divSet">
                    <div class="controls controls-row">
                        <div class="span3">
                            <input type="button" value="新增" id="btnBorrowAdd" class="btn btn-primary" onclick="DisplayAddBorrowdiv()" />
                            <asp:Button runat="server" Text="高级查询" ID="btnBorrowQuery" CssClass="btn btn-primary" OnClick="btnBorrowQuery_Click" />
                        </div>
                    </div>
                </div>
                <div id="BorrowEdit">
                    <div class="controls controls-row">
                        借入方式：
                    </div>
                    <div class="controls controls-row">
<%--                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>--%>
                                <asp:RadioButtonList ID="RadioBorrowAddBorrowType" runat="server" RepeatDirection="Horizontal" CssClass="span2" ><%--OnSelectedIndexChanged="RadioBorrowAddBorrowType_SelectedIndexChanged"--%>
                                    <asp:ListItem Value="1">现金</asp:ListItem>
                                    <asp:ListItem Value="2">刷卡</asp:ListItem>
                                </asp:RadioButtonList>
                                <label class="span1">&nbsp;</label>
                                <asp:Label runat="server" Text="借款人:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtBorrowAddBorrower" CssClass="span2" />
                                <div runat="server" id="divBorrow">
                                    <asp:Label runat="server" Text="借入账户:" CssClass="span1" />
                                    <asp:TextBox runat="server" ID="txtBorrowAddBorrowAccount" CssClass="span2" />
                                </div>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
<%--                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                    <div class="controls controls-row">
                        出借方式：
                    </div>
<%--                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>--%>
                            <div class="controls controls-row">
                                <asp:RadioButtonList runat="server" ID="RadioBorrowAddLoanType" RepeatDirection="Horizontal" CssClass="span2" > <%--OnSelectedIndexChanged="RadioBorrowAddLoanType_SelectedIndexChanged"--%>
                                    <asp:ListItem Value="1">现金</asp:ListItem>
                                    <asp:ListItem Value="2">转账</asp:ListItem>
                                </asp:RadioButtonList>
                                <label class="span1">&nbsp;</label>
                                <asp:Label runat="server" Text="出借人:" CssClass="span1" />
                                <asp:TextBox runat="server" ID="txtBorrowAddLender" CssClass="span2" />
                                <div runat="server" id="divLoan">
                                    <asp:Label runat="server" Text="借出账户:" CssClass="span1" />
                                    <asp:TextBox runat="server" ID="txtBorrowAddLoanAccount" CssClass="span2" />
                                </div>
<%--                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div class="controls controls-row">
                    <asp:Label runat="server" Text="借入金额:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtBorrowAddBorrowAmount" CssClass="span2" />
                    <asp:Label runat="server" Text="借款日期:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtBorrowAddBorrowDate" CssClass="span2" />
                    <asp:Label runat="server" Text="归还日期:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtBorrowAddReturnDate" CssClass="span2" />
                </div>
                <div class="controls controls-row">
                    <asp:Label runat="server" Text="备注:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtBorrowAddContent" CssClass="span8" TextMode="MultiLine" />
                </div>
                <div class="controls controls-row">
                    <label class="span7">&nbsp;</label>
                    <div class="span2" style="text-align: right">
                        <asp:Button runat="server" ID="btnBorrowAddSubmit" CssClass="btn btn-primary" Text="提交" OnClick="btnBorrowAddSubmit_Click" />
                        <asp:Button runat="server" ID="btnBorrowAddCanel" CssClass="btn btn-primary" Text="后退" OnClick="btnBorrowAddCanel_Click" />
                    </div>
                </div>
            </div>

            <div id="BorrowQuery">
                <div class="controls controls-row">
                    <asp:Label runat="server" Text="借款人:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtBorrowQueryBorrower" CssClass="span2" />
                    <asp:Label runat="server" Text="借款日期:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtBorrowQueryBBorrowDate" CssClass="span2" />
                    <asp:Label runat="server" Text="到:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtBorrowQueryEBorrowDate" CssClass="span2" />
                    <label class="span1">&nbsp;</label>
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
                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" SelectedItemStyle-BorderColor="Red"
                        OnItemCommand="BorrowListDataGrid_ItemCommand">
                        <Columns>
                            <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" />
                            <asp:HyperLinkColumn HeaderText="借款人" DataTextField="Borrower" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openBorrowEditWin('{0}')" ItemStyle-Width="5%"></asp:HyperLinkColumn>
                            <asp:BoundColumn ReadOnly="true" DataField="BorrowType" HeaderText="借入方式" ItemStyle-Width="5%" />
                            <asp:BoundColumn ReadOnly="true" DataField="BorrowedAccount" HeaderText="借入账户" ItemStyle-Width="10%" />
                            <asp:BoundColumn ReadOnly="true" DataField="Lender" HeaderText="出借方" ItemStyle-Width="5%" />
                            <asp:BoundColumn ReadOnly="true" DataField="LoanType" HeaderText="出借方式" ItemStyle-Width="5%" />
                            <asp:BoundColumn ReadOnly="true" DataField="LoanAccount" HeaderText="出借账户" ItemStyle-Width="10%" />
                            <asp:BoundColumn ReadOnly="true" DataField="BorrowAmount" HeaderText="金额" ItemStyle-Width="7%" />
                            <asp:BoundColumn ReadOnly="true" DataField="BorrowDate" HeaderText="借款日期" ItemStyle-Width="7%" />
                            <asp:BoundColumn ReadOnly="true" DataField="ReturnDate" HeaderText="归还日期" ItemStyle-Width="7%" />
                            <asp:BoundColumn ReadOnly="true" DataField="Content" HeaderText="备注" ItemStyle-Width="15%" />
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
