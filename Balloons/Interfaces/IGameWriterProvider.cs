using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Interfaces
{
    public interface IGameWriterProvider
    {
        public void WriteLine(string text);
        public void Write(string text, params object[]? args);
       
    }
}
