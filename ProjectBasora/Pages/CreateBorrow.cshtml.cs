using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectBasora.Data;
using ProjectBasora.Models;

namespace ProjectBasora.Pages
{
    public class CreateBorrowModel : PageModel
    {
        private readonly ProjectBasora.Data.ApplicationDbContext _context;

        public CreateBorrowModel(ProjectBasora.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "ISBN");
        ViewData["BorrowingId"] = new SelectList(_context.Borrowing, "Id", "Id");
        ViewData["RenterId"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public UserAndBorrow UserAndBorrow { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UserAndBorrows == null || UserAndBorrow == null)
            {
                return Page();
            }

            _context.UserAndBorrows.Add(UserAndBorrow);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
