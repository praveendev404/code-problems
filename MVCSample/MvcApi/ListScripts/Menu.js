$(document).ready(function () {
    BindMenu();
})
function BindMenu() {
    $.ajax({
        type: "POST",
        url: "/Employee/BindMenu",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (data) {
            var lstMenu = data;
            var ul = "<ul></ul>"
            $.each(data.d, function (ID, Name) {

            });
        },
        error: function (result) {
            //alert("error");
        }
    })
}