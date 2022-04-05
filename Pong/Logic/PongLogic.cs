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
        public double Angle { get; set; }
        public void TimeStamp()
        {
            bool inside = Ball.Move(new System.Drawing.Size((int)area.Width, (int)area.Height));
            if (!inside)
            {
                if (Ball.Center.Y <= area.Height)
                {
                    Ball.Speed = new Vector(Ball.Speed.X, Ball.Speed.Y * -1);
                }

                Ball.Speed = new Vector(Ball.Speed.X * -1, Ball.Speed.Y);
                Changed?.Invoke(this, null);
            }

            Rect ballRect = new Rect(Ball.Center.X - 2, Ball.Center.Y - 2, 5, 5);
            Rect platformRect = new Rect((area.Width / 2 - 25) + Position, area.Height - 30, 100, 25);
            if (ballRect.IntersectsWith(platformRect))
            {
                Ball.Speed = new Vector(Ball.Speed.X, Ball.Speed.Y * -1);
                Changed?.Invoke(this, null);
            }

            if (Ball.Center.Y > area.Height)
            {
                GameOver?.Invoke(this, null);
            }

            Changed?.Invoke(this, null);
        }
    }
}
