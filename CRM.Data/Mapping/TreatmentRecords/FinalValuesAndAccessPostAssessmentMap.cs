using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
    class FinalValuesAndAccessPostAssessmentMap : IEntityTypeConfiguration<FinalValuesAndAccessPostAssessment>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<FinalValuesAndAccessPostAssessment> builder)
        {
            builder.ToTable("FinalValuesAndAccessPostAssessment");
            builder.HasKey(a => a.Id);


        }
    }
}
