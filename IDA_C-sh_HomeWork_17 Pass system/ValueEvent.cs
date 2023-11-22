using IDA_C_sh_HomeWork_17_Pass_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSystemEventLogger
{
    internal class ValueEvent
    {
        /////   CTOR    /////

        public ValueEvent(string operation, Employee employee, bool operationResult) 
        {
            ValueEventID = ID_counter++;
            if (employee != null)   { EmploeeName = employee.ToString(); }
            else { EmploeeName = "null"; }
            if (employee.Pass != null)  { Pass = employee.Pass.ToString(); }
            Operation = operation;
            OperationResult = operationResult;
        }

        /////   PROPS   /////

        private static int ID_counter = 1;
        public int ValueEventID { private set; get; }
        public enum ACTION { RegisterEmployee , IssuePass , AccessControl }
        public ACTION Action { private set; get; }
        public string Operation { private set; get; }
        public bool OperationResult { private set; get; }
        public string EmploeeName { private set; get; }
        public string Pass { private set; get; } = "no pass";

        /////   METHODS   /////

       /* public override string ToString()
        {
           // return $"Action {Action}";
        }*/
    }
}
