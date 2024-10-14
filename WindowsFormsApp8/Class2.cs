using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public interface IDrawable
    {
        void DrawLine(Graphics g, Pen pen, Point start, Point end);
        void DrawCircle(Graphics g, Pen pen, Point center, int radius);
        void DrawRectangle(Graphics g, Pen pen, Rectangle rect);
    }
}
