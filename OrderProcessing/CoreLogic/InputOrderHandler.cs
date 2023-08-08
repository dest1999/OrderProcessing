using System.Text.Json;

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
            var jsonDocumentRoot = JsonDocument.Parse(incomingJSON).RootElement;

            //Если значение извлеклось успешно то сохраняем в БД
            if (int.TryParse(jsonDocumentRoot.GetProperty("orderNumber").ToString(), out int orderNumber))
            {
                _repository.Create(new Order()
                {
                    SystemType = systemType,
                    OrderNumber = orderNumber,
                    SourceOrder = incomingJSON,
                    ConvertedOrder = string.Empty,
                    OrderStatus = OrderStatus.New,
                    CreatedAt = DateTime.Now
                });
            }
            //TODO Сдесь нужно уточнить если значение не корректно
            //Иначе что-то не так кинем исключение?
        }
    }
}
