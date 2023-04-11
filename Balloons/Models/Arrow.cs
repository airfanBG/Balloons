using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Models
{
    public class Arrow:IArrow
    {
        public Arrow(string color)
        {
            Color= color;
        }
        public string Color { get; set; }
    }
}
