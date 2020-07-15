//Product
function AddRowsToBinsTable(data) {
    var OrderQuantity = 0;
    var rowsData = '<tr id="row_' + data[0].rowId + '" class="collapse row_' + data[0].rowId + '"><td></td><td colspan="4">';
    rowsData += '<table class="">';

    var i;

    rowsData += "<thead class='bg-light text-black'><tr><th>Sr No.</th><th>Bin Code</th><th>Lot No</th><th>Pallet Tag</th><th>Received Date</th><th>Expiry Date</th><th>Order Qty</th><th></th></tr></thead>";
    for (i = 0; i < data.length; i++) {
        rowsData += '<tr  id=Rowchild' + data[0].rowId + '_' + i + '  ><td class=\"s-12\">' + i + 1 + '</td><td class=\"s-12\">' + data[i].binCode + ' </td><td class=\"s-12\">' + data[i].lotNo + ' </td><td class=\"s-12\">' + data[i].palletTag + ' </td><td class=\"s-12\">' + data[i].receivedDate + ' </td><td class=\"s-12\">' + data[i].exDate + '</td><td class=\"s-12\">' + data[i].orderQty + ' </td><td class=\"s-12 text-center\"><a onclick=\"removeBin(' + data[i].rowId + ',' + i + ') \" id =removechild' + data[0].rowId + '_' + i + '> <i class=\"s-14 icon-cancel red-text\"></i></a><input type=\"hidden\" id=binid' + data[0].rowId + '_' + i + ' /></td></tr>';

        OrderQuantity += data[i].orderQty;
      }
   
    //var rowicon = document.getElementById("rowicon_" + data[0].rowId + "");
    //rowicon.style.display = "block";
    rowsData += '</table ></td></tr >';

    if ($('#row_' + data[0].rowId) != null) {
        $('#row_' + data[0].rowId).remove();
    }


    $('#Row_' + data[0].rowId).after(rowsData);

    return OrderQuantity;
}

//Product
function AddRowsToBinsTableAfterReset(data) {

    debugger
    var OrderQuantity = 0;
    var rowsData = '';
  //  rowsData += '<table class="">';

   var i;

   // rowsData += "<thead class='bg-light text-black'><tr><th>Sr No.</th><th>Bin Code</th><th>Lot No</th><th>Pallet Tag</th><th>Received Date</th><th>Expiry Date</th><th>Order Qty</th><th></th></tr></thead>";
    for (i = 0; i < data.length; i++) {
        rowsData += '<tr  id=Rowchild' + data[0].rowId + '_' + i + '  ><td class=\"s-12\">' + i + 1 + '</td><td class=\"s-12\">' + data[i].binCode + ' </td><td class=\"s-12\">' + data[i].lotNo + ' </td><td class=\"s-12\">' + data[i].palletTag + ' </td><td class=\"s-12\">' + data[i].receivedDate + ' </td><td class=\"s-12\">' + data[i].exDate + '</td><td class=\"s-12\">' + data[i].orderQty + ' </td><td class=\"s-12 text-center\"><a onclick=\"removeBin(' + data[i].rowId + ',' + i + ') \" id =removechild' + data[0].rowId + '_' + i + '> <i class=\"s-14 icon-cancel red-text\"></i></a><input type=\"hidden\" id=binid' + data[0].rowId + '_' + i + ' /></td></tr>';

        OrderQuantity += data[i].orderQty;
    }

    //var rowicon = document.getElementById("rowicon_" + data[0].rowId + "");
    //rowicon.style.display = "block";
    rowsData += '';


    $('#Row_' + data[0].rowId).after(rowsData);

    return OrderQuantity;
}

function removeBin(rowId, i) {
    var jsonData = {

        WRreceivingProductId: $("#wrreceivingProductId_" + i).val(),
        stockInPalletId: $("#stockInPallet_"  + i).val(),
        wrreceivingProduct_Id: $("#wrreceivingProduct_Id_"+ i).val()
    };

    $.post("/WarehouseTransaction/RemovePickupProductsByBinsTempForCreatePickup",

        jsonData
        ,
        function (data, status) {
            $("#Rowchild" + rowId + "_" + i).remove();

            //$('#DeleteModal').modal('hide');
            var j = 0;
            var PickuQuantity = 0;
            if (data.length != 0) {
                for (j = 0; data.length > j; j++) {
                    PickuQuantity += data.pickupQty;
                }
                var modal = document.getElementById('ProductStock');
                modal.style.display = "none";

                document.getElementById("QTY_" + rowId + "").value = PickuQuantity;
            }
            else {
                document.getElementById("QTY_" + rowId + "").value = PickuQuantity;
                $("#row_" + rowId + "").remove();
                $("#rowicon_" + rowId + "").hide();
            }

        });

}

function PostDeleteBin(i, j, productBinId) {

    var jsonData = {
        ProductBinsId: productBinId
        //shippingProductreqId: $("#writem_"+ i + "").val()

    };

    $.post("/WarehouseTransaction/DeletePickUpProductBins",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Rowchild_" + i + j + "").remove();

                $('#DeleteModal').modal('hide');
                var PickuQuantity = 0;
                if (data.totalPickUpQty != 0) {
                    PickuQuantity = data.totalPickUpQty;
                    var modal = document.getElementById('ProductStock');
                    modal.style.display = "none";

                    document.getElementById("QTY_" + i + "").value = PickuQuantity;
                }
                else {
                    document.getElementById("QTY_" + i + "").value = PickuQuantity;
                    $("#row_" + i + "").remove();
                    $("#rowicon_" + i + "").hide();
                }


            }
        });

}