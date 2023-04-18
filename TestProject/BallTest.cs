using Logic;
using Data;
using System;

namespace TestProject
{
    [TestClass()]
    public class BallTest

    {
        [TestMethod]
        public void CreateBallTest()
        {
        IBallsManager _ballsManager = new BallsManager();
        _ballsManager.CreateNewBall(10, 10, 25);
            //czy kula prawid³owo powstaje
            Assert.AreEqual(_ballsManager.GetBall(0).X, 10);
            Assert.AreEqual(_ballsManager.GetBall(0).Y, 10);
            Assert.AreEqual(_ballsManager.GetBall(0).Radius, 25);
        }

        [TestMethod]
        public void UpdateBallTest()
        {
            IBallsManager _ballsManager = new BallsManager();
            _ballsManager.CreateNewBall(10, 10, 25);
            //czy zmiana miejsca kuli dzia³a prawid³owo
            _ballsManager.UpdateBallStatus(0, 20, 30);
            Assert.AreEqual(_ballsManager.GetBall(0).X, 20);
            Assert.AreEqual(_ballsManager.GetBall(0).Y, 30);
        }

        [TestMethod]
        public void RandomBallsTest()
        {
            IBallsManager _ballsManager = new BallsManager();
            Random random = new Random();
            _ballsManager.CreateNewBall(random.Next(1127) + 25, random.Next(404) + 25, 25);
            //czy kula powstanie w prawid³owym obszarze(wymiary odpowiadaj¹ce scenie)
            Assert.IsTrue(_ballsManager.GetBall(0).X > 0 && _ballsManager.GetBall(0).X < 1190);
            Assert.IsTrue(_ballsManager.GetBall(0).Y > 0 && _ballsManager.GetBall(0).Y < 474);
        }
    }
}