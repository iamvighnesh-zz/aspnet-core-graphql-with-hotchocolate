using GraphQLDemoServer.StockDetails.WebApi.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemoServer.StockDetails.WebApi.GraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<SizeInfo> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(p => p.Size)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.SizeId);

            builder
                .Entity<SizeInfo>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Size)
                .HasForeignKey(p => p.SizeId);
        }
    }
}
