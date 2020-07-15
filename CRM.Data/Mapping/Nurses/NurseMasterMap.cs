using CRM.Core.Domain.Nurses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Nurses
{
    public class NurseMasterMap : IEntityTypeConfiguration<NurseMaster>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<NurseMaster> builder)
        {
            builder.ToTable("NurseMaster");
            builder.HasKey(a => a.Id);


        }
    }
}
