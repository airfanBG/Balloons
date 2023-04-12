using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services
{
    public class GameplayRandomGenerator:IGameplayRandomGenerator
    {
       
        public int GetNumber(int from, int to)
        {
            return new Random().Next(from, to);
        }
    }
}
