namespace OrderProcessing
{
    public class OrderDTO
    {
        public string OrderNumber { get; set; }
        public List<Product> Products { get; set; }
        public string CreatedAt { get; set; }
    }
}
