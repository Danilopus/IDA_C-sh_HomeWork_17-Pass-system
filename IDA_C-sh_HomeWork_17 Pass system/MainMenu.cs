using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    internal class MainMenu
    {
        List<string>? _menu_elements = new List<string>()
            { "HomeWork XX : [{work_name}]",
              "Task_1: ",
              "Task_2: ",
              "Task_3: ",
              "Task_4: ",
              "Task_5: ",
              "Task_6: ",
              "Task_7: "
            };

        public void AddElement(string menu_element) { _menu_elements.Add(menu_element); }
        public void Show_menu()
        {
            Console.Clear();    // system("cls");
            Console.Write("\n\t***\t" + _menu_elements[0] + "\t***\n\n\t\n\nChoose an option: \n");

            for (int i = 1; i < _menu_elements.Count; i++)
                Console.Write("\n" + i + ". " + _menu_elements[i]);
            Console.Write("\n\n 0. Exit\n");
            Console.Write("\nYour choice: ");
        }
        public int User_Choice_Handle()
        {
            int? choice = Service.ServiceFunction.Get_Int_Positive();
            Console.Write("\n\n***\t");

            // Обработка выбора пользователя
            if (choice == 0)
            {
                Console.Write("\nGood By");
                for (int j = 0; j < 50; j++) { Thread.Sleep(50 - j); Console.Write("y"); }
                Console.Write("e!"); Thread.Sleep(850); return 0;
            }

            else if (choice == 1) IDA_C_sh_HomeWork.Program.Task_1(_menu_elements[1]);
            else if (choice == 2) IDA_C_sh_HomeWork.Program.Task_2(_menu_elements[2]);
            else if (choice == 3) IDA_C_sh_HomeWork.Program.Task_3(_menu_elements[3]);
            else if (choice == 4) IDA_C_sh_HomeWork.Program.Task_4(_menu_elements[4]);
            else if (choice == 5) IDA_C_sh_HomeWork.Program.Task_5(_menu_elements[5]);
            else if (choice == 6) IDA_C_sh_HomeWork.Program.Task_6(_menu_elements[6]);
            else if (choice == 7) IDA_C_sh_HomeWork.Program.Task_7(_menu_elements[7]);
            //else if (choice == 8) IDA_C_sh_HomeWork_1.Program.Task_8(_menu_elements[8]);


            else { Console.Write("\nSuch choice does not exist yet\n"); Thread.Sleep(1000); }
            return 1;
        }

        //public int User_Choice_Handle(int key_code);

    } // class MainMenu
} // namespace