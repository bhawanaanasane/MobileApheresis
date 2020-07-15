function AddRowsToCargoDetails(rowId) {
 
    var mailingListTableData = $("#tblCargoDetails").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblCargoDetails tr');
        var k = $('#tblCargoDetails tr').length - 1;

        var rowsData = "";

        if (k == 0) {
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ItemDiv_" + k + "  class='s-12'><input name='cargoDetailsId' id=cargoDetailsId_" + k + " value=\"0\" hidden /><input name='ReceiptModel[" + k + "].QTY' id=CargoQTY_" + k + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='ReceiptModel[" + k + "].RowId' id=RowId_" + k + " value=" + rowId+" type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else {

            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(15)) + 1;
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td id=ItemDiv_" + k + "  class='s-12'><input name='cargoDetailsId' id=cargoDetailsId_" + k + "  hidden /><input name='ReceiptModel[" + k + "].QTY' id=CargoQTY_" + k + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='ReceiptModel[" + k + "].RowId' id=RowId_" + k + " type=\"text\" value=" + rowId +" hidden class=\"form-control form-control-sm s-12\"/></td></td>";
        }

        rowsData += "<td><input name='ReceiptModel[" + k +"].CargoTypeVin' id=CargoCargoTypeVin_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].Pieces' id=CargoPieces_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
       // rowsData += "<td><input name='Unit' id=Unit_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].Length' id=CargoLength_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].Width' id=CargoWidth_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].Height' id=CargoHeight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].UnitWeight' id=CargoUnitWeight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].TotalWeight' id=CargoTotalWeight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].Cubic' id=CargoCubic_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ReceiptModel[" + k +"].VolWeight' id=CargoVolWeight_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        //if (orderIdFromForm == 0) {
        //   // rowsData += "<td width='9%' class=\"text-center\"> <a onclick='CargoPopup(" + k + ");showloaderfn();'><i class=\"s-12 icon-plus blue-text  handCursor\"></i></a>";
        //    rowsData += "<td class=\"text-center\"><a id = remove_" + k + "> <i class=\"s-14 icon-cancel ml-2 red-text handCursor\"></i></a ></td>";
        //}
        //else {
        //    rowsData += "<td class=\"text-center\"><a id = save_" + k + " onclick='PostAddQuotationProduct(" + k + ", " + orderIdFromForm + ")'> <i class=\"s-14 ml-2 icon-save text-blue handCursor\"></i></a><a style =\"display: none\" id=SuccessIcon_" + k + " > <i class=\"icon-check3 text-green font-weight-bolder ml-1\"></i></a><a id = remove_" + k + "   onclick='PostDeleteQuotationItem(" + k + "," + orderIdFromForm + ")'> <i class=\"s-14 ml-2 icon-cancel red-text handCursor\"></i></a></td>";

        //}
        rowsData += "</tr>";

        $("#divCargoDetailsRows").append(rowsData);

        $("#remove_" + k + "").click(function () {
            $("#Row_" + k + "").remove();
        });
    });
}

function PostAddQuotationProduct(k, WRid) {

    var jsonData = {

        id: $("#quotItemId_" + k).val(),
        quotationId: WRid,
        ItemName: $("#ItemName_" + k).val(),
        Description: $("#Description_" + k).val(),
        Quantity: $("#QTY_" + k).val(),
        UnitCost: $("#UnitCost_" + k).val(),
        UnitPrice: $("#UnitPrice_" + k).val(),
        TotalPrice: $("#TotalPrice_" + k).val(),
        Profit: $("#Profit_" + k).val(),
        GP: $("#GP_" + k).val()


    };

    $.post("/Quotation/AddEditProductoQuotation",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                if (data.message == "Create") {
                    var quoteitemId = data.quoteItemId;
                    document.getElementById("quotItemId_" + k + "").value = quoteitemId;
                    var ID = $("#quotItemId_" + k).val();
                    $("#save_" + k).hide();
                    $("#remove_" + k).show();
                    $("#edit_" + k).show();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {


                        $('#ItemName_' + k).prop('disabled', true);
                        $('#Description_' + k).prop('disabled', true);
                        $('#QTY_' + k).prop('disabled', true);
                        $('#UnitCost_' + k).prop('disabled', true);
                        $('#UnitPrice_' + k).prop('disabled', true);
                        $('#TotalPrice_' + k).prop('disabled', true);
                        $('#Profit_' + k).prop('disabled', true);
                        $('#GP_' + k).prop('disabled', true);


                    });
                }
                else {
                    $("#save_" + k).hide();
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {

                        $("#edit_" + k).show();
                        $("#remove_" + k).show();
                        $('#ItemName_' + k).prop('disabled', true);
                        $('#Description_' + k).prop('disabled', true);
                        $('#Description_' + k).prop('disabled', true);
                        $('#QTY_' + k).prop('disabled', true);
                        $('#UnitCost_' + k).prop('disabled', true);
                        $('#UnitPrice_' + k).prop('disabled', true);
                        $('#TotalPrice_' + k).prop('disabled', true);
                        $('#Profit_' + k).prop('disabled', true);
                        $('#GP_' + k).prop('disabled', true);

                    });
                }
            }
        });

}

function PostDeleteQuotationItem(k, quoteid) {

    var jsonData = {
        quotationId: quoteid,
        id: $("#quotItemId_" + k).val()

    };

    $.post("/Quotation/DeleteProductQuotation",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + k + "").remove();

                $('#DeleteModal').modal('hide');
            }
        });

}


function PostDeleteQuotation(quoteid) {

    var jsonData = {
        Id: quoteid,


    };

    $.post("/Quotation/DeleteQuotation",

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