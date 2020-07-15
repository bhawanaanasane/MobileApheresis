using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
  public partial  class PreTreatmentAssessmentMap : IEntityTypeConfiguration<PreTreatmentAssessment>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<PreTreatmentAssessment> builder)
        {
            builder.ToTable("PreTreatmentAssessment");
            builder.HasKey(a => a.Id);


        }
    }
}
