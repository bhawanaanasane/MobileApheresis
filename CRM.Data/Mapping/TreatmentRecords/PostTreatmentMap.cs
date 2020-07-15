using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
   public partial class PostTreatmentMap : IEntityTypeConfiguration<PostTreatment>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<PostTreatment> builder)
        {
            builder.ToTable("PostTreatment");
            builder.HasKey(a => a.Id);


        }
    }
}
