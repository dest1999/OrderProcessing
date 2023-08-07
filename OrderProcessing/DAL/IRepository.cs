namespace OrderProcessing
{
    public interface IRepository<T> where T : Order
    {
        int Create(T entity);
        T Read(OrderStatus status);
        IEnumerable<T> ReadAll(OrderStatus status);
        bool Update(T entity);
    }
}
