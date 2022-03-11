using System;
using UnluCoProductCatalog.Application.Interfaces.LogInterfaces;

namespace UnluCoProductCatalog.Persistence.Services.LogService
{
    public class ConsoleLoggerService :ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
