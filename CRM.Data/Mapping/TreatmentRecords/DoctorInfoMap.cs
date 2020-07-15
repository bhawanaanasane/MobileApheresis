using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
  public partial class DoctorInfoMap : IEntityTypeConfiguration<DoctorInfo>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<DoctorInfo> builder)
        {
            builder.ToTable("DoctorInfo");
            builder.HasKey(a => a.Id);


        }
    }
}
