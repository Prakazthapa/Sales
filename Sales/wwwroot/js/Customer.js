var mySet = new Set();
$(function () {
    ShowCustomerData();
});


$(document).ready(function () {
    $.ajax({
        url: '/Customer/getProvince',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result) {
            $("#ProvinceId").append('<option disabled selected value=0>--Select Province--</option>');
            $("#DistrictId").append('<option disabled selected value=0>--Select District--</option>');
            $("#LocalBodyId").append('<option disabled selected value=0>--Select Local Body--</option>');
            $.each(result, function (index, value) {
                $("#ProvinceId").append('<option value=' + value.id + '>' + value.name + '</option>');
            })
        }
    });
    $("#ProvinceId").change(function () {
        $("#DistrictId").empty();
        var one = $("#ProvinceId").val();
        var URL = '/Customer/getDistrict?id=' + one;
        $.ajax({
            url: URL,
            type: 'Get',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8;',
            success: function (result) {
                $.each(result, function (index, value) {
                    $("#DistrictId").append('<option value=' + value.id + '>' + value.name + '</option>');

                })
            }
        });
    });
    $("#DistrictId").change(function () {
        $("#LocalBodyId").empty();
        var one = $("#DistrictId").val();
        var URL = '/Customer/getLocalbody?id=' + one;
        $.ajax({
            url: URL,
            type: 'Get',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8;',
            success: function (result) {
                $.each(result, function (index, value) {
                    $("#LocalBodyId").append('<option value=' + value.id + '>' + value.name + '</option>');

                })
            }
        });
    });
});

$(document).ready(function () {
    $.ajax({
        url: '/Customer/getProvince',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result) {
            
            $.each(result, function (index, value) {
                $("#EProvinceId").append('<option value=' + value.id + '>' + value.name + '</option>');
                
            })
        }
    });


    $("#EProvinceId").change(function () {
        $("#EDistrictId").empty();
        var one = $("#EProvinceId").val();
        var URL = '/Customer/getDistrict?id=' + one;
        $.ajax({
            url: URL,
            type: 'Get',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8;',
            success: function (result) {
                $.each(result, function (index, value) {
                    $("#EDistrictId").append('<option value=' + value.id + '>' + value.name + '</option>');

                })
            }
        });
    });
    $("#EDistrictId").change(function () {
        $("#ELocalBodyId").empty();
        var one = $("#EDistrictId").val();
        var URL = '/Customer/getLocalbody?id=' + one;
        $.ajax({
            url: URL,
            type: 'Get',
            dataType: 'json',
            contentType: 'application/json;charset=utf-8;',
            success: function (result) {
                $.each(result, function (index, value) {
                    $("#ELocalBodyId").append('<option value=' + value.id + '>' + value.name + '</option>');
                })
            }
        });
    });
});


function ShowCustomerData() {
    var url = '/Customer/CustomerList';
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.cId + '</td>';
                object += '<td>' + item.cName + '</td>';
                mySet.add(String(item.cName));
                object += '<td>' + item.provinceId + '</td>';
                object += '<td>' + item.districtId + '</td>';
                object += '<td>' + item.localBodyId + '</td>';
                object += '<td>' + item.wardno + '</td>';
                object += '<td>' + item.mobileNumber + '</td>';
                object += '<td>' + item.email + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.cId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + item.cId + ');">Delete</a></td>';
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
}


$(document).ready(function () {
    $('#searchForm').submit(function (event) {
        event.preventDefault(); 

        var searchString = $('#myInput').val();
        $.ajax({
            url: '/Customer/SearchCustomerList', 
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

        
        $.each(data, function (index, customer) {
            var row = '<tr>' +
                '<td>' + customer.cId + '</td>' +
                '<td>' + customer.cName + '</td>' +
                '<td>' + customer.provinceId + '</td>' +
                '<td>' + customer.districtId + '</td>' +
                '<td>' + customer.localBodyId + '</td>' +
                '<td>' + customer.wardno + '</td>' +
                '<td>' + customer.mobileNumber + '</td>' +
                '<td>' + customer.email + '</td>' +
                '<td><a href="#" class="btn btn-primary" onclick="Edit(' + customer.cId + ')" >Edit</a>  <a href="#" class="btn btn-danger" onclick="Delete(' + customer .cId + ');">Delete</a></td>'+
                '</tr>';
            $('#table_data').append(row);
        });
    }
    $('#backtolist').click(function (event) {
        event.preventDefault();

        $('#myInput').val('');
        
        $.ajax({
            url: '/Customer/CustomerList', 
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
    $('#btnAddCustomer').on('click', function () {
        $('#CustomerModal').modal('show');
    });
});


function AddCustomer() {
    var objData = {
        CName: $('#CName').val(),
        ProvinceId: $('#ProvinceId').val(),
        DistrictId: $('#DistrictId').val(),
        LocalBodyId: $('#LocalBodyId').val(),
        wardno: $('#WardNumber').val(),
        MobileNumber: $('#MobileNumber').val(),
        Email: $('#Email').val()
    }
    $.ajax({
        url: '/Customer/AddCustomer',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
           
            swal("Success", "Data is Successfully Saved!!!", "success"); 
            ClearTextBox();
            ShowCustomerData();
            HideModalPopUp();
        },
        error: function () {
            
            swal("Sorry", "Data can't Saved!!!", "error"); 
        }
    });

    function HideModalPopUp() {
        $('#CustomerModal').modal('hide');
    }

    function ClearTextBox() {
        $('#CName').val('');
        $('#ProvinceId').val('');
        $('#DistrictId').val('');
        $('#LocalBodyId').val('');
        $('#WardNumber').val('');
        $('#MobileNumber').val('');
        $('#Email').val('');
    }
}

function Delete(id) {
    //if (confirm('Are you want to delete this record?')) {
    //    $.ajax({
    //        url: '/Customer/Delete?id=' + id,
    //        success: function () {
    //            alert('Record Deleted!');
    //            ShowCustomerData();
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
                        url: '/Customer/Delete?id=' + id,
                        success: function () {
                            swal("Poof! Your record has been deleted!!!", {
                                icon: "success",
                            });
                            ShowCustomerData();
                        },
                        error: function () {
                            swal("Error", "Data can't be deleted!!!", "error");
                        }
                    });
                } else {
                    swal("Cancel","Your record is safe!","info");
                }
            });
    

}

function Edit(id) {
    $.ajax({
        url: '/Customer/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            
            $('#EditCustomerModal').modal('show');
            $('#CustomerId').val(response.cId);
            $('#CEName').val(response.cName);
            $('#EProvinceId').val(response.provinceId);

            $('#EDistrictId').val(response.districtId);
            var one = $("#EProvinceId").val();
            var URL = '/Customer/getDistrict?id=' + one;
            $.ajax({
                url: URL,
                type: 'Get',
                dataType: 'json',
                contentType: 'application/json;charset=utf-8;',
                success: function (result) {
                    $("#EDistrictId").empty(); 
                    $.each(result, function (index, value) {
                        var option = '<option value="' + value.id + '"';
                        
                        if (value.id == response.districtId) {
                            option += ' selected'; 
                        }
                        option += '>' + value.name + '</option>';
                        $("#EDistrictId").append(option);
                    });
                }
            });

            $('#ELocalBodyId').val(response.localBodyId);
            
            var two =response.districtId;
            var URL = '/Customer/getLocalbody?id=' + two;
            $.ajax({
                url: URL,
                type: 'Get',
                dataType: 'json',
                contentType: 'application/json;charset=utf-8;',
                success: function (result) {
                    $("#ELocalBodyId").empty();
                    $.each(result, function (index, value) {
                        var option = '<option value="' + value.id + '"';

                        if (value.id == response.localBodyId) {
                            option += ' selected';
                        }
                        option += '>' + value.name + '</option>';
                        $("#ELocalBodyId").append(option);
                    });
                }
            });

            $('#EWardNumber').val(response.wardno);
            $('#EMobileNumber').val(response.mobileNumber);
            $('#EEmail').val(response.email);

            $('#btnUpdate').show();
        },
        error: function () {
            /*alert('Data not found');*/
            swal("Sorry", "Data not found!!!", "error"); 
        }
    })
}

function UpdateCustomer() {
   
    var objData = {
        CId: $('#CustomerId').val(),
        CName: $('#CEName').val(),
        ProvinceId: $('#EProvinceId').val(),
        DistrictId: $('#EDistrictId').val(),
        LocalBodyId: $('#ELocalBodyId').val(),
        wardno: $('#EWardNumber').val(),
        MobileNumber: $('#EMobileNumber').val(),
        Email: $('#EEmail').val()
    }
    
    $.ajax({
        url: '/Customer/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: 'json',
        success: function () {
            /*alert('Data Saved');*/
            swal("Success", "Data is Successfully Updated!!!", "success"); 
            ClearTextBox();
            ShowCustomerData();
            HideModalPopUp();
        },
        error: function () {
            /*alert("Data can't Saved");*/
            swal("Sorry", "Data can't Updated!!!", "error"); 
        }

    })
    function HideModalPopUp() {
        $('#EditCustomerModal').modal('hide');
    }

    function ClearTextBox() {
        $('#CustomerId').val('');
        $('#CEName').val('');
        $('#ProvinceId').val('');
        $('#DistrictId').val('');
        $('#LocalBodyId').val('');
        $('#WardNumber').val('');
        $('#EMobileNumber').val('');
        $('#EEmail').val('');
    }
}