using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBall
    {
        int X { get; set; }
        int Y { get; set; }
        int Radius { get; }
    }
}
