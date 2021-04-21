using graphql_webapi_with_data.GraphQL.Types;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_webapi_with_data.GraphQL
{
    public class Subscription
    {
        [Topic]
        [Subscribe]
        public Author OnAuthorAdded([EventMessage] Author author)
        {
            return author;
        }

        [Topic]
        [Subscribe]
        public Book OnBookAdded([EventMessage] Book book)
        {
            return book;
        }
    }
}
