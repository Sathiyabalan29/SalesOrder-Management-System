namespace SalesOrderManagement.API.Application.Helpers;

public static class SalesOrderCalculator
{
    public static decimal CalculateExclAmount(decimal quantity, decimal price)
    {
        return quantity * price;
    }

    public static decimal CalculateTaxAmount(decimal exclAmount, decimal taxRate)
    {
        return exclAmount * taxRate / 100;
    }

    public static decimal CalculateInclAmount(decimal exclAmount, decimal taxAmount)
    {
        return exclAmount + taxAmount;
    }
}