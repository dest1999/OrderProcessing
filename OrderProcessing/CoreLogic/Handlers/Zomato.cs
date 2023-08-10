namespace OrderProcessing.CoreLogic.Handlers
{
    public class Zomato : IHandler
    {
        public bool TryToHandleOrder(Order order)
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
