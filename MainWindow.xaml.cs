using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab0_git
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void AddX(int x)
        {
            X += x;
        }
        public void AddY(int y)
        {
            Y += y;
        }
    }
    public partial class MainWindow : Window
    {
        Triangle tr;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();

            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            tr = new Triangle(p1, p2, p3);
            DrawTriangle(tr);
            Rectangle rect = new Rectangle(new Point2D(50, 50), 150, 100);
            DrawRectangle(rect);
        }

        public void DrawLine(Point2D p1, Point2D p2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;
            Scene.Children.Add(line);
        }

        public void DrawTriangle(Triangle tr)
        {
            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }
        public void DrawRectangle(Rectangle rect)
        {
            Point2D p1 = rect.Start;
            Point2D p2 = new Point2D(rect.Start.X + rect.Width, rect.Start.Y);
            Point2D p3 = new Point2D(rect.Start.X + rect.Width, rect.Start.Y + rect.Height);
            Point2D p4 = new Point2D(rect.Start.X, rect.Start.Y + rect.Height);

            DrawLine(p1, p2);
            DrawLine(p2, p3);
            DrawLine(p3, p4);
            DrawLine(p4, p1);
        }
        public void ClearScene()
        {
            Scene.Children.Clear();
        }
    }
}