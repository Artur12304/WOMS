using MediatR;
using RestApi.Application.Common.Models;

namespace RestApi.Application.Clients.Commands.DeleteClient;

public record DeleteClientCommand : IRequest<Result>
{
    public int Id { get; set; }
}