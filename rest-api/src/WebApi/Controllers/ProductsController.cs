using Microsoft.AspNetCore.Mvc;
using RestApi.Application.Common.Models;
using RestApi.Application.Products.Commands.CreateProduct;
using RestApi.Application.Products.Commands.DeleteProduct;
using RestApi.Application.Products.Commands.UpdateProduct;
using RestApi.Application.Products.Model;
using RestApi.Application.Products.Queries.GetProduct;
using RestApi.Application.Products.Queries.ListProducts;

namespace RestApi.WebApi.Controllers;

public class ProductsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        return await Mediator.Send(new DeleteProductCommand { Id = id });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return await Mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> Get(int id)
    {
        return await Mediator.Send(new GetProductQuery { Id = id });
    }

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> Get()
    {
        return await Mediator.Send(new ListProductsQuery { });
    }
}
