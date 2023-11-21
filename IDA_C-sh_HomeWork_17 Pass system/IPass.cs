using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_HomeWork_17_Pass_system
{
    internal interface IPass
    {
        enum PassType { PermanentPass , TemporaryPass }
        bool Validate(); //- проверка валидности пропуска
        void PrintInfo(); //- отображение информации о пропуске
    }
}
