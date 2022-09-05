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



            mb.Entity<UserAndBorrow>()
               .HasKey(bc => new { bc.RenterId, bc.BookId, bc.UserId, bc.BorrowingId });
            mb.Entity<UserAndBorrow>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.UserAndBorrow)
                .HasForeignKey(bc => bc.BookId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserAndBorrow>()
                .HasOne(bc => bc.Renter)
                .WithMany(c => c.UserAndBorrowRenters)
                .HasForeignKey(bc => bc.RenterId)
                .HasPrincipalKey(t => t.Id).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserAndBorrow>()
              .HasOne(bc => bc.User)
              .WithMany(c => c.UserAndBorrowUsers)
              .HasForeignKey(bc => bc.UserId)
              .HasPrincipalKey(t => t.Id).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserAndBorrow>()
             .HasOne(bc => bc.Borrowing)
             .WithMany(c => c.UserAndBorrow)
             .HasForeignKey(bc => bc.BorrowingId).OnDelete(DeleteBehavior.NoAction);


            mb.Entity<UserReview_bookRelation>()
        .HasKey(bc => new { bc.BookISBN, bc.UserId, bc.UserReview_bookId });
            mb.Entity<UserReview_bookRelation>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.UserReview_bookRelation)
                .HasForeignKey(bc => bc.BookISBN).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserReview_bookRelation>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UserReview_bookRelationUsers)
                .HasForeignKey(bc => bc.UserId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserReview_bookRelation>()
        .HasOne(bc => bc.UserReview_book)
        .WithMany(c => c.UserReview_bookRelation)
        .HasForeignKey(bc => bc.UserReview_bookId).OnDelete(DeleteBehavior.NoAction);



            mb.Entity<UserReview_bookConditionRelation>()
               .HasKey(bc => new { bc.RatedId, bc.BookId, bc.UserId, bc.UserReview_bookConditionId });
            mb.Entity<UserReview_bookConditionRelation>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.UserReview_bookConditionRelation)
                .HasForeignKey(bc => bc.BookId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserReview_bookConditionRelation>()
                .HasOne(bc => bc.Rated)
                .WithMany(c => c.UserReview_bookConditionRelationRateds)
                .HasForeignKey(bc => bc.RatedId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserReview_bookConditionRelation>()
              .HasOne(bc => bc.User)
              .WithMany(c => c.UserReview_bookConditionRelationUsers)
              .HasForeignKey(bc => bc.UserId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserReview_bookConditionRelation>()
             .HasOne(bc => bc.UserReview_bookCondition)
             .WithMany(c => c.UserReview_bookConditionRelation)
             .HasForeignKey(bc => bc.UserReview_bookConditionId).OnDelete(DeleteBehavior.NoAction);


            mb.Entity<UserReview_userRelation>()
             .HasKey(bc => new { bc.RatedId, bc.UserId, bc.UserReview_userId });
            mb.Entity<UserReview_userRelation>()
                .HasOne(bc => bc.Rated)
                .WithMany(c => c.UserReview_userRelationRateds)
                .HasForeignKey(bc => bc.RatedId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserReview_userRelation>()
              .HasOne(bc => bc.User)
              .WithMany(c => c.UserReview_userRelationUsers)
              .HasForeignKey(bc => bc.UserId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<UserReview_userRelation>()
             .HasOne(bc => bc.UserReview_user)
             .WithMany(c => c.UserReview_userRelation)
             .HasForeignKey(bc => bc.UserReview_userId).OnDelete(DeleteBehavior.NoAction);
            //mb.Entity<Borrowing>()
            // .HasKey(bc => new { bc.BorrowingReader, bc.BookId, bc.BorrowingRenter });
            //mb.Entity<Borrowing>()
            //    .HasOne(bc => bc.Book)
            //    .WithMany(b => b.Borrowing)
            //    .HasForeignKey(bc => bc.BookId).OnDelete(DeleteBehavior.NoAction);
            //mb.Entity<Borrowing>()
            //    .HasOne(bc => bc.BorrowingRenter)
            //    .WithMany(c => c.Renters)
            //    .HasForeignKey(bc => bc.BorrowingRenterId).OnDelete(DeleteBehavior.NoAction);
            //mb.Entity<Borrowing>()
            //.HasOne(bc => bc.BorrowingReader)
            //.WithMany(c => c.Users)
            //.HasForeignKey(c => c.BorrowingReaderId).OnDelete(DeleteBehavior.NoAction);


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
            mb.Entity<Author>().HasData(new Author { AuthorId = 6, AuthorName = "George Orwell" });

            mb.Entity<ApplicationUser>().HasData(new ApplicationUser { UserSurname ="David", UserLastname = "Celis", UserNick = "OWNERcelis", Street="Gen. Svob", City="Madrid", State="Spain", PostCode= 23344, Vertification = true, UserType="OWNER", IDtype="", IDnumber= 1, Limit= 10000, UserName ="davceli019@pslib.cz", Email= "davceli019@pslib.cz", PasswordHash="", Id="owner1" });

            mb.Entity<Book>().HasData(new Book { BookId = 1, Title = "1984", ISBN= "9780140862539", Public = true, Borrowed = false, UploadedAt = DateTime.Now, BookBinding = "soft", NumberPages = 224, UserId= "owner1" });

            mb.Entity<BooksAndAuthors>().HasData(new BooksAndAuthors { AuthorId = 6, BookId =1, UserId ="owner1" });






        }
    }
}