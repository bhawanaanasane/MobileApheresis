using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Utils
{
    public static class NotificationMessage
    {
        public static string TitleSuccess = "Success";
        public static string TypeSuccess = "success";

        public static string TitleError = "Error";
        public static string TypeError = "error";


        public static string Titlewarning = "Warning";
        public static string Typewarning = "warning";
        //Error Msg
        public static string ErrorMsg = "There is something wrong.Please try again.";

        //TreatmentRecord
        public static string msgAddTreatmentRecord = "The new TreatmentRecord has been added successfully.";

        //Genral

        public static string msgAddGenral = "The new Genral info has been added successfully.";
        public static string msgEditGenral = "The new Genral info has been eddited successfully.";
        // PolicyandProcedure
        public static string msgAddPolicyandProcedure = "The new PolicyandProcedure info has been added successfully.";
        public static string msgEditPolicyandProcedure = "The new PolicyandProcedure info has been eddited successfully.";

        //UserRole
        public static string msgDeleteUserRole = "The user role has been deleted successfully.";
        public static string ErrormsgDeleteUserRole = "User Role is in use";
        //User
        public static string msgAddUser = "The new user has been added successfully.";
      
        public static string msgEditUser = "The user info has been edited successfully.";
       
        public static string UserAlreadyRegistered = "User is already registered.";
        public static string msgUserDeleted = "User has been deleted successfully.";
        public static string ErrormsgUserDeleted = "User is in use.";
        //Customer
        public static string msgAddCustomer = "The new customer has been added successfully.";
       
        public static string msgEditCustomer = "The customer info has been edited successfully.";
       
        public static string Emailisalreadyregistered = "Email is already registered.";
        public static string CustomerAlreadyRegistered = "Customer is already registered.";
        public static string msgCustomerDeleted = "Customer has been deleted successfully.";
        public static string ErrormsgCustomerDeleted = "Customer is in use.";
        
        //Hospitals
        public static string msgAddHospital = "The new hospital has been added successfully.";

        public static string msgEditHospital = "The hospital info has been edited successfully.";
        public static string msgDeleteHospital = "The  hospital has been deleted successfully.";
        public static string ErrormsgDeleteHospital = "Hospital is in use";

        //Diagnosis
        public static string msgAddDiagnosis = "The new Diagnosis has been added successfully.";

        public static string msgEditDiagnosis = "The Diagnosis info has been edited successfully.";
        public static string msgAddAutoText = "The new AutoText has been added successfully.";
        public static string msgAddCommenttype = "The new CommentType has been added successfully.";

        //Nurse
        public static string msgAddNurse = "The new nurse has been added successfully.";

        public static string msgEditNurse = "The nurse info has been edited successfully.";
        public static string msgDeleteNurse = "The nurse has been deleted successfully.";
        public static string NurseInUser = "Nurse is in use";
        public static string NurseNotFount = "No relevant data fount";
        //Appointment
        public static string msgAddAppointment = "The new Appointment has been added successfully.";

        public static string msgEditAppointment = "The Appointment info has been edited successfully.";
        public static string msgAppointmentDeleted = "Appointment has been deleted successfully.";
        public static string ErrormsgAppointmentDeleted = "Appointment is in use.";
        //CreatePolicyAndProcedure
        public static string msgAddPolicyAndProcedure = "The new PolicyAndProcedure has been added successfully.";

        public static string msgEditPolicyAndProcedure = "The PolicyAndProcedure info has been edited successfully.";
        public static string msgDeleteCompanyProfile = "The CompanyProfile has been deleted successfully.";
        public static string CompanyProfileInUse = "CompanyProfile is in use";
        public static string CompanyProfileNotFount = "No relevant data fount";
        // DownloadCompanyDocument
        public static string DownloadCompanyDocument = "The CompanyDocument has been downloaded successfully.";
        public static string msgDownloadCompanyDocumentDeleted = "CompanyDocument  has been deleted successfully.";

        //UploadCompanyDocument
        public static string UploadCompanyDocument = "The CompanyDocument has been Uploaded successfully.";
        public static string msgUploadCompanyDocumentDeleted = "CompanyDocument  has been deleted successfully.";

       
        //User Role
        public static string msgCreateUserRole = "The new User role has been added successfully.";
     
        public static string msgEditUserRole = "The User role has  been edited successfully.";
       
        public static string msgUserRoleDeleted = "User Role has been deleted successfully.";
     


        public static string ErrormsgUserRoleDeleted = "User Role is in use.";
        //User Login
        public static string msgLoginSuccessfull { get; set; }
       
        //Permissions
         public static string msgSavePermission = "The permission has been saved successfully.";
        public static string ErrormsgSavePermission = "The permission has not been saved to database.";
        
       

    }
}
