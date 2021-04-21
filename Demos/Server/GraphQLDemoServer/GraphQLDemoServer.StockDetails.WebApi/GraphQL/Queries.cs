using GraphQLDemoServer.StockDetails.WebApi.GraphQL.Data;
using GraphQLDemoServer.StockDetails.WebApi.GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQLDemoServer.StockDetails.WebApi.GraphQL
{
    public class Queries
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public SizeInfo GetSizeInfoByName(string name, [ScopedService] AppDbContext context)
        {
            return context.Sizes
                .Where(b => b.Name == name)
                .FirstOrDefault();
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Product> SearchProductsById(int productId, [ScopedService] AppDbContext context)
        {
            return context.Products.Where(b => b.ExternalProductId == productId);
        }
    }
}
