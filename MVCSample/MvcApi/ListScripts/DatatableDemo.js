$(document).ready(function () {
    //alert("welcome");

    $('#tblEmployeeList').dataTable({
        bJQueryUI: true,
        bServerSide: true,
        sAjaxSource: "/Employee/DatatableDemo1",
        bProcessing: true,
        bProcessing: false,
        bJQueryUI: true,
        bPaginate: true,
        bSort: false,
        ServerSide: true,
        info: true,
        "pagingType": "full_numbers",
        iDisplayLength: 10,
        bFilter: true,
        "aoColumns": [
                        {
                            "sName": "EmployeeId",
                            "bSearchable": false,
                            "bSortable": false,
                            "bVisible": false,
                            "mData": "EmployeeId",
                        },

                       { "sName": "FirstName" },
                       { "sName": "LastName" },
                       { "sName": "Gender" },
                       { "sName": "Country" },
                       { "sName": "State" },
                       { "sName": "MobileNo" },
                       { "sName": "EmailId" },
                       { "sName": "ZipCode" },
                       { "sName": "Address" },
                        {
                            "sName": "Actions",
                            "mRender": function (data, type, full) {
                                return "<a href=/Employee/EditEmps?empId=" + full[0] + "><img src='../../Images/Actions/actions16px/edit.png'" +
                               "style='border:0;' class='action' title='edit' " + "alt='edit' /></a> &nbsp&nbsp" +
                               "<a href='#'  onclick=Test( " + full[0] + " )><img class='action' src='../../Images/Actions/actions16px/del.png'" +
                               "style='border:0;' class='action' title='delete' ' + 'alt='delete' /></a>"

                            }
                        },

        ]
    });
    $(".action").on("click", function () {
        alert("work1");
        var target_row = $(this).closest("tr").get(0); // this line did the trick
        var aPos = oTable.fnGetPosition(target_row); 
        oTable.fnDeleteRow(aPos);
    });
   
    $('#tblEmployeeList tbody').on('click', function () {
        alert("work2");
        var target_row = $(this).closest("tr").get(0);
        //table
        //    .row($(this).parents('tr'))
        //    .remove()
        //    .draw();
    });

    function Test(el) {
        alert("ok");
    }
    function DeleteEmpById(empid) {
        alert("bgfgb");

    }
   

})


