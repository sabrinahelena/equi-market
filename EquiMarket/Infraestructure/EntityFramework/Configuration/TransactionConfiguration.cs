using Domain.AggregatesModel.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFramework.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("ID")
            .IsRequired();

        builder.Property(x => x.PaymentType).IsRequired();
        builder.Property(x => x.PaymentStatus);
        builder.Property(x => x.CostumerId).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
    }
}
