using IDA_C_sh_HomeWork_17_Pass_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSystemEventLogger
{
    internal class Logger
    {
        static internal readonly List<ValueEvent> LogEvents = new List<ValueEvent>();
        static public ValueEvent EventInfoGenerate(string method_name, Employee employee, bool result)
        {
            LogEvents.Add(new ValueEvent(method_name, employee, result));
            return LogEvents[LogEvents.Count - 1];
        }
        static public List<string> ReadLogFile(string fileName) 
        {
        return FileManager.ReadLogFile(fileName);
        }
    }
}
