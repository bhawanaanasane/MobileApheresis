using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
    public partial class PatientMasterMap : IEntityTypeConfiguration<PatientMaster>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<PatientMaster> builder)
        {
            builder.ToTable("PatientMaster");
            builder.HasKey(a => a.Id);


        }
    }
}
