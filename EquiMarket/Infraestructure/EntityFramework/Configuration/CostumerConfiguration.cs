using Domain.AggregatesModel.CostumerModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFramework.Configuration;

public class CostumerConfiguration : IEntityTypeConfiguration<Costumer>
{
    public void Configure(EntityTypeBuilder<Costumer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(x => x.UserId).IsRequired();

        builder
            .HasMany(x => x.Transactions)
            .WithOne(x => x.Costumer)
            .HasForeignKey(x => x.CostumerId);

        builder
            .HasMany(x => x.Reviews)
            .WithOne(x => x.Costumer)
            .HasForeignKey(x => x.CostumerId);

        builder
            .HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Costumer>(x => x.UserId);
    }
}
