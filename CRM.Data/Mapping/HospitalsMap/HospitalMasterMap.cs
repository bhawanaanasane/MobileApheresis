using CRM.Core.Domain.Hospitals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.HospitalsMap
{
  public partial class HospitalMasterMap : IEntityTypeConfiguration<HospitalMaster>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<HospitalMaster> builder)
        {
            builder.ToTable("HospitalMaster");
            builder.HasKey(a => a.Id);


        }
    
    }
}
