namespace Master.Microservices.Orders.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAvailable { get; set; }

        public ProductCategoryViewModel Category { get; set; }
    }
}
