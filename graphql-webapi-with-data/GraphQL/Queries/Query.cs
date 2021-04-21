using graphql_webapi_with_data.GraphQL.Data;
using graphql_webapi_with_data.GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace graphql_webapi_with_data.GraphQL.Queries
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> SearchBooks(string title, [ScopedService] ApplicationDbContext context) => context.Books.Where(b => b.Title.Contains(title));

        [UseDbContext(typeof(ApplicationDbContext))]
        public Book GetBookById(int bookId, [ScopedService] ApplicationDbContext context) => context.Books.FirstOrDefault(b => b.Id == bookId);

        [UseDbContext(typeof(ApplicationDbContext))]
        public Author GetAuthorById(int authorId, [ScopedService] ApplicationDbContext context) => context.Authors.FirstOrDefault(b => b.Id == authorId);
    }
}
