namespace OrderProcessing
{
    public interface IRepository<T> where T : Order
    {
        Task<int> CreateAsync(T entity);
        T Read(OrderStatus status);
        Task<IEnumerable<T>> ReadAllByStatusAsync(OrderStatus status);
        Task<int> UpdateAsync(Order entity);
    }
}
