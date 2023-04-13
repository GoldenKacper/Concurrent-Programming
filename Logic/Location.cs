using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Location : ILocation
    {
        private int _X;
        private int _Y;

        public int X { get => _X; set => _X = value; }
        public int Y { get => _Y; set => _Y = value; }
    }
}
