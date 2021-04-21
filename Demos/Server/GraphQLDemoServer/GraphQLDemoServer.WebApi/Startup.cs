using GraphQLDemoServer.WebApi.GraphQL;
using GraphQLDemoServer.WebApi.GraphQL.Data;
using GraphQLDemoServer.WebApi.GraphQL.Types;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLDemoServer.WebApi
{
    public class Startup
    {
        private const int MaxRequestSizeInBytes = 1024 * 1024 * 1; //1MB

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ProductCatelogueConnection"));
            });

            services
                .AddGraphQLServer()
                .AddQueryType<Queries>()
                .AddMutationType<Mutations>()
                .AddType<BrandType>()
                .AddType<ProductType>()
                .AddFiltering()
                .AddSorting();

            services.AddApplicationInsightsTelemetry();
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
