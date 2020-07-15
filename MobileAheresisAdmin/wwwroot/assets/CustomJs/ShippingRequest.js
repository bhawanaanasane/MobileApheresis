function AddRowsToWRShippingRequestLog(List, shippingRequestIdFromForm)
{

    var mailingListTableData = $("#tblListFieldData").children('thead').children('tr');
    var ProductName = $("#ProductListDropdown option:selected").text();

    mailingListTableData.each(function (i, el)
    {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr.clickable');
        var k = $('#tblListFieldData tr.clickable').length;
        var rowsData = "";
        if (k == 0)
        {
            rowsData = "<tr  id=Row_" + k + " class='clickable' >";
            //rowsData += "<td width='5%' class=\"text-center\"  data-toggle='collapse'  data-target='.row_" + k + "' ><i id='rowicon_" + k + "' class='icon icon-angle-right blue-text s-24  ml-2 handCursor'></i></td>";
            rowsData += "<td width='59 %' id=ProductDiv_" + k + "  class='s-12'><input name='RowId' id=RowId_" + k + " value=" + k + " hidden /><input name='shippingProductId' id=shippingProductId_" + k + "  hidden /><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        else
        {
            //var name = $trs[k - 1].cells[1].children[0].id.toString();
            //var check = $trs[k - 1].cells[1].children[0].id.toString().substring(12);
            k = parseInt($trs[k - 1].cells[0].children[2].id.toString().substring(12)) + 1;
            rowsData = "<tr id=Row_" + k + " class='clickable' >";
            //rowsData += "<td width='5%' class=\"text-center\" data-toggle='collapse'  data-target='.row_" + k + "' ><i id='rowicon_" + k + "' class='icon icon-angle-right blue-text s-24  ml-2 handCursor'></i><input name='RowId' id=RowId_" + k + " value=" + k + " hidden /></td>";
            rowsData += "<td width='59 %' id=ProductDiv_" + k + "  class='s-12'><input name='RowId' id=RowId_" + k + " value=" + k + " hidden /><input name='shippingProductId' id=shippingProductId_" + k + " value=\"0\" hidden /><input name='ProductId' id=ProductName_" + k + " value=" + $("#ProductListDropdown").val() + " hidden />" + ProductName + "</td>";
        }
        rowsData += "<td width='10 %'><input name='OrderQty' id=OrderQty_" + k + "  class=\"form-control form-control-sm s-12 \"></input></td>";
        if (shippingRequestIdFromForm != 0)
        {
            rowsData += "<td width='10 %'></td>";
        }
        if (shippingRequestIdFromForm != 0)
        {
            rowsData += "<td class=\"text-center\" width='15%'> <a onclick='LoadBinDetailsWhenCreate(" + k + ");'><i class='icon-plus s-14 ml-2 text-blue handCursor'></i></a><a onclick='ViewBinDetails(" + k + ","+ shippingRequestIdFromForm +");showloaderfn();'><i class='icon-eye s-14 ml-2 text-blue handCursor'></i></a>";
            rowsData += "<a id = save_" + k + " onclick='PostAddShippingRequestProduct(" + k + "," + shippingRequestIdFromForm + ")'> <i class=\"s-14 icon-save text-blue ml-2 handCursor\"></i></a>";
            rowsData += "<a style='display:none' id='SuccessIcon_" + k + "'><i class='icon-check3 text-green font-weight-bolder ml-2'></i></a>";
            rowsData += " <a id = 'remove_" + k + "' onclick = 'removeProduct(" + k + "," + shippingRequestIdFromForm + ")' > <i class='icon-cancel s-14 text-red ml-2 handCursor'></i></a> ";
        }
        else
        {
            rowsData += "<td  class=\"text-center\" width='15%'> <a onclick='LoadBinDetailsWhenCreate(" + k + ");'><i class='icon-plus s-14 ml-2 text-blue handCursor'></i></a><a onclick='ViewBinDetails(" + k + ",0);showloaderfn();'><i class='icon-eye s-14 ml-2 text-blue handCursor'></i></a>";
            rowsData += "<a id = remove_" + k + "  onclick = 'removeProduct(" + k + ",0)'> <i class=\"s-14 icon-cancel red-text ml-2 handCursor\"></i></a ></td>";
        }
        rowsData += "</tr>";
        $("#divListFieldRows").append(rowsData);
        $("#ExDate_" + k).datetimepicker(
            {
                format: "m/d/Y",
                timepicker: false
            });
        var arrayindex = List.data.findIndex(function (row) {
            return row.value == $("#ProductListDropdown").val();
        });
        var arrayData = List.data[arrayindex];
    });
}

function removeProduct(i, shippingRequestIdFromForm)
{
    var shippingProductId = $("#shippingProductId_" + i).val();
    var jsonData = {
        ShippingRequestId: shippingRequestIdFromForm,
        rowId: i,
        id: $("#shippingProductId_" + i).val()
    };
    if (shippingRequestIdFromForm != 0) {
        if (shippingProductId != 0) {
            $.post("/WRShippingReq/DeleteProductShippingRequest",
                jsonData
                ,
                function (data, status) {
                    if (data.success == true) {

                        $("#Row_" + i + "").remove();

                        $('#DeleteModal').modal('hide');
                    }

                });
        }
        else
        {
            $("#Row_" + i + "").remove();

        }
    }
    else {
        $.post("/WRShippingReq/RemovePickupProductsByBinsTempForCreatePickupandShipping",
            jsonData
            ,
            function (data, status) {
                if (data == "Success") {
                  
                   
                    $("#Row_" + i + "").remove();
                }
            });
    }
}

function ViewBinDetails(RowId, WrShippingRequestProductId ) {
    var url = "/WarehouseTransaction/ViewPickupProductBins";
    var jsonData = {
        ShippingRequestProductId: WrShippingRequestProductId,
        PickupListProductId: 0,
        RowId: RowId,
        ProductId: $("#ProductName_" + RowId).val()
    };
    $("#divBinTableDataView").load(url, jsonData, function (response, status, xhr) {
        var modal = document.getElementById('PickupProductBins');
        modal.style.display = "block";
        //close Loader on loaad partial view
        $("#loader").hide();
    });
}
function LoadBinDetailsWhenCreate(k) {
   
        showloaderfn();
        var url = "/WRShippingReq/ListAvailableBinsProduct";

        var jsonData = {
            productid: $("#ProductName_" + k).val(),
            RowId: k,
            ShippingRequestId: $("#WRShippingRequestId").val(),
            ShippingRequestProductId: $("#WRShippingRequestProductsId_" + k).val(),
            IsFromPickup: false,
            MaxQtyToSelect: 0
        };

        $("#divBinTableDataCreate").load(url, jsonData, function (response, status, xhr) {
            var modal = document.getElementById('ProductStockCreate');
            modal.style.display = "block";

            //close Loader on loaad partial view
            $("#loader").hide();
        });
    
}


function LoadBinDetails(ProductId, RowId, ShippingRequestId, WrShippingRequestProductId) {

        var url = "/WRShippingReq/ListAvailableBinsProduct";
        var jsonData = {
            productid: ProductId,
            RowId: RowId,
            ShippingRequestId: ShippingRequestId,
            ShippingRequestProductId: WrShippingRequestProductId,
            IsFromPickup: false,
            MaxQtyToSelect: 0
        };

        $("#divBinTableData").load(url, jsonData, function (response, status, xhr) {
            var modal = document.getElementById('ProductStock');
            modal.style.display = "block";

            //close Loader on loaad partial view
            $("#loader").hide();
        });
    
}

//function EditRowsToWRReceivingLog(List, orderIdFromForm) {

//    var ProductTableData = $("#tblListFieldData").children('thead').children('tr');

//    ProductTableData.each(function (i, el) {
//        var $tds = $(this).find('th');
//        var $trs = $('#tblListFieldData tr');

//        var k = $('#tblListFieldData tr').length - 1;

//        var rowsData = "";
//        if (k == 0) {
//            rowsData = "<tr id=Row_" + k + " class='clickable' >";
//            rowsData += "";
//            rowsData += "<td id=ProductDiv_" + k + "><select name='ProductId' id=ProductName_" + k + " class='select2'></select></td>";
//        }
//        else {

//            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(12)) + 1;
//            rowsData = "<tr id=Row_" + k + " class='clickable' >";
//            rowsData += "";
//            rowsData += "<td id=ProductDiv_" + k + "></td>";
//        }
//        rowsData += "<td><input name='Quantity' id=Quantity_" + k + " class=\"form-control s-12\" value=\"\"  oninput='CalculateWithQuantity(" + k + ")'/></td>";
//        rowsData += "<td><input name='OrderQty' id=OrderQty_" + k + " class=\"form-control s-12\" value=\"\"/></td>";

//        //rowsData += "<td><input name='ExDate' id=ExDate_" + k + " class=\"date-time-picker form-control s-12\" data-options='{\"timepicker\":false, \"format\":\"d M Y\"}' autocomplete = \"off\" value=\"\"/></td>";
//        rowsData += "<td><a id = save_" + k + " onclick='PostAddShippingRequestProduct(" + k + "," + orderIdFromForm + ")'> <i class=\"s-18 icon-save red-blue\"></i></a ><a  style='display: none' id = remove_" + k + "  onclick='PostDeleteShippingRequestItem(" + k + "," + orderIdFromForm + ")'> <i class=\"s-18 icon-cancel red-text\"></i></a ></td>";

//        rowsData += "</tr>";

//        if (k != 0) {

//            var ddlId = $trs[1].cells[0].children[0].id;
//            var ddl = $("#" + ddlId.toString()).clone();


//            //Set the ID and Name
//            ddl.attr("id", "ProductName_" + k);
//            ddl.attr("name", "ProductId");
//            ddl.attr("disabled", false);
//            $("#divListFieldRows").append(rowsData);
//            $("#ProductDiv_" + k).append(ddl);
//            ddl.select2();
//            $("#ExDate_" + k).datetimepicker(
//                {
//                    format: "d M Y",
//                    timepicker: false
//                });

//        }
//        else {
//            $("#divListFieldRows").append(rowsData);
//            $("#ProductName_0").html("");
//            $("#ProductName_0").append(
//                $('<option></option>').val("0").html("Select Product"));
//            $.each(List.data, function (i, item) {
//                $("#ProductName_0").append(
//                    $('<option></option>').val(item.value).html(item.text + " ( " + item.Column2 + " )"));
//            });

//            $("#ProductName_0").select2();
//            $("#ExDate_0").datetimepicker(
//                {
//                    format: "d M Y",
//                    timepicker: false
//                });
//        }




//        $("#ProductName_" + k + "").change(function () {

//            var arrayindex = List.data.findIndex(function (row) {
//                return row.value == $("#ProductName_" + k + "").val();
//            });
//            var arrayData = List.data[arrayindex];
//            document.getElementById("Quantity_" + k + "").value = "1";
//            document.getElementById("SKU_" + k + "").value = arrayData.Column2;
//            document.getElementById("Weight_" + k + "").value = (Math.round(parseInt(arrayData.Column3) * parseInt(document.getElementById("Quantity_" + k + "").value)), 2).toString();
//            document.getElementById("Cubic_" + k + "").value = (Math.round(parseInt(arrayData.Column4) * parseInt(document.getElementById("Quantity_" + k + "").value)), 2).toString();


//        });



//    });


//}
//function toggleEditFromAdd(i, editMode) {
//    //if (editMode) {

//    //    $('#ProductName_' + i).prop('disabled', true);
//    //    $('#Quantity_'+i).prop('disabled', true);

//    //    $('#save_'+i).css('display', 'none');
//    //    $('#edit_'+i).css('display', 'inline-block');

//    //}

//    //else {
//    $('#ProductName_' + i).prop('disabled', false);
//    $('#Quantity_' + i).prop('disabled', false);

//    $('#save_' + i).css('display', 'inline-block');
//    $('#edit_' + i).css('display', 'none');

//    // }
//}


function PostAddShippingRequestProduct(k, WRid) {

    var jsonData = {

        id: $("#shippingProductId_" + k).val(),
        ShippingRequestId: WRid,
        ProductId: $("#ProductName_" + k).val(),
        OrderQty: $("#OrderQty_" + k).val(),
        Quantity: $("#Quantity_" + k).val()
    };

    $.post("/WRShippingReq/AddEditProductoShippingRequest",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                if (data.message == "Create") {
                   
                    document.getElementById("shippingProductId_" + k).value = data.shippingProductId;
                    var d = document.getElementById("shippingProductId_" + k).value;
                    $("#save_" + k).hide();
                    $("#remove_" + k).show();
                    $("#edit_" + k).show();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {
                        $('#ProductName_' + k).prop('disabled', false);
                        $('#Quantity_' + k).prop('disabled', false);
                        $('#OrderQty_' + k).prop('disabled', false);

                    });
                }
                else {
                    $("#save_" + k).hide();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {

                        $("#edit_" + k).show();
                        $("#remove_" + k).show();
                        $('#ProductName_' + k).prop('disabled', false);
                        $('#Quantity_' + k).prop('disabled', false);
                        $('#OrderQty_' + k).prop('disabled', false);

                    });
                }
            }
        });

}
function PostDeleteShippingRequestItem(k, Wrid) {

    var jsonData = {
        ShippingRequestId: Wrid,
        id: $("#shippingProductId_" + k).val()

    };

    $.post("/WRShippingReq/DeleteProductShippingRequest",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + k + "").remove();

                $('#DeleteModal').remove();
                $('body').removeClass("modal-open");
                $('.modal-backdrop').remove();
            }
        });

}



function CalculateWithQuantity(k) {

    $("#Weight_" + k + "").val(Math.round((parseInt($("#Weight_" + k + "").val()) * parseInt($("#Quantity_" + k + "").val())), 2).toString());
    $("#Cubic_" + k + "").val(Math.round((parseInt($("#Cubic_" + k + "").val()) * parseInt($("#Quantity_" + k + "").val())), 2).toString());


}

//function showShippingProgressReport(id) {

//    var jsonData = {
//        Id: id

//    };

//    $.post("/WRShippingReq/ShowShippingRequestProgress",

//        jsonData
//        ,
//        function (data, status) {
//            document.getElementById("ShippingId").innerHTML = "Progress Report : #" + id;
//            if (data.isCreated == true) {
//                $("#isCreated").removeClass("activity-normal");
//                $("#isCreated").addClass("activity-warning");
//                //span class change
//                $("#createdSpan").removeClass("badge-secondary");
//                $("#createdSpan").addClass("badge-success");
//            }
//            else {
//                $("#isCreated").removeClass("activity-warning");
//                $("#isCreated").addClass("activity-normal");
//                //span class change
//                $("#createdSpan").removeClass("badge-success");
//                $("#createdSpan").addClass("badge-secondary");
//            }

//            if (data.isPickupStarted == true) {
//                $("#isPickupStarted").removeClass("activity-normal");
//                $("#isPickupStarted").addClass("activity-warning");
//                //span class change
//                $("#pickUpStartedSpan").removeClass("badge-secondary");
//                $("#pickUpStartedSpan").addClass("badge-success");

//            }
//            else {
//                $("#isPickupStarted").removeClass("activity-warning");
//                $("#isPickupStarted").addClass("activity-normal");
//                //span class change
//                $("#pickUpStartedSpan").removeClass("badge-success");
//                $("#pickUpStartedSpan").addClass("badge-secondary");
//            }

//            if (data.isPickupDone == true) {
//                $("#isPickupDone").removeClass("activity-normal");
//                $("#isPickupDone").addClass("activity-warning");
//                //span class change
//                $("#pickupDoneSpan").removeClass("badge-secondary");
//                $("#pickupDoneSpan").addClass("badge-success");
//            }
//            else {
//                $("#isPickupDone").removeClass("activity-warning");
//                $("#isPickupDone").addClass("activity-normal");
//                //span class change
//                $("#pickupDoneSpan").removeClass("badge-success");
//                $("#pickupDoneSpan").addClass("badge-secondary");
//            }

//            if (data.isStockedOut == true) {
//                $("#isStockout").removeClass("activity-normal");
//                $("#isStockout").addClass("activity-warning");
//                //span class change
//                $("#stockoutSpan").removeClass("badge-secondary");
//                $("#stockoutSpan").addClass("badge-success");
//            }
//            else {
//                $("#isStockout").removeClass("activity-warning");
//                $("#isStockout").addClass("activity-normal");
//                //span class change
//                $("#stockoutSpan").removeClass("badge-success");
//                $("#stockoutSpan").addClass("badge-secondary");
//            }

//        });

//}
