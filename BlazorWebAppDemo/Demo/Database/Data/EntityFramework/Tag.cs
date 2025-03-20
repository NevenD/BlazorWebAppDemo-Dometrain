namespace BlazorWebAppDemo.Demo.Database.Data.EntityFramework;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
