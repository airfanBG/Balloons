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
        private readonly IGameWriterProvider writerProvider;
        private IDictionary<string,IBalloon> _balloons;
        private IDictionary<string,IArrow> _arrows;
        private int balloonsCount;
        private int arrowsCount;
        public GamePlay(IGameWriterProvider writerProvider)
        {
            _balloons= new Dictionary<string,IBalloon>();
            _arrows= new Dictionary<string,IArrow>();
            this.writerProvider = writerProvider;
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
            arrowsCount++;
            writerProvider.WriteLine($"Total arrows: {_arrows.Count}");
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
            balloonsCount++;
            writerProvider.WriteLine($"Total balloons: {balloonsCount}");
        }

        public bool Remove(IBalloon balloon)
        {
            if (_balloons.ContainsKey(balloon.Color)&& _arrows.ContainsKey(balloon.Color))
            {
                _balloons.Remove(balloon.Color);
                writerProvider.WriteLine($"Left balloons: {balloonsCount - _balloons.Count}");
                writerProvider.Write($@"Total balloons: {_balloons.Count}, Total arrows; {_arrows.Count}");
                return true;
            }
            else
            {
                writerProvider.WriteLine("No arrows!");
                writerProvider.Write($@"Total balloons: {_balloons.Count}, Total arrows; {_arrows.Count}");
                return false;
            }

        }
    }
}
