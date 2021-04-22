using GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Types;
using GraphQLDemoServer.ProductDetails.WebApi.GraphQL.Data;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemoServer.ProductDetails.WebApi.GraphQL
{

    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<Brand> AddBrand(string name, [ScopedService] AppDbContext context)
        {
            var brand = new Brand
            {
                Name = name
            };

            context.Brands.Add(brand);

            await context.SaveChangesAsync();

            return context.Brands.Where(b => b.Name == name).FirstOrDefault();
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<ProductDetail> AddProduct(string title, string imageAddress, int brandId, [ScopedService] AppDbContext context)
        {
            var product = new ProductDetail
            {
                Title = title,
                ImageAddress = imageAddress,
                BrandId = brandId
            };

            context.Products.Add(product);

            await context.SaveChangesAsync();

            return context.Products.Where(b => b.Title == title && b.BrandId == brandId).FirstOrDefault();
        }
    }
}
