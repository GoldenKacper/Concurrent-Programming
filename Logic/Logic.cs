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

            while (true)
            {
                // TODO fix if condition


                //if (x > _ballRadius && x < 1190-31 && y > _ballRadius && y < 474-35)
                //if (_ballsManager.GetBall(index).X < 1152 && _ballsManager.GetBall(index).X > 25 && _ballsManager.GetBall(index).Y < 428 && _ballsManager.GetBall(index).Y > 25)

                Random rng = new Random();
                int xDirection = rng.Next(-1, 2);
                int yDirection = rng.Next(-1, 2);


                for (int i = 0; i < 25; i++)
                {
                    _ballsManager.GetBall(index).X += xDirection;
                    _ballsManager.GetBall(index).Y += yDirection;
                    Thread.Sleep(25);
                    if (_ballsManager.GetBall(index).X > 1152 || _ballsManager.GetBall(index).X < 25 || _ballsManager.GetBall(index).Y > 428 || _ballsManager.GetBall(index).Y < 25)
                        break;
                }
                if (_ballsManager.GetBall(index).X > 1152 || _ballsManager.GetBall(index).X < 25 || _ballsManager.GetBall(index).Y > 428 || _ballsManager.GetBall(index).Y < 25)
                    break;


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
                _ballsManager.CreateNewBall(random.Next(1190 - 63) + _ballRadius, random.Next(474 - 70) + _ballRadius, _ballRadius);
                //_ballsManager.CreateNewBall(1190-50, 474-50, _ballRadius); // TODO change to random value
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
