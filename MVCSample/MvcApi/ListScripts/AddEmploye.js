$(document).ready(function () {

    $(".ddlCountry").change(function () {
        //alert("Working");
        var id = $(this).val();
        var ddlCountry = $("#ddlCountry");
        var ddlState = $("#ddlState");
        GetState(id);

    })

    $("#ProfilePic").on("change", function () {
        var files = !!this.files ? this.files : [];
        if (/^image/.test(files[0].type)) {
            var reader = new FileReader();
            reader.readAsDataURL(files[0]);
            reader.onloadend = function () {
                $("#imgProfilePic").attr('src', this.result);
            }
        }
    })
})
function GetState(id) {
    $.ajax({
        url: "/Employee/GetState",
        data: { "id": id },
        async: false,
        cache: false,
        success: function (data) {
            if (data != null) {
                var ddlState = $("#ddlState");
                $("#ddlState").empty();
                ddlState.append("<option value='--Select--'> --Select--</option>");
                $.each(data, function (index, optionData) {
                    //alert(optionData.StateId + "" + optionData.Name);
                    ddlState.append("<option value='" + optionData.StateId + "'>" + optionData.Name + "</option>");
                })
            }
        },
        error: function (data) {
            alert("error");
        }
    })
}
function LoadImage() {
    var fileUpload = $("imgProfilePic").val();
    $("#imgProfilePic").attr("src", "../../Images/p.jpg");



}