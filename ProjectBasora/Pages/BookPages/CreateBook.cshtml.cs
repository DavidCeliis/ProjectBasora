using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectBasora.Data;
using ProjectBasora.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;

namespace ProjectBasora.Pages.BookPages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ProjectBasora.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        private IConfiguration _configuration;
        private int _squareSize;
        private int _sameAspectRatioHeigth;
        //public IList<Book> Books { get; set; }
        //public IList<Author> Author { get; set; }
        //public Author Authors { get; set; }
        //public IList<Categories> Category { get; set; }
        //public IList<Languages> Language { get; set; }
        //public IList<BooksAndAuthors> BooksAndAuthors { get; set; }
        //public IList<BooksAndCategories> BooksAndCategories { get; set; }
        //public IList<BooksAndLanguages> BooksAndLanguages { get; set; }
        [BindProperty]
        public BooksAndAuthors BooksAndAuthors { get; set; }
        [BindProperty]
        public BooksAndCategories BooksAndCategories { get; set; }
        [BindProperty]
        public BooksAndLanguages BooksAndLanguages { get; set; }

        public Book Book { get; set; } 
        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public bool IfExist { get; set; }


        [BindProperty]
        public bool Public { get; set; } = true;
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public int Weight{ get; set; }
        [BindProperty]
        public string ISBN { get; set; }
        [BindProperty]
        public bool Borrowed { get; set; } = false;
        [BindProperty]
        public string BookBinding { get; set; }
        [BindProperty]
        public int NumberPages { get; set; }
        public int BookId { get; set; }
        public ICollection<IFormFile> UploadImage { get; set; }

        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context, IConfiguration configuration)
        {
            _environment = environment;
            _context = context;
            _configuration = configuration;
            if (Int32.TryParse(_configuration["Thumbnails:SquareSize"], out _squareSize) == false) _squareSize = 128; // získej data z konfigurave nebo použij 64
            if (Int32.TryParse(_configuration["Thumbnails:SameAspectRatioHeigth"], out _sameAspectRatioHeigth) == false) _sameAspectRatioHeigth = 320;

        }


        public async Task OnGetAsync(int Idbook)
        {
          
            var userId = User.Claims.Where(cc => cc.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
         
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "LanguageId", "LanguageName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ////ViewData["BookId"] = new SelectList(_context.Books, "BookId", "ContentType", "Title");
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");

            //Books = await _context.Books
            //    .Include(s => s.User)
            //    .Include(s => s.BooksAndAuthors)
            //    .Include(s => s.BooksAndCategories)
            //    .Include(s => s.BooksAndLanguages)
            //    .ToListAsync();
            //Author = await _context.Authors
            //    .Include(s => s.BooksAndAuthors)
            //    .ToListAsync();
            //Category = await _context.Categories
            //    .Include(s => s.BooksAndCategories)
            //    .ToListAsync();
            //Language = await _context.Languages
            //   .Include(s => s.BooksAndLanguages)
            //   .ToListAsync();

            //BooksAndAuthors = await _context.BooksAndAuthors
            //    .Include(s => s.Author)
            //    .Include(s => s.Book)
            //    .OrderBy(s => s.BookId)
            //    .ToListAsync();
            //BooksAndLanguages = await _context.BooksAndLanguages
            //    .Include(s => s.Languages)
            //    .Include(s => s.Book)
            //    .OrderBy(s => s.BookId)
            //    .ToListAsync();
            //BooksAndCategories = await _context.BooksAndCategories
            //     .Include(s => s.Categories)
            //     .Include(s => s.Book)
            //     .OrderBy(s => s.BookId)
            //     .ToListAsync();


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

      


        public async Task<IActionResult> OnPostAsync()
        {

            int successfulProcessing = 0;
            int failedProcessing = 0;
            //if (!ModelState.IsValid || _context.Books == null || Book == null)
            //{
            //    return Page();
            //}
            var userId = User.Claims.Where(cc => cc.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            //Book book = new Book { Title = Book.Title, UserId = userId, Borrowed = false, UploadedAt= DateTime.Now };
            //BookId = _context.Books.Where(f => f.BookId == BookId & f.UserId == userId).FirstOrDefault().BookId;

            foreach (var bookUpload in UploadImage) // pro každý nahrávaný soubor
            {
                Book book = new Book // vytvoříme záznam
                {
                   
                    Title = Title,
                    fileName = bookUpload.FileName,
                    UserId = userId,
                    UploadedAt = DateTime.Now,
                    ContentType = bookUpload.ContentType,
                    Public = Public = true,
                    BookBinding = BookBinding,
                    ISBN = ISBN,
                    NumberPages = NumberPages,
                    Weight = Weight,
                    Borrowed = Borrowed = false,

                };
               
                if (bookUpload.ContentType.StartsWith("image")) // je soubor obrázek?
                {
                    book.Thumbnails = new List<Thumbnail>();
                    MemoryStream ims = new MemoryStream(); // proud pro příchozí obrázek
                    MemoryStream oms1 = new MemoryStream(); // proud pro čtvercový náhled
                    MemoryStream oms2 = new MemoryStream(); // proud pro obdélníkový náhled
                    bookUpload.CopyTo(ims); // vlož obsah do vstupního proudu
                    IImageFormat format; // zde si uložíme formát obrázku (JPEG, GIF, ...), budeme ho potřebovat při ukládání
                    using (Image image = Image.Load(ims.ToArray(), out format)) // vytvoříme čtvercový náhled
                    {
                        int largestSize = Math.Max(image.Height, image.Width); // jaká je orientace obrázku?
                        if (image.Width > image.Height) // podle orientace změníme velikost obrázku
                        {
                            image.Mutate(x => x.Resize(0, _squareSize));
                        }
                        else
                        {
                            image.Mutate(x => x.Resize(_squareSize, 0));
                        }
                        image.Mutate(x => x.Crop(new Rectangle((image.Width - _squareSize) / 2, (image.Height - _squareSize) / 2, _squareSize, _squareSize)));
                        // obrázek ořízneme na čtverec
                        image.Save(oms1, format); // vložíme ho do výstupního proudu
                        book.Thumbnails.Add(new Thumbnail { Type = ThumbnailType.Square, Blob = oms1.ToArray() }); // a uložíme do databáze jako pole bytů
                    }
                    using (Image image = Image.Load(ims.ToArray(), out format)) // obdélníkový náhled začíná zde
                    {
                        image.Mutate(x => x.Resize(0, _sameAspectRatioHeigth)); // stačí jen změnit jeho velikost
                        image.Save(oms2, format); // a přes proud ho uložit do databáze
                        book.Thumbnails.Add(new Thumbnail { Type = ThumbnailType.SameAspectRatio, Blob = oms2.ToArray() });
                    }
                }
                try
                {
                    _context.Books.Add(book); // a uložíme ho
                    await _context.SaveChangesAsync(); // tím se nám vygeneruje jeho klíč ve formátu Guid
                    var file = Path.Combine(_environment.ContentRootPath, "Uploads", book.BookId.ToString());
                    // pod tímto klíčem uložíme soubor i fyzicky na disk
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await bookUpload.CopyToAsync(fileStream);
                    };
                    successfulProcessing++;
                    //BooksAndAuthors = new BooksAndAuthors { Gall = _context.Galleries.Where(g => g.UploaderId == userId).FirstOrDefault(), StoredFile = _context.Files.Where(g => g.Id == fileRecord.Id).FirstOrDefault(), UploaderId = userId };
                    //_context.PictureInGalleries.Add(PictureInGallery);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    failedProcessing++;
                }
                if (failedProcessing == 0)
                {
                    SuccessMessage = "All files has been uploaded successfuly.";
                }
                else
                {
                    ErrorMessage = "There were " + failedProcessing + " errors during uploading and processing of files.";
                }
            }

            //_context.BooksAndAuthors.Add(BooksAndAuthors);
            //_context.BooksAndLanguages.Add(BooksAndLanguages);
            //_context.BooksAndCategories.Add(BooksAndCategories);

            //SuccessMessage = "Added";
           
          
            await _context.SaveChangesAsync();
            //var bookid = _context.Books.Find().BookId;
             return RedirectToPage("../Index");
            //return RedirectToPage("/CreateConnections?bookId=" + bookid);
        }

        public IActionResult OnGetDownload(string bookname)
        {
            var fullName = Path.Combine(_environment.ContentRootPath, "Uploads", bookname);
            if (System.IO.File.Exists(bookname))
            {
                var book = _context.Books.Find(Guid.Parse(bookname));
                if (book != null) 
                {
                    return PhysicalFile(fullName, book.ContentType, book.fileName);
                
                }
                else
                {
                    ErrorMessage = "There is no record of such file.";
                    return RedirectToPage();
                }
            }
            else
            {
                ErrorMessage = "There is no such file.";
                return RedirectToPage();
            }

        }

    }
}
