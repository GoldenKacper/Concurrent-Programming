using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallsManager : IBallsManager    
    {
        private List<IBall> _balls = new List<IBall>();

        public void CreateNewBall(int x, int y, int radius)
        {
            _balls.Add(new Ball(x, y, radius));
        }

        public IBall GetBall(int index)
        {
            if (index >= _balls.Count)
            {
                throw new IndexOutOfRangeException("Given index is higher than number of balls, or less than 0");
            }
            return _balls[index];
        }

        public int GetBallCount()
        {
            return _balls.Count;
        }

        public void UpdateBallStatus(int index, int x, int y)
        {
            if (index >= _balls.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Given index is higher than number of balls, or less than 0");
            }
            _balls[index].X = x;
            _balls[index].Y = y;
        }
    }
}
