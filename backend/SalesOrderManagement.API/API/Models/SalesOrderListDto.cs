namespace SalesOrderManagement.API.Models;

public class SalesOrderListDto
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public decimal TotalInclAmount { get; set; }
}