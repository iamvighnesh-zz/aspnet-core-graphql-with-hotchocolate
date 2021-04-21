using graphql_webapi_with_data.GraphQL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using graphql_webapi_with_data.GraphQL.Types;
using graphql_webapi_with_data.GraphQL.Queries;
using graphql_webapi_with_data.GraphQL.Mutations;

namespace graphql_webapi_with_data
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private const string ConnectionString = "Server=tcp:vm-uks-graphql-demo-server.database.windows.net,1433;Initial Catalog=GraphQLDemo;Persist Security Info=False;User ID=vighneshwar;Password=Nationwide#123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>((s, o) => o.UseSqlServer(ConnectionString));

            services
                .AddGraphQLServer()
                .AddType<Book>()
                .AddType<Author>()
                .AddQueryType<BooksQuery>()
                .AddMutationType<BooksMutation>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();
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
