using GraphQLDemoServer.StockDetails.WebApi.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLDemoServer.StockDetails.WebApi.GraphQL.Types
{
    public class SizeInfoType : ObjectType<SizeInfo>
    {
        protected override void Configure(IObjectTypeDescriptor<SizeInfo> descriptor)
        {
            descriptor
                .Field(p => p.Products)
                .ResolveWith<SizeProductsResolver>(r => r.GetProducts(default!, default!))
                .UseDbContext<AppDbContext>();
        }

        private class SizeProductsResolver
        {
            public IQueryable<Product> GetProducts(SizeInfo sizeInfo, [ScopedService] AppDbContext context)
            {
                return context.Products.Where(p => p.SizeId == sizeInfo.Id);
            }
        }
    }
}
