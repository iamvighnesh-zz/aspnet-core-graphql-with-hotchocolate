using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace graphql_webapi_with_data.GraphQL.Types
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public bool IsPaperback { get; set; }

        public Author Author { get; set; }
    }
}
