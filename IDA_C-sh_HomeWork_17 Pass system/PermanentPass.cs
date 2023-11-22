using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_HomeWork_17_Pass_system
{
    internal class PermanentPass : IPass
    //- не имеет ограничения по дате действия
    {
        /////   CTOR    /////

        public PermanentPass()  { PermanentPassID = ID_counter++; }

        /////   PROPS   /////

        IPass.PassTypeEnum passType = IPass.PassTypeEnum.PermanentPass;
        private static int ID_counter = 1;
        public int PermanentPassID{ private set; get; }
        string _passtype = "PermanentPass";
        public string PassType
        {
            get { return _passtype; }
            set { }
        }               

        /////   METHODS   /////

        public bool Validate()
        {
            return PassType == "PermanentPass";
        }

        public string PrintInfo()
        {
            return $"{this} exp.date: none";
        }
        public override string ToString()
        {
            return $"{PassType}_{PermanentPassID}";
        }
    }
}
