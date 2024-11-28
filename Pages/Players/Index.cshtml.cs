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
    public class IndexModel : PageModel
    {
        private readonly Players.Models.AppDbContext _context;

        public IndexModel(Players.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; } = "first_asc";

        [BindProperty(SupportsGet = true)]
        public string CurrentSearch {get; set;} = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Players.Include(m => m.Teams).AsQueryable();

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(m => m.Name.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

            switch (CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(m => m.Name);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(m => m.Name);
                    break;
                default:
                    query = query.OrderBy(m => m.Name);
                    break;
            }

            var totalPlayerCount = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalPlayerCount / (double)PageSize);

            Player = await query
                .Skip((PageNum - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
