using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_HomeWork_17_Pass_system
{
    internal interface IPass
    {
        enum PassTypeEnum { PermanentPass , TemporaryPass }
        string PassType { get; set; }
        bool Validate(); //- проверка валидности пропуска
        string PrintInfo(); //- отображение информации о пропуске
    }
}
