namespace OrderProcessing
{
    public interface IInputOrderHandler
    {
        public void CreateNewOrder(SystemType systemType, string incomingJSON);
    }

    public class InputOrderHandler : IInputOrderHandler
    {
        private IRepository<Order> _repository;

        public InputOrderHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public void CreateNewOrder(SystemType systemType, string incomingJSON)
        {
            _repository.Create(new Order()
            {
                SystemType = systemType,
                OrderNumber = 0, //TODO need fix to real number
                SourceOrder = incomingJSON,
                ConvertedOrder = string.Empty,
                OrderStatus = OrderStatus.New,
                CreatedAt = DateTime.Now
            });
        }
    }
}
