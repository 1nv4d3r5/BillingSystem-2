<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSetting.aspx.cs" Inherits="BillingSystem.Views.UserSetting" %>

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
    <script type="text/javascript" lang="ja">
        function openUserEditWin(id) {
            displayUserEditdiv();
            EditUser(id);
        }
        function displayUserAdddiv() {
            UserEdit.style.display = "";
            UserQuery.style.display = 'none';
            Label3.style.display = '';
            txtPassword.style.display = '';
            document.getElementById("fgdiv").style.display = '';
            btnUserEditSave.style.display = 'none';
            this.divUserTitle.innerText = "用户信息维护--新增";
            InitializeEditDivForm();
            $("#dropRole").val('1');
        }

        function displayUserEditdiv() {
            UserEdit.style.display = '';
            UserQuery.style.display = 'none';
            document.getElementById("fgdiv").style.display = '';
            this.divUserTitle.innerText = "用户信息维护--编辑";
            Label3.style.display = 'none';
            btnUserEditSave.style.display = 'none';
            txtPassword.style.display = 'none';
        }

        function displayUserQuery() {
            UserEdit.style.display = 'none';
            UserQuery.style.display = '';
            document.getElementById("fgdiv").style.display = '';
            btnUserQuerySave.style.display = 'none';
            this.divUserTitle.innerText = "用户信息维护--查询";
            $('input[type="text"]').val('');
        }

        function displayUserSet() {
            divUserSet.style.display = '';
            UserEdit.style.display = 'none';
            UserQuery.style.display = 'none';
            document.getElementById("fgdiv").style.display = 'none';
            Label3.style.display = '';
            txtPassword.style.display = '';
            this.divUserTitle.innerText = "用户信息维护";
        }
        $(function () {
            $("#UserListDataGrid tr").first().nextAll().bind('click', function () {
                $("#UserListDataGrid tr.highlight").removeClass('highlight');
                $(this).toggleClass("highlight");
            });
        });

        $(function () {
            $('#btnUserQuery').button();
            $('#btnUserAdd').button();
            $('#btnUserEditCanel').button();
            $('#btnUserQueryCancel').button();
            $('#btnUserEditConfirm').button();
            $('#btnUserQueryConfirm').button();
        });

        function InitializeEditDivForm() {
            $('input[type="text"]').val('');
            $('input[type="password"]').val('');
            $('#HiddenField1').val('');
            $("#txtContent").val('');
        }

        function EditUser(id) {
            //清空编辑div
            InitializeEditDivForm();
            var selectedRow = $("tr.highlight").children("td");

            $("#HiddenField1").val(id);
            $("#txtUserName").val(selectedRow[1].innerText);
            $("#txtIdCode").val(selectedRow[0].innerText);
            $("#txtEmail").val(selectedRow[2].innerText);
            $("#txtContent").val(selectedRow[4].innerText);

            if (selectedRow[3].innerText == "使用者") {
                $("#dropRole").val('2');
            }
            else {
                $("#dropRole").val('1');
            }
        }

        function onclicksub(id) {
            if (id == 1) {
                document.getElementById("btnUserEditSave").click();
            }
            else {
                document.getElementById("btnUserQuerySave").click();
            }
            //$("#btnUserEditSave").click();
        }

        function hidebutton() {
            $('#btnUserEditSave').hide();
        }

        $(document).ready(function () {
            $('#btnUserEditSave').hide();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; background-color: transparent">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div>
                <div id="divUserTitle" class="title">
                    用户信息维护
                </div>
                <div id="divUserSet" style="height: 30px; margin-top: 5px; vertical-align: middle; margin-left: 5px;">
                    <div class="row">
                        <div class="span3">
                            <button type="button" title="新增" id="btnUserAdd" onclick="displayUserAdddiv();">
                                <img src="../Image/add3_16.png" />
                                新增
                            </button>
                            <button type="button" title="查询" id="btnUserQuery" onclick="displayUserQuery();">
                                <img src="../Image/query1_16.png" />
                                查询
                            </button>
                        </div>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                </div>
                <hr style="border-color: #cccfd2; margin-top: 10px;" />
                <div id="UserEdit" class="margin-top">
                    <div class="controls controls-row">
                        <asp:Label ID="Label1" runat="server" Text="用户名:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtUserName" CssClass="span2" />
<%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ErrorMessage="请输入用户名！" CssClass="span1">*</asp:RequiredFieldValidator>--%>
                        <asp:Label ID="Label2" runat="server" Text="IdCode:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtIdCode" CssClass="span2" />
<%--                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtIdCode" runat="server" ErrorMessage="请输入6~18个字符组成的code" ValidationExpression="^[a-zA-Z]+\w{5,17}$" CssClass="span1">*</asp:RegularExpressionValidator>--%>
                        <asp:Label ID="Label3" runat="server" Text="密码:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="span2" />

                    </div>

                    <div class="controls controls-row">
                        <asp:Label ID="Label5" runat="server" Text="角色:" CssClass="span1" />
                        <asp:DropDownList runat="server" ID="dropRole" CssClass="span2">
                            <asp:ListItem Value="1">管理员</asp:ListItem>
                            <asp:ListItem Value="2">使用者</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="Label4" runat="server" Text="邮箱:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="span2" />

                    </div>
                    <div class="controls controls-row">
                        <asp:Label ID="Label6" runat="server" Text="备注:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" CssClass="span5" />
                        <label class="span1">&nbsp;</label>
                        <div class="span3">
                            <asp:Button runat="server" ID="btnUserEditSave" OnClick="btnUserEditSave_Click" />
                            <button type="button" id="btnUserEditConfirm" title="提交" onclick="onclicksub('1');">
                                <img src="../Image/submit1_16.png" />
                                提交
                            </button>
                            <button type="button" id="btnUserEditCanel" title="返回" onclick="displayUserSet();">
                                <img src="../Image/back2_16.ico" />
                                返回
                            </button>
                        </div>
                    </div>
                </div>
                <div id="UserQuery" class="margin-top">
                    <div class="controls controls-row">
                        <asp:Label ID="Label7" runat="server" Text="用户名称:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtUserQueryUserName" CssClass="span2" />
                        <asp:Label ID="Label8" runat="server" Text="IdCode:" CssClass="span1" />
                        <asp:TextBox runat="server" ID="txtUserQueryIdCode" CssClass="span2" />
                        <label class="span1">&nbsp;</label>
                        <div class="span3">
                            <asp:Button runat="server" ID="btnUserQuerySave" OnClick="btnUserQuerySave_Click" />
                            <button type="button" id="btnUserQueryConfirm" title="查询" onclick="onclicksub('2')">
                                <img src="../Image/query2_16.png" />
                                查询
                            </button>
                            <button type="button" id="btnUserQueryCancel" title="返回" onclick="displayUserSet();">
                                <img src="../Image/back2_16.ico" />
                                返回
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <hr id="fgdiv" style="border-color: #cccfd2; margin-top: 10px;" />
            <div class="margin-left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid runat="server" AutoGenerateColumns="False" ID="UserListDataGrid" Width="98%" BorderColor="Black" BorderStyle="None" BorderWidth="5px" CellPadding="2" CellSpacing="2" GridLines="Both" Font-Size="Small"
                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Size="Small" OnItemCommand="UserListDataGrid_ItemCommand">
                            <AlternatingItemStyle BorderStyle="None" />
                            <Columns>
                                <asp:BoundColumn ReadOnly="true" DataField="Id" HeaderText="Id" Visible="false" ItemStyle-Width="5%" />
                                <asp:HyperLinkColumn HeaderText="Code" DataTextField="Code" DataNavigateUrlField="Id" DataNavigateUrlFormatString="javascript:openUserEditWin('{0}')" ItemStyle-Width="3%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Name" HeaderText="Name" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="EMail" HeaderText="EMail" ItemStyle-Width="8%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Role" HeaderText="Role" ItemStyle-Width="5%" />
                                <asp:BoundColumn ReadOnly="true" DataField="Content" HeaderText="Content" ItemStyle-Width="10%" />
                                <asp:TemplateColumn HeaderText="操作" HeaderStyle-HorizontalAlign="Center" FooterStyle-BorderStyle="None" ItemStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="btnCardDelete" ImageUrl="~/Images/delete/1.jpg" CommandName="ImageDelete" OnClientClick="return confirm('确定删除？')" OnClick="btnCardDelete_Click" />
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
