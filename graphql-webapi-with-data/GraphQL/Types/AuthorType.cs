using graphql_webapi_with_data.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace graphql_webapi_with_data.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor
                .Field(p => p.Books)
                .ResolveWith<AuthorBooksResovler>(p => p.GetBooks(default!, default!))
                .UseDbContext<ApplicationDbContext>();
        }

        private class AuthorBooksResovler
        {
            public IQueryable<Book> GetBooks(Author author, [ScopedService] ApplicationDbContext context)
            {
                return context.Books.Where(a => a.AuthorId == author.Id);
            }
        }
    }
}
