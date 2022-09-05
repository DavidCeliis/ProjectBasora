using ProjectBasora.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectBasora.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<BooksAndAuthors> BooksAndAuthors { get; set; }
        public DbSet<BooksAndCategories> BooksAndCategories { get; set; }
        public DbSet<BooksAndLanguages> BooksAndLanguages { get; set; }
        public DbSet<Borrowing> Borrowing { get; set; }
        public DbSet<Searching> Searchings { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }
        //public DbSet<UserReview_book> UserReviewsBooks { get; set; }
        //public DbSet<UserReview_bookCondition> UserReview_BookConditions { get; set; }
        //public DbSet<UserReview_user> UserReview_Users { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Thumbnail>().HasKey(t => new { t.BookId, t.Type });

            mb.Entity<BooksAndAuthors>()
                .HasKey(bc => new { bc.AuthorId, bc.BookId });
            mb.Entity<BooksAndAuthors>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BooksAndAuthors)
                .HasForeignKey(bc => bc.BookId).OnDelete(DeleteBehavior.NoAction);

            mb.Entity<BooksAndAuthors>()
                .HasOne(bc => bc.Author)
                .WithMany(c => c.BooksAndAuthors)
                .HasForeignKey(bc => bc.AuthorId).OnDelete(DeleteBehavior.NoAction);

            mb.Entity<BooksAndLanguages>()
              .HasKey(bc => new { bc.LanguageId, bc.BookId });
            mb.Entity<BooksAndLanguages>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BooksAndLanguages)
                .HasForeignKey(bc => bc.BookId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<BooksAndLanguages>()
                .HasOne(bc => bc.Languages)
                .WithMany(c => c.BooksAndLanguages)
                .HasForeignKey(bc => bc.LanguageId).OnDelete(DeleteBehavior.NoAction);

            mb.Entity<BooksAndCategories>()
             .HasKey(bc => new { bc.CategoryId, bc.BookId });
            mb.Entity<BooksAndCategories>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BooksAndCategories)
                .HasForeignKey(bc => bc.BookId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<BooksAndCategories>()
                .HasOne(bc => bc.Categories)
                .WithMany(c => c.BooksAndCategories)
                .HasForeignKey(bc => bc.CategoryId).OnDelete(DeleteBehavior.NoAction);

            //mb.Entity<Borrowing>()
            // .HasKey(bc => new { bc.BorrowingReaders, bc.BookId, bc.BorrowingRenters });


            //mb.Entity<Borrowing>()
            //    .HasOne(bc => bc.Book)
            //    .WithMany(b => b.Borrowing)
            //    .HasForeignKey(bc => bc.BookId).OnDelete(DeleteBehavior.NoAction); 
            //mb.Entity<Borrowing>()
            //    .HasMany(bc => bc.BorrowingRenters)
            //    .WithOne(c => c.BorrowingRenter)
            //    .HasForeignKey(bc => bc.BorrowingRenterId).OnDelete(DeleteBehavior.NoAction);
            //mb.Entity<Borrowing>()
            //.HasMany(bc => bc.BorrowingReaders)
            //.WithOne(c => c.BorrowingReader)
            //.HasForeignKey(bc => bc.BorrowingReaderId).OnDelete(DeleteBehavior.NoAction);


            //mb.Entity<UserReview_bookCondition>()
            //    .HasOne(x => x.Reviewer)
            //    .WithOne(x => x.userReview_BookCondition)

            //   .IsRequired().OnDelete(DeleteBehavior.ClientSetNull);

            //mb.Entity<UserReview_bookCondition>().HasOne(x => x.Renter).WithOne(x => x.userRenter_BookCondition)
            //            .IsRequired().OnDelete(DeleteBehavior.ClientSetNull);

            mb.Entity<Languages>().HasData(new Languages { LanguageId = 1, LanguageName = "English" });
            mb.Entity<Languages>().HasData(new Languages { LanguageId = 2, LanguageName = "Spanish" });
            mb.Entity<Languages>().HasData(new Languages { LanguageId = 3, LanguageName = "German" });
            mb.Entity<Languages>().HasData(new Languages { LanguageId = 4, LanguageName = "Czech" });
            mb.Entity<Languages>().HasData(new Languages { LanguageId = 5, LanguageName = "Polish" });
            mb.Entity<Languages>().HasData(new Languages { LanguageId = 6, LanguageName = "Italian" });
            mb.Entity<Languages>().HasData(new Languages { LanguageId = 7, LanguageName = "French" });

            mb.Entity<Categories>().HasData(new Categories { CategoryId = 1, CategoryName = "Thriller" });
            mb.Entity<Categories>().HasData(new Categories { CategoryId = 2, CategoryName = "Mystery" });
            mb.Entity<Categories>().HasData(new Categories { CategoryId = 3, CategoryName = "Horror" });
            mb.Entity<Categories>().HasData(new Categories { CategoryId = 4, CategoryName = "Historical" });
            mb.Entity<Categories>().HasData(new Categories { CategoryId = 5, CategoryName = "Romance" });
            mb.Entity<Categories>().HasData(new Categories { CategoryId = 6, CategoryName = "Literary Fiction" });

            mb.Entity<Author>().HasData(new Author { AuthorId = 1, AuthorName = "William Shakespeare" });
            mb.Entity<Author>().HasData(new Author { AuthorId = 2, AuthorName = "Agatha Christie" });
            mb.Entity<Author>().HasData(new Author { AuthorId = 3, AuthorName = "Barbara Cartland" });
            mb.Entity<Author>().HasData(new Author { AuthorId = 4, AuthorName = "Danielle Steel" });
            mb.Entity<Author>().HasData(new Author { AuthorId = 5, AuthorName = "Harold Robbins" });




        }
    }
}