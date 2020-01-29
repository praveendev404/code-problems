$(document).ready(function () {


    CheckQueryString();



    $("#EmpList").jqGrid({
        caption: "Employee Details",
        url: '/Employee/jqEmpsList1/',
        datatype: "json",
        contentType: "application/json; charset-utf-8",
        mtype: 'GET',
        colNames: ['EmployeeId', 'FirstName', 'LastName', 'Gender', 'Country', 'State', 'MobileNo', 'EmailId', 'ZipCode', 'Address', 'Actions'],
        colModel: [
              { name: 'EmployeeId', index: 'EmployeeId', editable: true, width: 100, hidden: true, key: true },
              { name: 'FirstName', index: 'FirstName', width: 100, editable: true },
              { name: 'LastName', index: 'LastName', width: 100, editable: true },
              { name: 'Gender', index: 'Gender', width: 100, editable: true },
              { name: 'Country', index: 'Country', width: 100, editable: true },
              { name: 'State', index: 'State', width: 100, editable: true },
              { name: 'MobileNo', index: 'MobileNo', width: 100, editable: true },
              { name: 'EmailId', index: 'EmailId', width: 100, editable: true },
              { name: 'ZipCode', index: 'ZipCode', width: 100, editable: true },
              { name: 'Address', index: 'Address', width: 100, editable: true },
              //{ name: 'Image', index: 'Image', width: 100, editable: true },
              { name: 'Action', index: 'Action', width: 100, editable: true }

        ],
        rowNum: 15,

        emptyrecords: "No records",
        loadonce: true,
        height: 360,
        width: 1060,
        add: true,
        reloadAfterSubmit: true,
        reloadAfterEdit: true,
        sortname: 'EmployeeId',
        viewrecords: true,
        rowList: [20, 30, 40, 50, 100],
        pager: '#pager',
        gridComplete: function () {
            // alert("hi");
            var gridId = $("#EmpList");
            var dataIds = jQuery(gridId).jqGrid('getDataIDs');
            for (var i = 0; i < dataIds.length; i++) {
                var itemId = dataIds[i];
                var editBtnId = "btnEdit" + itemId;
                var delBtnId = "btnDel" + itemId;
                btnEdit = "<a id=" + editBtnId + " title='Edit' " + "href=/Employee/EditEmps?empId=" + itemId + "><img src='../../Images/Actions/edit.png' width='15px' height='15px'/></a>"
                btnDel = "<a id=" + delBtnId + " title='Delete' ><img src='../../Images/Actions/del.png' width='20px' height='20px'/></a>"
                jQuery(gridId).jqGrid('setRowData', itemId, { Action: btnEdit + btnDel });
                $('#' + delBtnId).on("click", function () {
                    AttachGridDelete(this);
                })
            }
        }
    })
})
function AttachGridDelete(curRec) {
    var gridDelId = $(curRec).attr('id').replace("btnDel", "");
    var gridId = $("#EmpList");

    $.Zebra_Dialog("Are you sure want to delete this record ?", {
        'type': 'question', 'modal': 'false',
        'buttons':
            [
                {
                    caption: 'Yes',
                    callback: function () {
                        $.ajax({
                            datatype: "json",
                            url: "/Employee/DeleEmp?empId=" + gridDelId,
                            async: true,
                            cache: false,
                            success: function (result) {
                                StatusMsg("Delete", "Employee Details");
                                $(gridId).trigger('reloadGrid');

                            },
                            error: function (res) {
                                alert(res.responseText);
                            }
                        });
                    },
                },
                {
                    caption: 'No',
                    callback: function () {
                    },
                }
            ]
    })
}
function CheckQueryString() {
    var status = GetParameterValue('status');
    StatusMsg(status, "Employee Details");
}
function GetParameterValue(param) {
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlParam = url[i].split('=');
        if (urlParam[0] == param) {

            return urlParam[1];
        }
        else
            return "";
    }
}