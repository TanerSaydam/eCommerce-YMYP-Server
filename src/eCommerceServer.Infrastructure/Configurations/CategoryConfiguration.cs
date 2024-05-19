﻿using eCommerceServer.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerceServer.Infrastructure.Configurations;
public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new Name(value))
            .IsRequired()
            .HasColumnType("varchar(50)");
    }
}
