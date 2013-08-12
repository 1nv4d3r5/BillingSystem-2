<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="BillingSystem.Views.Loan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/css.css" />
    <link href="../../Css/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.10.3.custom.min.js"></script>
    <script type="text/javascript" src="../../Scripts/common.js"></script>
    <script type="text/javascript" src="../../Scripts/Loan-Jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btnLoanAdd').button();
            $('#btnLoanQuery').button();
            $('#btnLoanAddCanel').button();
            $('#btnLoanAddSubmit').button();

            $('#txtLoanAddLender').change(loadLoanAccount);
        });

        function loadLoanAccount() {
            //$.post('Loan.aspx/test', {}, function (msg) {
            //    alert(msg);
            //}, 'json');
            $.ajax({
                //要用post方式       
                type: "POST",
                //方法所在页面和方法名  
                url: "/Views/Ajax.aspx/getLoanAccountByPerson",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{ 'loanName':'" + $('#txtLoanAddLender').val() + "'}",
                success: function (data) {
                    //返回的数据用data.d获取内容       
                    // alert(data.d);

                    $(data.d).each(function () {
                        //插入结果到li里面     
                        $("#dropLoanAddLoanAccount").append("<option value='" + this + "'>" + this + "</option>");
                    });
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div>
                <div id="divLoanTitle" class="title">
                    借出管理
                </div>
                <div id="divSet" style="margin-top: 5px; vertical-align: middle;">
                    <div class="row">
                        <div class="span3" style="margin-left: 25px;">
                            <button type="button" id="btnLoanAdd" title="新增" onclick="DisplayAddLoandiv();">
                                <img src="../Image/add3_16.png" />
                                新增
                            </button>
                            <button type="button" id="btnLoanQuery" title="查询" onclick="DisplayQueryLoandiv();">
                                <img src="../Image/query1_16.png" />
                                查询
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <hr style="border-color: #cccfd2; margin-top: 10px;" />
            <div id="LoanEdit" class="margin-top">
                <div class="controls controls-row">
                    <label class="span2">出借方式：</label>
                </div>
                <div class="controls controls-row">
                    <asp:RadioButtonList ID="RadioLoanAddLoanType" runat="server" RepeatDirection="Horizontal" CssClass="span2">
                        <asp:ListItem Value="1">现金</asp:ListItem>
                        <asp:ListItem Value="2">刷卡</asp:ListItem>
                    </asp:RadioButtonList>
                    <label class="span1">&nbsp;</label>

                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HidderField2" runat="server" />
                </div>
                <div class="controls controls-row">
                    <asp:Label ID="Label1" runat="server" Text="出借人:" CssClass="span1" />
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <asp:TextBox runat="server" ID="txtLoanAddLender" CssClass="span2"/>
                    <div id="divLoan">
                        <asp:Label ID="Label2" runat="server" Text="出借账户:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropLoanAddLoanAccount" CssClass="span2" />
                    </div>
                    <%--     </ContentTemplate>
                    </asp:UpdatePanel>--%>
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
                    <div class="span3">
                        <asp:Button runat="server" ID="btnLoanAddSubmit" Text="提交" OnClick="btnLoanAddSubmit_Click" />
                        <%--<button type="button" id="btnLoanAddConfirm" title="提交" onclick="onclicksub();">
                            <img src="../Image/submit1_16.png" />
                            提交
                        </button>--%>
                        <button type="button" id="btnLoanAddCanel" title="返回" onclick="DisplaySysdiv();">
                            <img src="../Image/back2_16.ico" />
                            返回
                        </button>
                    </div>
                </div>
            </div>

            <div id="LoanQuery" class="margin-top">
                <div class="controls controls-row">
                    <asp:Label ID="Label9" runat="server" Text="出借人:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtLoanQueryLoaner" CssClass="span2" />
                    <asp:Label ID="Label10" runat="server" Text="借款日期:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtLoanQueryBLoanDate" CssClass="span2" />
                    <asp:Label ID="Label11" runat="server" Text="到:" CssClass="span1" />
                    <asp:TextBox runat="server" ID="txtLoanQueryELoanDate" CssClass="span2" />
                    <label class="span1">&nbsp;</label>
                    <div class="span3">
                        <asp:Button runat="server" ID="btnLoanQuerySubmit" Text="查询" CssClass="btn btn-primary" OnClick="btnLoanQuerySubmit_Click" />
                        <input type="button" id="btnLoanQueryCanel" value="返回" class="btn btn-primary" onclick="DisplaySysdiv()" />
                    </div>
                </div>
            </div>
        </div>
        <hr id="fgdiv" style="border-color: #cccfd2; display: none" />
        <div class="margin">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="LoanListDataGrid" Width="99%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" Font-Size="Small"
                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" SelectedItemStyle-BorderColor="Red"
                        OnItemCommand="LoanListDataGrid_ItemCommand">
                        <Columns>
                            <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" Visible="false" />
                            <asp:HyperLinkColumn HeaderText="出借人" DataTextField="Lender" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openLoanEditWin('{0}')" ItemStyle-Width="5%"></asp:HyperLinkColumn>
                            <asp:BoundColumn ReadOnly="true" DataField="BorrowORLoanType" HeaderText="出借方式" ItemStyle-Width="5%" />
                            <asp:BoundColumn ReadOnly="true" DataField="LoanAccount" HeaderText="出借账户" ItemStyle-Width="10%" />
                            <asp:BoundColumn ReadOnly="true" DataField="Borrower" HeaderText="借款人" ItemStyle-Width="5%" />
                            <asp:BoundColumn ReadOnly="true" DataField="BorrowedAccount" HeaderText="借款账户" ItemStyle-Width="10%" />
                            <asp:BoundColumn ReadOnly="true" DataField="Amount" HeaderText="金额" ItemStyle-Width="7%" />
                            <asp:BoundColumn ReadOnly="true" DataField="HappenedDate" HeaderText="借款日期" ItemStyle-Width="7%" />
                            <asp:BoundColumn ReadOnly="true" DataField="ReturnDate" HeaderText="归还日期" ItemStyle-Width="7%" />
                            <asp:BoundColumn ReadOnly="true" DataField="Content" HeaderText="备注" ItemStyle-Width="15%" />
                            <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="3%">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="btnLoanDelete" ImageUrl="~/Images/delete/1.jpg" CommandName="LoanImageDelete" OnClientClick="return confirm('确定删除？')" OnClick="btnLoanDelete_Click" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
