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
        private IErrorLogger _errorLogger;

        public MainProcessingContainer(IRepository<Order> repository, IErrorLogger errorLogger)
        {
            _repository = repository;
            _errorLogger = errorLogger;
        }

        public async Task StartAsync(IEnumerable<IHandler> handlers)
        {
            _orders = await _repository.ReadAllByStatusAsync(OrderStatus.New);
            
            foreach (var order in _orders)
            {
                foreach (var handler in handlers)
                {
                    try
                    {
                        if (handler.IsOrderMatching(order).Result)
                        {
                            string str = handler.ChangeOrderJSON(order.SourceOrder);
                            order.ConvertedOrder = str;
                            order.OrderStatus = OrderStatus.ProcessedSuccessfully;
                            await _repository.UpdateAsync(order);
                            break;
                        }
                    }
                    catch (Exception e)
                    {//TODO выделить для исключения специфический класс
                        order.OrderStatus = OrderStatus.Error;
                        await _repository.UpdateAsync(order);
                        _errorLogger.WriteToLog($"{DateTime.Now}: {e.Message}");
                        break;
                    }
                }
            }
        }
    }
}
