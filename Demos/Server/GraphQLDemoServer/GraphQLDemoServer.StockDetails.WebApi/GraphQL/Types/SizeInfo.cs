using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GraphQLDemoServer.StockDetails.WebApi.GraphQL.Types
{
    public class SizeInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public IQueryable<Product> Products { get; set; }
    }
}
