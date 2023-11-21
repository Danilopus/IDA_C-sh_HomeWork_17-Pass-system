using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDA_C_sh_HomeWork_17_Pass_system
{
    internal class FileManager
    {
        static public bool WriteToLogFile(PassSystemEventLogger.ValueEvent valueEvent, string filename)
        {
           if (valueEvent == null) return false;
            using (StreamWriter writer = new StreamWriter(filename, true))  
            {
                writer.WriteLine(valueEvent.ToString());
            }                        
        return true;
        }
    }
}
