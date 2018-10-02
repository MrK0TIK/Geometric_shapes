using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;

namespace WindowsFormsApplication1
{
    class Shapes : ObservableCollection<Shape>
    {
        public Pen CurrentPen { get; set; }

        public void BringToFront(Shape shape)
        {
            int indexCurrent = this.IndexOf(shape);
            int indexLast = this.Count - 1;
            this.Move(indexCurrent, indexLast);
 
        }
    }
}
