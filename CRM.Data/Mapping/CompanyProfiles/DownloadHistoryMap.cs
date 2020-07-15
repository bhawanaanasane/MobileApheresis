using CRM.Core.Domain.CompanyProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.CompanyProfiles
{
    public class DownloadHistoryMap : IEntityTypeConfiguration<DownloadHistory>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<DownloadHistory> builder)
    {
        builder.ToTable("DownloadHistory");
        builder.HasKey(a => a.Id);


    }
}
}
