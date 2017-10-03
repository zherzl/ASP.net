$(function () {
    var url = '/Home/GetCountries';
    Settings.postAjaxSettings(function (res) {
        if (res.Success == true) {
            displayInfo(res.Drzave[0].Naziv);
        }

    }, url, null, false);


    url = '/Home/GetCities';
    Settings.postAjaxSettings(function (res) {
        if (res.Success == true) {
            displayInfo(res.Cities[0].Naziv);
        }

    }, url, null, false);
});



var Settings = (function () {

    function getAjaxSettings(callback, url, data) {
        $.ajax({
            url: url, data: data, dataType: "json", method: "GET", contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Success === false) {
                    displayError(data.Message);
                }
                else {
                    callback(data);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                displayError("Nije moguće dohvatiti podatke: " + xhr.responseText, 10000);
            }
        });
    }

    function postAjaxSettings(callback, url, data, prikaziWait) {
        $.ajax({
            url: url, data: data, dataType: "json", type: "post", contentType: "application/json; charset=utf-8",
            success: function (data) {
                data = JSON.parse(data);
                if (data.Success === false) {
                    displayError(data.Message, 10000);
                }
                else {
                    callback(data);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                displayError("Greška: " + xhr.responseText, 10000);
            }
        });
    }

    return {
        getAjaxSettings: getAjaxSettings,
        postAjaxSettings: postAjaxSettings
    }
})();




function displayError(msg, hideDelay) {
    $("#errorMsg").html(msg);
    if (isNaN(hideDelay) || hideDelay == 0) {
        hideDelay = 30000;
    }
    $("#errorPanel").stop(true, true).slideDown(250).delay(hideDelay).slideUp('slow');
    return false;
}
function displayInfo(msg, hideDelay) {
    $("#infoMsg").html(msg);
    if (isNaN(hideDelay) || hideDelay == 0) { hideDelay = 30000; }
    $("#infoPanel").stop(true, true).slideDown(250).delay(hideDelay).slideUp('slow');
    return false;
}
function displayWarning(msg, hideDelay) {
    $("#warningMsg").html(msg);
    if (isNaN(hideDelay) || hideDelay == 0) { hideDelay = 30000; }
    $("#warningPanel").stop(true, true).slideDown(250).delay(hideDelay).slideUp('slow');
    return false;
}
function closeDialogsEvent() {
    $(".close").click(function () {
        $(".alert").stop(true, true).slideUp('fast');
    });
}