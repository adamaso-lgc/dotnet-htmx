using System.ComponentModel.DataAnnotations;

namespace Dotnet.Htmx.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsComplete { get; set; }
}