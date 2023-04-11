using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services
{
    public class GameWriterProvider : IGameWriterProvider
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
