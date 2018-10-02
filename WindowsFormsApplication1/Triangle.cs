using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Triangle : Polygon
    {
        public Triangle(Point point1, Point point2, Point point3) : base(new Point[] { point1, point2, point3 }) { }
    }
}
