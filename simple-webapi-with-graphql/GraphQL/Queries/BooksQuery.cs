using simple_webapi_with_graphql.GraphQL.Types;

namespace simple_webapi_with_graphql.GraphQL.Queries
{
    public class BooksQuery
    {
        public Book GetBook() => new Book() { Title = "C# in Depth", Author = "Job Skeet" };
    }
}
