using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppDemo.Demo.Database.Data.EntityFramework;

public class TodoItem
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = "";
    public TodoState State { get; set; } = TodoState.New;
    public DateTime? DueDate { get; set; }
    public string? AssignedTo { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();
    [Required]
    public TShirtSize Effort { get; set; }
}
