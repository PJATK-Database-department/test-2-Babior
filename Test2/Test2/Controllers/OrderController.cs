using Microsoft.AspNetCore.Mvc;
using Test2.DTOs;
using Test2.Services.Contracts;

namespace Test2.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrdersService _orderService;
    
    public OrderController(IOrdersService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet("/{idClient:int}")]
    public async Task<IActionResult> GeOrderByClientId([FromRoute] int idClient)
    {
        var orders = await _orderService.GetOrdersByClient(idClient);
        return Ok(orders);
    }
    
    [HttpPut("/{idOrder:int}")]
    public IActionResult UpdateOrder([FromBody] OrderRequest newOrder, [FromRoute] int idOrder)
    {
        _orderService.UpdateOrder(newOrder, idOrder);
        return Ok();
    }
}