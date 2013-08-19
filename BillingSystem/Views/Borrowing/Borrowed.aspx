<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Borrowed.aspx.cs" Inherits="BillingSystem.Views.Borrowed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Css/css.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../../Css/jquery-ui-1.10.3.custom.min.css" />
    <script type="text/javascript" src="../../Scripts/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="../../Scripts/borrow-jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.10.3.custom.min.js"></script>
    <script>
        $(function () {
            $('#txtBorrowAddBorrower').change(loadBorrowAccount);

            $('#dropBorrowAddBorrowAccount').change(function () {
                var accountType = $('#dropBorrowAddBorrowAccount').val();
                var loanaccount = $("#dropBorrowAddBorrowAccount").find("option:selected").text();//¢
                $('#HidderField2').val(accountType + "," + loanaccount);
            });
        });

        function loadBorrowEditInfo(id) {
            
            $.ajax({
                //要用post方式       
                type: "POST",
                //方法所在页面和方法名  
                url: "/Views/Ajax.aspx/GetBorrowInfo",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{ 'Id':'" + id + "'}",
                success: function (data) {
                    //返回的数据用data.d获取内容       
                    var d = data.d;
                    //插入结果到li里面     
                    //$("#dropBorrowAddBorrowAccount").append("<option value='" + this["ValueField"] + "'>" + this["DisplayField"] + "</option>");
                    if (d.BorrowORLoanType == '1') {
                        $('#divBorrow').hide();
                        $('#divLoan').hide();
                    }
                    else {
                        $('#divBorrow').show();
                        $('#divLoan').show();
                    }
                    $('input[name="RadioBorrowAddBorrowType"]').val([d.BorrowORLoanType]);
                    $('#txtBorrowAddBorrower').val(d.Borrower);

                    buildBorrowAccountSelect(d.BorrowedAccountList);

                    //var temp = d['BorrowORLoanAccountId'];
                    //loadBorrowAccount(function () {$('#dropBorrowAddBorrowAccount').val(temp) });
                    // $('#dropBorrowAddBorrowAccount').val(this['BorrowORLoanAccountId']);
                    $('#txtBorrowAddLender').val(d.Lender);
                    $('#txtBorrowAddLoanAccount').val(d.LoanAccount);
                    $('#txtBorrowAddBorrowAmount').val(d.Amount);
                    $('#txtBorrowAddBorrowDate').val(d.HappenedDate);
                    $('#txtBorrowAddReturnDate').val(d.ReturnDate);
                    $('#dropBorrowAddStatus').val(d.Status);
                    $('#txtBorrowAddContent').val(d.Content);

                },
                error: function (err) {
                    alert(err);
                }
            });
        }

        function buildBorrowAccountSelect(list) {
            $('#dropBorrowAddBorrowAccount').empty();
            $(list).each(function () {
                //插入结果到li里面     
                $("#dropBorrowAddBorrowAccount").append("<option value='" + this["ValueField"] + "'>" + this["DisplayField"] + "</option>");
            });
        }

        function fillFormField(params) {
            alert(params);
            alert(params.borrowAccount);
        }

        function loadBorrowAccount(callback) {
            $('#dropBorrowAddBorrowAccount').empty();
            $.ajax({
                //要用post方式       
                type: "POST",
                //方法所在页面和方法名  
                url: "/Views/Ajax.aspx/getLoanAccountByPerson",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{ 'loanName':'" + $('#txtBorrowAddBorrower').val() + "'}",
                success: function (data) {
                    //返回的数据用data.d获取内容       
                    $("#dropBorrowAddBorrowAccount").append("<option value=''>请选择</option>");
                    $(data.d).each(function () {
                        //插入结果到li里面     
                        $("#dropBorrowAddBorrowAccount").append("<option value='" + this["ValueField"] + "'>" + this["DisplayField"] + "</option>");
                    });
                    if (typeof (callback) == 'function')
                        callback();
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    </script>
</head>

<body>
    <form id="form1" runat="server" style="width: 100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div>
                <div id="divBorrowTitle" class="title">
                    借入管理
                </div>
                <div id="divSet" style="height: 30px; margin-top: 5px; vertical-align: middle; margin-left: 5px;">
                    <div class="row">
                        <div class="span3">
                            <button type="button" title="新增" id="btnBorrowAdd" onclick="onbtnborrowaddclick();">
                                <img src="../Image/add3_16.png" />
                                新增
                            </button>
                            <button type="button" title="查询" id="btnBorrowQuery" onclick="DisplayQueryBorrowdiv();">
                                <img src="../Image/query1_16.png" />
                                查询
                            </button>
                        </div>
                    </div>
                </div>
                <hr style="border-color: #cccfd2; margin-top: 10px;" />
                <div id="BorrowEdit" class="margin-top">
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="借入方式：" CssClass="span1" />
                    </div>
                    <div class="controls controls-row">
                        <asp:RadioButtonList ID="RadioBorrowAddBorrowType" runat="server" RepeatDirection="Horizontal" CssClass="span2">
                            <asp:ListItem Value="1">现金</asp:ListItem>
                            <asp:ListItem Value="2">刷卡</asp:ListItem>
                        </asp:RadioButtonList>
                        <label class="span1">&nbsp;</label>

                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label1" runat="server" Text="借款人:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowAddBorrower" CssClass="span2" />
                        <div runat="server" id="divBorrow">
                            <asp:Label ID="Label2" runat="server" Text="借入账户:" CssClass="span1" />
                            <select id="dropBorrowAddBorrowAccount" name="dropBorrowAddBorrowAccount" class="span2"></select>
                        </div>

                        <asp:Label runat="server" Text="出借人:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowAddLender" CssClass="span2" />
                        <div runat="server" id="divLoan">
                            <asp:Label runat="server" Text="出借账户:" CssClass="span1" />
                            <asp:TextBox runat="server" ID="txtBorrowAddLoanAccount" CssClass="span2" />
                        </div>
                    </div>
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="借入金额:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowAddBorrowAmount" CssClass="span2" />
                        <asp:Label runat="server" Text="借款日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowAddBorrowDate" CssClass="span2" />
                        <asp:Label runat="server" Text="归还日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowAddReturnDate" CssClass="span2" />
                        <asp:Label runat="server" Text="状态：" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropBorrowAddStatus" CssClass="span2">
                            <asp:ListItem Value="1" Text="未还" />
                            <asp:ListItem Value="2" Text="已还" />
                        </asp:DropDownList>
                    </div>
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="备注:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowAddContent" CssClass="span8" TextMode="MultiLine" />
                        <div class="span3" style="text-align: right">
                            <asp:Button runat="server" ID="btnBorrowAddSubmit" OnClick="btnBorrowAddSubmit_Click" />
                            <button type="button" id="btnBorrowAddConfirm" title="提交" onclick="onborrowaddconfirmclick();">
                                <img src="../Image/submit1_16.png" />
                                提交
                            </button>
                            <button type="button" title="返回" id="btnBorrowAddCanel" onclick="DisplaySysdiv();">
                                <img src="../Image/submit1_16.png" />
                                返回
                            </button>
                        </div>
                    </div>
                </div>

                <div id="BorrowQuery" class="margin-top">
                    <div class="controls controls-row">
                        <asp:Label runat="server" Text="借款人:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowQueryBorrower" CssClass="span2" />
                        <asp:Label runat="server" Text="状态：" CssClass="span1" />
                        <asp:DropDownList runat="server" CssClass="span2" ID="dropBorrowQueryStatus">
                            <asp:ListItem Value="" Text="请选择..." />
                            <asp:ListItem Value="1" Text="未还" />
                            <asp:ListItem Value="2" Text="已还" />
                        </asp:DropDownList>
                        <asp:Label runat="server" Text="借款日期:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowQueryBBorrowDate" CssClass="span2" />
                        <asp:Label runat="server" Text="到:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtBorrowQueryEBorrowDate" CssClass="span2" />
                    </div>
                    <div class="controls controls-row">
                        <label class="span9">&nbsp;</label>
                        <div class="span3" style="text-align: right;">
                            <asp:Button runat="server" ID="btnBorrowQuerySubmit" OnClick="btnBorrowQuerySubmit_Click" />
                            <button type="button" title="查询" id="btnBorrowQueryConfirm" onclick="onborrowqueryconfirmclick();">
                                <img src="../Image/query2_16.png" />
                                查询
                            </button>
                            <button type="button" title="返回" id="btnBorrowQueryCanel" onclick="DisplaySysdiv();">
                                <img src="../Image/back2_16.ico" />
                                返回
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <hr id="fgdiv" style="border-color: #cccfd2; display: none;" />
            <div class="margin">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid runat="server" AutoGenerateColumns="false" ID="BorrowListDataGrid" Width="99%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" Font-Size="Small"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" SelectedItemStyle-BorderColor="Red"
                            OnItemCommand="BorrowListDataGrid_ItemCommand">
                            <Columns>
                                <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" ItemStyle-Width="5%" Visible="false" />
                                <asp:HyperLinkColumn HeaderText="借款人" DataTextField="Borrower" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openBorrowEditWin('{0}')" ItemStyle-Width="5%"></asp:HyperLinkColumn>
                                <asp:BoundColumn ReadOnly="true" DataField="BorrowORLoanType" HeaderText="借入方式" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="BorrowORLoanAccountId" HeaderText="账户Id" ItemStyle-Width="1%" Visible="false" />
                                <asp:BoundColumn ReadOnly="true" DataField="BorrowedAccount" HeaderText="借入账户" ItemStyle-Width="10%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Lender" HeaderText="出借方" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="LoanAccount" HeaderText="出借账户" ItemStyle-Width="10%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Amount" HeaderText="金额" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="HappenedDate" HeaderText="借款日期" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="ReturnDate" HeaderText="归还日期" ItemStyle-Width="7%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Status" HeaderText="状态" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Content" HeaderText="备注" ItemStyle-Width="10%" />
                                <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="btnBorrowDelete" ImageUrl="~/Images/delete/1.jpg" CommandName="BorrowImageDelete" OnClientClick="return confirm('确定删除？')" OnClick="btnBorrowDelete_Click" />
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
