using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Players.Models;

namespace Final_Project.Pages_Players
{
    public class DetailsModel : PageModel
    {
        private readonly Players.Models.AppDbContext _context;

        public DetailsModel(Players.Models.AppDbContext context)
        {
            _context = context;
        }

        public Player Player { get; set; } = default!;

        [BindProperty]
        public int TeamIDToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.Include(m => m.Teams).FirstOrDefaultAsync(m => m.PlayerID == id);

            if (player is not null)
            {
                Player = player;

                return Page();
            }

            return NotFound();
        }

        public IActionResult OnPostDeleteTeam(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var team = _context.Teams.FirstOrDefault(r => r.TeamID == TeamIDToDelete);
            if (team != null)
            {
                _context.Remove(team);
                _context.SaveChanges();
            }

            Player = _context.Players.Include(m => m.Teams).First(m => m.PlayerID == id);
            return Page();
        }
    }
}
