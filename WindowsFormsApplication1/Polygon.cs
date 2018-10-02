using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Polygon : Shape
    {
        public Polygon(Point[] points)
            : base(points)
        {
            Pen = new System.Drawing.Pen(Brushes.Red, 2f);
            Brush = Brushes.RosyBrown;
            GraphicsPath.AddPolygon(Points);
        }
    }
}
