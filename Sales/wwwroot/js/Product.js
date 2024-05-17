
var mySet = new Set();

$(function () {
    ShowProductData();
});

function ShowProductData() {
    $.ajax({
        url: '/Product/ProductList',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.pId + '</td>';
                object += '<td>' + item.pName + '</td>';
                mySet.add(String(item.pName));
                object += '<td>' + item.pDescription + '</td>';
                object += '<td>' + item.price + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.pId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + item.pId + ');">Delete</a></td>';
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
            url: '/Product/SearchProductList',
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
        $.each(data, function (index, product) {
            var row = '<tr>' +
             '<td>' + product.pId + '</td>'+
            '<td>' + product.pName + '</td>'+
            '<td>' + product.pDescription + '</td>'+
            '<td>' + product.price + '</td>'+
                '<td><a href="#" class="btn btn-primary" onclick="Edit(' + product.pId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + product.pId + ');">Delete</a></td>'+
            '</tr>';
            $('#table_data').append(row);
        });
    }
    $('#backtolist').click(function (event) {
        event.preventDefault();

        $('#myInput').val('');

        $.ajax({
            url: '/Product/ProductList',
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
    $('#btnAddProduct').on('click', function () {
        $('#ProductModal').modal('show');
    });
});


function AddProduct() {
    var objData = {
        PName: $('#PName').val(),
        PDescription: $('#PDescription').val(),
        Price: $('#Price').val()
    }

    $.ajax({
        url: '/Product/AddProduct',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function (response) {

            if (response === "Data is Saved") {
                swal("Success", "Data is Successfully Saved!!!", "success");
                ClearTextBox();
                ShowProductData();
                HideModalPopUp();
            } else {
                swal("Sorry", response, "info");
                ClearTextBox();
                ShowProductData();
                HideModalPopUp();
            }
        },
        error: function () {
            swal("Sorry", "Data can't Saved!!!", "error");
        }

    });

    function HideModalPopUp() {
        $('#ProductModal').modal('hide');
    }

    function ClearTextBox() {
        $('#PName').val('');
        $('#PDescription').val('');
        $('#Price').val('');
    }
}

function Delete(id) {
    //if (confirm('Are you want to delete this record?')) {
    //    $.ajax({
    //        url: '/Product/Delete?id=' + id,
    //        success: function () {
    //            alert('Record Deleted!');
    //            ShowProductData();
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
                    url: '/Product/Delete?id=' + id,
                    success: function () {
                        swal("Poof! Your record has been deleted!!!", {
                            icon: "success",
                        });
                        ShowProductData();
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
        url: '/Product/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#EditProductModal').modal('show');
            $('#ProductId').val(response.pId);
            $('#PEName').val(response.pName);
            $('#PEDescription').val(response.pDescription);
            $('#EPrice').val(response.price);

            $('#btnUpdate').show();
        },
        error: function () {
            swal("Sorry", "Data not found!!!", "error");
        }
    })
}

function UpdateProduct() {
    var objData = {
        PId: $('#ProductId').val(),
        PName: $('#PEName').val(),
        PDescription: $('#PEDescription').val(),
        price: $('#EPrice').val()
    }
    $.ajax({
        url: '/Product/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            swal("Success", "Data is Successfully Updated!!!", "success"); 
            ClearTextBox();
            ShowProductData();
            HideModalPopUp();
        },
        error: function () {
            swal("Sorry", "Data can't Updated!!!", "error");
        }

    })
    function HideModalPopUp() {
        $('#EditProductModal').modal('hide');
    }

    function ClearTextBox() {
        $('#ProductId').val();
        $('#PEName').val('');
        $('#PEDescription').val('');
        $('#EPrice').val('');
    }
}