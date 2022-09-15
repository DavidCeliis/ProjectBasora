using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectBasora.Data;
using ProjectBasora.Models;

namespace ProjectBasora.Pages
{
    public class TestModel : PageModel

    {
        private IWebHostEnvironment _environment;
        private readonly ILogger<TestModel> _logger;
        private readonly ApplicationDbContext _context;

        public TestModel(ILogger<TestModel> logger, ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _logger = logger;
            _context = context;
        }

        public IList<Book> Books { get; set; }
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
            Books = await _context.Books
                .Include(s => s.User)
                .Include(s => s.BooksAndAuthors)
                .Include(s => s.BooksAndCategories)
                .Include(s => s.BooksAndLanguages)
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


            //foreach (Author i in _context.Authors)
            //{
            //    if (BooksAndAuthors.FirstOrDefault(c => c.AuthorId == i.AuthorId) == null)
            //    {
            //        i.BookIncludeAuthors = null;
            //    }
            //    else
            //    {
            //        BooksAndAuthorsNoList = BooksAndAuthors.First(c => c.AuthorId == i.AuthorId);
            //        i.BookIncludeAuthors = BooksAndAuthorsNoList.Book;
            //    }


            //}
            //foreach (Languages i in _context.Languages)
            //{
            //    if (BooksAndLanguages.FirstOrDefault(c => c.LanguageId == i.LanguageId) == null)
            //    {
            //        i.BookInclude = null;
            //    }
            //    else
            //    {
            //        BooksAndLanguagesNoList = BooksAndLanguages.First(c => c.LanguageId == i.LanguageId);
            //        i.BookInclude = BooksAndLanguagesNoList.Book;
            //    }


            //}
            //foreach (Categories i in _context.Categories)
            //{
            //    if (BooksAndCategories.FirstOrDefault(c => c.CategoryId == i.CategoryId) == null)
            //    {
            //        i.BookInclude = null;
            //    }
            //    else
            //    {
            //        BooksAndCategoriesNoList = BooksAndCategories.First(c => c.CategoryId == i.CategoryId);
            //        i.BookInclude = BooksAndCategoriesNoList.Book;
            //    }


            //}
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