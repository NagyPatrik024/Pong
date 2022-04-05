using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pong.Logic
{
    public class PongLogic : IGameModel
    {
        public double Position { get; set; }
        public Ball Ball { get; set; }
        public Platform Platform { get; set; }

        public event EventHandler Changed;
        public event EventHandler GameOver;

        System.Windows.Size area;

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
            this.Ball = new Ball(new System.Windows.Size(area.Width, area.Height));
            this.Platform = new Platform();
        }

        public PongLogic()
        {

        }

        public enum Controls
        {
            Left, Right
        }

        public void Control(Controls control)
        {
            switch (control)
            {
                case Controls.Left:
                    Position -= 10;
                    break;
                case Controls.Right:
                    Position += 10;
                    break;
                default:
                    break;
            }
            Changed?.Invoke(this, null);
        }

        public void TimeStamp()
        {
            Random rnd = new Random();
            bool inside = Ball.Move(new System.Drawing.Size((int)area.Width, (int)area.Height));
            if (!inside)
            {
                if (this.Ball.Center.X < 0)
                {
                    this.Ball.Speed = new Vector(Ball.Speed.X * -1 * rnd.NextDouble() + (1 + rnd.NextDouble()), Ball.Speed.Y);
                }
                this.Ball.Speed = new Vector(Ball.Speed.X * -1 * rnd.NextDouble() + (1 + rnd.NextDouble()), Ball.Speed.Y * -1 * rnd.NextDouble() + (1 + rnd.NextDouble()));
                Changed?.Invoke(this, null);
            }

            Rect asteroidRect = new Rect(Ball.Center.X - 12, Ball.Center.Y - 12, 25, 25);
            //if (asteroidRect.IntersectsWith(shipRect))
            //{
            //    Ball.Speed = new Vector(Ball.Speed.X * -1 + rnd.NextDouble() + (1 + rnd.NextDouble()), Ball.Speed.Y * -1 + rnd.NextDouble() + (1 + rnd.NextDouble()));
            //    Changed?.Invoke(this, null);
            //}

            if (Ball.Center.Y < area.Height / 25)
            {
                GameOver?.Invoke(this, null);
            }

            Changed?.Invoke(this, null);
        }
    }
}
