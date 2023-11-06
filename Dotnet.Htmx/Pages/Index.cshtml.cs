using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnet.Htmx.Pages;

public class IndexModel : PageModel
{
    private static List<TaskItem> _taskItems = new();

    [BindProperty]
    public TaskItem TaskItem { get; set; }
    public IList<TaskItem> TaskItems { get; set; }

    public void OnGet()
    {
        TaskItems = _taskItems;
    }

    public IActionResult OnPostCreate()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        TaskItem.Id = _taskItems.Any() ? _taskItems.Max(t => t.Id) + 1 : 1;
        _taskItems.Add(TaskItem);
        TaskItems = _taskItems;
        return Partial("_TaskItemsTable", TaskItems);
    }

    public IActionResult OnGetEdit(int id)
    {
        var taskItem = _taskItems.FirstOrDefault(t => t.Id == id);
        if (taskItem == null)
        {
            return NotFound();
        }

        TaskItem = taskItem;
        return Partial("_EditTaskItem", TaskItem);
    }

    public IActionResult OnPostUpdate(int id)
    {
        var taskItem = _taskItems.FirstOrDefault(t => t.Id == id);
        if (taskItem == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        taskItem.Title = TaskItem.Title;
        taskItem.IsComplete = TaskItem.IsComplete;
        TaskItems = _taskItems;
        return Partial("_TaskItemsTable", TaskItems);
    }

    public IActionResult OnPostDelete(int id)
    {
        var taskItem = _taskItems.FirstOrDefault(t => t.Id == id);
        if (taskItem != null)
        {
            _taskItems.Remove(taskItem);
        }
        TaskItems = _taskItems;
        return Partial("_TaskItemsTable", TaskItems);
    }

}

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsComplete { get; set; }
} 
