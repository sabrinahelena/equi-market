using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFramework.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.CostumerId).IsRequired();
        builder.Property(x => x.Comment)
            .HasMaxLength(200)
            .IsRequired();
    }
}
