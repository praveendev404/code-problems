$(document).ready(function () {
    var dvStatusMsg = $("#dvStatusMsg");
    dvStatusMsg.hide();



})
function StatusMsg(status, statusParam) {
    if (status != "") {
        var dvStatusMsg = $("#dvStatusMsg");
        dvStatusMsg.show();
        var msg;
        // alert("Master");
        switch (status) {
            case "Add":
                msg = statusParam + " added successfully";
                dvStatusMsg.append('<span style="color:green;text-align:center">' + msg + '</span>');
                break;
            case "Update":
                msg = statusParam + " updated successfully";
                dvStatusMsg.append('<span style="color:green;text-align:center">' + msg + '</span>');
                break;
            case "Delete":
                msg = statusParam + " deleted successfully";
                dvStatusMsg.append('<span style="color:green;text-align:center">' + msg + '</span>');
                break;
            case "Error":
                msg = "Error occured";
                dvStatusMsg.append('<span style="color:red;text-align:center">' + msg + '</span>');
                break;
            case "InvalidUser":
                msg = statusParam + "Invalid user credentials";
                dvStatusMsg.append('<span style="color:red;text-align:center">' + msg + '</span>');
                break;

        }

        dvStatusMsg.delay(5000).fadeOut("slow");
    }
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