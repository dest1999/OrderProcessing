namespace OrderProcessing
{
    public class SQLiteOrderRepository : IRepository<Order>
    {
        private readonly DataContext _dataContext;

        public SQLiteOrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Create(Order entity)
        {
            _dataContext.Orders.Add(entity);
            _dataContext.SaveChanges();
            int returnValue = 0;
            return returnValue;
        }

        public Order Read(OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ReadAll(OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
