using graphql_webapi_with_data.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace graphql_webapi_with_data.GraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Author>()
                .HasMany(t => t.Books)
                .WithOne(t => t.Author)
                .HasForeignKey(t => t.AuthorId);

            builder
                .Entity<Book>()
                .HasOne(t => t.Author)
                .WithMany(t => t.Books)
                .HasForeignKey(t => t.AuthorId);
        }
    }
}
