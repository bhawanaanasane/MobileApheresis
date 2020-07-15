using CRM.Core.Domain.TreatmentRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.TreatmentRecords
{
   public class NoteAndReportMasterMap : IEntityTypeConfiguration<NoteAndReportMaster>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<NoteAndReportMaster> builder)
        {
            builder.ToTable("NoteAndReportMaster");
            builder.HasKey(a => a.Id);


        }
    }
}
