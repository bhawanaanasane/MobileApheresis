function AddRowsToWRDeliveryRequest(List) {
    //var List = JSON.parse(List2);
    var mailingListTableData = $("#tblListFieldData").children('thead').children('tr');

    var ProductName = $("#ProductListDropdown option:selected").text();
    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr');

        var k = $('#tblListFieldData tr').length - 1;

        var rowsData = "";
        if (k == 0) {
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ProductDiv_" + k + " class='s-12'><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        else {

            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(12)) + 1;
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ProductDiv_" + k + " class='s-12'><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        rowsData += "<td><input name='Quantity' id=Quantity_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";


        rowsData += "<td><input name='Weight' id=Weight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Cubic' id=Cubic_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";

        rowsData += "<td class=\"text-center\"><a id = remove_" + k + "> <i class=\"s-14 icon-cancel red-text  handCursor\"></i></a ></td>";
        rowsData += "</tr>";


      
        $("#divListFieldRows").append(rowsData);

        $("#remove_" + k + "").click(function () {
            $("#Row_" + k + "").remove();

        });
        // $("#ProductName_" + k + "").change(function () {

        var arrayindex = List.data.findIndex(function (row) {
            return row.value == $("#ProductListDropdown").val();
        });
        var arrayData = List.data[arrayindex];
        document.getElementById("Quantity_" + k + "").value = "1";


        document.getElementById("Weight_" + k + "").value = (Math.round(parseFloat(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value))).toString();
        document.getElementById("Cubic_" + k + "").value = ((parseFloat(arrayData.Column4) / 1728) * parseInt(document.getElementById("Quantity_" + k + "").value)).toFixed(3).toString();



        //  });




        $("#Quantity_" + k + "").on('input', function () {
            var arrayindex = List.data.findIndex(function (row) {
                return row.value == $("#ProductListDropdown").val();
            });
            var arrayData = List.data[arrayindex];
            document.getElementById("Weight_" + k + "").value = (Math.round(parseFloat(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value))).toString();
            document.getElementById("Cubic_" + k + "").value = ((parseFloat(arrayData.Column4) / 1728) * parseInt(document.getElementById("Quantity_" + k + "").value)).toFixed(3).toString();
        });

    });



    function PostAddItemToRFQ(k, RfqId) {

        var jsonData = {
            RfqId: RfqId,
            ProductName: $("#ProductName_" + k).val(),
            Quantity: $("#Quantity_" + k).val(),
            Sku: $("#Sku_" + k).val(),
            Description: $("#Description_" + k).val(),
        };

        $.post("/Customer/AddProductToOrderDetails",

            jsonData
            ,
            function (data, status) {

            });
        SumOfInvoiceBill();
    }



}

function EditRowsToWRDeliveryRequest(List, orderIdFromForm) {

    var ProductTableData = $("#tblListFieldData").children('thead').children('tr');
    var ProductName = $("#ProductListDropdown option:selected").text();
    ProductTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr');

        var k = $('#tblListFieldData tr').length - 1;

        var rowsData = "";
        if (k == 0) {
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ProductDiv_" + k + " class=\"s-12\"><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        else {

            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(12)) + 1;
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ProductDiv_" + k + " class=\"s-12\"><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        rowsData += "<td><input name='Quantity' id=Quantity_" + k + " class=\"form-control s-12\" value=\"\"  /></td>";

        rowsData += "<td><input name='Weight' id=Weight_" + k + " class=\"form-control s-12\" value=\"\"/></td>";
        rowsData += "<td><input name='Cubic' id=Cubic_" + k + " class=\"form-control s-12\" value=\"\"/></td>";
        rowsData += "<td><input name='stockIn' id=stockIn_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td><input name='damage' id=damage_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td><input name='stockout' id=stockout_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td></td>";
        rowsData += "<td class=\"text-center\"><a id = save_" + k + " onclick='ValidateExDate(" + k + ", " + orderIdFromForm + ")'> <i class=\"s-12 icon-save text-blue ml-2 handCursor\"></i></a><a style=\"display: none\" id=SuccessIcon_" + k + " > <i class=\"icon-check3 text-green font-weight-bolder ml-1\"></i></a><a id = remove_" + k + "> <i class=\"s-14 icon-cancel red-text ml-2 handCursor\"></i></a ></td><a  style='display: none'  onclick='PostDeleteWRDeliveryRequestItem(" + k + "," + orderIdFromForm + ")'> <i class=\"s-14 icon-cancel red-text handCursor\"></i></a ></td>";
       
        rowsData += "</tr>";

        $("#divListFieldRows").append(rowsData);
        $("#remove_" + k + "").click(function () {
            $("#Row_" + k + "").remove();

        });


        //$("#ProductName_" + k + "").change(function () {

            var arrayindex = List.data.findIndex(function (row) {
                return row.value == $("#ProductListDropdown").val();
            });
            var arrayData = List.data[arrayindex];
            document.getElementById("Quantity_" + k + "").value = "1";
            document.getElementById("Weight_" + k + "").value = (Math.round(parseFloat(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value))).toString();
        document.getElementById("Cubic_" + k + "").value = ((parseFloat(arrayData.Column4) / 1728) * parseInt(document.getElementById("Quantity_" + k + "").value)).toFixed(3).toString();


        //});
        $("#Quantity_" + k + "").on('input', function () {
            var arrayindex = List.data.findIndex(function (row) {
                return row.value == $("#ProductListDropdown").val();
            });
            var arrayData = List.data[arrayindex];


            document.getElementById("Weight_" + k + "").value = (Math.round(parseFloat(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value))).toString();
            document.getElementById("Cubic_" + k + "").value = ((parseFloat(arrayData.Column4) / 1728) * parseInt(document.getElementById("Quantity_" + k + "").value)).toFixed(3).toString();


        });



    });


}
function QtyInputChaange(k, List) {
    $("#Quantity_" + k + "").on('input', function () {
        var arrayindex = List.data.findIndex(function (row) {
            return row.value == $("#ProductName_" + k + "").val();
        });
        var arrayData = List.data[arrayindex];


        document.getElementById("Weight_" + k + "").value = (Math.round(parseFloat(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value))).toString();
        document.getElementById("Cubic_" + k + "").value = ((parseFloat(arrayData.Column4) / 1728) * parseInt(document.getElementById("Quantity_" + k + "").value)).toFixed(3).toString();


    });
}


function PostAddWRDeliveryRequestProduct(k, WRid) {

    var jsonData = {

        id: $("#writem_" + k).val(),
        WRDeliveryRequestId: WRid,
        ProductId: $("#ProductName_" + k).val(),
        Quantity: $("#Quantity_" + k).val(),
        Weight: $("#Weight_" + k).val(),
        Cubic: $("#Cubic_" + k).val(),
        DeliveryDate: $("#DeliveryDate_" + k).val(),
    };

    $.post("/WRDeliveryReq/AddEditProductoWRDeliveryRequest",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                if (data.message == "Create") {
                    $("#save_" + k).hide();
                    $("#remove_" + k).show();
                    $("#edit_" + k).show();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {



                        $('#Quantity_' + k).prop('disabled', true);
                        $('#Weight_' + k).prop('disabled', true);
                        $('#Cubic_' + k).prop('disabled', true);
                        $('#StockOutQuantity_' + k).prop('disabled', true);
                        $('#DamageQuantity_' + k).prop('disabled', true);
                        $('#StockInQuantity_' + k).prop('disabled', true);
                        $('#DeliveryDate_' + k).prop('disabled', true);


                    });
                }
                else {
                    $("#save_" + k).hide();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {

                        $("#edit_" + k).show();
                        $("#remove_" + k).show();


                        $('#Quantity_' + k).prop('disabled', true);
                        $('#Weight_' + k).prop('disabled', true);
                        $('#Cubic_' + k).prop('disabled', true);
                        $('#StockOutQuantity_' + k).prop('disabled', true);
                        $('#DamageQuantity_' + k).prop('disabled', true);
                        $('#StockInQuantity_' + k).prop('disabled', true);
                        $('#DeliveryDate_' + k).prop('disabled', true);
                        


                    });
                }
            }
        });

}
function PostDeleteWRDeliveryRequestItem(k, Wrid) {

    var jsonData = {
        WRDeliveryRequestId: Wrid,
        id: $("#writem_" + k).val()

    };

    $.post("/WRDeliveryReq/DeleteProductWRDeliveryRequest",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + k + "").remove();

                $('#DeleteModal').modal('hide');
            }
        });

}
//Delete Delivery Request
function PostDeleteWrDeliveryRequest(Id) {

    var jsonData = {

        WRDeliveryRequestId: Id

    };
    $.post("/WRDeliveryReq/DeleteWRDeliveryRequest",
        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                $('#DeleteModal').modal('hide');
                window.location.reload();
            }
            else
                window.location.reload();
        });

}
//DeleteMultiple Delivery Request
function PostDeleteMultipleWRDeliveryRequest() {
    var selectedIds = [];
    $.each($("input[name='wrDeliveryRequest']:checked"), function () {
        selectedIds.push($(this).val());
    });

    var jsonData = {
        selectedIds: selectedIds
    };

    $.post("/WRDeliveryReq/DeleteSelected",
        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                $('#DeleteModal').modal('hide');
                window.location.reload();
            }
            else
                window.location.reload(); 
        });

}
function launch_toast() {
    $('#Toast').toast('show');


}
function ValidateExDate(k, orderIdFromForm) {
    var names = $("#ExDate_" + k);

    if (names.value == "") {
        $(".alert").show();
        setTimeout(function () { $(".alert").hide(); }, 5000);

    }
    else {
        PostAddWRDeliveryRequestProduct(k, orderIdFromForm);
    }

    //your code goes here



}

