using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Circle : Ellips
    {
        public Circle(int x, int y, int diameter) : base(x, y, diameter, diameter) { }
    }
}
