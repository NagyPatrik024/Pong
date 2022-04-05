using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Logic
{
    internal interface IGameModel
    {
        double Position { get; set; }
        event EventHandler Changed;
        public double Angle { get; set; }
        Ball Ball { get; set; }
        Platform Platform { get; set; }
    }
}
