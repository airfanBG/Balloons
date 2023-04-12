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
        public Arrow(string color, int accurancy)
        {
            Color = color;
            ArrowId=Guid.NewGuid().ToString();  
            Accurancy = accurancy;
        }
        public string Color { get; set; }
        public string ArrowId { get; set; }
        public int Accurancy { get; set; }
        public int ArrowThrownCount { get; set; }
    }
}
