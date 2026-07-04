using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrderManagement.API.Domain.Entities;

public class SalesOrderItem
{
    public int Id { get; set; }

    [Required]
    public int SalesOrderId { get; set; }

    public SalesOrder? SalesOrder { get; set; }

    [Required]
    public int ItemId { get; set; }

    public Item? Item { get; set; }

    [MaxLength(500)]
    public string? Note { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }

    [Range(0, 100, ErrorMessage = "Tax rate must be between 0 and 100.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TaxRate { get; set; }
}