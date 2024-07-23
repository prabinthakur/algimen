/// <reference path="jquery-3.4.1.intellisense.js" />



$(document).ready(function () {
    loaddata();


});

function loaddata() {
    $.ajax({
        url:"/hirevehicle/list",
        type:"get",
        dataType:"json",
        contentType:"json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.Vehicleid + '<td>';
                html += '<td>' + item.vehicleType + '<td>';
                html += '<td>' + item.vehiclePrice + '<td>';
                html += '<img src="~/photo/"'+item.vehiclephoto+' width=50 height=50>';
                html += '</tr>';



            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert("cannot load");
        }
      




    })
}