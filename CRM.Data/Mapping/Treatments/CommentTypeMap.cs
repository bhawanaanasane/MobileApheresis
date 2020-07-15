using CRM.Core.Domain.TreatmentMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Treatments
{
   public class CommentTypeMap : IEntityTypeConfiguration<CommentType>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<CommentType> builder)
        {
            builder.ToTable("CommentType");
            builder.HasKey(a => a.Id);


        }
    }
}
