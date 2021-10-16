using Master.Microservices.Common.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Microservices.Orders.DataAccess.Models
{
    [Table("ProductCategory", Schema = "Orders")]
    public class ProductCategory : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}
