using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnet.Htmx.Pages;

public class Counter : PageModel
{
    private int count = 0;
        
    public void OnGet()
    {
        // reset on refresh
        count = 0;
    }

    public IActionResult OnPost()
    {
        return Content($"<span>{count++}</span>", "text/html");
    }
}