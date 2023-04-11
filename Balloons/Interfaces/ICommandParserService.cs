using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Interfaces
{
    public interface ICommandParserService
    {
        public ICommand ParseCommand(string fullCommand);
        public IList<string> ParseParameters(string command);
    }
}
