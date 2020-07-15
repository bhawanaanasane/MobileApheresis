using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
    public class PreTreatmentCheckMap : IEntityTypeConfiguration<PreTreatmentCheck>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<PreTreatmentCheck> builder)
        {
            builder.ToTable("PreTreatmentCheck");
            builder.HasKey(a => a.Id);


        }
    }
}
