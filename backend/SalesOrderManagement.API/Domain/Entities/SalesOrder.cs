using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.API.Domain.Entities;

public class SalesOrder
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Required]
    public int ClientId { get; set; }

    public Client? Client { get; set; }

    public List<SalesOrderItem> SalesOrderItems { get; set; } = new();
}