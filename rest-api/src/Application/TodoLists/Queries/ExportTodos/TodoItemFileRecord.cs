using RestApi.Application.Common.Mappings;
using RestApi.Domain.Entities;

namespace RestApi.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
