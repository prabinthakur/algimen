/// <reference path="jquery-3.4.1.intellisense.js" />
$.ready(function () {
    getid();
})

function hirevehicle(vehid) {
    $.ajax({
        url: "/Vehicle/getid/" + vehid,
        type: "get",
        dataType: "json",
        contentType: "json",
        success: function (result) {

            alert("vehicleid" + result.vehid);

        },
        error: function (errormessage) {

            alert("cannnot")
        }




    })
}