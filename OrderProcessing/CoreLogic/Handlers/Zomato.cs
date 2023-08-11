//принимает JSON заказа и делит все цены в заказе на количество позиций (price / quantity).
//Возвращает измененный заказ (Продукты которые нужно обработать содержатся в коллекции products.
//Цены содержатся в поле paidPrice, количество в поле quantity)
using System.Text.Json;

namespace OrderProcessing
{
    public class Zomato : IHandler
    {
        public string ChangeOrderJSON(string inputJSON)
        {
            var orderJSON = JsonSerializer.Deserialize<OrderJSON>(inputJSON);

            foreach (var product in orderJSON.Products)
            {
                if (int.TryParse(product.PaidPrice, out int price) &&
                    int.TryParse(product.Quantity, out int quantity) &&
                    price > 0 && quantity > 0)
                {
                    product.UnitPrice = ((double)price / (double)quantity).ToString();//TODO для денежных выражений лучше decimal
                }
            }
            
            var returnValue = JsonSerializer.Serialize(orderJSON);
            return returnValue;
        }

        public async Task<bool> IsOrderMatching(Order order)
        {
            if (order.SystemType == SystemType.zomato)
            {
                return true;
            }
            return false;
        }
    }
}
