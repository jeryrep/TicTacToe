using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToe.WPF.Symbols
{
    internal class Cross
    {
        private static Line DrawLeftLine()
        {
            var myLine = new Line
            {
                Stroke = Brushes.Gray,
                X1 = 38,
                X2 = 8,
                Y1 = 8,
                Y2 = 38,
                StrokeThickness = 3
            };
            return myLine;
        }

        private static Line DrawRightLine()
        {
            var myLine = new Line
            {
                Stroke = Brushes.Gray,
                X1 = 8,
                X2 = 38,
                Y1 = 8,
                Y2 = 38,
                StrokeThickness = 3
            };
            return myLine;
        }

        public static void Draw(Canvas canvas)
        {
            canvas.Children.Add(DrawLeftLine());
            canvas.Children.Add(DrawRightLine());
        }
    }
}