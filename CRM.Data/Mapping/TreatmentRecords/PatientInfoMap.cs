using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
   public partial class PatientInfoMap : IEntityTypeConfiguration<PatientInfo>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<PatientInfo> builder)
        {
            builder.ToTable("PatientInfo");
            builder.HasKey(a => a.Id);


        }
    }
}
