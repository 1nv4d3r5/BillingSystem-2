//列表出借人超链接，编辑一条记录
function openLoanEditWin(id) {
    DisplayEditLoandiv();
    EditLoan(id);
}

//隐藏编辑、查询的div
function DisplaySysdiv() {
    document.getElementById("LoanEdit").style.display = 'none';
    document.getElementById("LoanQuery").style.display = 'none';
    document.getElementById("divSet").style.display = '';
    document.getElementById("fgdiv").style.display = 'none';
    document.getElementById("divLoanTitle").innerText = "借出管理";
    $('#HiddenField1').val('');
    $('input[type="radio"]').removeAttr('checked');
}

//显示新增的div
function DisplayAddLoandiv() {
    $("#divLoan").hide();
    $("#divBorrow").hide();
    InitializeEditDivForm();
    $('input[name="RadioLoanAddLoanType"]').val(['1']);
    document.getElementById("LoanEdit").style.display = '';
    document.getElementById("LoanQuery").style.display = 'none';
    document.getElementById("fgdiv").style.display = '';
    document.getElementById("divLoanTitle").innerText = "借出管理--新增";
}

//显示编辑的div
function DisplayEditLoandiv() {
    document.getElementById("LoanEdit").style.display = '';
    document.getElementById("LoanQuery").style.display = 'none';
    document.getElementById("fgdiv").style.display = '';
    document.getElementById("divLoanTitle").innerText = "借出管理--编辑";
}

//显示查询的div
function DisplayQueryLoandiv() {
    document.getElementById("LoanEdit").style.display = 'none';
    document.getElementById("LoanQuery").style.display = '';
    document.getElementById("fgdiv").style.display = '';
    document.getElementById("divLoanTitle").innerText = "借出管理--查询";
    InitializeQueryDivForm();
}

//清空编辑div
function InitializeEditDivForm() {
    $('input[type="text"]').val('');
    $('#dropLoanAddLoanAccount').val('');
    $('#HiddenField1').val('');
    $("#txtLoanAddContent").val('');
}

//清空查询div
function InitializeQueryDivForm() {
    $('input[type="text"]').val('');
}

//点击借款人修改一条记录
function EditLoan(id) {
    $("#HiddenField1").val(id);

    //清空编辑div
    InitializeEditDivForm();
    $("#HiddenField1").val(id);

    var selectedRow = $("tr.highlight").children("td");
    //给出借方式赋值
    var loanType = findLoanIndex(selectedRow[1].innerText);
    $('input[name="RadioLoanAddLoanType"]').val([loanType]);

    if (loanType == "2") {
        $("#divLoan").show();
        $("#divBorrow").show();

        //$("#dropLoanAddLoanAccount").prepend("<option value='0'>"+s+"</option>");
        //$("#dropLoanAddLoanAccount").val(selectedRow[2].innerText);
        //$("#txtLoanAddBorrowAccount").val(selectedRow[4].innerText);
    }
    else {
        $("#divBorrow").hide();
        $("#divLoan").hide();
    }

    
    $("#txtLoanAddLender").val(selectedRow[0].innerText);
    if (loanType == 2) {
        loadLoanAccount(function () { $('#dropLoanAddLoanAccount').val('13')});
    }
    $("#txtLoanAddBorrower").val(selectedRow[3].innerText);
    $("#txtLoanAddLoanAmount").val(selectedRow[5].innerText);
    $("#txtLoanAddLoanDate").val(selectedRow[6].innerText);
    $("#txtLoanAddReturnDate").val(selectedRow[7].innerText);
    //$('#dropLoanAddStatus').val();
    $("#txtLoanAddContent").val(selectedRow[9].innerText);
}

//默认加载，隐藏DataGrid的Id这一列
$(document).ready(function () {
    //新增、编辑div的日期
    $('#txtLoanAddLoanDate').datepicker({ dateFormat: "yy-mm-dd" });
    $('#txtLoanAddReturnDate').datepicker({ dateFormat: "yy-mm-dd" });

    //查询div的日期
    $('#txtLoanQueryBLoanDate').datepicker({ dateFormat: "yy-mm-dd" });
    $('#txtLoanQueryELoanDate').datepicker({ dateFormat: "yy-mm-dd" });
    $('#btnLoanAddSubmit').hide();
    $('#btnLoanQuerySubmit').hide();
});

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
            $("#divBorrow").show();
        }
        else {
            $("#divLoan").hide();
            $("#divBorrow").hide();
            $("#dropLoanAddLoanAccount").val("");
            $("#txtLoanAddBorrowAccount").val("");
        }
    });
});

function displayAddborder(str,id) {
    if (id == 1) {
        document.getElementById(str).style.border = '';
    }
    else {
        document.getElementById(str).style.border = 'none';
    }
}

function onLoanAddConfirmclick() {
    //document.getElementById("btnLoanAddSubmit").click();
   // document.getElementById('<%btnLoanAddSubmit%>').click() = btnLoanAddSubmit_Click;
    $("#btnLoanAddSubmit").click();
}

function onLoanQueryConfirmclick() {
    $('#btnLoanQuerySubmit').click();
}


