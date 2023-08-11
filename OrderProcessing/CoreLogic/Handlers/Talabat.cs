using System.Text;
using System.Text.Json;

namespace OrderProcessing
{
    public class Talabat : IHandler
    {
        private OrderDTO _orderDTO;

        public async Task<bool> TryToHandleOrder(Order order)
        {
            if (order.SystemType == SystemType.talabat)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(order.SourceOrder);
                MemoryStream stream = new (byteArray);


                _orderDTO = await JsonSerializer.DeserializeAsync<OrderDTO>(stream);

                foreach (var product in _orderDTO.Products)
                {
                    if (int.TryParse(product.PaidPrice, out int price))
                    {
                        price *= -1;
                        product.PaidPrice = price.ToString();
                    }
                }
                order.ConvertedOrder = JsonSerializer.Serialize(_orderDTO);

                //WorkJSON(order);
                return true;
            }
            return false;
        }
        /*
         принимает JSON заказа и меняет все положительные цены в заказе на отрицательные. Возвращает измененный заказ.
         Продукты которые нужно обработать содержаться в коллекции products. Цены содержаться в поле paidPrice
         */
        private void WorkJSON(Order order)
        {
            _orderDTO = JsonSerializer.Deserialize<OrderDTO>(order.SourceOrder);

            foreach (var product in _orderDTO.Products)
            {
                if (int.TryParse(product.PaidPrice, out int price))
                {
                    price *= -1;
                    product.PaidPrice = price.ToString();
                }
            }
            order.ConvertedOrder = JsonSerializer.Serialize(_orderDTO);
        }
    }
}
