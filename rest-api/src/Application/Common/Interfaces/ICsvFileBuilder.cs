using RestApi.Application.TodoLists.Queries.ExportTodos;

namespace RestApi.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
