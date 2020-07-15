using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
  public partial class LabValuesMap : IEntityTypeConfiguration<LabValues>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<LabValues> builder)
        {
            builder.ToTable("LabValues");
            builder.HasKey(a => a.Id);


        }
    }
}
