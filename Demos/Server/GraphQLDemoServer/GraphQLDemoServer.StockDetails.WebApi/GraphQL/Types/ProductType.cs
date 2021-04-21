using GraphQLDemoServer.StockDetails.WebApi.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLDemoServer.StockDetails.WebApi.GraphQL.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor
                .Field(p => p.Size)
                .ResolveWith<ProductSizeResolver>(r => r.GetSize(default!, default!))
                .UseDbContext<AppDbContext>();
        }

        private class ProductSizeResolver
        {
            public SizeInfo GetSize(Product product, [ScopedService] AppDbContext context)
            {
                return context.Sizes
                    .Where(p => p.Id == product.SizeId)
                    .FirstOrDefault();
            }
        }
    }
}
