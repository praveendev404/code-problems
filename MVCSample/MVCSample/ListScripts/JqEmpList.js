$(document).ready(function () {
    $("#EmpList").jqGrid({
        caption: "Employee Details",
        url: '/Employee/jqEmpList1/',
        datatype: "json",
        contentType: "application/json; charset-utf-8",
        mtype: 'GET',
        colNames: ['EmployeeId', 'Name', 'MobileNo', 'Email', 'Address'],
        colModel: [
              { name: 'EmployeeId', index: 'EmployeeId', editable: true, width: 260, hidden: true, key: true },
              { name: 'Name', index: 'Name', width: 260, editable: true },
              { name: 'MobileNo', index: 'MobileNo', width: 260, editable: true },
              { name: 'Email', index: 'Email', width: 260, editable: true },
              { name: 'Address', index: 'Address', width: 260, editable: true }
        ],
        rowNum: 20,

        emptyrecords: "No records",
        loadonce: true,
        height: 360,
        add: true,
        reloadAfterSubmit: true,
        reloadAfterEdit: true,
        sortname: 'EmployeeId',
        viewrecords: true,
        rowList: [20, 30, 40, 50, 100],
        pager: '#pager'
    }).navGrid('#pager', { edit: true, add: true,  del: true, search: false },
    {
   
        url: "/Employee/EditEmp",
        closeOnEscape: true,
        closeAfterEdit: true,
        recreateform: true,
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
               // $("#EmpList").setGridParam({ datatype: 'json', page: 1 }).trigger('reloadGrid');
            }
        }
    },
    {
        url: "/Employee/Create",
        closeOnEscape: true,
        closeAfterAdd: true,
        recreateform: true,
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
                //$("#EmpList").setGridParam({ datatype: 'json', page: 1 }).trigger('reloadGrid');
            }
        }
    },
    {
         url: "/Employee/DeleteEmp",
        closeOnEscape: true,
        closeAfterDelete: true,
        recreateform: true,
        msg:"Are you sure you want to delete this record",
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    }    
    );
    //alert("hi");
 //   $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid');
    $("#EmpList").setGridParam({ datatype: 'json', page: 1 }).trigger('reloadGrid');
}); //$("#EmpList").setGridParam({ datatype: 'json', page: 1 }).trigger('reloadGrid');