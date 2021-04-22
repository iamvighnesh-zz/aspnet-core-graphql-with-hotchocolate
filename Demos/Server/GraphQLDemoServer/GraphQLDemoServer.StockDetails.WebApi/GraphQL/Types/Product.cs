using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDemoServer.StockDetails.WebApi.GraphQL.Types
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ExternalProductId { get; set; }

        [Required]
        public int SizeId { get; set; }

        [Required]
        public int InStock { get; set; }

        public SizeInfo Size { get; set; }
    }

    public class ProductStock
    {
        public int ProductId { get; set; }

        public int InStock { get; set; }

        public string Size { get; set; }
    }
}
