using CRM.Core.Domain.TreatmentMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Treatments
{
   public class DiagnosisMap : IEntityTypeConfiguration<Diagnosis>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.ToTable("Diagnosis");
            builder.HasKey(a => a.Id);


        }
    }
}
