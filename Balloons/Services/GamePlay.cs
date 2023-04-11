using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.Services
{
    public class GamePlay : IGamePlay
    {
        private IDictionary<string,IBalloon> _balloons;
        private IDictionary<string,IArrow> _arrows;
        public GamePlay()
        {
            _balloons= new Dictionary<string,IBalloon>();
            _arrows= new Dictionary<string,IArrow>();
        }
        public void AddArrow(IArrow arrow)
        {
            if (_arrows.ContainsKey(arrow.Color))
            {
                _arrows[arrow.Color] = arrow;
            }
            else
            {
                _arrows.Add(arrow.Color, arrow);
            }
        }

        public void AddBalloon(IBalloon balloon)
        {
            if (_balloons.ContainsKey(balloon.Color))
            {
                _balloons[balloon.Color] = balloon;
            }
            else
            {
                _balloons.Add(balloon.Color, balloon);
            }
        }

        public void Remove(IBalloon balloon)
        {
            if (_balloons.ContainsKey(balloon.Color))
            {
                _balloons.Remove(balloon.Color);
            }
            
        }
    }
}
