function AddPrinterId() {

    var mailingListTableData = $("#tblListFieldData").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr');

        var k = $('#tblListFieldData tr').length - 1;

        var rowsData = "";
        if (k == 0) {
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td class='s-12 text-center'><input name='PId' id='PId_0' value='0' hidden />1</td>";
        }
        else {
            k = parseInt($trs[k].cells[0].children[0].id.toString().substring(4)) + 1;
            rowsData = "<tr id=Row_" + k + ">";
            rowsData += "<td class='s-12 text-center'><input name='PId' id='PId_" + k + "' value='" + k + "' hidden />" + (k + 1) + "</td>";
        }

        rowsData += "<td><input name='PrinterId' id=PrinterId_" + k + " class=\"form-control form-control-sm s-12 \" value=\"\" /></td>";
        rowsData += "<td class='text-center'><a id = remove_" + k + "> <i class=\"s-14 icon-cancel ml-2 red-text handCursor\"></i></a ></td>";
        rowsData += "</tr>";

        $("#divListFieldRows").append(rowsData);

        $("#remove_" + k + "").click(function () {
            $("#Row_" + k + "").remove();
        });
    });
}

function PostDeletePrinterId(a, printerSettingId) {
    var dataid = $("#PId_" + a).val();
    var jsonData = {
        id: dataid,
        printerSettingId: printerSettingId
    };
    $.post("/Printer/DeletePrinterId",
        jsonData,
        function (data, status) {
            if (data.success == true) {
                $("#Row_" + a + "").remove();
                $('#DeleteModal').modal('hide');
            }
        });
}



