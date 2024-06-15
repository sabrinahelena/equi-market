using Application.DTOs;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.UseCases.Costumer.Transactions.Commands;

public class CreateTransactionCommand : TransactionDto, IRequest<CreateTransactionResponse>
{
    [JsonIgnore]
    public new int Id { get; set; }

    [JsonIgnore]
    public new int CostumerId { get; init; }

    [JsonIgnore]
    public new int ProductId { get; init; }

}
