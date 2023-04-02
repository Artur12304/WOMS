using Microsoft.AspNetCore.Mvc;
using RestApi.Application.Carts.Commands.CreateCart;
using RestApi.Application.Carts.Commands.DeleteCart;
using RestApi.Application.Carts.Commands.UpdateCart;
using RestApi.Application.Carts.Model;
using RestApi.Application.Carts.Queries.GetCart;
using RestApi.Application.Carts.Queries.ListCarts;
using RestApi.Application.Common.Models;

namespace RestApi.WebApi.Controllers;

public class CartsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCartCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        return await Mediator.Send(new DeleteCartCommand { Id = id });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(int id, UpdateCartCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return await Mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<CartDto> Get(int id)
    {
        return await Mediator.Send(new GetCartQuery { Id = id });
    }

    [HttpGet]
    public async Task<IEnumerable<CartDto>> Get()
    {
        return await Mediator.Send(new ListCartsQuery { });
    }
}
