using Master.Microservices.Common.Bases;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}
