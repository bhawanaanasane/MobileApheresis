using CRM.Core.Domain.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Equipments
{
   public class EquipmentDocumentsMap : IEntityTypeConfiguration<EquipmentDocuments>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<EquipmentDocuments> builder)
        {
            builder.ToTable("EquipmentDocuments");
            builder.HasKey(a => a.Id);


        }
    }
}
