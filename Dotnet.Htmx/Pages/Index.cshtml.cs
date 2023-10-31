using Dotnet.Htmx.Data;
using Dotnet.Htmx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnet.Htmx.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DatabaseContext _context;

    public IndexModel(ILogger<IndexModel> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IList<TaskModel> Tasks { get; set; }

    public void OnGet()
    {
        Tasks = _context.Tasks.ToList();
    }
    
    public IActionResult OnPostAddTask(TaskModel task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return new JsonResult(task);
    }
    
    public IActionResult OnPostUpdateTask(TaskModel task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
        return new JsonResult(task);
    }

    public IActionResult OnPostDeleteTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }
        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return new JsonResult(task);
    }
}