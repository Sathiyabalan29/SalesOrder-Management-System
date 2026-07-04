using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesOrderManagement.API.Domain.Entities;

public class Item
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string ItemCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public List<SalesOrderItem> SalesOrderItems { get; set; } = new();
}