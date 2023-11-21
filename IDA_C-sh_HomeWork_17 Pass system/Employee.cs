using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_HomeWork_17_Pass_system
{
    internal class Employee
    {
        /////   CTOR    /////
        public Employee(string s) 
        {
        EmployeeId = ID_counter++;
        }

        /////   PROPS   /////

        public IPass Pass { private set; get; }
        private static int ID_counter = 1;
        public int EmployeeId { private set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Position { set; get; }
        public string Login { set; private get; }
        public string Password { set; private get; }

        /////   METHODS   /////

        public void PassAcquire(IPass pass) { Pass = pass; }
        public override string ToString()
        {
            return $"{LastName} {FirstName} ID{EmployeeId}";
        }

    }
}
