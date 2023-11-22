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
        
        IPass.PassTypeEnum passType = IPass.PassTypeEnum.TemporaryPass;
        private static int ID_counter = 1;
        public int TemporaryPassID { private set; get; }
        string _passtype = "TemporaryPass";
        public string PassType
        {
            get { return _passtype; }
            set { }
        }

        public DateTime PassExpritationDate { get; private set; }

        /////   METHODS   /////

        public bool Validate()
        {
                return PassExpritationDate > DateTime.Now;
        }

        public string PrintInfo()
        {
            return $"{this} exp.date: {PassExpritationDate}";
        }
        public override string ToString()
        {
            return $"{PassType}_{TemporaryPassID}";
        }
    }
}
