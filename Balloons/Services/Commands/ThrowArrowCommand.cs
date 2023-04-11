﻿using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services.Commands
{
    public class ThrowArrowCommand : ICommand
    {
        private readonly IBalloonFactory balloonFactory;
        private readonly IRemoveBalloon removeBalloon;

        public ThrowArrowCommand(IBalloonFactory balloonFactory,IRemoveBalloon removeBalloon)
        {
            this.balloonFactory = balloonFactory;
            this.removeBalloon = removeBalloon;
        }
        public string Execute(IList<string> arguments)
        {
            string color = arguments[0];
            var balloon=balloonFactory.CreateBalloon(color);
            removeBalloon.Remove(balloon);

            return $"{color} strike balloon";
        }
    }
}
