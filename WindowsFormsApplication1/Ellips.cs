using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Ellips : Shape
    {
        public Ellips(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            Pen = new System.Drawing.Pen(Brushes.Red, 2f);
            Brush = Brushes.RosyBrown;
            GraphicsPath.AddEllipse(Rectangle);
        }

    }
}
