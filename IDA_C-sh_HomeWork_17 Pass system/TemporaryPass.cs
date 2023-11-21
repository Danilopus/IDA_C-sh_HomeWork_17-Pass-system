using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_HomeWork_17_Pass_system
{
    internal class TemporaryPass : IPass
    {
        /////   CTOR    /////
        private TemporaryPass() { } // Чтобы не было пропусков без даты
        public TemporaryPass(DateTime passExpritationDate) 
        {
            PassExpritationDate = passExpritationDate;
            TemporaryPassID = ID_counter++;
        }

        /////   PROPS   /////
        IPass.PassType passType = IPass.PassType.TemporaryPass;
        private static int ID_counter = 1;
        public int TemporaryPassID { private set; get; }
        public string PassType { get; private set; } = "TemporaryPass";
        public DateTime PassExpritationDate { get; private set; }

        /////   METHODS   /////

        public bool Validate()
        {
                return PassExpritationDate > DateTime.Now;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{this} exp.date: {PassExpritationDate}");
        }
        public override string ToString()
        {
            return $"{PassType}_{TemporaryPassID}";
        }
    }
}
