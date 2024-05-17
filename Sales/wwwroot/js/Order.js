$(function () {
    ShowOrderData();
});

//$(document).ready(function () {
//    $("#PId").change(function () {
//        var data = $("#PId").val();
//        var URL = '/order/serid?id=' + data;

//        $.ajax({
//            url: URL,
//            data: 'json',
//            type: 'Get',
//            contentType: 'application/json;charset=utf-8',
//            success: function (result) {
//                var options = [];
//                $.each(result, function (index, value) {
//                    var newItem = {
//                        value: value.serialNumberId,
//                        text: value.serialno
//                    };
//                    options.push(newItem);
//                });

//                $("#SerialNumberId").empty();
//                $.each(options, function (index, option) {
//                    $('#SerialNumberId').append($('<option>', {
//                        value: option.value,
//                        text: option.text
//                    }));
//                });
//            }
//        });
//    });

//})

//$(document).ready(function () {
//    $("#EPId").change(function () {
//        drop();
//    });
//        });


//function drop() {
//    var data = $("#EPId").val();
//    var URL = '/order/serid?id=' + data;

//    $.ajax({
//        url: URL,
//        data: 'json',
//        type: 'Get',
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) {
//            var options = [];
//            $.each(result, function (index, value) {
//                var newItem = {
//                    value: value.serialNumberId,
//                    text: value.serialno
//                };
//                options.push(newItem);
//            });

//            $("#ESerialNumberId").empty();
//            $.each(options, function (index, option) {
//                $('#ESerialNumberId').append($('<option>', {
//                    value: option.value,
//                    text: option.text
//                }));
//            });
//        }

//        });
    
//}

function ShowOrderData() {
    $.ajax({
        url: '/Order/OrderList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.oId + '</td>';
                object += '<td>' + item.cId + '</td>';
                object += '<td>' + item.pId + '</td>';
                /*object += '<td>' + item.serialNumberId + '</td>';*/
                object += '<td>' + item.oDateTime + '</td>';
                object += '<td>' + item.quantity + '</td>';
                object += '<td>' + item.totalAmount + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.oId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + item.oId + ');">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            swal("So Sorry", "Data can't get!!!", "error"); 
        }
    });
};
$(function () {
    $('#btnAddOrder').on('click', function () {
        $('#OrderModal').modal('show');
    });
});


function AddOrder() {
    var objData = {
        CId: $('#CId').val(),
        PId: $('#PId').val(),
        /*SerialNumberId: $('#SerialNumberId').val(),*/
        ODateTime: $('#ODate').val(),
        Quantity: $('#Quantity').val()

    }
    $.ajax({
        url: '/Order/AddOrder',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function (data) {
            if (data.success) {
                swal("Success", "Data is Successfully Saved!!!", "success");
            }
            else {
                swal("Sorry", "The Selected Quantity is not available!!!", "error");
            }
            
            ClearTextBox();
            ShowOrderData();
            HideModalPopUp();
        },
        error: function () {
            swal("Sorry", "Data can't Saved!!!", "error");
        }
    });

    function HideModalPopUp() {
        $('#OrderModal').modal('hide');
    }

    function ClearTextBox() {
        $('#CId').val('');
        $('#PId').val('');
        /*$('#SerialNumberId').val('');*/
        $('#ODate').val('');
        $('#Quantity').val('');
    }
}

function Delete(id) {
    //if (confirm('Are you want to delete this record?')) {
    //    $.ajax({
    //        url: '/Order/Delete?id=' + id,
    //        success: function () {
    //            alert('Record Deleted!');
    //            ShowOrderData();
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
                    url: '/Order/Delete?id=' + id,
                    success: function () {
                        swal("Poof! Your record has been deleted!!!", {
                            icon: "success",
                        });
                        ShowOrderData();
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
        url: '/Order/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#EditOrderModal').modal('show');
            $('#OrderId').val(response.oId);
            $('#CId').val(response.cId);
            $('#PId').val(response.pId);
            /*drop();*/
            /*$('#ESerialNumberId').val(response.serialNumberId);*/
            $('#EODate').val(response.oDateTime);
            $('#EQuantity').val(response.quantity);
            $('#btnUpdate').show();
        },
        error: function () {
            swal("Sorry", "Data not found!!!", "error");
        }
    })
}

function UpdateOrder() {
    var objData = {
        OId: $('#OrderId').val(),
        CId: $('#CId').val(),
        PId: $('#PId').val(),
        /*SerialNumberId: $('#ESerialNumberId').val(),*/
        ODateTime: $('#EODate').val(),
        Quantity: $('#EQuantity').val()
    }
    $.ajax({
        url: '/Order/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            swal("Success", "Data is Successfully Updated!!!", "success");
            ClearTextBox();
            ShowOrderData();
            HideModalPopUp();
        },
        error: function () {
            swal("Sorry", "Data can't Updated!!!", "error"); 
        }

    })
    
    function HideModalPopUp() {
        $('#EditOrderModal').modal('hide');
    }

    function ClearTextBox() {
        $('#OrderId').val('');
        $('#CId').val('');
        $('#PId').val('');
        /*$('#ESerialNumberId').val('');*/
        $('#OEDate').val('');
        $('#EQuantity').val('');
    }
}
