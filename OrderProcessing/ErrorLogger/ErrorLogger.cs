using System.Collections.Concurrent;

namespace OrderProcessing
{
    public class ErrorLogger : IErrorLogger
    {
        private ConcurrentQueue<string> _errors = new();
        public void WriteToLog(string message)
        {
            _errors.Enqueue(message);
            WriteMessageToFile();
        }

        private void WriteMessageToFile()
        {
            while (_errors.Count > 0)
            {
                if (_errors.TryDequeue(out string message))
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(10_000);//возможно задание в части задержки записи ошибки в лог понято некорректно
                        File.AppendAllText("ErrorMessages.log", $"Writing at {DateTime.Now} message:\n{message}\n");
                        Thread.Sleep(10_000);
                    });

                };
            }
        }
    }
}
