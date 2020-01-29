$(document).ready(function () {

    $("#btnLogin").click(function () {
        $(document).tooltip({
            track: true
        });
        $("#txtUserName").tooltip({
            content: "Working",
            track: true,
        });
        var userName = $("#txtUserName").val();
        if (userName == "") {
            alert("tool");
            return false;
        }
    })
    CheckQueryString();
    $(".tblLogin").show();
    $(".lnkLogin").hide()
    $("#btnClose").click(function () {
        $(".dvLogin").hide();
        $(".lnkLogin").show();
    })
    $(".lnkLogin").click(function () {
        $(".dvLogin").show();
        $(".lnkLogin").hide();
    })
})
//function Validate() {
//    var userName = $("#txtUserName").val();
//    if (userName == "") {
//        alert("click");
//        return false;
//    }

//}
function CheckQueryString() {
    var status = GetParameterValue('status');
    StatusMsg(status, "");
}