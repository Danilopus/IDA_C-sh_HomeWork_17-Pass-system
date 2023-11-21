// HomeWork template 1.4 // date: 17.10.2023

using IDA_C_sh_HomeWork_17_Pass_system;
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

            // Создадим эко-систему из 100 сотрудников
            Employee[] employees_teeam = new Employee[100];

            foreach (Employee employee in employees_teeam)
                Console.WriteLine(employee);






        }


    }// class Program
}// namespace