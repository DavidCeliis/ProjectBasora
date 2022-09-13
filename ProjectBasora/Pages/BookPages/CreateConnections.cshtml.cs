using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectBasora.Data;
using ProjectBasora.Models;

namespace ProjectBasora.Pages.BookPages
{
    [Authorize]
    public class CreateConnectionsModel : PageModel
    {
        private readonly ProjectBasora.Data.ApplicationDbContext _context;
        public int BookId { get; set; }
        public Book Book { get; set; }


        public CreateConnectionsModel(ProjectBasora.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int bookId)
        {

            var userId = User.Claims.Where(cc => cc.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

            BookId = _context.Books.Where(f => f.BookId == bookId & f.UserId == userId).FirstOrDefault().BookId;
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            //ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            //ViewData["BookId"] = new SelectList(_context.Books, "BookId", "ISBN");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public BooksAndAuthors BooksAndAuthors { get; set; }

        //[BindProperty]
        //public BooksAndLanguages BooksAndLanguages { get; set; } 
        //[BindProperty]
        //public BooksAndCategories BooksAndCategories { get; set; } 

     
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.BooksAndAuthors == null || BooksAndAuthors == null)
            //{
            //    return RedirectToPage("../Error");
            //}

            _context.BooksAndAuthors.Add(BooksAndAuthors);
            //_context.BooksAndCategories.Add(BooksAndCategories);
            //_context.BooksAndLanguages.Add(BooksAndLanguages);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
