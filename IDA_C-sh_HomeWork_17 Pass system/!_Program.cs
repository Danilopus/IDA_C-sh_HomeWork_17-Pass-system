// HomeWork template 1.4 // date: 17.10.2023

using IDA_C_sh_HomeWork_17_Pass_system;
using PassSystemEventLogger;
using Service;
using System;
using System.Linq.Expressions;
using System.Text;

/// QUESTIONS ///
/// 1. 

// UNDER CONSTRUCTION

// HomeWork 17 : [Pass System] --------------------------------

namespace IDA_C_sh_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu.MainMenu mainMenu = new MainMenu.MainMenu();

            do
            {
                Console.Clear();
                mainMenu.Show_menu();
                if (mainMenu.User_Choice_Handle() == 0) break;
                Console.ReadKey();
            } while (true);
            // Console.ReadKey();
        }

        public static void Task_1(string work_name)
        /* Задание:
        
        Вам необходимо разработать консольное приложение на языке C#, которое имитирует работу пропускной системы предприятия. 
        Пропускная система должна позволять регистрировать сотрудников, выдавать им пропуски, а также проверять валидность пропусков при попытке доступа.

        Требования:

        *** Создайте класс "Employee" (сотрудник) со следующими полями:

        Идентификатор сотрудника (EmployeeId)
        Фамилия (LastName)
        Имя (FirstName)
        Должность (Position)
        Логин (Login)
        Пароль (Password)

        *** Создайте интерфейс "IPass" (пропуск) с методами:

        Validate() - проверка валидности пропуска
        PrintInfo() - отображение информации о пропуске
        
        Создайте классы пропусков:

        TemporaryPass (временный пропуск) - должен иметь дату начала и окончания действия
        PermanentPass (постоянный пропуск) - не имеет ограничения по дате действия

        *** Создайте класс "PassSystem" (система пропусков) с методами:

        RegisterEmployee() - регистрация нового сотрудника
        IssuePass() - выдача пропуска сотруднику
        AccessControl() - проверка доступа сотрудника с помощью пропуска
        PrintEmployeeList() - отображение списка зарегистрированных сотрудников

        Используйте делегаты и события для логирования важных событий системы, например, успешной регистрации сотрудника или проверке доступа.

        Используйте LINQ для выполнения следующих запросов:

        Получение списка сотрудников с постоянным пропуском.
        Получение списка сотрудников с временным пропуском, чье действие истекает сегодня.

        Используйте Generics для возможности работы с разными типами пропусков.

        Примечание:

        Для упрощения примера, весь ввод/вывод можно осуществлять через консоль.
        Разрешается использовать любые сторонние библиотеки или фреймворки. */
        {
            Console.WriteLine("\n***\t{0}\n\n", work_name);

            // Создадим эко-систему из 20 сотрудников
            var employees_team = Employee.CreateEmployeeTeam(20).ToList();

            PassSystem passSystem = new PassSystem();
            // Настроим систему пропусков так, чтобы все значимые события логировались в файл
            // Для этого подключаем в делегат-событие VulueEvent_event метод Logger.WriteEventToLogFile
            Logger.LogFileName = passSystem.LogFileName;
            passSystem.VulueEvent_event += Logger.WriteEventToLogFile;

            // Зарегистрируем и раздадим всем пропуска
            foreach (Employee employee in employees_team)
            {
                passSystem.RegisterEmployee(employee);
                // по умолчанию временные пропуска на 5 секунд
                passSystem.IssuePass(employee);
            }

            // Инфорация о сотрудниках и выданных пропусках
            Console.WriteLine("\n\n// Инфорация о сотрудниках и выданных пропусках:\n");
            foreach (Employee employee in employees_team)
            {
                if (employee.Pass == null) Console.WriteLine($"{employee} | Position: {employee.Position} | Pass: null");
                else Console.WriteLine($"{employee} ".PadLeft(30) + $"| Position: {employee.Position} | Pass: {employee.Pass.PrintInfo()}");
            }

            // Также добавим в колектив несколько нарушителей:
            for (int i = 0; i < 5; i++)
            {
                Employee employee = new Employee();
                employee.FirstName = "intruder";
                employee.Position = "Director";
                passSystem.IssuePass(employee);
                Employee employee2 = new Employee();
                employees_team.Add(employee);
            }

            // создадим кипучую деятельность на 10 секунд     
            PassSystemWorkSimulation();

            // Получение списка сотрудников с постоянным пропуском.
            Console.Write("\n\n*** Получение списка сотрудников с постоянным пропуском\n\n ... press any key\r");
            Console.ReadKey();
            foreach (Employee employee in employees_team.Where(s => s.Pass.PassType == "PermanentPass"))
                Console.WriteLine($"{employee} |".PadLeft(30) + $" Pass type: {employee.Pass.PassType}");


            // Получение списка сотрудников с временным пропуском, чье действие истекает сегодня.
            Console.Write("\n\n*** Получение списка сотрудников с временным пропуском, чье действие истекает {0}\n\n ... press any key\r", DateTime.Now.Date.AddDays(1));
            Console.ReadKey();
            foreach (Employee employee in employees_team.Where(s => s.Pass.PassType == "TemporaryPass").Where(s => (s.Pass as TemporaryPass).PassExpritationDate < DateTime.Now.Date.AddDays(1)))
                        Console.WriteLine($"{employee} |".PadLeft(30) + employee.Pass.PrintInfo());

            // Логи            
            Console.Write("\n\n--- Хотите взглянуть на журнал событий текущей сессии?\nСобытий в журнале текущей сессии: {0}\n\n ... press Y if Yes, or any other key if No\r", Logger.LogEvents.Count);            
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                foreach (var logevent in Logger.LogEvents)
                    Console.WriteLine(logevent);
            }

            Console.Write("\n\n--- Хотите взглянуть на журнал событий всех сессий {1}?\nСобытий в журнале всех сессий: {0}\n\n ... press Y if Yes, or any other key if No\r", Logger.ReadLogFile(passSystem.LogFileName).Count, passSystem.LogFileName);
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                foreach (var logevent in Logger.ReadLogFile(passSystem.LogFileName))
                    Console.WriteLine(logevent);
            }

            Console.WriteLine("\n\nEnd of work ... press any key");

            ///// LOCAL FUNCTIONS /////

            void PassSystemWorkSimulation(int simulation_time_sec = 10)
            {
                string comment;
                Random rand = new Random();

                Console.Write("\n\nTo start simulation ... press any key");
                Console.ReadKey();
                Console.Write("\r");
                DateTime start = DateTime.Now;
                Console.WriteLine("*** Simulation start time: " + start + "\n");
                int attempts = 0, success_attemps = 0;
                while (start.AddSeconds(simulation_time_sec) > DateTime.Now)
                {
                    attempts++;
                    Thread.Sleep(300);
                    Employee employee = employees_team[rand.Next(employees_team.Count)];
                    if (passSystem.AccessControl(employee, out comment)) { success_attemps++; }
                    Console.WriteLine(" AccessControl comment: " + comment);
                }

                Console.WriteLine("\n*** Simulation stop time: " + DateTime.Now + 
                    "\tDuration " + string.Format("{0:f2}", (DateTime.Now - start).TotalSeconds) + " sec" +
                    "\n*** AccessControl attempts: " + attempts +
                    ", successful " + success_attemps +
                    ", denied " + (attempts-success_attemps));

                Console.WriteLine($"\n*** Logged events: {Logger.LogEvents.Count}");
            }
        }
 

    }// class Program
}// namespace