using BlazorWebAppDemo.Demo.Database.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppDemo.Demo.Database.Data
{
    public class TodoServiceDirectAccess : ITodoService
    {
        private readonly IDbContextFactory<TodoDataContext> _contextFactory;

        public TodoServiceDirectAccess(IDbContextFactory<TodoDataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<TodoItem> AddTodoItemAsync(TodoItem todoItem)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<List<TodoItem>> GetAllTodoItemsAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return context.TodoItems.Include(t => t.Tags).ToList();
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var item = await context.TodoItems.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);
            return item ?? throw new Exception("Item not found");
        }

        public async Task<TodoItem> UpdateTodoItemAsync(TodoItem todoItem)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Entry(todoItem).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return todoItem;
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var item = context.TodoItems.Find(id);
            if (item != null)
            {
                context.TodoItems.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }

}
