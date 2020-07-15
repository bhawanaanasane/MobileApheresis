using CRM.Core.Domain.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Appointment
{
   public partial class AppointmentDatesMap : IEntityTypeConfiguration<AppointmentDates>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<AppointmentDates> builder)
        {
            builder.ToTable("AppointmentDates");
            builder.HasKey(a => a.Id);


        }
    }
}
