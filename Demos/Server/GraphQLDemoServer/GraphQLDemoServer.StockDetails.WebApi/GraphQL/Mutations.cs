using GraphQLDemoServer.StockDetails.WebApi.GraphQL.Data;
using GraphQLDemoServer.StockDetails.WebApi.GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemoServer.StockDetails.WebApi.GraphQL
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<SizeInfo> AddSizeInfo(string name, [ScopedService] AppDbContext context)
        {
            var size = new SizeInfo
            {
                Name = name
            };

            context.Sizes.Add(size);

            await context.SaveChangesAsync();

            return context.Sizes.Where(b => b.Name == name).FirstOrDefault();
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<Product> AddProduct(int productId, int sizeId, int inStock, [ScopedService] AppDbContext context)
        {
            var product = new Product
            {
                ExternalProductId = productId,
                SizeId = sizeId,
                InStock = inStock
            };

            context.Products.Add(product);

            await context.SaveChangesAsync();

            return context.Products.Where(b => b.Id == productId && b.SizeId == sizeId).FirstOrDefault();
        }
    }
}
