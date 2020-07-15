using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
    public partial class SuppliesAndAccessMap : IEntityTypeConfiguration<SuppliesAndAccess>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<SuppliesAndAccess> builder)
        {
            builder.ToTable("SuppliesAndAccess");
            builder.HasKey(a => a.Id);


        }
    }
}
