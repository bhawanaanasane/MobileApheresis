using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
 public partial class OtherLabValuesMap : IEntityTypeConfiguration<OtherLabValues>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<OtherLabValues> builder)
        {
            builder.ToTable("OtherLabValues");
            builder.HasKey(a => a.Id);


        }
    }
}
