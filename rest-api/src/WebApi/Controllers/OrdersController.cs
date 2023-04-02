using Microsoft.AspNetCore.Mvc;
using RestApi.Application.Orders.Commands.CreateOrder;
using RestApi.Application.Orders.Commands.UpdateOrder;
using RestApi.Application.Orders.Model;
using RestApi.Application.Orders.Queries.GetOrder;
using RestApi.Application.Orders.Queries.ListOrders;

namespace RestApi.WebApi.Controllers;

public class OrdersController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateOrderCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(int id, UpdateOrderCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return await Mediator.Send(command);
    }

    [HttpGet("{clientId}")]
    public async Task<IEnumerable<OrderDto>> GetByClient(int clientId)
    {
        return await Mediator.Send(new ListOrdersByClientQuery { ClientId = clientId });
    }

    [HttpGet("{id}")]
    public async Task<OrderDto> Get(int id)
    {
        return await Mediator.Send(new GetOrderQuery { Id = id });
    }

    [HttpGet]
    public async Task<IEnumerable<OrderDto>> Get()
    {
        return await Mediator.Send(new ListOrdersQuery { });
    }
}
