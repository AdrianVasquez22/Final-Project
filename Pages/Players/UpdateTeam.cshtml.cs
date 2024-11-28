using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Players.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Teams.Pages_Teams;

public class UpdateTeamModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<UpdateTeamModel> _logger;

    [BindProperty]
    public Team Team {get; set;} = default!;

    public SelectList PlayersDropDown {get; set;} = default!;

    public UpdateTeamModel(AppDbContext context, ILogger<UpdateTeamModel> logger)
    {
        _context = context;
        _logger = logger;
    }

   public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var team = _context.Teams.Find(id);
        if (team == null)
        {
            return NotFound();
        }
        else
        {
            Team = team;
        }

        PlayersDropDown = new SelectList(_context.Players.ToList(), "PlayerID", "Name");
        return Page();
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

        try
        {
            _context.Attach(Team).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"Database error: {ex.InnerException?.Message}");
            return BadRequest("An error occurred while updating the team.");
        }

        return RedirectToPage("./Index");
    }
}