/// <reference path="AppBase/ajaxSetup.js" />
/// <reference path="AppBase/Common.js" />


var AjaxHttpSender = new AjaxHttpSender();
function loadData(data, callback) {
    debugger
    //data.draw = 1
    //data.start = 1
    //data.length=1
    //data.search = "";

    //data.order = 1;
    //AjaxHttpSender.sendPost("/Home/Test",
    // {

    // })
    // .done(function (data, textStatus, jqXHR) {
    //     callback(data);

    // });

    AjaxHttpSender.sendPost("/Home/EmployeeList",
        {
            draw: data.draw,
            start: data.start,
            length: data.length,
            search: data.search,
            columns: data.columns,

        })
        .done(function (data, textStatus, jqXHR) {
            callback(data);

        });

}


function EditEmployee(employeeId)
{debugger
    window.location.href = "/Home/EditEmployee/" + employeeId;
    //AjaxHttpSender.sendGet(url)
    //    .done(function (data, textStatus, jqXHR) {
    //        debugger
    //    })
}
function DeleteEmployee(employeeId)
{
    debugger
    var url = "/Home/DeleteEmployee/" + employeeId;
    AjaxHttpSender.sendGet(url)
        .done(function (data, textStatus, jqXHR) {
            alert("Deleted successfully..");
        })
}

$("#tblEmployee").dataTable(
             {
                 "processing": true,
                 "serverSide": true,
                 "searching": true,
                 bFilter: false,
                 bInfo: false,
                 "bPaginate": true,
                 //"stateSave": true,
                 "order": [[0, "asc"]],
                 "ajax": function (data, callback, settings) {
                     loadData(data, callback);
                     debugger
                 },
                 "columns": [

                     { "data": "FirstName", "sortable": true },
                     { "data": "LastName", "sortable": true },
                     { "data": "ZipCode", "sortable": true },
                     { "data": "MobileNo", "sortable": true },
                     { "data": "EmailId", "sortable": true, "width": 300 },

                       {
                           "sortable": false,
                           "width": 180,
                           "data": "EmployeeId",
                           "defaultContent": '',
                           "render": function (data, type, row) {
                               debugger
                               return '<a onclick="EditEmployee(' + row.EmployeeId + ' );">Edit</a>&nbsp;<a onclick="DeleteEmployee(' + row.EmployeeId + ' );">Delete</a>';
                           }
                       }
                 ]
             }
             );