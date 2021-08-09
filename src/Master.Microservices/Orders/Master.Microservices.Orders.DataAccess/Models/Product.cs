using Master.Microservices.Common.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class Product : EntityBase
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAvailable { get; set; }

        public ProductCategory Category { get; set; }
    }
}
