using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            shapes = new Shapes();
            GetColorsFromComboBox();
        }
        Shapes shapes;
        private void panelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
   
            foreach (Shape item in shapes)
            {
                if (item.GraphicsPath.IsVisible(e.X, e.Y))
                {
                    shapes.BringToFront(item);
                    panelDrawing.Invalidate();
                    //toolTip1.Show(item.Name, panelDrawing, new Point(e.X+10, e.Y+10));
                    break;
                }
            }

        }

        //private void panelDrawing_MouseDown(object sender, MouseEventArgs e)
        //{
        //    foreach (Shape item in shapes)
        //    {
        //        if (item.GraphicsPath.IsVisible(e.X, e.Y))
        //        {
        //            shapes.BringToFront(item);
        //            toolTip1.Hide(panelDrawing);
        //            panelDrawing.Invalidate();
        //            break;
        //        }
        //    }
        //}

        private void panelDrawing_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape item in shapes)
            {
                item.Draw(e.Graphics);
            }
        }

        #region область наполнения раскрывающегося списка с рацветками
        string[] names;
        Array values;
        void GetColorsFromComboBox()
        {
            names = Enum.GetNames(typeof(System.Drawing.KnownColor));
            values = Enum.GetValues(typeof(System.Drawing.KnownColor));
            
            for (int i = 0; i < names.Length; i++)
			{
                Rectangle_ColorsPen.Items.Add(names[i]);
                Rectangle_ColorsBrush.Items.Add(names[i]);
                Circle_ColorsPen.Items.Add(names[i]);
                Circle_ColorsBrush.Items.Add(names[i]);
                Triangle_ColorsPen.Items.Add(names[i]);
                Triangle_ColorsBrush.Items.Add(names[i]);
                Ellips_ColorsPen.Items.Add(names[i]);
                Ellips_ColorsBrush.Items.Add(names[i]);
                Polygon_ColorsPen.Items.Add(names[i]);
                Polygon_ColorsBrush.Items.Add(names[i]);
                Square_ColorsPen.Items.Add(names[i]);
                Square_ColorsBrush.Items.Add(names[i]);
			}
            
        }
        void ComboBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            e.DrawBackground();
            Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2,
                                                e.Bounds.Height,
                                                e.Bounds.Height - 4);
            e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.FromName(names[e.Index])), rectangle);
            e.Graphics.DrawString(names[e.Index], e.Font,
                                    System.Drawing.Brushes.Black,
                                    new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y,
                                    e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }
        #endregion

        #region создание фигур
        private void Regtangle_Create_Click(object sender, EventArgs e)
        {
            OurRectangle rectangle = new OurRectangle(Convert.ToInt32(Rectangle_X.Value),
                                        Convert.ToInt32(Rectangle_Y.Value),
                                        Convert.ToInt32(Rectangle_Widht.Value),
                                        Convert.ToInt32((Rectangle_Heigth.Value)));
            rectangle.Name = "Прямоугольник";
            rectangle.Pen = new Pen(Color.FromName(Rectangle_ColorsPen.SelectedItem.ToString()),
                                                Convert.ToInt32(Rectangle_WidhtTickness.Value));
            rectangle.Brush = new SolidBrush(Color.FromName(Rectangle_ColorsBrush.SelectedItem.ToString()));
            shapes.Add(rectangle);
            panelDrawing.Invalidate();
        }

        private void Circle_Create_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle(Convert.ToInt32(Circle_X.Value),
                                          Convert.ToInt32(Circle_Y.Value),
                                          Convert.ToInt32(Circle_Diametr.Value));
            circle.Name = "Круг";
            circle.Pen = new Pen(Color.FromName(Circle_ColorsPen.SelectedItem.ToString()),
                                                Convert.ToInt32(Circle_WidthTickness.Value));
            circle.Brush = new SolidBrush(Color.FromName(Circle_ColorsBrush.SelectedItem.ToString()));
            shapes.Add(circle);
            panelDrawing.Invalidate();
        }

        private void Triangle_Create_Click(object sender, EventArgs e)
        {
            Triangle triangle = new Triangle(new Point(Convert.ToInt32(Triangle_1Line_X.Value), Convert.ToInt32(Triangle_1Line_Y.Value)),
                                            new Point(Convert.ToInt32(Triangle_2Line_X.Value), Convert.ToInt32(Triangle_2Line_Y.Value)),
                                            new Point(Convert.ToInt32(Triangle_3Line_X.Value), Convert.ToInt32(Triangle_3Line_Y.Value)));
            triangle.Name = "Треугольник";
            triangle.Pen = new Pen(Color.FromName(Triangle_ColorsPen.SelectedItem.ToString()),
                                                Convert.ToInt32(Triangle_WidhtTickness.Value));
            triangle.Brush = new SolidBrush(Color.FromName(Triangle_ColorsBrush.SelectedItem.ToString()));
            shapes.Add(triangle);
            panelDrawing.Invalidate();
        }

        private void EllipsCreate_Click(object sender, EventArgs e)
        {
            Ellips ellips = new Ellips(Convert.ToInt32(Ellips_X.Value),
                                          Convert.ToInt32(Ellips_Y.Value),
                                          Convert.ToInt32(Ellips_Width.Value),
                                          Convert.ToInt32(Ellips_Height.Value));
            ellips.Name = "Эллипс";
            ellips.Pen = new Pen(Color.FromName(Ellips_ColorsPen.SelectedItem.ToString()),
                                                Convert.ToInt32(Ellips_WidthTickness.Value));
            ellips.Brush = new SolidBrush(Color.FromName(Ellips_ColorsBrush.SelectedItem.ToString()));
            shapes.Add(ellips);
            panelDrawing.Invalidate();
        }

        private void Polygon_Create_Click(object sender, EventArgs e)
        {
            Polygon polygon = new Polygon(PolygonPoints);
            polygon.Name = "Многоугольник";
            polygon.Pen = new Pen(Color.FromName(Polygon_ColorsPen.SelectedItem.ToString()),
                                    Convert.ToInt32(Polygon_WidthTickness.Value));
            polygon.Brush = new SolidBrush(Color.FromName(Polygon_ColorsBrush.SelectedItem.ToString()));
            shapes.Add(polygon);
            panelDrawing.Invalidate();
        }

        private void Square_Create_Click(object sender, EventArgs e)
        {
            Square square = new Square(Convert.ToInt32(Square_X.Value),
                            Convert.ToInt32(Square_Y.Value),
                            Convert.ToInt32(Square_Side.Value));
            square.Name = "Квадрат";
            square.Pen = new Pen(Color.FromName(Square_ColorsPen.SelectedItem.ToString()),
                                                Convert.ToInt32(Square_WidthTickness.Value));
            square.Brush = new SolidBrush(Color.FromName(Square_ColorsBrush.SelectedItem.ToString()));
            shapes.Add(square);
            panelDrawing.Invalidate();
        }
        #region для создания многоугольника
        Point[] PolygonPoints;
        
        private void Polygon_LinesCount_ValueChanged(object sender, EventArgs e)
        {
            PolygonPoints = new Point[Convert.ToInt32(Polygon_LinesCount.Value)];
            Polygon_NameLines.Items.Clear();
            for (int i = 0; i < PolygonPoints.Length; i++)
            {
                Polygon_NameLines.Items.Add((i + 1).ToString() + " точка");
            }
            Polygon_NameLines.SelectedIndex = 0;
        }
         private void Polygon_NameLines_SelectedIndexChanged(object sender, EventArgs e)
         {
             int index = Polygon_NameLines.SelectedIndex;
             Polygon_X.Value = PolygonPoints[index].X;
             Polygon_Y.Value = PolygonPoints[index].Y;
         }
         private void Polygon_X_ValueChanged(object sender, EventArgs e)
         {
             PolygonPoints[Polygon_NameLines.SelectedIndex].X = Convert.ToInt32(Polygon_X.Value);
         }
         private void Polygon_Y_ValueChanged(object sender, EventArgs e)
         {
             PolygonPoints[Polygon_NameLines.SelectedIndex].Y = Convert.ToInt32(Polygon_Y.Value);
         }
        #endregion
        #endregion

        private void buttonClearDrawing_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            panelDrawing.Invalidate();
        }













    }
}
