using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessing
{
    // Order to store in DB
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("system_type")]
        public SystemType SystemType { get; set; }

        [Column("order_number")]
        public int OrderNumber { get; set; }

        [Column("source_order")]
        public string SourceOrder { get; set; }

        [Column("converted_order")]
        public string ConvertedOrder { get; set; }

        [Column("order_status")]
        public OrderStatus OrderStatus { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
