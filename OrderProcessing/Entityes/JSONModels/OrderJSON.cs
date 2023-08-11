using System.Text.Json.Serialization;

namespace OrderProcessing
{
    public class OrderJSON
    {
        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
    }
}
