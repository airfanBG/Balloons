using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services
{
    public class GameReaderProvider : IGameReaderProvider
    {
        public string ReadLine()
        {
            string command=Console.ReadLine();
            while (string.IsNullOrWhiteSpace(command))
            {
               command=Console.ReadLine();
            }
            return command;
        }
    }
}
