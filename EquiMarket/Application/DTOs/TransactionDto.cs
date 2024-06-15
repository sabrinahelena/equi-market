namespace Application.DTOs;

public class TransactionDto
{
    public int Id { get; set; }
    public int CostumerId { get; init; }
    public int ProductId { get; init; }
    public EPaymentStatus? PaymentStatus { get; init; }
    public EPaymentType PaymentType { get; init; }
    public DateTime FinishedAt { get; init; }
}
