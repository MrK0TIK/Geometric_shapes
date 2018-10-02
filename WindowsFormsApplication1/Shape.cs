using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public class Shape
    {
        public string Name { get; set; }
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point[] Points { get; set; }
        public Rectangle Rectangle { get; set; }
        public GraphicsPath GraphicsPath { get; set; }

        public Shape(int x, int y, int width, int height)
        {
            Rectangle = new Rectangle(x, y, width, height);
            GraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
        }
        public Shape(Point[] points)
        {
            Points = points;
            GraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
        }
        public void Draw(Graphics g)
        {
            g.DrawPath(Pen, GraphicsPath);
            g.FillPath(Brush, GraphicsPath);
            //if (IsTop)
            //    g.TranslateClip(2f, 4f);
        }

        
    }
}
