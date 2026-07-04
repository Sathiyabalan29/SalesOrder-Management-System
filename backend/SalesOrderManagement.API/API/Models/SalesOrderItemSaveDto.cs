using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.API.Models;

public class SalesOrderItemSaveDto
{
    [Required]
    public int ItemId { get; set; }

    [MaxLength(500)]
    public string? Note { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public decimal Quantity { get; set; }

    [Range(0, 100, ErrorMessage = "Tax rate must be between 0 and 100.")]
    public decimal TaxRate { get; set; }
}