using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp8
{
    public class Canvas : IDrawable
    {
        public void DrawLine(Graphics g, Pen pen, Point start, Point end)
        {
            g.DrawLine(pen, start, end);
        }

        public void DrawCircle(Graphics g, Pen pen, Point center, int radius)
        {
            g.DrawEllipse(pen, center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }

        public void DrawRectangle(Graphics g, Pen pen, Rectangle rect)
        {
            g.DrawRectangle(pen, rect);
        }
    }
}
