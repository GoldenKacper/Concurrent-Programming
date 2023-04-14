using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ILogic // Logic API
    {
        void Initialize(int width, int height, int ballsNumber, int ballsRadius = 25);
        ILocation GetLocation(int index);
    }
}
