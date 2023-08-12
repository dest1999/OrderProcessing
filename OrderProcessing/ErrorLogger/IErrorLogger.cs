namespace OrderProcessing
{
    public interface IErrorLogger
    {
        void WriteToLog(string message);
    }
}
