namespace OrderProcessing.CoreLogic.Handlers
{
    public class Zomato : IHandler
    {
        public bool TryToHandleOrder(Order order)
        {
            if (order.SystemType == SystemType.zomato)
            {
                //TODO Выделить исключение в отдельный класс
                throw new Exception("Zomato detected");
            }
            return false;
        }
    }
}
