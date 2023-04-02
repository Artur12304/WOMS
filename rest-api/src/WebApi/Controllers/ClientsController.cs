using Microsoft.AspNetCore.Mvc;
using RestApi.Application.Clients.Commands.CreateClient;
using RestApi.Application.Clients.Commands.DeleteClient;
using RestApi.Application.Clients.Commands.UpdateClient;
using RestApi.Application.Clients.Model;
using RestApi.Application.Clients.Queries.GetClient;
using RestApi.Application.Clients.Queries.ListClients;
using RestApi.Application.Common.Models;

namespace RestApi.WebApi.Controllers;

public class ClientsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateClientCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result>> Delete(int id)
    {
        return await Mediator.Send(new DeleteClientCommand { Id = id });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(int id, UpdateClientCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        return await Mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<ClientDto> Get(int id)
    {
        return await Mediator.Send(new GetClientQuery { Id = id });
    }

    [HttpGet]
    public async Task<IEnumerable<ClientDto>> Get()
    {
        return await Mediator.Send(new ListClientsQuery { });
    }
}
