using Pong.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Pong.Renderer
{
    class Display : FrameworkElement
    {
        Size area;
        IGameModel model;
        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 0),
                  new Rect(0, 0, area.Width, area.Height));

               
                drawingContext.PushTransform(new TranslateTransform(model.Position, (double)0));
                drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.White, 3), new Rect(area.Width / 2 - 25, area.Height-30, 100, 25));
                drawingContext.Pop();
                drawingContext.DrawEllipse(Brushes.Red, null, new Point(model.Ball.Center.X, model.Ball.Center.Y), 5, 5);


            }

        }
    }
}
