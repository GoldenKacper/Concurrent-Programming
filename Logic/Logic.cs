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
        static IBallsManager _ballsManager;
        static int _ballsNumber;
        static int _width;
        static int _height;
        static int _ballRadius;
        static int _ballWeight;
        static bool _isRunning = true; // change to false in purpose kill thread
        static int _ballsSpeed; // the length of the ball's displacement vector in each tick of the clock


        List<Thread> _threads = new List<Thread>();
        List<Task> _tasks = new List<Task>();
        static List<bool> _ballsRunning = new List<bool>();
        static List<int> _directions = new List<int>(); // directions is an angle from range <0;360), where 0 is right direction 
        Action<object> _taskAction = (object obj) =>
        {
            int index = (int)obj;
            IBall ball = _ballsManager.GetBall(index);
            int x = ball.X;
            int y = ball.Y;

            while (_isRunning)
            {
                if (!_ballsRunning[index])
                {
                    Thread.Sleep(1);
                    continue;
                }
                int direction = _directions[index];
                int collisionBallIndex = FindPotentialCollision(index);
                if (collisionBallIndex != -1)
                {
                    lock (_ballsRunning)
                    {
                        _ballsRunning[collisionBallIndex] = false;
                    }
                    int collisionDirection = _directions[collisionBallIndex];
                    int collisionX = _ballsManager.GetBall(collisionBallIndex).X;
                    int collisionY = _ballsManager.GetBall(collisionBallIndex).Y;
                    int collisionAngle = 0;
                    if (x != collisionX)
                    {
                        // arctan from slope to have collisions converted from radians to angles
                        collisionAngle = (int)Math.Round(Math.Atan(((double)(y - collisionY)) / ((double)(collisionX - x))) * 180.0 / Math.PI);
                    }
                    else
                    {
                        collisionAngle = (y > collisionY) ? 90 : -90;
                    }
                    if (x > collisionX)
                    {
                        collisionAngle = 180 + collisionAngle;
                    }
                    else if (collisionAngle < 0)
                    {
                        collisionAngle = 360 + collisionAngle;
                    }
                    int difference = collisionAngle - direction;
                    direction = (180 + direction + 2 * difference) % 360;
                }
                if (x < _ballRadius || x > _width - _ballRadius) // left or right wall
                {
                    if (direction <= 180)
                    {
                        direction = 180 - direction;
                    }
                    else
                    {
                        direction = 360 - (direction - 180);
                    }
                    // return the ball to the board
                    if (x < _ballRadius)
                    {
                        x = _ballRadius;
                    }
                    else
                    {
                        x = _width - _ballRadius;
                    }
                }
                if (y < _ballRadius || y > _height - _ballRadius) // bottom or top wall
                {
                    direction = 360 - direction;
                    if (y < _ballRadius)
                    {
                        y = _ballRadius;
                    }
                    else
                    {
                        y = _height - _ballRadius;
                    }
                }
                x += (int)Math.Round(_ballsSpeed * Math.Cos(direction * Math.PI / 180.0));
                y -= (int)Math.Round(_ballsSpeed * Math.Sin(direction * Math.PI / 180.0));
                lock (ball)
                {
                    ball.X = x;
                    ball.Y = y;
                }
                lock (_directions)
                {
                    _directions[index] = direction;
                }
                if (collisionBallIndex != -1)
                {
                    lock (_ballsRunning)
                    {
                        _ballsRunning[collisionBallIndex] = true;
                    }
                }
                Thread.Sleep(1);
            }
        }; 

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

        public void Initialize(int width, int height, int ballsNumber, int ballsRadius = 25, int ballsWeight = 10, int ballsSpeed = 5)
        {
            _ballsNumber = ballsNumber;
            _width = width - 10;
            _height = height - 15;
            _ballRadius = ballsRadius;
            _ballWeight = ballsWeight;
            _ballsSpeed = ballsSpeed;

            Random random = new Random();
            for (int i = 0; i < _ballsNumber; i++)
            {
                _ballsManager.CreateNewBall(random.Next(1150) + _ballRadius, random.Next(420) + _ballRadius, _ballRadius);
                _directions.Add(random.Next(360));
                _ballsRunning.Add(true);
                _tasks.Add(new Task(action: _taskAction, i));
                //_threads.Add(new Thread(MoveBall));
            }
            Start();
        }

        static int FindPotentialCollision(int index)
        {
            IBall ball = _ballsManager.GetBall(index);
            int ballX = ball.X; 
            int ballY = ball.Y;
            for (int ballNumber = 0; ballNumber < _ballsNumber; ++ballNumber)
            {
                if (index == ballNumber)
                {
                    continue;
                }
                int comparedX = _ballsManager.GetBall(ballNumber).X;
                int comparedY = _ballsManager.GetBall(ballNumber).Y;
                int distance = (int)Math.Round(Math.Sqrt((ballX - comparedX) * (ballX - comparedX) + (ballY - comparedY) * (ballY - comparedY)));
                if (distance <= 2 * _ballRadius)
                {
                    return ballNumber; // collision of two balls
                }
            }
            return -1; // not found
        }

        public void Start()
        {
            _isRunning = true;
            for (int i = 0; i < _ballsNumber; i++)
            {
                _tasks[i].Start();
            }
        }

        public void Stop()
        {
            _isRunning = false;
            for (int i = 0; i < _ballsNumber; i++)
            {
                _tasks[i].Wait(); 
            }
        }
    }
}
