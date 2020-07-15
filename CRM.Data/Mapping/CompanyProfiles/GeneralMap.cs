using CRM.Core.Domain.CompanyProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.CompanyProfiles
{
    public partial class GeneralMap : IEntityTypeConfiguration<CompanyProfile>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<CompanyProfile> builder)
        {
            builder.ToTable("CompanyProfile");
            builder.HasKey(a => a.Id);


        }
    }
}
