using Logic;
using Data;

namespace TestProject
{
    [TestClass()]
    public class BallTest

    {
        [TestMethod]
        public void BallTests()
        {
        IBallsManager _ballsManager = new BallsManager();
        _ballsManager.CreateNewBall(10, 10, 25);
            Assert.AreEqual(_ballsManager.GetBall(0).X, 10);
            Assert.AreEqual(_ballsManager.GetBall(0).Y, 10);
            Assert.AreEqual(_ballsManager.GetBall(0).Radius, 25);

        _ballsManager.UpdateBallStatus(0, 20, 30);
            Assert.AreEqual(_ballsManager.GetBall(0).X, 20);
            Assert.AreEqual(_ballsManager.GetBall(0).Y, 30);

        }
    }
}