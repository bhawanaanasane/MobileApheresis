function AddRowsToProductBarcode(FormId,Append)
{

    var mailingListTableData = $("#ProductBarcodeTable").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#ProductBarcodeTable tr');
        
        var a = $('#ProductBarcodeTable tr').length - 1;

        var rowsData = "";
        if (a == 0)
        {
            rowsData = "<tr id=Row_" + a + ">";

            rowsData += "<td id=ItemDiv_" + a + "  class='s-12'><input name='ProductBarcodeId' id=ProductBarcodeId_" + a + " value=\"0\" hidden /><input name='ProductBarcode' id=ProductBarcode_" + a + " type=\"text\" class=\"form-control form-control-sm s-12\" /><input name='RowId' id=RowId_" + a + " value=" + a + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else
        {

            a = parseInt($trs[a].cells[0].children[0].id.toString().substring(17)) + 1;
            rowsData = "<tr id=Row_" + a + ">";
            rowsData += "<td id=ItemDiv_" + a + " class='s-12'><input name='ProductBarcodeId' id=ProductBarcodeId_" + a + " value=\"0\" hidden /><input name='ProductBarcode' id=ProductBarcode_" + a + " type=\"text\" class=\"form-control form-control-sm s-12\" /><input name='RowId' id=RowId_" + a + " value=" + a + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
            
        }
        if (FormId != 0) {
            rowsData += "<td class=\"text-center\"><a id = save_" + a + " onclick='PostAddProductBarcode(" + a + "," + FormId + ")'> <i class=\"s-12 icon-save text-blue ml-2 handCursor\"></i></a>";
            rowsData += "<a style='display:none' id='SuccessIcon_" + a + "'><i class='icon-check3 text-green font-weight-bolder '></i></a>";
            rowsData += "<a id='remove_" + a + "' data-target='#DeleteModal' data-toggle='modal' onclick='ShowDeleteConfirmationWithResponse('PostDeleteProductBarcode(" + a + ",0)'><i class='icon-cancel text-red ml-2 handCursor'></i></a></td>";
          }
        else {
            rowsData += "<td><a id = remove_" + a + "> <i class='icon-cancel s-14 text-red ml-2 handCursor'></i></a></td>";
}
        rowsData += "</tr>";
        if (Append != false) {
            $("#ProductBarcodeRowsField").append(rowsData);
        }
        Append = false;
        $("#remove_" + a + "").click(function () {
            $("#Row_" + a + "").remove();

        });


    });







}

function PostAddProductBarcode(k, ProductId) {

    var jsonData = {

        ProductBarcodeId: $("#ProductBarcodeId_" + k).val(),
        ProductId: ProductId,
        Tag: $("#ProductBarcode_" + k).val(),
        
    };

    $.post("/Product/AddProducBarcodetoProduct",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                if (data.message == "Create") {
                   
                   
                    document.getElementById("ProductBarcodeId_" + k).value = data.productBarcodeId;
                     
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {

                        $("#remove_" + k).show();
                        $("#save_" + k).hide();


                    });
                }
                
            }
        });

}
function PostDeleteProductBarcode(K, ProductBarcodeId) {
    var productBarcodeId = 0;
    if (ProductBarcodeId != 0) {
        productBarcodeId = ProductBarcodeId;
    }
    else {
        productBarcodeId = $("#ProductBarcodeId_" + k).val();
    }


    var jsonData = {

        id: productBarcodeId

    };
    $.post("/Product/DeleteProductBarcode",
        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                $('#DeleteModal').modal('hide');
                $("#Row_" + K).remove();
            }

        });

}
