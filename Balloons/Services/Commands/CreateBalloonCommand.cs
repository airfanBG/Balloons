using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services.Commands
{
    public class CreateBalloonCommand : ICommand
    {
        private readonly IBalloonFactory balloonFactory;
        private readonly IAddBalloon addBalloon;

        public CreateBalloonCommand(IBalloonFactory balloonFactory, IAddBalloon addBalloon)
        {
            this.balloonFactory = balloonFactory;
            this.addBalloon = addBalloon;
        }
        public string Execute(IList<string> arguments)
        {
            
            var balloon = balloonFactory.CreateBalloon(arguments[0]);
            addBalloon.AddBalloon(balloon);
            return $"A new balloon with color {arguments[0]} added";
        }
    }
}
