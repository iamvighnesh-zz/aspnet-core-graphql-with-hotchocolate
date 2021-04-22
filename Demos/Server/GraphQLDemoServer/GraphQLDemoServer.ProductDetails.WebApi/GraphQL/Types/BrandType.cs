using GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Types
{
    public class BrandType : ObjectType<Brand>
    {
        protected override void Configure(IObjectTypeDescriptor<Brand> descriptor)
        {
            descriptor
                .Field(f => f.Products)
                .ResolveWith<BrandProductsResolver>(b => b.GetProducts(default!, default!))
                .UseDbContext<AppDbContext>();
        }

        private class BrandProductsResolver
        {
            public IQueryable<ProductDetail> GetProducts(Brand brand, [ScopedService] AppDbContext context)
            {
                return context.Products.Where(p => p.BrandId == brand.Id);
            }
        }
    }
}
