using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048Lib
{
    public class ScoreCounter
    {
        public int TotalScore { get; private set; } = 0;

        public void AddPoints(int points)
        {
            TotalScore += points;
        }

        public void Reset()
        {
            TotalScore = 0;
        }
    }
}
 