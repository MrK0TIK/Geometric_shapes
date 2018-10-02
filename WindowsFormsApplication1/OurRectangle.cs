using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class OurRectangle : Shape
    {
        public OurRectangle(int x, int y, int width, int height) : base(x, y, width, height)
        {
            Pen = new System.Drawing.Pen(Brushes.Red, 2f);
            Brush = Brushes.RosyBrown;
            GraphicsPath.AddRectangle(Rectangle);
        }
    }
}
