


function GetDrropDownByReportType() {
    var reprtType = $("#Report").val();

    if (reprtType == "By Nurse") {
        // show time div, hide fromTo div
        $('#StartDate').hide();
        $('#EndDate').hide();
        $('#Patient').hide();
        $('#Nurse').show();
        $('#Diagnosis').hide();
        $('#MR').hide();
        $('#Procedure').hide();
        $('#Hospital').hide();
        $('#Machine').hide();
    }
    else if (reprtType == "By Hospital") {
        // show time div, hide fromTo div
        $('#StartDate').hide();
        $('#EndDate').hide();
        $('#Patient').hide();
        $('#Nurse').hide();
        $('#Diagnosis').hide();
        $('#MR').hide();
        $('#Procedure').hide();
        $('#Hospital').show();
        $('#Machine').hide();
    }
    else if (reprtType == "By Diagnosis") {
        // show time div, hide fromTo div
        $('#StartDate').hide();
        $('#EndDate').hide();
        $('#Patient').hide();
        $('#Nurse').hide();
        $('#Diagnosis').show();
        $('#MR').hide();
        $('#Procedure').hide();
        $('#Hospital').hide();
        $('#Machine').hide();
    }
    else if (reprtType == "By Patient") {
        // show time div, hide fromTo div
        $('#StartDate').hide();
        $('#EndDate').hide();
        $('#Patient').show();
        $('#Nurse').hide();
        $('#Diagnosis').hide();
        $('#MR').hide();
        $('#Procedure').hide();
        $('#Hospital').hide();
        $('#Machine').hide();
    }
    else if (reprtType == "All") {
        // show time div, hide fromTo div
        $('#StartDate').show();
        $('#EndDate').show();
        $('#Patient').show();
        $('#Nurse').show();
        $('#Diagnosis').show();
        $('#MR').show();
        $('#Procedure').show();
        $('#Hospital').show();
        $('#Machine').show();
    }
    else if (reprtType == "By Procedure") {
        // show time div, hide fromTo div
        $('#StartDate').hide();
        $('#EndDate').hide();
        $('#Patient').hide();
        $('#Nurse').hide();
        $('#Diagnosis').hide();
        $('#MR').hide();
        $('#Procedure').show();
        $('#Hospital').hide();
        $('#Machine').hide();
    }
    else if (reprtType == "Machine QA") {
        // show time div, hide fromTo div
        $('#StartDate').hide();
        $('#EndDate').hide();
        $('#Patient').hide();
        $('#Nurse').show();
        $('#Diagnosis').hide();
        $('#MR').hide();
        $('#Procedure').hide();
        $('#Hospital').hide();
        $('#Machine').hide();
    }
    else if (reprtType == "By Date") {
        // show time div, hide fromTo div
        $('#StartDate').show();
        $('#EndDate').show();
        $('#Patient').hide();
        $('#Nurse').hide();
        $('#Diagnosis').hide();
        $('#MR').hide();
        $('#Procedure').hide();
        $('#Hospital').hide();
        $('#Machine').hide();
    }
}

function PostDataToReport() {

    var reprttype = $("#Report").val();




    $.post("/TreatmentRecord/Report",
        {
            StartDate: $("#Startdatetime").val(),
            EndDate: $("#Enddatetime").val(),
            HospitalId: $("#HospitalName").val(),
            PatientId: $("#PatientName").val(),
            NurseId: $("#NurseName").val(),
            ProcedureId: $("#ProcedureName").val(),
            DiagnosisId: $("#DiagnosisName").val(),
            ReportType: $("#Report").val(),


        });

         location.href = "/TreatmentRecord/Report"
   
            if (reprttype == "By Patient") {
                PatientList: $("#PatientName").val(),
                $("#tabs").tabs($('w3--tab1').show());


            }
            else if (reprttype == "HospitalName") {
                $("#tabs").tabs($('w3--tab2').show());
            }


  


}


      










//function PostDataToReport() {
//    $("#loader").show();
//    var reprttype = $("#Report").val();

   

   
//    //$.post("/TreatmentRecord/Report",
//    //    {
//    //        StartDate: $("#Startdatetime").val(),
//    //        EndDate: $("#Enddatetime").val(),
//    //        HospitalId: $("#HospitalName").val(),
//    //        PatientId: $("#PatientName").val(),
//    //        NurseId: $("#NurseName").val(),
//    //        ProcedureId: $("#ProcedureName").val(),
//    //        DiagnosisId: $("#DiagnosisName").val(),
//    //        ReportType: $("#Report").val(),
           
           
//    //    }
        
//    //);
//    $.ajax({
//        type: "POST",
//        url: "/TreatmentRecord/ViewReport",
       
        
//        success: function (data) {
         
//            var url = "/TreatmentRecord/Report";
         
//            $("#ProfileLoad").load(url,{ StartDate: $("#Startdatetime").val(),
//                EndDate: $("#Enddatetime").val(),
//                HospitalId: $("#HospitalName").val(),
//                PatientId: $("#PatientName").val(),
//                NurseId: $("#NurseName").val(),
//                ProcedureId: $("#ProcedureName").val(),
//                DiagnosisId: $("#DiagnosisName").val(),
//                ReportType: $("#Report").val(),
//            }, function (data,response, status, xhr) {
//                    $("#loader").hide();
//                    if (reprttype == "By Patient") {
//                        location.href = "/TreatmentRecord/Report"
//                        loadData(data);
//                        $("tabs").show();

//                    }
//                    else if (reprttype == "HospitalName") {
//                        $("#tabs").tabs($('w3--tab2').show());
//                    }
//            });
          

//        }
        
//    });
   
//    //location.href = ""
   
   
    
   

    

//}









//$(function () {
//    $("#tabs").tabs();
//});

//function goto() {
//    //method: "POST",
//    //document.location.href = '/TreatmentRecord/Report';
//    var url = "/TreatmentRecord/Report?HospitalId=" + Id + "&NurseId=" + NurseId + "&PatientId=" + PatientId + "&ProcedureId=" + ProcedureId + "&DiagnosisId=" + DiagnosisId + "&ReportType=" + ReportType + "&StartDate=" + StartDate + "&EndDate=" + EndDate;
//    $("#tabs").tabs("By Patient", $('w3--tab1')).load(url, function (response, status, xhr)


//    {
//        $("#loader").hide();
//    });
//}
//    $("#tabs").tabs("By Patient", $('w3--tab1').show());
//    $("#tabs").tabs("By Hospital", $('w3--tab2').show());

//}

