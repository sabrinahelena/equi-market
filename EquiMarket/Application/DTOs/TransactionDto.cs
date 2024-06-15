namespace Application.DTOs;

public class TransactionDto
{
    public int Id { get; set; }
    public int CostumerId { get; set; }
    public int ProductId { get; set; }
    public EPaymentStatus? PaymentStatus { get; init; }
    public EPaymentType PaymentType { get; init; }
    public DateTime FinishedAt { get; init; }
}
