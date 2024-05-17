$(document).ready({
    $() { }, : .on("input", function() {
        var inputVal = $(this).val();
        $.ajax({
            url: "/Customer/GetCustomerNames",
            type: "GET",
            data: { term: inputVal },
            dataType: "json",
            success: function(response) {

                autocomplete(document.getElementById("searchString"), response);
            },
            error: function(xhr) {
                console.log(xhr.responseText);
            }
        });
    })
});
