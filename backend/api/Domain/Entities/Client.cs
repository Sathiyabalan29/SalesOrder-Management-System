using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.API.Domain.Entities;

public class Client
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    [MaxLength(250)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string PostCode { get; set; } = string.Empty;

    public List<SalesOrder> SalesOrders { get; set; } = new();
}