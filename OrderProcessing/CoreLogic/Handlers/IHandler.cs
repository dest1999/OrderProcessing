namespace OrderProcessing
{
    public interface IHandler
    {
        bool IsSuccess(Order order);
    }
}
