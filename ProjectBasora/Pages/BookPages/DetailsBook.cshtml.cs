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
    public class DetailsModel : PageModel
    {
        private readonly ProjectBasora.Data.ApplicationDbContext _context;

        public DetailsModel(ProjectBasora.Data.ApplicationDbContext context)
        {
            _context = context;
         
        }

      public Book Book { get; set; } = default!; 
        public ApplicationUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            AppUser = await _context.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();

            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
        [Authorize]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //if (!ModelState.IsValid || _context.UserAndBorrows == null || UserAndBorrow == null)
            //{
            //    return Page();
            //}
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);
            if (book.UserId != userId) {
            UserAndBorrow userAndborrow = new UserAndBorrow
            {
                UserAndBorrowId = book.BookId,
                UserId = userId,
                BookId = id,
                RenterId = book.UserId,
                //BorrowingId = id,
                Expired = false,
                Created = DateTime.Now,
                Expire = DateTime.Now.AddDays(2),
                Return = false
            };
            book.Borrowed = true;
            _context.UserAndBorrows.Add(userAndborrow);
            await _context.SaveChangesAsync();
            }
            else
            {
                RedirectToPage("../Error");
            }
            return RedirectToPage("../Users/Index");
        }
    }
}
