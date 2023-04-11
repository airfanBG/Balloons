using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Interfaces
{
    public interface ICommandFactory
    {
       public ICommand GetCommand(Type type);
    }
}
