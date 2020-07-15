﻿using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
  public partial  class TreatmentRecordMasterMap : IEntityTypeConfiguration<TreatmentRecordMaster>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<TreatmentRecordMaster> builder)
        {
            builder.ToTable("TreatmentRecordMaster");
            builder.HasKey(a => a.Id);


        }
    }
}
