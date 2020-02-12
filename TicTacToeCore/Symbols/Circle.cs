using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToeCore.Symbols
{
    internal class Circle
    {
        private static TranslateTransform PositionCircle() => new TranslateTransform(6, 6);

        private static Ellipse CircleDrawing()
        {
            var ellipse = new Ellipse
            {
                Width = 35,
                Height = 35,
                Stroke = Brushes.Gray,
                StrokeThickness = 3,
                RenderTransform = PositionCircle()
            };
            return ellipse;
        }

        public static void Draw(Canvas canvas)
        {
            canvas.Children.Add(CircleDrawing());
        }
    }
}