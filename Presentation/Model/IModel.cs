using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public interface IModel
    {
        void InitializeModel(int bordWidth, int bordHeight, int ballsNumber, int ballsRadius);
        ILocation GetLocation(int index);
        void UpdateLocation();
    }
}
