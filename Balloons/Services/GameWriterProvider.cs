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
        public virtual void Write(string text, params object[]? args)
        {
           if (args != null)
            {
                Console.Write(string.Format($"{text}, parameters: {string.Join(',', args)}"));
            }
            else
            {
                Console.Write(string.Format($"{text}"));
            }
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
