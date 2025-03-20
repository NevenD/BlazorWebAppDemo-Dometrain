using BlazorWebAppDemo.Demo.Database.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppDemo.Demo.Database.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTodoService(this IServiceCollection services)
        {
            services.AddPooledDbContextFactory<TodoDataContext>(options =>
            options.UseSqlite("Data Source=TodoApp.db"));

            //This is needed for running the migrations
            services.AddDbContext<TodoDataContext>(options => options.UseSqlite("Data Source=TodoApp.db"));

            services.AddScoped<ITodoService, TodoServiceDirectAccess>();

        }
    }
}
