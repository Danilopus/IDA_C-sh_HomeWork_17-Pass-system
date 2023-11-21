using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PassSystemEventLogger;

namespace IDA_C_sh_HomeWork_17_Pass_system
{
    internal class PassSystem

    {
        /////   PROPS   /////

        List<Employee> employees_list = new List<Employee>();
        List<IPass> pass_list = new List<IPass>();
        public string LogFileName { private set; get; } = "PassSystemJournal.log";

        /////   METHODS   /////
        


        bool RegisterEmployee(Employee new_employee) //- регистрация нового сотрудника
        {
            if (new_employee == null)
            {
                VulueEvent_event(Logger.EventInfoGenerate(GetCallerName(), new_employee, false));
                return false;
            }
            employees_list.Add(new_employee);
            VulueEvent_event(Logger.EventInfoGenerate(GetCallerName(), new_employee, true));
            return true;
        }
        bool IssuePass(Employee employee, IPass.PassType passType, DateTime? expitarion_date = null) //- выдача пропуска сотруднику
        {
            if (employee == null) throw new Exception("Null Employee reference");
            switch (passType)
            {
                case IPass.PassType.PermanentPass:
                    PermanentPass tmp_obj = new PermanentPass();
                    pass_list.Add(tmp_obj);
                    employee.PassAcquire(tmp_obj);
                    break;
                case IPass.PassType.TemporaryPass:
                    if (expitarion_date == null) return false;
                    TemporaryPass tmp_obj_2 = new TemporaryPass(Convert.ToDateTime(expitarion_date));
                    pass_list.Add(tmp_obj_2);
                    employee.PassAcquire(tmp_obj_2);
                    break;
                default:
                    VulueEvent_event(Logger.EventInfoGenerate(GetCallerName(), employee, false));
                    return false;
            }
            VulueEvent_event(Logger.EventInfoGenerate(GetCallerName(), employee, true));
            return true;
        }
        public bool AccessControl(Employee employee, out string comment)
        {
            if (employee == null) { comment = "No employee"; return false; }
            if (employee.Pass == null)  { comment = "No pass"; return false; }
            if (!employees_list.Contains(employee)) { comment = "employee not registred"; return false; }
            VulueEvent_event(Logger.EventInfoGenerate(GetCallerName(), employee, employee.Pass.Validate()));
            comment = employee.ToString + " get " + employee.Pass.ToString();
            return employee.Pass.Validate(); }    //- проверка доступа сотрудника с помощью пропуска

        public void PrintEmployeeList() { foreach (Employee employee in employees_list) Console.WriteLine(employee); }  //- отображение списка зарегистрированных сотрудников           

        static string GetCallerName([CallerMemberName] string name = "")    { return name; }

        // Используйте делегаты и события для логирования важных событий системы, например, успешной регистрации сотрудника или проверке доступа.

        internal delegate void VulueEvent_delegate(ValueEvent valueEvent);
        public event VulueEvent_delegate VulueEvent_event = delegate { };




    }
}
