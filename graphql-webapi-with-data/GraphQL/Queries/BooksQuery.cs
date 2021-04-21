using graphql_webapi_with_data.GraphQL.Data;
using graphql_webapi_with_data.GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace graphql_webapi_with_data.GraphQL.Queries
{
    public class BooksQuery
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> SearchBooks(string title, [ScopedService] ApplicationDbContext context) => context.Books.Where(b => b.Title.Contains(title));

        [UseDbContext(typeof(ApplicationDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public Book GetBookById(int bookId, [ScopedService] ApplicationDbContext context) => context.Books.FirstOrDefault(b => b.Id == bookId);
    }
}
