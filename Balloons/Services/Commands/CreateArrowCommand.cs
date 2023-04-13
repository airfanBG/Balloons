using Balloons.Interfaces;
using Balloons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services.Commands
{
   
    public class CreateArrowCommand : ICommand
    {
        private readonly IArrowFactory arrowFactory;
        private readonly IAddArrow addArrow;

        public CreateArrowCommand(IArrowFactory arrowFactory, IAddArrow addArrow)
        {
            this.arrowFactory = arrowFactory;
            this.addArrow = addArrow;
        }
        public string Execute(IList<string> arguments)
        {
          
            var arrow = arrowFactory.Create(arguments[0],int.Parse(arguments[1]));
            addArrow.AddArrow(arrow);
            return $"A new arrow with color {arguments[0]} added";
        }
    }
}
