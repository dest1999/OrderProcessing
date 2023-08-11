namespace OrderProcessing
{
    public interface IHandler
    {
        Task<bool> IsOrderMatching(Order order);
        string ChangeOrderJSON(string json);
    }
}
