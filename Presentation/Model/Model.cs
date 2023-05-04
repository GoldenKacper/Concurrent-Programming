using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public class Model : IModel
    {
        private List<ILocation> _location = new List<ILocation>();
        private int _ballsNumber;
        private ILogic _logic;

        public Model(ILogic logic)
        {
            _logic = logic;
        }

        public ILocation GetLocation(int index)
        {
            if (index >= _ballsNumber || index < 0)
            {
                throw new IndexOutOfRangeException("Given index is higher than number of Locations, or less than 0");
            }
            return _location[index];
        }

        public void InitializeModel(int bordWidth, int bordHeight, int ballsNumber, int ballsRadius, int ballsSpeed)
        {
            _ballsNumber = ballsNumber;
            _logic.Initialize(bordWidth, bordHeight, ballsNumber, ballsRadius, ballsSpeed);
            for (int i = 0; i < _ballsNumber; i++)
            {
                _location.Add(_logic.GetLocation(i));
            }
        }

        public void UpdateLocation()
        {
            for (int i = 0; i < _ballsNumber; i++)
            {
                _location[i] = _logic.GetLocation(i);
            }
        }

        public void StopLogic()
        {
            _logic.Stop();
        }
    }
}
