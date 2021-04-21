using graphql_webapi_with_data.GraphQL.Data;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace graphql_webapi_with_data.GraphQL.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor
                .Field(p => p.Author)
                .ResolveWith<BookAuthorResovler>(p => p.GetAuthor(default!, default!))
                .UseDbContext<ApplicationDbContext>();
        }

        private class BookAuthorResovler
        {
            public Author GetAuthor(Book book, [ScopedService] ApplicationDbContext context)
            {
                return context.Authors
                    .Where(a => a.Id == book.AuthorId)
                    .FirstOrDefault();
            }
        }
    }
}
