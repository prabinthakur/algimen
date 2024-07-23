/// <reference path="jquery-3.4.1.intellisense.js" />




$(document).ready(function () {

  /*  loaddata();*/

})
//function loaddata() {
//    $.ajax({
//        url:"/staff/list",
//        type: "get",
//        contentType: "json",
//        dataType: "json",
//        success: function (result) {
//            var html = '';
//            $.each(result, function (key, item) {


//                html += '<tr>';
//                html += '<td>' + item.staff_id + '</td>'
//                html += '<td>' + item.Name + '</td>'
//                html += '<td>' + item.post + '</td>'
//                html += '<td>' + item.salary + '</td>'
//                html += '<td>' + item.hiredate + '</td>'
//                html += '<td><a href="#" onclick="getid(' + item.staff_id + ')">Edit</a>';
//                html += '<td><a href="#" onclick="removestaff(' + item.staff_id + ')">delete</a>';
//                html += '</tr>'

//            });
//            $('tbody').html(html);


//        }, error: function (errormessage) {
//            alert("cannot load");
//        }

//    });
   



//}


function addstaff() {
    



        var staffobj = {
            name: $("#Name").val(),
            post: $("#post").val(),
            salary: $("#salary").val(),
            hiredate: $("#hiredate").val(),
        }
        $.ajax({
            url: "/Staff/addstaff",
            data: JSON.stringify(staffobj),
            type: "post",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loaddata();
                $('#myModal').modal('hide');

            },
            error: function (errormessage) {
                alert("cannot insert");
            }
        })
    
}

function getid(staffid) {

    $.ajax({
        url: "/staff/getid/" + staffid,
        type: "get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#staffid').val(result.staff_id);
            $("#Name").val(result.Name);
            $("#post").val(result.post);
            $("#salary").val(result.salary);
            $("#hiredate").val(result.hiredate);
             $('#update').show();
            $('#add').hide();
            $('#myModal').modal('show');

        },
        error: function (errormessage) {
            alert("erro occured");
        }
            



    })
}
function update() {

    var staffobj = {
        staff_id: $('#staffid').val(),
        Name: $("#Name").val(),
        post: $("#post").val(),
        salary: $("#salary").val(),
        hiredate: $("#hiredate").val(),
    }
    $.ajax({
        url: "/staff/edit/",
        type: "post",
        data: JSON.stringify(staffobj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loaddata();
            $('#Name').val("");
            $("#post").val("");
            $("#salary").val("");
            $("#hiredate").val("");
            $('#myModal').modal('hide');

        },
        error: function (errormessage) {
            alert("cannot insert");
        }
    })


}
function removestaff(id)
{
    $.ajax({
        url: "/staff/removestaff/" + id,
        type: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loaddata();

        },
        error: function (errormessage) {
            alert("deleted");



        }



    })


}

function validate() {
    var isvalid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isvalid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#post').val().trim() == "") {
        $('#post').css('border-color', 'Red');
        isvalid = false;
    }
    else {
        $('#post').css('border-color', 'lighygrey');
    }
    if ($('#salary').val().trim() == "") {
        $('#salary').css('border-color', 'Red');
        isvalid = false;
    }
    else {
        $('#hiredate').css('border-color', 'lighygrey');
    }
    if ($('#hiredate').val().trim() == "") {
        $('#hiredate').css('border-color', 'Red');
        isvalid = false;
    }
    else {
        $('#hiredate').css('border-color', 'lighygrey');
    }

}
      
