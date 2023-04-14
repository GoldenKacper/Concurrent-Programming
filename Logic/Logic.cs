using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class Logic : ILogic
    {
        private IBallsManager _ballsManager;
        private int _ballsNumber;
        private int _width;
        private int _height;
        private int _ballRadius;
        List<Thread> _threads = new List<Thread>();



        public Logic(IBallsManager ballsManager)
        {
            _ballsManager = ballsManager;
        }

        public ILocation GetLocation(int index)
        {
            if (index >= _ballsNumber || index < 0)
            {
                throw new IndexOutOfRangeException("Given index is higher than number of Locations, or less than 0");
            }
            return new Location { X = _ballsManager.GetBall(index).X, Y = _ballsManager.GetBall(index).Y };
        }

        private void MoveBall(object obj)
        {
            //TODO rebuild

            int index = (int)obj;
            int x = 10;
            int y = 10;

            while (true)
            {
                //if (x > _ballRadius && x < _height - _ballRadius && y > _ballRadius && y < _width - _ballRadius)
                //{
                //    _ballsManager.GetBall(index).X = 400;
                //    _ballsManager.GetBall(index).Y = 400;
                //    Thread.Sleep(1);
                //}
                //else
                //{ break; }

                _ballsManager.GetBall(index).X = 400;
                _ballsManager.GetBall(index).Y = 400;
                Thread.Sleep(1);
            }

        }

        public void Initialize(int width, int height, int ballsNumber, int ballsRadius = 25)
        {
            _ballsNumber = ballsNumber;
            _width = width;
            _height = height;
            _ballRadius = ballsRadius;
            Random random = new Random();
            for (int i = 0; i < _ballsNumber; i++)
            {
                //_ballsManager.CreateNewBall(random.Next(_height - 2 * _ballRadius) + _ballRadius, random.Next(_width - 2 * _ballRadius) + _ballRadius, _ballRadius);
                _ballsManager.CreateNewBall(100, 100, 25); // TODO change to random value
                //_Dane.CreateNewBall(random.Next(_length - 2 * _radius) + _radius, random.Next(_width - 2 * _radius) + _radius, _radius);
                //_directions.Add(random.Next(360));
                _threads.Add(new Thread(MoveBall));
            }
            for (int i = 0; i < _ballsNumber; i++)
            {
                _threads[i].Start(i);
            }
            //throw new Exception(_ballsManager.GetBall(0).X.ToString() + "    " + _ballsManager.GetBall(0).Y.ToString());
        }
    }
}
