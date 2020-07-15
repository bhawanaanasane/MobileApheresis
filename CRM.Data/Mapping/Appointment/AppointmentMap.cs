﻿using CRM.Core.Domain.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Appointment
{
    public partial class AppointmentMap : IEntityTypeConfiguration<AppointmentMaster>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<AppointmentMaster> builder)
        {
            builder.ToTable("AppointmentMaster");
            builder.HasKey(a => a.Id);


        }
    }
}
