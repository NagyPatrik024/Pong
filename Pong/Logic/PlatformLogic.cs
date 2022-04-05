using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Logic
{
    public class PlatformLogic : IGameModel
    {
        public double Angle { get; set; }
        public Ball Ball { get; set; }
        public Platform Platform { get; set; }

        public event EventHandler Changed;
        public event EventHandler GameOver;

        System.Windows.Size area;

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
            Ball = new Ball(new System.Windows.Size(area.Width, area.Height));
            Platform = new Platform();
        }
    }
}
