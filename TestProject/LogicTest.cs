using Data;
using Logic;
using System;

namespace TestProject
{
    [TestClass()]
    public class LogicTest

    {
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
    }
}