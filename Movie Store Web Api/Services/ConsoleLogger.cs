using System;

namespace Movie_Store_Web_Api.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] - "+message);
        }
    }
}
