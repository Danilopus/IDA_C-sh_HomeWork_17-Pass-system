using Service;
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
        public Employee()//: this(FileManager.RandomEmploye());
        {
        EmployeeId = ID_counter++;
        }
        static public Employee[] CreateEmployeeTeam(int qua)
        {
            
            string[] females_names;
            string[] males_names;
            string[] males_surnames;
            FileManager.RandomNameSurnameLoader(out males_surnames, out males_names, out females_names);

            Random random = new Random();
            List<Employee> list = new List<Employee>();

            for (int i = 0; i< qua; i++) 
            {
                bool gender = false; // female
                if (random.Next(10) > 5) gender = true; // man
                Employee employee = new Employee();
                if (gender)
                {
                    employee.FirstName = males_names[random.Next(males_names.Length)];
                    employee.LastName = males_surnames[random.Next(males_surnames.Length)];
                }
                else
                {
                    employee.FirstName = females_names[random.Next(females_names.Length)];
                    employee.LastName = (males_surnames[random.Next(males_names.Length)] + "а");
                }
                string[] positions = new string[] { "Director", "Head", "Ordinary" };
                switch(random.Next(10))
                {
                    case 0: employee.Position = positions[0]; break;
                    case 1: case 2: employee.Position = positions[1]; break;    
                    default: employee.Position = positions[2]; break;
                }
                employee.Login = employee.FirstName.ElementAt(0)+employee.LastName;
                //employee.Password = employee.LastName.ToCharArray().Reverse().ToString();
                employee.Password = "123qaz";

                list.Add(employee);
            }


          return list.ToArray();
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
            string result = (LastName + " " + FirstName) + " ID" + EmployeeId;
            return result;
        }

    }
}
