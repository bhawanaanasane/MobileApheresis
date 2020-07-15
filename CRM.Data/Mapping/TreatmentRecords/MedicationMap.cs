using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
   public partial class MedicationMap : IEntityTypeConfiguration<Medication>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.ToTable("Medication");
            builder.HasKey(a => a.Id);


        }
    }
}
