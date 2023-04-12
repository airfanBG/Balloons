using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Models
{
    public class Balloon : IBalloon
    {
        public Balloon(string color)
        {
            Color=color;
            BalloonId = Guid.NewGuid().ToString();
        }
        public string BalloonId { get; set; }
        public string Color { get; set; }
       
    }
}
