using eCommerceServer.Domain.Companies;
using eCommerceServer.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerceServer.Infrastructure.Configurations;

public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder
            .Property(p => p.Name)
            .HasConversion(name => name.Value, value => new Name(value))
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.OwnsOne(p => p.Address, builder =>
        {
            builder.Property(p => p.Country).HasColumnType("varchar(50)");
            builder.Property(p => p.City).HasColumnType("varchar(50)");
            builder.Property(p => p.Street).HasColumnType("varchar(50)");
            builder.Property(p => p.Town).HasColumnType("varchar(50)");
            builder.Property(p => p.FullAddress).HasColumnType("varchar(200)");
        });

        builder
            .Property(p => p.TaxNumber)
            .HasConversion(p => p.Value, v => new(v))
            .HasColumnName("TaxNumber");

        builder
            .Property(p => p.TaxDepartment)
            .HasMaxLength(11)
            .HasConversion(p => p.Value, v => TaxDepartmentSmartEnum.FromValue(v))
            .HasColumnName("TaxDepartment")
            .IsRequired();

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
