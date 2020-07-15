
using CRM.Core.Domain.Printers;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Mapping.WarehouseManagement
{
    public class PrinterCloudSettingMap : IEntityTypeConfiguration<PrinterCloudSetting>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PrinterCloudSetting> builder)
        {
            builder.ToTable("PrinterCloudSetting");
            builder.HasKey(tc => tc.Id);
            builder.Property(tc => tc.KeyFilePath).IsRequired();
            builder.Property(tc => tc.KeyFileSecreat).IsRequired();
            builder.Property(tc => tc.ServiceAccountEmail).IsRequired();
            builder.Property(tc => tc.ServiceName).IsRequired();
        }
    }

}
