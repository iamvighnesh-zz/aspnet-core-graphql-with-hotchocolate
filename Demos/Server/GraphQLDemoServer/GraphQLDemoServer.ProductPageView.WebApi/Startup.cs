using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GraphQLDemoServer.ProductPageView.WebApi
{
    public class Startup
    {
        private const string ProductDetails = "productdetails";
        private const string StockDetails = "stockdetails";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient(ProductDetails, c => c.BaseAddress = new Uri("https://vm-uks-graphql-demo-productdetails-app.azurewebsites.net/graphql"));
            services.AddHttpClient(StockDetails, c => c.BaseAddress = new Uri("https://vm-uks-graphql-demo-stockdetails-app.azurewebsites.net/graphql"));

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                .AddRemoteSchema(ProductDetails, ignoreRootTypes: true)
                .AddRemoteSchema(StockDetails, ignoreRootTypes: true)
                .AddTypeExtensionsFromFile("./Stitching.graphql");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
