using System.Text.Json;

namespace OrderProcessing
{
    public interface IInputOrderHandler
    {
        public Task CreateNewOrderAsync(SystemType systemType, string incomingJSON);
    }

    public class InputOrderHandler : IInputOrderHandler
    {
        private IRepository<Order> _repository;

        public InputOrderHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task CreateNewOrderAsync(SystemType systemType, string incomingJSON)
        {
            try
            {
                var jsonDocumentRoot = JsonDocument.Parse(incomingJSON).RootElement;

                //Если значение извлеклось успешно то сохраняем в БД
                if (int.TryParse(jsonDocumentRoot.GetProperty("orderNumber").ToString(), out int orderNumber))
                {
                    await _repository.CreateAsync(new Order()
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
        }
    }
}
