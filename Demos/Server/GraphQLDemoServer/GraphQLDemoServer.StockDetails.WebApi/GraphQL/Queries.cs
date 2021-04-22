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
        public IQueryable<ProductStock> GetProductStockById(int productId, [ScopedService] AppDbContext context)
        {
            var productStockResults = context.Products.Where(b => b.ExternalProductId == productId);

            var  result = productStockResults.Select(p => new ProductStock
            {
                ProductId = p.ExternalProductId,
                InStock = p.InStock,
                Size = p.Size.Name
            });

            return result;
        }
    }
}
