using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.ProducerModel;

namespace Infraestructure.EntityFramework.Configuration;

public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(x => x.UserId).IsRequired();

        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.Producer)
            .HasForeignKey(x => x.ProducerId);

        builder
            .HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Producer>(x => x.UserId);
    }
}
