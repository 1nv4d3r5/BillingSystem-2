//列表出借人超链接，编辑一条记录
function openBorrowEditWin(id) {
    DisplayEditBorrowdiv();
    EditBorrow(id);
}

//隐藏编辑、查询的div
function DisplaySysdiv() {
    document.getElementById("BorrowEdit").style.display = 'none';
    document.getElementById("BorrowQuery").style.display = 'none';
    document.getElementById("divSet").style.display = '';
    document.getElementById("fgdiv").style.display = 'none';
    document.getElementById("divBorrowTitle").innerText = "借入管理";
    $('#HiddenField1').val('');
    $('input[type="radio"]').removeAttr('checked');
}

//显示新增的div
function DisplayAddBorrowdiv() {
    $("#divBorrow").hide();
    $("#divLoan").hide();
    InitializeEditDivForm();
    $('input[name="RadioBorrowAddBorrowType"]').val(['1']);
    document.getElementById("BorrowEdit").style.display = '';
    document.getElementById("BorrowQuery").style.display = 'none';
    document.getElementById("fgdiv").style.display = '';
    document.getElementById("divBorrowTitle").innerText = "借入管理--新增";
}

//显示编辑的div
function DisplayEditBorrowdiv() {
    document.getElementById("BorrowEdit").style.display = '';
    document.getElementById("BorrowQuery").style.display = 'none';
    document.getElementById("fgdiv").style.display = '';
    document.getElementById("divBorrowTitle").innerText = "借入管理--编辑";
}

//显示查询的div
function DisplayQueryBorrowdiv() {
    document.getElementById("BorrowEdit").style.display = 'none';
    document.getElementById("BorrowQuery").style.display = '';
    document.getElementById("fgdiv").style.display = '';
    document.getElementById("divBorrowTitle").innerText = "借入管理--查询";
}

//清空编辑div
function InitializeEditDivForm() {
    $('input[type="text"]').val('');
    $('#HiddenField1').val('');
    $("#txtBorrowAddContent").val('');
}

//清空查询div
function InitializeQueryDivForm() {
    $('input[type="text"]').val('');
}

//点击借款人修改一条记录
function EditBorrow(id) {

    //清空编辑div
    InitializeEditDivForm();

    var selectedRow = $("tr.highlight").children("td");

    //给出借方式赋值
    var borrowType = selectedRow[1].innerText;
    $('input[name="RadioBorrowAddBorrowType"]').val([borrowType]);
    if (borrowType == "2") {
        $("#divLoan").show();
        $("#divBorrow").show();
        $("#txtBorrowAddLoanAccount").val(selectedRow[4].innerText);
        $("#txtBorrowAddBorrowAccount").val(selectedRow[2].innerText);
    }
    else {
        $("#divBorrow").hide();
        $("#divLoan").hide();
    }

    $("#HiddenField1").val(id);
    $("#txtBorrowAddLender").val(selectedRow[3].innerText);
    $("#txtBorrowAddBorrower").val(selectedRow[0].innerText);
    $("#txtBorrowAddBorrowAmount").val(selectedRow[5].innerText);
    $("#txtBorrowAddBorrowDate").val(selectedRow[6].innerText);
    $("#txtBorrowAddReturnDate").val(selectedRow[7].innerText);
    $("#txtBorrowAddContent").val(selectedRow[8].innerText);
}

//默认加载，隐藏DataGrid的Id这一列
$(document).ready(function () {
    //新增、编辑div的日期
    $('#txtBorrowAddBorrowDate').datepicker({ dateFormat: "yy-mm-dd" });
    $('#txtBorrowAddReturnDate').datepicker({ dateFormat: "yy-mm-dd" });

    //查询div的日期
    $('#txtBorrowQueryBBorrowDate').datepicker({ dateFormat: "yy-mm-dd" });
    $('#txtBorrowQueryEBorrowDate').datepicker({ dateFormat: "yy-mm-dd" });

    $('#btnBorrowAddSubmit').hide();
    $('#btnBorrowQuerySubmit').hide();
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

//出借方式选择，当选择现金，会隐藏和清空账户
$(function () {
    $("#RadioBorrowAddBorrowType").click(function () {
        var s = $("input[name='RadioBorrowAddBorrowType']:checked").val();
        if (s == 2) {
            $("#divLoan").show();
            $("#divBorrow").show();
        }
        else {
            $("#divLoan").hide();
            $("#divBorrow").hide();
            $("#txtBorrowAddLoanAccount").val("");
            $("#txtBorrowAddBorrowAccount").val("");
        }
    });
});

$(function () {
    $("#btnBorrowAdd").button();
    $("#btnBorrowQuery").button();
    $('#btnBorrowAddConfirm').button();
    $('#btnBorrowQueryConfirm').button();
    $('#btnBorrowAddCanel').button();
    $('#btnBorrowQueryCanel').button();
});

function onborrowqueryconfirmclick() {
    $('#btnBorrowQuerySubmit').click();
}

function onborrowaddconfirmclick() {
    $('#btnBorrowAddSubmit').click();
}