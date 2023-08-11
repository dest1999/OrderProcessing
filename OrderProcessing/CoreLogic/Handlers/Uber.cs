namespace OrderProcessing
{
    public class Uber : IHandler
    {
        public string ChangeOrderJSON(string json)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsOrderMatching(Order order)
        {
            if (order.SystemType == SystemType.uber)
            {
                //TODO Выделить исключение в отдельный класс
                throw new Exception("Uber detected");
            }
            return false;
        }
    }
}
