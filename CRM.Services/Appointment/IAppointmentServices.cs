using CRM.Core.Domain.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Services.Appointment
{
    public partial interface IAppointmentServices
    {
        #region Appointment
        /// <summary>
        /// Insert a Appointment
        /// </summary>
        /// <param name="Appointment">Appointment</param>
        void InsertAppointment(AppointmentMaster appointment);

        /// <summary>
        /// Updates the Appointment
        /// </summary>
        /// <param name="Appointment">Appointment</param>
        void UpdateAppointment(AppointmentMaster  appointment);

        void DeleteAppointment(AppointmentMaster appointment);

        /// <summary>
        /// Gets a Appointment
        /// </summary>
        /// <param name="AppointmentId">Appointment identifier</param>
        /// <returns>A Appointment</returns>
        AppointmentMaster GetAppointmentById(int AppointmentId);

        /// <summary>
        /// Gets all Appointment
        /// </summary>

        /// <returns>A Appointment</returns>
        IList<AppointmentMaster> GetAllAppointment();
        #endregion

        //Bhawana (3/10/2019)
        #region AppointmentDate
        /// <summary>
        /// Gets a AppointmentDate
        /// </summary>
        /// <param name="AppointmentDateId">AppointmentDate identifier</param>
        /// <returns>A Appointment</returns>
        AppointmentDates GetAppointmentDateById(int AppointmentDateId);

        /// <summary>
        /// Gets a AppointmentDate
        /// </summary>
        /// <param name="AppointmentDate and AppointmentMasterId">AppointmentDate and AppointmentMasterId identifier</param>
        /// <returns>A Appointment</returns>
        AppointmentDates GetAppointmentDateByAppointmentIdAndAppointmentDateId(int AppointmentId,int AppointmentDateId);
        void DeleteAppointmentDate(AppointmentDates appointmentDate);
        /// <summary>
        /// Updates the Appointment
        /// </summary>
        /// <param name="Appointment">Appointment</param>
        void UpdateAppointmentDate(AppointmentDates appointmentDate);
        #endregion

    }
}
