namespace OrderProcessing
{
    public class Uber : IHandler
    {
        public async Task<bool> TryToHandleOrder(Order order)
        {
            if (order.SystemType == SystemType.uber)
            {
                //TODO Выделить исключение в отдельный класс
                throw new Exception("Uber detected");
            }
            return false;
        }
    }
}
