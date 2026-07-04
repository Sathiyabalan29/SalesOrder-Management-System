namespace SalesOrderManagement.API.Models;

public class SalesOrderResponseDto
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public int ClientId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string PostCode { get; set; } = string.Empty;

    public decimal TotalExclAmount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public decimal TotalInclAmount { get; set; }

    public List<SalesOrderItemResponseDto> Items { get; set; } = new();
}