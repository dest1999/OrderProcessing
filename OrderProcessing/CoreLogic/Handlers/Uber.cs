namespace OrderProcessing
{
    public class Uber : IHandler
    {
        public bool IsSuccess(Order order)
        {
            if (order.SystemType == SystemType.uber)
            {

                Console.WriteLine("Uber detected");
                Console.WriteLine($"Order number: {order.OrderNumber}");

                return true;
            }
            return false;
        }
    }
}
