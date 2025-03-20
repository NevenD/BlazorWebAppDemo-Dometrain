using BlazorWebAppDemo.Demo.Database.Data.EntityFramework;

namespace BlazorWebAppDemo.Demo.Database.Data
{
    public interface ITodoService
    {
        Task<TodoItem> AddTodoItemAsync(TodoItem todoItem);
        Task<List<TodoItem>> GetAllTodoItemsAsync();
        Task<TodoItem> GetTodoItemByIdAsync(int id);
        Task<TodoItem> UpdateTodoItemAsync(TodoItem todoItem);
        Task DeleteTodoItemAsync(int id);
    }
}
