// HomeWork template 1.4 // date: 17.10.2023

using Service;
using System;
using System.Linq.Expressions;
using System.Text;

/// QUESTIONS ///
/// 1. 

UNDER CONSTRUCTION

// HomeWork XX : [{work_name}] --------------------------------

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
        /* Задание */
        { Console.WriteLine("\n***\t{0}\n\n", work_name); }
        public static void Task_2(string work_name)
        /* Задание */
        { Console.WriteLine("\n***\t{0}\n\n", work_name); }
        public static void Task_3(string work_name)
        /* Задание */
        { Console.WriteLine("\n***\t{0}\n\n", work_name); }
        public static void Task_4(string work_name)
        /* Задание */
        { Console.WriteLine("\n***\t{0}\n\n", work_name); }
        public static void Task_5(string work_name)
        /* Задание */
        { Console.WriteLine("\n***\t{0}\n\n", work_name); }
        public static void Task_6(string work_name)
        /* Задание */
        { Console.WriteLine("\n***\t{0}\n\n", work_name); }
        public static void Task_7(string work_name)
        /* Задание */
        { Console.WriteLine("\n***\t{0}\n\n", work_name); }

    }// class Program
}// namespace