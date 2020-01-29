/// <reference path="../toastr.min.js" />


//jQuery.extend(
//    jQuery.jgrid.defaults,
//    {
//        emptyrecords: "No records found",
//        loadtext: 'Loading Data.Please Wait..',
//        scrollOffset: 0,
//        altRows: 'true',
//        altclass: 'myAltRowClass',
//        pgtext: "Page {0} Of {1}",
//        recordtext: "View {0} - {1} of {2}",
//        rowList: [10, 20, 30, 40, 50]
//    }
// );

function ShowLoader(message) {
	//window.setTimeout(function () {
	//$("body").addClass("transparent_class");
		$("#progressbar").show();
	//}, 10000);
	//$("#showprogress").progressbar({value:37});
		//window.setTimeout(function () {
		//$.showprogress(message);
		//}, 10000);
}

function HideLoader() {
	//$("body").removeClass("transparent_class");
	$("#progressbar").hide();
	//$.hideprogress();
}

function ReloadGrid(gridId) {
	$(gridId).trigger('reloadGrid', { page: 1 });
}

function ModifyGridDefaultStyles(gridId) {
	$('#' + gridId + ' tr').removeClass("ui-widget-content");
	$('#' + gridId + ' tr:nth-child(even)').addClass("evenTableRow");
	$('#' + gridId + ' tr:nth-child(odd)').addClass("oddTableRow");
}

toastr.options = {
	"closeButton": true,
	"debug": false,
	"positionClass": "toast-top-full-width",
	"onclick": null,
	"showDuration": "30000000",
	"hideDuration": "1000000",
	"timeOut": "50000",
	"extendedTimeOut": "100000",
	"showEasing": "swing",
	"hideEasing": "linear",
	"showMethod": "fadeIn",
	"hideMethod": "fadeOut"
}

window.addAntiForgeryToken = function (data) {
	data.__RequestVerificationToken = $('input[name="__RequestVerificationToken"]').val();
	return data;
};

function htmlEncode(value) {
	var encodedHtml= $('<div/>').text(value).html();
	//encodedHtml = encodedHtml.replace(/\//g, "%2F");
	//encodedHtml = encodedHtml.replace(/\?/g, "%3F");
	//encodedHtml = encodedHtml.replace(/=/g, "%3D");
	//encodedHtml = encodedHtml.replace(/&/g, "%26");
	encodedHtml = encodedHtml.replace(/&amp;/g, "");	
	return encodedHtml;
}