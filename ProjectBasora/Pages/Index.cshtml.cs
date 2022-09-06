using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectBasora.Data;
using ProjectBasora.Models;

namespace ProjectBasora.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Book> Books { get; set; }
        public IList<Author> Author { get; set; }
        public IList<BooksAndAuthors> BooksAndAuthors { get; set; }
        public BooksAndAuthors BooksAndAuthorsNoList { get; set; }
        public async Task OnGetAsync()
        {
            Books = await _context.Books
                .Include(s => s.User)
                .Include(s => s.BooksAndAuthors).ToListAsync();
            Author = await _context.Authors
                .Include(s => s.BooksAndAuthors)
                .ToListAsync();
            BooksAndAuthors = await _context.BooksAndAuthors
                .Include(s => s.Author)
                .Include(s => s.Book)
                .OrderBy(s => s.BookId)
                .ToListAsync();
            foreach (Author i in _context.Authors)
            {
                if (BooksAndAuthors.FirstOrDefault(c => c.AuthorId == i.AuthorId) == null)
                {
                    i.BookIncludeAuthors = null;
                }
                else
                {
                    BooksAndAuthorsNoList = BooksAndAuthors.First(c => c.AuthorId == i.AuthorId);
                    i.BookIncludeAuthors = BooksAndAuthorsNoList.Book;
                }


            }
            _context.SaveChanges();
        }
    }
}