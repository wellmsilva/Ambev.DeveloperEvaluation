using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(si => si.Id);
            builder.Property(si => si.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(si => si.Name).IsRequired().HasMaxLength(100);
            builder.Property(si => si.Quantity).IsRequired().HasColumnType("int");
            builder.Property(si => si.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(si => si.Discount).HasPrecision(18, 2)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Ignore(x => x.AmountTotal);

            builder.HasOne<Sale>()
                   .WithMany(s => s.Products)
                   .HasForeignKey(si => si.SaleId);
        }
    }
}
