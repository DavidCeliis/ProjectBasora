using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectBasora.Data;
using ProjectBasora.Models;

namespace ProjectBasora.Pages.BookPages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ProjectBasora.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public DeleteModel(ProjectBasora.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
      public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userId = User.Claims.Where(cc => cc.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.Include(s => s.User).Where(s => s.UserId == userId).FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }
            //else if(book.Borrowed == true)
            //{
            //    return RedirectToPage("/Index");
            //}
            else 
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                Book = book;
                _context.Books.Remove(Book);
                var fullname = Path.Combine(_environment.ContentRootPath, "Uploads", id.ToString());
                System.IO.File.Delete(fullname);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Users/Index");
        }
    }
}
