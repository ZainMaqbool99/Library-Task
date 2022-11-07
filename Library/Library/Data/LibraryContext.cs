using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; } = default!;

        public DbSet<SubCategories> SubCategories { get; set; }

        public DbSet<Authors> Authors { get; set; }

        public DbSet<BookDetails> BookDetails { get; set; }
    }
}
