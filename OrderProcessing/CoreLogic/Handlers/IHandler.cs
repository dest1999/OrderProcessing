namespace OrderProcessing
{
    public interface IHandler
    {
        bool TryToHandleOrder(Order order);
    }
}
