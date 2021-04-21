using graphql_webapi_with_data.GraphQL.Data;
using graphql_webapi_with_data.GraphQL.Types;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace graphql_webapi_with_data.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<Book> AddBook(
            string title, 
            int authorId,
            string isbn,
            bool isPaperback,
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                Title = title,
                AuthorId = authorId,
                ISBN = isbn,
                IsPaperback = isPaperback
            };

            context.Books.Add(book);

            await context.SaveChangesAsync(cancellationToken);

            var result = context.Books.First(b => b.Title == title && b.AuthorId == authorId);

            await eventSender.SendAsync(nameof(Subscription.OnBookAdded), result, cancellationToken);

            return result;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<Author> AddAuthor(
            string name, 
            [ScopedService] ApplicationDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var author = new Author()
            {
                Name = name
            };

            context.Authors.Add(author);

            await context.SaveChangesAsync();

            var result = context.Authors.First(b => b.Name == name);

            await eventSender.SendAsync(nameof(Subscription.OnAuthorAdded), result, cancellationToken);

            return result;
        }
    }
}
