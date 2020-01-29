/// <reference path="Common.js" />
//http://globalgateway.wordpress.com/2010/01/05/reusable-centralized-ajax-component-based-on-jquery/

var AjaxHttpSender = function () { };


//Gets the token from @Html.AntiForgeryToken()


//Token from a different form I pasted here
//headers["__RequestVerificationToken"] = "2hwuX7Untp9r5lNqQF1RG8iWgwmLr4wVobB6foTdXvQdXCQrJUp6zsM3cTxVQ3bQjAWlEYYGOSxa5EcXl70WeCXlkipw6_00tyqUFjDSzziR0K1muy29j0vgOPHNqxR0";

AjaxHttpSender.prototype.sendGet = function (url, isAsync, callback) {
    return $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json',
        cache: false,
        async: (isAsync === undefined) ? true : isAsync,
        beforeSend: function () {
          //  onStartAjaxRequest();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
          //  onErrorHandling(errorThrown);
        },
        success: function (data, textStatus) {
            callback.success(data, textStatus);
        },
        complete: function (XMLHttpRequest, textStatus) {
         //   onEndAjaxRequest();
        }
    });
}

AjaxHttpSender.prototype.sendPost = function (url, data, callback) {
    debugger
    return $.ajax({
        url: url,
        type: 'POST',
        data: data,
        beforeSend: function () {
           // AjaxHttpSender.onStartAjaxRequest();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (callback != null) {
                callback.failure(XMLHttpRequest, textStatus, errorThrown);
            }
            else {
             //   appBase.showNotification(errorThrown, "error");
            }
        },
        success: function (data, textStatus) {
            if (callback != null) {
                callback.success(data, textStatus);
            }
        },
        complete: function (XMLHttpRequest, textStatus) {
          //  AjaxHttpSender.onEndAjaxRequest();
        }
    });
    //return $.ajax({
    //    url: url,
    //    type: 'POST',
    //    data: data,
    //    contentType: 'application/json',
    //    beforeSend: function () {
    //        onStartAjaxRequest();
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //      //  onErrorHandling(errorThrown);
    //    },
    //    success: function (resData, textStatus) {
    //        callback.success(resData, textStatus);
    //    },
    //    complete: function (XMLHttpRequest, textStatus) {
    //      //  onEndAjaxRequest();
    //    }
    //});
}

function onStartAjaxRequest() {
   
}

function onEndAjaxRequest() {
 
}

