$(document).ready(function () {
    SchoolsList("#schoolList");

    $('#txtName').keyup(function () {
        ReloadGrid('#schoolList');
    });

    $('#txtCity').keyup(function () {
        ReloadGrid('#schoolList');
    });
});

function SchoolsList(gridId) {

    //Jq Grid Start
    $(gridId).jqGrid({
        url: '/Schools/GetSchoolsList',
        datatype: 'json',
        mtype: 'GET',
        colNames: ['id', 'Name', 'City', 'Actions'],
        colModel: [
                      { name: 'SchoolId', key: true, width: 0, index: 'SchoolId', hidden: true },
                      { name: 'Name', index: 'Name', width:525, align: 'left', sortable: true },
                      { name: 'City', index: 'City', width: 500, align: 'left', sortable: true },
                       { name: 'Action', index: 'Action', width: 150, align: 'center', sortable: false },
                  ],
        width: '100%',
        rowNum: 10,        
        height: 360,
        rowList: [10, 20, 30, 40, 50, 100],
        sortname: 'Name',
        sortorder: "asc",
        viewrecords: true,
        caption: 'School List',
        beforeRequest: function () {
            responsive_jqgrid($(".jqGridSchools"));
        },
        pager: 'schoolPager',
        gridComplete: function () {
            ModifyGridDefaultStyles("schoolList");
            var dataIds = jQuery(gridId).jqGrid('getDataIDs');

            for (var i = 0; i < dataIds.length; i++) {
                var itemId = dataIds[i];
                var editBtnId = "btnEdit" + itemId;
                var delBtnId = "btnDelete" + itemId;

                btnEdit = "<a id=" + editBtnId + "  title='Edit School' style='padding-left: 3px;padding-right:3px' " + "href=/Schools/EditSchool?schoolId=" + itemId + "  > <img src='../Content/NewImages/edit.png' alt='Edit School' /></a>";
                btnDel = "<input id=" + delBtnId + " style='padding-left: 3px;padding-right:5px' title='Delete School' type='Image' src='/Content/NewImages/delete.png' value='Delete' title='Delete School' />";


                jQuery(gridId).jqGrid('setRowData', itemId, { Action: btnEdit + btnDel });

                $('#' + delBtnId).on("click", function () { attachGridDelete(this); });
            } //for
        },
        success: function () {

        },
        postData: {
            filter: function () { return $("#txtName").val(); },
            city: function () { return $("#txtCity").val(); }
        }
    });

    //for making use of zebra dialog instead of jquery modal dialog
    function attachGridDelete(curRec) {
        var gridDelId;
        gridDelId = $(curRec).attr('Id').replace("btnDelete", "");
        $.Zebra_Dialog("Delete the School (" + $(gridId).getRowData(gridDelId).Name + ")?", { 'type': 'question', 'modal': 'false',
            'buttons':
              [
                {
                    caption: 'Yes',
                    callback: function () {
                        $.ajax({
                            url: "/Schools/DeleteSchool?schoolId=" + gridDelId,
                            async: true,
                            cache: false,
                            success: function (result) {
                                $(gridId).trigger('reloadGrid');

                            },
                            error: function (xhr) {
                                alert(xhr.responseText);
                            }
                        });
                        //HideLoading();
                    }
                },
                {
                    caption: 'No',
                    callback: function () { }
                }
              ]
        });
    }
}