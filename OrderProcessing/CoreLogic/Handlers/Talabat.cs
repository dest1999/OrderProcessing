//принимает JSON заказа и меняет все положительные цены в заказе на отрицательные. Возвращает измененный заказ.
//Продукты которые нужно обработать содержаться в коллекции products. Цены содержаться в поле paidPrice
using System.Text.Json;

namespace OrderProcessing
{
    public class Talabat : IHandler
    {
        public string ChangeOrderJSON(string inputJSON)
        {
            var orderJSON = JsonSerializer.Deserialize<OrderJSON>(inputJSON);

            foreach (var product in orderJSON.Products)
            {
                if (int.TryParse(product.PaidPrice, out int price))
                {
                    price = -1 * price;
                    product.PaidPrice = price.ToString();
                }
            }

            var returnValue = JsonSerializer.Serialize(orderJSON);
            return returnValue;
        }

        public async Task<bool> IsOrderMatching(Order order)
        {
            if (order.SystemType == SystemType.talabat)
            {
                return true;
            }
            return false;
        }
    }
}
