using CRM.Core.Domain.Nurses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Nurses
{
    class NurseDocumentsMap : IEntityTypeConfiguration<NurseDocuments>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<NurseDocuments> builder)
        {
            builder.ToTable("NurseDocuments");
            builder.HasKey(a => a.Id);


        }
    }
}
