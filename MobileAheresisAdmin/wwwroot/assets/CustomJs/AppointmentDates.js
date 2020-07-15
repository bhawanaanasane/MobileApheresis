function AddRowsToAppointmentDates(List, pickupListIdFromForm) {

    var mailingListTableData = $("#tblListFieldData").children('thead').children('tr');
   
    mailingListTableData.each(function (i, el) {
        var $tds = $(this).find('th');
        var $trs = $('#tblListFieldData tr.clickable');

        var k = $('#tblListFieldData tr.clickable').length;

        var rowsData = "";
        if (k == 0) {
            rowsData = "<tr  id=Row_" + k + " class='clickable' >";
            rowsData += "<td width='59 %' id=ProductDiv_" + k + "  class='s-12'><input name='RowId' id=RowId_" + k + " value=" + k + " hidden /><input name='AppointmentDatesId' id=AppointmentDatesId_" + k + " value=" + 0 + " hidden /><input name='AppointmentDates' id=AppointmentDates_" + k + " value=" + $("#datetime").val() + " hidden />" + List + "</td>";
        }
        else {

            k = parseInt($trs[k - 1].cells[0].children[1].id.toString().substring(19)) + 1;
            rowsData = "<tr id=Row_" + k + " class='clickable' >";
            rowsData += "<td width='59 %' id=ProductDiv_" + k + "  class='s-12'><input name='RowId' id=RowId_" + k + " value=" + k + " hidden /><input name='AppointmentDatesId' id=AppointmentDatesId_" + k + " value="+ 0 +" hidden /><input name='AppointmentDates' id=AppointmentDates_" + k + " value=" + $("#datetime").val() + " hidden />" + List + "</td>";
        }
        

        if (pickupListIdFromForm != 0)
        {
            rowsData += "<td width='9%' class=\"text-center\"><a id = save_" + k + " onclick='PostAddAppointmentDate(" + k + "," + pickupListIdFromForm + ")'> <i class=\"s-12 icon-save text-blue ml-2 handCursor\"></i></a>";
            rowsData += "<a style='display:none' id='SuccessIcon_" + k + "'><i class='icon-check3 text-green font-weight-bolder '></i></a>";
            rowsData += "<a id='remove_" + k + "' data-target='#DeleteModal' data-toggle='modal' onclick='ShowDeleteConfirmationWithResponse('PostDeleteAppointmentDate(" + k + "," + pickupListIdFromForm + ")')'> <i class='icon-cancel text-red ml-2 handCursor'></i></a></td>";
           }
        else
        {          
            rowsData += "<td width='9%' class=\"text-center\"><a id = remove_" + k + "> <i class='icon-cancel s-14 text-red ml-2 handCursor'></i></a></td>";
        }

        rowsData += "</tr>";
        $("#divListFieldRows").append(rowsData);

        $("#remove_" + k + "").click(function () {
            $("#Row_" + k + "").remove();

        });

      

    });
}

function PostAddAppointmentDate(k, appointmentId) {

    var jsonData = {

        AppointmentDate: $("#AppointmentDates_" + k).val(),
        AppointmentMasterId: appointmentId
        
    };

    $.post("/Appointment/PostAddAppointmentDates",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {
                if (data.message == "Create") {
                    document.getElementById("AppointmentDatesId_" + k).value = data.appointmentDateId;
                    $("#save_" + k).hide();
                    $("#remove_" + k).show();                   
                    $("#SuccessIcon_" + k).show();
                    $("#SuccessIcon_" + k).fadeOut(3000, function () {
                        


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
                        $('#PickedQty_' + k).prop('disabled', false);
                        $('#OrderQty_' + k).prop('disabled', true);

                    });
                }
            }
            else {
                alert("Please add order qty.");
            }
        });

}



function PostDeleteAppointmentDate(k, appointmentId) {

    var jsonData = {
        AppointmentId: appointmentId,
        id: $("#AppointmentDatesId_" + k).val()

    };

    $.post("/Appointment/AppointmentDateDelete",

        jsonData
        ,
        function (data, status) {
            if (data.success == true) {

                $("#Row_" + k + "").remove();
                $('#DeleteModal').modal('hide');
            }
        });

}

function PostCancelAppointment(AppointmentDateiD,AppointmentId) {
  
    var jsonData = {
        AppointmentMasterId: AppointmentId,
        //CancelDate: $("AppointmentDate_" + k)
        Id: AppointmentDateiD

    };

    $.post("/Appointment/CancelAppointment",

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
