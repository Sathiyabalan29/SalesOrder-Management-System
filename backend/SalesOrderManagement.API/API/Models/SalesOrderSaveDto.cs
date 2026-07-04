using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagement.API.Models;

public class SalesOrderSaveDto
{
    [Required]
    public int ClientId { get; set; }

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

    [Required]
    [MinLength(1, ErrorMessage = "At least one item is required.")]
    public List<SalesOrderItemSaveDto> Items { get; set; } = new();
}