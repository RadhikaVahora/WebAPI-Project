
$(document).ready(function () {
    var ctable = $('#Custable').DataTable({
        ajax:
            {
                url: "/api/Customer",
                dataSrc: ""
            },
        columns: [
            {
                data: "name"
            },
            {
                data: "address"
            },
            {
                render: function (data, type, customer) {
                    return '<button class="btn btn-warning float-right js-edit" type="button" id="btn" edit-customer-id="'
                        + customer.customerId
                        + '"><i class="fa fa-edit">&nbsp;</i>Edit</button>';
                }
            },
            {
                render: function (data, type, customer) {
                    return "<button class='btn btn-danger float-right js-delete' del-customer-id='"
                        + customer.customerId
                        + "'><i class='fa fa-trash'>&nbsp;</i>Delete</button>";
                }
            }
        ]
    });

    ////EDIT
    $("#Custable").on("click", ".js-edit", function () {

        //  alert("Edit");
        var editbutton = $(this);

        $.ajax({
            url: "/api/customer/" + editbutton.attr("edit-customer-id"),
            method: "GET",
            success: function (result) {
                $("#CustomerId").val(result.customerId);
                $("#Name").val(result.name);
                $("#Address").val(result.address);
                $("#CreateModal").modal("show");
                $('#btnUpdate').show();
                $('#btnAdd').hide();

            }

        });
    });
    $("#btnUpdate").click(function () {


        var Updatebutton = $(this);
        //alert("Edit");
        var myformdata = {
            CustomerId: $("#CustomerId").val(),
            name: $("#Name").val(),
            address: $("#Address").val()
        }
        $.ajax({
            type: "PUT",
            url: "/api/Customer/",
            data: myformdata,
            success: function () {
                ctable.ajax.reload();
                $("#CreateModal").modal("hide");
            }

        })
    });

    // $("#btnUpdate").click()

    //DELETE
    $("#Custable").on("click", ".js-delete", function () {

        var delbutton = $(this);
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {

            if (result) {
                $.ajax({
                    url: "/api/customer/" + delbutton.attr("del-customer-id"),
                    method: "DELETE",
                    success: function () {
                        ctable.row(delbutton.parents("tr")).remove().draw();
                    }

                });
            }
        });
    });

    //ADD
    $("#btnAdd").click(function () {

        var myformdata = {
            name: $("#Name").val(),
            address: $("#Address").val()
        }
        $.ajax({
            type: "POST",
            url: "/api/Customer/",
            data: myformdata,
            success: function () {
                ctable.ajax.reload();
                $("#CreateModal").modal("hide");
            }
        })
    });
});



//Function for clearing the textboxes  
function clearTextBox() {
    $('#CustomerId').val("");
    $('#Name').val("");
    $('#Address').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
}  