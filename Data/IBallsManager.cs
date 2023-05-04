using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBallsManager
    {
        void CreateNewBall(int x, int y, int radius);
        void UpdateBallStatus(int index, int x, int y);
        IBall GetBall(int index); // returns a ball, not an interface (upcasting)
        int GetBallsCount();
    }
}
