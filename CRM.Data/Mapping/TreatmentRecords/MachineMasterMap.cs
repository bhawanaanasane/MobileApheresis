using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
  public partial  class MachineMasterMap : IEntityTypeConfiguration<MachineMaster>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<MachineMaster> builder)
        {
            builder.ToTable("MachineMaster");
            builder.HasKey(a => a.Id);


        }
    }
}
