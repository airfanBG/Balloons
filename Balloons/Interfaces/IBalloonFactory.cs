using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Interfaces
{
    public interface IBalloonFactory
    {
        IBalloon CreateBalloon(string color);
    }
}
