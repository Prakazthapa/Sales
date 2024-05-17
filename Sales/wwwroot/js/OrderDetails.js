$(function () {
    ShowOrderDetailsData();
});

function ShowOrderDetailsData() {
    
    $.ajax({
        url: '/OrderDetails/OrderDetailsList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.odId + '</td>';
                object += '<td>' + item.cId + '</td>';
                object += '<td>' + item.pId + '</td>';
                object += '<td>' + item.oId + '</td>';
                object += '<td>' + item.quantity + '</td>';
                object += '<td>' + item.unitPrice + '</td>';
                object += '<td>' + item.totalPrice + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.odId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + item.odId + ');">Delete</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data can't get");
        }
    });
};
$(function () {
    $('#btnAddOrderDetails').on('click', function () {
        $('#OrderDetailsModal').modal('show');
    });
});


function AddOrderDetails() {

    var objData = {
        CId: $('#CId').val(),
        PId: $('#PId').val(),
        OId: $('#OId').val(),
        Quantity: $('#Quantity').val(),
        UnitPrice: $('#UnitPrice').val(),
        TotalPrice: $('#TotalPrice').val()

    }
    $.ajax({
        url: '/OrderDetails/AddOrderDetails',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('Data Saved');
            ClearTextBox();
            ShowOrderDetailsData();
            HideModalPopUp();
        },
        error: function () {
            alert("Data can't Saved");
        }
    });

    function HideModalPopUp() {
        $('#OrderDetailsModal').modal('hide');
    }

    function ClearTextBox() {
        $('#CId').val('');
        $('#PId').val('');
        $('#OId').val('');
        $('#Quantity').val('');
        $('#UnitPrice').val('');
        $('#TotalPrice').val('');
    }
}

function Delete(id) {
    if (confirm('Are you want to delete this record?')) {
        $.ajax({
            url: '/OrderDetails/Delete?id=' + id,
            success: function () {
                alert('Record Deleted!');
                ShowOrderDetailsData();
            },
            error: function () {
                alert("Data can't be Deleted");
            }
        })
    }
}

function Edit(id) {
    $.ajax({
        url: '/OrderDetails/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#EditOrderDetailsModal').modal('show');
            $('#OrderDetailsId').val(response.odId);
            $('#CId').val(response.cId);
            $('#PId').val(response.pId);
            $('#OId').val(response.oId);
            $('#EQuantity').val(response.quantity);
            $('#EUnitPrice').val(response.unitPrice);
            $('#ETotalPrice').val(response.totalPrice);
            $('#btnUpdate').show();
        },
        error: function () {
            alert('Data not found');
        }
    })
}
function UpdateOrderDetails() {
    var objData = {
        ODId: $('#OrderDetailsId').val(),
        CId: $('#CId').val(),
        PId: $('#PId').val(),
        OId: $('#OId').val(),
        Quantity: $('#EQuantity').val(),
        UnitPrice: $('#EUnitPrice').val(),
        TotalPrice: $('#ETotalPrice').val()
    }

    $.ajax({
        url: '/OrderDetails/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('Data Saved');
            ClearTextBox();
            ShowOrderDetailsData();
            HideModalPopUp();
        },
        error: function () {
            alert("Data can't Saved");
        }

    })

    function HideModalPopUp() {
        $('#EditOrderDetailsModal').modal('hide');
    }

    function ClearTextBox() {
        $('#OrderDetailsId').val('');
        $('#CId').val('');
        $('#PId').val('');
        $('#OId').val('');
        $('#EQuantity').val('');
        $('#EUnitPrice').val('');
        $('#ETotalPrice').val('');
    }
}