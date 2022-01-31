using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public interface IEquipment
    {
        void RandEquipment();
        void IncreaseEqComponent(Eq eq);
        void ReduceEqComponent(Eq eq);
    }
}
