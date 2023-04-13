using Balloons.Interfaces;
using Balloons.Models;
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
        private readonly IGameplayRandomGenerator gameplayRandomGenerator;
        private IDictionary<string,List<IBalloon>> _balloons;
        private IDictionary<string, List<IArrow>> _arrows;
        private int balloonsCount;
        private int arrowsCount;
        public GamePlay(IGameWriterProvider writerProvider, IGameplayRandomGenerator gameplayRandomGenerator)
        {
            _balloons= new Dictionary<string, List<IBalloon>>();
            _arrows= new Dictionary<string, List<IArrow>>();
            this.writerProvider = writerProvider;
            this.gameplayRandomGenerator = gameplayRandomGenerator;
        }
        public void AddArrow(IArrow arrow)
        {
            if (_arrows.ContainsKey(arrow.Color))
            {
                _arrows[arrow.Color].Add(arrow);
            }
            else
            {
                _arrows.Add(arrow.Color, new List<IArrow>() { arrow});
            }
            arrowsCount++;
            writerProvider.WriteLine($"Total arrows: {_arrows.Count}");
        }

        public void AddBalloon(IBalloon balloon)
        {
            if (_balloons.ContainsKey(balloon.Color))
            {
                _balloons[balloon.Color].Add(balloon);
            }
            else
            {
                _balloons.Add(balloon.Color, new List<IBalloon>() { balloon});
            }
            balloonsCount++;
         
            writerProvider.WriteLine($"Total balloons: {balloonsCount}");
        }

        public bool Remove(IBalloon balloon)
        {
            if (_balloons.ContainsKey(balloon.Color)&& _arrows.ContainsKey(balloon.Color))
            {
                //get random index by color list
                var allBalloons=_balloons[balloon.Color].Count;
             
                if (CheckArrowCount(balloon.Color))
                {
                    var allArrows = _arrows[balloon.Color].Count;
                    var balloonIndex = gameplayRandomGenerator.GetNumber(0, allBalloons);

                    var arrowIndex = gameplayRandomGenerator.GetNumber(0, allArrows);
                    var arrow = _arrows[balloon.Color][arrowIndex];
                    if (arrow.ArrowThrownCount < arrow.Accurancy)
                    {
                        //remove random balloon from list
                        _balloons[balloon.Color].RemoveAt(balloonIndex);
                        arrow.ArrowThrownCount++;
                        balloonsCount--;
                    }
                    else
                    {
                        _arrows[balloon.Color].RemoveAt(arrowIndex);
                        return false;
                    }

                    writerProvider.WriteLine($"Left balloons: {balloonsCount}");
                    writerProvider.Write($@"Total balloons: {balloonsCount}, Total arrows: {_arrows.Count}");
                    return true;
                }
                writerProvider.Write($@"Total balloons: {balloonsCount}, Total arrows: {_arrows.Count}");
                writerProvider.Write("You lost!");
                return false;
            }
            else
            {
                writerProvider.WriteLine("No arrows!");
                writerProvider.Write($@"Total balloons: {balloonsCount}, Total arrows: {_arrows.Count}");
                return false;
            }

        }
        private bool CheckArrowCount(string color)
        {
            if (_arrows[color].Count>0)
            {
                return true;
            }
            return false;
        }
    }
}
