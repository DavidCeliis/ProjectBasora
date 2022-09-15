using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBasora.Data;
using ProjectBasora.Models;
using System.Linq;
using System.Security.Claims;

namespace ProjectBasora.Pages.Users
{
    [Authorize]
    public class IndexModel : PageModel

    {
        private IWebHostEnvironment _environment;
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;


        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _logger = logger;
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? AuthorsList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchAuthors { get; set; }
        public Searching Searching { get; set; }
        public IList<Book> Books { get; set; }
        public IList<Book> AllBooks { get; set; }
        public ApplicationUser AppUser { get; set; }
        public IList<Author> Author { get; set; }
        public IList<Categories> Category { get; set; }
        public IList<Languages> Language { get; set; }
        public IList<BooksAndAuthors> BooksAndAuthors { get; set; }
        public IList<BooksAndCategories> BooksAndCategories { get; set; }
        public IList<BooksAndLanguages> BooksAndLanguages { get; set; }
        public IList<UserAndBorrow> UserAndBorrow { get; set; }

        public IList<UserAndBorrowFinal> UserAndBorrowFinal { get; set; }
        public BooksAndAuthors BooksAndAuthorsNoList { get; set; }
        public BooksAndCategories BooksAndCategoriesNoList { get; set; }
        public BooksAndLanguages BooksAndLanguagesNoList { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public async Task OnGetAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            AppUser = await _context.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();

            AllBooks = await _context.Books
            .Include(s => s.User)
            .Include(s => s.BooksAndAuthors)
            .Include(s => s.BooksAndCategories)
            .Include(s => s.BooksAndLanguages)
            .Include(s => s.UserAndBorrow)
            .Where(s => s.UserId == userId)
            .ToListAsync();
            Books = await _context.Books
                .Include(s => s.User)
                .Include(s => s.BooksAndAuthors)
                .Include(s => s.BooksAndCategories)
                .Include(s => s.BooksAndLanguages)
                .Include(s => s.UserAndBorrow)
                .Where(s => s.UserId == userId)
                .ToListAsync();
            Author = await _context.Authors
                .Include(s => s.BooksAndAuthors)
                .ToListAsync();
            Category = await _context.Categories
                .Include(s => s.BooksAndCategories)
                .ToListAsync();
            Language = await _context.Languages
               .Include(s => s.BooksAndLanguages)
               .ToListAsync();

            BooksAndAuthors = await _context.BooksAndAuthors
                .Include(s => s.Author)
                .Include(s => s.Book)
                .OrderBy(s => s.BookId)
                .ToListAsync();
            BooksAndLanguages = await _context.BooksAndLanguages
                .Include(s => s.Languages)
                .Include(s => s.Book)
                .OrderBy(s => s.BookId)
                .ToListAsync();
            BooksAndCategories = await _context.BooksAndCategories
                 .Include(s => s.Categories)
                 .Include(s => s.Book)
                 .OrderBy(s => s.BookId)
                 .ToListAsync();
            UserAndBorrow = await _context.UserAndBorrows
                .Include(s => s.User)
                .Include(s => s.Book)
                .Include(s => s.Renter)
                .ToListAsync();
            UserAndBorrowFinal = await _context.UserAndBorrowsFinal
               .Include(s => s.User)
               .Include(s => s.Book)
               .Include(s => s.Renter)
               .ToListAsync();


            //IQueryable<string> AuthorQuery = from m in _context.Books
            //                                orderby m.BooksAndAuthors
            //                                select m.BooksAndAuthors;
            var book = from m in _context.Books.Where(s => s.UserId == userId)
                       select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                book = book.Where(s => s.Title!.Contains(SearchString)).Where(s => s.UserId == userId);
                var searchedbooks = book.Count();

                if (searchedbooks > 0)
                {
                    Searching searching = new Searching
                    {
                        Result = SearchString,
                        Find = true
                    };
                    _context.Searchings.Add(searching);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Searching searching = new Searching
                    {
                        Result = SearchString,
                        Find = false
                    };
                    _context.Searchings.Add(searching);
                    await _context.SaveChangesAsync();
                }


            }
            Books = await book.ToListAsync();



            _context.SaveChanges();
        }

        public async Task<IActionResult> OnGetThumbnail(string filename, ThumbnailType type = ThumbnailType.Square)
        {
            Book file = await _context.Books
              .AsNoTracking()
              .Where(f => f.BookId == int.Parse(filename))
              .SingleOrDefaultAsync();
            if (file == null)
            {
                return NotFound("no files");
                //return PhysicalFile("../wwwroot/images/no-image-available.jpg", "img");
            }
            Thumbnail thumbnail = await _context.Thumbnails
              .AsNoTracking()
              .Where(t => t.BookId == int.Parse(filename) && t.Type == type)
              .SingleOrDefaultAsync();
            if (thumbnail != null)
            {
                return File(thumbnail.Blob, file.ContentType);
            }
            return NotFound("no thumbnail for this file");


        }

        public async Task<IActionResult> OnPostAsync(int id, int bookid, string response)
        {

            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            AppUser = await _context.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();
            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == bookid);

            AllBooks = await _context.Books
            .Include(s => s.User)
            .Include(s => s.BooksAndAuthors)
            .Include(s => s.BooksAndCategories)
            .Include(s => s.BooksAndLanguages)
            .Include(s => s.UserAndBorrow)
            .Where(s => s.UserId == userId)
            .ToListAsync();
            Books = await _context.Books
                .Include(s => s.User)
                .Include(s => s.BooksAndAuthors)
                .Include(s => s.BooksAndCategories)
                .Include(s => s.BooksAndLanguages)
                .Include(s => s.UserAndBorrow)
                .Where(s => s.UserId == userId)
                .ToListAsync();
            Author = await _context.Authors
                .Include(s => s.BooksAndAuthors)
                .ToListAsync();
            Category = await _context.Categories
                .Include(s => s.BooksAndCategories)
                .ToListAsync();
            Language = await _context.Languages
               .Include(s => s.BooksAndLanguages)
               .ToListAsync();

            BooksAndAuthors = await _context.BooksAndAuthors
                .Include(s => s.Author)
                .Include(s => s.Book)
                .OrderBy(s => s.BookId)
                .ToListAsync();
            BooksAndLanguages = await _context.BooksAndLanguages
                .Include(s => s.Languages)
                .Include(s => s.Book)
                .OrderBy(s => s.BookId)
                .ToListAsync();
            BooksAndCategories = await _context.BooksAndCategories
                 .Include(s => s.Categories)
                 .Include(s => s.Book)
                 .OrderBy(s => s.BookId)
                 .ToListAsync();
            UserAndBorrow = await _context.UserAndBorrows
          .Include(s => s.User)
          .Include(s => s.Book)
          .Include(s => s.Renter)
          .ToListAsync();
            UserAndBorrowFinal = await _context.UserAndBorrowsFinal
               .Include(s => s.User)
               .Include(s => s.Book)
               .Include(s => s.Renter)
               .ToListAsync();


            if (response == "false")
            {
                var userAndBorrowNoList = await _context.UserAndBorrows
               .Include(p => p.User)
               .Include(p => p.Book)
               .Include(p => p.Renter).FirstOrDefaultAsync(m => m.UserAndBorrowId == id);
                _context.UserAndBorrows.Remove(userAndBorrowNoList);
                book.Borrowed = false;
                await _context.SaveChangesAsync();
                return RedirectToPage("/Users/Index");

            }
            else if (response == "true")
            {
                var userAndBorrowNoList = await _context.UserAndBorrows
                .Include(p => p.User)
                .Include(p => p.Book)
                .Include(p => p.Renter).FirstOrDefaultAsync(m => m.UserAndBorrowId == id);
                UserAndBorrowFinal request = new UserAndBorrowFinal
                {
                    UserAndBorrowFinalId = bookid,
                    BookId = bookid,
                    RenterId = userId,
                    UserId = userAndBorrowNoList.UserId,
                    Created = userAndBorrowNoList.Created,
                    Expired = false,
                    Expire = userAndBorrowNoList.Expire.AddDays(8),
                    Return = false

                };

                _context.UserAndBorrows.Remove(userAndBorrowNoList);
                _context.UserAndBorrowsFinal.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Users/Index");
            }
            else if (response == "return")
            {
                var userAndBorrowfinal = await _context.UserAndBorrowsFinal
          .Include(p => p.User)
          .Include(p => p.Book)
          .Include(p => p.Renter).FirstOrDefaultAsync(m => m.UserAndBorrowFinalId == id);
                UserAndBorrow request = new UserAndBorrow
                {
                    UserAndBorrowId = bookid,
                    BookId = bookid,
                    RenterId = userId,
                    UserId = userAndBorrowfinal.UserId,
                    Created = userAndBorrowfinal.Created,
                    Expired = false,
                    Expire = DateTime.Now.AddDays(2),
                    Return = true

                };

                _context.UserAndBorrowsFinal.Remove(userAndBorrowfinal);
                await _context.SaveChangesAsync();
                _context.UserAndBorrows.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Users/Index");

            }
            else if (response == "acceptreturn")
            {
                var userAndBorrowNoList = await _context.UserAndBorrows
             .Include(p => p.User)
             .Include(p => p.Book)
             .Include(p => p.Renter).FirstOrDefaultAsync(m => m.UserAndBorrowId == id);
                _context.UserAndBorrows.Remove(userAndBorrowNoList);
                book.Borrowed = false;
                await _context.SaveChangesAsync();
                return RedirectToPage("/Users/Index");
                            }
            else
            {
                return RedirectToPage("../Error");
            }
           
        }


    }
}