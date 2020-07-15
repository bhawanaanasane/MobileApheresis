function AddRowsToInvoiceItems(orderIdFromForm) {

    var mailingListTableData = $("#InvoiceTable").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#InvoiceTable tr');

        var a = $('#InvoiceTable tr').length - 1;

        var rowsData = "";
        if (a == 0) {
            rowsData = "<tr id=Row_" + a + ">";

            rowsData += "<td id=ItemDiv_" + a + "  class='s-12'><input name='InvoiceItemId' id=InvoiceItemId_" + a + " value=\"0\" hidden /><input asp-for='@Model.invoiceItemsList.Description' name='InvoiceDescription' id=InvoiceDescription_" + a + " type=\"text\" class=\"form-control form-control-sm s-12\" readonly/><input name='RowId' id=RowId_" + a + " value=" + a + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else {

            a = parseInt($trs[a].cells[0].children[0].id.toString().substring(14)) + 1;
            rowsData = "<tr id=Row_" + a + ">";

            rowsData += "<td id=ItemDiv_" + a + "  class='s-12'><input name='InvoiceItemId' id=InvoiceItemId_" + a + " hidden /><input name='InvoiceDescription' asp-for='@Model.invoiceItemsList.Description' id=InvoiceDescription_" + a + " type=\"text\" class=\"form-control form-control-sm s-12\" readonly/><input name='RowId' id=RowId_" + a + " value=" + a + "  type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }

        rowsData += "<td><input asp-for='@Model.invoiceItemsList.Qty' name='QTY' id=QTY_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\" readonly/></td>";
        rowsData += "<td><input asp-for='@Model.invoiceItemsList.Rate' name='Rate' id=Rate_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\" readonly/></td>";
        rowsData += "<td><input asp-for='@Model.invoiceItemsList.Amount' name='Amount' id=Amount_" + a + " class=\"form-control form-control-sm s-12 \" value=\"\" readonly/></td>";
         
        rowsData += "</tr>";




        $("#InvoiceFielsList").append(rowsData);

        $("#remove_" + a + "").click(function () {
            $("#Row_" + a + "").remove();

        });


    });







}

function AddRowsToInventoryReportByLocationItems() {

    var mailingListTableData = $("#InvontaryReportTable").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#InvontaryReportTable tr');

        var b = $('#InvontaryReportTable tr').length - 1;

        var rowsData = "";
        if (b == 0) {
            rowsData = "<tr id=Row_" + b + ">";

            rowsData += "<td id=ItemDiv_" + b + "  class='s-12'><input name='InventoryReportByLocationItemId' id=InventoryReportByLocationItemId_" + b + " value=\"0\" hidden /><input name='Status' id=Status_" + b+ " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='RowId' id=RowId_" + b + " value=" + b + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else {

            b = parseInt($trs[b].cells[0].children[0].id.toString().substring(32)) + 1;
            rowsData = "<tr id=Row_" + b + ">";

            rowsData += "<td id=ItemDiv_" + b + "  class='s-12'><input name='InventoryReportByLocationItemId' id=InventoryReportByLocationItemId_" + b + " value=\"0\" hidden /><input name='Status' id=Status_" + b + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='RowId' id=RowId_" + b + " value=" + b + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }

        rowsData += "<td><input name='Customer' id=Customer_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='WHId' id=WHId_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='LOCID' id=LOCID_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='BinCode' id=BinCode_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='Item' id=Item_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Description' id=Description_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='ExDate' id=ExDate_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='RcvDate' id=RcvDate_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Weight' id=Weight_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Cubic' id=Cubic_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Rcvd' id=Rcvd_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='Comm' id=Comm_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        rowsData += "<td><input name='Available' id=Available_" + b + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";

        rowsData += "</tr>";




        $("#InventoryReportRowFields").append(rowsData);

        $("#remove_" + b + "").click(function () {
            $("#Row_" + b + "").remove();

        });


    });







}



function AddRowsToAverageCubic() {

    var mailingListTableData = $("#AveragecubicTable").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#AveragecubicTable tr');

        var c = $('#AveragecubicTable tr').length - 1;

        var rowsData = "";
        if (c == 0) {
            rowsData = "<tr id=Row_" + c + ">";

            rowsData += "<td id=ItemDiv_" + c + "  class='s-12'><input name='AverageCubicId' id=AverageCubicId_" + c + " value=\"0\" hidden /><input name='Date' id=Date_" + c + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='RowId' id=RowId_" + c + " value=" + c + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else {

            c = parseInt($trs[c].cells[0].children[0].id.toString().substring(15)) + 1;
            rowsData = "<tr id=Row_" + c + ">";

            rowsData += "<td id=ItemDiv_" + c + "  class='s-12'><input name='AverageCubicId' id=AverageCubicId_" + c + " value=\"0\" hidden /><input name='Date' id=Date_" + c + " type=\"text\" class=\"form-control form-control-sm s-12\"/><input name='RowId' id=RowId_" + c + " value=" + c + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }

        rowsData += "<td><input name='Cubic' id=Cubic_" + c + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td><input name='Average' id=Average_" + c + " class=\"form-control form-control-sm s-12 \" value=\"\"/></td>";
        
        rowsData += "</tr>";




        $("#AverageCubicRowFields").append(rowsData);

        $("#remove_" + c + "").click(function () {
            $("#Row_" + c + "").remove();

        });


    });







}

