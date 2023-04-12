using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Interfaces
{
    public interface IArrow:IGameplayObject
    {
        public string ArrowId { get; set; }
        public int Accurancy { get; set; }
        public int ArrowThrownCount { get; set; }
    }
}
