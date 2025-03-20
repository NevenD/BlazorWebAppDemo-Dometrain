using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppDemo.Demo.Database.Data.EntityFramework;

public class TodoDataContext : DbContext
{
    public TodoDataContext(DbContextOptions<TodoDataContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>()
            .HasMany(t => t.Tags)
            .WithMany(t => t.TodoItems)
            .UsingEntity(j => j.ToTable("TodoItemTags"));
    }
}