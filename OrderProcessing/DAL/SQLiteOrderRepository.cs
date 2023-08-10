using Microsoft.EntityFrameworkCore;

namespace OrderProcessing
{
    public class SQLiteOrderRepository : IRepository<Order>
    {
        private readonly DataContext _dataContext;

        public SQLiteOrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateAsync(Order entity)
        {
            var db = _dataContext;

            db.Orders.Add(entity);
            await db.SaveChangesAsync();
            int returnValue = db.Orders.OrderBy(x => x.Id).Last().Id;
            return returnValue;
        }

        public Order Read(OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> ReadAllByStatusAsync(OrderStatus status)
        {
            var db = _dataContext;
            var returnValue = await db.Orders.Where(x => x.OrderStatus == OrderStatus.New).ToListAsync() ;
            return returnValue;
        }

        public bool Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
