using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
    public partial class RunValuesMap : IEntityTypeConfiguration<RunValues>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<RunValues> builder)
        {
            builder.ToTable("RunValues");
            builder.HasKey(a => a.Id);


        }
    }
}
