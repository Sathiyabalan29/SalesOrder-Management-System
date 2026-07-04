using Microsoft.AspNetCore.Mvc;
using SalesOrderManagement.API.Application.Interfaces;
using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesOrdersController : ControllerBase
{
    private readonly ISalesOrderService _salesOrderService;

    public SalesOrdersController(ISalesOrderService salesOrderService)
    {
        _salesOrderService = salesOrderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var salesOrders = await _salesOrderService.GetAllAsync();
        return Ok(salesOrders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var salesOrder = await _salesOrderService.GetByIdAsync(id);

        if (salesOrder == null)
        {
            return NotFound();
        }

        return Ok(salesOrder);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SalesOrderSaveDto dto)
    {
        try
        {
            var createdOrder = await _salesOrderService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, SalesOrderSaveDto dto)
    {
        try
        {
            var updatedOrder = await _salesOrderService.UpdateAsync(id, dto);

            if (updatedOrder == null)
            {
                return NotFound();
            }

            return Ok(updatedOrder);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}