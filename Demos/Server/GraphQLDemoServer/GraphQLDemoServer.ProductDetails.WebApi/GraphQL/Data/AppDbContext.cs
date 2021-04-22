using GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductDetail> Products { get; set; }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Brand>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId);

            builder
                .Entity<ProductDetail>()
                .HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId);
        }
    }
}
