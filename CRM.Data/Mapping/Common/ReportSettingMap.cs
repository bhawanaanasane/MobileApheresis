using CRM.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Common
{
    public partial class ReportSettingMap : IEntityTypeConfiguration<ReportSetting>
    {
        public void Configure(EntityTypeBuilder<ReportSetting> builder)
        {
            builder.ToTable("ReportSetting");
            builder.HasKey(a => a.Id);
            builder.Property(p => p.ReportName).IsRequired().HasMaxLength(400);
        }
    }
}
