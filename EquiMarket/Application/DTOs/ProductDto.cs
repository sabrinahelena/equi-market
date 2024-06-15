using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class ProductDto
{
    [Required]
    public int ProducerId { get; set; }

    [Required]
    public string Name { get; init; } = null!;
    public string? Description { get; init; }
    public string? Origin { get; init; }
    public string? ProductionProcess { get; init; }
    public string? Materials { get; init; }

    [Required]
    public double Price { get; init; }
}
