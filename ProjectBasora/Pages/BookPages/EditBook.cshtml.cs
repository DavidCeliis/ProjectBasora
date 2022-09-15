using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBasora.Data;
using ProjectBasora.Models;

namespace ProjectBasora.Pages.BookPages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ProjectBasora.Data.ApplicationDbContext _context;

        public EditModel(ProjectBasora.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            var userId = User.Claims.Where(cc => cc.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book =  await _context.Books.Include(s=>s.User).FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
        
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToPage("../Error");
            //}

            var userId = User.Claims.Where(cc => cc.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            if (userId == Book.UserId)
            {
                Book.UserId = userId;
                Book.User = _context.Users.Where(c => c.Id == userId).FirstOrDefault();
                _context.Attach(Book).State = EntityState.Modified;
            }
            else
            {
                return RedirectToPage("../Error");
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Users/Index");
        }

        private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
