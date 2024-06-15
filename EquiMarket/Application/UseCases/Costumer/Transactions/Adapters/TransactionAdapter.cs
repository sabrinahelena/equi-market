using Application.UseCases.Costumer.Transactions.Commands;
using Domain.AggregatesModel.Common;

namespace Application.UseCases.Costumer.Transactions.Adapters;

public static class TransactionAdapter
{
    public static Transaction Map(this CreateTransactionCommand command)
    {
        return new Transaction
        {
            CostumerId = command.CostumerId,
            ProductId = command.ProductId,
            CreatedAt = DateTime.Now,
            PaymentStatus = (int?)command.PaymentStatus,
            PaymentType = (int)command.PaymentType,

        };
    }
}
