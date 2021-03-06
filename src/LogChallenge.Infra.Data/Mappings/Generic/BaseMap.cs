﻿using LogChallenge.Domain.Entities.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogChallenge.Infra.Data.Mappings.Generic
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //builder.HasKey(c => c.Id);

            //builder.Property(c => c.Id)
            //    .IsRequired()
            //    .HasColumnName("Id");
        }
    }
}
