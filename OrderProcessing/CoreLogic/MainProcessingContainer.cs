namespace OrderProcessing
{
    public interface IMainProcessingContainer
    {
        Task StartAsync(IEnumerable<IHandler> handlers);
    }

    public class MainProcessingContainer : IMainProcessingContainer
    {
        private IRepository<Order> _repository;
        private IEnumerable<Order> _orders;

        public MainProcessingContainer(IRepository<Order> repository)
        {
            _repository = repository;
        }

        
        public async Task StartAsync(IEnumerable<IHandler> handlers)
        {
            Console.Clear();
            _orders = await _repository.ReadAllByStatusAsync(OrderStatus.New);
            Console.WriteLine($"Readed orders: {_orders.Count()}");
            
            foreach (var order in _orders)
            {
                foreach (var handler in handlers)
                {
                    try
                    {
                        if (handler.TryToHandleOrder(order).Result)
                        {
                            order.OrderStatus = OrderStatus.ProcessedSuccessfully;
                            await _repository.UpdateAsync(order);
                            break;
                        }
                    }
                    catch (Exception)
                    {//TODO выделить для исключения специфический класс
                        order.OrderStatus = OrderStatus.Error;
                        await _repository.UpdateAsync(order);
                        break;
                    }
                }
            }
        }
    }
}
