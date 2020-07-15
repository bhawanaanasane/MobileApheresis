using CRM.Core.Domain.TreatmentMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Treatments
{
   public class AutoTextMap : IEntityTypeConfiguration<AutoText>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<AutoText> builder)
        {
            builder.ToTable("AutoText");
            builder.HasKey(a => a.Id);


        }
    }
}
