using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pong.Logic
{
    public class Ball
    {
        public System.Drawing.Point Center { get; set; }
        public Vector Speed { get; set; }
        public Ball(System.Drawing.Point center, Vector speed)
        {
            Center = center;
            Speed = speed;
        }

        public bool Move(System.Drawing.Size area)
        {
            //hova kerülne a lépéskor a labda
            System.Drawing.Point newCenter =
                new System.Drawing.Point(Center.X + (int)Speed.X,
                Center.Y + (int)Speed.Y);
            if (newCenter.X >= 0 &&
                newCenter.X <= area.Width &&
                newCenter.Y >= 0 &&
                newCenter.Y <= area.Height
                )
            {
                //pályán belül van a labda
                Center = newCenter;
                return true;
            }
            else
            {
                //épp elhagyta a pályát
                return false;
            }
        }
    }
}
