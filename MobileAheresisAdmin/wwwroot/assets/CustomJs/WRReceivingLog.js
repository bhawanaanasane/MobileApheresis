function AddRowsToWRReceivingLog(List) {

    var mailingListTableData = $("#tblListFieldData").children('thead').children('tr');
    var ProductName = $("#ProductListDropdown option:selected").text();
    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr');

        var k = $('#tblListFieldData tr').length - 1;

        var rowsData = "";
        if (k == 0) {
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ProductDiv_" + k + "  class='s-12'><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        else {
            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(12)) + 1;
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ProductDiv_" + k + "  class='s-12'><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }

        rowsData += "<td><input name='Quantity' id=Quantity_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='Weight' id=Weight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Cubic' id=Cubic_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ExDate' id=ExDate_" + k + " class=\"date-time-picker form-control form-control-sm s-12\" data-options='{\"timepicker\":false, \"format\":\"m/d/Y\"}'  autocomplete = \"off\" value=\"\"/></td>";
        rowsData += "<td><a id = remove_" + k + "> <i class=\"s-14 icon-cancel ml-2 red-text handCursor\"></i></a ></td>";
        rowsData += "</tr>";




        $("#divListFieldRows").append(rowsData);
        var arrayindex = List.data.findIndex(function (row) {
            return row.value == $("#ProductListDropdown").val();
        });
        var arrayData = List.data[arrayindex];
        if (arrayData.Column5 == 1) {
            $("#ExDate_" + k).prop('disabled', true);
        }
        else
        {
            $("#ExDate_" + k).datetimepicker(
                {
                    format: "m/d/Y",
                    timepicker: false
                });
        }


        $("#remove_" + k + "").click(function () {
            $("#Row_" + k + "").remove();

        });
        // $("#ProductName_" + k + "").change(function () {


        document.getElementById("Quantity_" + k + "").value = "1";


        document.getElementById("Weight_" + k + "").value = (Math.round(parseFloat(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value))).toString();
        document.getElementById("Cubic_" + k + "").value = ((parseFloat(arrayData.Column4) / 1728) * parseInt(document.getElementById("Quantity_" + k + "").value)).toFixed(3).toString();



        // });




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

function EditRowsToWRReceivingLog(List, orderIdFromForm) {

    var ProductTableData = $("#tblListFieldData").children('thead').children('tr');
    var ProductName = $("#ProductListDropdown option:selected").text();
    ProductTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr');

        var k = $('#tblListFieldData tr').length - 1;

        var rowsData = "";
        if (k == 0) {
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td class=\"s-12\" id=ProductDiv_" + k + "><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        else {

            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(12)) + 1;
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td class=\"s-12\" id=ProductDiv_" + k + "><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        rowsData += "<td><input name='Quantity' id=Quantity_" + k + " class=\"form-control s-12\" value=\"\"  /></td>";

        rowsData += "<td><input name='Weight' id=Weight_" + k + " class=\"form-control s-12\" value=\"\"/></td>";
        rowsData += "<td><input name='Cubic' id=Cubic_" + k + " class=\"form-control s-12\" value=\"\"/></td>";
        rowsData += "<td><input name='ExDate' id=ExDate_" + k + " class=\"date-time-picker form-control form-control-sm s-12\" data-options='{\"timepicker\":false, \"format\":\"m/d/Y\"}'  autocomplete = \"off\" value=\"\"/></td>";
        rowsData += "<td><input name='stockIn' id=stockIn_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td><input name='PalletInQuantity' id=PalletInQuantity_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td><input name='damage' id=damage_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td><input name='extra' id=extra_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td><input name='stockout' id=stockout_" + k + " class=\"form-control s-12\" value=\"0\" readonly/></td>";
        rowsData += "<td></td>";
        rowsData += "<td class=\"text-center\"><a id = save_" + k + " onclick='ValidateExDate(" + k + ", " + orderIdFromForm + ")'> <i class=\"s-14 ml-2 icon-save text-blue handCursor\"></i></a><a style=\"display: none\" id=SuccessIcon_" + k + " > <i class=\"icon-check3 text-green font-weight-bolder ml-1\"></i></a><a id = remove_" + k + "> <i class=\"s-14 ml-2 icon-cancel red-text handCursor\"></i></a ></td><a  style='display: none'  onclick='PostDeleteWrReceivedItem(" + k + "," + orderIdFromForm + ")'> <i class=\"s-14 icon-cancel red-text handCursor\"></i></a ></td>";

        rowsData += "</tr>";


        $("#divListFieldRows").append(rowsData);
        $("#ExDate_" + k + "").datetimepicker(
            {
                format: "m/d/Y",
                timepicker: false
            });
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

function QtyInputChange(k, List) {
    $("#Quantity_" + k + "").on('input', function () {
        var arrayindex = List.data.findIndex(function (row) {
            return row.value == $("#ProductName_" + k + "").val();
        });
        var arrayData = List.data[arrayindex];


        document.getElementById("Weight_" + k + "").value = (Math.round(parseFloat(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value))).toString();
        document.getElementById("Cubic_" + k + "").value = ((parseFloat(arrayData.Column4) / 1728) * parseInt(document.getElementById("Quantity_" + k + "").value)).toFixed(3).toString();


    });
}

function PostAddWrReceivedProduct(k, WRid) {

    var jsonData = {

        id: $("#writem_" + k).val(),
        WrReceivedId: WRid,
        ProductId: $("#ProductName_" + k).val(),
        Quantity: $("#Quantity_" + k).val(),
        Weight: $("#Weight_" + k).val(),
        Cubic: $("#Cubic_" + k).val(),
        ExDate: $("#ExDate_" + k).val(),

    };

    $.post("/WRReceivingLog/AddEditProductoWrReceivedLog",

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

                        $('#ProductName_' + k).prop('disabled', true);
                        $('#Quantity_' + k).prop('disabled', true);
                        $('#Weight_' + k).prop('disabled', true);
                        $('#ExDate_' + k).prop('disabled', true);
                        $('#Cubic_' + k).prop('disabled', true);
                        $('#StockOutQuantity_' + k).prop('disabled', true);
                        $('#DamageQuantity_' + k).prop('disabled', true);
                        $('#StockInQuantity_' + k).prop('disabled', true);
                        $('#PalletInQuantity_' + k).prop('disabled', true);




                    });
                }
                else {
                    $("#save_" + k).hide();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {

                        $("#edit_" + k).show();
                        $("#remove_" + k).show();
                        $('#ProductName_' + k).prop('disabled', true);
                        $('#Quantity_' + k).prop('disabled', true);
                        $('#Weight_' + k).prop('disabled', true);
                        $('#ExDate_' + k).prop('disabled', true);
                        $('#Cubic_' + k).prop('disabled', true);
                        $('#StockOutQuantity_' + k).prop('disabled', true);
                        $('#DamageQuantity_' + k).prop('disabled', true);
                        $('#StockInQuantity_' + k).prop('disabled', true);
                        $('#PalletInQuantity_' + k).prop('disabled', true);
                    });
                }
            }
        });

}
function PostDeleteWrReceivedItem(k, Wrid) {

    var jsonData = {
        WrReceivedId: Wrid,
        id: $("#writem_" + k).val()

    };

    $.post("/WRReceivingLog/DeleteProductWrReceivedLog",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + k + "").remove();

                $('#DeleteModal').modal('hide');
            }
        });

}

function PostDeleteItemChangeProductStatus(k, WrDeliveryid, WRDProductid) {

    var jsonData = {
        WrDeliveryid: WrDeliveryid,
        WRDProductid: WRDProductid

    };

    $.post("/WRDeliveryReq/RemoveProductChangeStatusDeliveryProduct",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + k + "").remove();

                $('#DeleteModal').modal('hide');
            }
        });

}

function PostDeleteWrReceivedLog(Id) {

    var jsonData = {

        WrReceivedId: Id

    };
    $.post("/WRReceivingLog/DeleteWRReceivedLog",
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
function PostDeleteMultipleWrReceivedLog() {
    var selectedIds = [];
    $.each($("input[name='wrreceivinglog']:checked"), function () {
        selectedIds.push($(this).val());
    });

    var jsonData = {
        selectedIds: selectedIds
    };

    $.post("/WRReceivingLog/DeleteSelected",
        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                $('#DeleteModal').modal('hide');
                window.location.reload();
            }
        });

}
function launch_toast() {
    $('#Toast').toast('show');


}
function ValidateExDate(k, orderIdFromForm) {
    var names = $("#ExDate_" + k).val();
    var data = names;
    if (names == "") {
        $(".alert").show();
        setTimeout(function () { $(".alert").hide(); }, 5000);

    }
    else {
        PostAddWrReceivedProduct(k, orderIdFromForm);
    }

    //your code goes here



}
