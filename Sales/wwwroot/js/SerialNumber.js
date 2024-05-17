var mySet = new Set();

$(function () {
    ShowSerialNumberData();
});

function ShowSerialNumberData() {
    $.ajax({
        url: '/SerialNumber/SerialNumberList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.serialNumberId + '</td>';
                object += '<td>' + item.pId + '</td>';
                object += '<td>' + item.serialno + '</td>';
                mySet.add(String(item.serialno));
                object += '<td>' + item.stock + '</td>';
                object += '<td>' + item.oId + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.serialNumberId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + item.serialNumberId + ');">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);

            var myList = Array.from(mySet);

            autocomplete(document.getElementById("myInput"), myList);
        },
        error: function () {
            swal("So Sorry", "Data can't get!!!", "error");
        }
    });
};

$(document).ready(function () {
    $('#searchForm').submit(function (event) {
        event.preventDefault();

        var searchString = $('#myInput').val();
        $.ajax({
            url: '/SerialNumber/SearchSerialNumberList',
            type: 'GET',
            dataType: 'json',
            data: { searchString: searchString },
            success: function (data) {

                displayCustomers(data);

            },
            error: function () {

                alert("Error occurred while fetching customer data.");
            }
        });
    });

    function displayCustomers(data) {

        $('#table_data').empty();


        $.each(data, function (index, SerialNumber) {
            var row = '<tr>' +
                '<td>' + SerialNumber.serialNumberId + '</td>'+
                '<td>' + SerialNumber.pId + '</td>'+
                '<td>' + SerialNumber.serialno + '</td>'+
                '<td>' + SerialNumber.stock + '</td>'+
                '<td>' + SerialNumber.oId + '</td>'+
                '<td><a href="#" class="btn btn-primary" onclick="Edit(' + SerialNumber.serialNumberId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + SerialNumber.serialNumberId + ');">Delete</a></td>'+
             '</tr>';
            $('#table_data').append(row);
        });
    }
    $('#backtolist').click(function (event) {
        event.preventDefault();

        $('#myInput').val('');

        $.ajax({
            url: '/SerialNumber/SerialNumberList',
            type: 'GET',
            dataType: 'json',
            success: function (data) {

                displayCustomers(data);
            },
            error: function () {

                alert("Error occurred while fetching customer data.");
            }
        });
    });
});

$(function () {
    $('#btnAddSerialNumber').on('click', function () {
        $('#SerialNumberModal').modal('show');
    });
});


function AddSerialNumber() {
    var objData = {
        PId: $('#PId').val(),
        Serialno: $('#Serialno').val()
        
    }

    $.ajax({
        url: '/SerialNumber/AddSerialNumber',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            swal("Success", "Data is Successfully Saved!!!", "success"); 
            ClearTextBox();
            ShowSerialNumberData();
            HideModalPopUp();
        },
        error: function () {
            swal("Sorry", "Data can't Saved!!!", "error"); 
        }
    });

    function HideModalPopUp() {
        $('#SerialNumberModal').modal('hide');
    }

    function ClearTextBox() {
        $('#PId').val('');
        $('#Serialno').val('');
    }
}

function Delete(id) {
    //if (confirm('Are you want to delete this record?')) {
    //    $.ajax({
    //        url: '/SerialNumber/Delete?id=' + id,
    //        success: function () {
    //            alert('Record Deleted!');
    //            ShowSerialNumberData();
    //        },
    //        error: function () {
    //            alert("Data can't be Deleted");
    //        }
    //    })
    //}
    swal({
        title: "Are you sure want to delete this record?",
        /*text: "Once deleted, you will not be able to recover this record!",*/
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: '/SerialNumber/Delete?id=' + id,
                    success: function () {
                        swal("Poof! Your record has been deleted!!!", {
                            icon: "success",
                        });
                        ShowSerialNumberData();
                    },
                    error: function () {
                        swal("Error", "Data can't be deleted!!!", "error");
                    }
                });
            } else {
                swal("Cancel", "Your record is safe!", "info");
            }
        });
}

function Edit(id) {
    $.ajax({
        url: '/SerialNumber/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#EditSerialNumberModal').modal('show');
            $('#SerialNumberId').val(response.serialNumberId);
            $('#PId').val(response.pId);
            $('#ESerialno').val(response.serialno);
            $('#stock').val(response.stock);

            $('#btnUpdate').show();
        },
        error: function () {
            swal("Sorry", "Data not found!!!", "error"); 
        }
    })
}

function UpdateSerialNumber() {
    var objData = {
        SerialNumberId: $('#SerialNumberId').val(),
        PId: $('#PId').val(),
        Serialno: $('#ESerialno').val(),
        stock: $('#stock').val()
    }
    $.ajax({
        url: '/SerialNumber/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            swal("Success", "Data is Successfully Updated!!!", "success"); 
            ClearTextBox();
            ShowSerialNumberData();
            HideModalPopUp();
        },
        error: function () {
            swal("Sorry", "Data can't Updated!!!", "error"); 
        }

    })
    function HideModalPopUp() {
        $('#EditSerialNumberModal').modal('hide');
    }

    function ClearTextBox() {
        $('#SerialNumberId').val();
        $('#PId').val('');
        $('#ESerialno').val('');
        $('#stock').val('');
    }
}