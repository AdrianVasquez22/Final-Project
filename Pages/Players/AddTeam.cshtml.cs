using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Players.Models;

namespace Teams.Pages_Teams;

public class AddTeamModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<AddTeamModel> _logger;

    [BindProperty]
    public Team Team {get; set;} = default!;

    public SelectList PlayersDropDown {get; set;} = default!;

    public AddTeamModel(AppDbContext context, ILogger<AddTeamModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        PlayersDropDown = new SelectList(_context.Players.ToList(), "PlayerID", "Name");
    }

    public IActionResult OnPost()
{
    if (!ModelState.IsValid)
    {
        var allErrors = ModelState.Values.SelectMany(v => v.Errors);
        foreach (var e in allErrors)
        {
            _logger.LogError($"Error: {e.ErrorMessage}");
        }
        return Page();
    }

    _context.Teams.Add(Team);
    _context.SaveChanges();

    return RedirectToPage("./Index");
}
}
