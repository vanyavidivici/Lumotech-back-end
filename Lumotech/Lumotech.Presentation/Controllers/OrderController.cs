using Lumotech.Presentation.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Lumotech.Presentation.Controllers;

[Route("api/orders")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IServiceManager _service;

    public OrderController(IServiceManager service) => _service = service;
    
    [HttpGet("admin")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> GetOrdersForAdmin([FromQuery] OrderParameters orderParameters)
    {
        var orders = 
            await _service.OrderService.GetAllOrdersAsync(orderParameters, trackChanges: false);
        return Ok(orders);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] OrderParameters orderParameters)
    {
        var userId = User.Claims.FirstOrDefault()?.Value;
        var orders = 
            await _service.OrderService.GetAllOrdersForUserAsync(userId, orderParameters, trackChanges: false);
        return Ok(orders);
    }
    
    [HttpGet("{id:guid}", Name = "OrderById")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _service.OrderService.GetOrderAsync(id, trackChanges: false);
        return Ok(order);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto order)
    {
        
        var userId = User.Claims.FirstOrDefault()?.Value;
        var createdOrder = await _service.OrderService.CreateOrderAsync(userId, order);
        
        return CreatedAtRoute("OrderById", new { id = createdOrder.Id },
            createdOrder);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        await _service.OrderService.DeleteOrderAsync(id, trackChanges: false);
        
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderForUpdateDto order)
    {
        await _service.OrderService.UpdateOrderAsync(id, order, trackChanges: true);

        return NoContent();
    }

    // [HttpPost]
    // [ServiceFilter(typeof(ValidationFilterAttribute))]
    // private async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto order)
    // {
    //     
    //     var userId = User.Claims.FirstOrDefault()?.Value;
    //     var createdOrder = await _service.OrderService.CreateOrderAsync(userId, order);
    //     var sequence = "1-15+2+1-10+3";
    //     using (var httpClient = new HttpClient())
    //     {
    //         httpClient.Timeout = TimeSpan.FromSeconds(60);
    //         httpClient.BaseAddress = new Uri("http://localhost:9080/");
    //         string requestUrl = "move?sequence=" + sequence + "/";
    //         try
    //         {
    //             HttpResponseMessage response = await httpClient.PostAsync(requestUrl, null);
    //             if (response.IsSuccessStatusCode)
    //             {
    //                 return CreatedAtRoute("OrderById", new { id = createdOrder.Id },
    //                     createdOrder);
    //             }
    //             else
    //             {
    //                 return BadRequest($"Toggle request failed with status code: {response.StatusCode}");
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             return StatusCode(500, $"An error occurred while sending the toggle request: {ex.Message}");
    //         }
    //     }
    // }
}