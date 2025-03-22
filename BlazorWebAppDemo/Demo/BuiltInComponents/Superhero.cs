using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppDemo.Demo.BuiltInComponents;

public class Superhero
{
    public int Id { get; set; }
    [Required, MinLength(5)]
    public string Name { get; set; } = string.Empty;
    [Required, MinLength(5)]
    public string RealName { get; set; } = string.Empty;
    [Required, MinLength(5)]
    public string Powers { get; set; } = string.Empty;
}
