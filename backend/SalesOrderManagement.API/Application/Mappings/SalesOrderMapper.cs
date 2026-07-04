using SalesOrderManagement.API.Application.Helpers;
using SalesOrderManagement.API.Domain.Entities;
using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Mappings;

public static class SalesOrderMapper
{
    public static SalesOrderResponseDto ToResponseDto(SalesOrder order)
    {
        var itemDtos = order.SalesOrderItems.Select(orderItem =>
        {
            var price = orderItem.Item?.Price ?? 0;
            var exclAmount = SalesOrderCalculator.CalculateExclAmount(orderItem.Quantity, price);
            var taxAmount = SalesOrderCalculator.CalculateTaxAmount(exclAmount, orderItem.TaxRate);
            var inclAmount = SalesOrderCalculator.CalculateInclAmount(exclAmount, taxAmount);

            return new SalesOrderItemResponseDto
            {
                Id = orderItem.Id,
                ItemId = orderItem.ItemId,
                ItemCode = orderItem.Item?.ItemCode ?? string.Empty,
                Description = orderItem.Item?.Description ?? string.Empty,
                Note = orderItem.Note,
                Quantity = orderItem.Quantity,
                Price = price,
                TaxRate = orderItem.TaxRate,
                ExclAmount = exclAmount,
                TaxAmount = taxAmount,
                InclAmount = inclAmount
            };
        }).ToList();

        return new SalesOrderResponseDto
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            ClientId = order.ClientId,
            CustomerName = order.Client?.CustomerName ?? string.Empty,
            Address = order.Client?.Address ?? string.Empty,
            City = order.Client?.City ?? string.Empty,
            PostCode = order.Client?.PostCode ?? string.Empty,
            TotalExclAmount = itemDtos.Sum(i => i.ExclAmount),
            TotalTaxAmount = itemDtos.Sum(i => i.TaxAmount),
            TotalInclAmount = itemDtos.Sum(i => i.InclAmount),
            Items = itemDtos
        };
    }

    public static SalesOrderListDto ToListDto(SalesOrder order)
    {
        var totalInclAmount = order.SalesOrderItems.Sum(orderItem =>
        {
            var price = orderItem.Item?.Price ?? 0;
            var exclAmount = SalesOrderCalculator.CalculateExclAmount(orderItem.Quantity, price);
            var taxAmount = SalesOrderCalculator.CalculateTaxAmount(exclAmount, orderItem.TaxRate);
            return SalesOrderCalculator.CalculateInclAmount(exclAmount, taxAmount);
        });

        return new SalesOrderListDto
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            CustomerName = order.Client?.CustomerName ?? string.Empty,
            TotalInclAmount = totalInclAmount
        };
    }
}