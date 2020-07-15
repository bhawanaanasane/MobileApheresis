function AddRowsToCartonList() {

    var mailingListTableData = $("#CartonTable").children('thead').children('tr');

    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#CartonTable tr');

        var a = $('#CartonTable tr').length - 1;

        var rowsData = "";
        if (a == 0) {
            rowsData = "<tr id=Row_" + a + ">";

            rowsData += "<td id=ItemDiv_" + a + "  class='s-12'><input type ='checkbox' id =SelectCarton_" + a + "  class='ml-2' /><input name='RowId' id=RowId_" + a + " value=" + a + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        else {

            a = parseInt($trs[a].cells[0].children[0].id.toString().substring(13)) + 1;
            rowsData = "<tr id=Row_" + a + ">";

            rowsData += "<td id=ItemDiv_" + a + "  class='s-12'><input type ='checkbox' id =SelectCarton_" + a + "  class='ml-2' /><input name='RowId' id=RowId_" + a + " value=" + a + " type=\"text\" hidden class=\"form-control form-control-sm s-12\"/></td>";
        }
        rowsData += "<td><label name = 'SrNo' id = SrNo_" + a + " type =\"text\" class=\"form-control form-control-sm s-12\">"+(a+1)+"</label></td>";
        rowsData += "<td><select name='Products' id=Products_" + a + "  multiple='multiple' class='select2'></select></td>";

        rowsData += "</tr>";




        $("#CartonRowFields").append(rowsData);

        $("#remove_" + a + "").click(function () {
            $("#Row_" + a + "").remove();

        });


    });

}
