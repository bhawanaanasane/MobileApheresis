function AddRowsToSegrigationCharges() {

    var mailingListTableData = $("#SegrigationTable").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#SegrigationTable tr');

        var a = $('#SegrigationTable tr').length - 1;

        var rowsData = "";
        if (a == 0) {
            rowsData = "<tr id=Row_" + a + ">";

            rowsData += "<td id=ItemDiv_" + a + "  class='s-12'><input name='SO' id=SO_" + a + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='RowId' id=RowId_" + a + " value=" + a + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else {

            a = parseInt($trs[a].cells[0].children[0].id.toString().substring(3)) + 1;
            rowsData = "<tr id=Row_" + a + ">";

            rowsData += "<td id=ItemDiv_" + a + "  class='s-12'><input name='SO' id=SO_" + a + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='RowId' id=RowId_" + a + " value=" + a + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }

        rowsData += "<td><input name='DO' id=DO_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='Consignee' id=Consignee_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Product' id=Product_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Unit' id=Unit_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='SegFees' id=SegFees_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";

        rowsData += "</tr>";




        $("#SegrigationChargesRows").append(rowsData);

        $("#remove_" + a + "").click(function () {
            $("#Row_" + a + "").remove();

        });


    });







}

function PostAddEditWarehouseCharges(a, WRid) {

    var jsonData = {

        id: $("#warehouseChargesId_" + a).val(),
        warehouseReceiptId: WRid,
        BillingCode: $("#BillingCode_" + a).val(),

        Description: $("#Description_" + a).val(),
        BillType: $("#BillType_" + a).val(),
        BillTo: $("#BillTo_" + a).val(),
        Qty: $("#ChargesQty_" + a).val(),
        Rate: $("#Rate_" + a).val(),
        Amount: $("#Amount_" + a).val(),
        Currency: $("#Currency_" + a).val(),
        Cost: $("#Cost_" + a).val()


    };

    $.post("/WarehouseReceipt/AddEditWarehouseCharges",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                if (data.message == "Create") {
                    var warehousechargesId = data.warehouseChargesId;
                    document.getElementById("warehouseChargesId_" + a + "").value = warehousechargesId;
                    var ID = $("#warehouseChargesId_" + a).val();
                    $("#saves_" + a).hide();
                    $("#removes_" + a).show();
                    $("#edits_" + a).show();
                    $("#SuccessIcons_" + a).show();
                    $("#SuccessIcons_" + a).fadeOut(3000, function () {
                        $("#BillingCode_" + a).prop('disabled', true);

                        $("#Description_" + a).prop('disabled', true);
                        $("#BillType_" + a).prop('disabled', true);
                        $("#BillTo_" + a).prop('disabled', true);
                        $("#ChargesQty_" + a).prop('disabled', true);
                        $("#Rate_" + a).prop('disabled', true);
                        $("#Amount_" + a).prop('disabled', true);
                        $("#Currency_" + a).prop('disabled', true);
                        $("#Cost_" + a).prop('disabled', true);

                    });
                }
                else {
                    $("#saves_" + a).hide();

                    $("#SuccessIcons_" + a).fadeOut(3000, function () {

                        $("#edits_" + a).show();
                        $("#removes_" + a).show();
                        $("#BillingCode_" + a).prop('disabled', true);

                        $("#Description_" + a).prop('disabled', true);
                        $("#BillType_" + a).prop('disabled', true);
                        $("#BillTo_" + a).prop('disabled', true);
                        $("#ChargesQty_" + a).prop('disabled', true);
                        $("#Rate_" + a).prop('disabled', true);
                        $("#Amount_" + a).prop('disabled', true);
                        $("#Currency_" + a).prop('disabled', true);
                        $("#Cost_" + a).prop('disabled', true);

                    });
                }
            }
        });

}



function PostDeleteWarehouseCharges(a, warehouseReceiptId) {
    var dataid = $("#warehouseChargesId_" + a).val();
    var jsonData = {

        id: $("#warehouseChargesId_" + a).val(),
        warehouseReceiptId: warehouseReceiptId

    };

    $.post("/WarehouseReceipt/DeleteWarehouseCharges",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + a + "").remove();

                $('#DeleteModal').modal('hide');
            }
        });

}

