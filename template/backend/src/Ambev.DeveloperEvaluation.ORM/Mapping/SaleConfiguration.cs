using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(x => x.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Branch).IsRequired().HasMaxLength(70);
        builder.Property(p => p.Date);

        builder.Ignore(p => p.AmountTotal);

        builder.HasMany(x => x.Products)
                .WithOne(s => s.Sale)
                .HasForeignKey(si => si.SaleId);

    }
}
