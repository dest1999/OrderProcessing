namespace OrderProcessing.CoreLogic.Handlers
{
    public class Zomato : IHandler
    {
        public bool IsSuccess(Order order)
        {
            if (order.SystemType == SystemType.zomato)
            {

                Console.WriteLine("Zomato detected");
                Console.WriteLine($"Order number: {order.OrderNumber}");

                return true;
            }
            return false;
        }
    }
}
