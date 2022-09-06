using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectBasora.Data;
using ProjectBasora.Models;

namespace ProjectBasora.Pages.BookPages
{
    public class IndexModel : PageModel
    {
        private readonly ProjectBasora.Data.ApplicationDbContext _context;

        public IndexModel(ProjectBasora.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books
                .Include(b => b.User).ToListAsync();
            }
        }
    }
}
