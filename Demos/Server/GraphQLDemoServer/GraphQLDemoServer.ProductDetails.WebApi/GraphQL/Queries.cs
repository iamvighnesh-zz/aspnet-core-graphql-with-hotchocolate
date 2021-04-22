using GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Types;
using GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Data;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQLDemoServer.ProductDetails.WebApi.GraphQL
{
    public class Queries
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public Brand GetBrandByName(string name, [ScopedService] AppDbContext context)
        {
            return context.Brands
                .Where(b => b.Name == name)
                .FirstOrDefault();
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<ProductDetail> SearchProductDetailsByTitle(string searchTerm, [ScopedService] AppDbContext context)
        {
            return context.Products
                .Where(b => b.Title.Contains(searchTerm));
        }

        [UseDbContext(typeof(AppDbContext))]
        public ProductDetail GetProductDetailsById(int productId, [ScopedService] AppDbContext context)
        {
            return context.Products.Where(b => b.Id == productId).FirstOrDefault();
        }
    }
}
