function AddRowsToWarehouseDetails(orderIdFromForm) {

    var mailingListTableData = $("#tblListFieldData").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr');

        var k = $('#tblListFieldData tr').length - 1;

        var rowsData = "";
        if (k == 0) {
            rowsData = "<tr id=Row_" + k + ">";

            rowsData += "<td id=ItemDiv_" + k + "  class='s-12'><input name='warehouseDetailsId' id=warehouseDetailsId_" + k + " value=\"0\" hidden /><input name='QTY' id=QTY_" + k + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='RowId' id=RowId_" + k + " value="+k+" type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else {

            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(19)) + 1;
            rowsData = "<tr id=Row_" + k + ">";

            rowsData += "<td id=ItemDiv_" + k + "  class='s-12'><input name='warehouseDetailsId' id=warehouseDetailsId_" + k + " hidden /><input name='QTY' id=QTY_" + k + " type=\"text\" class=\"form-control form-control-sm s-12\" /><input name='RowId' id=RowId_" + k + " value=" + k +"  type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }

        rowsData += "<td><input name='CargoTypeVinId' id=CargoTypeVinId_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" hidden/><input name='CargoTypeVin' id=CargoTypeVin_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='Pieces' id=Pieces_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Unit' id=Unit_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Length' id=Length_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='Width' id=Width_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Height' id=Height_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Weight' id=Weight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Cubic' id=Cubic_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='VolWeight' id=VolWeight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/>      <input name='OverallDimension' id=OverallDimension_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" hidden/></td>";

        if (orderIdFromForm == 0) {
            //rowsData += "<td width='9%' class=\"text-center\"> <a onclick='CargoPopup(" + k + ");showloaderfn();'><i class=\"s-12 icon-plus blue-text  handCursor\"></i></a>";
            rowsData += "<td><a id = remove_" + k + "> <i class=\"s-14 icon-cancel ml-2 red-text handCursor\"></i></a ></td>";
        }
        else {
            rowsData += "<td class=\"text-center\"><a id = save_" + k + " onclick='PostAddEditWarehouseDetails(" + k + ", " + orderIdFromForm + ")'> <i class=\"s-14 ml-2 icon-save text-blue handCursor\"></i></a><a style =\"display: none\" id=SuccessIcon_" + k + " > <i class=\"icon-check3 text-green font-weight-bolder ml-1\"></i></a><a id = remove_" + k + "   onclick='PostDeleteWarehouseDetails(" + k + ", " + orderIdFromForm + ")'> <i class=\"s-14 ml-2 icon-cancel red-text handCursor\"></i></a></td>";

        }
        rowsData += "</tr>";




        $("#divListFieldRows").append(rowsData);

        $("#remove_" + k + "").click(function () {
            $("#Row_" + k + "").remove();

        });
      

    });







}
function CargoPopup(k) {

    var url = "/WarehouseReceipt/CreateCargoDetails";
    var jsonData = {
        id: 0,
        RowId: k,
        warehouseDetailsId: $("#warehouseDetailsId_" + k).val()
                   };

    $("#divBinTableData").load(url, jsonData, function (response, status, xhr) {
        var modal = document.getElementById('ProductStockCreate');
        modal.style.display = "block";

        //close Loader on loaad partial view
        $("#loader").hide();


    });

    //close bin details
    $("#importclose").click(function () {
        var modal = document.getElementById('ImageList');
        modal.style.display = "none";
    });

}
function PostAddEditWarehouseDetails(k, WRid) {

    var jsonData = {

        id: $("#warehouseDetailsId_" + k).val(),
        warehouseReceiptId: WRid,
        RowId: k,
        Qty: $("#QTY_" + k).val(),
        OverallDimension: $("#OverallDimension_"+k).val(),
        CargoTypeId: $("#CargoTypeVinId_" + k).val(),
        Pieces: $("#Pieces_" + k).val(),
        Length: $("#Length_" + k).val(),
        Width: $("#Width_" + k).val(),
        Height: $("#Height_" + k).val(),
        UnitWeight: $("#Unit_" + k).val(),
        TotalWeight: $("#Weight_" + k).val(),
        CubicFeet: $("#Cubic_" + k).val(),
        VolWeight: $("#VolWeight_" + k).val(),
     
    };

    $.post("/WarehouseReceipt/AddEditWarehouseDetails",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                if (data.message == "Create") {

                    document.getElementById("warehouseDetailsId_" + k).value = data.warehouseDetailsId;
                    var d = document.getElementById("warehouseDetailsId_" + k).value;
                    $("#save_" + k).hide();
                    $("#remove_" + k).show();
                    $("#edit_" + k).show();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {
                        $("#edit_" + k).show();
                        

                    });
                }
                else {
                    $("#save_" + k).hide();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {

                        $("#edit_" + k).show();
                        $("#remove_" + k).show();
                       
                    });
                }
            }
        });

}

function PostDeleteWarehouseDetails(k,warehouseRId) {

    var jsonData = {
        
        id: $("#warehouseDetailsId_" + k).val(),
        warehouseReceiptId : warehouseRId

    };

    $.post("/WarehouseReceipt/DeleteWarehouseDetails",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + k + "").remove();

                $('#DeleteModal').modal('hide');
            }
        });

}
function UnitCostInputChange(k) {
    $("#UnitCost_" + k + "").on('input', function () {

        document.getElementById("UnitPrice_" + k + "").value = ((parseFloat(document.getElementById("UnitCost_" + k + "").value) / (1 - (parseInt(document.getElementById("GP_" + k + "").value) / 100)))).toFixed(2).toString();
        document.getElementById("TotalPrice_" + k + "").value = ((parseFloat(document.getElementById("UnitPrice_" + k + "").value) * parseInt(document.getElementById("QTY_" + k + "").value))).toFixed(2).toString();
        var unitcost = document.getElementById("UnitCost_" + k + "").value;
        var unitprice = document.getElementById("UnitPrice_" + k + "").value;
        document.getElementById("Profit_" + k + "").value = (((parseFloat(unitprice) - parseInt(unitcost)) * parseInt(document.getElementById("QTY_" + k + "").value))).toFixed(2).toString();

    });
}
function QtyInputChange(k) {
    $("#QTY_" + k + "").on('input', function () {

        document.getElementById("UnitPrice_" + k + "").value = ((parseFloat(document.getElementById("UnitCost_" + k + "").value) / (1 - (parseInt(document.getElementById("GP_" + k + "").value) / 100)))).toFixed(2).toString();
        document.getElementById("TotalPrice_" + k + "").value = ((parseFloat(document.getElementById("UnitPrice_" + k + "").value) * parseInt(document.getElementById("QTY_" + k + "").value))).toFixed(2).toString();
        var unitcost = document.getElementById("UnitCost_" + k + "").value;
        var unitprice = document.getElementById("UnitPrice_" + k + "").value;
        document.getElementById("Profit_" + k + "").value = (((parseFloat(unitprice) - parseInt(unitcost)) * parseInt(document.getElementById("QTY_" + k + "").value))).toFixed(2).toString();

    });
}
function GPInputChange(k) {
    $("#GP_" + k + "").on('input', function () {

        document.getElementById("UnitPrice_" + k + "").value = ((parseFloat(document.getElementById("UnitCost_" + k + "").value) / (1 - (parseInt(document.getElementById("GP_" + k + "").value) / 100)))).toFixed(2).toString();
        document.getElementById("TotalPrice_" + k + "").value = ((parseFloat(document.getElementById("UnitPrice_" + k + "").value) * parseInt(document.getElementById("QTY_" + k + "").value))).toFixed(2).toString();
        var unitcost = document.getElementById("UnitCost_" + k + "").value;
        var unitprice = document.getElementById("UnitPrice_" + k + "").value;
        document.getElementById("Profit_" + k + "").value = (((parseFloat(unitprice) - parseInt(unitcost)) * parseInt(document.getElementById("QTY_" + k + "").value))).toFixed(2).toString();

    });
}




function PostDeleteWarehouseReceipt(Id) {

    var jsonData = {

        WarehouseReceiptId: Id

    };
    $.post("/WarehouseReceipt/DeleteWarehouseReceipt",
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