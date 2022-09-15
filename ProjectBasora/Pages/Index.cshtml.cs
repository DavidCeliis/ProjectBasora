using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBasora.Data;
using ProjectBasora.Models;
using System.Linq;

namespace ProjectBasora.Pages
{
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
        public IList<Author> Author { get; set; }
        public IList<Categories> Category { get; set; }
        public IList<Languages> Language { get; set; }
        public IList<BooksAndAuthors> BooksAndAuthors { get; set; }
        public IList<BooksAndCategories> BooksAndCategories { get; set; }
        public IList<BooksAndLanguages> BooksAndLanguages { get; set; }
        public BooksAndAuthors BooksAndAuthorsNoList { get; set; }
        public BooksAndCategories BooksAndCategoriesNoList { get; set; }
        public BooksAndLanguages BooksAndLanguagesNoList { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public async Task OnGetAsync()
        {
            AllBooks = await _context.Books
                .Include(s => s.User)
                .Include(s => s.BooksAndAuthors)
                .Include(s => s.BooksAndCategories)
                .Include(s => s.BooksAndLanguages)
                .Where(s => s.Borrowed == false)
                .ToListAsync();
            Books = await _context.Books
                .Include(s => s.User)
                .Include(s => s.BooksAndAuthors)
                .Include(s => s.BooksAndCategories)
                .Include(s => s.BooksAndLanguages)
                .Where(s => s.Borrowed == false)
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

            //IQueryable<string> AuthorQuery = from m in _context.Books
            //                                orderby m.BooksAndAuthors
            //                                select m.BooksAndAuthors;
            var book = from m in _context.Books
                       select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                book = book.Where(s => s.Title!.Contains(SearchString));
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

  

        
    }
}