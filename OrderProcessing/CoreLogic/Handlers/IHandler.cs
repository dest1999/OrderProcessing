namespace OrderProcessing
{
    public interface IHandler
    {
        Task<bool> TryToHandleOrder(Order order);
        //bool TryToHandleOrder(Order order);
    }
}
