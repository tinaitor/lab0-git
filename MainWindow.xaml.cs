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
            Rectangle rect = new Rectangle(
                new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height)),
                rnd.Next(20, 200),
                rnd.Next(20, 150)
            );
            DrawRectangle(rect);
        }
        public void DrawFiguresByPoints(
        Point2D triangleP1,
        Point2D triangleP2,
        Point2D triangleP3,
        Point2D squareStart,
        int squareSide)
        {
        tr = new Triangle(triangleP1, triangleP2, triangleP3);

        Rectangle square = new Rectangle(squareStart,squareSide,squareSide);

        ClearScene();
        DrawTriangle(tr);
        DrawRectangle(square);
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
        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            string[] t = TriangleInput.Text.Split(',');
            string[] s = SquareInput.Text.Split(',');

            DrawFiguresByPoints(
                new Point2D(int.Parse(t[0]), int.Parse(t[1])),
                new Point2D(int.Parse(t[2]), int.Parse(t[3])),
                new Point2D(int.Parse(t[4]), int.Parse(t[5])),
                new Point2D(int.Parse(s[0]), int.Parse(s[1])),
                int.Parse(s[2])
            );
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            DrawFiguresByPoints(
                new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height)),
                new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height)),
                new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height)),
                new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height)),
                rnd.Next(20, 150)
            );
        }
    }

}