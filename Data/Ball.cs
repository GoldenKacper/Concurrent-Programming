using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ball : IBall
    {
        private int _X;
        private int _Y;
        private readonly int _Radius;
        private readonly int _Weight;

        public Ball(int x, int y, int radius)
        {
            X = x;
            Y = y;
            lock (this) 
            {
                _Radius = radius;
            }
        }

        public int X 
        {
            get => _X; 
            set 
            { 
                lock (this)
                {
                    _X = value;
                }
                 
            } 
        }
        public int Y
        {
            get => _Y;
            set
            { 
                lock (this)
                {
                    _Y = value;
                }
                
            } 
        }
        public int Radius { get => _Radius; }

        public int Weight => _Weight;
    }
}
