using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.AggregatesModel.Common;

namespace Infraestructure.EntityFramework.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(x => x.ProducerId).IsRequired();
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Materials).HasMaxLength(150);
        builder.Property(x => x.Origin).HasMaxLength(40);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.ProductionProcess).HasMaxLength(150);

        builder.HasMany(x => x.Reviews)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Transaction)
            .WithOne(x => x.Product)
            .HasForeignKey<Transaction>(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
