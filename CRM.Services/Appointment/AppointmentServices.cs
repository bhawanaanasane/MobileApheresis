using CRM.Core.Domain.Appointment;
using CRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Services.Appointment
{
    public partial class AppointmentServices : IAppointmentServices
    {
        #region Fields
        private readonly IRepository<AppointmentMaster> _appointmentMasterRepository;
        private readonly IRepository<AppointmentDates> _appointmentDateRepository;

        #endregion
        #region CTOR
        public AppointmentServices(IRepository<AppointmentMaster> AppointmentMasterRepository,
            IRepository<AppointmentDates> AppointmentDateRepository) {
            this._appointmentMasterRepository = AppointmentMasterRepository;
            this._appointmentDateRepository = AppointmentDateRepository;

        }
        #endregion

        #region Appointment
        /// <summary>
        /// Insert a Appointment
        /// </summary>
        /// <param name="Appointment">Appointment</param>
        public void InsertAppointment(AppointmentMaster appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            _appointmentMasterRepository.Insert(appointment);
        }

        /// <summary>
        /// Updates the Appointment
        /// </summary>
        /// <param name="Appointment">Appointment</param>
        public void UpdateAppointment(AppointmentMaster appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            _appointmentMasterRepository.Update(appointment);
        }

       public void DeleteAppointment(AppointmentMaster appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));
            appointment.Deleted = true;
            UpdateAppointment(appointment);
        }

        /// <summary>
        /// Gets a Appointment
        /// </summary>
        /// <param name="AppointmentId">Appointment identifier</param>
        /// <returns>A Appointment</returns>
        public AppointmentMaster GetAppointmentById(int AppointmentId)
        {
            var query = from d in _appointmentMasterRepository.Table
                        where d.Id == AppointmentId
                        select d;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets all Appointment
        /// </summary>

        /// <returns>A Appointment</returns>
        public IList<AppointmentMaster> GetAllAppointment()
        {
            var query = from d in _appointmentMasterRepository.Table                       
                        select d;
            return query.ToList();
        }
        #endregion


        #region AppointmentDate
        /// <summary>
        /// Gets a AppointmentDate
        /// </summary>
        /// <param name="AppointmentDateId">AppointmentDate identifier</param>
        /// <returns>A Appointment</returns>
       public AppointmentDates GetAppointmentDateById(int AppointmentDateId)
        {
            var query = from d in _appointmentDateRepository.Table
                        where d.Id == AppointmentDateId
                        select d;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Gets a AppointmentDate
        /// </summary>
        /// <param name="AppointmentDateId and AppointmentMasterId">AppointmentDate and AppointmentMasterId identifier</param>
        /// <returns>A Appointment</returns>
       public AppointmentDates GetAppointmentDateByAppointmentIdAndAppointmentDateId(int AppointmentId, int AppointmentDateId)
        {
            var query = from d in _appointmentDateRepository.Table
                        where d.AppointmentMasterId == AppointmentId && d.Id == AppointmentDateId
                        select d;
            return query.FirstOrDefault();
        }
        public void DeleteAppointmentDate(AppointmentDates appointmentDate)
        {
            if (appointmentDate == null)
                throw new ArgumentNullException(nameof(appointmentDate));

            _appointmentDateRepository.Delete(appointmentDate);
        }

        /// <summary>
        /// Updates the Appointment
        /// </summary>
        /// <param name="Appointment">Appointment</param>
        public void UpdateAppointmentDate(AppointmentDates appointmentDate)
        {
            if (appointmentDate == null)
                throw new ArgumentNullException(nameof(appointmentDate));

            _appointmentDateRepository.Update(appointmentDate);
        }
        #endregion

    }
}
