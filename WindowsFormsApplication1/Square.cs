using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Square : OurRectangle
    {
        public Square(int x, int y, int side) : base(x, y, side, side) 
        {
        
        }
    }
}
