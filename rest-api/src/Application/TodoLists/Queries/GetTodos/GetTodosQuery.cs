using MediatR;

namespace RestApi.Application.TodoLists.Queries.GetTodos;

//[Authorize]
public record GetTodosQuery : IRequest<TodosVm>;