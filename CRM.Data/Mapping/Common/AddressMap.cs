﻿using CRM.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Mapping.Common
{
    public partial class AddressMap : IEntityTypeConfiguration<Address>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(a => a.Id);

           
        }
    }
}
