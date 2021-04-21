using graphql_webapi_with_data.GraphQL.Data;
using graphql_webapi_with_data.GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_webapi_with_data.GraphQL.Mutations
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<Book> AddBook(string title, int authorId, [ScopedService] ApplicationDbContext context)
        {
            var book = new Book()
            {
                Title = title,
                AuthorId = authorId,
                Author = context.Authors.Find(authorId)
            };

            context.Books.Add(book);

            await context.SaveChangesAsync();

            return context.Books.First<Book>(b => b.Title == title && b.AuthorId == authorId);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<Author> AddAuthor(string name, [ScopedService] ApplicationDbContext context)
        {
            var author = new Author()
            {
                Name = name
            };

            context.Authors.Add(author);

            await context.SaveChangesAsync();

            return context.Authors.First<Author>(b => b.Name == name);
        }
    }
}
