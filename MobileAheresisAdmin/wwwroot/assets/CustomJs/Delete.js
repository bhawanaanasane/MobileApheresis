//30/09/19 aakansha
//CompanyProfile
function PostDeleteCompanyProfile(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/CompanyProfile/Delete",
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
//Users

function PostDeleteUser(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/User/Delete",
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
//Bhawana (2/10/2019)
//UserRoles
function PostDeleteUserRole(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/UserRoles/Delete",
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

//PostNurse
function PostDeleteNurse(Id) {
    var jsonData = {

        id: Id

    };

    $.post("/Nurse/Delete", jsonData

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
//PostHospital
function PostDeleteHospital(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/Hospital/Delete",
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



function PostDeleteDaignosis(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/Treatment/DaignosisDelete",
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


function PostDeleteCommentType(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/Treatment/CommentTypeDelete",
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
function PostDeleteAutoText(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/Treatment/AutoTextDelete",
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
function PostDeleteEquipment(Id) {

    var jsonData = {

        id: Id

    };
    $.post("/Equipment/EquipmentDelete",
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




