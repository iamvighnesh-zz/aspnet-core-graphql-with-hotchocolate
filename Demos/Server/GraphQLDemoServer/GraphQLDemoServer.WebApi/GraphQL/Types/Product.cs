using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDemoServer.WebApi.GraphQL.Types
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string imageAddress { get; set; }
    }
}
