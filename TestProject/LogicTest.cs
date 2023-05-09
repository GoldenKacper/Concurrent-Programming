using Data;
using Logic;
using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace TestProject
{
    [TestClass()]
    public class LogicTest
    {
        Random random = new Random();
        int _ballRadius = 25;
        //static List<int> _directions = new List<int>();

        [TestMethod]
        public void InitializeTest()
        {
            IBallsManager _ballsManager = new BallsManager();
            ILogic _logic = new Logic.Logic(_ballsManager);

            _logic.Initialize(1190, 474, 5);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(_logic.GetLocation(i).X > 0 && _logic.GetLocation(i).X < 1190);
                Assert.IsTrue(_logic.GetLocation(i).Y > 0 && _logic.GetLocation(i).Y < 474);
            }
        }



        // czy kulka idzie zgodnie ze swoim direction
        [TestMethod]
        public void DirectionTest()
        {
            IBallsManager _ballsManager = new BallsManager();
            ILogic _logic = new Logic.Logic(_ballsManager);

            _logic.Initialize(1150, 420, 1, 25);
            System.Threading.Thread.Sleep(10);
            _logic.SetDirectionValue(0, 0);                     // aby poruszała się tylko w osi X w kierunku prawym
            int x1 = _logic.GetLocation(0).X;
            int y1 = _logic.GetLocation(0).Y;

            System.Threading.Thread.Sleep(20);                  // czekamy aby kulki się ruszyły
            Assert.AreNotEqual(_logic.GetLocation(0).X ,x1);    // w osi X wartość się zmienia
            Assert.AreEqual(_logic.GetLocation(0).Y, y1);       // w osi Y wartość nie zmienia się
            Assert.IsTrue(_logic.GetLocation(0).X > x1);        // czy kulka poszła w prawo
        }

        

        [TestMethod]
        public void WallColisionTest()
        {
            IBallsManager _ballsManager = new BallsManager();
            ILogic _logic = new Logic.Logic(_ballsManager);
            int dir;

            _logic.Initialize(1150, 420, 1, 25);
            System.Threading.Thread.Sleep(10);
            _logic.SetDirectionValue(0, 0);
            while(true)
            {
                dir = _logic.GetDirectionValue(0);
                if (dir == 180)
                    break;

            }
            Assert.IsTrue(true); // poprawnie zmieniło się odbicie po odbiciu z prawą ścianą
            
            while (true)
            {
                dir = _logic.GetDirectionValue(0);
                if (dir == 0)
                    break;

            }
            Assert.IsTrue(true); // poprawnie zmieniło się odbicie po odbiciu z lewą ścianą

            System.Threading.Thread.Sleep(10);
            _logic.SetDirectionValue(0, 90);

            while (true)
            {
                dir = _logic.GetDirectionValue(0);
                if (dir == 270)
                    break;

            }
            Assert.IsTrue(true); // poprawnie zmieniło się odbicie po odbiciu z dolną ścianą

            while (true)
            {
                dir = _logic.GetDirectionValue(0);
                if (dir == 90)
                    break;

            }
            Assert.IsTrue(true); // poprawnie zmieniło się odbicie po odbiciu z górną ścianą
        }

        [TestMethod]
        public void BallColisionTest()
        {
            IBallsManager _ballsManager = new BallsManager();
            ILogic _logic = new Logic.Logic(_ballsManager);
            int dir1;
            _logic.Initialize(1150, 420, 2, 25);

            while (true)
            {
                dir1 = _logic.GetDirectionValue(0);
                System.Threading.Thread.Sleep(1);
                if (_logic.MockFindPotentialCollision(0) != -1)
                { break; }
            }
            System.Threading.Thread.Sleep(20);
            Assert.AreNotEqual(_logic.GetDirectionValue(0), dir1);    // czy po odbiciu kierunek się zmienił



        }

    }
}